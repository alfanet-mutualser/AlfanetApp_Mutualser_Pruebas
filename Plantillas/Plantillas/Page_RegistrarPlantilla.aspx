<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeFile="Page_RegistrarPlantilla.aspx.cs" 
        Inherits="Page_RegistrarPlantilla" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="CPHPlantillas" ID="CRegistrarPlantilla" runat="server">
    <link rel="Stylesheet" href="styles/AlfanetStyle.css" type="text/css"/>
    <link rel="Stylesheet" href="styles/cssPlantilas.css" type="text/css"/>
    <link rel="Stylesheet" href="styles/redmond/jquery-ui-1.8.21.custom.css" type="text/css"/>
    
    <link rel="Stylesheet" href="styles/cssUpdateProgress.css" type="text/css"/>
    
    <script type="text/javascript" src="script/jquery-1.7.2.min.js" ></script>
    <script type="text/javascript" src="script/jquery-ui-1.8.21.custom.min.js" ></script>
    
    <link rel="Stylesheet" href="styles/cssUpdateProgress.css" type="text/css"/>
    
    <script type="text/javascript" language="javascript">
        var modalProgress = '<%= modalProgress.ClientID %>';
	</script>
	
	
	<script type="text/javascript">
	    $(document).ready(function() {
	        $("#dialog").dialog({
	            autoOpen: false,
	            modal: true
	        });
	    });

	    $(".confirm").click(function(e) {
	        e.preventDefault();
	        var targetUrl = $(this).attr("href");

	        $("#dialog").dialog({
	            buttons: {
	                "Confirm": function() {
	                    $(this).dialog("close");
	                    return true;
	                },
	                "Cancel": function() {
	                    $(this).dialog("close");
	                    return false;
	                }
	            }
	        });

	        $("#dialog").dialog("open");
	    });
    </script>
	
	
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/script/jsUpdateProgress.js" />
        </Scripts>
    </asp:ScriptManager>
    <div id=" progress">
        <asp:Panel ID="Panel1" runat="server" >
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
					<img src="Imagenes/loading.gif" style="vertical-align: middle" alt="Processing" />
					Processing ...
				</div>
            </ProgressTemplate>
            </asp:UpdateProgress>
        </asp:Panel>
        <asp:ModalPopupExtender ID="modalProgress" runat="server" BackgroundCssClass="modalBackground"
            TargetControlID="Panel1" PopupControlID="Panel1">
        </asp:ModalPopupExtender>
    </div>
    <asp:UpdatePanel ID="UPRegistrarDatos" runat="server"><ContentTemplate>
    <div align="center">
    
        <asp:Panel ID="PDatosRegistro" runat="server">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="left" class="style4" bgcolor="#9999FF">
                        &nbsp;
                    </td>
                    <td align="left" bgcolor="#FFCC66">
                        &nbsp;
                    </td>
                    <caption>
                        &nbsp;
                    </caption>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="LRadicadoFuente" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="Radicación Fuente"></asp:Label>
                        <%--<asp:Label ID="LRadicadoFuenteR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>--%>
                    </td>
                    <td align="left">
                        <%--<asp:UpdatePanel id="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="TxtRadicadoFuente" runat="server" AutoPostBack="true" OnTextChanged="TxtRadicadoFuente_TextChanged" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACERadicadoFuente" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtRadicadoFuente" ServicePath="~/AutoComplete.asmx" 
                                            ServiceMethod="GetRadicadoByCodigo"
                                            MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWMRadicadoFuente" runat="server" TargetControlID="TxtRadicadoFuente"
                                    WatermarkText="Seleccione un Radicado Fuente ...">
                                </asp:TextBoxWatermarkExtender>
                                <%--<asp:RequiredFieldValidator ID="RFVRadicadoFuente" runat="server" ControlToValidate="TxtRadicadoFuente"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>--%>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>                    
                    <td align="left">
                        <div>
                            <asp:Label ID="LDestino" runat="server" Font-Bold="True" Font-Size="Small" 
                                Text="Destino"></asp:Label>
                            <asp:Label ID="LDestinoR" runat="server" Font-Bold="True" Font-Size="Small" 
                                Text="*" ForeColor="Red"></asp:Label>
                        </div>
                        <div>
                            <%--<asp:RadioButton ID="RBPlantillaProcedencia" runat="server" Checked="true" 
                                GroupName="destino" Text="Procedencia" AutoPostBack="True" Visible="false" 
                                oncheckedchanged="RBPlantillaProcedencia_CheckedChanged"  />
                            <asp:RadioButton ID="RBPlantillaDependencia" runat="server" Checked="false" 
                                GroupName="destino" Text="Dependencia" AutoPostBack="True" Visible="false" 
                                oncheckedchanged="RBPlantillaDependencia_CheckedChanged" />--%>
                                
                                <asp:RadioButtonList ID="RBLDestino" runat="server" RepeatDirection="Vertical" 
                             AutoPostBack="true" 
                            onselectedindexchanged="RBLDestino_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Externo</asp:ListItem>
                            <asp:ListItem Selected="False" Value="0">Interno</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                    </td>
                    <td align="left">
                        
                        <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="TxtDestino" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACEDestino" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtDestino" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre"
                                            MinimumPrefixLength="3" EnableCaching="true" CompletionSetCount="12" CompletionInterval="50">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWMDestino" runat="server" TargetControlID="TxtDestino" 
                                        WatermarkText="Seleccione un Destino ...">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RFVDestino" runat="server" ControlToValidate="TxtDestino"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>                
                <tr>
                    <td align="left" class="style4">
                        <asp:Label ID="LNaturaleza" runat="server" Font-Bold="True" Font-Size="Small" Text="Naturaleza">
                        </asp:Label>
                        <asp:Label ID="LNaturalezaR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td align="left">
                        <%--<asp:UpdatePanel id="UpdatePanel4" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox id="TxtNaturaleza" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACENaturaleza" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtNaturaleza" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetNaturalezaByText"
                                            MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender id="TBWMNaturaleza" watermarkText="Seleccione una Naturaleza ..." runat="server" 
                                        TargetControlID="TxtNaturaleza">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator id="RFVNaturaleza" runat="server" ValidationGroup="ValAceptar" SetFocusOnError="True" 
                                        ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtNaturaleza">*
                                </asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style4">
                        <asp:Label ID="LMedio" runat="server" Font-Bold="True" Font-Size="Small" Text="Medio"></asp:Label>
                        <asp:Label ID="LMedioR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td align="left">
                        <%--<asp:UpdatePanel id="UpdatePanel3" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="TxtMedio" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACEMedio" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtMedio" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetMedioByText"
                                            MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWMMedio" runat="server" TargetControlID="TxtMedio" 
                                        WatermarkText="Seleccione un Medio ...">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RFVMedio" runat="server" ControlToValidate="TxtMedio"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style4">
                        <asp:Label ID="LExpediente" runat="server" Font-Bold="True" Font-Size="Small" Text="Expediente"></asp:Label>
                        <asp:Label ID="LExpedienteR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td align="left">
                        <%--<asp:UpdatePanel id="UpdatePanel5" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="TxtExpediente" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACEExpediente" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtExpediente" ServicePath="~/AutoComplete.asmx" 
                                            ServiceMethod="GetExpedienteByTextNombre"
                                            MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWMExpediente" runat="server" TargetControlID="TxtExpediente" 
                                        WatermarkText="Seleccione un Expediente ...">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RFVExpediente" runat="server" ControlToValidate="TxtExpediente"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style4">
                        <asp:Label ID="LArchivarEn" runat="server" Font-Bold="True" Font-Size="Small" Text="Archivar En"></asp:Label>
                        <asp:Label ID="LArchivarEnR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td align="left">
                        <%--<asp:UpdatePanel id="UpdatePanel6" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="TxtSerie" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACEArchivar" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtSerie" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetSerieByText"
                                            MinimumPrefixLength="-1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWMSerie" runat="server" TargetControlID="TxtSerie" 
                                        WatermarkText="Seleccione una Serie ...">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RFVSerie" runat="server" ControlToValidate="TxtSerie"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style4">
                        <%--<asp:Label ID="LAccion" runat="server" Font-Bold="True" Font-Size="Small" Text="Acción"></asp:Label>
                        <asp:Label ID="LAccionR" runat="server" Font-Bold="True" Font-Size="Small" 
                            Text="*" ForeColor="Red"></asp:Label>--%>
                    </td>
                    <td align="left" class="style4">
                        <%--<asp:UpdatePanel id="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TxtAccion" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="ACEAccion" runat="server" 
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem" 
                                            CompletionListCssClass="autocomplete_completionListElement"
                                            TargetControlID="TxtAccion" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText"
                                            MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TBWEAccion" runat="server" TargetControlID="TxtAccion"
                                        WatermarkText="Seleccione una Acción...">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RFVAccion" runat="server" ControlToValidate="TxtAccion"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValAceptar">*
                                </asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    
    </div>
    <div align="center">
        <table style="width:50%;">
            <tr>
                <td align="center" class="style4">
                    <asp:ImageButton ID="ImageButton2" runat="server"
                        ImageUrl="~/Plantillas/Plantillas/Imagenes/btnRegresarClaro.gif" 
                        onclick="ImageButton2_Click"/>
                </td>
                <td align="center" class="style4">
                    <asp:ImageButton ID="ImageButton1" runat="server" ValidationGroup="ValAceptar"
                        ImageUrl="~/Plantillas/Plantillas/Imagenes/btnSiguienteClaro.gif" onclick="IBAceptar_Click"/>
                </td>
            </tr>
            <tr>
                <td align="left" class="style4" colspan = "2">
                    <asp:Label ID="LblMsgCreateRegistro" runat="server" Font-Bold="True"
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Small" ForeColor="Red">
                    *
                    </asp:Label>
                    <asp:Label ID="LLeyenda" runat="server" Font-Size="X-Small">
                    El campo es Obligatorio.
                    </asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%--<div id="dialog" title="Confirmation Required">
        Se requiere confirmaci&oacute;n.
    </div>--%>
    </ContentTemplate></asp:UpdatePanel>
    <asp:UpdatePanel ID="upmessagealfa" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div>
                <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ButtonHighlight">
                    <table>
                        <tbody>
                            <tr>
                                <td style="BACKGROUND-COLOR: activecaption" align="center">
                                    <asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False">
                                    </asp:Label>
                                </td>
                                <td style="WIDTH: 5%; BACKGROUND-COLOR: activecaption">
                                    <asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" onclick="btnCerrar_Click" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789">
                                    </asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="BACKGROUND-COLOR: highlighttext" align="center" colspan="2">
                                    <br />
                                    <asp:Label id="LblMessageBox" runat="server" Width="350px" Font-Size="X-Large" ForeColor="Red">
                                    </asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender id="MPEMessage" runat="server" TargetControlID="LblMessageBox"
                    PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle" Enabled="false" >
                </asp:ModalPopupExtender> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
