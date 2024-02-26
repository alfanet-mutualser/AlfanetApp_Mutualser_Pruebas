<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConsultasEnviada.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_ConsultasEnviada" Title="Consulta Dinamica Enviada" %>

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
Loading...<asp:Image id="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif" __designer:wfdid="w5"></asp:Image> 
</progresstemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="243px" Text="Create series from row area values" __designer:dtid="844424930131974" __designer:wfdid="w11" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" Checked="True"></asp:CheckBox> <dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" __designer:dtid="844424930131976" __designer:wfdid="w12" ASPxPivotGridID="ConsultaRegistros">
    
</dxpgw:ASPxPivotGridExporter><DIV __designer:dtid="844424930131977"><TABLE class="style1" __designer:dtid="844424930131978"><TBODY><TR __designer:dtid="844424930131979"><TD __designer:dtid="844424930131980"><dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                        <Items __designer:dtid="844424930131982">
                            <dxe:ListEditItem __designer:dtid="844424930131983" Text="Pdf" Value="0"  />
                            <dxe:ListEditItem __designer:dtid="844424930131984" Text="Excel" Value="1"  />
                            <dxe:ListEditItem __designer:dtid="844424930131985" Text="Mht" Value="2"  />
                            <dxe:ListEditItem __designer:dtid="844424930131986" Text="Rtf" Value="3"  />
                            <dxe:ListEditItem __designer:dtid="844424930131987" Text="Text" Value="4"  />
                            <dxe:ListEditItem __designer:dtid="844424930131988" Text="Html" Value="5"  />
                        </Items>
                    </dxe:ASPxComboBox> </TD><TD __designer:dtid="844424930131989"><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                    </dxe:ASPxButton> </TD><TD __designer:dtid="844424930131991"><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                    </dxe:ASPxButton> </TD><TD style="WIDTH: 3px">&nbsp;&nbsp; </TD><TD style="WIDTH: 206px">Grupos Naturalezas</TD><TD style="WIDTH: 3px"><dxe:ASPxComboBox id="ASPxComboBox1" runat="server" __designer:wfdid="w1" AutoPostBack="True" ValueType="System.String" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged" OnDataBound="ASPxComboBox1_DataBound" SelectedIndex="0"><Items>
<dxe:ListEditItem Text="TODAS" Value="TODAS"></dxe:ListEditItem>
<dxe:ListEditItem Text="PQR" Value="PQR"></dxe:ListEditItem>
<dxe:ListEditItem Text="TRAMITES" Value="TRA"></dxe:ListEditItem>
<dxe:ListEditItem Text="DERECHOS DE PETICION" Value="DERE"></dxe:ListEditItem>
</Items>

<ButtonStyle Width="13px"></ButtonStyle>
</dxe:ASPxComboBox></TD><TD style="WIDTH: 3px">&nbsp;</TD><TD style="WIDTH: 2px">Año&nbsp;a&nbsp;consultar</TD><TD style="WIDTH: 3px"><dxe:ASPxComboBox id="ASPxComboBox2" runat="server" DataSourceID="SqlDataSource1" __designer:wfdid="w3" AutoPostBack="True" ValueType="System.String" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" OnSelectedIndexChanged="ASPxComboBox2_SelectedIndexChanged" OnDataBound="ASPxComboBox2_DataBound" ValueField="Expr1" TextField="Expr1">
<ButtonStyle Width="13px">
</ButtonStyle>
</dxe:ASPxComboBox><asp:SqlDataSource id="SqlDataSource1" runat="server" __designer:wfdid="w57" SelectCommand="SELECT DISTINCT YEAR(WFMovimientoFecha) AS Expr1 FROM Registro ORDER BY Expr1" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"></asp:SqlDataSource></TD></TR></TBODY></TABLE><dxwpg:ASPxPivotGrid id="ConsultaRegistros" runat="server" Width="900px" DataSourceID="AlfaWeb" __designer:dtid="844424930131994" __designer:wfdid="w16" OnPreRender="ConsultaRegistros_PreRender" EnableCallBacks="False"><Fields __designer:dtid="844424930131995">
<dxwpg:PivotGridField FieldName="RegistroCodigo" ID="fieldRegistroCodigo" Area="FilterArea" AreaIndex="4" Caption="Registro" SummaryType="Count" __designer:dtid="844424930131996"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldWFMovimientoFecha" Area="ColumnArea" AreaIndex="0" GroupInterval="DateMonth" UnboundFieldName="fieldWFMovimientoFecha" Caption="Fecha Registro" __designer:dtid="844424930131997"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="Destino" ID="fieldDestino" Area="FilterArea" AreaIndex="1" Caption="Destino" __designer:dtid="844424930131998"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldNaturalezaNombre" Area="RowArea" AreaIndex="0" Caption="Naturaleza" __designer:dtid="844424930132001"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="MedioNombre" ID="fieldMedioNombre" Area="FilterArea" AreaIndex="2" Caption="Medio" __designer:dtid="844424930132002"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="ExpedienteNombre" ID="fieldExpedienteNombre" Area="FilterArea" AreaIndex="3" Caption="Expediente" __designer:dtid="844424930132003"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldSerieNombre" Area="FilterArea" AreaIndex="0" Caption="Serie" __designer:dtid="844424930132004"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="RegistroCodigo" ID="fieldRegistroCodigoPivot" Area="DataArea" AreaIndex="0" Caption="Registro Pivot" SummaryType="Count" __designer:dtid="844424930132005"></dxwpg:PivotGridField>
<dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldYearRegistro" Area="ColumnArea" AreaIndex="0" Visible="False" GroupInterval="DateYear" UnboundFieldName="field" Caption="A&#241;o Registro"></dxwpg:PivotGridField>
</Fields>

<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" __designer:dtid="844424930132007">
<CustomizationFieldsHeaderStyle __designer:dtid="844424930132008">
<Paddings PaddingLeft="12px" PaddingRight="6px" __designer:dtid="844424930132009"></Paddings>
</CustomizationFieldsHeaderStyle>
</Styles>

<OptionsView ShowGrandTotalsForSingleValues="True" __designer:dtid="844424930132006"></OptionsView>

<OptionsChartDataSource ShowColumnCustomTotals="False" ShowColumnGrandTotals="False" ShowColumnTotals="False" ShowRowCustomTotals="False" ShowRowGrandTotals="False" ShowRowTotals="False"></OptionsChartDataSource>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/" __designer:dtid="844424930132010">
<FieldValueCollapsed Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png" __designer:dtid="844424930132011"></FieldValueCollapsed>

<FieldValueExpanded Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png" __designer:dtid="844424930132012"></FieldValueExpanded>

<HeaderSortDown Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png" __designer:dtid="844424930132013"></HeaderSortDown>

<HeaderSortUp Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png" __designer:dtid="844424930132014"></HeaderSortUp>

<SortByColumn Height="7px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png" __designer:dtid="844424930132015"></SortByColumn>
</Images>
</dxwpg:ASPxPivotGrid><BR /><asp:SqlDataSource id="AlfaWeb" runat="server" __designer:dtid="844424930132016" __designer:wfdid="w18" SelectCommand="Registro_ConsultasRegistroDinamico" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommandType="StoredProcedure"><SelectParameters>
<asp:Parameter DbType="DateTime" DefaultValue="01/01/2010" Name="WFMovimientoFecha"></asp:Parameter>
<asp:Parameter DbType="DateTime" DefaultValue="31/12/2010" Name="WFMovimientoFecha1"></asp:Parameter>
</SelectParameters>
</asp:SqlDataSource> <%-- <dxchartsui:WebChartControl id="WebChartControl1" runat="server" Width="900px" DataSourceID="ConsultaRegistros" AppearanceName="Pastel Kit" AlternateText="Grafico de Consultas Dinamicas Documentos Recibidos" DiagramTypeName="XYDiagram" SeriesDataMember="Series" Height="400px" ShowLoadingPanel="False">
<SeriesTemplate LabelTypeName="FullStackedBarSeriesLabel" PointOptionsTypeName="FullStackedBarPointOptions" SeriesViewTypeName="FullStackedBarSeriesView">
<SeriesTemplate LabelTypeName="SideBySideBarSeriesLabel" PointOptionsTypeName="PointOptions" SeriesViewTypeName="SideBySideBarSeriesView">
<View HiddenSerializableString="to be serialized"></View>

<Label HiddenSerializableString="to be serialized" OverlappingOptionsTypeName="OverlappingOptions">
<FillStyle FillOptionsTypeName="SolidFillOptions">
<Options HiddenSerializableString="to be serialized"></Options>
</FillStyle>
</Label>

<PointOptions HiddenSerializableString="to be serialized"></PointOptions>

<LegendPointOptions HiddenSerializableString="to be serialized"></LegendPointOptions>
</SeriesTemplate>

<Diagram>
<AxisX Reverse="True" VisibleInPanesSerializable="-1">
<Range Auto="False" MinValueSerializable="A" MaxValueSerializable="E" SideMarginsEnabled="True"></Range>
</AxisX>

<AxisY VisibleInPanesSerializable="-1">
<Range SideMarginsEnabled="True"></Range>

<NumericOptions Precision="0"></NumericOptions>
</AxisY>
</Diagram>

<FillStyle FillOptionsTypeName="SolidFillOptions">
<Options HiddenSerializableString="to be serialized"></Options>
</FillStyle>
</dxchartsui:WebChartControl> --%><dxchartsui:WebChartControl style="TEXT-ALIGN: center" id="WebChartControl1" runat="server" Width="900px" DataSourceID="ConsultaRegistros" __designer:errorcontrol="No se pudo crear el diseñador 'System.Windows.Forms.Design.ComponentDocumentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'" ShowLoadingPanel="False" SeriesDataMember="Series" DiagramTypeName="XYDiagram" AlternateText="Grafico de Consultas Dinamicas Documentos Recibidos" AppearanceName="Pastel Kit" Height="500px">
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
<AxisX Reverse="True" VisibleInPanesSerializable="-1">
<Range Auto="False" MinValueSerializable="A" MaxValueSerializable="E" SideMarginsEnabled="True"></Range>
</AxisX>

<AxisY VisibleInPanesSerializable="-1">
<Range SideMarginsEnabled="True"></Range>

<NumericOptions Precision="0"></NumericOptions>
</AxisY>
</Diagram>

<FillStyle FillOptionsTypeName="SolidFillOptions">
<Options HiddenSerializableString="to be serialized"></Options>
</FillStyle>

<Legend MarkerSize="15, 10" SpacingVertical="1" SpacingHorizontal="0" MaxHorizontalPercentage="30"></Legend>
</dxchartsui:WebChartControl> </DIV>
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;<br />
    <br />
</asp:Content>

