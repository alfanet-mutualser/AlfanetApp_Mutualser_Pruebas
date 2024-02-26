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

public partial class _MaestroPais : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Pais";
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
        if (TxtPais.Text != "")
        {
            if (TxtPais.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtPais.Text.Remove(TxtPais.Text.IndexOf(" | "));
                this.DVPais.ChangeMode(DetailsViewMode.ReadOnly);
                //OBTENER CONSECUTIVO DE LOGS
                DSPaisSQLTableAdapters.PaisTableAdapter pais = new DSPaisSQLTableAdapters.PaisTableAdapter();
                DSPaisSQL.PaisDataTable elpais = new DSPaisSQL.PaisDataTable();
                elpais = pais.GetPaisById(HFCodigoSeleccionado.Value);
                string nombre = elpais[0].PaisNombre;
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
                string DatosFin = "Se busco el Pais de codigo: " + HFCodigoSeleccionado.Value + " Nombre:" + nombre;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();                //Se hace Insert de Log Buscar Pais
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el consecutivo de Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVPais.DataItemCount.ToString() == "0")
        {
            this.DVPais.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVPais.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVPais.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVPais.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVPais.DataBind();
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
            this.DVPais.DataBind();
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
            this.DVPais.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }


    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
          this.AutoCompletePais.ServiceMethod = "GetPaisByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
          this.AutoCompletePais.ServiceMethod = "GetPaisByTextIdNull";
    }
    
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "1";

            this.PaisByIdDataSource.UpdateParameters["PaisHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "0";
            this.PaisByIdDataSource.UpdateParameters["PaisHabilitar"].DefaultValue = "0";
        }
        this.PaisByIdDataSource.UpdateParameters["Original_PaisCodigo"].DefaultValue = HFCodigoSeleccionado.Value;

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
        CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "1";
            this.PaisByIdDataSource.InsertParameters["PaisHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "0";
            this.PaisByIdDataSource.InsertParameters["PaisHabilitar"].DefaultValue = "0";
        }
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtPais.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.PaisByIdDataSource.UpdateParameters["Original_PaisCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtPais.Text= "";
        this.Label7.Text = "¿Va a eliminar el País seleccionado esta seguro?" + " ";
        this.MPEPregunta.Show();

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        PaisBLL Pais = new PaisBLL();
        bool Correcto;

        try
        {

            Correcto = Pais.DeletePais(HFCodigoSeleccionado.Value);
            this.LblMessageBox.Text = "Registro Eliminado";
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
            string DatosFin = "Se elimino el Pais de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se Inserta log de Eliminar pais
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Pais";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Pais " + Error;
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
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            
        }

        //this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtPais.Text = "";
    }
}

