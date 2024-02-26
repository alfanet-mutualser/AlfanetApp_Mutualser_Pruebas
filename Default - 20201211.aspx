<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; text-align: center; width: 100%; background-color: white;">
              <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" style="width: 475px; height: 365px">
  <param name="movie" value="Alfanet animacion 3D negro.swf" />
  <param name="quality" value="high" />
  <embed src="Alfanet animacion 3D 
negro.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="640" 
height="480"></embed>
        </object>
        </td>
        </tr>
        <tr>
        <td style="vertical-align: middle; background-color: #ffffff; text-align: center">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="lnkbtn" PostBackUrl="~/AlfaNetInicio/InicioLogin/LoginIniciar.aspx">Iniciar Sesion</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>
