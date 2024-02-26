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

public partial class LoginIniciar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DSInfoTableAdapters.Info_ReadInfoTableAdapter TAInfo = new DSInfoTableAdapters.Info_ReadInfoTableAdapter();
        DSInfo.Info_ReadInfoDataTable DTInfo = new DSInfo.Info_ReadInfoDataTable();

        DTInfo = TAInfo.GetInfoAlfaNet();
        this.Label1.Text = "Licenciado a: " + DTInfo[0].empresa.ToString();
        //ARCHIVAR LTDA";

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
}
