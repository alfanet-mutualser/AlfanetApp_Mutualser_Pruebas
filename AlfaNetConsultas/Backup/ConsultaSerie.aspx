<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ConsultaSerie.aspx.cs" Inherits="_ConsultaSerie" %>
   
<%@ Import Namespace="System.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div>
    <script language="javascript" type="text/javascript">

        function url(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
             var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
             var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Enviada
           function VImagenesReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Archivo
           function VImagenesArc(evt,NumeroDocumento,CodArchivo,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&GrupoPadreCodigo=101&Admon=S&CZ=' + CodArchivo + '&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Historico Recibida
           function Historico(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
         //Historico Recibida
           function HistoricoReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        
// ]]>
    </script>

    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                        <asp:Panel ID="PnlMensaje" runat="server" Style="display: none" Width="280px" BackColor="ControlLight">
                            <table style="width: 385px">
                                <tbody>
                                    <tr>
                                        <td align="center" style="background-color: activecaption">
                                            <asp:Label ID="Label555" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                                Text="Mensaje" Width="120px"></asp:Label></td>
                                        <td style="width: 5%; background-color: activecaption">
                                            <asp:ImageButton ID="btnCerrar" runat="server" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                                                Style="vertical-align: top" ValidationGroup="789" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="height: 45px; background-color: highlighttxt">
                                            <br />
                                            <asp:Label ID="LblMessageBox" runat="server" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="PnlMensaje"
                            TargetControlID="LblMessageBox" BackgroundCssClass="MessageStyle">
                        </cc1:ModalPopupExtender>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                    TransitionDuration="250" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Consulta Series.:</a>
                            
</Header>
                            <Content>       
                            <TABLE style="WIDTH: 100%"><TBODY><TR><TD 
style="WIDTH: 20%" colSpan=1></TD><TD 
style="HEIGHT: 318px" colSpan=3><asp:UpdatePanel id="UpdatePanelExpediente" runat="server" RenderMode="Inline"><ContentTemplate>
<TABLE style="WIDTH: 600px; TEXT-ALIGN: left" forecolor="White"><TBODY><TR><TD style="WIDTH: 600px; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">Consulta de Documentos por Serie</TD></TR><TR><TD style="WIDTH: 600px; BACKGROUND-COLOR: #eff3fb; TEXT-ALIGN: center" colSpan=3><TABLE style="WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"></TD><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="84px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Font-Italic="False" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                                            <asp:ListItem Value="2">Codigo</asp:ListItem>
                                                        </asp:RadioButtonList></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 489px; HEIGHT: 16px; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center"></TD></TR><TR><TD style="WIDTH: 489px; BACKGROUND-COLOR: #eff3fb; TEXT-ALIGN: center">&nbsp;<asp:CheckBox id="CBBusquedaExacta" runat="server" Font-Size="Smaller" Visible="False" ForeColor="RoyalBlue" Text="Busqueda Exacta" Font-Bold="True"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="6px" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtExpediente">*</asp:RequiredFieldValidator> <asp:Label id="LblExpedienteS" runat="server" Width="100px" BackColor="CornflowerBlue" ForeColor="White" Text="Serie" Font-Bold="True" BorderStyle="Solid" BorderWidth="2px" BorderColor="#B5C7DE"></asp:Label> <asp:TextBox id="TxtExpediente" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox> <asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CommandName="Select"></asp:ImageButton><asp:HiddenField id="HFDependenciaConsulta" runat="server"></asp:HiddenField> <asp:HiddenField id="HFCodigoSeleccionado" runat="server">
</asp:HiddenField> <cc1:autocompleteextender id="ACExpediente" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" targetcontrolid="TxtExpediente" servicepath="../../AutoComplete.asmx" servicemethod="GetSerieByText" minimumprefixlength="1" enablecaching="true" completionsetcount="12" completioninterval="1000" ContextKey="311">
</cc1:autocompleteextender> <cc1:TextBoxWatermarkExtender id="TBWExpediente1" watermarkText="Seleccione una Serie ..." runat="server" TargetControlID="TxtExpediente">
</cc1:TextBoxWatermarkExtender> </TD></TR><TR><TD style="WIDTH: 485px; BACKGROUND-COLOR: #eff3fb; TEXT-ALIGN: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 500px; COLOR: white; HEIGHT: 21px; BACKGROUND-COLOR: #507cd1">&nbsp;<asp:ImageButton id="ImgBtnNew" onclick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png"></asp:ImageButton> &nbsp; <asp:ImageButton id="ImgBtnCancel" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="ImgBtnFind"></asp:PostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD><TD style="WIDTH: 20%" colSpan=1></TD></TR><TR><TD style="WIDTH: 20%" colSpan=1></TD><TD colSpan=3><dxwgv:aspxgridview id="ASPxGridView1" runat="server" Width="100%" datasourceid="ODSBuscar" csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" autogeneratecolumns="False" KeyFieldName="SerieCodigo">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager PageSize="20" ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</SettingsPager>

<ImagesFilterControl>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="SerieCodigoPadre" GroupIndex="0" SortIndex="0" SortOrder="Ascending" Caption="Serie Padre" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieCodigo" ReadOnly="True" VisibleIndex="1"><DataItemTemplate>
<asp:LinkButton id="LBtnExpediente" onclick="LBtnExpediente_Click" runat="server" Width="40px" Text='<%# Bind("SerieCodigo") %>' CommandName="Select"></asp:LinkButton>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieNombre" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieTiempo" Caption="Tiempo" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:aspxgridview></TD><TD style="WIDTH: 20%" colSpan=1></TD></TR></TBODY></TABLE>
</Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            
</Header>
                            <Content>
                     <asp:HiddenField id="HFTipoSeleccionado" runat="server"></asp:HiddenField>
<dxwgv:aspxgridview id="ASPxGVExpediente" runat="server" Width="100%" csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" autogeneratecolumns="False" OnHtmlRowPrepared="ASPxGVExpediente_HtmlRowPrepared">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager PageSize="20" ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</SettingsPager>

<ImagesFilterControl>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="id_res" ReadOnly="True" Caption="AutoID" VisibleIndex="0">
<EditFormSettings Visible="False"></EditFormSettings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NroDoc" Caption="Nro Documento" VisibleIndex="1">
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Font-Size="XX-Small" Text='<%# Eval("NroDoc") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" Caption="Fecha" VisibleIndex="3"></dxwgv:GridViewDataDateColumn>
<dxwgv:GridViewDataTextColumn FieldName="Detalle" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoNombre" Caption="Grupo" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieNombre" Caption="Serie" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn ReadOnly="True" VisibleIndex="6" Caption="Opciones"><DataItemTemplate>
<asp:HyperLink id="HprLnkImgExtVen" runat="server" Font-Size="XX-Small" Text="Imagenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink> 
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:aspxgridview>
                            
</Content>
                        </cc1:AccordionPane>
                        </Panes>
                </cc1:Accordion>
                       
                <asp:ObjectDataSource ID="ODSBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetSerieConsultaV1Data" TypeName="DSSerieSQLTableAdapters.SerieTableAdapter">
                    <SelectParameters>
                        <asp:Parameter Name="SerieNombre" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
                <asp:ObjectDataSource ID="ODSWFExpediente" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData" TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadSerieWFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter Name="SerieCodigo" Type="String" DefaultValue="10" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="420px"></asp:Label>
                <asp:ValidationSummary Style="vertical-align: middle; text-align: float" ID="ValidationSummaryRadicado"
                    runat="server" Width="418px" Height="1px" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
