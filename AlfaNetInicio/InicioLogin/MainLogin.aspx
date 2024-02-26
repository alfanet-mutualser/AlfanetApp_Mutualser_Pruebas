<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MainLogin.aspx.cs" Inherits="_MainLogin" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table height="400" width="735">
        <tr>
            <td style="vertical-align: top; width: 156px; text-align: center">
            </td>
            <td style="text-align: right">
                <asp:LoginView ID="LoginView1" runat="server">
                    <LoggedInTemplate>
                        <asp:LoginName ID="LoginName1" runat="server" Font-Bold="True" ForeColor="ControlText"
                            Style="vertical-align: top; color: black; text-align: left" />
                        <span style="color: red">| Conectado |&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server"
                            Font-Bold="True" ForeColor="Red" LogoutAction="Redirect" LogoutPageUrl="~/AlfaNetInicio/InicioLogin/LoginIniciar.aspx" />
                        </span>
                    </LoggedInTemplate>
                    <AnonymousTemplate>
                        <strong><span style="color: red"><span style="color: red">Usted no ha iniciado sesion</span>.</span></strong>
                    </AnonymousTemplate>
                </asp:LoginView>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 156px; text-align: center">
                <img src="../../AlfaNetImagen/MainPages/MainLogin.JPG" style="width: 264px; height: 278px" /></td>
            <td>
                <h1 style="text-align: center">
                    <strong><span style="color: appworkspace">MainLogin.aspx </span></strong>
                </h1>
                <h1 style="text-align: center">
                    <strong><span style="color: appworkspace"></span></strong><strong><span style="color: appworkspace">
                        Insertar texto ...</span></strong></h1>
            </td>
        </tr>
    </table>
           
</asp:Content>

