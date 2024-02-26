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

public partial class WFProceso : System.Web.UI.Page
{



    protected void ImgBtnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender1.Show();
    }
    protected void ImgBtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender2.Show();
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}
