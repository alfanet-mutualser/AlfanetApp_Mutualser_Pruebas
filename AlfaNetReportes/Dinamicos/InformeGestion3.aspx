<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="InformeGestion3.aspx.cs" Inherits="AlfaNetReportes_Dinamicos_InformeGestion3" Title="Informe Gestion de Documentos Enviados" %>

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

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function checkControl(TxtDestino) {
            <%--var nodeText = document.getElementById("<%=TxtDestino.ClientID%>");
            nodeText.innerText = "";
            nodeText.innerHTML = "";

            //            var RBL = document.getElementById("<%=RadioButtonList1.ClientID%>");
            //            if( RBL != null ){ RBL.focus(); }

            var ACDestino = document.getElementById("<%=AutoCompleteExtender3.ClientID%>");
            if (ACDestino != null) {
                ACDestino.set_serviceMethod("GetProcedenciaByTextNombre");
            }--%>

        }

    </script>

    <div>
         <%--PANEL DE REGISTROS INTERNOS--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
                    <ProgressTemplate>
                        Cargando...
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <dxpgw:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRegistros">
                </dxpgw:ASPxPivotGridExporter>
                <table class="style1" style="width: 850px">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox ID="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
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
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                                <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="width: 67px; padding-right:35px;">
                                <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="width: 100px;padding-right:35px;">Tipo Registro: 
                                <asp:RadioButtonList ID="RadioButtonList1" TabIndex="8" runat="server" Font-Size="Smaller" ForeColor="RoyalBlue" ValidationGroup="1" CssClass="TxtOpciones" RepeatDirection="Horizontal" AutoPostBack="True" OnLoad="RadioButtonList1_Load" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="100%">
                                    <asp:ListItem Value="1" Selected="True">Interno</asp:ListItem>
                                    <asp:ListItem Value="0">Externo</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 15px">&nbsp; </td>
                            <td style="width: 1402px">Fecha Inicial:<telerik:RadDatePicker ID="telkFechaInicial" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                            </td>
                            <td style="width: 1502px">Fecha Final:
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
                        </tr>
                    </tbody>
                </table>
                <%--ASP PIVOTGRID Registros Internos--%>
                <dxwpg:ASPxPivotGrid ID="ConsultaRegistros" runat="server" Width="800px" DataSourceID="AlfaWeb" EnableCallbackCompression="True">

                    <Prefilter Enabled="False"></Prefilter>
                    <Fields>
                        <dxwpg:PivotGridField FieldName="RegistroCodigo" ID="fieldRegistroNumero" Area="RowArea"
                            AreaIndex="0" Caption="Registro">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="PivotGridField1" GroupIndex="0"
                            InnerGroupIndex="0" Area="RowArea" AreaIndex="1" UnboundFieldName="fieldRegistroFecha"
                            Caption="F. Registro">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="RegistroFechaVencimiento" ID="fieldRegistroFechaVencimiento"
                            GroupIndex="0" InnerGroupIndex="1" Area="RowArea" AreaIndex="2" GroupInterval="Date"
                            UnboundFieldName="fieldRegistroFechaVencimiento" Caption="F. Vencimiento">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DependenciaNombre" ID="fieldRegistroDependencia"
                            GroupIndex="0" InnerGroupIndex="2" Area="RowArea" AreaIndex="3" Caption="Dependencia">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldRegistroNaturaleza" GroupIndex="0"
                            InnerGroupIndex="3" Area="RowArea" AreaIndex="4" Caption="Naturaleza">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="RegistroDetalle" ID="fieldRegistroDetalle" GroupIndex="0"
                            InnerGroupIndex="4" Area="RowArea" AreaIndex="5" Caption="Detalle">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoPasoFinal" ID="fieldRegistroMaxPaso"
                            GroupIndex="0" InnerGroupIndex="5" Area="RowArea" AreaIndex="6" UnboundFieldName="fieldRegistroMaxPaso"
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
                </dxwpg:ASPxPivotGrid>
                <asp:SqlDataSource ID="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="Registro_ReadRegistroInformeGestion3Internos" SelectCommandType="StoredProcedure" OnSelecting="AlfaWeb_Selecting">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="telkFechaInicial" DbType="DateTime" DefaultValue="01/01/2011"
                            Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="telkFechaFinal" DbType="DateTime" DefaultValue="31/12/2011"
                            Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <%--ASP PIVOTGRID Registros Externos--%>
                 <dxwpg:ASPxPivotGrid ID="ConsultaRegistrosExternos" runat="server" Width="800px" DataSourceID="AlfaWebExt" EnableCallbackCompression="True">

                    <Prefilter Enabled="False"></Prefilter>
                    <Fields>
                        <dxwpg:PivotGridField FieldName="RegistroCodigo" ID="fieldRegistroNumeroExt" Area="RowArea"
                            AreaIndex="0" Caption="Registro">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="PivotGridField2" GroupIndex="0"
                            InnerGroupIndex="0" Area="RowArea" AreaIndex="1" UnboundFieldName="fieldRegistroFecha"
                            Caption="F. Registro">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldRegistroProcedenciaExt"
                            GroupIndex="0" InnerGroupIndex="1" Area="RowArea" AreaIndex="2" Caption="Procedencia">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldRegistroNaturalezaExt" GroupIndex="0"
                            InnerGroupIndex="2" Area="RowArea" AreaIndex="3" Caption="Naturaleza">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="RegistroDetalle" ID="fieldRegistroDetalleExt" GroupIndex="0"
                            InnerGroupIndex="3" Area="RowArea" AreaIndex="4" Caption="Detalle">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoPasoFinal" ID="fieldRegistroMaxPasoExt"
                            GroupIndex="0" InnerGroupIndex="4" Area="RowArea" AreaIndex="5" UnboundFieldName="fieldRegistroMaxPaso"
                            Caption="Paso Final">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldRespuestaTipoExt" GroupIndex="0"
                            InnerGroupIndex="5" Area="RowArea" AreaIndex="6" Caption="Serie">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="WFMovimientoPaso" ID="FieldWFMovimientoPasoExt" GroupIndex="0"
                            InnerGroupIndex="6" Area="RowArea" AreaIndex="7" Caption="MovimientoPaso">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="FechaMovimiento" ID="FieldWFMovimientoFechaExt" GroupIndex="0"
                            InnerGroupIndex="7" Area="RowArea" AreaIndex="8" Caption="FechaMovimiento">
                        </dxwpg:PivotGridField>

                        <dxwpg:PivotGridField FieldName="WFAccionNombre" ID="FieldWFAccionExt" GroupIndex="0"
                            InnerGroupIndex="8" Area="RowArea" AreaIndex="9" Caption="Accion">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DependenciaNomOrigen" ID="fieldDependenciaOrigenExt"
                            GroupIndex="0" InnerGroupIndex="9" Area="RowArea" AreaIndex="10" Caption="DependenciaOrigen">
                        </dxwpg:PivotGridField>
                        <dxwpg:PivotGridField FieldName="DependenciaNomDestino" ID="fieldDependenciaDestinoExt"
                            GroupIndex="0" InnerGroupIndex="10" Area="RowArea" AreaIndex="11" Caption="DependenciaDestino">
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
                </dxwpg:ASPxPivotGrid>
                <asp:SqlDataSource ID="AlfawebExt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="Registro_ReadRegistroInformeGestion3" SelectCommandType="StoredProcedure" OnSelecting="AlfaWebExt_Selecting">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="telkFechaInicial" DbType="DateTime" DefaultValue="01/01/2011"
                            Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="telkFechaFinal" DbType="DateTime" DefaultValue="31/12/2011"
                            Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                    </SelectParameters>
                </asp:SqlDataSource>

            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="imgBtBuscar" EventName="Click" />
            </Triggers>

        </asp:UpdatePanel>
         <%--PANEL DE REGISTROS EXTERNOS
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="100">
                    <ProgressTemplate>
                        Cargando...
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <dxpgw:ASPxPivotGridExporter ID="ASPxPivotGridExporter2" runat="server" ASPxPivotGridID="ConsultaRegistrosExt">
                </dxpgw:ASPxPivotGridExporter>
                <table class="style1" style="width: 850px">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
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
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                                <dxe:ASPxButton ID="ASPxButton1" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="width: 67px">
                                <dxe:ASPxButton ID="ASPxButton2" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="width: 100px">Tipo Registro: 
                                <asp:RadioButtonList ID="RadioButtonList2" TabIndex="8" runat="server" Font-Size="Smaller" ForeColor="RoyalBlue" ValidationGroup="1" CssClass="TxtOpciones" RepeatDirection="Horizontal" AutoPostBack="True" OnLoad="RadioButtonList1_Load" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="100%">
                                    <asp:ListItem Value="1">Interno</asp:ListItem>
                                    <asp:ListItem Value="0">Externo</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 15px">&nbsp; </td>
                            <td style="width: 1402px">Fecha Inicial:<telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                            </td>
                            <td style="width: 1502px">Fecha Final:
            <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
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
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Iniciar busqueda por fechas"
                                    Height="24px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif" OnClick="imgBtBuscar_Click" /></td>
                        </tr>
                    </tbody>
                </table>
               
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="imgBtBuscar" EventName="Click" />
            </Triggers>

        </asp:UpdatePanel>--%>
    </div>

</asp:Content>
