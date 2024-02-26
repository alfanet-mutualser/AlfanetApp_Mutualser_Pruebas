using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.NetworkInformation;

public partial class _MaestroWorkFlowProceso : System.Web.UI.Page 
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro WFPROCESOS";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "Error";
    protected void Page_Load(object sender, EventArgs e)
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
                Session["IP"] = localIP;
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();

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
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVWFProceso.DataBind();
            //this.DVDependenciaPermiso.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }      
    }

    protected void DetailsView_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de actualizar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)
        {

            if (this.TxtDepartamento.Text != "")
            {
                if (this.TxtDepartamento.Text.Contains(" | "))
                {
                    this.HFCodigoSeleccionado.Value = TxtDepartamento.Text.Remove(TxtDepartamento.Text.IndexOf(" | "));
                    this.DVWFProceso.ChangeMode(DetailsViewMode.ReadOnly);
                }
            }
            this.DVWFProceso.DataBind();
            //this.DVDependenciaPermiso.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }        
    }

    protected void DetailsView_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)
        {
            this.DVWFProceso.DataBind();
            //this.DVDependenciaPermiso.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }           
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //this.HFNroDetCount.Value = "1";
        this.DVWFProcesoDetalle.ChangeMode(DetailsViewMode.Insert);
        this.DVWFProcesoDetalle.Visible = true;
       
    }

    protected void DVWFProceso_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        this.DVWFProceso.PageIndex = e.NewPageIndex;
        
    }

    protected void DVWFProceso_PageIndexChanged(object sender, EventArgs e)
    {      
        
    }

    protected void DVWFProceso_DataBound(object sender, EventArgs e)
    {
        //DVWFProceso.SelectedValue.ToString();
        //DetailsView DVProceso = DVWFProceso.
       

            if (this.DVWFProceso.CurrentMode == DetailsViewMode.ReadOnly)
            {
                if (DVWFProceso.PageCount > 0)
                {

                string data = DVWFProceso.DataKey.Value.ToString();
                DSProcesoTableAdapters.WFProcesoDetalle1TableAdapter OBJPROceso = new DSProcesoTableAdapters.WFProcesoDetalle1TableAdapter();

                DSProceso.WFProcesoDetalle1DataTable DTProcesodetalle = new DSProceso.WFProcesoDetalle1DataTable();

                DTProcesodetalle = OBJPROceso.GetWFProcesoDetalleById(data);

                if (DTProcesodetalle.Count == 0)
                {
                    LinkButton1.Enabled = true;
                    this.DVWFProcesoDetalle.Visible = false;
                    this.HFNroDetCount.Value = "1";
                }
                else
                {
                    LinkButton1.Enabled = false;
                    this.DVWFProcesoDetalle.Visible = true;
                    this.DVWFProcesoDetalle.DataBind();
                    this.DVWFProcesoDetalle.ChangeMode(DetailsViewMode.ReadOnly);
                    //this.WFProcesoDetalleDataSource.DataBind();
                }

                Label Lb = (Label)DVWFProceso.FindControl("Label1");

                if (Lb.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProceso.FindControl("CheckBox1");
                    Ch.Checked = true;
                    Ch.Enabled = false;
                }                
            }
            else
            {

            }

            }
            else if (this.DVWFProceso.CurrentMode == DetailsViewMode.Edit)
            {
                TextBox Text = (TextBox)DVWFProceso.FindControl("TextBox1");

                if (Text.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProceso.FindControl("CheckBox1");
                    Ch.Checked = true;
                    Ch.Enabled = true;
                }
            }
            else if (this.DVWFProceso.CurrentMode == DetailsViewMode.Insert)
            {
                TextBox Text = (TextBox)DVWFProceso.FindControl("TextBox1");

                if (Text.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProceso.FindControl("CheckBox1");
                    Ch.Checked = true;
                    Ch.Enabled = false;
                }
            }

        

    }

    protected void DVWFProcesoDetalle_DataBound(object sender, EventArgs e)
    {
        if (this.DVWFProcesoDetalle.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVWFProcesoDetalle.FindControl("Label1");
            if (Lb != null)
            {
                if (Lb.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProcesoDetalle.FindControl("CheckBox1");
                    Ch.Checked = true;
                    Ch.Enabled = false;
                }
            }
            
            HFNroDetCount.Value = Convert.ToString(DVWFProcesoDetalle.PageCount + 1);
        }
        else if (this.DVWFProcesoDetalle.CurrentMode == DetailsViewMode.Edit)
        {
           
            TextBox Text = (TextBox)DVWFProcesoDetalle.FindControl("TextBox1");
            if (Text != null)
            {
                if (Text.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProcesoDetalle.FindControl("CheckBox1");
                    Ch.Checked = true;
                    Ch.Enabled = true;                    
                }
            }

            RadioButtonList RbtLst = (RadioButtonList)DVWFProcesoDetalle.FindControl("RadioButtonList1");
            RbtLst.SelectedValue = HFRbtLst.Value;
            TextBox TextDep = (TextBox)DVWFProcesoDetalle.FindControl("TextBox2");
            TextBox TextSer = (TextBox)DVWFProcesoDetalle.FindControl("TextBox3");
            if (TextDep.Text != "" && HFRbtLst.Value == "")
            {
                RbtLst.SelectedValue = "1";
            }
            else if (TextSer.Text != "" && HFRbtLst.Value == "")
            {
                RbtLst.SelectedValue = "0";
            }
            //else if (HFRbtLst.Value != "")
            //{
            //    if (HFRbtLst.Value == "1")
            //    {
            //        TextDep.Text = null;
            //    }
            //    else if (HFRbtLst.Value == "0")
            //    {
            //        TextSer.Text = null;
            //    }
            //}
            if (RbtLst.SelectedValue == "1")
            {
                TextDep.Visible = true;
                TextSer.Visible = false;
                this.DVWFProcesoDetalle.Fields[3].HeaderText = "Dependencia";
            }
            else if (RbtLst.SelectedValue == "0")
            {
                TextDep.Visible = false;
                TextSer.Visible = true;
                this.DVWFProcesoDetalle.Fields[3].HeaderText = "Serie";
            }
        }
        else if (this.DVWFProcesoDetalle.CurrentMode == DetailsViewMode.Insert)
        {
            Label Lb1 = (Label)DVWFProcesoDetalle.FindControl("Label1");
            if (Lb1 != null)
            {
                Lb1.Text = this.HFCodigoSeleccionado.Value;
            }
            TextBox Text = (TextBox)DVWFProcesoDetalle.FindControl("TextBox1");
            if (Text != null)
            {
                if (Text.Text == "1")
                {
                    CheckBox Ch = (CheckBox)DVWFProcesoDetalle.FindControl("CheckBox1");
                    Ch.Checked = true;
                    //Ch.Enabled = false;
                }
            }            
            Label Lb2 = (Label)DVWFProcesoDetalle.FindControl("Label2");
            Lb2.Text = HFNroDetCount.Value;

            RadioButtonList RbtLst = (RadioButtonList)DVWFProcesoDetalle.FindControl("RadioButtonList1");
            RbtLst.SelectedValue = HFRbtLst.Value;
            TextBox TextDep = (TextBox)DVWFProcesoDetalle.FindControl("TextBox2");
            TextBox TextSer = (TextBox)DVWFProcesoDetalle.FindControl("TextBox3");
            if (RbtLst.SelectedValue == "1")
            {
                TextDep.Visible = true;
                TextSer.Visible = false;
                this.DVWFProcesoDetalle.Fields[3].HeaderText = "Dependencia";
            }
            else if (RbtLst.SelectedValue == "0")
            {
                TextDep.Visible = false;
                TextSer.Visible = true;
                this.DVWFProcesoDetalle.Fields[3].HeaderText = "Serie";
            }
        }

    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVWFProceso.FindControl("CheckBox1");
        TextBox Text = (TextBox)DVWFProceso.FindControl("TextBox1");
        string ActLogCod = "INSERTAR";
        TextBox TxtDescripcion = (TextBox)DVWFProceso.FindControl("TextBox4");
        string nombre = TxtDescripcion.Text;
        TextBox TxtCodigo = (TextBox)DVWFProceso.FindControl("TextBox3");
        string codigo = TxtCodigo.Text;

        if (Ch.Checked == true)
        {
            Text.Text = "1";
        }
        else
        {
            Text.Text = "0";
        }

        string habilitar = this.WFProcesoDataSource.InsertParameters["WFProcesoHabilitar"].DefaultValue;
        TextBox TxtBox = (TextBox)DVWFProceso.FindControl("TextBox2");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains(" | "))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
            }
        }
        this.WFProcesoDataSource.InsertParameters["WFProcesoCodigoPadre"].DefaultValue = "0";

        //OBTENER CONSECUTIVO DE LOGS E INSERTAR EN TABLAS LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        Int64 LogId = Convert.ToInt64(LOG);
        string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
        string DatosIni = "Nuevo";// WFPROCESOCod + ProcesoNombre + Habilitar
        string DatosFin = TxtCodigo.Text + " | " + nombre + " | " + habilitar;
        DateTime FechaFin = DateTime.Now;
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Se hace insert de Log añadir proceso
        DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
        BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo Log
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVWFProceso.FindControl("CheckBox1");
        TextBox Text = (TextBox)DVWFProceso.FindControl("TextBox1");
        string ActLogCod = "ACTUALIZAR";
        TextBox TxtDescripcion = (TextBox)DVWFProceso.FindControl("TextBox3");
        string nombre = TxtDescripcion.Text;
        Label LblCodigo = (Label)DVWFProceso.FindControl("Label1");
        string codigo = LblCodigo.Text;

        if (Ch.Checked == true)
        {
            Text.Text = "1";
        }
        else
        {
            Text.Text = "0";
        }

        string habilitar = this.WFProcesoDataSource.UpdateParameters["WFProcesoHabilitar"].DefaultValue;
        // WFPROCESOCod + ProcesoNombre + Habilitar
        string DatosIni = DVWFProceso.SelectedValue + " | " + habilitar;
        TextBox TxtBox = (TextBox)DVWFProceso.FindControl("TextBox2");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains(" | "))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
            }
        }
        //OBTENER CONSECUTIVO DE LOGS E INSERTAR EN TABLAS LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        Int64 LogId = Convert.ToInt64(LOG);
        string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
        // WFPROCESOCod + ProcesoNombre + Habilitar
        string DatosFin = codigo + " | " + nombre + " | " + habilitar;
        DateTime FechaFin = DateTime.Now;
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert de Log actualizar proceso
        DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
        BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo de Log
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        //DVWFProceso.ChangeMode(DetailsViewMode.ReadOnly);
    }
    protected void ImgBtnUpdateDetalle_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVWFProcesoDetalle.FindControl("CheckBox1");
        TextBox Text = (TextBox)DVWFProcesoDetalle.FindControl("TextBox1");

        TextBox TxtDescripcion = (TextBox)DVWFProcesoDetalle.FindControl("TextBox4"); string nombre = TxtDescripcion.Text;
        Label LblCodigo = (Label)DVWFProcesoDetalle.FindControl("Label1"); string codigo = LblCodigo.Text;
        Label LblDetallePaso = (Label)DVWFProcesoDetalle.FindControl("Label2"); string detallepaso = LblDetallePaso.Text;
        TextBox TxtTiempo = (TextBox)DVWFProcesoDetalle.FindControl("TextBox5"); string tiempo = TxtTiempo.Text;
        string ActLogCod = "ACTUALIZAR_DETALLE";

        if (Ch.Checked == true)
        {
            Text.Text = "1";
        }
        else
        {
            Text.Text = "0";
        }
        RadioButtonList RbtLst = (RadioButtonList)DVWFProcesoDetalle.FindControl("RadioButtonList1");
        TextBox TxtBox = (TextBox)DVWFProcesoDetalle.FindControl("TextBox2");
        TextBox TxtBoxSerie = (TextBox)DVWFProcesoDetalle.FindControl("TextBox3");
        if (RbtLst.SelectedValue == "1")
        {            
            if (TxtBox.Text != "")
            {
                if (TxtBox.Text.Contains(" | "))
                {
                    TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
                }
            }
            TxtBoxSerie.Text = null;
            
        }
        else if (RbtLst.SelectedValue == "0")
        {            
            if (TxtBoxSerie.Text != "")
            {
                if (TxtBoxSerie.Text.Contains(" | "))
                {
                    TxtBoxSerie.Text = TxtBoxSerie.Text.Remove(TxtBoxSerie.Text.IndexOf(" | "));
                }
            }
            TxtBox.Text = null;
        }
        TextBox TxtBoxAccion = (TextBox)DVWFProcesoDetalle.FindControl("TextBox4");

        if (TxtBoxAccion.Text != "")
        {
            if (TxtBoxAccion.Text.Contains(" | "))
            {
                TxtBoxAccion.Text = TxtBoxAccion.Text.Remove(TxtBoxAccion.Text.IndexOf(" | "));
            }
        }
        //this.WFProcesoDetalleDataSource.UpdateParameters["WFAccionNombre"].DefaultValue = null;
        //this.WFProcesoDetalleDataSource.UpdateParameters["DependenciaNombre"].DefaultValue = null;
        //this.WFProcesoDetalleDataSource.UpdateParameters["SerieNombre"].DefaultValue = null;
        string habilitar = this.WFProcesoDataSource.InsertParameters["WFProcesoHabilitar"].DefaultValue;
        string DatosIni = "WFProceso de codigo: " + DVWFProceso.SelectedValue + " Habilitar:" + habilitar;
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        Int64 LogId = Convert.ToInt64(LOG);
        string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
        // WFPROCESOCod +  Habilitar
        string DatosFin = DVWFProceso.SelectedValue + " | " + habilitar;
        DateTime FechaFin = DateTime.Now;
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert de Log actualizar detalle
        DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
        BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo Log
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
    protected void ImgBtnInsertDetalle_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVWFProcesoDetalle.FindControl("CheckBox1");
        TextBox Text = (TextBox)DVWFProcesoDetalle.FindControl("TextBox1");
        if (Ch.Checked == true)
        {
            Text.Text = "1";
        }
        else
        {
            Text.Text = "0";
        }
        this.WFProcesoDetalleDataSource.InsertParameters["WFProcesoDetalleHabilitar"].DefaultValue = Text.Text;

        RadioButtonList RbtLst = (RadioButtonList)DVWFProcesoDetalle.FindControl("RadioButtonList1");

        if (RbtLst.SelectedValue == "1")
        {
            TextBox TxtBox = (TextBox)DVWFProcesoDetalle.FindControl("TextBox2");

            if (TxtBox.Text != "")
            {
                if (TxtBox.Text.Contains(" | "))
                {
                    TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
                }
            }
            this.WFProcesoDetalleDataSource.InsertParameters["DependenciaCodigo"].DefaultValue = TxtBox.Text;
        }
        else if (RbtLst.SelectedValue == "0")
        {
            TextBox TxtBoxSerie = (TextBox)DVWFProcesoDetalle.FindControl("TextBox3");

            if (TxtBoxSerie.Text != "")
            {
                if (TxtBoxSerie.Text.Contains(" | "))
                {
                    TxtBoxSerie.Text = TxtBoxSerie.Text.Remove(TxtBoxSerie.Text.IndexOf(" | "));
                }
            }
            this.WFProcesoDetalleDataSource.InsertParameters["SerieCodigo"].DefaultValue = TxtBoxSerie.Text;
        }
        TextBox TxtBoxAccion = (TextBox)DVWFProcesoDetalle.FindControl("TextBox4");

        if (TxtBoxAccion.Text != "")
        {
            if (TxtBoxAccion.Text.Contains(" | "))
            {
                TxtBoxAccion.Text = TxtBoxAccion.Text.Remove(TxtBoxAccion.Text.IndexOf(" | "));
            }
        }
        this.WFProcesoDetalleDataSource.InsertParameters["WFAccionCodigo"].DefaultValue = TxtBoxAccion.Text;

        Label LblWFProCod = (Label)DVWFProcesoDetalle.FindControl("Label1");
        this.WFProcesoDetalleDataSource.InsertParameters["WFProcesoCodigo"].DefaultValue = LblWFProCod.Text;

        Label LblWFProCodPaso = (Label)DVWFProcesoDetalle.FindControl("Label2");
        this.WFProcesoDetalleDataSource.InsertParameters["WFProcesoDetallePaso"].DefaultValue = LblWFProCodPaso.Text;
        //this.WFProcesoDetalleDataSource.InsertParameters["WFAccionNombre"].DefaultValue = null;
        //this.WFProcesoDetalleDataSource.InsertParameters["DependenciaNombre"].DefaultValue = null;
        //this.WFProcesoDetalleDataSource.InsertParameters["SerieNombre"].DefaultValue = null;


    }
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtDepartamento.Text != "")
        {
            if (TxtDepartamento.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtDepartamento.Text.Remove(TxtDepartamento.Text.IndexOf(" | "));
                this.DVWFProceso.ChangeMode(DetailsViewMode.ReadOnly);
                this.DVWFProceso.DataBind();
                this.DVWFProcesoDetalle.DataBind();                
                this.TxtDepartamento.Text = null;
                this.HFRbtLst.Value = null;
                this.LinkButton1.Visible = true;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                Int64 LogId = Convert.ToInt64(LOG);
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                string DatosIni = "Buscar";
                string DatosFin = "Se busco WFProceso de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();  //Se hace insert de Log buscar proceso
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //actualiza consecutivo log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }        
    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.DVWFProcesoDetalle.Visible = false;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList RbtLst = (RadioButtonList)DVWFProcesoDetalle.FindControl("RadioButtonList1");
        TextBox TextDep = (TextBox)DVWFProcesoDetalle.FindControl("TextBox2");
        TextBox TextSer = (TextBox)DVWFProcesoDetalle.FindControl("TextBox3");
        this.HFRbtLst.Value = RbtLst.SelectedValue;
        if (RbtLst.SelectedValue == "1")
        {
            TextDep.Visible = true;
            TextSer.Text = null;
            TextSer.Visible = false;
            this.DVWFProcesoDetalle.Fields[3].HeaderText = "Dependencia";

        }
        else if (RbtLst.SelectedValue == "0")
        {
            TextDep.Visible = false;
            TextSer.Visible = true;
            TextDep.Text = null;
            this.DVWFProcesoDetalle.Fields[3].HeaderText = "Serie";
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        //Eliminar el proceso seleccionado
        if ("PROCESO" == this.HDFSeleccion.Value)
            this.DVWFProceso.DeleteItem();
        //Eliminar el detalle del proceso
        else if ("DETALLEPROCESO" == this.HDFSeleccion.Value)
            this.DVWFProcesoDetalle.DeleteItem();
    }
    protected void ImgBtnDelete_Click(object sender, EventArgs e)
    {
        this.Label7.Text = "¿Va a eliminar proceso seleccionado, Está seguro?";
        this.HDFSeleccion.Value = "PROCESO";
        this.MPEPregunta.Show();
    }
    protected void ImgBtnDeleteDetalle_Click(object sender, EventArgs e)
    {
        this.Label7.Text = "¿Va a eliminar el detalle del proceso seleccionado, Está seguro?";
        this.HDFSeleccion.Value = "DETALLEPROCESO";
        this.MPEPregunta.Show();
    }
}
