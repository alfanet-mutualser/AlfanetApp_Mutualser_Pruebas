<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="TransDocPendientes.aspx.cs" Inherits="_TransDocPendientes" %>



<%@ import Namespace="System.Configuration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
 <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD><TABLE 
style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; width: 100%;" 
border=0><TBODY>
    <tr>
        <td colspan="1" style="width: 10%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
            <asp:Label ID="LblTransfDoc" runat="server" BackColor="CornflowerBlue" BorderColor="#B5C7DE"
                Font-Bold="True" ForeColor="White" Text="Tranferencia de Documentos " BorderWidth="2px"></asp:Label></td>
        <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
        </td>
    </tr>
    <tr>
        <td colspan="1" style="width: 10%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
        </td>
        <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
        </td>
    </tr>
    <tr>
        <td colspan="1" style="width: 10%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
            <table>
                <tr>
                    <td style="width: 25%">
                    </td>
                    <td style="width: 114px">
            <asp:CheckBoxList ID="ChBoxLst" runat="server" RepeatDirection="Horizontal" Width="392px">
                <asp:ListItem Value="0">Correspondencia Recibida</asp:ListItem>
                <asp:ListItem Value="1">Correspondencia Enviada</asp:ListItem>
            </asp:CheckBoxList></td>
                    <td style="width: 25%">
                    </td>
                </tr>
            </table>
        </td>
        <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
        </td>
    </tr>
    <TR>
    <td colspan="1" style="width: 10%">
    </td>
    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><Ajax:TextBoxWatermarkExtender id="TBWDocumento" watermarkText="Ingrese la Dependencia Inicial..." runat="server" TargetControlID="TxtDocumento">
                </Ajax:TextBoxWatermarkExtender> <Ajax:AutoCompleteExtender id="ACDocumento" runat="server" TargetControlID="TxtDocumento" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem ">
                </Ajax:AutoCompleteExtender> </TD>
    <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
    </td>
</TR><TR>
                    <td colspan="1" style="width: 20%">
                    </td>
                    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2>
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDocumento"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator></td>
                                <td style="width: 125px">
                                    <asp:Label ID="LblDocumento" runat="server" BackColor="CornflowerBlue" BorderColor="#B5C7DE"
                                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White"
                                        Text="*Dependencia Inicial" Width="126px"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TxtDocumento" runat="server" CssClass="TxtAutoComplete"></asp:TextBox></td>
                                <td style="width: 100px">
                                    </td>
                            </tr>
                        </table>
                        &nbsp;
                    </TD>
                    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
                    </td>
                </TR>
    <tr>
        <td colspan="1" style="width: 20%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
            <Ajax:AutoCompleteExtender id="ACFinal" runat="server" TargetControlID="TxtDepFinal" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem ">
            </Ajax:AutoCompleteExtender>
            <Ajax:TextBoxWatermarkExtender id="TBWFinal" watermarkText="Ingrese la Dependencia Final..." runat="server" TargetControlID="TxtDepFinal">
            </Ajax:TextBoxWatermarkExtender>
        </td>
        <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
        </td>
    </tr>
    <tr>
        <td colspan="1" style="width: 20%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDocumento"
                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator></td>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" BackColor="CornflowerBlue" BorderColor="#B5C7DE"
                            BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White"
                            Text="*Dependencia Final" Width="118px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TxtDepFinal" runat="server" CssClass="TxtAutoComplete"></asp:TextBox></td>
                    <td style="width: 100px">
                        </td>
                </tr>
            </table>
        </td>
        <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
        </td>
    </tr>
    <tr>
        <td colspan="1" style="width: 20%">
        </td>
        <td colspan="2" style="vertical-align: middle; text-align: center">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg" /></td>
                                            <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
                                        ToolTip="Transferir Documentos" OnClick="ImageButton1_Click" /><br />
                                                Transferir</td>
                                            <td>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/AlfaNetImagen/WFImagen/WFEscritorioImg.jpg"
                                                    ToolTip="Transferir" /></td>
                                        </tr>
                                    </table>
        </td>
        <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
        </td>
    </tr>
    <TR>
                                <td colspan="4" rowspan="1" style="text-align: center">
                                </td>
</TR></TBODY></TABLE> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblDocumento" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                </Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
<asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%" Height="1px"></asp:ValidationSummary> 
</TD></TR></TBODY></TABLE>
</asp:Content>



