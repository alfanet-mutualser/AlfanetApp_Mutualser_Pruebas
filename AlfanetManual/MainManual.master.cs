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

public partial class AlfaNetManual_MainManual : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FramePDF.Attributes["Src"] = "https://alfanet.mutualser.org//AlfaNet//AlfaNetManual//Manual operativo ALFANET.pdf";
        this.FramePDF.DataBind();
        this.FramePDF.Visible = true;
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
