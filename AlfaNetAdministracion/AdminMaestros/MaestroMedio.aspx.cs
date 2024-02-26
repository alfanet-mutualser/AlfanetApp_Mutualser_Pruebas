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

public partial class _MaestroMedio : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Medio";
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
            string Admon = Request["Admon"];
            if (Admon == "S")
            {
                ((MainMaster)this.Master).hidemenu();
            }
            else
            {
                //((MainMaster)this.Master).showmenu();
            }
            this.TCMedio.ActiveTabIndex = 0; 
        }
        else
        {

        }
                 
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtMedio.Text != "")
        {
            if (TxtMedio.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtMedio.Text.Remove(TxtMedio.Text.IndexOf(" | "));
                this.DVMedio.ChangeMode(DetailsViewMode.ReadOnly);
            }
            DSMedioSQLTableAdapters.MedioTableAdapter tamedio = new DSMedioSQLTableAdapters.MedioTableAdapter();
            DSMedioSQL.MedioDataTable DTMedio = new DSMedioSQL.MedioDataTable();
            DTMedio = tamedio.GetMedioById(HFCodigoSeleccionado.Value);
            RbtnLstPermiso.SelectedValue = DTMedio[0].MedioPermiso;
            TextBox4.Text = DTMedio[0].MedioFactor;
            string nombre = DTMedio[0].MedioNombre;
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
            string DatosFin = HFCodigoSeleccionado.Value + " | " + nombre;//MEDIOCOD+ MedioNombre
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace insert de Log Buscar medio
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo de Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);


        }
    }

    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //TextBox TxtBox = (TextBox)DVMedio.FindControl("TxtPais");

        //if (TxtBox.Text != "")
        //{
        //    if (TxtBox.Text.Contains(" | "))
        //    {
        //        TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
        //    }
        //}
    }

    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVMedio.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox2");
            Txt.Text = "1";
            this.MedioByIdDataSource.InsertParameters["MedioHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox2");
            Txt.Text = "0";
            this.MedioByIdDataSource.InsertParameters["MedioHabilitar"].DefaultValue = "0";
        }
        this.MedioByIdDataSource.InsertParameters["MedioPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        TextBox Txt3 = (TextBox)DVMedio.FindControl("TextBox3");
        this.HFCodigoSeleccionado.Value = Txt3.Text;
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVMedio.DataItemCount.ToString() == "0")
        {
            this.DVMedio.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVMedio.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVMedio.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVMedio.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVMedio.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVMedio.FindControl("Label1");

            DSMedioSQLTableAdapters.Medio_ReadExisteMedioTableAdapter TAMedioExiste = new DSMedioSQLTableAdapters.Medio_ReadExisteMedioTableAdapter();
            DSMedioSQL.Medio_ReadExisteMedioDataTable DTMedioExiste = new DSMedioSQL.Medio_ReadExisteMedioDataTable();
            DTMedioExiste = TAMedioExiste.GetMedio_ReadExisteMedio(LblCodProce.Text);

            Label LblProce = (Label)DVMedio.FindControl("Label4");
            TextBox TxtProce = (TextBox)DVMedio.FindControl("TextBox3");
            Label LblProceMsg = (Label)DVMedio.FindControl("Label13");

            if (DTMedioExiste.Count == 0)
            {
                LblProce.Visible = false;
                TxtProce.Visible = true;
                LblProceMsg.Visible = false;
            }
            else
            {
                LblProce.Visible = true;
                LblProceMsg.Visible = true;
                TxtProce.Visible = false;
            }            

            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVMedio.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }

            TextBox TxtPadre = (TextBox)DVMedio.FindControl("TextBox1");
            if (TxtPadre.Text != "")
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVMedio.FindControl("RbtnLstSelPadre");
                RBLPadre.SelectedValue = "1";
                TxtPadre.Visible = true;

            }
            else
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVMedio.FindControl("RbtnLstSelPadre");
                RBLPadre.SelectedValue = "0";
                TxtPadre.Visible = false;
            }
        }
    }

    protected void DVDepartamento_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
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
            this.DVMedio.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVDepartamento_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
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
            this.DVMedio.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVDepartamento_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
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
            this.DVMedio.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtMedio.Text = "";
        this.HFCodigoSeleccionado.Value = null;
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.MedioByIdDataSource.UpdateParameters["Original_MedioCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        //this.HFCodigoSeleccionado.Value = null;
        this.TxtMedio.Text = "";
        this.Label7.Text = "¿Va a eliminar el Medio seleccionado esta seguro?" + " ";
        this.MPEPregunta.Show();

    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVMedio.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox2");
            Txt.Text = "1";

            this.MedioByIdDataSource.UpdateParameters["MedioHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox2");
            Txt.Text = "0";
            this.MedioByIdDataSource.UpdateParameters["MedioHabilitar"].DefaultValue = "0";
        }
        this.MedioByIdDataSource.UpdateParameters["Original_MedioCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.MedioByIdDataSource.UpdateParameters["MedioPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        String Pivote;
        Pivote = this.TextBox4.Text;
        if (Pivote == "______.__")
            Pivote = null;
        this.MedioByIdDataSource.UpdateParameters["MedioFactor"].DefaultValue = Pivote;
        
    
    }
    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSMedioSQLTableAdapters.MedioTableAdapter ObjTAMedPer = new DSMedioSQLTableAdapters.MedioTableAdapter();
        DSMedioSQL.MedioDataTable DTMedioPer = new DSMedioSQL.MedioDataTable();

        DTMedioPer = ObjTAMedPer.GetMedioById(HFCodigoSeleccionado.Value);

        DataRow[] rows = DTMedioPer.Select();
        String Padre;

        if (rows[0].ItemArray[2].ToString() == "")
            Padre = null;
        else
            Padre = rows[0].ItemArray[2].ToString();

        MedioBLL ObjMedio = new MedioBLL();
        bool correcto = ObjMedio.UpdateMedio(rows[0].ItemArray[1].ToString(),
                                             Padre,
                                             rows[0].ItemArray[3].ToString(),
                                             this.RbtnLstPermiso.SelectedValue,
                                             rows[0].ItemArray[0].ToString(), rows[0].ItemArray[6].ToString());

    }
    protected void TCMedio_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.TCMedio.ActiveTabIndex.ToString() == "1" || this.TCMedio.ActiveTabIndex.ToString() == "2")
        {
            //if (this.TxtMedio.Text == "")
            //    HFCodigoSeleccionado.Value = null;
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.LblMessageBox.Text = "No ha seleccionado un expediente";
                this.MPEMensaje.Show();
                this.RbtnLstPermiso.Enabled = false;

            }
            else
            {
                this.RbtnLstPermiso.Enabled = true;
                this.TextBox4.Enabled = true;
                this.LinkButton1.Enabled = true;
                
                //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
                //Lb.Text = HFCodigoSeleccionado.Value;

            }
        }
    }
    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox TxtBox = (TextBox)DVMedio.FindControl("TextBox1");
        RadioButtonList rblst = (RadioButtonList)DVMedio.FindControl("RbtnLstSelPadre");

        if (rblst != null)
        {
            if (rblst.SelectedValue.ToString() == "0")
            {
                TxtBox.Visible = false;
                TxtBox.Text = null;
            }
            else
            {
                TxtBox.Visible = true;
            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            DSMedioSQLTableAdapters.MedioTableAdapter ObjTAMedPer = new DSMedioSQLTableAdapters.MedioTableAdapter();
            DSMedioSQL.MedioDataTable DTMedioPer = new DSMedioSQL.MedioDataTable();

            DTMedioPer = ObjTAMedPer.GetMedioById(HFCodigoSeleccionado.Value);

            DataRow[] rows = DTMedioPer.Select();
            String Padre;

            if (rows[0].ItemArray[2].ToString() == "")
                Padre = null;
            else
                Padre = rows[0].ItemArray[2].ToString();
            String Pivote;
            Pivote = this.TextBox4.Text;

            if (Pivote == "____.__")
                Pivote = null;
            else
                Pivote = Pivote.TrimStart(Convert.ToChar("_"));


            MedioBLL ObjMedio = new MedioBLL();
            bool correcto = ObjMedio.UpdateMedio(rows[0].ItemArray[1].ToString(),
                                                 Padre,
                                                 rows[0].ItemArray[3].ToString(),
                                                 rows[0].ItemArray[4].ToString(),
                                                 rows[0].ItemArray[0].ToString(), Pivote);
            
            this.LblMessageBox.Text = "Factor de Multipplicacion Guardado Correctamente";
            this.MPEMensaje.Show();
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "Problema" + Error;
            this.MPEMensaje.Show();
        }

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.autoComplete1.ServiceMethod = "GetMedioByTextnull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.autoComplete1.ServiceMethod = "GetMedioByTextIdnull";

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        MedioBLL Medio = new MedioBLL();
        bool Correcto;

        try
        {

            Correcto = Medio.DeleteMedio(HFCodigoSeleccionado.Value);
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
            string DatosIni = "Eliminando";
            string DatosFin = "Se elimino el Medio de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace insert de Log eliminar medio
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter DeleteMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            DeleteMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Medio";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Medio " + Error;
            DateTime WFMovimientoFechaFin = DateTime.Now;
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = HttpContext.Current.Session["IP"].ToString();
            string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace el insert de Log error
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales,
            WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        //this.DVDepartamento.DataBind();
        this.LblMessageBox.Text = "Registro Eliminado";
        this.MPEMensaje.Show();
        this.TxtMedio.Text = "";
    }

    
    protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
    {
        FormView f1 = (FormView)DVMedio.FindControl("FVAutoNum");
        CheckBox Ch = (CheckBox)f1.FindControl("CkAuto");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox3");
            TextBox Tx2 = (TextBox)f1.FindControl("TxCons");
            Txt.Text = Tx2.Text.ToString();
        }
        else
        {
            TextBox Txt = (TextBox)DVMedio.FindControl("TextBox3");
            Txt.Text = "";
        }
    }
}

