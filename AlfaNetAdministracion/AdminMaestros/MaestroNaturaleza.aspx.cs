using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebNavigator;
using System.Net;
using System.Net.NetworkInformation;

public partial class _MaestroNaturaleza : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "6";
    string ModuloLog = "Maestro Naturaleza";
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
           

            this.TCNaturaleza.ActiveTabIndex = 0;
        }
        else
        {
            TextBox TxtBox = (TextBox)DVNaturaleza.FindControl("TextBox1");
            RadioButtonList rblst = (RadioButtonList)DVNaturaleza.FindControl("RbtnLstSelPadre");

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
            TextBox TxtBoxPQR = (TextBox)DVNaturaleza.FindControl("TextBox7");
            CheckBox ChkPQR = (CheckBox)DVNaturaleza.FindControl("CheckBox2");
            if (ChkPQR != null)
            {
                if (ChkPQR.Checked == true)
                {
                    if (TxtBoxPQR != null)
                    {
                        TxtBoxPQR.Visible = true;
                    }
                }
                else
                {
                    if (TxtBoxPQR != null)
                    {
                        TxtBoxPQR.Visible = false;
                    }
                }
            }
        }    
                 
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        if (TxtNaturaleza.Text != "")
        {
            if (TxtNaturaleza.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtNaturaleza.Text.Remove(TxtNaturaleza.Text.IndexOf(" | "));
                this.DVNaturaleza.ChangeMode(DetailsViewMode.ReadOnly);

                //this.GVExpedientePermiso.DataBind();

                DSNaturalezaSQLTableAdapters.NaturalezaTableAdapter ObjTANat = new DSNaturalezaSQLTableAdapters.NaturalezaTableAdapter();
                DSNaturalezaSQL.NaturalezaDataTable DTNAturaleza = new DSNaturalezaSQL.NaturalezaDataTable();
                DTNAturaleza = ObjTANat.GetNaturalezaById(HFCodigoSeleccionado.Value);
                string nombre = DTNAturaleza[0].NaturalezaNombre;
                DataRow[] rows = DTNAturaleza.Select();

                this.RbtnLstPermiso.SelectedValue = rows[0].ItemArray[6].ToString().Trim();

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
                string DatosFin = HFCodigoSeleccionado.Value + " | " + nombre; //Naturaleza de codigo+ Naturaleza nombre
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se hace insert de Log Buscar Naturaleza
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
                //Se acutaliza consecutivo de LOG
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
        }
    }


    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtBox = (TextBox)DVNaturaleza.FindControl("TxtPais");

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
        TextBox TxtBox = (TextBox)DVNaturaleza.FindControl("TxtPais");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains("-"))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
            }
        }
    }


    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVNaturaleza.DataItemCount.ToString() == "0")
        {
            this.DVNaturaleza.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVNaturaleza.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVNaturaleza.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVNaturaleza.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
            Label LbPQR = (Label)DVNaturaleza.FindControl("Label6");
            if (LbPQR.Text == "1")
            {
                CheckBox ChPQR = (CheckBox)DVNaturaleza.FindControl("CheckBox2");
                ChPQR.Checked = true;
                ChPQR.Enabled = false;
            }
        }
        else if (this.DVNaturaleza.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVNaturaleza.FindControl("Label1");

            DSNaturalezaSQLTableAdapters.Naturaleza_ReadExistePNaturalezaTableAdapter TANaturalezaExiste = new DSNaturalezaSQLTableAdapters.Naturaleza_ReadExistePNaturalezaTableAdapter();
            DSNaturalezaSQL.Naturaleza_ReadExistePNaturalezaDataTable DTNaturalezaExiste = new DSNaturalezaSQL.Naturaleza_ReadExistePNaturalezaDataTable();
            DTNaturalezaExiste = TANaturalezaExiste.GetNaturaleza_ReadExisteNaturaleza(LblCodProce.Text);

            Label LblProce = (Label)DVNaturaleza.FindControl("Label5");
            TextBox TxtProce = (TextBox)DVNaturaleza.FindControl("TextBox4");
            Label LblProceMsg = (Label)DVNaturaleza.FindControl("Label13");

            if (DTNaturalezaExiste.Count == 0)
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
            TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox2");
            
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVNaturaleza.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
                
            }
            TextBox TxtDepPQR = (TextBox)DVNaturaleza.FindControl("TextBox7");
            TextBox TxtPQR = (TextBox)DVNaturaleza.FindControl("TextBox6");
            if (TxtPQR.Text == "1")
            {
                CheckBox ChPQR = (CheckBox)DVNaturaleza.FindControl("CheckBox2");
                ChPQR.Checked = true;
                ChPQR.Enabled = true;
                TxtDepPQR.Visible = true;
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
            this.DVNaturaleza.DataBind();
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
            
            if (this.TxtNaturaleza.Text != "")
            {
                if (this.TxtNaturaleza.Text.Contains(" | "))
                {
                    this.HFCodigoSeleccionado.Value = TxtNaturaleza.Text.Remove(TxtNaturaleza.Text.IndexOf(" | "));
                    this.DVNaturaleza.ChangeMode(DetailsViewMode.ReadOnly);


                }
            }
            this.DVNaturaleza.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
            //this.DVNaturaleza.ChangeMode(DetailsViewMode.ReadOnly);
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
        
            this.DVNaturaleza.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TCNaturaleza_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.TCNaturaleza.ActiveTabIndex.ToString() == "1")
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
    protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DSNaturalezaSQLTableAdapters.NaturalezaTableAdapter ObjTANatPer = new DSNaturalezaSQLTableAdapters.NaturalezaTableAdapter();

        
        DSNaturalezaSQL.NaturalezaDataTable DTNaturalezaPer = new DSNaturalezaSQL.NaturalezaDataTable();

        
        DTNaturalezaPer = ObjTANatPer.GetNaturalezaById(HFCodigoSeleccionado.Value);
        //DSNaturalezaSQL.NaturalezaRow RownaturalezaPer = DTNaturalezaPer.NewNaturalezaRow();
       
        DataRow[] rows = DTNaturalezaPer.Select();
        String Padre;
        if (rows[0].ItemArray[2].ToString() == "")
            Padre = null;
        else
            Padre = rows[0].ItemArray[2].ToString();

        DTNaturalezaPer = ObjTANatPer.GetNaturaleza_UpdateNaturalezaBy(rows[0].ItemArray[1].ToString(),
                                                                       Padre,
                                                                       Convert.ToInt32(rows[0].ItemArray[3].ToString()),
                                                                       rows[0].ItemArray[5].ToString(),
                                                                       this.RbtnLstPermiso.SelectedValue,
                                                                       rows[0].ItemArray[0].ToString());
     
       //DTExpediente = ObjTAExp.GetExpediente_UpdateExpedientePermisoBy(HFCodigoSeleccionado.Value, Convert.ToBoolean(RbtnLstPermiso.SelectedValue));
    }
    protected void ImgBtnDeleteExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    {
        this.NaturalezaByIdDataSource.DeleteParameters["Original_NaturalezaCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtNaturaleza.Text = "";
        this.Label7.Text = "¿Va a eliminar la Naturaleza seleccionada esta seguro?" + " ";
        this.MPEPregunta.Show();
    }
    protected void ImgBtnEditExpediente_Click(object sender, ImageClickEventArgs e)
    {
        //if (DVNaturaleza.DefaultMode != DetailsViewMode.ReadOnly)
        //{
            CheckBox Ch = (CheckBox)DVNaturaleza.FindControl("CheckBox1");
            if (Ch.Checked == true)
            {
                TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox2");
                Txt.Text = "1";
                //if (Txt.Text == "1")
                //{
                this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaHabilitar"].DefaultValue = "1";
                //}
            }
            else
            {
                TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox2");
                Txt.Text = "0";
                this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaHabilitar"].DefaultValue = "0";
            }
            CheckBox ChPQR = (CheckBox)DVNaturaleza.FindControl("CheckBox2");
            if (ChPQR.Checked == true)
            {
                TextBox TxtPQR = (TextBox)DVNaturaleza.FindControl("TextBox6");
                TxtPQR.Text = "1";
                this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaPQR"].DefaultValue = "1";
            }
            else
            {
                TextBox TxtPQR = (TextBox)DVNaturaleza.FindControl("TextBox6");
                TxtPQR.Text = "0";
                this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaPQR"].DefaultValue = "0";
            }

            TextBox TxtDEPPQR = (TextBox)DVNaturaleza.FindControl("TextBox7");
            this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaDependenciaPQR"].DefaultValue = TxtDEPPQR.Text;

        this.NaturalezaByIdDataSource.UpdateParameters["NaturalezaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        this.NaturalezaByIdDataSource.UpdateParameters["Original_NaturalezaCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        
   // }
    }
    protected void ImgBtnInsertExpediente_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVNaturaleza.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox2");
            Txt.Text = "1";
            this.NaturalezaByIdDataSource.InsertParameters["NaturalezaHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox2");
            Txt.Text = "0";
            this.NaturalezaByIdDataSource.InsertParameters["NaturalezaHabilitar"].DefaultValue = "0";
        }
        CheckBox ChPQR = (CheckBox)DVNaturaleza.FindControl("CheckBox2");
        if (ChPQR.Checked == true)
        {
            TextBox TxtPQR = (TextBox)DVNaturaleza.FindControl("TextBox6");
            TxtPQR.Text = "1";
            this.NaturalezaByIdDataSource.InsertParameters["NaturalezaPQR"].DefaultValue = "1";
        }
        else
        {
            TextBox TxtPQR = (TextBox)DVNaturaleza.FindControl("TextBox6");
            TxtPQR.Text = "0";
            this.NaturalezaByIdDataSource.InsertParameters["NaturalezaPQR"].DefaultValue = "0";
        }
        TextBox TxtDEPPQR = (TextBox)DVNaturaleza.FindControl("TextBox7");
        this.NaturalezaByIdDataSource.InsertParameters["NaturalezaDependenciaPQR"].DefaultValue = TxtDEPPQR.Text;
        this.NaturalezaByIdDataSource.InsertParameters["NaturalezaPermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        
    }
    protected void ImgBtnInsertExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtDep = (TextBox)DVExpedientePermiso.FindControl("TextBox2");
        String DepCod = TxtDep.Text;
        if (DepCod != "")
        {
            if (DepCod.Contains(" | "))
            {
                DepCod = DepCod.Remove(DepCod.IndexOf(" | "));
            }
        }

        //DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter ObjTADepPer = new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();
        //int correcto = ObjTADepPer.Insert(DepCod,this.HFCodigoSeleccionado.Value);
        this.ODSPermisoNaturaleza.InsertParameters["NaturalezaCodigo"].DefaultValue = this.HFCodigoSeleccionado.Value;
        this.ODSPermisoNaturaleza.InsertParameters["DependenciaCodigo"].DefaultValue = DepCod;
        //this.ODSPermisoDependencia.Insert();
        //this.ODSPermisoExpediente.InsertParameters["ExpedienteCodigo"].DefaultValue = this.HFCodigoSeleccionado.Value;
        //this.GVExpedientePermiso.DataBind();
        TxtDep.Text = "";
        Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
        Lb.Text = HFCodigoSeleccionado.Value;
    }
    protected void GVExpedientePermiso_RowDeleted(object sender, GridViewDeletedEventArgs e)
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
            this.DVNaturaleza.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
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
            this.DVNaturaleza.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
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
            this.DVNaturaleza.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
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
            this.DVNaturaleza.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_DataBound(object sender, EventArgs e)
    {
        Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
        Lb.Text = HFCodigoSeleccionado.Value;


        //Label Lb1 = (Label)DetailsView1.FindControl("Label1");
        //Lb1.Text = HFCodigoSeleccionado.Value;
        //this.DVDependencia.
        /*
        this.MPEMensaje.Show(this.DVExpediente.DefaultMode.ToString());

        if (this.DVExpediente.DataItemCount.ToString() == "0")
        {
            this.DVExpediente.ChangeMode(DetailsViewMode.Insert);
        }

        if (this.DVExpediente.DefaultMode.ToString() == "Insert")
        {
            this.RbtnLstPermiso.Enabled = true;
        }
        */
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //this.DVNaturaleza.ChangeMode(DetailsViewMode.Edit);
    }
    protected void ImgBtnNewExpediente_Click(object sender, ImageClickEventArgs e)
    {
        this.DVNaturaleza.ChangeMode(DetailsViewMode.Insert);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.ACSearchNaturaleza.ServiceMethod = "GetNaturalezaByTextnull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.ACSearchNaturaleza.ServiceMethod = "GetNaturalezaByTextIdnull";
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        NaturalezaBLL Naturaleza = new NaturalezaBLL();
        bool Correcto;

        try
        {

            Correcto = Naturaleza.DeleteNaturaleza(HFCodigoSeleccionado.Value);
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
            string DatosFin = "Se elimino la Naturaleza de codigo: " + HFCodigoSeleccionado.Value;
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace Insert de Log eliminar naturaleza
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter DeleteMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            DeleteMaestra.GetMaestros(LogId, FechaIni, UserName, ActLogCod, ModuloLog, DatosIni, DatosFin, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivod e log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "Maestro Naturaleza";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al eliminar Naturaleza " + Error;
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
            
        }

        //this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtNaturaleza.Text = "";
    }
    protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
    {

        FormView f1 = (FormView)DVNaturaleza.FindControl("FVAutoNum");
        CheckBox Ch = (CheckBox)f1.FindControl("CkAuto");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox4");
            TextBox Tx2 = (TextBox)f1.FindControl("TxCons");
            Txt.Text = Tx2.Text.ToString();
        }
        else
        {
            TextBox Txt = (TextBox)DVNaturaleza.FindControl("TextBox4");
            Txt.Text = "";
        }
    }
}

