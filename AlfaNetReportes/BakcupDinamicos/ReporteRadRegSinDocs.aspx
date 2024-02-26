<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteRadRegSinDocs.aspx.cs" Inherits="ReporteRadRegSinDocs" Title="Reporte de Radicados y Registros sin documentos asociados" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
	
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

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
<%@ register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
<TABLE class="style1"><TBODY><TR><TD><dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/"><Items>
<dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
<dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
<dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
<dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
</Items>

<ButtonStyle Width="13px"></ButtonStyle>
</dxe:ASPxComboBox> </TD><TD><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> </TD><TD><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> </TD></TR></TBODY></TABLE>
 <dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server"></dxwgv:ASPxGridViewExporter>
 
                &nbsp;
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                        </td>
                        <td>
                            <table style="width: 100%">
                    <tr>
                        <td style="width: 100px; height: 36px">
                            <asp:Label ID="Label1" runat="server" Text="Fecha Inicial:" Width="73px"></asp:Label></td>
                        <td style="width: 100px; height: 36px">
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 100px; height: 36px">
                            <asp:Label ID="Label2" runat="server" Text="Fecha Final:" Width="74px"></asp:Label></td>
                        <td style="width: 100px; height: 36px">
                            <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Outlook">
                                <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width: 1014px; height: 36px">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Buscar:"></asp:Label></td>
                        <td style="width: 1332px; height: 36px">
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/AlfaNetImagen/ToolBar/buscarnew2.gif"
                                Width="35px" onclick="ImageButton2_Click" /></td>
                    </tr>
                </table>
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
 
 <asp:CheckBox id="CheckBox1" runat="server" Width="343px" Visible="False" Text="Intercambiar Filas y Columnas en Grafica" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True"></asp:CheckBox> <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" DataSourceID="ODSRadYRegSinDoc">
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
<dxwgv:ASPxSummaryItem SummaryType="Count" FieldName="RegistroCodigo" DisplayFormat="Total" ShowInColumn="Registro" ShowInGroupFooterColumn="Registro" Tag="Total"></dxwgv:ASPxSummaryItem>
</TotalSummary>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="DocumentoNumero" ReadOnly="True" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" ReadOnly="True" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Grupo" ReadOnly="True" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataDateColumn FieldName="Fecha" ReadOnly="True" VisibleIndex="3"></dxwgv:GridViewDataDateColumn>
<dxwgv:GridViewDataTextColumn FieldName="Radicador" ReadOnly="True" VisibleIndex="4"><Settings AutoFilterCondition="Contains" /></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Naturaleza" ReadOnly="True" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:ASPxGridView>
                <asp:ObjectDataSource ID="ODSRadYRegSinDoc" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData_RadicYRegistSinDocs" TypeName="DSReportesTableAdapters.Reporte_RadicYRegist_SinDocumentoAsociadosTableAdapter">
                </asp:ObjectDataSource>
<asp:SqlDataSource id="AlfaWeb" runat="server" SelectCommand="Reporte_RadicYRegist_SinDocumentoAsociadosDinamico" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommandType="StoredProcedure"><SelectParameters>
    <asp:ControlParameter ControlID="RadDatePicker1" DbType="DateTime" DefaultValue="01/01/2011"
        Name="WFMovimientoFecha" PropertyName="SelectedDate" />
    <asp:ControlParameter ControlID="RadDatePicker2" DbType="DateTime" DefaultValue="31/12/2011"
        Name="WFMovimientoFecha1" PropertyName="SelectedDate" />
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

