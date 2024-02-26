<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; text-align: center; width: 100%; background-color: white;">
              <video src="Video_Alfanet.mp4" style="width: 475px; height: 365px" muted autoplay />
        </td>
        </tr>
        <tr>
        <td style="vertical-align: middle; background-color: #ffffff; text-align: center">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="lnkbtn" PostBackUrl="~/AlfaNetInicio/InicioLogin/LoginIniciar.aspx">Iniciar Sesion</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>
