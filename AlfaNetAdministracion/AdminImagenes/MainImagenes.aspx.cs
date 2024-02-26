using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MainImagenes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.TreeViewCarpeta.Nodes.Clear();
            CrearNodosDelPadre(null, null);
            this.ExceptionDetails.Visible = false;
            this.DGCarpeta.DisplayLayout.Pager.StyleMode = Infragistics.WebUI.UltraWebGrid.PagerStyleMode.QuickPages;

        }
        else
        {
            
        }

    }


    protected void ImgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.DGCarpeta.DisplayLayout.CellClickActionDefault = Infragistics.WebUI.UltraWebGrid.CellClickAction.RowSelect;
        this.DVCarpeta.ChangeMode(DetailsViewMode.ReadOnly);

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
            DGCarpeta.DataBind();
            this.TreeViewCarpeta.Nodes.Clear();
            CrearNodosDelPadre(null, null);
            this.DVCarpeta.ChangeMode(DetailsViewMode.ReadOnly);

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
        DGCarpeta.DataBind();
        this.TreeViewCarpeta.Nodes.Clear();
        CrearNodosDelPadre(null, null);
        this.DVCarpeta.ChangeMode(DetailsViewMode.ReadOnly);

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
        DGCarpeta.DataBind();
        this.TreeViewCarpeta.Nodes.Clear();
        CrearNodosDelPadre(null, null);
        this.DVCarpeta.ChangeMode(DetailsViewMode.Insert);

    }


    private int CrearNodosDelPadre(string IndicePadre, Infragistics.WebUI.UltraWebNavigator.Node nodePadre)
    {

       foreach (DataRowView dataRowCurrent in CarpetaDataSource.Select())
       {
           Infragistics.WebUI.UltraWebNavigator.Node nuevoNodo = new Infragistics.WebUI.UltraWebNavigator.Node();
           nuevoNodo.DataKey = dataRowCurrent[0].ToString().Trim();
           nuevoNodo.Text = dataRowCurrent[1].ToString().Trim();

           if (dataRowCurrent[5].ToString().Trim() == "0" && nodePadre == null)
           {
               //Crea nodos padre
               TreeViewCarpeta.Nodes.Add(nuevoNodo);
               CrearNodosDelPadre(dataRowCurrent[0].ToString().Trim(), nuevoNodo);
           }
           else
           {
               if (dataRowCurrent[0].ToString().Trim() != IndicePadre)
               {
                   if (dataRowCurrent[5].ToString().Trim() == IndicePadre)
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

