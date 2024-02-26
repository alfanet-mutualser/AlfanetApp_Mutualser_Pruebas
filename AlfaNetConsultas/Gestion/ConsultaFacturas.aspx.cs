using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AlfaNetConsultas_Gestion_ConsultaFacturas : System.Web.UI.Page
{    
    String depCod = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////        
        depCod = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
        facturasFrame.Attributes.Add("src", "http:/localhost/RadicacionMasivaSitePruebas/RadicacionMasiva/ConsultaRadicacionMasiva.aspx?dep=" + depCod);
    }    
}
