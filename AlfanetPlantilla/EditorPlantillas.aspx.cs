using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Net;
using System.Net.NetworkInformation;

public partial class AlfanetPlantilla_EditorPlantillas : System.Web.UI.Page
{
    string ModuloLog = "Plantillas-Editor";
    string ConsecutivoCodigo = "7";
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
                String IPAdd = string.Empty;
                IPAdd = Request.ServerVariables["HTTP_X_FORWARDER_FOR"];
                if (String.IsNullOrEmpty(IPAdd))
                {
                    IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                    localIP = IPAdd.ToString();
                    Session["IP"] = localIP;
                }
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();

        if (!IsPostBack)
        {
            //LOG ACCESO
            string ActLogCod = "ACCESO";
            DateTime Fecha = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string HTML = Editor.Text;
            string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert de Log Consulta plantilla
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, TxtCodigo.Text, "",
                                            0, true, HTML, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

            CargaPanel("Inicio");
        }
        //LstCamposSel.Attributes.Add("onChange", "concatena();");
    }

    void CargaPanel(string panel)
    {
        PnlPlantilla.Visible = false;
        PnlMenu.Visible = false;

        LstPlantillasModificar.Visible = false;
        //LstPlantillasEliminar.Visible = false;

        LnkNuevaP.Visible = false;
        LnkModificarP.Visible = false;
        //LnkEliminarP.Visible = false;
        LnkVerModificar.Visible = false;
        //LnkVerEliminar.Visible = false;

        ImgBtnLimpiar.Visible = false;
        ImgBtnGuardar.Visible = false;
        ImgBtnModificar.Visible = false;
        //ImgBtnEliminar.Visible = false;
        ImgBtnRegresar.Visible = false;

        LblResultado.Visible = false;

        TxtCodigo.Enabled = true;
        TxtDescripcion.Enabled = true;
        ChkEstado.Enabled = true;
        Editor.Enabled = true;

        switch (panel)
        {
            case "Inicio":
                LnkNuevaP.Visible = true;
                LnkModificarP.Visible = true;
                //LnkEliminarP.Visible = true;
                PnlMenu.Visible = true;
                break;

            case "Nuevo":
                PnlPlantilla.Visible = true;
                TxtCodigo.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
                //Editor.Content = string.Empty;
                Editor.Text = string.Empty;
                //ImgBtnLimpiar.Visible = true;
                ImgBtnRegresar.Visible = true;
                ImgBtnGuardar.Visible = true;
                break;

            case "Modificar":
                PnlMenu.Visible = true;
                LnkModificarP.Visible = true;
                LstPlantillasModificar.Visible = true;
                LnkVerModificar.Visible = true;
                TxtCodigo.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
                //Editor.Content = string.Empty;
                Editor.Text = string.Empty;
                ImgBtnRegresar.Visible = true;
                break;

            case "VerModificar":
                PnlPlantilla.Visible = true;
                ImgBtnModificar.Visible = true;
                ImgBtnRegresar.Visible = true;
                break;

            /* case "Eliminar":
                 PnlMenu.Visible = true;
                 LnkEliminarP.Visible = true;
                 LstPlantillasEliminar.Visible = true;
                 LnkVerEliminar.Visible = true;
                 ImgBtnRegresar.Visible = true;
                 break;*/

            /*case "VerEliminar":
                PnlPlantilla.Visible = true;
                ImgBtnEliminar.Visible = true;
                TxtCodigo.Enabled = false;
                TxtDescripcion.Enabled = false;
                ChkEstado.Enabled = false;
                Editor.Enabled = false;
                ImgBtnRegresar.Visible = true;
                break;*/
        }
    }

    protected void LnkNuevaP_Click(object sender, EventArgs e)
    {
        LstCampos.Items.Clear();
        LstCamposSel.Items.Clear();

        DSPlantillaTableAdapters.Plantilla_CamposTableAdapter TAPlantilla_Campos = new DSPlantillaTableAdapters.Plantilla_CamposTableAdapter();
        DSPlantilla.Plantilla_CamposDataTable DTPlantillaCampos = new DSPlantilla.Plantilla_CamposDataTable();
        Int32 mTipoCampos = 2; //Radicados
        DTPlantillaCampos = TAPlantilla_Campos.GetPlantillaCampos(mTipoCampos);
        LstCampos.DataValueField = "TABLE_COLUMN";
        LstCampos.DataTextField = "CAMPO";
        LstCampos.DataSource = DTPlantillaCampos;
        LstCampos.DataBind();
        CargaPanel("Nuevo");
    }

    protected void LnkModificarP_Click(object sender, EventArgs e)
    {
        LstCampos.Items.Clear();
        LstCamposSel.Items.Clear();
        DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
        DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
        DTPlantilla = TAPlantilla.GetPlantillaLista();
        LstPlantillasModificar.DataValueField = "Codigo";
        LstPlantillasModificar.DataTextField = "Descripcion";
        LstPlantillasModificar.DataSource = DTPlantilla;
        LstPlantillasModificar.DataBind();
        CargaPanel("Modificar");
    }

    /* protected void LnkEliminarP_Click(object sender, EventArgs e)
     {
         DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
         DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
         DTPlantilla = TAPlantilla.GetPlantillaLista();
         LstPlantillasEliminar.DataValueField = "Codigo";
         LstPlantillasEliminar.DataTextField = "Descripcion";
         LstPlantillasEliminar.DataSource = DTPlantilla;
         LstPlantillasEliminar.DataBind();
         CargaPanel("Eliminar");
     }*/


    protected void LnkVerModificar_Click(object sender, EventArgs e)
    {
        string ActLogCod = "CONSULTA";
        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
            DTPlantilla = TAPlantilla.GetPlantillaById(LstPlantillasModificar.SelectedValue);

            LstCampos.Items.Clear();
            LstCamposSel.Items.Clear();
            DSPlantillaTableAdapters.Plantilla_CamposTableAdapter TAPlantilla_Campos = new DSPlantillaTableAdapters.Plantilla_CamposTableAdapter();
            DSPlantilla.Plantilla_CamposDataTable DTPlantillaCampos = new DSPlantilla.Plantilla_CamposDataTable();

            if (DTPlantilla.Rows.Count > 0)
            {
                TxtCodigo.Text = DTPlantilla.Rows[0]["Codigo"].ToString();
                TxtDescripcion.Text = DTPlantilla.Rows[0]["Descripcion"].ToString();
                if ((bool)DTPlantilla.Rows[0]["Estado"] == true)
                {
                    ChkEstado.Checked = true;
                }
                else
                {
                    ChkEstado.Checked = false;
                }
                Int32 mTipoCampos = 2; //Radicados
                DTPlantillaCampos = TAPlantilla_Campos.GetPlantillaCampos(mTipoCampos);
                LstCampos.DataValueField = "TABLE_COLUMN";
                LstCampos.DataTextField = "CAMPO";
                LstCampos.DataSource = DTPlantillaCampos;
                LstCampos.DataBind();

                //Editor.Content = DTPlantilla.Rows[0]["HTML"].ToString();
                Editor.Text = DTPlantilla.Rows[0]["HTML"].ToString();
                Session.Add("CodPlantillaModif", DTPlantilla.Rows[0]["Codigo"].ToString());
                CargaPanel("VerModificar");

                DateTime Fecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                string HTML = Editor.Text;
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert de Log Consulta plantilla
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                ConsultaLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, TxtCodigo.Text, TxtDescripcion.Text,
                                                mTipoCampos, ChkEstado.Checked, HTML, IP, NombreEquipo, Navegador);
                //Actualiza consecutivo log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
        catch (Exception ex)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al consultar plantilla " + ex;
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
            throw ex;
        }
    }

      /* protected void LnkVerEliminar_Click(object sender, EventArgs e)
      {
          DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
          DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
          DTPlantilla = TAPlantilla.GetPlantillaById(LstPlantillasEliminar.SelectedValue);
          if (DTPlantilla.Rows.Count > 0)
          {
              TxtCodigo.Text = DTPlantilla.Rows[0]["Codigo"].ToString();
              TxtDescripcion.Text = DTPlantilla.Rows[0]["Descripcion"].ToString();
              if ((bool)DTPlantilla.Rows[0]["Estado"] == true)
              {
                  ChkEstado.Checked = true;
              }
              else
              {
                  ChkEstado.Checked = false;
              }
              //Editor.Content =  DTPlantilla.Rows[0]["HTML"].ToString();
              Editor.Text = DTPlantilla.Rows[0]["HTML"].ToString();
              CargaPanel("VerEliminar");
          }
      }*/

    protected void BtnAddOne_Click(object sender, EventArgs e)
    {
        bool Existe = false;
        for (int i = 0; i < LstCampos.Items.Count; i++)
        {
            if (LstCampos.Items[i].Selected == true)
            {
                Existe = false;
                for (int j = 0; j < LstCamposSel.Items.Count; j++)
                {
                    if (LstCampos.Items[i].Value == LstCamposSel.Items[j].Value)
                    {
                        Existe = true;
                        break;
                    }
                }
                if (Existe == false)
                    LstCamposSel.Items.Add(new ListItem(LstCampos.Items[i].Text, LstCampos.Items[i].Value));
            }
        }
    }

    protected void BtnMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }





    protected void ImgBtnRegresar_Click(object sender, ImageClickEventArgs e)
    {
        CargaPanel("Inicio");
    }
    /*   protected void ImgBtnEliminar_Click(object sender, ImageClickEventArgs e)
       {
           try
           {
               DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
               TAPlantilla.Plantilla_Delete(LstPlantillasEliminar.SelectedValue);

               LblResultado.Visible = true;
               LblResultado.Text = "Plantilla Eliminada correctamente";

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }*/

    protected void ImgBtnModificar_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "ACTUALIZAR";

        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            if (Session["CodPlantillaModif"] != null)
            {
                TAPlantilla.Plantilla_Update(
                    TxtCodigo.Text,
                    TxtDescripcion.Text,
                    Convert.ToInt32(2),
                    ChkEstado.Checked,
                    Editor.Text,
                    Session["CodPlantillaModif"].ToString()
                    );

                LblResultado.Visible = true;
                LblResultado.Text = "Plantilla Modificada correctamente";

                //LOG ACTUALIZAR PLANTILLA
                DateTime Fecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                int Tipo = 2;
                string HTML = Editor.Text;
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert de Log actualizar Plantilla
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter UpdateLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                UpdateLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, TxtCodigo.Text, TxtDescripcion.Text,
                                                Tipo, ChkEstado.Checked, HTML, IP, NombreEquipo, Navegador);
                //Actualiza consecutibov log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
        catch (Exception ex)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al actualizar plantilla " + ex;
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
            throw ex;
        }
    }
    protected void ImgBtnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "INSERTAR";

        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            TAPlantilla.Insert(
                TxtCodigo.Text,
                TxtDescripcion.Text,
                Convert.ToInt32(2),
                ChkEstado.Checked,
                Editor.Text);

            LblResultado.Visible = true;
            LblResultado.Text = "Plantilla Creada correctamente";

            //LOG INSERTAR PLANTILLA
            DateTime Fecha = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            int Tipo = 2;
            string HTML = Editor.Text;
            string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert de Log añadir plantilla
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertaLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            InsertaLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, TxtCodigo.Text, TxtDescripcion.Text,
                                            Tipo, ChkEstado.Checked, HTML, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        catch (Exception ex)
            {
                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error al Insertar plantilla " + ex;
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
                // Enviar Alerta JS
                Console.WriteLine("{0}Exception caught.", ex);
                string s = "alert('La Plantilla numero " + TxtCodigo.Text + " ya se encuentra creada, por favor asigne otro codigo y nombre a la plantilla.');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
    }
    protected void ImgBtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        CargaPanel("Nuevo");
    }
    protected void LstCamposSel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cadena = Editor.Text;
        string valor = "<span style='color:#ff0000;'>" + "##" + LstCamposSel.SelectedValue.ToString() + "##" + "</span>";
        cadena += valor;
        Editor.Text = cadena;
    }
}
