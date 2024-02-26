using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;


public partial class _MaestroCiudad : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Ciudad";
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
        //this.Button1.Visible = false;
        //this.Button2.Visible = false;
        if (!IsPostBack)
        {
        //this.Button1.Visible = false;
        //this.Button2.Visible = false; 
        }
        else
        {
        //this.Button1.Visible = false;
        //this.Button2.Visible = false;   
        }
                        
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtCiudad.Text != "")
        {
            if (TxtCiudad.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtCiudad.Text.Remove(TxtCiudad.Text.IndexOf(" | "));
                this.DVCiudad.ChangeMode(DetailsViewMode.ReadOnly);
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
                string DatosFin = "Se busco la Ciudad de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se inserta Log de buscar ciudad
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni,
                                            DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza consecutivo de Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
               // this.ModalPopupExtender1.Show();
            }
        }
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        //if (DVCiudad.DataItemCount.ToString() == "0")
        //{
        //    this.DVCiudad.ChangeMode(DetailsViewMode.Insert);
        //}

        //TextBox TxtBox = (TextBox)(DVCiudad.FindControl("TxtDepartamento"));

        //if (TxtBox != null)
        //{
        //    TxtBox.Text = "";
        //}

        if (DVCiudad.DataItemCount.ToString() == "0")
        {
            this.DVCiudad.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVCiudad.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVCiudad.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVCiudad.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }
            //TextBox TxtPadre = (TextBox)DVCiudad.FindControl("TextBox1");
            //if (TxtPadre.Text != "")
            //{
            //    //RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
            //    //RBLPadre.SelectedValue = "1";
            //    TxtPadre.Visible = true;

            //}
            //else
            //{
            //    //RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
            //    //RBLPadre.SelectedValue = "0";
            //    TxtPadre.Visible = false;
            //}

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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            //this.Button1.Visible = false;
            //this.Button2.Visible = false;
            this.DVCiudad.DataBind();
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)
        {
            //this.Button1.Visible = false;
            //this.Button2.Visible = false;
            this.DVCiudad.DataBind();
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)
        {
            this.DVCiudad.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteCiudad.ServiceMethod = "GetCiudadByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteCiudad.ServiceMethod = "GetCiudadByTextIdnull";
    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "1";

            this.CiudadByIdDataSource.UpdateParameters["CiudadHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "0";
            this.CiudadByIdDataSource.UpdateParameters["CiudadHabilitar"].DefaultValue = "0";
        }
        this.CiudadByIdDataSource.UpdateParameters["Original_CiudadCodigo"].DefaultValue = HFCodigoSeleccionado.Value;

    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //TextBox TxtBox = (TextBox)DVCiudad.FindControl("TxtPais");

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
       CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "1";
            this.CiudadByIdDataSource.InsertParameters["CiudadHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "0";
            this.CiudadByIdDataSource.InsertParameters["CiudadHabilitar"].DefaultValue = "0";
        }
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtCiudad.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.CiudadByIdDataSource.UpdateParameters["Original_CiudadCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtCiudad.Text = "";
        this.Label7.Text = "¿Va a eliminar la Ciudad seleccionada esta seguro?" + " ";
        this.MPEPregunta.Show();
                
    }
        
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        CiudadBLL Ciudad = new CiudadBLL();
        bool Correcto;

        try
        {

            Correcto = Ciudad.DeleteCiudad(HFCodigoSeleccionado.Value);
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
            string DatosIni = "Eliminado";
            string DatosFin = "Se elimino la ciudad de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter DeleteMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            //Se inserta el Log de Eliminar ciudad
            DeleteMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin,
                                        FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo de Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            this.MPEMensaje.Show();
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Ciudad";
            string Grupo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = LblMessageBox.Text + Error;
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
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace el insert de Log error
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, Grupo, ModuloLog, DatosFinales,
            WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }

        //this.DVDepartamento.DataBind();
        this.LblMessageBox.Text = "Registro Eliminado";
        this.MPEMensaje.Show();
        this.TxtCiudad.Text = "";
    }
}

