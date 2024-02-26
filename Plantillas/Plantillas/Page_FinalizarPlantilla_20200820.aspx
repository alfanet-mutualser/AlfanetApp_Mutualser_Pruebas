<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeFile="Page_FinalizarPlantilla.aspx.cs"
        Inherits="Page_FinalizarPlantilla" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="CFinalizarPlantilla" ContentPlaceHolderID="CPHPlantillas" runat="server">
    
    <link rel="Stylesheet" href="styles/cssPlantilas.css" type="text/css"/>
    <link rel="Stylesheet" href="styles/redmond/jquery-ui-1.8.21.custom.css" type="text/css"/>
    <link rel="Stylesheet" href="styles/cssUpdateProgress.css" type="text/css"/>
    <link href="styles/AlfaNetStyle.css" rel="stylesheet" type="text/css"/>
    
    <script type="text/javascript" src="script/jquery-1.7.2.min.js" ></script>
    <script type="text/javascript" src="script/jquery-ui-1.8.21.custom.min.js"></script>

    <script type="text/javascript">
        function pageLoad() {
            $('#document').ready(function() {
                $('#dialog').dialog({
                    modal: true,
                    autoOpen: false
                });
            });
        }
    </script>
    <script type="text/javascript">
        function openModal() {
            var confirmar = confirm("Creará un nuevo registro. Seguro que desea continuar?");

            if (confirmar == true) {
                return true;
            }
            else {
                return false;
            }
//            $("#dialog-confirm").dialog({
//                resizable: false,
//                height: 140,
//                modal: true,
//                buttons: {
//                    "Continuar": function() {
//                        $(this).dialog("close");
//                        return true;
//                    },
//                    Cancel: function() {
//                        $(this).dialog("close");
//                        return false;
//                    }
//                 }
//            });
        }
    </script>
    
    <script type="text/javascript">
        function cerrar() {
            window.close();
        }
    </script>
    
    <%--<script type="text/javascript">
        $(function() {

        $('#<%=LBCopiar.ClientID%>').click(function() {

            $('#DivCorreos').dialog('open');
 
            });

            $('#DivCorreos').dialog({
                autoOpen: false,
                modal: true,
                width: 700,
                heigth: 250,
                title: 'Agregar CC',
            buttons: {
                "Cancel": function() {
            $(this).dialog("close");
            }
        }
    });
 
});
</script>--%>
    <%--<script type ="text/javascript">
        function inicio() {
            var path = "<%=nameFile%>";
            var x = new ActiveXObject('AxControl.AxControlSigner');
            var firmado = x.SignPDF(path);
            //alert(firmado);
            document.getElementById('<%=HFFirmado.ClientID%>').value = firmado;
            //alert(document.getElementById('<%=HFFirmado.ClientID%>').value);
        }
    </script>--%>
    <script type="text/javascript" language="javascript">
        var modalProgress = '<%= modalProgress.ClientID %>';         
	</script>
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Plantillas/Plantillas/script/jsUpdateProgress.js" />
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div align="left">
        <asp:Panel ID="pnlBotonFirmar" CssClass="panels_wizard" runat="server" Visible="True">
            <table class="table_wizard">
                <tr>
                    <td colspan="4" class="titles_wizard">
                        <h4 class="titulos_wizard">Seleccione la imagen de su firma. Formatos admitidos .jpg, y .png</h4>
                        <br />
                        <br />
                    </td>                    
                </tr>
                <tr>
                    <td align="right" style="width:20%;">
                        Seleccione:
                    </td>
                    <td class="certificate_wizard" colspan = "2">                   
                        <asp:FileUpload ID="fuImagenFirma" runat="server" style="width:98%;" />                        
                    </td>
                    <td align="left" style="width:5%;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                            CssClass="validacion_wizard" runat="server" 
                            ErrorMessage="Seleccione" ControlToValidate="fuImagenFirma" 
                            ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </td>                                       
                </tr>
                <tr>
                    <%--<td colspan="2" align="center"><br />        
                        asp:ImageButton ID="ImageButton1" runat="server"
                            ImageUrl="~/Plantillas/Plantillas/Imagenes/btnRegresarClaro.gif" 
                            onclick="ImageButton1_Click" />
                    </td>--%>
                    <td colspan="4" align="center"><br />
                        <asp:ImageButton ID="LBFirmar" runat="server" onClick="LBFirmar_Click" OnClientClick="return openModal();"
                            ImageUrl="~/Plantillas/Plantillas/Imagenes/btnSiguienteClaro.gif" ValidationGroup="validation" />
                    </td>
                    
                </tr>
            </table>
        
        </asp:Panel>
        
        <asp:Panel ID="pnlBotonAdjuntarVisualizar" CssClass="panels_wizard" runat="server" Visible="False">
            <table class="table_wizard">
                <tr>
                    <td class="titles_wizard">
                        <h4 class="titulos_wizard">Haga clic en 'Visualizar, Anexar, Imprimir'.
                        Para continuar haga clic en siguiente.</h4>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="LBAnexar" CssClass="link_wizard" runat="server" OnClick="LBAdjuntar_Click">Visualizar, Anexar, Imprimir
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    <br />
                        <asp:ImageButton ID="btnContinuarACopiarCorreos" runat="server"
                            onclick="btnContinuarACopiarCorreos_Click" 
                            ImageUrl="~/Plantillas/Plantillas/Imagenes/btnSiguienteClaro.gif" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        
        <%--<asp:Panel ID="pnlCopiarACorreos" CssClass="panels_wizard" runat="server" Visible="False">
            <table class="table_wizard">
                <tr>
                    <td colspan="2" class="titles_wizard">
                        <h4 class="titulos_wizard">S&iacute; desea copiar a otros correos, haga clic en 'Copiar a otros correos electr&oacute;nicos'.
                        De lo contrario haga clic en siguiente.</h4>
                        <br />
                        <br />                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        
                    </td>
                </tr>
                <tr>
                    <td align="center">
                            <br />
                          <asp:ImageButton ID="btnAtrasAdjuntar" runat="server"
                             ImageUrl="~/Plantillas/Plantillas/Imagenes/btnRegresarClaro.gif"
                              onclick="btnAtrasAdjuntar_Click" />             
                    </td>
                    <td align="center">
                    <br />
                        <asp:ImageButton ID="btnContinuarAEnviarPorCorreo" runat="server" 
                             onclick="btnContinuarAEnviarPorCorreo_Click" ImageUrl="~/Plantillas/Plantillas/Imagenes/btnSiguienteClaro.gif" />
                    </td>
                </tr>
            </table>
        </asp:Panel>--%>
        
        <asp:Panel ID="pnlEnviarPorCorreo" CssClass="panels_wizard" runat ="server" Visible="False">
        <table class="table_wizard">
            <tr>
                <td colspan = "2" class="titles_wizard">                   
                    <h4 class="titulos_wizard">Para agregar otras personas a las que desee copiarle esta respuesta active 'Destinatarios copia'</h4> <br />                   
                </td>
            </tr> 
            <tr>
                <td colspan = "2" align="center">
                    <asp:LinkButton ID="LBCopiar" CssClass="link_wizard" runat="server" OnClick="LBCopiar_Click" 
                        ToolTip="Agregar CC">Destinatarios copia
                        </asp:LinkButton>
                        <br />
                        <br />
                </td>
            </tr>            
            <tr>
                <td colspan = "2" class="titles_wizard">                   
                    <h4 class="titulos_wizard">Para enviar la respuesta por correo electr&oacute;nico active 'Enviar correo'. Para salir haga clic en Aceptar.</h4>                    
                </td>
            </tr>         
            <tr>                
                <td colspan = "2" align="center"><br />
                    <asp:LinkButton ID="LBCorreo" CssClass="link_wizard" runat="server" OnClick="LBEnviar_Click" 
                        ToolTip="Enviar respuesta">Enviar Correo
                    </asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:ImageButton ID="btnAtrasEnviarEmail" runat="server" 
                             ImageUrl="~/Plantillas/Plantillas/Imagenes/btnRegresarClaro.gif" 
                        onclick="btnAtrasEnviarEmail_Click" />
                </td>
                <td align="center">
                <br />
                    <asp:ImageButton ID="btnFinalizar" OnClientClick="cerrar()" runat="server" 
                        onclick="btnFinalizar_Click" 
                        ImageUrl="~/Plantillas/Plantillas/Imagenes/btnAceptarClaro.gif" />
                </td>
            </tr> 
        </table>
        </asp:Panel>
    </div>
    <%--<div id="dialog">
        <div>
            <asp:Label ID="LEditarFirma" runat="server" Font-Bold="True" Font-Size="Large" Text="Editar Firma"></asp:Label>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:FileUpload ID="FileUploadControl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblStatusUpload" runat="server" ForeColor="Red" Text="">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: right;">
            <asp:Button runat="server" ID="BCargar" Text="Cargar" Width="100px" 
                 />
        </div>
    </div>--%>
    <%--INICIO VENTANA DE COPIAR A OTROS CORREOS. --%>
    
    
    <div id="DivCorreos" style="width: 480px; position: absolute; top: 220px; left: 155px;">
        <asp:Panel ID="PCorreos" runat="server" Visible="false" BorderWidth="1px" 
                BorderColor="#CCCCCC" BackColor="#81BEF7">
             <div align="right">
                <asp:LinkButton ID="LBCerrar" runat="server" Text="Cerrar" onclick="LBCerrar_Click" ForeColor="White">
                </asp:LinkButton>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RBLCarreos" runat="server" RepeatDirection="Horizontal" 
                             AutoPostBack="true" 
                            onselectedindexchanged="RBLCarreos_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Externo</asp:ListItem>
                            <asp:ListItem Selected="False" Value="0">Interno</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID="TBCorreos" runat="server" Width="200px" Visible="true"></asp:TextBox>
                        
                        <asp:AutoCompleteExtender ID="ACECorreos" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement"
                            TargetControlID="TBCorreos" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre"
                            MinimumPrefixLength="3" EnableCaching="true" CompletionSetCount="12" CompletionInterval="50">
                        </asp:AutoCompleteExtender>
                        
                    </td>
                    <td align="left">
                        <asp:ImageButton  ID="IBCarreos" runat="server" 
                            ImageUrl="Imagenes/ToolBar/Add.png" 
                            onclick="IBCarreos_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;&nbsp;
                        <asp:ListBox ID="LBCorreos" runat="server" Width="375px"></asp:ListBox>
                        
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="IBCorreosBorrar" 
                            ImageUrl="Imagenes/ToolBar/Delete.png" runat="server" onclick="IBCorreosBorrar_Click" 
                        />
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
    </div>
    <div id="dialog">
        <div class="message_container">
            <asp:Label ID="LMessagePlantilla" runat="server" Text=""></asp:Label><br />
            <asp:LinkButton ID="lbtnPrint" runat="server" Visible="False" 
                onclick="lbtnPrint_Click">Imprimir</asp:LinkButton>
        </div>
    </div>
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger   ControlID="LBFirmar"/>
    </Triggers>
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
    <asp:HiddenField ID="firma" runat="server" />  
    <%--<div id="dialog-confirm" title="Continuar?">
    <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>Se creará un registro. Seguro que desea continuar?</p>
</div>--%>
</asp:Content>
