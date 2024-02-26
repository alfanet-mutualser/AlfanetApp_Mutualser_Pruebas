<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultasRecibida.aspx.cs" Inherits="AlfanetReportes_Dinamicos_ConsultasRecibida" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

    <%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc2" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="ContentConsultasRecibida" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
        <progresstemplate>
            Loading... 
            <asp:Image id="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif">
            </asp:Image>
        </progresstemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
            <asp:CheckBox id="CheckBox1" runat="server" Width="243px" Text="Graficar los Valores de las Filas" OnCheckedChanged="CheckBox1_CheckedChanged" 
                    AutoPostBack="True" Checked="True">
            </asp:CheckBox>
            <dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRadicados">
            </dxpgw:ASPxPivotGridExporter>
            <div style="TEXT-ALIGN: center">
                <table class="style1">
                    <tbody>
                        <tr>
                            <td style="WIDTH: 173px">
                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ValueType="System.String">
                                    <Items>
                                        <dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="Mht" Value="2"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="Rtf" Value="3"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="Text" Value="4"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="Html" Value="5"></dxe:ListEditItem>
                                    </Items>

                                    <ButtonStyle Width="13px"></ButtonStyle>
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="WIDTH: 3px">
                            </td>
                            <td style="WIDTH: 206px">
                                Grupos Naturalezas
                            </td>
                            <td style="WIDTH: 3px">
                                <dxe:ASPxComboBox id="ASPxComboBox1" runat="server" AutoPostBack="True" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ValueType="System.String" 
                                        OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged" OnDataBound="ASPxComboBox1_DataBound" SelectedIndex="0">
                                    <Items>
                                        <dxe:ListEditItem Text="TODAS" Value="TODAS"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="PQR" Value="PQR"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="TRAMITES" Value="TRA"></dxe:ListEditItem>
                                        <dxe:ListEditItem Text="DERECHOS DE PETICION" Value="DERE"></dxe:ListEditItem>
                                    </Items>

                                    <ButtonStyle Width="13px"></ButtonStyle>
                                </dxe:ASPxComboBox>
                            </td>
                            <td style="WIDTH: 3px">
                                &nbsp;
                            </td>
                            <td style="WIDTH: 1px">
                                Año&nbsp;a&nbsp;consultar 
                            </td>
                            <td style="WIDTH: 3px">
                                <dxe:ASPxComboBox id="ASPxComboBox2" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" 
                                        ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                                        CssPostfix="Office2003_Blue" ValueType="System.String" OnSelectedIndexChanged="ASPxComboBox2_SelectedIndexChanged" 
                                        OnDataBound="ASPxComboBox2_DataBound" TextField="Expr1" ValueField="Expr1">
                                    <ButtonStyle Width="13px">
                                    </ButtonStyle>
                                </dxe:ASPxComboBox>
                                <asp:SqlDataSource id="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
                                        SelectCommand="SELECT DISTINCT YEAR(WFMovimientoFecha) AS Expr1 FROM Radicado ORDER BY Expr1">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                        </td>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100px; height: 36px">
                                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicial:" Width="73px">
                                        </asp:Label>
                                    </td>
                                    <td style="width: 100px; height: 36px">
                                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                            <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" runat="server"
                                                    ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td style="width: 100px; height: 36px">
                                        <asp:Label ID="Label2" runat="server" Text="Fecha Final:" Width="74px">
                                        </asp:Label>
                                    </td>
                                    <td style="width: 100px; height: 36px">
                                        <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
                                            <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" runat="server"
                                                    ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td style="width: 1014px; height: 36px">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Buscar:">
                                        </asp:Label>
                                    </td>
                                    <td style="width: 1332px; height: 36px">
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif"
                                                Width="35px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <table>
                <tbody>
                    <tr>
                        <td style="WIDTH: 621px">
                            <dxwpg:ASPxPivotGrid id="ConsultaRadicados" runat="server" Width="900px" DataSourceID="AlfaWeb" 
                                    OnPreRender="ConsultaRadicados_PreRender" EnableCallBacks="False">
                                <Fields>
                                    <dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoCodigo" Area="FilterArea" AreaIndex="4" Caption="Radicado" 
                                            SummaryType="Count">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldWFMovimientoFecha" Area="ColumnArea" AreaIndex="0" GroupInterval="DateMonth" 
                                            UnboundFieldName="fieldWFMovimientoFecha" Caption="Fecha Radicado">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldProcedenciaNombre" Area="FilterArea" AreaIndex="1" Caption="Procedencia">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldNaturalezaNombre" Area="RowArea" AreaIndex="0" Caption="Naturaleza">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="MedioNombre" ID="fieldMedioNombre" Area="FilterArea" AreaIndex="3" Caption="Medio">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="ExpedienteNombre" ID="fieldExpedienteNombre" Area="FilterArea" AreaIndex="0" Caption="Expediente">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="DependenciaNombre" ID="fieldDependenciaNombre" Area="FilterArea" AreaIndex="2" Caption="Dependencia">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fielRadicadoCodigoPivot" Area="DataArea" AreaIndex="0" Caption="Radicado Pivot" 
                                            SummaryType="Count">
                                    </dxwpg:PivotGridField>
                                    <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="fieldYearRadicado" Area="ColumnArea" AreaIndex="0" Visible="False" 
                                            GroupInterval="DateYear" UnboundFieldName="field" Caption="A&#241;o Radicado">
                                    </dxwpg:PivotGridField>
                                </Fields>

                                <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                                    <CustomizationFieldsHeaderStyle>
                                        <Paddings PaddingLeft="12px" PaddingRight="6px"></Paddings>
                                    </CustomizationFieldsHeaderStyle>
                                </Styles>

                                <OptionsView ShowGrandTotalsForSingleValues="True"></OptionsView>

                                <OptionsChartDataSource ChartDataVertical="False" ShowColumnCustomTotals="False" ShowColumnGrandTotals="False" 
                                        ShowColumnTotals="False" ShowRowCustomTotals="False" ShowRowGrandTotals="False" ShowRowTotals="False">
                                </OptionsChartDataSource>

                                <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                    <FieldValueCollapsed Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png">
                                    </FieldValueCollapsed>

                                    <FieldValueExpanded Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png">
                                    </FieldValueExpanded>

                                    <HeaderSortDown Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png">
                                    </HeaderSortDown>

                                    <HeaderSortUp Height="8px" Width="7px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png">
                                    </HeaderSortUp>

                                    <SortByColumn Height="7px" Width="11px" Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png">
                                    </SortByColumn>
                                </Images>
                            </dxwpg:ASPxPivotGrid>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:SqlDataSource id="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
                    SelectCommand="Radicado_ConsultasRadicadoDinamico" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="01/01/2011"
                            Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                    <asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="31/12/2011"
                            Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                </SelectParameters>
            </asp:SqlDataSource>
            <dxchartsui:WebChartControl style="TEXT-ALIGN: center" id="WebChartControl1" runat="server" Width="900px" DataSourceID="ConsultaRadicados" 
                    ShowLoadingPanel="False" SeriesDataMember="Series" DiagramTypeName="XYDiagram" AlternateText="Grafico de Consultas Dinamicas Documentos Recibidos" 
                    AppearanceName="Pastel Kit" Height="500px">
                <SeriesSerializable>
                    <cc2:Series Name="Series 1" ArgumentScaleType="Numerical" LabelTypeName="SideBySideBarSeriesLabel" PointOptionsTypeName="PointOptions" 
                            SeriesViewTypeName="SideBySideBarSeriesView">
                        <View HiddenSerializableString="to be serialized"></View>

                        <Label HiddenSerializableString="to be serialized" LineVisible="True" OverlappingOptionsTypeName="OverlappingOptions">
                            <FillStyle FillOptionsTypeName="SolidFillOptions">
                                <Options HiddenSerializableString="to be serialized"></Options>
                            </FillStyle>
                        </Label>

                        <PointOptions HiddenSerializableString="to be serialized"></PointOptions>

                        <LegendPointOptions HiddenSerializableString="to be serialized"></LegendPointOptions>
                    </cc2:Series>
                </SeriesSerializable>

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
                    <axisx reverse="True" visibleinpanesserializable="-1">
                        <range auto="False" minvalueserializable="A" maxvalueserializable="E" sidemarginsenabled="True">
                        </range>
                    </axisx>

                    <axisy visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True"></range>

                        <numericoptions precision="0"></numericoptions>
                    </axisy>
                </Diagram>

                <FillStyle FillOptionsTypeName="SolidFillOptions">
                    <Options HiddenSerializableString="to be serialized"></Options>
                </FillStyle>

                <Legend MarkerSize="15, 10" Font="Tahoma, 7pt" SpacingVertical="1" SpacingHorizontal="0" MaxHorizontalPercentage="30" BackColor="White">
                </Legend>
            </dxchartsui:WebChartControl> 
        </contenttemplate>
        <triggers>
            <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
        </triggers>
    </asp:UpdatePanel>
</asp:Content>

