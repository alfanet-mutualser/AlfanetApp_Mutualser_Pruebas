using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.NetworkInformation;


public partial class _MaestroUsuario : System.Web.UI.Page
{
    string ModuloLog = "Maestro Usuarios";
    string ConsecutivoCodigo = "6";
    DateTime FechaIni = DateTime.Now;
    User item;
    string path = ConfigurationManager.ConnectionStrings["ADConnectionString"].ConnectionString;

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

        this.TxtNombre.Enabled = false;
        this.TxtApellido.Enabled = false;
        this.TxtUserName.Enabled = false;
        this.TxtPassword.Enabled = false;
        this.TxtConfirmPassword.Enabled = false;
        this.TxtEmail.Enabled = false;
        this.AvailableRoles.Enabled = false;
        this.TxtDependencia.Enabled = false;
        this.CheckBox1.Enabled = false;
        this.Label7.Visible = false;
        this.TxtOldPassword.Visible = false;

        if (!IsPostBack)
        {
            AvailableRoles.DataSource = Roles.GetAllRoles();
            AvailableRoles.DataBind();
        }
        else
        {
           
        }
		this.ImgBtnAdd.Visible = false;
    }


    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.LblModo.Visible = true;
        this.LblModo.Text = "ADICIONAR USUARIO...";

        this.TxtNombre.Enabled = true;
        this.TxtApellido.Enabled = true;
        this.TxtUserName.Enabled = true;
        this.TxtPassword.Enabled = true;
        this.TxtConfirmPassword.Enabled = true;
        this.TxtEmail.Enabled = true;
        this.AvailableRoles.Enabled = true;
        this.TxtDependencia.Enabled = true;

        this.ImgBtnAdd.Visible = false;
        this.ImgBtnEdit.Visible = false;
        this.ImgBtnDelete.Visible = false;
        this.ImgBtnAcceptInsert.Visible = true;
        this.ImgBtnCancelInsert.Visible = true;
        this.ImgBtnAcceptEdit.Visible = false;
        this.ImgBtnCancelEdit.Visible = false;

        this.TxtNombre.Text = "";
        this.TxtApellido.Text = "";
        this.TxtUserName.Text = "";
        this.TxtPassword.Text = "";
        this.TxtConfirmPassword.Text = "";
        this.TxtEmail.Text = "";
        this.TxtDependencia.Text = null;
        this.CheckBox1.Enabled = true;
        this.AvailableRoles.ClearSelection();
    }


    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {

        MembershipUser memberuser = Membership.GetUser(this.TxtUserName.Text);      
        PasswordRequired.Enabled = false;
        ConfirmPasswordRequired.Enabled = false;

        this.LblModo.Visible = true;
        this.LblModo.Text = "EDITAR USUARIO...";
        
        this.TxtNombre.Enabled = false;
        this.TxtApellido.Enabled = false;
        //this.TxtUserName.Enabled = true;
        this.TxtPassword.Enabled = false;
        this.TxtConfirmPassword.Enabled = false;
        this.TxtEmail.Enabled = false;
        this.AvailableRoles.Enabled = true;
        this.TxtDependencia.Enabled = true;


        this.ImgBtnAdd.Visible = false;
        this.ImgBtnEdit.Visible = false;
        this.ImgBtnDelete.Visible = false;
        this.ImgBtnAcceptInsert.Visible = false;
        this.ImgBtnCancelInsert.Visible = false;
        this.ImgBtnAcceptEdit.Visible = true;
        this.ImgBtnCancelEdit.Visible = true;
        this.TxtPassword.TextMode = TextBoxMode.Password;
        //this.TxtPassword.Text = null;
        this.TxtConfirmPassword.TextMode = TextBoxMode.Password;
        //this.TxtConfirmPassword.Text = null;
        this.ImgBtnFind.Enabled = false;
        this.CheckBox1.Enabled = true;

       

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Membership.DeleteUser("user4", true);
    }
    protected void ImgBtnAcceptInsert_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "INSERTAR";
        try
        {
            Membership.CreateUser(this.TxtUserName.Text, this.TxtPassword.Text, this.TxtEmail.Text);
            
            // Codigo para almacenar los roles                       
            foreach (ListItem item in AvailableRoles.Items)
            {
                if (item.Selected)
                {
                    if (!Roles.IsUserInRole(this.TxtUserName.Text, item.Text))
                        Roles.AddUserToRole(this.TxtUserName.Text, item.Text);
                }              
            }
            if (!Roles.IsUserInRole(this.TxtUserName.Text, "WorkFlow"))
                Roles.AddUserToRole(this.TxtUserName.Text, "WorkFlow"); 
            // Codigo para almacenar la dependencia asociada
            MembershipUser user = Membership.GetUser(this.TxtUserName.Text);
            user.IsApproved = CheckBox1.Checked;
            Membership.UpdateUser(user);
            ProfileCommon prof = Profile.GetProfile(user.UserName);
            String[] ND = this.TxtDependencia.Text.Split('|');
            prof.CodigoDepUsuario = ND[0].ToString().TrimEnd();
            prof.NombreDepUsuario = ND[1].ToString().TrimStart();
            prof.NombresUsuario = TxtNombre.Text;
            prof.ApellidosUsuario = TxtApellido.Text;
            prof.Save();
                        
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            ObjTaUsuario.Insert(user.ProviderUserKey.ToString(), TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | ")).ToString().Trim(),this.TxtNombre.Text,this.TxtApellido.Text);

            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            Int64 LogId = Convert.ToInt64(LOG);

            string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
            string DatosIni = "Nuevo Usuario";
            string vacio = "";
            Session["NombreRoles"] = vacio;
            foreach (ListItem item2 in AvailableRoles.Items)
            {
                if (item2.Selected)
                {
                    string roles = item2.Text;
                    Session["NombreRoles"] = Session["NombreRoles"].ToString() + " " + roles;
                }
            }
            string DatosFin = "Se registro el usuario: " + TxtUserName.Text + " Nombre:" + TxtNombre.Text + " Apellido: " + TxtApellido.Text + " Email: " + TxtEmail.Text + " Perfiles: " + Session["NombreRoles"].ToString()+ " Dependencia: "+TxtDependencia.Text+" Habilitar: "+CheckBox1.Checked.ToString();
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            BuscarMaestra.GetMaestros(LogId,
                                        FechaIni,
                                        UserName,
                                        ActLogCod,
                                        ModuloLog,
                                        DatosIni,
                                        DatosFin,
                                        FechaFin,
                                        IP,
                                        NombreEquipo,
                                        Navegador
                                        );

            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);


            this.LblModo.Visible = false;
            this.LblModo.Text = "";

            this.TxtNombre.Enabled = false;
            this.TxtApellido.Enabled = false;
            this.TxtUserName.Enabled = false;
            this.TxtPassword.Enabled = false;
            this.TxtConfirmPassword.Enabled = false;
            this.TxtEmail.Enabled = false;
            this.AvailableRoles.Enabled = false;
            this.TxtDependencia.Enabled = false;

            this.ImgBtnAdd.Visible = false;
            this.ImgBtnEdit.Visible = true;
            this.ImgBtnAcceptInsert.Visible = false;
            this.ImgBtnCancelInsert.Visible = false;
            this.ImgBtnAcceptEdit.Visible = false;
            this.ImgBtnCancelEdit.Visible = false;
                        
            this.ImgBtnFind.Enabled = true;
            this.TxtUsuario.Text = null;

        }
        catch (MembershipCreateUserException ex)
        {
            // Find out why CreateUser failed
            switch (ex.StatusCode)
            {

                case MembershipCreateStatus.DuplicateUserName:
                    LblMessageBox.Text = ex.Message;
                    this.MPEMensaje.Show();
                    //this.MPEMensaje.Show();
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    LblMessageBox.Text = ex.Message;
                    this.MPEMensaje.Show();
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    LblMessageBox.Text = ex.Message;
                    this.MPEMensaje.Show();
                    break;
                default:
                    LblMessageBox.Text = ex.Message;
                    this.MPEMensaje.Show();
                    break;
            }

        }
        catch (Exception ex)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Error 1: Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = ex.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += ex.Message.ToString();
            this.MPEMensaje.Show();
        }
    }
    protected void ImgBtnCancelInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.LblModo.Visible = false;
        this.LblModo.Text = "";

        this.TxtNombre.Enabled = false;
        this.TxtApellido.Enabled = false;
        this.TxtUserName.Enabled = false;
        this.TxtPassword.Enabled = false;
        this.TxtConfirmPassword.Enabled = false;
        this.TxtEmail.Enabled = false;
        this.AvailableRoles.Enabled = false;
        this.TxtDependencia.Enabled = false;

        this.ImgBtnAdd.Visible = false;
        this.ImgBtnEdit.Visible = true;
        //this.ImgBtnDelete.Visible = true;
        this.ImgBtnAcceptInsert.Visible = false;
        this.ImgBtnCancelInsert.Visible = false;
        this.ImgBtnAcceptEdit.Visible = false;
        this.ImgBtnCancelEdit.Visible = false;

        this.TxtNombre.Text = "";
        this.TxtApellido.Text = "";
        this.TxtUserName.Text = "";
        this.TxtPassword.Text = "";
        this.TxtConfirmPassword.Text = "";
        this.TxtEmail.Text = "";
        this.ImgBtnFind.Enabled = true;
        this.AvailableRoles.ClearSelection();
        this.TxtDependencia.Text = null;
    }
    protected void ImgBtnAcceptEdit_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod="ACTUALIZAR";
        try
        {
            MembershipUser memberuser = Membership.GetUser(this.TxtUserName.Text);
            memberuser.Email = this.TxtEmail.Text;
            memberuser.IsApproved = CheckBox1.Checked;
            //Membership.UpdateUser(memberuser);

            DirectoryEntry _path = new DirectoryEntry(path);
            _path.AuthenticationType = AuthenticationTypes.Secure;
            _path.Username = "mutualser.org\\ldapalfanet";
            _path.Password = "Mutu4lser2020*";
            string cn = this.TxtUserName.Text;
            DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(&(objectCategory=User)(samaccountname=" + cn + "))";
            search.PropertiesToLoad.Add("samaccountname").ToString();
            search.PropertiesToLoad.Add("habilitar").ToString();
            SearchResult result;
            result = search.FindOne();
            //Linea que se utiliza para actualizar un valor del directorio activo
            DirectoryEntry entryToUpdate = result.GetDirectoryEntry();

            if (CheckBox1.Checked)
            {
                int hab = 1;
                entryToUpdate.Properties["habilitar"].Value = hab;
                entryToUpdate.CommitChanges();
            }
            else if (CheckBox1.Checked == false)
            {
                int hab = 0;
                entryToUpdate.Properties["habilitar"].Value = hab;
                entryToUpdate.CommitChanges();
            }
            //memberuser.UnlockUser();
            ProfileCommon prof = Profile.GetProfile(this.TxtUserName.Text);
            String[] ND = this.TxtDependencia.Text.Split('|');
            string DependenciaCod;
            DependenciaCod = this.TxtDependencia.Text;

            if (DependenciaCod.Contains(" | "))
            {
                DependenciaCod = DependenciaCod.Remove(DependenciaCod.IndexOf(" | "));
                prof.CodigoDepUsuario = DependenciaCod;
            }
            else
            {
                DependenciaCod = null;
                prof.CodigoDepUsuario = ND[0].ToString().TrimEnd();
            }

            prof.NombreDepUsuario = ND[1].ToString().TrimStart();
            prof.NombresUsuario = TxtNombre.Text;
            prof.ApellidosUsuario = TxtApellido.Text;
            prof.Save();

            // Codigo para almacenar los roles            
            foreach (ListItem item in AvailableRoles.Items)
            {
                //Roles.RemoveUserFromRole(memberuser.UserName, item.Value);
               if (CheckBox1.Checked == false)
               {
                   if (item.Selected)
                   {
                       if (Roles.IsUserInRole(this.TxtUserName.Text, item.Text))
                           Roles.RemoveUserFromRole(this.TxtUserName.Text, item.Text);
                   }
               }
                else if (item.Selected)
                {
                    if (!Roles.IsUserInRole(this.TxtUserName.Text, item.Text))
                        Roles.AddUserToRole(this.TxtUserName.Text, item.Text);
                }
                else
                {
                    if (Roles.IsUserInRole(this.TxtUserName.Text, item.Text))
                        Roles.RemoveUserFromRole(this.TxtUserName.Text, item.Text);                
                }
            }
            // Codigo para almacenar la dependencia asociada
            bool PassWord = false;
            if (TxtPassword.Text != "")
            {
                PassWord = memberuser.ChangePassword(this.TxtOldPassword.Text, this.TxtPassword.Text);
            }

            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter Usuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            String NA = TxtNombre.Text;
            String AP = TxtApellido.Text;
            string concat = TxtNombre.Text.TrimEnd() + ND[1].TrimStart() + prof.CodigoDepUsuario + TxtApellido.Text;
            Object UserId = Usuario.GetUsuarioByNombreApellido(NA, AP);
            //Si no Encuentra El usuario
            DSUsuarioTableAdapters.aspnet_Profile_Get_UserIdTableAdapter objID = new DSUsuarioTableAdapters.aspnet_Profile_Get_UserIdTableAdapter();
            Object con = objID.Get_UserId(concat);

            if (UserId != null)
            {
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                ObjTaUsuario.UsuariosByUpdateUsuarios(con.ToString(), TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | ")).ToString().Trim(), this.TxtNombre.Text, this.TxtApellido.Text);
            }
            else
            {
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                ObjTaUsuario.Insert(con.ToString(), TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | ")).ToString().Trim(), this.TxtNombre.Text, this.TxtApellido.Text);
            }

            if (PassWord == true)
            {
                this.LblMessageBox.Text = "Registro y Contraseña Actualizados";
                this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "Registro Actualizado";
                this.MPEMensaje.Show();
            }

            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            Int64 LogId = Convert.ToInt64(LOG);

            string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
            string DatosIni = Session["InfoUsuario"].ToString();
            string vacio = "";
            Session["NombreRoles"] = vacio;
            foreach (ListItem item2 in AvailableRoles.Items)
            {
                if (item2.Selected)
                {
                    string roles = item2.Text;
                    Session["NombreRoles"] = Session["NombreRoles"].ToString() + " " + roles;
                }
            }
            string DatosFin = "Se Actualizo el usuario: " + TxtUserName.Text + " Nombre:" + TxtNombre.Text + " Apellido: " + TxtApellido.Text + " Email: " + TxtEmail.Text + " Perfiles: " + Session["NombreRoles"].ToString() + " Dependencia: " + TxtDependencia.Text + " Habilitar: " + CheckBox1.Checked.ToString();
            DateTime FechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter UpdateMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
            UpdateMaestra.GetMaestros(LogId,
                                        FechaIni,
                                        UserName,
                                        ActLogCod,
                                        ModuloLog,
                                        DatosIni,
                                        DatosFin,
                                        FechaFin,
                                        IP,
                                        NombreEquipo,
                                        Navegador
                                        );

            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

            this.LblModo.Visible = false;
            this.LblModo.Text = "";
            this.TxtNombre.Enabled = false;
            this.TxtApellido.Enabled = false;
            this.TxtUserName.Enabled = false;
            this.TxtPassword.Enabled = false;
            this.TxtConfirmPassword.Enabled = false;
            this.TxtEmail.Enabled = false;
            this.AvailableRoles.Enabled = false;
            this.TxtDependencia.Enabled = false;

            this.ImgBtnAdd.Visible = false;
            this.ImgBtnEdit.Visible = true;
            this.ImgBtnAcceptInsert.Visible = false;
            this.ImgBtnCancelInsert.Visible = false;
            this.ImgBtnAcceptEdit.Visible = false;
            this.ImgBtnCancelEdit.Visible = false;
            this.ImgBtnFind.Enabled = true;
            this.TxtUsuario.Text = null;
        }
        catch (Exception ex)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Error 2: Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = ex.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += ex.Message.ToString();
            this.MPEMensaje.Show();
        }
    }
    protected void ImgBtnCancelEdit_Click(object sender, ImageClickEventArgs e)
    {
        this.LblModo.Visible = false;
        this.LblModo.Text = "";

        this.TxtNombre.Enabled = false;
        this.TxtApellido.Enabled = false;
        this.TxtUserName.Enabled = false;
        this.TxtPassword.Enabled = false;
        this.TxtConfirmPassword.Enabled = false;
        this.TxtEmail.Enabled = false;
        this.AvailableRoles.Enabled = false;
        this.TxtDependencia.Enabled = false;

        this.ImgBtnAdd.Visible = false;
        this.ImgBtnEdit.Visible = true;
        //this.ImgBtnDelete.Visible = true;
        this.ImgBtnAcceptInsert.Visible = false;
        this.ImgBtnCancelInsert.Visible = false;
        this.ImgBtnAcceptEdit.Visible = false;
        this.ImgBtnCancelEdit.Visible = false;

        this.TxtNombre.Text = "";
        this.TxtApellido.Text = "";
        this.TxtUserName.Text = "";
        this.TxtPassword.Text = "";
        this.TxtConfirmPassword.Text = "";
        this.TxtEmail.Text = "";
        this.ImgBtnFind.Enabled = true;
        this.AvailableRoles.ClearSelection();
        this.TxtDependencia.Text = null;
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
		this.AvailableRoles.ClearSelection();
        string ActLogCod = "BUSCAR";
        try
        {
			
            MembershipUser memberuser = null;
            DirectoryEntry _path = new DirectoryEntry(path);
            _path.AuthenticationType = AuthenticationTypes.Secure;
            _path.Username = "mutualser.org\\ldapalfanet";
            _path.Password = "Mutu4lser2020*";

            if (RadBtnLstFindby.SelectedValue == "3")
            {
                this.TxtNombre.Text = "";
                this.TxtApellido.Text = "";
                this.TxtUserName.Text = "";
                this.TxtEmail.Text = "";

                this.TxtUserName.Text = Profile.GetProfile(this.TxtUsuario.Text).UserName;
                string cn = this.TxtUserName.Text.ToLowerInvariant();
                DirectorySearcher search = new DirectorySearcher(_path);
                search.Filter = "(&(objectCategory=User)(sAMAccountName=" + cn + "))";
                search.PropertiesToLoad.Add("givenName").ToString();
                search.PropertiesToLoad.Add("sn").ToString();
                search.PropertiesToLoad.Add("mail").ToString();
                SearchResult result;
                result = search.FindOne();
                string propName = "givenName";
                string propname2 = "sn";
                string propmail = "mail";	

				DirectoryEntry entryToUpdate = result.GetDirectoryEntry();
				var habil = 0;
				habil = Convert.ToInt32(entryToUpdate.Properties["habilitar"].Value);

                ResultPropertyValueCollection valColl = result.Properties[propName];
                try  { this.TxtNombre.Text = valColl[0].ToString(); }
                catch { }

                ResultPropertyValueCollection apell = result.Properties[propname2];
                try  { this.TxtApellido.Text = apell[0].ToString(); }
                catch { }
                ResultPropertyValueCollection mail = result.Properties[propmail];
                try { this.TxtEmail.Text = mail[0].ToString(); }
                catch { }

                this.TxtDependencia.Text = Profile.GetProfile(this.TxtUsuario.Text).CodigoDepUsuario + " | " + Profile.GetProfile(this.TxtUsuario.Text).NombreDepUsuario.ToString();

                memberuser = Membership.GetUser(Profile.GetProfile(TxtUsuario.Text).UserName);
                //Si no Encuentra El usuario//
                if (memberuser != null)
                {
                    if (memberuser.IsLockedOut == true)
                    {
                        memberuser.UnlockUser();
                        memberuser.IsApproved = false;
                        Membership.UpdateUser(memberuser);
                    }
                    item = new User();
                    ProfileCommon PRO = Profile.GetProfile(memberuser.UserName);
                    this.TxtEmail.Text = memberuser.Email;
                }
                int i;
                if (memberuser != null)
                {
                    if (habil.Equals(0))
                        {
                            this.CheckBox1.Checked = false;
							int hab = 0;
							entryToUpdate.Properties["habilitar"].Value = hab;
							entryToUpdate.CommitChanges();
                    }
                    else
                    {
                        this.CheckBox1.Checked = true;
                    }
                    String[] Rol = Roles.GetRolesForUser(memberuser.UserName);

                    foreach (ListItem item in AvailableRoles.Items)
                    {
                        for (i = 0; i < Rol.Length; i++)
                        {
                            if (item.Value == Rol[i])
                            {
                                item.Selected = true;

                            }
                        }
                    }
                }
                else
                {
                    this.LblMessageBox.Text = "El Usuario No Existe o Fue Modificado";
                    this.MPEMensaje.Show();
                    return;
                }
                string vacio = "";
                Session["LOSRoles"] = vacio;
                foreach (ListItem item2 in AvailableRoles.Items)
                {
                    if (item2.Selected)
                    {
                        string roles = item2.Text;
                        Session["LOSRoles"] = Session["LOSRoles"].ToString() + " " + roles;
                    }
                }

                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                Int64 LogId = Convert.ToInt64(LOG);

                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                string DatosIni = "Buscar por UserName";
                string DatosFin = "Se busco el usuario: " + TxtUsuario.Text + " Nombre:" + TxtNombre.Text + " Apellido: " + TxtApellido.Text + " UserName: " + TxtUserName.Text + " Email: " + TxtEmail.Text + " Perfiles: " + Session["LOSRoles"].ToString() + " Dependencia: " + TxtDependencia.Text + " Habilitar: " + CheckBox1.Checked.ToString();
                Session["InfoUsuario"] = DatosFin;
                DateTime FechaFin = DateTime.Now;
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                Session["Navega"] = Navegador;
                DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                BuscarMaestra.GetMaestros(LogId,
                                            FechaIni,
                                            UserName,
                                            ActLogCod,
                                            ModuloLog,
                                            DatosIni,
                                            DatosFin,
                                            FechaFin,
                                            IP,
                                            NombreEquipo,
                                            Navegador
                                            );

                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);


            }
            else if (RadBtnLstFindby.SelectedValue == "1")
            {
                this.TxtNombre.Text = "";
                this.TxtApellido.Text = "";
                this.TxtUserName.Text = "";
                this.TxtEmail.Text = "";

                if (TxtUsuario.Text != null)
                {

                    string cn = this.TxtUsuario.Text;
                    DirectorySearcher search = new DirectorySearcher(_path);
                    search.Filter = "(&(objectCategory=User)(givenName=" + cn + "))";
                    search.PropertiesToLoad.Add("givenName").ToString();
                    search.PropertiesToLoad.Add("sn").ToString();
                    search.PropertiesToLoad.Add("samaccountname").ToString();
                    search.PropertiesToLoad.Add("mail").ToString();
                    SearchResult result;
                    result = search.FindOne();
                    string propName = "givenName";
                    string propname2 = "sn";
                    string propname3 = "samaccountname";
                    string propmail = "mail";
                    ResultPropertyValueCollection valColl = result.Properties[propName];
                    try   { this.TxtNombre.Text = valColl[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection apell = result.Properties[propname2];
                    try   { this.TxtApellido.Text = apell[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection usernam = result.Properties[propname3];
                    try   { this.TxtUserName.Text = usernam[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection mail = result.Properties[propmail];
                    try { this.TxtEmail.Text = mail[0].ToString(); }
                    catch { }

                    this.TxtUserName.Text = Profile.GetProfile(this.TxtUserName.Text).UserName;
                    memberuser = Membership.GetUser(Profile.GetProfile(TxtUserName.Text).UserName);
                    ProfileCommon PRO = Profile.GetProfile(memberuser.UserName);

                    this.TxtDependencia.Text = Profile.GetProfile(memberuser.UserName).CodigoDepUsuario + " | " + Profile.GetProfile(memberuser.UserName).NombreDepUsuario;
                    this.TxtEmail.Text = memberuser.Email;

                    int i;
                    if (memberuser != null)
                    {
                    DirectoryEntry entryToUpdate = result.GetDirectoryEntry();
					var habil = 0;
					habil = Convert.ToInt32(entryToUpdate.Properties["habilitar"].Value);
                    if (habil.Equals(0))
                        {
                            this.CheckBox1.Checked = false;
							int hab = 0;
							entryToUpdate.Properties["habilitar"].Value = hab;
							entryToUpdate.CommitChanges();
                    }
                    else
                    {
                        this.CheckBox1.Checked = true;
                    }
                        String[] Rol = Roles.GetRolesForUser(memberuser.UserName);

                        foreach (ListItem item in AvailableRoles.Items)
                        {
                            for (i = 0; i < Rol.Length; i++)
                            {
                                if (item.Value == Rol[i])
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.LblMessageBox.Text = "El Usuario No Existe o Fue Modificado";
                        this.MPEMensaje.Show();
                        return;
                    }
                    string vacio = "";
                    Session["LOSRoles"] = vacio;
                    foreach (ListItem item2 in AvailableRoles.Items)
                    {
                        if (item2.Selected)
                        {
                            string roles = item2.Text;
                            Session["LOSRoles"] = Session["LOSRoles"].ToString() + " " + roles;
                        }
                    }

                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    Int64 LogId = Convert.ToInt64(LOG);

                    string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    string DatosIni = "Buscar por Nombre";
                    string DatosFin = "Se busco el usuario: " + TxtUsuario.Text + " Nombre:" + TxtNombre.Text + " Apellido: " + TxtApellido.Text + " UserName: " + TxtUserName.Text + " Email: " + TxtEmail.Text + " Perfiles: " + Session["LOSRoles"].ToString() + " Dependencia: " + TxtDependencia.Text + " Habilitar: " + CheckBox1.Checked.ToString();
                    Session["InfoUsuario"] = DatosFin;
                    DateTime FechaFin = DateTime.Now;
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    Session["Navega"] = Navegador;
                    DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                    BuscarMaestra.GetMaestros(LogId,
                                                FechaIni,
                                                UserName,
                                                ActLogCod,
                                                ModuloLog,
                                                DatosIni,
                                                DatosFin,
                                                FechaFin,
                                                IP,
                                                NombreEquipo,
                                                Navegador
                                                );

                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                }
               
            }

            else if (RadBtnLstFindby.SelectedValue == "2")
            {
                this.TxtNombre.Text = "";
                this.TxtApellido.Text = "";
                this.TxtUserName.Text = "";
                this.TxtEmail.Text = "";
                //this.TxtDependencia.Text = "";
                if (TxtUsuario.Text != null)
                {
                    string cn = this.TxtUsuario.Text;
                    DirectorySearcher search = new DirectorySearcher(_path);
                    search.Filter = "(&(objectCategory=User)(sn=" + cn + "))";
                    search.PropertiesToLoad.Add("givenName").ToString();
                    search.PropertiesToLoad.Add("sn").ToString();
                    search.PropertiesToLoad.Add("samaccountname").ToString();
                    search.PropertiesToLoad.Add("mail").ToString();
                    SearchResult result;
                    result = search.FindOne();
                    string propName = "givenName";
                    string propname2 = "sn";
                    string propname3 = "samaccountname";
                    string propmail = "mail";
                    ResultPropertyValueCollection valColl = result.Properties[propName];
                    try { this.TxtNombre.Text = valColl[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection apell = result.Properties[propname2];
                    try { this.TxtApellido.Text = apell[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection usernam = result.Properties[propname3];
                    try { this.TxtUserName.Text = usernam[0].ToString(); }
                    catch { }
                    ResultPropertyValueCollection mail = result.Properties[propmail];
                    try { this.TxtEmail.Text = mail[0].ToString(); }
                    catch { }

                    this.TxtUserName.Text = Profile.GetProfile(this.TxtUserName.Text).UserName;
                    memberuser = Membership.GetUser(Profile.GetProfile(TxtUserName.Text).UserName);
                    ProfileCommon PRO = Profile.GetProfile(memberuser.UserName);

                    this.TxtDependencia.Text = Profile.GetProfile(memberuser.UserName).CodigoDepUsuario + " | " + Profile.GetProfile(memberuser.UserName).NombreDepUsuario;
                    this.TxtEmail.Text = memberuser.Email;

                    int i;
                    if (memberuser != null)
                    {
                    DirectoryEntry entryToUpdate = result.GetDirectoryEntry();
					var habil = 0;
					habil = Convert.ToInt32(entryToUpdate.Properties["habilitar"].Value);
                    if (habil.Equals(0))
                        {
                            this.CheckBox1.Checked = false;
							int hab = 0;
							entryToUpdate.Properties["habilitar"].Value = hab;
							entryToUpdate.CommitChanges();
                    }
                    else
                    {
                        this.CheckBox1.Checked = true;
                    }
                        String[] Rol = Roles.GetRolesForUser(memberuser.UserName);

                        foreach (ListItem item in AvailableRoles.Items)
                        {
                            for (i = 0; i < Rol.Length; i++)
                            {
                                if (item.Value == Rol[i])
                                {
                                    item.Selected = true;

                                }
                            }
                        }
                    }
                    else
                    {
                        this.LblMessageBox.Text = "El Usuario Solicitado No Existe!!!";
                        this.MPEMensaje.Show();
                        return;
                    }

                    string vacio = "";
                    Session["LOSRoles"] = vacio;
                    foreach (ListItem item2 in AvailableRoles.Items)
                    {
                        if (item2.Selected)
                        {
                            string roles = item2.Text;
                            Session["LOSRoles"] = Session["LOSRoles"].ToString() + " " + roles;
                        }
                    }

                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    Int64 LogId = Convert.ToInt64(LOG);

                    string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    string DatosIni = "Buscar por Apellido";
                    string DatosFin = "Se busco el usuario: " + TxtUsuario.Text + " Nombre:" + TxtNombre.Text + " Apellido: " + TxtApellido.Text + " UserName: " + TxtUserName.Text + " Email: " + TxtEmail.Text + " Perfiles: " + Session["LOSRoles"].ToString() + " Dependencia: " + TxtDependencia.Text + " Habilitar: " + CheckBox1.Checked.ToString();
                    Session["InfoUsuario"] = DatosFin;
                    DateTime FechaFin = DateTime.Now;
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    Session["Navega"] = Navegador;
                    DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter BuscarMaestra = new DSLogAlfaNetTableAdapters.LogAlfaNetTablasMaestrasTableAdapter();
                    BuscarMaestra.GetMaestros(LogId,
                                                FechaIni,
                                                UserName,
                                                ActLogCod,
                                                ModuloLog,
                                                DatosIni,
                                                DatosFin,
                                                FechaFin,
                                                IP,
                                                NombreEquipo,
                                                Navegador
                                                );

                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                }
            }  
        }
        catch (Exception ex)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Error 3: Ocurrio un problema al tratar de Buscar el registro. " + ex.ToString();
            Exception inner = ex.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            //this.LblMessageBox.Text += ex.Message.ToString();
            this.MPEMensaje.Show();
        }
    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (RadBtnLstFindby.SelectedValue == "1")
        {
            this.ACEaspnet_Users.ServiceMethod = "GetADUsers";
            this.TxtUsuario.Text = "";
        }
        else if (RadBtnLstFindby.SelectedValue == "2")
        {
            this.ACEaspnet_Users.ServiceMethod = "GetADApellidos";
            this.TxtUsuario.Text = "";
        }
        else if (RadBtnLstFindby.SelectedValue == "3")
        {
            this.ACEaspnet_Users.ServiceMethod = "GetADUsername";
            this.TxtUsuario.Text = "";
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DSUsuarioTableAdapters.usuarios_alfawebTableAdapter TAUSUARIOSALFAWEB = new DSUsuarioTableAdapters.usuarios_alfawebTableAdapter();
        DSUsuario.usuarios_alfawebDataTable DTUsuarios = new DSUsuario.usuarios_alfawebDataTable();
        DTUsuarios = TAUSUARIOSALFAWEB.GetData();

        foreach (DSUsuario.usuarios_alfawebRow userRow in DTUsuarios.Rows)
        {


            string EMAIL = userRow.Mail;

                Membership.CreateUser(userRow.usuario, userRow.usuario, EMAIL);

                // Codigo para almacenar los roles
                if (userRow.nivel == 0)
                //foreach (ListItem item in AvailableRoles.Items)
                {
                //    if (item.Selected)
                //    {
                    if (!Roles.IsUserInRole(userRow.usuario, "Administrador"))
                        Roles.AddUserToRole(userRow.usuario, "Administrador");
                    //}
                    //else
                    //{
                    //    if (Roles.IsUserInRole(this.TxtUserName.Text, item.Text))
                    //        Roles.RemoveUserFromRole(this.TxtUserName.Text, item.Text);
                    //}
                }
                else if (userRow.nivel == 2)
                {
                    if (!Roles.IsUserInRole(userRow.usuario, "WorKFlow"))
                        Roles.AddUserToRole(userRow.usuario, "WorKFlow");
                }
                else if (userRow.nivel == 4)
                {
                    if (!Roles.IsUserInRole(userRow.usuario, "WorKFlow"))
                        Roles.AddUserToRole(userRow.usuario, "WorKFlow");
                    if (!Roles.IsUserInRole(userRow.usuario, "Consultas"))
                        Roles.AddUserToRole(userRow.usuario, "Consultas");
                }
                else if (userRow.nivel == 6)
                {
                    if (!Roles.IsUserInRole(userRow.usuario, "Documentos"))
                        Roles.AddUserToRole(userRow.usuario, "Documentos");
                    if (!Roles.IsUserInRole(userRow.usuario, "Consultas"))
                        Roles.AddUserToRole(userRow.usuario, "Consultas");
                }


                // Codigo para almacenar la dependencia asociada
                MembershipUser user = Membership.GetUser(userRow.usuario);
                user.IsApproved = true;
                Membership.UpdateUser(user);
                ProfileCommon prof = Profile.GetProfile(user.UserName);
                // String[] ND = this.TxtDependencia.Text.Split('|');
                prof.CodigoDepUsuario = userRow.codigod;
                prof.NombreDepUsuario = "";
                prof.NombresUsuario = userRow.nombres;
                prof.ApellidosUsuario = userRow.apellidos;
                prof.Save();
                
                //this.LblMessageBox.Text = "Registro Adicionado";
                //this.MPEMensaje.Show();
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                ObjTaUsuario.Insert(user.ProviderUserKey.ToString(), userRow.codigod, userRow.nombres,userRow.apellidos);
         

        }

    }
}