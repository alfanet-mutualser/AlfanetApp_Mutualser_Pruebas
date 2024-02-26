<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MainAdministracion.aspx.cs" Inherits="_MainAdministracion" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="text-align: center">
        <table height="400" width="735">
            <tr>
                <td style="vertical-align: top; width: 144px; text-align: center">
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
                            <strong><span style="color: red">Usted no ha iniciado sesion.</span></strong>
                        </AnonymousTemplate>
                    </asp:LoginView>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 144px; text-align: center">
                    <br />
                    <img src="../AlfaNetImagen/MainPages/MainAdministracion.JPG" style="width: 196px;
                        height: 288px" /></td>
                <td>
                    <strong></strong>
                    <h1>Administración Alfanet
                        <strong><span style="color: appworkspace">MainAdministracion.aspx </span></strong>
                    </h1>
                    <h1>
                        <strong><span style="color: appworkspace">Insertar texto ...</span></strong></h1>
                </td>
            </tr>
        </table>
    </div>
    
           
</asp:Content>
