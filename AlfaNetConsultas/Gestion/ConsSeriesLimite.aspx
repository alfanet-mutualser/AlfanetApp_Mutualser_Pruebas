<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConsSeriesLimite.aspx.cs" Inherits="AlfaNetConsultas_Gestion_ConsSeriesLimite" %>

<%@ Import Namespace="System.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <script language="javascript" type="text/javascript">

            function url(evt, Grupo) {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                var Rad = src.innerText || src.innerHTML;
                hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            }
            function urlInt(evt, Grupo) {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                var Rad = src.innerText || src.innerHTML;
                hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            }
            //Respuesta
            function urlRpta(evt) {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

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
            //Visor de Imagenes Archivo
            function VImagenesArc(evt, NumeroDocumento, CodArchivo, Grupo) {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&GrupoPadreCodigo=101&Admon=S&CZ=' + CodArchivo + '&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

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

            // ]]>
        </script>

        <table style="font-size: 8pt; width: 100%;">
            <tr>
                <td style="text-align: center; height: 315px;">
                    <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                        FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected" SuppressHeaderPostbacks="true"
                        TransitionDuration="250" Width="100%">
                        <Panes>
                            <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                                <Header>
                                    <a class="accordionLink" href="">Consulta Series.:</a>
                                </Header>
                                <Content>
                                    <table style="width: 100%; text-align: left"
                                        forecolor="White">
                                        <tbody>
                                            <tr>
                                                <td
                                                    style="width: 100%; color: white; height: 16px; background-color: #507cd1; text-align: center">Consulta de Documentos por Serie</td>
                                            </tr>
                                            <tr>
                                                <td
                                                    style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="ChBFechaReg" runat="server" Text="Entre Fechas de Documento" Width="185px"
                                                                AutoPostBack="True" OnCheckedChanged="ChBFechaRad_CheckedChanged" />
                                                            <br />
                                                            <cc1:CalendarExtender ID="CalendarFinal" runat="server" PopupButtonID="ImgCalendarFinal"
                                                                TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy">
                                                            </cc1:CalendarExtender>
                                                            <cc1:CalendarExtender ID="CalendarInicial" runat="server" PopupButtonID="ImgCalendarInicial"
                                                                TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy">
                                                            </cc1:CalendarExtender>
                                                            <asp:Label ID="LblFechaInicial" runat="server" Text="Fecha Inicial" Width="70px"
                                                                Visible="False"></asp:Label>
                                                            <asp:TextBox ID="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                            <asp:Image ID="ImgCalendarInicial" runat="server" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png"
                                                                Width="27px" Visible="False" />
                                                            <asp:Label ID="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label>
                                                            <asp:TextBox ID="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                            <asp:Image ID="ImgCalendarFinal" runat="server" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png"
                                                                Width="27px" Visible="False" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ChBFechaReg" EventName="CheckedChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td style="width: 100%; background-color: #eff3fb">
                                                    <asp:UpdatePanel ID="UpdatePanelDestino" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="ChBDestino" runat="server" Width="377px" Text="Por Destinatario o Dependencia Destino ...(Seleccione o ingrese criterio)" OnCheckedChanged="ChBDestino_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                                            <cc1:PopupControlExtender ID="PopupControlDestino" runat="server" PopupControlID="PnlDestino" TargetControlID="TxtBDestino" Position="Right">
                                                            </cc1:PopupControlExtender>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteDestino" runat="server" TargetControlID="TxtBDestino" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetDependenciaByTextnull" ServicePath="../../AutoComplete.asmx">
                                                            </cc1:AutoCompleteExtender>
                                                            <asp:RadioButtonList ID="RadioButtonList1" TabIndex="8" runat="server" Width="98px" Visible="false" Font-Size="8pt" ValidationGroup="1" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">Interno</asp:ListItem>
                                                                <asp:ListItem Value="0">Externo</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:Label ID="LblDestino" runat="server" Width="60px" Visible="False" Text="Destino"></asp:Label>
                                                            <asp:TextBox ID="TxtBDestino" runat="server" Width="400px" Visible="False" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox>
                                                            <asp:Panel Style="left: 21px" ID="PnlDestino" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                                <div>
                                                                    <asp:TreeView ID="TreeVDependencia" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
                                                                        <ParentNodeStyle Font-Bold="False" />
                                                                        <HoverNodeStyle Font-Underline="True" />
                                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                        <Nodes>
                                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                                                                Value="0"></asp:TreeNode>
                                                                        </Nodes>
                                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                                    </asp:TreeView>
                                                                    <asp:TreeView ID="TreeVProceso" runat="server" Visible="False" ShowLines="True" ExpandDepth="0">
                                                                        <ParentNodeStyle Font-Bold="False" />
                                                                        <HoverNodeStyle Font-Underline="True" />
                                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                        <Nodes>
                                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Proceso..."
                                                                                Value="0"></asp:TreeNode>
                                                                        </Nodes>
                                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                                    </asp:TreeView>
                                                                </div>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ChBDestino" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td
                                                    style="width: 100%; background-color: #ffffff">
                                                    <asp:UpdatePanel ID="UpdatePanelTiempo" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="ChkTiempoSerie" runat="server" Width="200px" Text="Por Tiempo de Serie" OnCheckedChanged="ChkTiempoSerie_CheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                                            <asp:Label ID="LblTiempoSerie" runat="server" Width="150px" Visible="False" Text="Tiempo[años] Mayor o igual a:"></asp:Label>
                                                            <asp:TextBox ID="TxtTiempoSerie" runat="server" Width="200px" Font-Size="8pt" Visible="False" ></asp:TextBox>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ChkTiempoSerie" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td
                                                    style="width: 100%; background-color: #ffffff">
                                                    <asp:UpdatePanel ID="UpdatePanelImg" runat="server"  UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="cbxPorImagen" runat="server" Text="Por Estado Documentos en serie" AutoPostBack="True" OnCheckedChanged="cbxPorImagen_CheckedChanged" /><br />
                                                            <asp:RadioButtonList ID="RblVencido" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                                <asp:ListItem Value="1">Vencidos</asp:ListItem>
                                                                <asp:ListItem Value="2">Vigentes</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                           
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="cbxPorImagen" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td
                                                    style="width: 100%; background-color: #ffffff">
                                                    <asp:UpdatePanel ID="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="ChBNroSerie" runat="server" Text="Por Serie" Width="100%"
                                                                OnCheckedChanged="ChBNroSerie_CheckedChanged" AutoPostBack="True" />                                                         <%--  
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="6px" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtNroSerieInicial">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="LblNroSerieInicial" runat="server" Text="Serie" Width="70px"
                                                                Visible="False"></asp:Label>
                                                            <asp:TextBox ID="TxtNroSerieInicial" runat="server" Width="350px" CssClass="TxtAutoComplete" Visible="False"></asp:TextBox>
                                                            <%--<asp:HiddenField ID="HFDependenciaConsulta" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="HFCodigoSeleccionado" runat="server"></asp:HiddenField>
                                                            <cc1:AutoCompleteExtender ID="ACSerie" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtNroSerieInicial" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000" ContextKey="311">--%>
                                                                                <%--</cc1:AutoCompleteExtender>
                                                                                <cc1:TextBoxWatermarkExtender ID="TBWExpediente1" WatermarkText="Seleccione una Serie ..." runat="server" TargetControlID="TxtNroSerieInicial">
                                                                                </cc1:TextBoxWatermarkExtender>--%>
                                         <br />
                                         <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" DataSourceID="ODSBuscar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False" KeyFieldName="SerieCodigo">
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
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieCodigo" ReadOnly="True" VisibleIndex="1" >
                                                                    <DataItemTemplate>
                                                                        <asp:LinkButton ID="LBtnExpediente" OnClick="LBtnExpediente_Click" runat="server" Width="40px" Text='<%# Bind("SerieCodigo") %>' CommandName="Select" ></asp:LinkButton>
                                                                    </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieNombre" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieTiempo" Caption="Tiempo" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
                                                            </Columns>

                                                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

                                                            <StylesEditors>
                                                                <ProgressBar Height="25px"></ProgressBar>
                                                            </StylesEditors>
                                                        </dxwgv:ASPxGridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ChBNroSerie" EventName="CheckedChanged" />
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
                                                                                    CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar"></asp:LinkButton>
                                                                            </asp:TableCell>
                                                                            <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                                                <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                                    CssClass="CommandButton" OnClick="BtnNuevo_Click" com TabIndex="24" Text="Nueva Busqueda" CommandArgument="Select"></asp:LinkButton>
                                                                            </asp:TableCell>
                                                                        </asp:TableRow>
                                                                    </asp:Table>
                                                                </td>
                                                                <td></td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                        <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
<%--                                    <table>
                                            <tr>
                                                 <td>
                                                     <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" DataSourceID="ODSBuscar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False" KeyFieldName="SerieCodigo">
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
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieCodigo" ReadOnly="True" VisibleIndex="1">
                                                                    <DataItemTemplate>
                                                                        <asp:LinkButton ID="LBtnExpediente" OnClick="LBtnExpediente_Click" runat="server" Width="40px" Text='<%# Bind("SerieCodigo") %>' CommandName="Select"></asp:LinkButton>
                                                                    </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieNombre" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="SerieTiempo" Caption="Tiempo" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
                                                            </Columns>

                                                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

                                                            <StylesEditors>
                                                                <ProgressBar Height="25px"></ProgressBar>
                                                            </StylesEditors>
                                                        </dxwgv:ASPxGridView>
                                              </td>
                                            </tr>
                                    </table>--%>
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
                                                    <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
                                                    </dxwgv:ASPxGridViewExporter>
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
                                                                    <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                    </dxe:ASPxButton>
                                                                </td>
                                                                <td style="width: 65px">
                                                                    <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                    </dxe:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <dxwgv:ASPxGridView ID="ASPxGVExpediente" runat="server" Width="100%" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False" OnHtmlRowPrepared="ASPxGVExpediente_HtmlRowPrepared">
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
                                                                    <%--<dxwgv:GridViewDataTextColumn FieldName="id_res" ReadOnly="True" Caption="AutoID" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False"></EditFormSettings>
                                                                    </dxwgv:GridViewDataTextColumn>--%>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="NroDoc" Caption="Nro Documento" VisibleIndex="0">
                                                                        <DataItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="XX-Small" Text='<%# Eval("NroDoc") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                                        </DataItemTemplate>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataDateColumn FieldName="MovimientoFecha" Caption="Fecha" VisibleIndex="2"></dxwgv:GridViewDataDateColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="Detalle" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="GrupoNombre" Caption="Grupo" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="SerieNombre" Caption="Serie" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="SerieTiempo" Caption="Serie_Tiempo" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="DocumentoLimite" Caption="Documento_Limite" VisibleIndex="6"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="DiasAplicacionTRD" Caption="DiasAplicacionTRD" VisibleIndex="7"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn ReadOnly="True" VisibleIndex="8" Caption="Opciones">
                                                                        <DataItemTemplate>
                                                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Font-Size="XX-Small" Text="Imagenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                                        </DataItemTemplate>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                </Columns>

                                                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

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
                        SelectMethod="GetRegistrosSeries" TypeName="DSWorkFlowTableAdapters.WFMov_ConsultaSeriesTableAdapter">
                        <SelectParameters>
                                <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                                <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                                <asp:Parameter Name="SerieCodigo" Type="String"/> 
<%--                            <asp:Parameter Name="Destino" Type="String"/> 
                                <asp:Parameter Name="DepCodDestino" Type="String"/> 
                                <asp:Parameter Name="Vencidos" Type="String"/>  --%>                           
                                <asp:Parameter Name="TiempoSerie" Type="String"/>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                        Width="100%"></asp:Label>
                    <asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                        runat="server" Width="100%" Height="1px" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
                </td>
            </tr>
        </table>

        <%--        <table style="font-size: 8pt; width: 100%;">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
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
                        </ContentTemplate>
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
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td
                                                    style="width: 20%" colspan="1"></td>
                                                <td
                                                    style="height: 318px" colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanelExpediente" runat="server" RenderMode="Inline">
                                                        <ContentTemplate>
                                                            <table style="width: 600px; text-align: left" forecolor="White">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 600px; color: white; height: 16px; background-color: #507cd1; text-align: center">Consulta de Documentos por Serie</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 600px; background-color: #eff3fb; text-align: center" colspan="3">
                                                                            <table style="width: 100%; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 57px; height: 8px"></td>
                                                                                        <td style="width: 57px; height: 8px"><strong><em><span style="font-family: Poor Richard"></span></em></strong>
                                                                                            <asp:Label ID="LblFindBy" runat="server" Width="84px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></td>
                                                                                        <td style="vertical-align: middle; width: 115px; height: 8px; text-align: center">
                                                                                            <asp:RadioButtonList ID="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Font-Italic="False" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged">
                                                                                                <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                                                                                <asp:ListItem Value="2">Codigo</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                        <td style="vertical-align: middle; width: 115px; height: 8px; text-align: center"></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 489px; height: 16px; background-color: #ffffff; text-align: center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 489px; background-color: #eff3fb; text-align: center">&nbsp;<asp:CheckBox ID="CBBusquedaExacta" runat="server" Font-Size="Smaller" Visible="False" ForeColor="RoyalBlue" Text="Busqueda Exacta" Font-Bold="True"></asp:CheckBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; background-color: #ffffff; text-align: center">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="6px" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtExpediente">*</asp:RequiredFieldValidator>
                                                                            <asp:Label ID="LblExpedienteS" runat="server" Width="100px" BackColor="CornflowerBlue" ForeColor="White" Text="Serie" Font-Bold="True" BorderStyle="Solid" BorderWidth="2px" BorderColor="#B5C7DE"></asp:Label>
                                                                            <asp:TextBox ID="TxtExpediente" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox>
                                                                            <asp:ImageButton ID="ImgBtnFind" OnClick="ImgBtnFind_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CommandName="Select"></asp:ImageButton><asp:HiddenField ID="HFDependenciaConsulta" runat="server"></asp:HiddenField>
                                                                            <asp:HiddenField ID="HFCodigoSeleccionado" runat="server"></asp:HiddenField>
                                                                            <cc1:AutoCompleteExtender ID="ACExpediente" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtExpediente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionInterval="1000" ContextKey="311">
                                                                            </cc1:AutoCompleteExtender>
                                                                            <cc1:TextBoxWatermarkExtender ID="TBWExpediente1" WatermarkText="Seleccione una Serie ..." runat="server" TargetControlID="TxtExpediente">
                                                                            </cc1:TextBoxWatermarkExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 485px; background-color: #eff3fb; text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 500px; color: white; height: 21px; background-color: #507cd1">&nbsp;<asp:ImageButton ID="ImgBtnNew" OnClick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png"></asp:ImageButton>
                                                                            &nbsp;
                                                                            <asp:ImageButton ID="ImgBtnCancel" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"></asp:ImageButton></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="ImgBtnFind"></asp:PostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td style="width: 20%" colspan="1"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" colspan="1"></td>
                                                <td colspan="3">
                                                    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" DataSourceID="ODSBuscar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False" KeyFieldName="SerieCodigo">
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
                                                            <dxwgv:GridViewDataTextColumn FieldName="SerieCodigo" ReadOnly="True" VisibleIndex="1">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton ID="LBtnExpediente" OnClick="LBtnExpediente_Click" runat="server" Width="40px" Text='<%# Bind("SerieCodigo") %>' CommandName="Select"></asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dxwgv:GridViewDataTextColumn>
                                                            <dxwgv:GridViewDataTextColumn FieldName="SerieNombre" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
                                                            <dxwgv:GridViewDataTextColumn FieldName="SerieTiempo" Caption="Tiempo" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
                                                        </Columns>

                                                        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

                                                        <StylesEditors>
                                                            <ProgressBar Height="25px"></ProgressBar>
                                                        </StylesEditors>
                                                    </dxwgv:ASPxGridView>
                                                </td>
                                                <td style="width: 20%" colspan="1"></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </Content>
                            </cc1:AccordionPane>
                            <cc1:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                                <Header>
                                    <a class="accordionLink" href="">Resultados.:</a>

                                </Header>
                                <Content>
                                    <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
                                    </dxwgv:ASPxGridViewExporter>
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
                                                    <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="width: 65px">
                                                    <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                    </dxe:ASPxButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <asp:HiddenField ID="HFTipoSeleccionado" runat="server"></asp:HiddenField>
                                    <dxwgv:ASPxGridView ID="ASPxGVExpediente" runat="server" Width="100%" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False" OnHtmlRowPrepared="ASPxGVExpediente_HtmlRowPrepared">
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
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="XX-Small" Text='<%# Eval("NroDoc") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                </DataItemTemplate>
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" Caption="Fecha" VisibleIndex="3"></dxwgv:GridViewDataDateColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="Detalle" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="GrupoNombre" Caption="Grupo" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="SerieNombre" Caption="Serie" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn ReadOnly="True" VisibleIndex="6" Caption="Opciones">
                                                <DataItemTemplate>
                                                    <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Font-Size="XX-Small" Text="Imagenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                </DataItemTemplate>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

                                        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

                                        <StylesEditors>
                                            <ProgressBar Height="25px"></ProgressBar>
                                        </StylesEditors>
                                    </dxwgv:ASPxGridView>

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
        </table>--%>
    </div>
</asp:Content>


