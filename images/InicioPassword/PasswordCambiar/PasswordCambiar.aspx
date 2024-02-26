<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="PasswordCambiar.aspx.cs" Inherits="_PasswordCambiar" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table height="400" style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 273px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center">
            </td>
            <td style="vertical-align: top; text-align: center" >
                <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    Font-Size="0.8em">
                    <CancelButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <PasswordHintStyle Font-Italic="True" ForeColor="#507CD1" />
                    <ChangePasswordButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                    <ChangePasswordTemplate>
                        <table border="0" cellpadding="4" cellspacing="0" style="width: 390px; border-collapse: collapse;
                            height: 168px">
                            <tr>
                                <td style="width: 144px">
                                    <table border="0" cellpadding="0" style="width: 381px">
                                        <tr>
                                            <td align="center" colspan="2" style="font-weight: bold; font-size: 0.9em; color: white;
                                                height: 40px; background-color: #507cd1">
                                                <span style="font-size: 14pt">Cambiar la contraseña</span></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 435px; height: 35px; text-align: left">
                                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
                                                    Font-Bold="True" CssClass="PropLabelsInicio">* Contraseña:</asp:Label></td>
                                            <td style="width: 351px; height: 35px; text-align: left">
                                                <asp:TextBox ID="CurrentPassword" runat="server" Height="15px"
                                                    TextMode="Password" Width="150px" CssClass="TxtProp"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                    ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                                    ValidationGroup="ChangePassword1" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 435px; height: 35px; text-align: left">
                                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"
                                                    Font-Bold="True" Width="137px" CssClass="PropLabelsInicio">* Nueva contraseña:</asp:Label></td>
                                            <td style="width: 351px; height: 35px; text-align: left">
                                                <asp:TextBox ID="NewPassword" runat="server" Height="15px" TextMode="Password"
                                                    Width="150px" CssClass="TxtProp"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                    ErrorMessage="La nueva contraseña es obligatoria." ToolTip="La nueva contraseña es obligatoria."
                                                    ValidationGroup="ChangePassword1" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 435px; height: 35px; text-align: left">
                                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                                                    Font-Bold="True" Width="334px" CssClass="PropLabelsInicio">* Confirmar contraseña:</asp:Label></td>
                                            <td style="width: 351px; height: 35px; text-align: left">
                                                <asp:TextBox ID="ConfirmNewPassword" runat="server" Height="15px"
                                                    TextMode="Password" Width="150px" CssClass="TxtProp"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                    ErrorMessage="Confirmar la nueva contraseña es obligatorio." ToolTip="Confirmar la nueva contraseña es obligatorio."
                                                    ValidationGroup="ChangePassword1" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                    ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="Confirmar la nueva contraseña debe coincidir con la entrada Nueva contraseña."
                                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: red">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 435px; height: 40px; text-align: center">
                                                <asp:Button ID="ChangePasswordPushButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                                    BorderStyle="Solid" BorderWidth="1px" CommandName="ChangePassword" Font-Names="Verdana"
                                                    Font-Size="0.8em" ForeColor="#284E98" Height="26px" Text="Cambiar contraseña"
                                                    ValidationGroup="ChangePassword1" Width="130px" /></td>
                                            <td style="width: 351px; height: 40px">
                                                <asp:Button ID="CancelPushButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                                    BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Cancel"
                                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Height="26px" Text="Cancelar"
                                                    Width="130px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ChangePasswordTemplate>
                    <TextBoxStyle Font-Size="0.8em" />
                    <SuccessTemplate>
                        <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" style="width: 209px; height: 1px">
                                        <tr>
                                            <td align="center" colspan="2" style="font-weight: bold; font-size: 0.9em; color: white;
                                                background-color: #507cd1">
                                                Cambio de contraseña completado</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="color: red">
                                                    <br />
                                                    Se ha cambiado su contraseña<br />
                                                    <br />
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2" style="text-align: center">
                                                <asp:Button ID="ContinuePushButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                                    BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Height="26px" PostBackUrl="~/Default.aspx"
                                                    Text="Continuar" Width="130px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </SuccessTemplate>
                  
                </asp:ChangePassword>
            </td>
            <td style="vertical-align: top; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center">
            </td>
            <td style="vertical-align: top; text-align: center">
            </td>
            <td style="vertical-align: top; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center">
            </td>
            <td style="vertical-align: top; text-align: center">
            </td>
            <td style="vertical-align: top; text-align: center">
            </td>
        </tr>
    </table>

           
</asp:Content>

