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
<TABLE height=400 width="100%"><TBODY><TR>
    <td style="width: 10%;">
    </td>
    <TD 
style="VERTICAL-ALIGN: top;"><asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; width: 100%;" border=0><TBODY><TR>
    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
    </td>
    <TD colSpan=2>
<Ajax:AutoCompleteExtender id="ACEaspnet_Users" runat="server" TargetControlID="TxtUsuario" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetUsuariosByNombres" MinimumPrefixLength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></Ajax:AutoCompleteExtender><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ValGroup1" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtUsuario" Height="15px" SetFocusOnError="True">*</asp:RequiredFieldValidator><asp:Label id="LblDepartamento" runat="server" Font-Bold="False" Text="Usuario" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtUsuario" runat="server" CssClass="TxtAutoComplete" Width="200px"></asp:TextBox><asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ValidationGroup="ValGroup1" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:ImageButton></TD>
    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
    </td>
</TR><TR>
    <td style="width: 57px;">
    </td>
    <TD style="WIDTH: 57px;"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" Font-Size="Smaller" ForeColor="RoyalBlue" Font-Bold="True" Text="Buscar Por: " BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="90%" Font-Size="Smaller" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Font-Italic="False" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="1">Nombres</asp:ListItem>
                                                    <asp:ListItem Value="2">Apellidos</asp:ListItem>
                                                    <asp:ListItem Value="3">Login</asp:ListItem>
                                                </asp:RadioButtonList></TD>
    <td style="vertical-align: middle; width: 20%; text-align: center">
    </td>
</TR></TBODY></TABLE>
</contenttemplate>
                        <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFind"></asp:PostBackTrigger>
</triggers>
                    </asp:UpdatePanel><asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Visible="False">LinkButton</asp:LinkButton> 
<TABLE 
style="BORDER-RIGHT: thin solid; BORDER-TOP: thin solid; BORDER-LEFT: thin solid; BORDER-BOTTOM: thin solid;" 
border=0><TBODY><TR><TD 
style="FONT-WEIGHT: bold; VERTICAL-ALIGN: top; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: left" 
align=center colSpan=2><asp:Label id="LblModo" runat="server" Visible="False" ForeColor="DarkGray" Text="Label" Font-Size="Medium" Font-Bold="False" Width="100%"></asp:Label></TD></TR><TR 
style="FONT-SIZE: 10pt; COLOR: #ffffff"><TD 
style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1" 
align=center colSpan=2><SPAN 
style="FONT-SIZE: 10pt">Datos del 
usuario</SPAN></TD></TR><TR style="FONT-SIZE: 12pt"><TD 
style="TEXT-ALIGN: right; width: 50%;" align=right> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="Label3" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtNombre">* Nombres:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtNombre" runat="server" CssClass="TxtStyle"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Width="1px" ValidationGroup="CreateUserWizard1" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtNombre">*</asp:RequiredFieldValidator></TD></TR><TR 
style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: #000000"><TD 
style="TEXT-ALIGN: right" align=right> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="Label4" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtApellido">* Apellidos:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtApellido" runat="server" CssClass="TxtStyle"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" ValidationGroup="CreateUserWizard1" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtApellido">*</asp:RequiredFieldValidator></TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=right> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="UserNameLabel" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtUserName">* Login:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtUserName" runat="server" CssClass="TxtStyle"></asp:TextBox> 
<asp:RequiredFieldValidator id="UserNameRequired" runat="server" ToolTip="El nombre de usuario es obligatorio." ValidationGroup="CreateUserWizard1" ErrorMessage="El nombre de usuario es obligatorio." ControlToValidate="TxtUserName">*</asp:RequiredFieldValidator> 
</TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=right> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="Label7" runat="server" Visible="False" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtUserName">Contraseña Anterior:</asp:Label>&nbsp;
</TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtOldPassword" runat="server" Visible="False" CssClass="TxtStyle" Enabled="False" TextMode="Password"></asp:TextBox></TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=right> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="PasswordLabel" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtPassword">* Contraseña:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtPassword" runat="server" CssClass="TxtStyle" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator id="PasswordRequired" runat="server" ToolTip="La contraseña es obligatoria." ValidationGroup="CreateUserWizard1" ErrorMessage="La contraseña es obligatoria." ControlToValidate="TxtPassword">*</asp:RequiredFieldValidator><Ajax:passwordstrength id="PasswordStrength2" runat="server" HelpHandlePosition="BelowLeft" textstrengthdescriptions="Very Poor;Weak;Average;Strong;Excellent" targetcontrolid="TxtPassword" strengthstyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good" strengthindicatortype="BarIndicator" requiresupperandlowercasecharacters="true" preferredpasswordlength="5" minimumsymbolcharacters="1" minimumnumericcharacters="1" helpstatuslabelid="TextBox2_HelpLabel" barbordercssclass="BarBorder_TextBox2"></Ajax:passwordstrength> 
<asp:Label id="TextBox2_HelpLabel" runat="server" CssClass="heading"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: right" 
align=right> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="ConfirmPasswordLabel" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtConfirmPassword">* Confirmar contraseña:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtConfirmPassword" runat="server" CssClass="TxtStyle" TextMode="Password"></asp:TextBox> 
<asp:RequiredFieldValidator id="ConfirmPasswordRequired" runat="server" ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="CreateUserWizard1" ErrorMessage="Confirmar contraseña es obligatorio." ControlToValidate="TxtConfirmPassword">*</asp:RequiredFieldValidator> 
</TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=right> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="EmailLabel" runat="server" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtEmail">* Correo electrónico:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:TextBox id="TxtEmail" runat="server" CssClass="TxtStyle"></asp:TextBox> 
<asp:RequiredFieldValidator id="EmailRequired" runat="server" ToolTip="El correo electrónico es obligatorio." ValidationGroup="CreateUserWizard1" ErrorMessage="El correo electrónico es obligatorio." ControlToValidate="TxtEmail">*</asp:RequiredFieldValidator> 
</TD></TR><TR><TD 
style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1" 
align=center colSpan=2><SPAN 
style="FONT-SIZE: 10pt">Perfil del 
usuario</SPAN></TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=center> &nbsp;&nbsp;&nbsp;
    <asp:Label id="Label1" runat="server" Width="197px" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="AvailableRoles">Perfil:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:ListBox id="AvailableRoles" runat="server" Width="250px" SelectionMode="Multiple"></asp:ListBox></TD></TR><TR><TD 
style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 20px; BACKGROUND-COLOR: #507cd1" 
align=center colSpan=2><SPAN 
style="FONT-SIZE: 10pt">Dependencia del 
usuario</SPAN></TD></TR><TR><TD 
style="TEXT-ALIGN: right" align=center> &nbsp;&nbsp;&nbsp;
    <asp:Label id="Label2" runat="server" Width="164px" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtDependencia">* Dependencia:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><Ajax:AutoCompleteExtender id="autoComplete1" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtDependencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000">
                                                </Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="WatermarkExt1" watermarkText="Seleccione una Dependencia ..." runat="server" TargetControlID="TxtDependencia">
                                                </Ajax:TextBoxWatermarkExtender> 
<asp:TextBox id="TxtDependencia" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox><asp:RequiredFieldValidator id="DependneciaRequired" runat="server" ToolTip="El correo electrónico es obligatorio." ValidationGroup="CreateUserWizard1" ErrorMessage="El correo electrónico es obligatorio." ControlToValidate="TxtDependencia">*</asp:RequiredFieldValidator></TD></TR>
    <tr>
        <td align="center" colspan="2" style="color: white; height: 20px; background-color: #507cd1;">
            <span style="font-size: 10pt; width: 100%; width: 100%; color: white; background-color: #507cd1; font-weight: bold;">
                Habilitar Usuario</span></td>
    </tr>
    <TR><TD 
style="TEXT-ALIGN: right" align=center> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label id="Label6" runat="server" Width="164px" ForeColor="ControlDarkDark" Font-Size="Small" Font-Bold="True" AssociatedControlID="TxtDependencia">Habilitar:</asp:Label></TD><TD 
style="TEXT-ALIGN: left"><asp:CheckBox id="CheckBox1" runat="server" Text="Habilitar/DesHabilitar"></asp:CheckBox></TD></TR><TR><TD 
style="VERTICAL-ALIGN: bottom; HEIGHT: 36px; TEXT-ALIGN: center" align=center 
colSpan=2><asp:ImageButton id="ImgBtnAcceptInsert" onclick="ImgBtnAcceptInsert_Click" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" ValidationGroup="CreateUserWizard1" AlternateText="Aceptar"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImgBtnCancelInsert" onclick="ImgBtnCancelInsert_Click" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" AlternateText="Cancelar"></asp:ImageButton> 
<asp:ImageButton id="ImgBtnAcceptEdit" onclick="ImgBtnAcceptEdit_Click" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" ValidationGroup="CreateUserWizard1" AlternateText="Aceptar"></asp:ImageButton> 
<asp:ImageButton id="ImgBtnCancelEdit" onclick="ImgBtnCancelEdit_Click" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" AlternateText="Cancelar"></asp:ImageButton> 
<asp:ImageButton id="ImgBtnAdd" onclick="ImgBtnAdd_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" AlternateText="Adicionar"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImgBtnEdit" onclick="ImgBtnEdit_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" AlternateText="Editar"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImgBtnDelete" onclick="ImgBtnDelete_Click" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" AlternateText="Eliminar"></asp:ImageButton></TD></TR><TR><TD style="HEIGHT: 18px" align=center 
colSpan=2><asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="CreateUserWizard1" ErrorMessage="RegularExpressionValidator" ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email Invalido</asp:RegularExpressionValidator><BR /><asp:CompareValidator id="PasswordCompare" runat="server" Width="426px" ValidationGroup="CreateUserWizard1" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ControlToValidate="TxtConfirmPassword" Display="Dynamic" ControlToCompare="TxtPassword"></asp:CompareValidator></TD></TR></TBODY></TABLE>
<Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                    </Ajax:ModalPopupExtender>
                     <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" ForeColor="White" Text="Aceptar" Font-Size="X-Small" Font-Bold="True" Font-Italic="False"></asp:Button><BR /><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
<asp:UpdateProgress id="UpdateProgress1" runat="server">
                        <progresstemplate>
<IMG style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" src="../../AlfaNetImagen/Icono/Load.gif"  />
</progresstemplate>
                    </asp:UpdateProgress> </TD>
    <td style="width: 10%;">
    </td>
</TR></TBODY></TABLE>       
</asp:Content>



