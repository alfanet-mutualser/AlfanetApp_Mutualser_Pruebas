using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class AlfaNetConsulta_Inventario_Gestion_Inventarios : System.Web.UI.Page
{
    String depCod = string.Empty;
    String admin = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////        
        depCod = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
        if (!Roles.IsUserInRole(User.Identity.Name, "Administrador"))
        {
            admin = "N";
        }
        else
        {
            admin = "S";
        }
        CargarUnidadFrame.Attributes.Add("src", "https://alfanet.fbscgr.gov.co/Inventarios/ConsultaUnidad.aspx?dep=" + depCod + "&user=" + admin);
    }
}
