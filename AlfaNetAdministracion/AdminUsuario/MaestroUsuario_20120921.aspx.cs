using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MaestroUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

        this.TxtNombre.Enabled = true;
        this.TxtApellido.Enabled = true;
        //this.TxtUserName.Enabled = true;
        this.TxtPassword.Enabled = true;
        this.TxtConfirmPassword.Enabled = true;
        this.TxtEmail.Enabled = true;
        this.AvailableRoles.Enabled = true;
        this.TxtDependencia.Enabled = true;

       // this.Label7.Visible = true;
        this.TxtOldPassword.Text = memberuser.GetPassword();
       // this.TxtOldPassword.Visible = true;

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

      /*  this.Label7.Visible = true;
        this.TxtOldPassword.Text = TxtPassword.Text;
        this.TxtOldPassword.Visible = true;*/
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Membership.DeleteUser("user4", true);
    }
    protected void ImgBtnAcceptInsert_Click(object sender, ImageClickEventArgs e)
    {
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
            ObjTaUsuario.Insert(user.ProviderUserKey.ToString(), TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | ")).ToString().Trim(),this.TxtNombre.Text.Trim(),this.TxtApellido.Text.Trim());

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

            this.ImgBtnAdd.Visible = true;
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
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
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

        this.ImgBtnAdd.Visible = true;
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
         try
        {
             MembershipUser memberuser = Membership.GetUser(this.TxtUserName.Text);
             memberuser.Email = this.TxtEmail.Text;
             memberuser.IsApproved = CheckBox1.Checked;
             Membership.UpdateUser(memberuser);
             
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
             prof.NombresUsuario =  TxtNombre.Text;
             prof.ApellidosUsuario = TxtApellido.Text;
             prof.Save();
                         
            // Codigo para almacenar los roles            
            foreach (ListItem item in AvailableRoles.Items)
            {
                //Roles.RemoveUserFromRole(memberuser.UserName, item.Value);
                if (item.Selected)
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
              bool PassWord= false;
            if (TxtPassword.Text != "")
            {
                PassWord = memberuser.ChangePassword(this.TxtOldPassword.Text, this.TxtPassword.Text);
            }

            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            ObjTaUsuario.UsuariosByUpdateUsuarios(memberuser.ProviderUserKey.ToString(), TxtDependencia.Text.Remove(TxtDependencia.Text.IndexOf(" | ")).ToString().Trim(), this.TxtNombre.Text.Trim(), this.TxtApellido.Text.Trim());

            if (PassWord== true)
            {
                this.LblMessageBox.Text = "Registro y Contraseña Actualizados";
                this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "Registro Actualizado";
                this.MPEMensaje.Show();
            }
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

            this.ImgBtnAdd.Visible = true;
            this.ImgBtnEdit.Visible = true;
            //this.ImgBtnDelete.Visible = true;
            this.ImgBtnAcceptInsert.Visible = false;
            this.ImgBtnCancelInsert.Visible = false;
            this.ImgBtnAcceptEdit.Visible = false;
            this.ImgBtnCancelEdit.Visible = false;

            //this.TxtNombre.Text = "";
            //this.TxtApellido.Text = "";
            //this.TxtUserName.Text = "";
            //this.TxtPassword.Text = "";
            //this.TxtConfirmPassword.Text = "";
            //this.TxtEmail.Text = "";
            this.ImgBtnFind.Enabled = true;
            //this.AvailableRoles.ClearSelection();
            //this.TxtDependencia.Text = null;
            this.TxtUsuario.Text = null;
            
    }
    catch (Exception ex)
    {
        //Display a user-friendly message
        this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
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

        this.ImgBtnAdd.Visible = true;
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

        try
        {

            MembershipUser memberuser = null;

            if (RadBtnLstFindby.SelectedValue == "3")
            {
                this.TxtUserName.Text = Profile.GetProfile(this.TxtUsuario.Text).UserName;
                //this.HFUserName.Value = Profile.GetProfile(this.TxtUsuario.Text).UserName;
                this.TxtNombre.Text = Profile.GetProfile(this.TxtUsuario.Text).NombresUsuario;
                this.TxtApellido.Text = Profile.GetProfile(this.TxtUsuario.Text).ApellidosUsuario;
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
                    //this.TxtPassword.Text = memberuser.GetPassword();
                    //this.TxtPassword.TextMode = TextBoxMode.SingleLine;
                    this.TxtPassword.TextMode = TextBoxMode.Password;
                    this.TxtPassword.Text = memberuser.GetPassword();



                    this.TxtOldPassword.TextMode = TextBoxMode.SingleLine;
                    this.TxtOldPassword.Text = memberuser.GetPassword();
                    //this.TxtPassword.Text = "*********";


                    //this.TxtConfirmPassword.TextMode = TextBoxMode.SingleLine;
                    this.TxtConfirmPassword.TextMode = TextBoxMode.Password;
                    this.TxtConfirmPassword.Text = memberuser.GetPassword();

                    //this.TxtConfirmPassword.Text = "**********";
                    this.TxtEmail.Text = memberuser.Email;

                }
                else
                {
                    this.LblMessageBox.Text = "El Usuario No Existe o Fue Modificado";
                    this.MPEMensaje.Show();
                    return;
                }
            }
            else if (RadBtnLstFindby.SelectedValue == "1")
            {
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter Usuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                if (TxtUsuario.Text != null)
                {
                    if (TxtUsuario.Text.Contains(" | "))
                    {

                        String[] NA = TxtUsuario.Text.Split('|');
                        Object UserId = Usuario.GetUsuarioByNombreApellido(NA[0].ToString().TrimEnd(), NA[1].ToString().TrimStart());



                        //Si no Encuentra El usuario//
                        if (UserId != null)
                        {
                            string U = Convert.ToString(UserId);
                            System.Guid UId = new Guid(U);
                            memberuser = Membership.GetUser(UId);
                            if (memberuser.IsLockedOut == true)
                            {
                                memberuser.UnlockUser();
                                memberuser.IsApproved = false;
                                Membership.UpdateUser(memberuser);
                            }
                            this.TxtPassword.Text = memberuser.GetPassword();
                            this.TxtPassword.TextMode = TextBoxMode.Password;
                            this.TxtOldPassword.TextMode = TextBoxMode.SingleLine;
                            this.TxtOldPassword.Text = memberuser.GetPassword();
                            //this.TxtPassword.Text = "**********";
                            this.TxtConfirmPassword.Text = memberuser.GetPassword();
                            this.TxtConfirmPassword.TextMode = TextBoxMode.Password;
                            //this.TxtConfirmPassword.Text = "**********";
                            this.TxtUserName.Text = Profile.GetProfile(memberuser.UserName).UserName;
                            //this.HFUserName.Value= Profile.GetProfile(memberuser.UserName).UserName;
                            this.TxtNombre.Text = Profile.GetProfile(memberuser.UserName).NombresUsuario;
                            this.TxtApellido.Text = Profile.GetProfile(memberuser.UserName).ApellidosUsuario;
                            ProfileCommon PRO = Profile.GetProfile(memberuser.UserName);
                            this.TxtDependencia.Text = Profile.GetProfile(memberuser.UserName).CodigoDepUsuario + " | " + Profile.GetProfile(memberuser.UserName).NombreDepUsuario;
                            this.TxtEmail.Text = memberuser.Email;
                        }
                        else
                        {
                            this.LblMessageBox.Text = "El Usuario No Existe o Fue Modificado";
                            this.MPEMensaje.Show();
                            return;
                        }


                    }
                }

            }
            else if (RadBtnLstFindby.SelectedValue == "2")
            {
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter Usuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                if (TxtUsuario.Text != null)
                {
                    if (TxtUsuario.Text.Contains(" | "))
                    {
                        String[] NA = TxtUsuario.Text.Split('|');
                        Object UserId = Usuario.GetUsuarioByNombreApellido(NA[1].ToString().TrimStart(), NA[0].ToString().TrimEnd());



                        //Si no Encuentra El usuario//
                        if (UserId != null)
                        {
                            string U = Convert.ToString(UserId);
                            System.Guid UId = new Guid(U);
                            memberuser = Membership.GetUser(UId);
                            if (memberuser.IsLockedOut == true)
                            {
                                memberuser.UnlockUser();
                                memberuser.IsApproved = false;
                                Membership.UpdateUser(memberuser);
                            }

                            this.TxtPassword.Text = memberuser.GetPassword();
                            this.TxtPassword.TextMode = TextBoxMode.Password;
                            this.TxtOldPassword.TextMode = TextBoxMode.SingleLine;
                            this.TxtOldPassword.Text = memberuser.GetPassword();
                            //this.TxtPassword.Text = "**********";
                            this.TxtConfirmPassword.Text = memberuser.GetPassword();
                            this.TxtConfirmPassword.TextMode = TextBoxMode.Password;
                            //this.TxtConfirmPassword.Text = "**********";
                            this.TxtUserName.Text = Profile.GetProfile(memberuser.UserName).UserName;
                            //this.HFUserName.Value= Profile.GetProfile(memberuser.UserName).UserName;
                            this.TxtNombre.Text = Profile.GetProfile(memberuser.UserName).NombresUsuario;
                            this.TxtApellido.Text = Profile.GetProfile(memberuser.UserName).ApellidosUsuario;
                            this.TxtDependencia.Text = Profile.GetProfile(memberuser.UserName).CodigoDepUsuario + " | " + Profile.GetProfile(memberuser.UserName).NombreDepUsuario;
                            this.TxtEmail.Text = memberuser.Email;
                            //this.TxtEmail.Text = usuari[Profile.GetProfile(memberuser.UserName).UserName].Email;
                        }
                        else
                        {
                            this.LblMessageBox.Text = "El Usuario No Existe o Fue Modificado";
                            this.MPEMensaje.Show();
                            return;
                        }
                    }
                }
            }
            if (memberuser != null)
            {
                this.CheckBox1.Checked = memberuser.IsApproved;
                String[] Rol = Roles.GetRolesForUser(memberuser.UserName);
                //int i= 0;
                foreach (ListItem item in AvailableRoles.Items)
                {
                    for (int i = 0; i < Rol.Length; i++)
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

        }
        catch (Exception ex)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de Buscar el registro. ";
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
            this.ACEaspnet_Users.ServiceMethod = "GetUsuariosByNombres";
            this.TxtUsuario.Text = "";
        }
        else if (RadBtnLstFindby.SelectedValue == "2")
        {
            this.ACEaspnet_Users.ServiceMethod = "GetUsuariosByApellidos";
            this.TxtUsuario.Text = "";
        }
        else if (RadBtnLstFindby.SelectedValue == "3")
        {
            this.ACEaspnet_Users.ServiceMethod = "Getaspnet_UsersByUserName";
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