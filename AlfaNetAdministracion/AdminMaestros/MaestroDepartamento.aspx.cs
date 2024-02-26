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


public partial class _MaestroDepartamento : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Departamento";
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
            
        }
        else
        {
           
        }
                 
    }
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtDepartamento.Text != "")
        {
            if (TxtDepartamento.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtDepartamento.Text.Remove(TxtDepartamento.Text.IndexOf(" | "));
                this.DVDepartamento.ChangeMode(DetailsViewMode.ReadOnly);

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
                string DatosFin = "Se busco el Departamento de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se inserta el Log de Buscar Departamento
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog,
                                            DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el Consecutivo de Log 
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }
    //protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    //{
    //    TextBox TxtBox = (TextBox)DVDepartamento.FindControl("TxtPais");

    //    if (TxtBox.Text != "")
    //    {
    //        if (TxtBox.Text.Contains("-"))
    //        {
    //            TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
    //        }
    //    }
    //}
    //protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    //{
    //    TextBox TxtBox = (TextBox)DVDepartamento.FindControl("TxtPais");

    //    if (TxtBox.Text != "")
    //    {
    //        if (TxtBox.Text.Contains("-"))
    //        {
    //            TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
    //        }
    //    }
    //}


    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVDepartamento.DataItemCount.ToString() == "0")
        {
            this.DVDepartamento.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVDepartamento.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVDepartamento.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVDepartamento.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVDepartamento.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVDepartamento.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVDepartamento.FindControl("CheckBox1");
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
            this.DVDepartamento.DataBind();
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
            this.DVDepartamento.DataBind();
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
            this.DVDepartamento.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteDepartamento.ServiceMethod = "GetDepartamentoByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteDepartamento.ServiceMethod = "GetDepartamentoByTextIdnull";
    }

    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVDepartamento.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVDepartamento.FindControl("TextBox2");
            Txt.Text = "1";

            this.DepartamentoByIdDataSource.UpdateParameters["DepartamentoHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVDepartamento.FindControl("TextBox2");
            Txt.Text = "0";
            this.DepartamentoByIdDataSource.UpdateParameters["DepartamentoHabilitar"].DefaultValue = "0";
        }
        this.DepartamentoByIdDataSource.UpdateParameters["Original_DepartamentoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;

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
        CheckBox Ch = (CheckBox)DVDepartamento.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVDepartamento.FindControl("TextBox2");
            Txt.Text = "1";
            this.DepartamentoByIdDataSource.InsertParameters["DepartamentoHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVDepartamento.FindControl("TextBox2");
            Txt.Text = "0";
            this.DepartamentoByIdDataSource.InsertParameters["DepartamentoHabilitar"].DefaultValue = "0";
        }
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtDepartamento.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //this.DepartamentoByIdDataSource.UpdateParameters["Original_DepartamentoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.DepartamentoByIdDataSource.DeleteParameters["Original_DepartamentoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        //this.DVDepartamento.DataBind();
        this.TxtDepartamento.Text = "";
        this.Label7.Text = "¿Va a eliminar el Departamento seleccionado esta seguro?" + " ";
        this.MPEPregunta.Show();

    }
   

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        DepartamentoBLL Departamento = new DepartamentoBLL();
        bool Correcto;

        try
        {

            Correcto = Departamento.DeleteDepartamento(HFCodigoSeleccionado.Value);
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
            string DatosFin = "Se elimino el Departamento de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now; string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            //Insert Log de Eliminar departamento
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter DeleteMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            DeleteMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            this.MPEMensaje.Show();
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Departamento";
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
        this.TxtDepartamento.Text = "";
       
        
    }
}

