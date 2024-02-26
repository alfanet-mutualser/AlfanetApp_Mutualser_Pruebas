<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConsultaGTRecibida.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_ConsultaGTRecibida" Title="Gestion de Tareas Recibidas" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1" Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dxwpg" %>--%>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dxwpg" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraPivotGrid.Web" tagprefix="dxpgw" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="100">
        <progresstemplate>
Loading...<asp:Image id="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif" __designer:wfdid="w4"></asp:Image>
</progresstemplate>
    </asp:UpdateProgress>
    <div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="243px" Text="Create series from row area values" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Checked="True"></asp:CheckBox><BR /><dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRegistros">
    </dxpgw:ASPxPivotGridExporter> <TABLE class="style1"><TBODY><TR><TD><dxe:ASPxComboBox id="listExportFormat" runat="server" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ValueType="System.String">
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
                    </dxe:ASPxComboBox> </TD><TD><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                    </dxe:ASPxButton> </TD><TD><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                    </dxe:ASPxButton> </TD><TD></TD><TD style="WIDTH: 3px">Grupos Naturalezas</TD><TD style="WIDTH: 3px"><dxe:ASPxComboBox id="ASPxComboBox1" runat="server" __designer:wfdid="w1" AutoPostBack="True" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ValueType="System.String" SelectedIndex="0" OnDataBound="ASPxComboBox1_DataBound" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged"><Items>
<dxe:ListEditItem Text="TODAS" Value="TODAS"></dxe:ListEditItem>
<dxe:ListEditItem Text="PQR" Value="PQR"></dxe:ListEditItem>
<dxe:ListEditItem Text="TRAMITES" Value="TRA"></dxe:ListEditItem>
<dxe:ListEditItem Text="DERECHOS DE PETICION" Value="DERE"></dxe:ListEditItem>
</Items>

<ButtonStyle Width="13px"></ButtonStyle>
</dxe:ASPxComboBox></TD><TD style="WIDTH: 3px"></TD><TD style="WIDTH: 3px">Año&nbsp;a&nbsp;consultar</TD><TD style="WIDTH: 3px"><dxe:ASPxComboBox id="ASPxComboBox2" runat="server" DataSourceID="SqlDataSource1" __designer:wfdid="w3" AutoPostBack="True" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ValueType="System.String" OnDataBound="ASPxComboBox2_DataBound" OnSelectedIndexChanged="ASPxComboBox2_SelectedIndexChanged" TextField="Expr1" ValueField="Expr1">
<ButtonStyle Width="13px">
</ButtonStyle>
</dxe:ASPxComboBox> <asp:SqlDataSource id="SqlDataSource1" runat="server" __designer:wfdid="w2" SelectCommand="SELECT DISTINCT YEAR(WFMovimientoFecha) AS Expr1 FROM Radicado ORDER BY Expr1" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"></asp:SqlDataSource></TD></TR></TBODY></TABLE><dxwpg:ASPxPivotGrid id="ConsultaRegistros" runat="server" Width="900px" DataSourceID="AlfaWeb" OnPreRender="ConsultaRegistros_PreRender" EnableCallBacks="False"><Fields>
<dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoCodigo" Area="FilterArea" AreaIndex="0" Caption="Radicado" SummaryType="Count"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldWFMovimientoFecha" Area="ColumnArea" AreaIndex="0" GroupInterval="DateMonth" UnboundFieldName="fieldWFMovimientoFecha" Caption="Fecha Radicado"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldProcedenciaNombre" Area="FilterArea" AreaIndex="1" Caption="Procedencia"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="DependenciaNombre" ID="fieldDependenciaNombre" Area="FilterArea" AreaIndex="2" Visible="False" Caption="Dependencia"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="Respuesta" ID="fieldRespuesta" Area="FilterArea" AreaIndex="0" Visible="False"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="WFAccionNombre" ID="fieldWFAccionNombre" Area="FilterArea" AreaIndex="2" Visible="False" Caption="Accion"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="ExpedienteNombre" ID="fieldExpedienteNombre" Area="FilterArea" AreaIndex="2" Caption="Expediente"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldSerieNombre" Area="FilterArea" AreaIndex="3" Caption="Serie"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldNaturalezaNombre" Area="RowArea" AreaIndex="0" Caption="Naturaleza"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoCodigo2" Area="DataArea" AreaIndex="0" Caption="Radicado Codigo Pivot" SummaryType="Count"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldYearGT" Area="ColumnArea" AreaIndex="0" Visible="False" GroupInterval="DateYear" UnboundFieldName="field" Caption="A&#241;os Radicado"></dxwpg:PivotGridField>
</Fields>

<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<CustomizationFieldsHeaderStyle>
<Paddings PaddingLeft="12px" PaddingRight="6px"></Paddings>
</CustomizationFieldsHeaderStyle>
</Styles>

<OptionsView ShowGrandTotalsForSingleValues="True"></OptionsView>

<OptionsChartDataSource ShowColumnCustomTotals="False" ShowColumnGrandTotals="False" ShowColumnTotals="False" ShowRowCustomTotals="False" ShowRowGrandTotals="False" ShowRowTotals="False"></OptionsChartDataSource>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<FieldValueCollapsed Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png"></FieldValueCollapsed>

<FieldValueExpanded Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png"></FieldValueExpanded>

<HeaderSortDown Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png"></HeaderSortDown>

<HeaderSortUp Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png"></HeaderSortUp>

<SortByColumn Height="7px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png"></SortByColumn>
</Images>
</dxwpg:ASPxPivotGrid> <asp:SqlDataSource id="AlfaWeb" runat="server" SelectCommand="Radicado_ConsultasGestionTareasDinamico" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommandType="StoredProcedure"><SelectParameters>
<asp:Parameter DbType="DateTime" DefaultValue="01/01/2010" Name="WFMovimientoFecha"></asp:Parameter>
<asp:Parameter DbType="DateTime" DefaultValue="31/12/2010" Name="WFMovimientoFecha1"></asp:Parameter>
</SelectParameters>
</asp:SqlDataSource><BR /><dxchartsui:WebChartControl id="WebChartControl1" runat="server" Width="900px" DataSourceID="ConsultaRegistros" __designer:errorcontrol="No se pudo crear el diseñador 'System.Windows.Forms.Design.ComponentDocumentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'" SeriesDataMember="Series" DiagramTypeName="XYDiagram" AlternateText="Grafico de Consultas Dinamicas Documentos Recibidos" AppearanceName="Pastel Kit" Height="400px">
<SeriesTemplate LabelTypeName="SideBySideBarSeriesLabel" PointOptionsTypeName="PointOptions" SeriesViewTypeName="SideBySideBarSeriesView">
<View HiddenSerializableString="to be serialized"></View>

<Label HiddenSerializableString="to be serialized" LineVisible="True" OverlappingOptionsTypeName="OverlappingOptions">
<FillStyle FillOptionsTypeName="SolidFillOptions">
<Options HiddenSerializableString="to be serialized"></Options>
</FillStyle>
</Label>

<PointOptions HiddenSerializableString="to be serialized"></PointOptions>

<LegendPointOptions HiddenSerializableString="to be serialized"></LegendPointOptions>
</SeriesTemplate>

<Diagram>
<AxisX VisibleInPanesSerializable="-1">
<Range SideMarginsEnabled="True"></Range>
</AxisX>

<AxisY VisibleInPanesSerializable="-1">
<Range SideMarginsEnabled="True"></Range>
</AxisY>
</Diagram>

<FillStyle FillOptionsTypeName="SolidFillOptions">
<Options HiddenSerializableString="to be serialized"></Options>
</FillStyle>

<Legend MarkerSize="15, 10" Font="Tahoma, 7pt" SpacingVertical="1" SpacingHorizontal="0" MaxHorizontalPercentage="30"></Legend>
</dxchartsui:WebChartControl> 
</contenttemplate>
       
        </asp:UpdatePanel>
        <br />
    
    </div>
</asp:Content>

