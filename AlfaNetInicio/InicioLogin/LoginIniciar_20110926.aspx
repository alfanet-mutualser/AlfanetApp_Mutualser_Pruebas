<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="LoginIniciar.aspx.cs" Inherits="LoginIniciar" %>

<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>


<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%">
        <tr>
            <td style="vertical-align: top; text-align: center">
                <br />
                        <img src="../../AlfaNetImagen/Logo/LogoEmpresa.jpg" /><br />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center;">
               <%-- <div id="CentrandoMar_80s">--%>
                <%--</div>--%>
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 33%">
                        </td>
                        <td style="width: 33%">
                        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4"
                            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                            ForeColor="#333333" DestinationPageUrl="~/AlfaNetWorkFlow/AlfaNetWF/WorkFlow.aspx">
                            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                            <TextBoxStyle Font-Size="0.8em" />
                            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                            <LayoutTemplate>
                                <table border="0" cellpadding="4" cellspacing="0" style="width: 295px; border-collapse: collapse;
                                    height: 190px">
                                    <tr>
                                        <td style="width: 295px; height: 166px">
                                            <table border="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" colspan="2" style="font-weight: bold; font-size: 0.9em; color: white;
                                                        height: 40px; background-color: #507cd1">
                                                        <span style="font-size: 12pt">
                                    Iniciar sesión</span></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 108px; height: 35px; text-align: float">
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Bold="True" CssClass="PropLabelsInicio">* Usuario:</asp:Label></td>
                                                    <td style="width: 189px; height: 35px; text-align: left">
                                                        <asp:TextBox ID="UserName" runat="server" Height="15px" Width="150px" CssClass="TxtProp"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                            ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio."
                                                            ValidationGroup="ctl01$Login1" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 108px; height: 35px; text-align: float">
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Bold="True" CssClass="PropLabelsInicio">* Contraseña:</asp:Label></td>
                                                    <td style="width: 189px; height: 35px; text-align: left">
                                                        <asp:TextBox ID="Password" runat="server" Height="15px" TextMode="Password"
                                                            Width="150px" CssClass="TxtProp"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                            ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                                            ValidationGroup="ctl01$Login1" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 32px">
                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." CssClass="textos2alfa" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="color: red">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2" style="text-align: center">
                                                        <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                                            BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" ForeColor="#284E98" Height="26px" Text="Inicio de sesión" ValidationGroup="ctl01$Login1"
                                                            Width="130px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                        </td>
                        <td style="width: 33%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom; text-align: float; height: 22px;" align="left">
                <asp:Label ID="Label1" runat="server" BackColor="#336699" BorderColor="Black"
                    BorderWidth="1px" Font-Bold="False" ForeColor="White" Text="Licenciado a:"></asp:Label>
                <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                </td>
        </tr>
    </table>
</asp:Content>


