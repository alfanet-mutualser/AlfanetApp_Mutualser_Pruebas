<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="LogsPlantilla.aspx.cs" Inherits="_DocRecibido" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl"
    TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="System.Configuration" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript">

        function url(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        function urlInt(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
        function urlRpta(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Recibida
        function VImagenes(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Enviada
        function VImagenesReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function Historico(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function HistoricoReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Expediente
        function Expediente(evt, NumeroDocumento, Expediente, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }

        function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
        }
        function popup_Shown(s, e) {
            callbackPanel.AdjustControl();
        }

    </script>
    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td>
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                    SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                    ContentCssClass="accordionContent" AutoSize="None">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Reportes Log.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; text-align: left"
                                    forecolor="White">
                                    <tbody>
                                        <tr>
                                            <td
                                                style="width: 489px; color: white; height: 16px; background-color: #507cd1; text-align: center">Reporte Logs Plantilla</td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBFechaFechas" runat="server" Width="185px" Text="Entre Fechas de Reporte" OnCheckedChanged="ChBFechaFechas_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                                        <br />
                                                        <cc1:CalendarExtender ID="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinal">
                                                        </cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarInicial">
                                                        </cc1:CalendarExtender>
                                                        <asp:Label ID="LblFechaInicial" runat="server" Width="70px" Text="Fecha Inicial" Visible="False"></asp:Label>
                                                        <asp:TextBox ID="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image>
                                                        <asp:Label ID="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label>
                                                        <asp:TextBox ID="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaFechas" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBUsername" runat="server" Text="Por nombre de usuario" Width="181px"
                                                            OnCheckedChanged="ChBUsername_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblUsername" runat="server" Text="Nombre de usuario" Visible="False"
                                                            Width="60px"></asp:Label>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtUsername" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionSetCount="20" MinimumPrefixLength="0" ServiceMethod="Getaspnet_UsersByUserName" ServicePath="../../AutoComplete.asmx"></cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtUsername" runat="server" Font-Size="8pt"
                                                            Visible="False" Width="400px" CssClass="TxtAutoComplete"></asp:TextBox>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBUsername" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #eff3fb">
                                                <asp:UpdatePanel ID="UpdatePanelDestino" runat="server" UpdateMode="Conditional">
                                                    <%--         <ContentTemplate>
<asp:CheckBox id="ChBGrupocodigo" runat="server" Width="300px" Text="Por Radicado o Registro ...(Seleccione un criterio)" AutoPostBack="True" OnCheckedChanged="ChBGrupocodigo_CheckedChanged"></asp:CheckBox><BR   />
                                                    <asp:RadioButtonList id="RadioButtonList2" tabIndex=8 runat="server" Width="98px" Visible="false" Font-Size="8pt" ValidationGroup="1" AutoPostBack="True" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Radicado</asp:ListItem>
                                                            <asp:ListItem Value="2">Registro</asp:ListItem>
                                                        </asp:RadioButtonList>
</ContentTemplate> --%>

                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBactividadLogica" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelProcedencia" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBActividadLogica" runat="server" Width="300px" Text="Por Actividad Logica" AutoPostBack="True" OnCheckedChanged="ChBActividadLogica_CheckedChanged"></asp:CheckBox><br />
                                                        <asp:Label ID="LblActividadLogica" runat="server" Width="60px" Visible="False" Text="Actividad Logica"></asp:Label>
                                                        <cc1:AutoCompleteExtender ID="ACEActividadLogica" runat="server" TargetControlID="TxtActividadLogica" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDataReportlogPlantillasReadActividadLogcodigo" MinimumPrefixLength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtActividadlogica" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBActividadLogica" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>

                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; color: white; background-color: #507cd1" colspan="3">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                                    <asp:TableRow ID="TableRow1" runat="server">
                                                                        <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                                                CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar">
                                                                            </asp:LinkButton>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                                CssClass="CommandButton" OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda">
                                                                            </asp:LinkButton>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                </asp:Table>
                                                            </td>
                                                            <td></td>
                                                            <td>
                                                                <%--<asp:RadioButtonList id="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                            </asp:RadioButtonList> --%>

                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </Content>
                        </cc1:AccordionPane>

                        <cc1:AccordionPane ID="AccordionPane2" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; height: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dxwgv:ASPxGridViewExporter>
                                                <table class="style1">
                                                    <tbody>
                                                        <tr>
                                                            <td>

                                                                <dxe:ASPxComboBox ID="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                                                    <Items>
                                                                        <dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
                                                                    </Items>

                                                                    <ButtonStyle Width="13px"></ButtonStyle>
                                                                </dxe:ASPxComboBox>
                                                            </td>
                                                            <td>
                                                                <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"></dxe:ASPxButton>
                                                            </td>
                                                            <td style="width: 65px">
                                                                <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"></dxe:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <dxpc:ASPxPopupControl ID="popup" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" ClientInstanceName="popup" AllowDragging="True" PopupHorizontalAlign="OutsideRight" HeaderText="Vinculo a Respuesta">
                                                    <ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
                                                    <ContentCollection>
                                                        <dxpc:PopupControlContentControl runat="server">
                                                            <dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel">
                                                                <LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

                                                                <LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
                                                                <PanelCollection>
                                                                    <dxp:PanelContent runat="server">
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:Literal runat="server" ID="litText"></asp:Literal>

                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>

                                                                        </table>
                                                                    </dxp:PanelContent>
                                                                </PanelCollection>
                                                            </dxcp:ASPxCallbackPanel>
                                                        </dxpc:PopupControlContentControl>
                                                    </ContentCollection>
                                                </dxpc:ASPxPopupControl>
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                    <ContentTemplate>

                                                        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False">

                                                            <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                                                                <Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>
                                                                <LoadingPanel ImageSpacing="10px"></LoadingPanel>
                                                            </Styles>
                                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

                                                            <SettingsPager ShowSeparators="True">
                                                                <Summary AllPagesText="Paginas: {0} - {1} ({2} Reportes)" Text="Pagina {0} de {1} ({2} Reportes)"></Summary>
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

                                                            <SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea Filtrar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
                                                            <Columns>

                                                                <%-- Campos del AspGridView provenientes de la consulta generada --%>
                                                                <dxwgv:GridViewCommandColumn VisibleIndex="0">
                                                                    <ClearFilterButton Visible="True"></ClearFilterButton>
                                                                </dxwgv:GridViewCommandColumn>


                                                                <dxwgv:GridViewDataTextColumn FieldName="UserName" Caption="Usuario" VisibleIndex="1">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Fecha" Caption="Fecha Inicial" VisibleIndex="2">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="ActividadLogCodigo" Caption="Actividad" VisibleIndex="4">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="ModuloLog" Caption="modulo Logico" VisibleIndex="6">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Codigo" Caption="Codigo" VisibleIndex="7">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Descripcion" Caption="Descripcion" VisibleIndex="8">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Estado" Caption="Estado" VisibleIndex="10">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="HTML" Caption="HTML" VisibleIndex="11">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Ip" Caption="Ip" VisibleIndex="11">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="NombreEquipo" Caption="Nombre Equipo" VisibleIndex="11">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <dxwgv:GridViewDataTextColumn FieldName="Navegador" Caption="Navegador" VisibleIndex="12">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>

                                                                <%--<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Caption="Numero Documento" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>--%>
                                                            </Columns>

                                                            <Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

                                                            <StylesEditors>
                                                                <ProgressBar Height="25px"></ProgressBar>
                                                            </StylesEditors>
                                                        </dxwgv:ASPxGridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                                                        <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane3" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Reporte.:</a>
                            </Header>

                            <%--<Content>                                                           
                <rsweb:reportviewer id="ReportViewer1" runat="server" BackColor="White" width="100%" height="400px" font-size="8pt" font-names="Verdana" AsyncRendering="false">
<LocalReport ReportPath="AlfaNetConsultas\Gestion\DocRecibido.rdlc" EnableExternalImages="True">
<DataSources>
    <rsweb:ReportDataSource DataSourceId="ODSBuscarGraph" Name="DSRadicado_Radicado_ConsultasRadicado" />
</DataSources>
</LocalReport>
</rsweb:reportviewer>
                            </Content> --%>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
                <%--llamar Metodo del data set --%>
                <asp:ObjectDataSource ID="ODSReporteLog3" runat="server" SelectMethod="GetReporteLogs3" TypeName="ReporteLogBLL" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="fechaini" Type="String" />
                        <asp:Parameter Name="fechafin" Type="String" />
                        <asp:Parameter Name="username" Type="String" />
                        <asp:Parameter Name="ActividadLogica" Type="String" />
                    </SelectParameters>

                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="100%"></asp:Label>
                <asp:Label ID="MyLabelTemp" runat="server" Width="100%"></asp:Label><asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                    runat="server" Width="100%" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>

        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </table>

</asp:Content>
