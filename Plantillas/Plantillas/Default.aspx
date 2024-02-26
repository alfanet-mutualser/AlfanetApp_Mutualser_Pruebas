<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="ContentPlantillas" ContentPlaceHolderID="CPHPlantillas" runat="server">
    <link rel="Stylesheet" href="styles/cssPlantilas.css" type="text/css"/>
    <link rel="Stylesheet" href="styles/redmond/jquery-ui-1.8.21.custom.css" type="text/css"/>
    <link rel="Stylesheet" href="../../AlfaNetStyle.css" type="text/css"/>
    
    <link rel="Stylesheet" href="styles/cssUpdateProgress.css" type="text/css"/>
    
    <script type="text/javascript" src="script/jquery-1.7.2.min.js" ></script>
    <script type="text/javascript" src="script/jquery-ui-1.8.21.custom.min.js" ></script>
    
    <link rel="Stylesheet" href="styles/cssUpdateProgress.css" type="text/css"/>
    <script type="text/javascript" language="javascript">
        var modalProgress = '<%= modalProgress.ClientID %>';         
	</script>
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../plantillas/plantillas/script/jsUpdateProgress.js" />
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
    <div id="plantilla">
    <asp:UpdatePanel ID="UPPlantilla" runat="server">
        <ContentTemplate>
            <div>
                <asp:Panel ID="PSelPlantilla" runat="server">
                    <table class="style1" style="width: 247px">
                         <tr>
                             <td align="left" class="style2">
                                 <asp:Label ID="LblPlantilla" runat="server" Style="font-weight: 700; color: #ff0000"
                                     Text="Plantilla: "></asp:Label>
                             </td>
                             <td align="left" style="width: 177px">
                                 <asp:DropDownList ID="DDLPlantilla" runat="server" CssClass="DDLPlantillas" 
                                                        onselectedindexchanged="DDLPlantilla_SelectedIndexChanged" AutoPostBack="True" >
                                 </asp:DropDownList>
                             </td>
                         </tr>
                     </table>
                </asp:Panel>
            </div>
            <div>
                <CKEditor:CKEditorControl ID="Editor" runat="server" UIColor="#317796" 
                    DialogButtonsOrder="OS" DisableObjectResizing="False" 
                    FilebrowserWindowFeatures="location=no,menubar=no,toolbar=no,dependent=yes,minimizable=no,modal=yes,alwaysRaised=yes,resizable=yes,scrollbars=yes" 
                    ResizeDir="Vertical" ResizeEnabled="False" Skin="kama" Height="491px"></CKEditor:CKEditorControl>
            </div>
            <div align="center">
                <asp:ImageButton ID="IBARegistrar" runat="server" ImageUrl="~/Plantillas/Plantillas/Imagenes/btnSiguienteClaro.gif"
                        onclick="IBARegistrar_Click"/>
            </div>
            <div id="dialog">
                <div>
                    <asp:Label ID="LMessagePlantilla" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
    </div>
</asp:Content>
