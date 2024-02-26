using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Admon = Request["Admon"];
        if (Admon == "S")
        {
            Session["Admon"] = "S";
            hidemenu();
        }
        else if (WebPanel2.Visible == false)
        {
            Session["Admon"] = "S";
            hidemenu();
        }
        else
        {
            showmenu();

        }
        Label m_label = (Label)this.LoginViewAlfaNet.FindControl("LblDependencia");
        if (m_label != null)
            m_label.Text = Profile.GetProfile(Profile.UserName).NombreDepUsuario.ToString() + " | ";

        if (SessionTimeOut.IsSessionTimedOut() == true)
        {
            //m_label.Text = "El Tiempo de session ha caducado";
            //Response.Redirect("~", true);
        } 

        // CultureInfo ci = new CultureInfo( CultureInfo.CurrentCulture.Name );
		// ci.DateTimeFormat.ShortDatePattern = "dd'/'MM'/'yyyy";
		// ci.DateTimeFormat.LongTimePattern = "hh':'mm tt";
		// Thread.CurrentThread.CurrentCulture = ci;
		// Thread.CurrentThread.CurrentUICulture = ci;

    }

     public void showmenu()
    {
        this.WebPanel2.Visible = true;
        this.SiteMapPath1.Visible = true;
        this.LoginViewAlfaNet.Visible = true;
        this.btnCerrar.Visible = false;
        this.LnkCerrar.Visible = false;
    }

    public void hidemenu()
    {
        this.WebPanel2.Visible = false;
        this.SiteMapPath1.Visible = false;
        this.LoginViewAlfaNet.Visible = false;
        this.btnCerrar.Visible = false;
        this.LnkCerrar.Visible = false;
    }
}
