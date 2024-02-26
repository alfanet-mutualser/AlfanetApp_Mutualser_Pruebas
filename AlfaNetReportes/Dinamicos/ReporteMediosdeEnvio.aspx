<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteMediosdeEnvio.aspx.cs" Inherits="AlfanetReportes_Dinamicos_ReporteMediosdeEnvio" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<asp:Content ID="ContentReporteMediosdeEnvio" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="100">
        <progresstemplate>
            Loading...
        </progresstemplate>
    </asp:UpdateProgress>
    <div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
                <TABLE class="style1">
                    <TBODY>
                        <TR>
                            <TD>
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
                            </TD>
                            <TD>
                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </TD>
                            <TD>
                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" 
                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                </dxe:ASPxButton>
                            </TD>
                        </TR>
                    </TBODY>
                </TABLE>
                <dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server" __designer:wfdid="w2">
                </dxwgv:ASPxGridViewExporter>
                <asp:CheckBox id="CheckBox1" runat="server" Width="343px" Visible="False" Text="Intercambiar Filas y Columnas en Grafica" 
                        OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True">
                </asp:CheckBox>
                <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                        CssPostfix="Office2003_Blue" __designer:wfdid="w1" AutoGenerateColumns="False" DataSourceID="AlfaWeb">
                    <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                        <Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

                        <LoadingPanel ImageSpacing="10px"></LoadingPanel>
                    </Styles>

                    <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

                    <SettingsPager ShowSeparators="True">
                        <Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)">
                        </Summary>
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
                            EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" 
                            CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" 
                            CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" 
                            HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" 
                            FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro">
                    </SettingsText>
                    <Columns>
                        <dxwgv:GridViewCommandColumn ButtonType="Button" VisibleIndex="0">
                            <CancelButton Text="Cancelar"></CancelButton>

                            <ClearFilterButton Visible="True" Text="Limpiar"></ClearFilterButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="RegistroCodigo" Caption="Registro" VisibleIndex="1">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" UnboundType="DateTime" Caption="Fecha Inicial" VisibleIndex="2">
                            <PropertiesDateEdit MinDate="2010-01-01"></PropertiesDateEdit>

                            <Settings AllowAutoFilterTextInputTimer="True" AllowAutoFilter="True" AutoFilterCondition="GreaterOrEqual">
                            </Settings>
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" UnboundType="DateTime" Caption="Fecha Final" Visible="False" VisibleIndex="3">
                            <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>

                            <Settings AllowAutoFilterTextInputTimer="True" AllowAutoFilter="True" AutoFilterCondition="LessOrEqual">
                            </Settings>
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="RegistroDetalle" Caption="Detalle" VisibleIndex="3">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="MedioNombre" Caption="Medio" VisibleIndex="4">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Caption="Procedencia" VisibleIndex="5">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaDireccion" Caption="Direccion" VisibleIndex="6">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="CiudadNombre" Caption="Ciudad" VisibleIndex="7">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>

                    <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

                    <StylesEditors>
                        <ProgressBar Height="25px"></ProgressBar>
                    </StylesEditors>
                </dxwgv:ASPxGridView>
                <asp:SqlDataSource id="AlfaWeb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
                        SelectCommand="SELECT [RegistroCodigo], [WFMovimientoFecha], [RegistroDetalle], [MedioNombre], [ProcedenciaNombre], [ProcedenciaDireccion], [CiudadNombre] FROM [MediosdeEnvio]">
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

