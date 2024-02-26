using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

public partial class _MaestroExpediente : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Expediente";
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
               // ((MainMaster)this.Master).showmenu();
            }
            this.TCExpediente.ActiveTabIndex = 0;
            
        }
        else
        {
            TextBox TxtBox = (TextBox)DVExpediente.FindControl("TxtExpedientePadre");
            RadioButtonList rblst = (RadioButtonList)DVExpediente.FindControl("RbtnLstSelPadre");

            if (rblst != null)
            {
                if (rblst.SelectedValue.ToString() == "0")
                {
                    TxtBox.Visible = false;
                }
                else
                {
                    TxtBox.Visible = true;
                }

            }

        }
    }

    protected void DVExpediente_DataBound(Object sender, EventArgs e)
    {
        //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
        //Lb.Text = HFCodigoSeleccionado.Value;
                
        if (this.DVExpediente.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVExpediente.FindControl("Label1");

            DSExpedienteSQLTableAdapters.Expediente_ReadExisteExpedienteTableAdapter TAExpedienteExiste = new DSExpedienteSQLTableAdapters.Expediente_ReadExisteExpedienteTableAdapter();
            DSExpedienteSQL.Expediente_ReadExisteExpedienteDataTable DTExpedienteExiste = new DSExpedienteSQL.Expediente_ReadExisteExpedienteDataTable();
            DTExpedienteExiste = TAExpedienteExiste.GetExpediente_ReadExisteExpediente(LblCodProce.Text);

            Label LblProce = (Label)DVExpediente.FindControl("Label2");
            TextBox TxtProce = (TextBox)DVExpediente.FindControl("TextBox2");
            Label LblProceMsg = (Label)DVExpediente.FindControl("Label13");

            if (DTExpedienteExiste.Count == 0)
            {
                LblProce.Visible = false;
                TxtProce.Visible = true;
                LblProceMsg.Visible = false;
            }
            else
            {
                LblProce.Visible = false;
                LblProceMsg.Visible = true;
                TxtProce.Visible = true;
            }

            TextBox Txt2 = (TextBox)DVExpediente.FindControl("TxtExpedientePadre");
            if (Txt2.Text != "")
            {
                RadioButtonList rblPadre = (RadioButtonList)DVExpediente.FindControl("RbtnLstSelPadre");
                rblPadre.SelectedValue = "1";
                Txt2.Visible = true;
            }
        }
    }


    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (this.TxtExpediente.Text != "")
        {
            if (this.TxtExpediente.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtExpediente.Text.Remove(TxtExpediente.Text.IndexOf(" | "));
                this.DVExpediente.ChangeMode(DetailsViewMode.ReadOnly);
                //this.GVExpedientePermiso.DataBind();
                //this.RbtnLstPermiso.SelectedValue =
                //this.DVExpedientePermiso.DataBind();
                //this.RbtnLstPermiso.SelectedValue = 
                DSExpedienteSQLTableAdapters.ExpedienteTableAdapter ObjTAExp = new DSExpedienteSQLTableAdapters.ExpedienteTableAdapter();
                DSExpedienteSQL.ExpedienteDataTable DTExpediente = new DSExpedienteSQL.ExpedienteDataTable();
                DTExpediente = ObjTAExp.GetExpedienteById(HFCodigoSeleccionado.Value);
                DataRow[] rows = DTExpediente.Select();

                this.RbtnLstPermiso.SelectedValue = rows[0].ItemArray[4].ToString().Trim();

                //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
                //Lb.Text = HFCodigoSeleccionado.Value;
                this.RbtnLstPermiso.Enabled = true;
                this.TreeVDependencia.Nodes.Clear();
                this.ListBox1.Items.Clear();
                TreeVdependencia_Load();
                ListBox1_Load();

                // OBTENER CONSECUTIVO DE LOGS
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
                string DatosFin = "Se busco Expediente de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                // Se hace Insert de buscar  expediente
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza consecutivo de lOG
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }


    /*
    protected void ImgBtnInsertPermiso_Click(object sender, ImageClickEventArgs e)
    {
        
        // PRIMER PARAMETRO A INSERTAR
        this.ExpedientePermisoByIdDataSource.InsertParameters["ExpedienteCodigo"].DefaultValue = this.HFCodigoSeleccionado.Value.ToString();

        // SEGUNDO PARAMETRO A INSERTAR
        TextBox TxtBox1 = (TextBox)DVExpedientePermiso.FindControl("TxtDependenciaPermiso");
        RadioButtonList rblst1 = (RadioButtonList)DVExpedientePermiso.FindControl("RbtnLst1");
        if (rblst1 != null)
        {
            if (rblst1.SelectedValue.ToString() == "0")
            {
                this.ExpedientePermisoByIdDataSource.InsertParameters["DependenciaCodigo"].DefaultValue = "-1";
            }
            else
            {
                if (TxtBox1.Text != "")
                {
                    if (TxtBox1.Text.Contains("-"))
                    {
                       this.ExpedientePermisoByIdDataSource.InsertParameters["DependenciaCodigo"].DefaultValue = TxtBox1.Text.Remove(TxtBox1.Text.IndexOf("-"));
                    }
                }
            }
        }

        // TERCER PARAMETRO A INSERTAR
        RadioButtonList rblst2 = (RadioButtonList)DVExpedientePermiso.FindControl("RbtnLst2");
        this.ExpedientePermisoByIdDataSource.InsertParameters["ExpedientePermisoHabilitar"].DefaultValue = rblst2.SelectedValue.ToString();
        

        //this.ExpedientePermisoByIdDataSource.InsertParameters["ExpedienteCodigo"].DefaultValue = "1";
        //this.ExpedientePermisoByIdDataSource.InsertParameters["DependenciaCodigo"].DefaultValue = "1";
        //this.ExpedientePermisoByIdDataSource.InsertParameters["ExpedientePermisoHabilitar"].DefaultValue = "True";  

    }
    */

    protected void ImgBtnEditExpediente_Click(object sender, ImageClickEventArgs e)
    {
        this.ExpedienteByIdDataSource.UpdateParameters["ExpedientePermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
    }

    protected void ImgBtnInsertExpediente_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtDepPadre = (TextBox)DVExpediente.FindControl("TxtExpedientePadre");
        String DepPadreCod = TxtDepPadre.Text;
        if (DepPadreCod != "")
        {
            if (DepPadreCod.Contains(" | "))
            {
                DepPadreCod = DepPadreCod.Remove(DepPadreCod.IndexOf(" | "));
            }
        }
        this.ExpedienteByIdDataSource.InsertParameters["ExpedienteCodigoPadre"].DefaultValue = DepPadreCod;
        this.ExpedienteByIdDataSource.InsertParameters["ExpedientePermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
    }

    protected void DVExpediente_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
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
            this.DVExpediente.DataBind();
            //this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVExpediente_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
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
            this.DVExpediente.DataBind();
            //this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVExpediente_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
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
            this.DVExpediente.DataBind();
            //this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
            this.DVExpediente.ChangeMode(DetailsViewMode.Insert);
        }
    }

    //protected void GVExpedientePermiso_RowDeleted(Object sender, GridViewDeletedEventArgs e)
    //{
    //    if (e.Exception != null)
    //    {
    //        //Display a user-friendly message
    //        this.LblMessageBox.Text = "Ocurrio un problema al tratar eliminar el registro. ";
    //        Exception inner = e.Exception.InnerException;
    //        this.LblMessageBox.Text += ErrorHandled.FindError(inner);
    //        this.LblMessageBox.Text += e.Exception.Message.ToString();
    //        this.MPEMensaje.Show();

    //        //Indicate that exception has been handled
    //        e.ExceptionHandled = true;
    //    }
    //    else if (e.Exception == null)
    //    {
    //        this.DVExpediente.DataBind();
    //        this.GVExpedientePermiso.DataBind();
    //        this.LblMessageBox.Text = "Registro Eliminado";
    //        this.MPEMensaje.Show();
    //    }
    //}


    /*Metodo para verificar si un no*/
    protected void TreeVDependencia_TreeNodeChecked(Object sender, EventArgs e)
    { 
    
    }


    protected void TCExpediente_OnActiveTabChanged(Object sender, EventArgs e)
    {
        this.TreeVDependencia.Nodes.Clear();
        this.ListBox1.Items.Clear();
        if (this.TCExpediente.ActiveTabIndex.ToString() == "1")
        {
            
            
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.LblExp.Text = "No ha seleccionado un expediente";
                this.LblMessageBox.Text = "No ha seleccionado un expediente";
                this.MPEMensaje.Show();

            }
            else
            {
                this.LblExp.Text = HFCodigoSeleccionado.Value;
                this.RbtnLstPermiso.Enabled = true;
                TreeVdependencia_Load();
                ListBox1_Load();
                //this.Paneldep.Visible = true;
                // this.la
                //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
                //Lb.Text = HFCodigoSeleccionado.Value;
                //Lab
                //this.DVExpedientePermiso.FindControl("Label1")

            }
        }
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteExpediente.ServiceMethod = "GetExpedienteByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteExpediente.ServiceMethod = "GetExpedienteByTextIdnull";
        
        

    }

    //protected void RBEnterarA_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (RBEnterarA.SelectedValue == "T")
    //    {
    //        this.ListBoxEnterar.Items.Clear();
    //        this.TxtDependencia1.Text = "";
    //        this.TxtDependencia1.ReadOnly = true;
    //        //this.DropDownExtender3.Enabled = false;
    //        this.ImgBtnAdd.Enabled = false;
    //        this.ImgBtnDelete.Enabled = false;
    //        this.ListBoxEnterar.Items.Add("Todas | Todas");
    //    }
    //    else
    //    {
    //        this.ListBoxEnterar.Items.Clear();
    //        this.TxtDependencia1.Text = "";
    //        this.TxtDependencia1.ReadOnly = false;
    //        //this.DropDownExtender3.Enabled = true;
    //        this.ImgBtnAdd.Enabled = true;
    //        this.ImgBtnDelete.Enabled = true;
    //    }
    //}
    //protected void ImgBtnAdd_Click(object sender, EventArgs e)
    //{
    //    this.ListBoxEnterar.Items.Add(this.TxtDependencia1.Text.ToString());
    //    this.TxtDependencia1.Text = "";
    //    string mExpediente = HFCodigoSeleccionado.Value;

    //}
    //protected void ImgBtnDelete_Click(object sender, EventArgs e)
    //{
    //    this.ListBoxEnterar.Items.Remove(this.ListBoxEnterar.SelectedItem);
    //}

    //protected void ImgBtnInsertExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    //{
    //    TextBox TxtDep = (TextBox)DVExpedientePermiso.FindControl("TextBox2");
    //    String DepCod = TxtDep.Text;
    //    if (DepCod != "")
    //    {
    //        if (DepCod.Contains(" | "))
    //        {
    //            DepCod = DepCod.Remove(DepCod.IndexOf(" | "));
    //        }
    //    }

    //    DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter ObjTAExpPer = new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
    //    int correcto = ObjTAExpPer.Insert(this.HFCodigoSeleccionado.Value,DepCod);

    //   // this.ODSPermisoExpediente.InsertParameters.RemoveAt(2);
    //   // this.ODSPermisoExpediente.InsertParameters["ExpedienteCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
    //   // this.ODSPermisoExpediente.InsertParameters["DependenciaCodigo"].DefaultValue = DepCod;
        
    //    this.GVExpedientePermiso.DataBind();
    //    TxtDep.Text = "";
    //}
    //protected void ImgBtnDeleteExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    //{
    //    this.ExpedienteByIdDataSource.DeleteParameters["Original_ExpedienteCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
    //    this.TxtExpediente.Text = "";
    //    this.Label7.Text = "¿Va a eliminar el Expediente seleccionado esta seguro?" + " ";
    //    this.MPEPregunta.Show();
    //}
    protected void DVExpediente_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        TextBox TxtDepPadre = (TextBox)DVExpediente.FindControl("TxtExpedientePadre");
        String DepPadreCod = TxtDepPadre.Text;
        if (DepPadreCod != "")
        {
            if (DepPadreCod.Contains(" | "))
            {
                DepPadreCod = DepPadreCod.Remove(DepPadreCod.IndexOf(" | "));
                this.ExpedienteByIdDataSource.InsertParameters["ExpedienteCodigoPadre"].DefaultValue = DepPadreCod;
            }

        }
    }
    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSExpedienteSQLTableAdapters.ExpedienteTableAdapter ObjTAExp = new DSExpedienteSQLTableAdapters.ExpedienteTableAdapter();
        DSExpedienteSQL.ExpedienteDataTable DTExpediente = new DSExpedienteSQL.ExpedienteDataTable();
        DTExpediente = ObjTAExp.GetExpediente_UpdateExpedientePermisoBy(HFCodigoSeleccionado.Value, Convert.ToBoolean(RbtnLstPermiso.SelectedValue));
        this.TreeVDependencia.Nodes.Clear();
        this.TreeVdependencia_Load();

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        ExpedienteBLL Expediente = new ExpedienteBLL();
        bool Correcto;

        try
        {

            Correcto = Expediente.DeleteExpediente(HFCodigoSeleccionado.Value);
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
            string DatosFin = "Se elimino el Expediente de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace Insert de Log Eliminar Expediente
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter EliminarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            EliminarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se Actualiza consecutivo Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Expediente";
            string Grupo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Expediente " + Error;
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
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, Grupo, ModuloLog, DatosFinales,
            WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        ////this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtExpediente.Text = "";
        //this.TxtExpediente.Text= "";
    }


    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre", "0");
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
         new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable DTExpedientePermiso =
            new DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable();

        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            DTExpedientePermiso = TAExpedientePermiso.GetExpedientePermisoData(HFCodigoSeleccionado.Value);
            foreach (DataRow rt in DTExpedientePermiso.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString());
            }
        }


        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";

            if (SeleccionarNodo == "1")
            {
                if (Convert.ToInt32(dr["childnodecount"]) > 0)
                {
                    tn.SelectAction = TreeNodeSelectAction.None;

                }
                else
                {
                }
            }
            else
            {
                //tn.NavigateUrl = "javascript:void(0);";
                tn.SelectAction = TreeNodeSelectAction.Select;
            }
            if (valExp.Count > 0)
            {
                if (valExp.Contains(tn.Value.ToString()))
                {
                    tn.Checked = true;
                }
            }

            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    private void PopulateNodes(DataTable dt, String Codigo, String Nombre, string SeleccionarNodo)
    {

        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
         new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable DTExpedientePermiso =
            new DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable();

        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            DTExpedientePermiso = TAExpedientePermiso.GetExpedientePermisoData(HFCodigoSeleccionado.Value);
            foreach (DataRow rt in DTExpedientePermiso.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString());
            }
        }

        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";

            if (SeleccionarNodo == "1")
            {
                if (Convert.ToInt32(dr["childnodecount"]) > 0)
                {
                    tn.SelectAction = TreeNodeSelectAction.None;

                }
                else
                {
                }
            }
            else
            {
                //tn.NavigateUrl = "javascript:void(0);";
                tn.SelectAction = TreeNodeSelectAction.Select;
            }

            if (valExp.Count > 0)
            {
                if (valExp.Contains(tn.Value.ToString()))
                {
                    tn.Checked = true;
                }
            }

            TreeVDependencia.Nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void TreeVDependencia_Load(object sender, EventArgs e)
    {
        
        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            
                this.TreeVDependencia.Attributes.Add("onclick", "OnTreeClick(event)");

                ArbolesBLL ObjArbolDep = new ArbolesBLL();
                DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
                DTDependencia = ObjArbolDep.GetDependenciaTree("0");
                PopulateNodes(DTDependencia, "DependenciaCodigo", "DependenciaNombre", "0");


            
        }
    }

    protected void TreeVdependencia_Load()
    {
         
        this.TreeVDependencia.Attributes.Add("onclick", "OnTreeClick(event)");

        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree("0");
        PopulateNodes(DTDependencia, "DependenciaCodigo", "DependenciaNombre", "0");
    }

    protected void ListBox1_Load()
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
          new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable DTExpedientePermiso =
            new DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable();
        DTExpedientePermiso = TAExpedientePermiso.GetExpedientePermisoData(HFCodigoSeleccionado.Value);
        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            DTExpedientePermiso = TAExpedientePermiso.GetExpedientePermisoData(HFCodigoSeleccionado.Value);
            if (DTExpedientePermiso.Count > 0)
            {
                foreach (DataRow r1 in DTExpedientePermiso.Rows)
                {
                    ListBox1.Items.Add(new ListItem(r1.ItemArray[1].ToString() + " | " + r1.ItemArray[2].ToString(), r1.ItemArray[1].ToString()));
                }
                ListBox1.DataBind();

            }
        }
    }

    protected void BtnAdicionaUno_Click(object sender, EventArgs e)
    {
        TreeNodeCollection checkedNodes = TreeVDependencia.CheckedNodes;
        
    }


    protected void BtnAdicionaTodos_Click(object sender, EventArgs e)
    {
        /*Selecciono todos los nodos seleccionados*/
        TreeNodeCollection checkedNodes = TreeVDependencia.CheckedNodes;

        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso = 
            new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable DTExpedientePermiso = 
            new DSExpedienteSQL.ExpedientePermiso_ReadExpedientePermisoDataTable();
        DTExpedientePermiso = TAExpedientePermiso.GetExpedientePermisoData(HFCodigoSeleccionado.Value);

        ExpedienteBLL b1 = new ExpedienteBLL();

        int cont = 0;

        /*Evalua si no se le ha asignado permiso*/
        if (DTExpedientePermiso.Count == 0)
        {
            String _texto = "";
            /*Buscar si los nodos seleccionados ya estan presentes*/
            if (checkedNodes.Count == 0)
                _texto = "No ha seleccionado dependencia";
            foreach (TreeNode node in checkedNodes)
            {
                
                String valor = node.Value.ToString();
                bool confirmar = b1.AddExpedientePermiso(HFCodigoSeleccionado.Value,valor);
                if (confirmar == true)
                {
                    cont++;
                    _texto += " " + valor+",";
                }

            }
            if (cont == 1)
            {
                this.LblMessageBox.Text = "Se han habilitado para el expediente " + HFCodigoSeleccionado.Value.ToString()
                    + " la siguiente dependencia: " + _texto.Substring(0, _texto.Length - 1);
            }
            else
            {
                this.LblMessageBox.Text = "Se han habilitado para el expediente " + HFCodigoSeleccionado.Value.ToString()
                    + " las siguientes dependencias: " + _texto.Substring(0, _texto.Length - 1);
            }
            
            this.MPEMensaje.Show();
        }
        else
        {
            String _texto = "";
            int _contador = 0;
            cont = 0;
            /*Obtengo la lista de los valores guardados en la base de datos*/
            System.Collections.Generic.List<String> valExp = new List<string>();
            foreach (DataRow rt in DTExpedientePermiso.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString());
            }
            /*Comparo si alguna dependencia seleccionada no esta registrada en la tabla expedientepermiso*/
            if (checkedNodes.Count == 0)
                _texto = "No se han  seleccionado dependencias";
            foreach (TreeNode node in checkedNodes)
            {
                if (!valExp.Contains(node.Value.ToString()))
                {
                    String valor = node.Value.ToString();
                    bool confirmar = b1.AddExpedientePermiso(HFCodigoSeleccionado.Value, valor);
                    if (confirmar == true)
                    {
                        cont++;
                        _texto += " " + valor + ",";
                    }

                }
                else
                {
                    _contador++;
                }
            }
            if (_contador == checkedNodes.Count)
            {
                _texto = "Las dependencias seleccionadas ya fueron asignadas al expediente";
                this.LblMessageBox.Text = _texto;
            }
            else
            {
                if (cont == 1)
                {
                    this.LblMessageBox.Text = "Se han habilitado para el expediente " + HFCodigoSeleccionado.Value.ToString()
                        + " la siguiente dependencia: " + _texto.Substring(0, _texto.Length - 1);
                }
                else
                {
                    this.LblMessageBox.Text = "Se han habilitado para el expediente " + HFCodigoSeleccionado.Value.ToString()
                        + " las siguientes dependencias: " + _texto.Substring(0, _texto.Length - 1);
                }
            }
            
            this.MPEMensaje.Show();

        }
        this.ListBox1.Items.Clear();
        ListBox1_Load();

       

        
    }
    protected void BtnEliminaTodos_Click(object sender, EventArgs e)
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
            new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        
        /*Busca todos los elementos*/
        foreach (ListItem l1 in ListBox1.Items)
        {
            
             int confirmado = TAExpedientePermiso.Delete(HFCodigoSeleccionado.Value, l1.Value);
           
        }
        this.TreeVDependencia.Nodes.Clear();
        this.ListBox1.Items.Clear();
        ListBox1_Load();
        TreeVdependencia_Load();

    }
    protected void BtnEliminaUno_Click(object sender, EventArgs e)
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
            new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        int cont = 0;
        /*Busca aquellos elementos que fueron seleccionados*/
        foreach (ListItem l1 in ListBox1.Items)
        {
            if (l1.Selected)
            {
                int confirmado = TAExpedientePermiso.Delete(HFCodigoSeleccionado.Value, l1.Value);
            }
            else
            {
                cont++;
            }
        }
        this.TreeVDependencia.Nodes.Clear();
        this.ListBox1.Items.Clear();
        ListBox1_Load();
        TreeVdependencia_Load();
    }
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        this.Label7.Text = "¿Va a eliminar el expediente seleccionado, Está seguro?";
        MPEConfirmar.Show();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Elimina el expediente actual
        this.DVExpediente.DeleteItem();
    }
}
   

