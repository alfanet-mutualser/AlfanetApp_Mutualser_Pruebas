<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteRadicadores.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_InformeGestion" Title="Informe de Gestion de Documentos" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

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
Loading...
</progresstemplate>
    </asp:UpdateProgress>
    <div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="343px" Visible="False" Text="Intercambiar Filas y Columnas en Grafica" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
<dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server">
</dxwgv:ASPxGridViewExporter> 
<TABLE class="style1"><TBODY><TR><TD><dxe:ASPxComboBox id="listExportFormat" runat="server" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" ValueType="System.String"><Items>
<dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
<dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
<dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
<dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
</Items>

<ButtonStyle Width="13px"></ButtonStyle>
</dxe:ASPxComboBox> </TD><TD><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                    </dxe:ASPxButton> </TD><TD><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                    </dxe:ASPxButton> </TD></TR></TBODY></TABLE>
                <table style="width: 659px">
                    <tr>
                        <td style="width: 100px; height: 36px;">
                            <asp:Label ID="Label1" runat="server" Text="Fecha Inicial:" Width="73px"></asp:Label></td>
                        <td style="width: 100px; height: 36px;">
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 100px; height: 36px;">
                            <asp:Label ID="Label2" runat="server" Text="Fecha Final:" Width="74px"></asp:Label></td>
                        <td style="width: 100px; height: 36px;">
                            <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 1014px; height: 36px;">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Buscar:"></asp:Label></td>
                        <td style="width: 1332px; height: 36px;">
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif"
                                Width="35px" /></td>
                    </tr>
                </table>
                <br />
                    <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" DataSourceID="AlfaWeb" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" AutoGenerateColumns="False">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>
<TotalSummary>
<dxwgv:ASPxSummaryItem SummaryType="Count" FieldName="RadicadoCodigo" ShowInColumn="Radicado Codigo" Tag="Total"></dxwgv:ASPxSummaryItem>
</TotalSummary>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>
<Columns>
<dxwgv:GridViewCommandColumn VisibleIndex="0">
<ClearFilterButton Visible="True"></ClearFilterButton>
</dxwgv:GridViewCommandColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="Documento" VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoNombre" Caption="Grupo" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" UnboundType="String" Caption="Fecha Radicacion" VisibleIndex="3">
<PropertiesDateEdit DisplayFormatString="" AllowUserInput="False"></PropertiesDateEdit>

<Settings FilterMode="DisplayText"></Settings>
</dxwgv:GridViewDataDateColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Caption="Detalle" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoAnexo" Caption="Anexo" VisibleIndex="5">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Digitador" Caption="Digitador" VisibleIndex="6">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:ASPxGridView><asp:SqlDataSource id="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                    SelectCommand="Radicado_ConsultasRadicadores" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="01/01/2017" Name="FechaInicial" PropertyName="SelectedDate" />
						<asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="01/01/2020" Name="FechaFinal" PropertyName="SelectedDate" />
                        <%--<asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="01/01/1800" Name="FechaInicial" PropertyName="SelectedDate" />
						<asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="01/01/2020" Name="FechaFinal" PropertyName="SelectedDate" />--%>
                    </SelectParameters>
</asp:SqlDataSource>
</contenttemplate>
       
            <Triggers>
<asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
</Triggers>
       
        </asp:UpdatePanel>
        <br />
    
    </div>
  
</asp:Content>

