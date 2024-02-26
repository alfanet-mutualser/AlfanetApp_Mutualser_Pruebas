using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MaeExpediente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.TreeViewExpediente.Nodes.Clear();
            CrearNodosDelPadre(null, null);
            this.ExceptionDetails.Visible = false;
            this.DGExpediente.DisplayLayout.Pager.StyleMode = Infragistics.WebUI.UltraWebGrid.PagerStyleMode.QuickPages;

        }
        else
        {
            
        }

    }


    protected void ImgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.DGExpediente.DisplayLayout.CellClickActionDefault = Infragistics.WebUI.UltraWebGrid.CellClickAction.RowSelect;
        this.DVExpediente.ChangeMode(DetailsViewMode.ReadOnly);

    }

    protected void DetailsView_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.ExceptionDetails.Visible = true;
            this.ExceptionDetails.Text = "Ocurrio un problema al tratar de adicionar el registro. ";

            Exception inner = e.Exception.InnerException;
            this.ExceptionDetails.Text += ErrorHandled.FindError(inner);

            //Indicate tahat exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {

            WebMsgBox.Show("Registro Adicionado");
            DGExpediente.DataBind();
            this.TreeViewExpediente.Nodes.Clear();
            CrearNodosDelPadre(null, null);
            this.DVExpediente.ChangeMode(DetailsViewMode.ReadOnly);

        }
    }


    protected void DetailsView_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.ExceptionDetails.Visible = true;
            this.ExceptionDetails.Text = "Ocurrio un problema al tratar de actualizar el registro. ";

            Exception inner = e.Exception.InnerException;
            this.ExceptionDetails.Text += ErrorHandled.FindError(inner);
            

            //Indicate tahat exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)

        WebMsgBox.Show("Registro Editado");
        DGExpediente.DataBind();
        this.TreeViewExpediente.Nodes.Clear();
        CrearNodosDelPadre(null, null);
        this.DVExpediente.ChangeMode(DetailsViewMode.ReadOnly);

    }


    protected void DetailsView_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.ExceptionDetails.Visible = true;
            this.ExceptionDetails.Text = "Ocurrio un problema al tratar de eliminar el registro. ";

            Exception inner = e.Exception.InnerException;
            this.ExceptionDetails.Text += ErrorHandled.FindError(inner);

            //Indicate tahat exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)

        WebMsgBox.Show("Registro Eliminado");
        DGExpediente.DataBind();
        this.TreeViewExpediente.Nodes.Clear();
        CrearNodosDelPadre(null, null);
        this.DVExpediente.ChangeMode(DetailsViewMode.Insert);

    }


    private int CrearNodosDelPadre(string IndicePadre, Infragistics.WebUI.UltraWebNavigator.Node nodePadre)
    {

       foreach (DataRowView dataRowCurrent in ExpedienteDataSource.Select())
       {
           Infragistics.WebUI.UltraWebNavigator.Node nuevoNodo = new Infragistics.WebUI.UltraWebNavigator.Node();
           nuevoNodo.DataKey = dataRowCurrent[0].ToString().Trim();
           nuevoNodo.Text = dataRowCurrent[1].ToString().Trim();

           if (dataRowCurrent[2].ToString().Trim() == "0" && nodePadre == null)
           {
               //Crea nodos padre
               TreeViewExpediente.Nodes.Add(nuevoNodo);
               CrearNodosDelPadre(dataRowCurrent[0].ToString().Trim(), nuevoNodo);
           }
           else
           {
               if (dataRowCurrent[0].ToString().Trim() != IndicePadre)
               {
                   if (dataRowCurrent[2].ToString().Trim() == IndicePadre)
                   {
                       nodePadre.Nodes.Add(nuevoNodo);
                       CrearNodosDelPadre(dataRowCurrent[0].ToString().Trim(), nuevoNodo);
                   }
               }
           }
       }

       // Retorno Final
       return 1;

    }


}

