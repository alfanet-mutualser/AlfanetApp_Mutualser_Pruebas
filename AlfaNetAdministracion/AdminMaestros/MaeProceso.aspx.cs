using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _MaeProceso : System.Web.UI.Page 
{



    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            //DibujarProceso();
            //WebMsgBox.Show("no post back");

            //this.TreeViewDepartamento.Nodes.Clear();
            //CrearNodosDelPadre(0, null, null);
            //this.ExceptionDetails.Visible = false;
            //this.DGDepartamento.DisplayLayout.Pager.StyleMode = Infragistics.WebUI.UltraWebGrid.PagerStyleMode.QuickPages;

        }
        else
        {
            //DibujarProceso();
            //WebMsgBox.Show("post back");
        }





        //Table table1 = new Table();
        //table1.BorderColor = System.Drawing.Color.Black;
        //table1.BorderWidth = Unit.Pixel(30);
        //table1.Width = Unit.Pixel(100);
        //table1.Height = Unit.Pixel(100);

        //TableRow table1row = new TableRow();
        //table1.Rows.Add(table1row);

        //PlaceHolder1.Controls.Add(table1);

        //Form.Controls.Add(table1);
        
     

       // Int32 i = 0;

       // for (i = 0; i <= 4; i++)
       // {
            //Button button = new Button();
            //button.ID = "Btn" + i;
            //PlaceHolder1.Controls.Add(button);
       // }




        //WebMsgBox.Show("Hola mundo");

        //Image ImgSerie = new Image();
        //Image ImgFlechaIzquierda = new Image();
        //Image ImgFlechaDerecha = new Image();

        //Table MyTable = new Table();
        //TableRow MyTableRow = new TableRow();

        //MyTable.BorderColor = 

        //MyTable.BorderWidth = 1;
        //MyTableRow.BorderWidth = 1;

        //MyTable.Rows.Add(MyTableRow);

        //PlaceHolder1.Controls.Add(MyTable);
        //PlaceHolder1.Controls.Add(MyTableRow);

        //ImgFlechaIzquierda.ImageUrl = "~/Images/WorkFlow/WFFlechaIzq.gif";
        //PlaceHolder1.Controls.Add(ImgFlechaIzquierda);

        //ImgSerie.ImageUrl = "~/Images/WorkFlow/WFArchivar.PNG";
        //ImgSerie.AlternateText = "Archivado en: ";
        //PlaceHolder1.Controls.Add(ImgSerie);

        //MyTableRow.Controls.Add(ImgFlechaIzquierda);


        

        // Create the parent FlowDocument...
        //flowDoc = new FlowDocument();

        // Create the Table...
        //table1 = new Table();
        // ...and add it to the FlowDocument Blocks collection.
        //flowDoc.Blocks.Add(table1);


        // Set some global formatting properties for the table.
        //table1.CellSpacing = 10;
        //table1.Background = Brushes.White;



        // Create 6 columns and add them to the table's Columns collection.
        //int numberOfColumns = 6;
        //for (int x = 0; x < numberOfColumns; x++)
        //{
          //  table1.Columns.Add(new TableColumn());

            // Set alternating background colors for the middle colums.
            //if (x % 2 == 0)
              //  table1.Columns[x].Background = Brushes.Beige;
            //else
              //  table1.Columns[x].Background = Brushes.LightSteelBlue;
        //}

    }


    protected void ImgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        //this.DGCiudad.DisplayLayout.CellClickActionDefault = Infragistics.WebUI.UltraWebGrid.CellClickAction.RowSelect;
        //this.DVCiudad.ChangeMode(DetailsViewMode.ReadOnly);

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

            //WebMsgBox.Show("Registro Adicionado");
            //this.Label1.Text = "hola mundo";
            //DGCiudad.DataBind();
            //this.TreeViewCiudad.Nodes.Clear();
            //CrearNodosDelPadre(0, null, null);
            //this.DVCiudad.ChangeMode(DetailsViewMode.ReadOnly);

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
        //DGCiudad.DataBind();
        //this.TreeViewCiudad.Nodes.Clear();
        //CrearNodosDelPadre(0, null, null);
        //this.DVCiudad.ChangeMode(DetailsViewMode.ReadOnly);

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
        //DGCiudad.DataBind();
        //this.TreeViewCiudad.Nodes.Clear();
        //CrearNodosDelPadre(0, null, null);
        //this.DVCiudad.ChangeMode(DetailsViewMode.Insert);

    }


    private int DibujarProceso(){

        

        Image ImgSerie = new Image();
        ImgSerie.ImageUrl = "~/Images/WorkFlow/WFArchivar.PNG";
        ImgSerie.AlternateText = "Archivado en: ";
        //PlaceHolder1.Controls.Add(ImgSerie);

        Table Table1 = new Table();
        Table1.ID = "Table1";
        Table1.BorderWidth = 5;


        TableRow TableRow1 = new TableRow();
        TableCell TableCell1 = new TableCell();
        TableCell1.Controls.Add(ImgSerie);
        TableRow1.Cells.Add(TableCell1);
        Table1.Rows.Add(TableRow1);


        foreach (DataRowView dataRowCurrent in WFProcesoDataSource.Select())
        {
            WebMsgBox.Show("hola mundo");
            //PlaceHolder1.Controls.Add(Table1);
        }


        

        return 1;
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {

        Table tempTable = new Table();
        tempTable.BorderWidth = 5;

        Image ImgSerie = new Image();
        ImgSerie.ImageUrl = "~/Images/WorkFlow/WFArchivar.PNG";
        ImgSerie.AlternateText = "Serie";

        Image ImgEscritorio = new Image();
        ImgEscritorio.ImageUrl = "~/Images/WorkFlow/WFEscritorio.PNG";
        ImgSerie.AlternateText = "Escritorio";

        Image ImgFlechaDer = new Image();
        ImgFlechaDer.ImageUrl = "~/Images/WorkFlow/WFFlechaDer.gif";
        ImgFlechaDer.AlternateText = "Escritorio";

        Image ImgFlechaIzq = new Image();
        ImgFlechaIzq.ImageUrl = "~/Images/WorkFlow/WFFlechaIzq.gif";
        ImgFlechaIzq.AlternateText = "Escritorio";


        foreach (DataRowView dataRowCurrent in WFProcesoDetalleDataSource.Select())
        {
            TableRow tempRow = new TableRow();
            TableCell tempCell = new TableCell();

            //WebMsgBox.Show(dataRowCurrent[5].ToString());

            tempCell.Text = string.Format("hola");
            
            tempRow.Cells.Add(tempCell);
            tempTable.Rows.Add(tempRow);

        }

        PlaceHolderProceso.Controls.Add(tempTable);

    }
}
