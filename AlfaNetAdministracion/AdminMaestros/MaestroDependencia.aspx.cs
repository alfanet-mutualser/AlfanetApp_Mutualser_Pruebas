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

public partial class _MaestroDependencia : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Dependencia";
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
            
            this.TCDependencia.ActiveTabIndex = 0;
            this.TabPermisos.ActiveTabIndex = 0;
        }
        else
        {
            TextBox TxtBox = (TextBox)DVDependencia.FindControl("TextBox2");
            RadioButtonList rblst = (RadioButtonList)DVDependencia.FindControl("RbtnLstSelPadre");

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


  

    protected void DVDependencia_DataBound(Object sender, EventArgs e)
    {
        if (this.DVDependencia.DataItemCount.ToString() == "0")
        {
            this.DVDependencia.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVDependencia.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVDependencia.FindControl("Label5");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVDependencia.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
            Label LbDT = (Label)DVDependencia.FindControl("Label50");
            if (LbDT.Text == "1")
            {
                CheckBox ChDT = (CheckBox)DVDependencia.FindControl("CheckBox10");
                ChDT.Checked = true;
                ChDT.Enabled = false;
            }
        }
        else if (this.DVDependencia.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVDependencia.FindControl("Label1");

            DSDependenciaSQLTableAdapters.Dependencia_ReadExisteDependenciaTableAdapter TADependenciaExiste = new DSDependenciaSQLTableAdapters.Dependencia_ReadExisteDependenciaTableAdapter();
            DSDependenciaSQL.Dependencia_ReadExisteDependenciaDataTable DTDependenciaciaExiste = new DSDependenciaSQL.Dependencia_ReadExisteDependenciaDataTable();

            DTDependenciaciaExiste = TADependenciaExiste.GetDependencia_ReadExisteDependencia(LblCodProce.Text);

            Label LblProce = (Label)DVDependencia.FindControl("Label2");
            TextBox TxtProce = (TextBox)DVDependencia.FindControl("TextBox1");
            Label LblProceMsg = (Label)DVDependencia.FindControl("Label13");

            if (DTDependenciaciaExiste.Count == 0)
            {
                LblProce.Visible = false;
                TxtProce.Visible = true;
                LblProceMsg.Visible = false;
            }
            else
            {
                LblProce.Visible = true;
                LblProceMsg.Visible = true;
                TxtProce.Visible = true;  //false
            }            

            TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox5");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVDependencia.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }

            TextBox TxtDT = (TextBox)DVDependencia.FindControl("TextBox50");
            if (TxtDT.Text == "1")
            {
                CheckBox ChDT = (CheckBox)DVDependencia.FindControl("CheckBox10");
                ChDT.Checked = true;
                ChDT.Enabled = true;
            }
            TextBox Txt2 = (TextBox)DVDependencia.FindControl("TextBox2");
            if (Txt2.Text != "")
            {
                RadioButtonList rblPadre = (RadioButtonList)DVDependencia.FindControl("RbtnLstSelPadre");
                rblPadre.SelectedValue = "1";
                Txt2.Visible = true;
            }

        }

    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (this.TxtDependencia.Text != "")
        {
            if (this.TxtDependencia.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | "));
                this.DVDependencia.ChangeMode(DetailsViewMode.ReadOnly);
                                                             
                //this.GVDependenciaPermiso.DataBind();

                DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter ObjTADep = new DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter();
                DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable DTDependencia = new DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable();
                DTDependencia = ObjTADep.GetData(HFCodigoSeleccionado.Value); 
                               
                DataRow[] rows = DTDependencia.Select();
                
                if(DTDependencia.Rows.Count > 0)
                {
                    this.RbtnLstPermiso.Enabled = true;
                    this.RbtnDepPermiso.Enabled = true;
                    
                }


                

                this.RbtnLstPermiso.SelectedValue = rows[0].ItemArray[5].ToString().Trim();
                this.RbtnDepPermiso.SelectedValue = rows[0].ItemArray[7].ToString().Trim();


                this.TreeVDependencia.Nodes.Clear();
                this.TreeVExpediente.Nodes.Clear();
                this.ListBox1.Items.Clear();
                this.ListBox2.Items.Clear();
                
                TreeVdependencia_Load();
                TreeVExpediente_Load();
                ListBox1_Load();
                ListBox2_Load();
                this.TreeVDependencia.Visible = true;
                this.TreeVExpediente.Visible = true;
                this.ListBox1.Visible = true;
                this.ListBox2.Visible = true;
                this.TreeVPreuba.Nodes.Clear();
                TreeVPreuba_Load();

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
                string DatosFin = "Se busco la Dependencia de codigo: " + HFCodigoSeleccionado.Value;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se hace insert de Log Buscar Dependencia
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el Consecutivo Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }

    protected void ImgBtnEditDependencia_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "ACTUALIZAR";
                CheckBox Ch = (CheckBox)DVDependencia.FindControl("CheckBox1");
                if (Ch.Checked == true)
                {
                    TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox5");
                    Txt.Text = "1";
                    //if (Txt.Text == "1")
                    //{
                    this.DependenciaByIdDataSource.UpdateParameters["DependenciaHabilitar"].DefaultValue = "1";
                    //}
                }
                else
                {
                    TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox5");
                    Txt.Text = "0";
                    this.DependenciaByIdDataSource.UpdateParameters["DependenciaHabilitar"].DefaultValue = "0";
                }
                CheckBox ChDT = (CheckBox)DVDependencia.FindControl("CheckBox10");
                if (ChDT.Checked == true)
                {
                    TextBox TxtDT = (TextBox)DVDependencia.FindControl("TextBox50");
                    TxtDT.Text = "1";
                    this.DependenciaByIdDataSource.UpdateParameters["DistriTareas"].DefaultValue = "1";
                }
                else
                {
                    TextBox TxtDT = (TextBox)DVDependencia.FindControl("TextBox50");
                    TxtDT.Text = "0";
                    this.DependenciaByIdDataSource.UpdateParameters["DistriTareas"].DefaultValue = "0";
                }

                RadioButtonList rblst = (RadioButtonList)DVDependencia.FindControl("RbtnLstSelPadre");
                if (rblst != null)
                {
                    if (rblst.SelectedValue.ToString() == "0")
                    {
                        this.DependenciaByIdDataSource.UpdateParameters["DependenciaCodigoPadre"].DefaultValue = "0";
                    }
                    else
                    {
                        TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox2");
                        if (Txt.Text == "")
                        {
                            this.DependenciaByIdDataSource.UpdateParameters["DependenciaCodigoPadre"].DefaultValue = "0";
                        }
                    }
                }
        


        
        this.DependenciaByIdDataSource.UpdateParameters["DependenciaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        this.DependenciaByIdDataSource.UpdateParameters["Original_DependenciaCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.DependenciaByIdDataSource.UpdateParameters["DependenciaNombre"].DefaultValue = HFCodigoSeleccionado.Value;

        string habilitar = this.DependenciaByIdDataSource.UpdateParameters["DependenciaHabilitar"].DefaultValue;
        string DatosIni = DVDependencia.SelectedValue + " | " + habilitar; //AccioCod + Habilitar
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
        string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();//AccioCod + Habilitar
        string DatosFin = DVDependencia.SelectedValue + " | " + habilitar;
        DateTime FechaFin = DateTime.Now;
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();  //Se hace insert de Log actualizar accion
        DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
        BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo Log
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        
    }

    protected void ImgBtnInsertDependencia_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVDependencia.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox5");
            Txt.Text = "1";
            this.DependenciaByIdDataSource.InsertParameters["DependenciaHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox5");
            Txt.Text = "0";
            this.DependenciaByIdDataSource.InsertParameters["DependenciaHabilitar"].DefaultValue = "0";
        }

        CheckBox ChDT = (CheckBox)DVDependencia.FindControl("CheckBox10");
        if (ChDT.Checked == true)
        {
            TextBox TxtDT = (TextBox)DVDependencia.FindControl("TextBox50");
            TxtDT.Text = "1";
            this.DependenciaByIdDataSource.InsertParameters["DistriTareas"].DefaultValue = "1";
        }
        else
        {
            TextBox TxtDT = (TextBox)DVDependencia.FindControl("TextBox50");
            TxtDT.Text = "0";
            this.DependenciaByIdDataSource.InsertParameters["DistriTareas"].DefaultValue = "0";
        }

        RadioButtonList rblst = (RadioButtonList)DVDependencia.FindControl("RbtnLstSelPadre");
        if (rblst != null)
        {
            if (rblst.SelectedValue.ToString() == "0")
            {
                this.DependenciaByIdDataSource.InsertParameters["DependenciaCodigoPadre"].DefaultValue = "0";
            }
            else
            {
                TextBox Txt = (TextBox)DVDependencia.FindControl("TextBox2");
                if (Txt.Text == "")
                {
                    this.DependenciaByIdDataSource.InsertParameters["DependenciaCodigoPadre"].DefaultValue = "0";
                }
            }
        }

        this.DependenciaByIdDataSource.InsertParameters["DependenciaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
    }
    
    protected void DVDependencia_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
    {   
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            //this.LblMessageBox.Text += inner.Message.ToString();
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            //this.DVDependenciaPermiso.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVDependencia_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
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
            TextBox text = (TextBox)DVDependencia.FindControl("TextBox1");

            string dependencia = TxtDependencia.Text;

            if (dependencia.Contains(" | "))
            {

                dependencia = dependencia.Remove(dependencia.IndexOf(" | "));

                //prof.CodigoDepUsuario = DependenciaCod;

            }

            //else

            //{

            //    dependencia = null;

            //    //prof.CodigoDepUsuario = ND[0].ToString().TrimEnd();

            //}

            DSUsuarioTableAdapters.Usuariosxdependencia1TableAdapter DSUXDependencia = new DSUsuarioTableAdapters.Usuariosxdependencia1TableAdapter();

            DSUsuario.Usuariosxdependencia1DataTable DSUsuarioDT = new DSUsuario.Usuariosxdependencia1DataTable();

            //DataSet ds = new DataSet();

            DSUsuarioDT = DSUXDependencia.GetDataByUsuarioxDependencia(dependencia);

            //ds=(DataSet)DSUXDependencia.GetDataByUsuarioxDependencia(dependencia);



            foreach (DataRow item in DSUsuarioDT.Rows)
            {

                ProfileCommon prof = Profile.GetProfile(DSUsuarioDT.Rows[0]["username"].ToString());

                String[] ND = this.TxtDependencia.Text.Split('|');

                prof.CodigoDepUsuario = ND[0].ToString().TrimEnd();

                prof.NombreDepUsuario = text.Text.Trim();

                prof.Save();

            }

            this.DVDependencia.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }

    protected void DVDependencia_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
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
            this.DVDependencia.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void GVDependenciaPermiso_RowDeleted(Object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar eliminar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;
        }
        else if (e.Exception == null)
        {
            this.DVDependencia.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void TCDependencia_OnActiveTabChanged(Object sender, EventArgs e)
    {
 
        if (this.TCDependencia.ActiveTabIndex.ToString() == "1")
        {
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.LblMessageBox.Text = "No ha seleccionado una dependencia";
                this.MPEMensaje.Show();
                this.TreeVDependencia.Visible = false;
                this.TreeVExpediente.Visible = false;
                
            }
            else
            {
                this.RbtnLstPermiso.Enabled = true;
                this.TreeVDependencia.Visible = true;
                this.TreeVExpediente.Visible = true;
                this.ListBox1.Visible = true;
                this.ListBox2.Visible = true;
                this.RbtnLstPermiso.Enabled = true;
                this.TreeVDependencia.Nodes.Clear();
                this.TreeVExpediente.Nodes.Clear();
                
                TreeVExpediente_Load();
                TreeVdependencia_Load();
                ListBox1_Load();
                ListBox2_Load();
                this.TreeVPreuba.Nodes.Clear();
                TreeVPreuba_Load();
               
            }
        }
    }

    protected void TPermisos_OnActiveTabChanged(Object sender, EventArgs e)
    {
        this.TreeVDependencia.Nodes.Clear();
        this.TreeVExpediente.Nodes.Clear();
        this.ListBox1.Items.Clear();
        this.ListBox2.Items.Clear();
        if (this.TCDependencia.ActiveTabIndex.ToString() == "1")
        {
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.TreeVDependencia.Visible = false;
                this.TreeVExpediente.Visible = false;
                /*
                this.LblMessageBox.Text = "No ha seleccionado una dependencia";
                this.MPEMensaje.Show();
                */
            }
            else
            {
                this.TreeVDependencia.Visible = true;
                this.TreeVExpediente.Visible = true;
                this.ListBox1.Visible = true;
                this.ListBox2.Visible = true;
                this.RbtnLstPermiso.Enabled = true;
                TreeVExpediente_Load();
                TreeVdependencia_Load();
                ListBox1_Load();
                ListBox2_Load();
                this.TreeVPreuba.Nodes.Clear();
                TreeVPreuba_Load();
            }
        }
    }

    
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteDependencia.ServiceMethod = "GetDependenciaByTextnull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteDependencia.ServiceMethod = "GetDependenciaByTextIdnull";
    }


    protected void DVDependencia_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

    }

    /*Configuración de boton de heredar para el modal popup*/
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        BtnHeredar1.Click += new EventHandler(btnShow_Click);
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        this.TreeVPreuba.Nodes.Clear();
        TreeVPreuba_Load();
        ModalPopupExtender1.Show();
    }

    /*Funciones del módulo de heredar*/
    protected void BtHeredarOK_Clic(object sender, EventArgs e)

    {
        /*Verificar los nodos pares y sus hijos*/
            TreeVPreuba.ExpandAll();
            List<string> nodos = new List<string>();
            List<string> propiedades = new List<string>();
            List<string> dep_ok = new List<string>();
            List<string> dep_fail = new List<string>();

            foreach (TreeNode tn in TreeVPreuba.CheckedNodes)
            {
                  if(!nodos.Contains(tn.Value))
                    nodos.Add(tn.Value);
            }
            nodos.Remove(HFCodigoSeleccionado.Value);
        /*Verificar los permisos*/

            foreach (ListItem lt in ListBox1.Items)
            {
                if (!propiedades.Contains(lt.Value))
                    propiedades.Add(lt.Value);
       
            }

            DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();
            
            
        /*Asignación de los permisos a las dpendencias*/
            foreach (string dep in nodos)
            {
                foreach (string valor in propiedades)
                {
                    try
                    {
                        dt1.DependenciaInsertPermiso(valor, dep);
                        if (!dep_ok.Contains(valor))
                        {
                            dep_ok.Add(dep);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                      if(!dep_fail.Contains(dep))
                      {
                        dep_fail.Add(dep);
                        if (dep_ok.Contains(dep))
                        {
                            dep_ok.Remove(dep);
                        }
                      }
                        
                    }
                }
            }
            this.LblMessageBox.Text = "Las dependencias: ";
            foreach (string res1 in nodos)
            {
                this.LblMessageBox.Text += res1+" ";
            }
            this.LblMessageBox.Text += " les fueron heredadas todas las opciones.\n";
            
            
            //this.LblMessageBox.Text = "Total nodos : " + nodos.Count.ToString();
            this.MPEMensaje.Show();

            this.TreeVPreuba.Nodes.Clear();
            this.TreeVPreuba_Load();
      
    }

    protected void BtHeredarCan_Clic(object sender, EventArgs e)
    {
        this.TreeVdependencia_Load();
        this.TreeVPreuba_Load();
    }

   
    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter ObjTADep = new DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter();
        //DSDependenciaSQLTableAdapters.DependenciaTableAdapter ObjTAExp = new DSDependenciaSQLTableAdapters.DependenciaTableAdapter();
        DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable DTDependencia = new DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable();
        //DSDependenciaSQL.DependenciaDataTable DTDependencia = new DSDependenciaSQL.DependenciaDataTable();
        DTDependencia = ObjTADep.GetDependencia_UpdateDependenciaPermisoBy(HFCodigoSeleccionado.Value, RbtnLstPermiso.SelectedValue);
        this.TreeVDependencia.Nodes.Clear();
        TreeVdependencia_Load();
        //DTDependencia = ObjTAExp.GetDependencia_UpdateDependenciaPermisoBy(HFCodigoSeleccionado.Value, Convert.ToBoolean(RbtnLstPermiso.SelectedValue));


    }

    protected void RbtnDepPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter ObjTADep = 
            new DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter();

        DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable DTDependencia 
            = new DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable();

        DTDependencia = ObjTADep.GetDependencia_UpdateExpedientePermisoDataBy(HFCodigoSeleccionado.Value, RbtnDepPermiso.SelectedValue);
        this.TreeVExpediente.Nodes.Clear();
        TreeVExpediente_Load();
        /*
        DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter ObjTADep = new DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaByIdTableAdapter();
        //DSDependenciaSQLTableAdapters.DependenciaTableAdapter ObjTAExp = new DSDependenciaSQLTableAdapters.DependenciaTableAdapter();
        DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable DTDependencia = new DSDependenciaSQL.Dependencia_ReadDependenciaByIdDataTable();
        //DSDependenciaSQL.DependenciaDataTable DTDependencia = new DSDependenciaSQL.DependenciaDataTable();
        DTDependencia = ObjTADep.GetDependencia_UpdateDependenciaPermisoBy(HFCodigoSeleccionado.Value, RbtnLstPermiso.SelectedValue);
        this.TreeVDependencia.Nodes.Clear();
        this.TreeVExpediente.Nodes.Clear();
        TreeVExpediente_Load();
        TreeVdependencia_Load();
        //DTDependencia = ObjTAExp.GetDependencia_UpdateDependenciaPermisoBy(HFCodigoSeleccionado.Value, Convert.ToBoolean(RbtnLstPermiso.SelectedValue));
        */

    }

    protected void DVDependenciaPermiso_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
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
            this.DVDependencia.DataBind();
            //this.DVDependenciaPermiso.DataBind();
            //this.GVDependenciaPermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }

    }
    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImgBtnNewDependencia_Click(object sender, ImageClickEventArgs e)
    {
        this.DVDependencia.ChangeMode(DetailsViewMode.Insert);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        DependenciaBLL Dependencia = new DependenciaBLL();
        bool Correcto;

        try
        {

            Correcto = Dependencia.DeleteDependencia(HFCodigoSeleccionado.Value);
            this.LblMessageBox.Text = "Registro Eliminado";
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        //this.DVDepartamento.DataBind();
       
        this.MPEMensaje.Show();
        this.TxtDependencia.Text = "";
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
        
        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();

        
        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString()+" | "+rt.ItemArray[2].ToString());
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
                if (valExp.Contains(tn.Text.ToString()))
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
        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();


        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString() + " | " + rt.ItemArray[2].ToString());
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
                if (valExp.Contains(tn.Text.ToString()))
                {
                    tn.Checked = true;
                }
            }

            TreeVDependencia.Nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }

    private void PopulateNodes5(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {

        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();


        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString() + " | " + rt.ItemArray[2].ToString());
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
            //if (valExp.Count > 0)
            //{
            //    if (valExp.Contains(tn.Text.ToString()))
            //    {
            //        tn.Checked = true;
            //    }
            //}
            tn.Checked = true;

            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }

    private void PopulateNodes5(DataTable dt, String Codigo, String Nombre, string SeleccionarNodo)
    {
        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();


        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[1].ToString() + " | " + rt.ItemArray[2].ToString());
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

            //if (valExp.Count > 0)
            //{
            //    if (valExp.Contains(tn.Text.ToString()))
            //    {
            //        tn.Checked = true;
            //    }
            //}
            tn.Checked = true;
            TreeVPreuba.Nodes.Add(tn);

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


    protected void TreeVPreuba_Load(object sender, EventArgs e)
    {

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {

            this.TreeVPreuba.Attributes.Add("onclick", "OnTreeClick(event)");

            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DependenciaBLL b1 = new DependenciaBLL();
            DataTable t1 = b1.GetDependenciaByID(HFCodigoSeleccionado.Value);
            
            DTDependencia = ObjArbolDep.GetDependenciaTree(t1.Rows[0].ItemArray[2].ToString());
            PopulateNodes5(DTDependencia, "DependenciaCodigo", "DependenciaNombre", "0");



        }
    }

    protected void TreeVPreuba_Load()
    {
      
        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
        this.TreeVPreuba.Attributes.Add("onclick", "OnTreeClick(event)");

        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DependenciaBLL b1 = new DependenciaBLL();
        DataTable t1 = b1.GetDependenciaByID(HFCodigoSeleccionado.Value);
        DTDependencia = ObjArbolDep.GetDependenciaTree(t1.Rows[0].ItemArray[2].ToString());
        PopulateNodes5(DTDependencia, "DependenciaCodigo", "DependenciaNombre", "0");
        }
    }

    protected void TreeVPreuba_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {

        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes5(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre", "0");

    }

    /*Metodos para llenar el nodo de expedientes*/

    private void PopulateNodes2(DataTable dt, String Codigo, String Nombre, string SeleccionarNodo)
    {
        DataTable t1 = new DataTable();

        DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter taExp =
            new DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter();


        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = taExp.GetExpedientePermisoByDependencia(HFCodigoSeleccionado.Value);
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[0].ToString());
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

            TreeVExpediente.Nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }

    private void PopulateNodes2(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {
        DataTable t1 = new DataTable();

        DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter taExp =
            new DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter();


        System.Collections.Generic.List<String> valExp = new List<string>();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = taExp.GetExpedientePermisoByDependencia(HFCodigoSeleccionado.Value);
            foreach (DataRow rt in t1.Rows)
            {
                valExp.Add(rt.ItemArray[0].ToString());
            }
        }


        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
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

    protected void TreeVExpediente_Load()
    {
        
            this.TreeVExpediente.Attributes.Add("onclick", "OnTreeClick(event)");
            this.TreeVExpediente.Visible = true;
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTDExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTDExpediente = ObjArbolDep.GetExpedienteTree("0");
            PopulateNodes2(DTDExpediente, "ExpedienteCodigo", "ExpedienteNombre", "0");
        
    }

    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTDExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTDExpediente = ObjArbolDep.GetExpedienteTree(e.Node.Value);
            PopulateNodes2(DTDExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre", "0");
        
    }


    protected void TreeVExpediente_Load(object sender, EventArgs e)
    {
        
            this.TreeVExpediente.Attributes.Add("onclick", "OnTreeClick(event)");
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTDExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTDExpediente = ObjArbolDep.GetExpedienteTree("0");
            PopulateNodes2(DTDExpediente, "ExpedienteCodigo", "ExpedienteNombre", "0");
        
    }

    

    protected void ListBox1_Load()
    {
        ListBox1.Items.Clear();
        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();

       

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());
            if (t1.Rows.Count > 0)
            {
                foreach (DataRow r1 in t1.Rows)
                {
                    ListBox1.Items.Add(new ListItem(r1.ItemArray[1].ToString() + " | " + r1.ItemArray[2].ToString(), r1.ItemArray[1].ToString()));
                }
                ListBox1.DataBind();

            }
        }
    }

    protected void ListBox2_Load()
    {
        ListBox2.Items.Clear();
        
        DataTable t2 = new DataTable();

        DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter taExp =
            new DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter();

        if (this.HFCodigoSeleccionado.Value.Length.ToString() != "0")
        {
            t2 = taExp.GetExpedientePermisoByDependencia(HFCodigoSeleccionado.Value);
            if (t2.Rows.Count > 0)
            {
                foreach (DataRow r1 in t2.Rows)
                {
                    ListBox2.Items.Add(new ListItem(r1.ItemArray[0].ToString() + " | " + r1.ItemArray[2].ToString(), r1.ItemArray[0].ToString()));
                }
                ListBox2.DataBind();

            }
        }
    }

    /*Funciones del módulo de asignar permisos de dependencias*/

    protected void BtnAdicionaUno_Click(object sender, EventArgs e)
    {
       

    }
    protected void BtnAdicionaTodos_Click(object sender, EventArgs e)
    {
        /*Selecciono todos los nodos seleccionados*/

        TreeNodeCollection checkedNodes = TreeVDependencia.CheckedNodes;

        DataTable t1 = new DataTable();

        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();

        t1 = dt1.GetData(HFCodigoSeleccionado.Value.ToString());



        int cont = 0;

        /*Evalua si no se le ha asignado permiso*/
        if (t1.Rows.Count == 0)
        {
            String _texto = "";
            /*Buscar si los nodos seleccionados ya estan presentes*/
            if (checkedNodes.Count == 0)
                _texto = "No ha seleccionado dependencia";
            foreach (TreeNode node in checkedNodes)
            {
                String valor = node.Value.ToString();
                dt1.DependenciaInsertPermiso(valor, HFCodigoSeleccionado.Value);
                cont++;
                _texto += " " + valor + ",";
                /*
                String valor = node.Value.ToString();
                bool confirmar = b1.AddExpedientePermiso(HFCodigoSeleccionado.Value, valor);
                if (confirmar == true)
                {
                    cont++;
                    _texto += " " + valor + ",";
                }*/

            }
            if (cont == 1)
            {
                this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
                    + " la siguiente dependencia: " + _texto.Substring(0, _texto.Length - 1);
            }
            else
            {
                this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
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
            foreach (DataRow rt in t1.Rows)
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
                    dt1.DependenciaInsertPermiso(valor, HFCodigoSeleccionado.Value);
                    cont++;
                    _texto += " " + valor + ",";
                    /*
                    String valor = node.Value.ToString();
                    bool confirmar = b1.AddExpedientePermiso(HFCodigoSeleccionado.Value, valor);
                    if (confirmar == true)
                    {
                        cont++;
                        _texto += " " + valor + ",";
                    }*/

                }
                else
                {
                    _contador++;
                }
            }
            if (_contador == checkedNodes.Count)
            {
                _texto = "Las dependencias seleccionadas ya fueron asignadas a la dependencia";
                this.LblMessageBox.Text = _texto;
            }
            else
            {
                if (cont == 1)
                {
                    this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
                        + " la siguiente dependencia: " + _texto.Substring(0, _texto.Length - 1);
                }
                else
                {
                    this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
                        + " las siguientes dependencias: " + _texto.Substring(0, _texto.Length - 1);
                }
            }

            this.MPEMensaje.Show();

        }
        this.TreeVDependencia.Nodes.Clear();
        TreeVdependencia_Load();
        this.ListBox1.Items.Clear();
        ListBox1_Load();

    }
    protected void BtnEliminaUno_Click(object sender, EventArgs e)
    {
        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();

        /*Busca todos los elementos*/
        foreach (ListItem l1 in ListBox1.Items)
        {
            if (l1.Selected)
            { 
                dt1.DependenciaPermiso_DeleteDependenciaPermiso(HFCodigoSeleccionado.Value, l1.Value);

            }
            
        }
        this.TreeVDependencia.Nodes.Clear();
        this.ListBox1.Items.Clear();
        ListBox1_Load();
        TreeVdependencia_Load();
    }
    protected void BtnEliminaTodos_Click(object sender, EventArgs e)
    {
        DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter dt1 =
            new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();

        /*Busca todos los elementos*/
        foreach (ListItem l1 in ListBox1.Items)
        {
            dt1.DependenciaPermiso_DeleteDependenciaPermiso(HFCodigoSeleccionado.Value, l1.Value);

        }
        this.TreeVDependencia.Nodes.Clear();
        this.ListBox1.Items.Clear();
        ListBox1_Load();
        TreeVdependencia_Load();
    }

    /*Metodos para adicionar o eliminar permisos de dependencias*/

    protected void BtnAdicionaTodosB_Click(object sender, EventArgs e)
    {

        /*Selecciono todos los nodos seleccionados*/
        TreeNodeCollection checkedNodes = TreeVExpediente.CheckedNodes;

        DataTable t2 = new DataTable();


        DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter taExp =
            new DSExpedienteSQLTableAdapters.ExpedientePermisoTableAdapter();

        t2 = taExp.GetExpedientePermisoByDependencia(HFCodigoSeleccionado.Value);

        ExpedienteBLL b1 = new ExpedienteBLL();

        int cont = 0;

        /*Evalua si no se le ha asignado permiso*/
        if (t2.Rows.Count == 0)
        {
            String _texto = "";
            /*Buscar si los nodos seleccionados ya estan presentes*/
            if (checkedNodes.Count == 0)
                _texto = "No ha seleccionado dependencia";
            foreach (TreeNode node in checkedNodes)
            {

                String valor = node.Value.ToString();
                bool confirmar = b1.AddExpedientePermiso(valor, HFCodigoSeleccionado.Value);
                if (confirmar == true)
                {
                    cont++;
                    _texto += " " + valor + ",";
                }

            }
            if (cont == 1)
            {
                this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
                    + " el siguiente expediente: " + _texto.Substring(0, _texto.Length - 1);
            }
            else
            {
                this.LblMessageBox.Text = "Se han habilitado para el expediente " + HFCodigoSeleccionado.Value.ToString()
                    + " los siguientes expedientes: " + _texto.Substring(0, _texto.Length - 1);
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
            foreach (DataRow rt in t2.Rows)
            {
                valExp.Add(rt.ItemArray[0].ToString());
            }
            /*Comparo si alguna dependencia seleccionada no esta registrada en la tabla expedientepermiso*/
            if (checkedNodes.Count == 0)
                _texto = "No se han  seleccionado dependencias";
            foreach (TreeNode node in checkedNodes)
            {
                if (!valExp.Contains(node.Value.ToString()))
                {
                    String valor = node.Value.ToString();
                    bool confirmar = b1.AddExpedientePermiso(valor, HFCodigoSeleccionado.Value);
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
                _texto = "Los expedientes seleccionados ya fueron asignadas a la dependencia";
                this.LblMessageBox.Text = _texto;
            }
            else
            {
                if (cont == 1)
                {
                    this.LblMessageBox.Text = "Se han habilitado para la depedencia " + HFCodigoSeleccionado.Value.ToString()
                        + " el siguiente expediente: " + _texto.Substring(0, _texto.Length - 1);
                }
                else
                {
                    this.LblMessageBox.Text = "Se han habilitado para la dependencia " + HFCodigoSeleccionado.Value.ToString()
                        + " los siguientes expedientes: " + _texto.Substring(0, _texto.Length - 1);
                }
            }

            this.MPEMensaje.Show();

        }
        this.TreeVExpediente.Nodes.Clear();
        this.ListBox2.Items.Clear();
        ListBox2_Load();
        //TreeVExpediente_Load();

    }
    protected void BtnEliminaUnoB_Click(object sender, EventArgs e)
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
           new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        int cont = 0;
        /*Busca aquellos elementos que fueron seleccionados*/
        foreach (ListItem l1 in ListBox2.Items)
        {
            if (l1.Selected)
            {
                int confirmado = TAExpedientePermiso.Delete(l1.Value, HFCodigoSeleccionado.Value);
            }
            else
            {
                cont++;
            }
        }
        this.TreeVExpediente.Nodes.Clear();
        this.ListBox2.Items.Clear();
        ListBox2_Load();
        TreeVExpediente_Load();
    }
    protected void BtnEliminaTodosB_Click(object sender, EventArgs e)
    {
        DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter TAExpedientePermiso =
          new DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter();
        int cont = 0;
        /*Busca todos los elementos*/
        foreach (ListItem l1 in ListBox2.Items)
        {
            int confirmado = TAExpedientePermiso.Delete(l1.Value, HFCodigoSeleccionado.Value);
        }
        this.TreeVExpediente.Nodes.Clear();
        this.ListBox2.Items.Clear();
        ListBox2_Load();
        TreeVExpediente_Load();

    }
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        this.Label7.Text = "¿Va a eliminar la Dependencia seleccionada, Está seguro?";
        this.MPEPregunta.Show();
    }
}

