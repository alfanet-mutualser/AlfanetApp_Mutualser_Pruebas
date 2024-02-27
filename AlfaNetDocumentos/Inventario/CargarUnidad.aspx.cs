using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class AlfaNetDocumentos_Inventario_CargarUnidad : System.Web.UI.Page
{
    String depCod = string.Empty;
    string urlCargarUnidad = ConfigurationManager.AppSettings["UrlCargarUnidad"];
    protected void Page_Load(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////        
        depCod = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
        CargarUnidadFrame.Attributes.Add("src", urlCargarUnidad + depCod);
    }
}
