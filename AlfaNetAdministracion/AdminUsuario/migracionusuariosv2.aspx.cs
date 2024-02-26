using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


public partial class AlfaNetAdministracion_AdminUsuario_migracionusuariosv2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        rutinas r1 = new rutinas();
        DataTable d1 = r1.rtn_creartabla("select * from dbo.MutualUsuarios2");
      

        foreach (DataRow rw in d1.Rows)
        {

            /*Extraccion de los datos*/
            string User_1 = rw["Usuario"].ToString().ToLower();
            string Name_1 = rw["Nombres"].ToString().ToUpper();
            string SName_1 = rw["Apellidos"].ToString().ToUpper();
           
            string Depend_1 = rw["Dependencia"].ToString();
            string Estado_1 = rw["Estado"].ToString();

            string Nomdep_1 = rw[9].ToString();

            /*se modifica la informacion del correo si este no existe en la tabla*/
            string Email_1 = "alfanetpruebas@gmail.com";
            if ((rw["email"].ToString().Length > 0) && (rw["email"].ToString() != null))
                Email_1 = rw["email"].ToString();
          
            
            /*estraccion de los perfiles*/
            String[] Perfiles_1 = rw["PERFIL"].ToString().Split(',');


            if (Membership.GetUser(User_1) == null)
            {
                //Creacion de perfiles
                Membership.CreateUser(User_1, User_1, Email_1);

                foreach (String _est in Perfiles_1)
                {
                    if (_est.ToLower() == "workflow")
                        Roles.AddUserToRole(User_1, "WorKFlow");
                    if (_est.ToLower() == "consultas")
                        Roles.AddUserToRole(User_1, "Consultas");
                    if (_est.ToLower() == "documentos")
                        Roles.AddUserToRole(User_1, "Documentos");
                    if (_est.ToLower() == " imagenes")
                        Roles.AddUserToRole(User_1, "Imagenes");
                    if (_est.ToLower() == " reportes")
                        Roles.AddUserToRole(User_1, "Reportes");

                }

                // Codigo para almacenar la dependencia asociada
                MembershipUser user = Membership.GetUser(User_1);

                if (Estado_1.Trim() == "A")
                    user.IsApproved = true;
                else
                    user.IsApproved = false;

                Membership.UpdateUser(user);
                ProfileCommon prof = Profile.GetProfile(User_1);
                prof.CodigoDepUsuario = Depend_1;
                prof.NombreDepUsuario = Nomdep_1;
                prof.NombresUsuario = Name_1;
                prof.ApellidosUsuario = SName_1;
                prof.Save();

                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                ObjTaUsuario.Insert(user.ProviderUserKey.ToString(), Depend_1, Name_1, SName_1);

            }

              /*
            //Creacion de perfiles
            
            string EMAIL = "soporte.archivar@gmail.com";

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
            //String[] ND = this.TxtDependencia.Text.Split('|');
            prof.CodigoDepUsuario = userRow.codigod;
            prof.NombreDepUsuario = "";
            prof.NombresUsuario = userRow.nombres;
            prof.ApellidosUsuario = userRow.apellidos;
            prof.Save();

            //this.LblMessageBox.Text = "Registro Adicionado";
            //this.MPEMensaje.Show();
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuario = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            ObjTaUsuario.Insert(user.ProviderUserKey.ToString(), userRow.codigod, userRow.nombres, userRow.apellidos);

            */

        }

    }



    

   
}
