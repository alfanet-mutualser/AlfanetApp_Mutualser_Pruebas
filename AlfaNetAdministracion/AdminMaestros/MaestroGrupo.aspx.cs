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


public partial class _MaestroGrupo : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Grupo";
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
            this.DVGrupo.Visible = true;
            this.TCGrupo.ActiveTabIndex = 0;
            
        }
        else
        {
               
            //DropDownList ddlst = (DropDownList)DVGrupo.FindControl("DropDownList1");
            //RadioButtonList rblst = (RadioButtonList)DVGrupo.FindControl("RbtnLst");

            //if (rblst != null)
            //{
            //    if (rblst.SelectedValue.ToString() == "0")
            //    {
            //        ddlst.Visible = false;
            //    }
            //    else
            //    {
            //        ddlst.Visible = true;
            //    }
            //}
                 
        }
                 

    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtGrupo.Text != "")
        {
            if (TxtGrupo.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtGrupo.Text.Remove(TxtGrupo.Text.IndexOf(" | "));
                this.DVGrupo.ChangeMode(DetailsViewMode.ReadOnly);

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
                string DatosFin = "Se busco el Grupo de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //se hace insert de log buscar grupo
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza consecutivo de log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                
                //DSGrupoSQLTableAdapters.GrupoTableAdapter ObjTAGrp = new DSGrupoSQLTableAdapters.GrupoTableAdapter();
                ////DSGrupoSQL.GrupoDataTable DTGrupo = new DSGrupoSQL.GrupoDataTable();
                ////GrupoBLL ObjGrupo = new GrupoBLL();

               //// DTGrupo = ObjGrupo.GetGrupoByID(HFCodigoSeleccionado.Value);
                //DTGrupo = ObjTAGrp.GetGroupById(HFCodigoSeleccionado.Value);

              ////  DataRow[] rows = DTGrupo.Select();

               //// this.RbtnLstPermiso.SelectedValue = rows[0].ItemArray[6].ToString().Trim();
            }
        }
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVGrupo.DataItemCount.ToString() == "0")
        {
            this.DVGrupo.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVGrupo.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVGrupo.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVGrupo.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVGrupo.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVGrupo.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVGrupo.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }

            TextBox TxtPadre = (TextBox)DVGrupo.FindControl("TextBox1");
            if (TxtPadre.Text != "")
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVGrupo.FindControl("RbtnLstSelPadre");
             RBLPadre.SelectedValue = "1";
             TxtPadre.Visible = true;

             }
            else
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVGrupo.FindControl("RbtnLstSelPadre");
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVGrupo.DataBind();
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
            this.DVGrupo.DataBind();
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
            this.DVGrupo.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteDepartamento.ServiceMethod = "GetGrupoByTextnull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteDepartamento.ServiceMethod = "GetGrupoTextByIdnull";
    }

    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVGrupo.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVGrupo.FindControl("TextBox2");
            Txt.Text = "1";

            this.GrupoByIdDataSource.UpdateParameters["GrupoHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVGrupo.FindControl("TextBox2");
            Txt.Text = "0";
            this.GrupoByIdDataSource.UpdateParameters["GrupoHabilitar"].DefaultValue = "0";
        }
        this.GrupoByIdDataSource.UpdateParameters["Original_GrupoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.GrupoByIdDataSource.UpdateParameters["GrupoPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
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
       // this.GrupoByIdDataSource.UpdateParameters["GrupoPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        //this.GrupoByIdDataSource.UpdateParameters["Original_GrupoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVGrupo.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVGrupo.FindControl("TextBox2");
            Txt.Text = "1";
            this.GrupoByIdDataSource.InsertParameters["GrupoHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVGrupo.FindControl("TextBox2");
            Txt.Text = "0";
            this.GrupoByIdDataSource.InsertParameters["GrupoHabilitar"].DefaultValue = "0";
        }
        this.GrupoByIdDataSource.InsertParameters["GrupoPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
       // this.HFCodigoSeleccionado.Value = GrupoByIdDataSource.InsertParameters["GrupoCodigo"].DefaultValue;
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtGrupo.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.GrupoByIdDataSource.UpdateParameters["Original_GrupoCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtGrupo.Text = "";
        this.Label7.Text = "¿Va a eliminar el Grupo seleccionado esta seguro?" + " ";
        this.MPEPregunta.Show();

    }


    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSGrupoSQLTableAdapters.GrupoTableAdapter ObjTAGrpPer = new DSGrupoSQLTableAdapters.GrupoTableAdapter();
        DSGrupoSQL.GrupoDataTable DTGrupoPer = new DSGrupoSQL.GrupoDataTable();

        DTGrupoPer = ObjTAGrpPer.GetGroupById(HFCodigoSeleccionado.Value);

        DataRow[] rows = DTGrupoPer.Select();
        String Padre;

        if (rows[0].ItemArray[2].ToString() == "")
            Padre = null;
        else
            Padre = rows[0].ItemArray[2].ToString();

        GrupoBLL ObjGrupo = new GrupoBLL();
        bool correcto =  ObjGrupo.UpdateGrupo(rows[0].ItemArray[1].ToString(),
                                                        Padre,
                                                        Convert.ToInt32(rows[0].ItemArray[3].ToString()),
                                                        rows[0].ItemArray[5].ToString(),
                                                        this.RbtnLstPermiso.SelectedValue,
                                                        rows[0].ItemArray[0].ToString());

        //DTGrupoPer = ObjTAGrpPer.GetGrupo_UpdateGrupoBy(rows[0].ItemArray[1].ToString(),
        //                                                Padre,
        //                                                Convert.ToInt32(rows[0].ItemArray[3].ToString()),
        //                                                rows[0].ItemArray[5].ToString(),
        //                                                this.RbtnLstPermiso.SelectedValue,
        //                                                rows[0].ItemArray[0].ToString());


    }
    protected void TCGrupo_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.TCGrupo.ActiveTabIndex.ToString() == "1")
        {
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.LblMessageBox.Text = "No ha seleccionado un expediente";
                this.MPEMensaje.Show();

            }
            else
            {
                this.RbtnLstPermiso.Enabled = true;

                //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
                //Lb.Text = HFCodigoSeleccionado.Value;

            }
        }
    }
    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox TxtBox = (TextBox)DVGrupo.FindControl("TextBox1");
        RadioButtonList rblst = (RadioButtonList)DVGrupo.FindControl("RbtnLstSelPadre");

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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        GrupoBLL Grupo = new GrupoBLL();
        bool Correcto;

        try
        {

            Correcto = Grupo.DeleteGrupo(HFCodigoSeleccionado.Value);
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
            string DatosFin = "Se elimino el Grupo de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace INsert de Log Eliminar grupo
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter DeleteMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            DeleteMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecuitov Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Grupo";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Grupo " + Error;
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
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        //this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtGrupo.Text = "";
    }
}

