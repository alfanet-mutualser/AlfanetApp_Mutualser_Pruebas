<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeGestion.aspx.cs" Inherits="AlfanetReportes_Dinamicos_InformeGestion" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>

<asp:Content ID="ContentInformeGestion" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
            <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
                <ProgressTemplate>
                    Cargando... 
                    <asp:Image id="Image1" runat="server" ImageUrl="~/App_Themes/Office2003 Blue/Web/Loading.gif">
                    </asp:Image>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_event">
                    <asp:ListItem Text="Radicado" Selected="True" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Registro" Selected="False" Value="2" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ConsultaRegistros">
                </dxpgw:ASPxPivotGridExporter>
                <table class="style1" style="width: 850px">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" 
                                        ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
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
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="WIDTH: 67px">
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar"
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td style="WIDTH: 3px">
                                &nbsp;
                            </td>
                            <td style="WIDTH: 1502px">
                                Fecha Inicial:
                                <telerik:RadDatePicker ID="telkFechaInicial" runat="server" Skin="Outlook">
                                    <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" runat="server" 
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                    </DateInput>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="telkFechaInicial">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 1502px">
                                Fecha Final:
                                <telerik:RadDatePicker ID="telkFechaFinal" runat="server" Skin="Outlook">
                                    <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x" runat="server">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                    </DateInput>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="telkFechaFinal">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 1502px">
                                <strong>
                                    Buscar:
                                </strong>
                                <asp:ImageButton ID="imgBtBuscar" runat="server" AlternateText="Iniciar busqueda por fechas"
                                        Height="24px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif" OnClick="imgBtBuscar_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Panel ID="PanelConsultaRadicados" runat="server" Visible="true" >
                    <dxwpg:ASPxPivotGrid id="ConsultaRegistros" runat="server" Width="800px" DataSourceID="AlfaWeb" 
                            EnableCallbackCompression="True">
                        <Prefilter Enabled="False">
                        </Prefilter>
                        <Fields>
                            <dxwpg:PivotGridField FieldName="WFMovimientoFecha" ID="PivotGridField1" 
                                    GroupIndex="0" InnerGroupIndex="0" Area="RowArea" AreaIndex="1" 
                                    UnboundFieldName="fieldRadicadoFecha" Caption="Fecha Radicacion">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="DependenciaNombre" ID="fieldActualmenteEn" 
                                    GroupIndex="0" InnerGroupIndex="4" Area="RowArea" AreaIndex="5" 
                                    Caption="Dependencia Actual">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="NaturalezaNombre" ID="fieldRadicadoNaturaleza" 
                                    GroupIndex="0" InnerGroupIndex="3" Area="RowArea" AreaIndex="4" 
                                    Caption="Naturaleza">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="RadicadoCodigo" ID="fieldRadicadoNumero" 
                                    Area="RowArea" AreaIndex="0" Caption="Radicado" SummaryType="Count">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="RadicadoFechaVencimiento" 
                                    ID="fieldRadicadoFechaVencimiento" GroupIndex="0" InnerGroupIndex="1" 
                                    Area="RowArea" AreaIndex="2" GroupInterval="Date" 
                                    UnboundFieldName="fieldRadicadoFechaVencimiento" Caption="Fecha Vencimiento">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="WFMovimientoPasoFinal" ID="fieldRadicadoMaxPaso" 
                                    GroupIndex="0" InnerGroupIndex="6" Area="RowArea" AreaIndex="7" 
                                    UnboundFieldName="fieldRadicadoMaxPaso" Caption="Paso Final">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="ProcedenciaNombre" ID="fieldRadicadoProcedencia" 
                                    GroupIndex="0" InnerGroupIndex="2" Area="RowArea" AreaIndex="3" 
                                    Caption="Procedencia">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="RadicadoDetalle" ID="fieldRadicadoDetalle" 
                                    GroupIndex="0" InnerGroupIndex="5" Area="RowArea" AreaIndex="6" 
                                    Caption="Detalle">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="SerieNombre" ID="fieldRespuestaTipo" 
                                    GroupIndex="0" InnerGroupIndex="7" Area="RowArea" AreaIndex="8" Caption="Serie">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="Respuesta"      ID="fieldRespuestaNumero" Area="RowArea" AreaIndex="11" Caption="Respuesta">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="FechaRespuesta" ID="field"                Area="RowArea" AreaIndex="10" Caption="Fecha Respuesta">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="DiasVencimiento" ID="fieldRespuestaDV" 
                                    Area="RowArea" AreaIndex="9" Caption="Dias Vencimiento" GroupIndex="0" InnerGroupIndex="8">
                            </dxwpg:PivotGridField>
                        </Fields>

                        <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                            <CustomizationFieldsHeaderStyle>
                                <Paddings PaddingLeft="12px" PaddingRight="6px">
                                </Paddings>
                            </CustomizationFieldsHeaderStyle>
                        </Styles>

                        <OptionsData CaseSensitive="False">
                        </OptionsData>

                        <OptionsView DataHeadersDisplayMode="Popup" ShowContextMenus="False" ShowColumnTotals="False" ShowRowTotals="False" 
                                ShowColumnGrandTotals="False" ShowRowGrandTotals="False" ShowDataHeaders="False" ShowFilterHeaders="False" 
                                ShowColumnHeaders="False" ShowRowHeaders="False" DrawFocusedCellRect="False" ShowFilterSeparatorBar="False">
                        </OptionsView>

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

                        <Groups>
                            <dxwpg:PivotGridWebGroup>
                            </dxwpg:PivotGridWebGroup>
                        </Groups>

                        <OptionsCustomization AllowDrag="False" AllowExpand="False" AllowSortBySummary="False">
                        </OptionsCustomization>

                        <OptionsPager>
                            <Summary AllPagesText="Paginas: {0} - {1} ({2} Documentos pendientes)" Text="Pagina {0} of {1} ({2} Documentos pendientes)">
                            </Summary>
                        </OptionsPager>
                    </dxwpg:ASPxPivotGrid>
                    <asp:SqlDataSource id="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
                            SelectCommand="Radicado_ReadRadicadoInformeGestion" SelectCommandType="StoredProcedure" 
                            onselecting="AlfaWeb_Selecting">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="telkFechaInicial" DbType="DateTime" 
                                Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                            <asp:ControlParameter ControlID="telkFechaFinal" DbType="DateTime" 
                                Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                        </SelectParameters>
                    </asp:SqlDataSource> 
                </asp:Panel>
                <asp:Panel ID="PanelConsultaRegistro" runat="server" Visible="false">                     
                    <dxpgw:ASPxPivotGridExporter id="ASPxPivotGridExporter2" runat="server" 
                            ASPxPivotGridID="ASPxPivotGrid1">
                    </dxpgw:ASPxPivotGridExporter>
                    <dxwpg:ASPxPivotGrid id="ASPxPivotGrid1" runat="server" Width="800px" 
                            DataSourceID="Alfaweb1" EnableCallbackCompression="True">
                        <Prefilter Enabled="False"></Prefilter>
                        <Fields>
                            <dxwpg:PivotGridField FieldName="RegistroCodigo" 
                                    ID="PivotGridField2" Area="RowArea" AreaIndex="0" 
                                    Caption="Registro" SummaryType="Count">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="WFMovimientoFecha" 
                                    ID="PivotGridField3" GroupIndex="0" InnerGroupIndex="0"
                                    Area="RowArea" AreaIndex="1" 
                                    UnboundFieldName="fieldRadicadoFecha" Caption="Fecha Registro">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="DependenciaNombre" 
                                    ID="fieldDependenciaNombre" GroupIndex="0" InnerGroupIndex="1" 
                                    Area="RowArea" AreaIndex="2" Caption="Remitente">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="Destino" 
                                    ID="PivotGridField4" GroupIndex="0" InnerGroupIndex="2" 
                                    Area="RowArea" AreaIndex="3" Caption="Destino">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="RegistroDetalle" 
                                    ID="PivotGridField5" GroupIndex="0" 
                                    InnerGroupIndex="3" Area="RowArea" AreaIndex="4" 
                                    Caption="Detalle">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="NaturalezaNombre" 
                                    ID="PivotGridField6" GroupIndex="0" InnerGroupIndex="4"
                                    Area="RowArea" AreaIndex="5" Caption="Naturaleza">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="MedioNombre" 
                                    ID="cMedioNombre" GroupIndex="0" 
                                    InnerGroupIndex="5" Area="RowArea" AreaIndex="6" 
                                    Caption="Medio">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="ExpedienteNombre" 
                                    ID="vExpedienteNombre" GroupIndex="0" 
                                    InnerGroupIndex="6" Area="RowArea" AreaIndex="7" 
                                    Caption="Expediente">
                            </dxwpg:PivotGridField>
                            <dxwpg:PivotGridField FieldName="SerieNombre" 
                                    ID="fieldSerieNombre" GroupIndex="0" 
                                    InnerGroupIndex="7" Area="RowArea" AreaIndex="8" 
                                    Caption="Serie">
                            </dxwpg:PivotGridField>
                        </Fields>

                        <Styles CssPostfix="Office2003_Blue" 
                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                            <CustomizationFieldsHeaderStyle>
                                <Paddings PaddingLeft="12px" PaddingRight="6px">
                                </Paddings>
                            </CustomizationFieldsHeaderStyle>
                        </Styles>

                        <OptionsData CaseSensitive="False"></OptionsData>

                        <OptionsView DataHeadersDisplayMode="Popup" ShowContextMenus="False" 
                                ShowColumnTotals="False" ShowRowTotals="False" 
                                ShowColumnGrandTotals="False" ShowRowGrandTotals="False" 
                                ShowDataHeaders="False" ShowFilterHeaders="False" 
                                ShowColumnHeaders="False" ShowRowHeaders="False" 
                                DrawFocusedCellRect="False" ShowFilterSeparatorBar="False">
                        </OptionsView>

                        <OptionsChartDataSource ChartDataVertical="False" 
                                ShowColumnCustomTotals="False" ShowColumnGrandTotals="False" 
                                ShowColumnTotals="False" ShowRowCustomTotals="False" 
                                ShowRowGrandTotals="False" ShowRowTotals="False">
                        </OptionsChartDataSource>

                        <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                            <FieldValueCollapsed Height="12px" Width="11px" 
                                    Url="~/App_Themes/Office2003 Blue/PivotGrid/pgCollapsedButton.png">
                            </FieldValueCollapsed>

                            <FieldValueExpanded Height="12px" Width="11px" 
                                    Url="~/App_Themes/Office2003 Blue/PivotGrid/pgExpandedButton.png">
                            </FieldValueExpanded>

                            <HeaderSortDown Height="8px" Width="7px" 
                                    Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortDown.png">
                            </HeaderSortDown>

                            <HeaderSortUp Height="8px" Width="7px" 
                                    Url="~/App_Themes/Office2003 Blue/PivotGrid/pgHeaderSortUp.png">
                            </HeaderSortUp>

                            <SortByColumn Height="7px" Width="11px" 
                                    Url="~/App_Themes/Office2003 Blue/PivotGrid/pgSortByColumn.png">
                            </SortByColumn>
                        </Images>
                        <Groups>
                            <dxwpg:PivotGridWebGroup></dxwpg:PivotGridWebGroup>
                        </Groups>

                        <OptionsCustomization AllowDrag="False" AllowExpand="False" 
                                AllowSortBySummary="False">
                        </OptionsCustomization>

                        <OptionsPager>
                            <Summary AllPagesText="Paginas: {0} - {1} ({2} Documentos pendientes)" 
                                    Text="Pagina {0} of {1} ({2} Documentos pendientes)">
                            </Summary>
                        </OptionsPager>
                    </dxwpg:ASPxPivotGrid>
                </asp:Panel>
                <asp:SqlDataSource id="Alfaweb1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
                        SelectCommand="Registro_ReadRegistroInformeGestion" SelectCommandType="StoredProcedure" 
                        onselecting="AlfaWeb_Selecting">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="telkFechaInicial" DbType="DateTime"
                                Name="WFMovimientoFecha" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="telkFechaFinal" DbType="DateTime" 
                                Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="imgBtBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

