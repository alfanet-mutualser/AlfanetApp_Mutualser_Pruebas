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


public partial class AlfaNetAdministracion_AdminUsuario_migracionusuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DSUsuarioTableAdapters.seguridaTableAdapter TAUSUARIOSALFAWEB = new DSUsuarioTableAdapters.seguridaTableAdapter();
        DSUsuario.seguridaDataTable DTUsuarios = new DSUsuario.seguridaDataTable();
        DTUsuarios = TAUSUARIOSALFAWEB.GetData();

        foreach (DSUsuario.seguridaRow userRow in DTUsuarios.Rows)
        {


            string EMAIL = "alfanet@mutualser.org";

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



        }

    }

   
}
