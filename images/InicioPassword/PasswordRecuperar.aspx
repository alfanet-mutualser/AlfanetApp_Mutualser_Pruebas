<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="PasswordRecuperar.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
<script runat="server">
  //Remove this code in production.
  // For sample purposes only we have canceled the email
  // that the PasswordRecovery control is attempting to send to the end user.
     protected void CancelEmail(object sender, MailMessageEventArgs e)
    {

        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg = e.Message;

        MailBLL Correo = new MailBLL();
        try
        {

            Correo.EnvioCorreoMsg(msg);
            e.Cancel = true;
        }           
        catch (System.Net.Mail.SmtpException ex)
        {
            //Label3.Text = ex.Message;
            this.PasswordRecovery2.SuccessText = ex.Message;
            e.Cancel = true; 
            //Console.WriteLine(ex.Message);
            //Console.ReadLine();
        }
    }
</script>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="width: 25%">
            </td>
            <td style="width: 50%; text-align: center">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td style="width: 25%">
            </td>
            <td style="width: 50%; text-align: center">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td style="height: 100%">
            </td>
            <td style="width: 50%; height: 100%; text-align: center">
                <asp:PasswordRecovery ID="PasswordRecovery2" runat="server"
    BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid"
    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" OnSendingMail="CancelEmail" Width="100%" Height="100%">
    <MailDefinition From="soporte.archivar@gmail.com" Subject="AlfaNet">
    </MailDefinition>
    <SuccessTextStyle Font-Bold="True" ForeColor="#507CD1" />
    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="0.9em" />
    <SubmitButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
      BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" Font-Size="0.8em" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TextBoxStyle Font-Size="0.8em" />
  </asp:PasswordRecovery>
            </td>
            <td style="height: 100%">
            </td>
        </tr>
        <tr>
            <td style="width: 25%">
            </td>
            <td style="width: 50%; text-align: center">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td style="width: 25%">
            </td>
            <td style="width: 50%; text-align: center">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Width="100%"></asp:Label></td>
        </tr>
    </table>
</asp:Content>



