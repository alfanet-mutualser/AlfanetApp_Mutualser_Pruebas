<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroUsuario.aspx.cs" Inherits="_MaestroUsuario" %>


<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table height="400" width="100%">
        <tr>
            <td style="width: 10%;"></td>
            <td style="VERTICAL-ALIGN: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                        <TABLE border="0" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; width: 100%;">
                            <tbody>
                                <tr>
                                    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center"></td>
                                    <td colspan="2">
                                        <Ajax:AutoCompleteExtender ID="ACEaspnet_Users" runat="server" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " MinimumPrefixLength="0" ServiceMethod="GetADUsers" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtUsuario">
                                        </Ajax:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUsuario" ErrorMessage="RequiredFieldValidator" Height="15px" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="LblDepartamento" runat="server" CssClass="TxtAutoComplete" Font-Bold="False" Text="Usuario"></asp:Label>
                                        <asp:TextBox ID="TxtUsuario" runat="server" CssClass="TxtAutoComplete"  Width="200px"></asp:TextBox>
                                        <asp:ImageButton ID="ImgBtnFind" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" onclick="ImgBtnFind_Click" ToolTip="Buscar" ValidationGroup="ValGroup1" />
                                    </td>
                                    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 57px;"></td>
                                    <td style="WIDTH: 57px;"><strong><em><span style="FONT-FAMILY: Poor Richard"></span></em></strong>
                                        <asp:Label ID="LblFindBy" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Width="67px"></asp:Label>
                                    </td>
                                    <td style="VERTICAL-ALIGN: middle; WIDTH: 115px; TEXT-ALIGN: center">
                                        <asp:RadioButtonList ID="RadBtnLstFindby" runat="server" AutoPostBack="True" Font-Italic="False" Font-Size="Smaller" ForeColor="RoyalBlue" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal" Width="90%">
                                            <asp:ListItem Selected="True" Value="1">Nombres</asp:ListItem>
                                            <asp:ListItem Value="2">Apellidos</asp:ListItem>
                                            <asp:ListItem Value="3">Login</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="vertical-align: middle; width: 20%; text-align: center"></td>
                                </tr>
                            </tbody>
                        </TABLE>
                    </contenttemplate>
                    <triggers>
                        <asp:PostBackTrigger ControlID="ImgBtnFind" />
                    </triggers>
                </asp:UpdatePanel>
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" Visible="False">LinkButton</asp:LinkButton>
                <table style="BORDER-RIGHT: thin solid; BORDER-TOP: thin solid; BORDER-LEFT: thin solid; BORDER-BOTTOM: thin solid;" 
                 border=0>
                    <TBODY>
                    <tr>
                        <td align="center" colspan="2" style="FONT-WEIGHT: bold; VERTICAL-ALIGN: top; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: left">
                            <asp:Label ID="LblModo" runat="server" Font-Bold="False" Font-Size="Medium" ForeColor="DarkGray" Text="Label" Visible="False" Width="100%"></asp:Label>
                        </td>
                    </tr>
                    <tr style="FONT-SIZE: 10pt; COLOR: #ffffff">
                        <td align="center" colspan="2" style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1"><span style="FONT-SIZE: 10pt">Datos del usuario</span></td>
                    </tr>
                    <tr style="FONT-SIZE: 12pt">
                        <td align="right" style="TEXT-ALIGN: right; width: 50%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="TxtNombre" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Nombres:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtNombre" runat="server" CssClass="TxtStyle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtNombre" ErrorMessage="RequiredFieldValidator" ValidationGroup="CreateUserWizard1" Width="1px">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: #000000">
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="TxtApellido" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Apellidos:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtApellido" runat="server" CssClass="TxtStyle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtApellido" ErrorMessage="RequiredFieldValidator" ValidationGroup="CreateUserWizard1" Width="1px">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TxtUserName" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Login:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtUserName" runat="server" CssClass="TxtStyle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="TxtUserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label7" runat="server" AssociatedControlID="TxtUserName" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark" Visible="False">Contraseña Anterior:</asp:Label>
                            &nbsp; </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtOldPassword" runat="server" CssClass="TxtStyle" Enabled="False" TextMode="Password" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="TxtPassword" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Contraseña:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtPassword" runat="server" CssClass="TxtStyle" TextMode="Password"></asp:TextBox>
                            <Ajax:PasswordStrength ID="PasswordStrength2" runat="server" barbordercssclass="BarBorder_TextBox2" HelpHandlePosition="BelowLeft" helpstatuslabelid="TextBox2_HelpLabel" minimumnumericcharacters="1" minimumsymbolcharacters="1" preferredpasswordlength="5" requiresupperandlowercasecharacters="true" strengthindicatortype="BarIndicator" strengthstyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good" targetcontrolid="TxtPassword" textstrengthdescriptions="Very Poor;Weak;Average;Strong;Excellent">
                            </Ajax:PasswordStrength>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="TxtPassword" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            <asp:Label ID="TextBox2_HelpLabel" runat="server" CssClass="heading"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="TxtConfirmPassword" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Confirmar contraseña:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtConfirmPassword" runat="server" CssClass="TxtStyle" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="TxtConfirmPassword" ErrorMessage="Confirmar contraseña es obligatorio." ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="TxtEmail" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark">* Correo electrónico:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="TxtStyle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="TxtEmail" ErrorMessage="El correo electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1"><span style="FONT-SIZE: 10pt">Perfil del usuario</span></td>
                    </tr>
                    <tr>
                        <td align="center" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="AvailableRoles" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark" Width="197px">Perfil:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:ListBox ID="AvailableRoles" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1"><span style="FONT-SIZE: 10pt">Dependencia del usuario</span></td>
                    </tr>
                    <tr>
                        <td align="center" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="TxtDependencia" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark" Width="164px">* Dependencia:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:TextBox ID="TxtDependencia" runat="server" CssClass="TxtAutoComplete" Width="350px"></asp:TextBox>
                            <Ajax:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtDependencia">
                            </Ajax:AutoCompleteExtender>
                            <Ajax:TextBoxWatermarkExtender ID="WatermarkExt1" runat="server" TargetControlID="TxtDependencia" watermarkText="Seleccione una Dependencia ...">
                            </Ajax:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="DependneciaRequired" runat="server" ControlToValidate="TxtDependencia" ErrorMessage="El correo electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="color: white; height: 20px; background-color: #507cd1;"><span style="font-size: 10pt; width: 100%; width: 100%; color: white; background-color: #507cd1; font-weight: bold;">Habilitar Usuario</span></td>
                    </tr>
                    <tr>
                        <td align="center" style="TEXT-ALIGN: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label6" runat="server" AssociatedControlID="TxtDependencia" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark" Width="164px">Habilitar:</asp:Label>
                        </td>
                        <td style="TEXT-ALIGN: left">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Habilitar/DesHabilitar" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="VERTICAL-ALIGN: bottom; HEIGHT: 36px; TEXT-ALIGN: center">
                            <asp:ImageButton ID="ImgBtnAcceptInsert" runat="server" AlternateText="Aceptar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" onclick="ImgBtnAcceptInsert_Click" ValidationGroup="CreateUserWizard1" Visible="False" />
                            &nbsp;<asp:ImageButton ID="ImgBtnCancelInsert" runat="server" AlternateText="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" onclick="ImgBtnCancelInsert_Click" Visible="False" Width="17px" />
                            <asp:ImageButton ID="ImgBtnAcceptEdit" runat="server" AlternateText="Aceptar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" onclick="ImgBtnAcceptEdit_Click" ValidationGroup="CreateUserWizard1" Visible="False" />
                            <asp:ImageButton ID="ImgBtnCancelEdit" runat="server" AlternateText="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" onclick="ImgBtnCancelEdit_Click" Visible="False" />
                            <asp:ImageButton ID="ImgBtnAdd" runat="server" AlternateText="Adicionar" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" onclick="ImgBtnAdd_Click" />
                            &nbsp;<asp:ImageButton ID="ImgBtnEdit" runat="server" AlternateText="Editar" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" onclick="ImgBtnEdit_Click" />
                            &nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server" AlternateText="Eliminar" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" onclick="ImgBtnDelete_Click" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="HEIGHT: 18px">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CreateUserWizard1">Email Invalido</asp:RegularExpressionValidator>
                            <br />
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TxtConfirmPassword" Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ValidationGroup="CreateUserWizard1" Width="426px"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" 
                    PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                </Ajax:ModalPopupExtender>
                <asp:Panel ID="PnlMensaje" runat="server" Height="63px" style="DISPLAY: none" Width="125px">
                    <BR />
                    <TABLE border="0" width="275">
                        <tbody>
                            <tr>
                                <td align="center" style="BACKGROUND-COLOR: activecaption">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White" Text="Mensaje" Width="120px"></asp:Label>
                                </td>
                                <td style="WIDTH: 12%; BACKGROUND-COLOR: activecaption">
                                    <asp:ImageButton ID="btnCerrar" runat="server" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" style="VERTICAL-ALIGN: top" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext">
                                    <BR />
                                    <IMG src="http://localhost:20774/Alfanet20180118%20-%20copia/AlfaNetImagen/ToolBar/error.png" />
                                    &nbsp; &nbsp;<asp:Label ID="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
                                    <BR />
                                    <BR />
                                    <asp:Button ID="Button1" runat="server" BackColor="ActiveCaption" Font-Bold="True" Font-Italic="False" Font-Size="X-Small" ForeColor="White" Text="Aceptar" />
                                    <BR />
                                    <BR />
                                </td>
                            </tr>
                        </tbody>
                    </TABLE>
                </asp:Panel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <progresstemplate>
                        <IMG style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" src="http://localhost:20774/Alfanet20180118%20-%20copia/AlfaNetImagen/Icono/Load.gif"  />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td style="width: 10%;"></td>
        </tr>
    </table>
</asp:Content>



