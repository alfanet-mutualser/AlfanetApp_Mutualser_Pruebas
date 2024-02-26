<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteDevoluciones.aspx.cs" Inherits="AlfanetReportes_Dinamicos_ReporteDevoluciones" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="ContentReporteDevoluciones" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="100">
        <progresstemplate>
            Loading...
        </progresstemplate>
    </asp:UpdateProgress>
    <div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
                <table class="style1">
                    <tbody>
                        <tr>
                            <td>
                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" 
                                        ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
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
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server">
                </dxwgv:ASPxGridViewExporter>
                <asp:CheckBox id="CheckBox1" runat="server" Width="343px" Visible="False" Text="Intercambiar Filas y Columnas en Grafica" 
                        OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True">
                </asp:CheckBox>
                <table style="width: 659px">
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Text="Fecha de Registro Inicial:" Width="135px">
                            </asp:Label>
                        </td>
                        <td style="width: 100px">
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label2" runat="server" Text="Fecha de Registro Final:" Width="131px">
                            </asp:Label>
                        </td>
                        <td style="width: 100px">
                            <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" runat="server">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 1014px">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Buscar:">
                            </asp:Label>
                        </td>
                        <td style="width: 1332px">
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif"
                                    Width="35px" />
                        </td>
                    </tr>
                </table>
                <br />
                <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                        CssPostfix="Office2003_Blue" AutoGenerateColumns="False" DataSourceID="Procedimiento">
                    <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                        <Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

                        <LoadingPanel ImageSpacing="10px"></LoadingPanel>
                    </Styles>

                    <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

                    <SettingsPager ShowSeparators="True">
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
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem SummaryType="Count" FieldName="RegistroCodigo" DisplayFormat="Total" ShowInColumn="Registro" 
                                ShowInGroupFooterColumn="Registro" Tag="Total">
                        </dxwgv:ASPxSummaryItem>
                    </TotalSummary>

                    <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                        <CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png">
                        </CollapsedButton>

                        <ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png">
                        </ExpandedButton>

                        <DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png">
                        </DetailCollapsedButton>

                        <DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png">
                        </DetailExpandedButton>

                        <FilterRowButton Height="13px" Width="13px"></FilterRowButton>
                    </Images>

                    <SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" 
                            PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" 
                            GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" 
                            EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" 
                            CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" 
                            CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" 
                            FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro">
                    </SettingsText>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn FieldName="RegistroCodigo" Caption="Registro" VisibleIndex="0">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn FieldName="FechaMotDevolucion" Caption="Fecha de Devoluci&#243;n" VisibleIndex="1">
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataDateColumn FieldName="FechaActMotDevolucion" Caption="Fecha Registro de Devoluci&#243;n" VisibleIndex="2">
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Caption="Procedencia" VisibleIndex="3">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="MotivoDevolucion" Caption="Motivo de Devoluci&#243;n" VisibleIndex="4">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="CiudadNombre" Caption="Ciudad" VisibleIndex="5">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaDireccion" Caption="Direcci&#243;n" VisibleIndex="6">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Caption="Dependencia Remitente" VisibleIndex="7">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>

                    <Settings ShowFilterBar="Visible" ShowGroupPanel="True" ShowFilterRow="True"></Settings>

                    <StylesEditors>
                        <ProgressBar Height="25px"></ProgressBar>
                    </StylesEditors>
                </dxwgv:ASPxGridView>
                <asp:SqlDataSource ID="Procedimiento" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                        SelectCommand="Registro_ConsultasDevoluciones" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="01/01/1800"
                                Name="FechaInicial" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="01/01/1800"
                                Name="FechaFinal" PropertyName="SelectedDate" />
                        <asp:Parameter DefaultValue="1" Name="Registrocodigo1" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="registroCodigo2" Type="String" />
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

