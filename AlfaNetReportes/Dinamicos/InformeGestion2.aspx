<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="InformeGestion2.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_InformeGestion2" Title="Informe de Gestion de Documentos" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>--%>
    <%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dxwpg" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraPivotGrid.Web" tagprefix="dxpgw" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    <div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100"><ProgressTemplate>
Cargando... <asp:Image id="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif"></asp:Image>
</ProgressTemplate>
</asp:UpdateProgress><dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRegistros">
    </dxpgw:ASPxPivotGridExporter> <TABLE class="style1" style="width: 850px"><TBODY><TR><TD><dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                        <Items>
                            <dxe:ListEditItem Text="Pdf" Value="0" />
                            <dxe:ListEditItem Text="Excel" Value="1" />
                            <dxe:ListEditItem Text="Mht" Value="2" />
                            <dxe:ListEditItem Text="Rtf" Value="3" />
                            <dxe:ListEditItem Text="Text" Value="4" />
                            <dxe:ListEditItem Text="Html" Value="5" />
                        </Items>
        <ButtonStyle Width="13px">
        </ButtonStyle>
                    </dxe:ASPxComboBox> </TD><TD><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> </TD><TD style="WIDTH: 67px"><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> </TD><TD style="WIDTH: 3px">&nbsp; </TD><TD style="WIDTH: 1502px">
            Fecha Inicial:<telerik:RadDatePicker ID="telkFechaInicial" runat="server" Skin="Outlook">
                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                    ViewSelectorText="x">
                </Calendar>
                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                </DateInput>
            </telerik:RadDatePicker>
            </TD>
    <td style="width: 1502px">
        Fecha Final:
            <telerik:RadDatePicker ID="telkFechaFinal" runat="server" Skin="Outlook">
                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                    ViewSelectorText="x">
                </Calendar>
                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                </DateInput>
            </telerik:RadDatePicker>
    </td>
    <td style="width: 1502px">
        <strong>Buscar: </strong>
        <asp:ImageButton ID="imgBtBuscar" runat="server" AlternateText="Iniciar busqueda por fechas"
                Height="24px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif" OnClick="imgBtBuscar_Click" /></td>
</TR></TBODY></TABLE>
<dxwpg:ASPxPivotGrid id="ConsultaRegistros" runat="server" Width="800px" DataSourceID="AlfaWeb" EnableCallbackCompression="True">

<Prefilter Enabled="False"></Prefilter>
<Fields>
<dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoNumero" Area="RowArea"
                            AreaIndex="0" Caption="Radicado" >
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="PivotGridField1" GroupIndex="0"
                            InnerGroupIndex="0" Area="RowArea" AreaIndex="1" UnboundFieldName="fieldRadicadoFecha"
                            Caption="F. Radicacion">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="RadicadoFechaVencimiento" ID="fieldRadicadoFechaVencimiento"
                            GroupIndex="0" InnerGroupIndex="1" Area="RowArea" AreaIndex="2" GroupInterval="Date"
                            UnboundFieldName="fieldRadicadoFechaVencimiento" Caption="F. Vencimiento">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldRadicadoProcedencia"
                            GroupIndex="0" InnerGroupIndex="2" Area="RowArea" AreaIndex="3" Caption="Procedencia">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldRadicadoNaturaleza" GroupIndex="0"
                            InnerGroupIndex="3" Area="RowArea" AreaIndex="4" Caption="Naturaleza">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="RadicadoDetalle" ID="fieldRadicadoDetalle" GroupIndex="0"
                            InnerGroupIndex="4" Area="RowArea" AreaIndex="5" Caption="Detalle">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoPasoFinal" ID="fieldRadicadoMaxPaso"
                            GroupIndex="0" InnerGroupIndex="5" Area="RowArea" AreaIndex="6" UnboundFieldName="fieldRadicadoMaxPaso"
                            Caption="Paso Final">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldRespuestaTipo" GroupIndex="0"
                            InnerGroupIndex="6" Area="RowArea" AreaIndex="7" Caption="Serie">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoPaso" ID="FieldWFMovimientoPaso" GroupIndex="0"
                            InnerGroupIndex="7" Area="RowArea" AreaIndex="8" Caption="MovimientoPaso">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="FechaMovimiento" ID="FieldWFMovimientoFecha" GroupIndex="0"
                            InnerGroupIndex="8" Area="RowArea" AreaIndex="9" Caption="FechaMovimiento">
                        </dxwpg:PivotGridField>

                        <dxwpg:PivotGridField FieldName="WFAccionNombre" ID="FieldWFAccion" GroupIndex="0"
                            InnerGroupIndex="9" Area="RowArea" AreaIndex="10" Caption="Accion">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DependenciaNomOrigen" ID="fieldDependenciaOrigen"
                            GroupIndex="0" InnerGroupIndex="10" Area="RowArea" AreaIndex="11" Caption="DependenciaOrigen">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DependenciaNomDestino" ID="fieldDependenciaDestino"
                            GroupIndex="0" InnerGroupIndex="11" Area="RowArea" AreaIndex="12" Caption="DependenciaDestino">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DiasVencimiento" ID="fieldRespuestaDV" Area="RowArea"
                             Caption="DV." GroupIndex="0" InnerGroupIndex="12" AreaIndex="13">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="Respuesta" ID="fieldRespuestaNumero" Area="RowArea"
                            InnerGroupIndex="13" AreaIndex="14" Caption="Respuesta">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="FechaRespuesta" ID="field" Area="RowArea" InnerGroupIndex="14" AreaIndex="15"
                            Caption="F. Respuesta">
                        </dxwpg:PivotGridField>
                        </Fields>

<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<CustomizationFieldsHeaderStyle>
<Paddings PaddingLeft="12px" PaddingRight="6px"></Paddings>
</CustomizationFieldsHeaderStyle>
</Styles>

<OptionsData CaseSensitive="False"></OptionsData>

<OptionsView DataHeadersDisplayMode="Popup" ShowContextMenus="False" ShowColumnTotals="False" ShowRowTotals="False" ShowColumnGrandTotals="False" ShowRowGrandTotals="False" ShowDataHeaders="False" ShowFilterHeaders="False" ShowColumnHeaders="False" ShowRowHeaders="False" DrawFocusedCellRect="False" ShowFilterSeparatorBar="False"></OptionsView>

<OptionsChartDataSource ChartDataVertical="False" ShowColumnCustomTotals="False" ShowColumnGrandTotals="False" ShowColumnTotals="False" ShowRowCustomTotals="False" ShowRowGrandTotals="False" ShowRowTotals="False"></OptionsChartDataSource>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<FieldValueCollapsed Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png"></FieldValueCollapsed>

<FieldValueExpanded Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png"></FieldValueExpanded>

<HeaderSortDown Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png"></HeaderSortDown>

<HeaderSortUp Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png"></HeaderSortUp>

<SortByColumn Height="7px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png"></SortByColumn>
</Images>
<Groups>
<dxwpg:PivotGridWebGroup></dxwpg:PivotGridWebGroup>
</Groups>

<OptionsCustomization AllowDrag="False" AllowExpand="False" AllowSortBySummary="False"></OptionsCustomization>

<OptionsPager>
<Summary AllPagesText="Paginas: {0} - {1} ({2} Documentos pendientes)" Text="Pagina {0} of {1} ({2} Documentos pendientes)"></Summary>
</OptionsPager>
</dxwpg:ASPxPivotGrid><asp:SqlDataSource id="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="Radicado_ReadRadicadoInformeGestion2" SelectCommandType="StoredProcedure" onselecting="AlfaWeb_Selecting"><SelectParameters>
    <asp:ControlParameter ControlID="telkFechaInicial" DbType="DateTime" DefaultValue="01/01/2011"
        Name="WFMovimientoFecha" PropertyName="SelectedDate" />
    <asp:ControlParameter ControlID="telkFechaFinal" DbType="DateTime" DefaultValue="31/12/2011"
        Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
</SelectParameters>
</asp:SqlDataSource> 
</contenttemplate>
       
            <Triggers>
<asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="imgBtBuscar" EventName="Click" />
</Triggers>
       
        </asp:UpdatePanel>
    
    </div>
  
</asp:Content>
