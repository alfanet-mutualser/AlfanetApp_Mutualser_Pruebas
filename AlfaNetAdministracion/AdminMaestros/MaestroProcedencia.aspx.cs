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
using System.Timers;

public partial class _MaestroProcedencia : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Procedencia";
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
                ((MainMaster)this.Master).showmenu();
            }
            this.TCProcedencia.ActiveTabIndex = 0;
        }
        else
        {

        }
                 
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtProcedencia.Text != "")
        {
            if (TxtProcedencia.Text.Contains(" | "))
            {
                                
                
                this.HFCodigoSeleccionado.Value = TxtProcedencia.Text.Remove(TxtProcedencia.Text.IndexOf(" | "));
                this.DVProcedencia.ChangeMode(DetailsViewMode.ReadOnly);
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                Int64 LogId = Convert.ToInt64(LOG);
                DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter proce = new DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter();
                DSProcedenciaSQL.ProcedenciaDataTable tablaa = new DSProcedenciaSQL.ProcedenciaDataTable();
                tablaa = proce.GetProcedenciaById(HFCodigoSeleccionado.Value);
                string nombre = tablaa[0].ProcedenciaNombre;
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                string DatosIni = "Buscar";//Proced codigo + Proced Nombre
                string DatosFin = HFCodigoSeleccionado.Value + " | " + nombre;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se hace insert de Log busca procedencia
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza Consecutivo Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        

        TextBox TxtBox = (TextBox)DVProcedencia.FindControl("TxtPais");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains("-"))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
            }
        }
    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        //TextBox TxtBox = (TextBox)DVProcedencia.FindControl("TxtPais");

        //if (TxtBox.Text != "")
        //{
        //    if (TxtBox.Text.Contains(" | "))
        //    {
        //        TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
        //    }
        //}
        TextBox TxtBox6 = (TextBox)DVProcedencia.FindControl("TextBox6");
        this.ProcedenciaByIdDataSource.InsertParameters["ProcedenciaNUI"].DefaultValue = TxtBox6.Text;

        CheckBox Ch = (CheckBox)DVProcedencia.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox2");
            Txt.Text = "1";
            this.ProcedenciaByIdDataSource.InsertParameters["ProcedenciaHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox2");
            Txt.Text = "0";
            this.ProcedenciaByIdDataSource.InsertParameters["ProcedenciaHabilitar"].DefaultValue = "0";
        }
        this.ProcedenciaByIdDataSource.InsertParameters["ProcedenciaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        TextBox Txt4 = (TextBox)DVProcedencia.FindControl("TextBox4");
        HFCodigoSeleccionado.Value = Txt4.Text;

    }


    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVProcedencia.DataItemCount.ToString() == "0")
        {
            this.DVProcedencia.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVProcedencia.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVProcedencia.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVProcedencia.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVProcedencia.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVProcedencia.FindControl("Label1");

            DSProcedenciaSQLTableAdapters.Procedencia_ReadExisteProcedenciaTableAdapter TAProcedenciaExiste = new DSProcedenciaSQLTableAdapters.Procedencia_ReadExisteProcedenciaTableAdapter();
            DSProcedenciaSQL.Procedencia_ReadExisteProcedenciaDataTable DTProcedenciaExiste = new DSProcedenciaSQL.Procedencia_ReadExisteProcedenciaDataTable();
            DTProcedenciaExiste = TAProcedenciaExiste.GetProcedencia_ReadExisteProcedencia(LblCodProce.Text);

            TextBox LblProce = (TextBox)DVProcedencia.FindControl("Label5");
            TextBox TxtProce = (TextBox)DVProcedencia.FindControl("TextBox4");
            Label LblProceMsg = (Label)DVProcedencia.FindControl("Label13");

            if (DTProcedenciaExiste.Count == 0)
            {
                LblProce.Visible = false;
               TxtProce.Visible = true;
                LblProceMsg.Visible = false;

            }
            else
            {
               // LblProce.Visible = true;
               //LblProceMsg.Visible = true;
                TxtProce.Visible = true;
            }      

            //if (DTProcedenciaExiste.Count == 0)
            //{
            //    //LblProce.Visible = false;
            //    //TxtProce.Visible = true;
            //    // LblProceMsg.Visible = false;
            //    LblProce.Visible = false;
            //    LblProceMsg.Visible = true;
            //    TxtProce.Visible = true;
            //}
            //else
            //{
            //    LblProce.Visible = false;
            //    LblProceMsg.Visible = true;
            //    TxtProce.Visible = true;
            //}          
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVProcedencia.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }
            TextBox TxtPadre = (TextBox)DVProcedencia.FindControl("TextBox3");
            if (TxtPadre.Text != "")
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
                RBLPadre.SelectedValue = "1";
                TxtPadre.Visible = true;

            }
            else
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
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
            this.DVProcedencia.DataBind();
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
            this.DVProcedencia.DataBind();
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
            this.DVProcedencia.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void LnkBtnActualizar_Click(object sender, EventArgs e)
    {
        this.ProcedenciaByIdDataSource.UpdateParameters["Original_ProcedenciaNUI"].DefaultValue =HFCodigoSeleccionado.Value;
    }
    protected void LnkBtnEliminar_Click(object sender, EventArgs e)
    {
        this.ProcedenciaByIdDataSource.UpdateParameters["Original_ProcedenciaNUI"].DefaultValue = HFCodigoSeleccionado.Value;
    }
    
    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox TxtBox = (TextBox)DVProcedencia.FindControl("TextBox3");
        RadioButtonList rblst = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");

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

    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtProcedencia.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.ProcedenciaByIdDataSource.UpdateParameters["Original_ProcedenciaNUI"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtProcedencia.Text = "";
        this.Label7.Text = "¿Va a eliminar la Procedencia seleccionada esta seguro?" + " ";
        this.MPEPregunta.Show();

    }
    
    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter ObjTAPro = new DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter();
        DSProcedenciaSQL.ProcedenciaDataTable DTProcedenciaPermiso = new DSProcedenciaSQL.ProcedenciaDataTable();

            DTProcedenciaPermiso = ObjTAPro.GetProcedenciaById(HFCodigoSeleccionado.Value);

        DataRow[] rows = DTProcedenciaPermiso.Select();
        String Padre;
        

        if (rows[0].ItemArray[3].ToString() == "")
            Padre = null;
        else
            Padre = rows[0].ItemArray[3].ToString();

        String Telefono2;
        if (rows[0].ItemArray[5].ToString() == "")
            Telefono2 = null;
        else
            Telefono2 = rows[0].ItemArray[5].ToString();
        String Fax;
        if (rows[0].ItemArray[6].ToString() == "")
            Fax = null;
        else
            Fax = rows[0].ItemArray[6].ToString();

        String Mail2;
        if (rows[0].ItemArray[8].ToString() == "")
            Mail2 = null;
        else
            Mail2 = rows[0].ItemArray[8].ToString();

        String PaginaWeb;
        if (rows[0].ItemArray[9].ToString() == "")
            PaginaWeb = null;
        else
            PaginaWeb = rows[0].ItemArray[9].ToString();
        DTProcedenciaPermiso = ObjTAPro.GetUpdate_ProcedenciaPermisoBy(rows[0].ItemArray[0].ToString(),
                                                                    rows[0].ItemArray[1].ToString(),
                                                                    rows[0].ItemArray[2].ToString(),
                                                                    Padre,
                                                                    rows[0].ItemArray[4].ToString(),
                                                                    rows[0].ItemArray[5].ToString(),
                                                                    Telefono2,
                                                                    Fax,
                                                                    rows[0].ItemArray[8].ToString(),
                                                                    Mail2,
                                                                    PaginaWeb,
                                                                    rows[0].ItemArray[11].ToString(),
                                                                    rows[0].ItemArray[12].ToString(),
                                                                   this.RbtnLstPermiso.SelectedValue,
                                                                    rows[0].ItemArray[0].ToString());

    }
    protected void TCProcedencia_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.TCProcedencia.ActiveTabIndex.ToString() == "1")
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
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVProcedencia.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox2");
            Txt.Text = "1";

            this.ProcedenciaByIdDataSource.UpdateParameters["ProcedenciaHabilitar"].DefaultValue = "1";

        }
        else
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox2");
            Txt.Text = "0";
            this.ProcedenciaByIdDataSource.UpdateParameters["ProcedenciaHabilitar"].DefaultValue = "0";
        }

        Label Lbl6 = (Label)DVProcedencia.FindControl("Label6");
        //this.ProcedenciaByIdDataSource.UpdateParameters["ProcedenciaNUI"].DefaultValue = Lbl6.Text;

        this.ProcedenciaByIdDataSource.UpdateParameters["ProcedenciaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        this.ProcedenciaByIdDataSource.UpdateParameters["Original_ProcedenciaNUI"].DefaultValue = HFCodigoSeleccionado.Value;
       // this.ProcedenciaByIdDataSource.UpdateParameters["ProcedenciaNUI"].DefaultValue = HFCodigoSeleccionado.Value;

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.autoComplete1.ServiceMethod = "GetProcedenciaByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.autoComplete1.ServiceMethod = "GetProcedenciaByTextIdnull";
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        ProcedenciaBLL Procedencia = new ProcedenciaBLL();
        bool Correcto;

        try
        {

            Correcto = Procedencia.DeleteProcedencia(HFCodigoSeleccionado.Value);
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
            string DatosIni = "Eliminando"; //Proced codigo
            string DatosFin = HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert de Log Eliminar parocedencia
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza Consecutivo Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Procedencia";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Procedencia " + Error;
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
        }

        //this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtProcedencia.Text = "";
    }
    protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
    {
        FormView f1 = (FormView)DVProcedencia.FindControl("FVAutoNum");
        CheckBox Ch = (CheckBox)f1.FindControl("CkAuto");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox6");
            TextBox Tx2 = (TextBox)f1.FindControl("TxCons");
            Txt.Text = Tx2.Text.ToString();
        }
        else
        {
            TextBox Txt = (TextBox)DVProcedencia.FindControl("TextBox6");
            Txt.Text = "";
        }
    }
}

