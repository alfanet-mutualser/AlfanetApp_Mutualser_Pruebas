<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="DocRecibidoReporte.aspx.cs" Inherits="_DocRecibidoReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ import Namespace="System.Configuration" %>
<%--<%@ Register Src="../NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc1" %>--%>
<%@ Register Src="NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
</script>

    
        <table style="font-size: 8pt;" id="TABLE1">
            <tr>
                <td style="width: 736px">
                
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
<asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="280px" BackColor="ControlLight">
                                            <table style="width: 385px">
                                                <tbody>
                                                    <tr>
                                                        <td align="center" style="background-color: activecaption">
                                                            <asp:Label ID="Label555" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                                                Text="Mensaje" Width="120px"></asp:Label></td>
                                                        <td style="width: 5%; background-color: activecaption">
                                                            <asp:ImageButton ID="btnCerrar" runat="server" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                                                                Style="vertical-align: top" ValidationGroup="789" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="height: 45px; background-color: highlighttxt">
                                                            <br />
                                                            <asp:Label ID="LblMessageBox" runat="server" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel> <cc1:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></cc1:ModalPopupExtender> 
</ContentTemplate>
                                </asp:UpdatePanel><asp:HiddenField ID="HFNroRad" runat="server" />
                             
                    <asp:HiddenField ID="HFTipoDB" runat="server" />
                    <asp:HiddenField ID="HFDepenOrig" runat="server" />
                    <asp:HiddenField ID="HFGrupo" runat="server" />
                    <asp:HiddenField ID="HFWFMovFecha" runat="server" /><asp:HiddenField ID="HFControlDias" runat="server" />
                    </td>
            </tr>
            <tr>
                <td style="font-size: 10pt; background-image: none; width: 800px; color: inactivecaption;
                    font-family: Sans-Serif; background-color: transparent; text-align: center;">
                    
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        Height="600px" Width="620px" AsyncRendering="False">
                        <LocalReport ReportPath="AlfaNetReportes\ReportesDocumentos\Radicado.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSRadicado_RadicadoReporte" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    </asp:Panel>
                    
                    &nbsp;
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetRadicadoReporte" TypeName="DSRadicadoTableAdapters.RadicadoReporteTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFNroRad" Name="RadicadoCodigo" PropertyName="Value"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 736px;">
                    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red">
                    </asp:Label>
                    <asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                    runat="server" Width="734px" Height="1px" Font-Size="10pt" DisplayMode="List">
                    </asp:ValidationSummary>
                    <asp:ObjectDataSource ID="GroupDataSource" runat="server" DeleteMethod="DeleteGrupo"
                                                    InsertMethod="AddGrupo" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGrupoByID"
                                                    TypeName="GrupoBLL" UpdateMethod="UpdateGrupo">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                    </DeleteParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
                                                    </UpdateParameters>
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="" Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                    </SelectParameters>
                                                    <InsertParameters>
                                                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
                                                        <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
                                                    </InsertParameters>
                     </asp:ObjectDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT [WFProcesoCodigo], [WFProcesoDescripcion] FROM [WFProceso] WHERE ([WFProcesoHabilitar] = @WFProcesoHabilitar) ORDER BY [WFProcesoCodigo], [WFProcesoDescripcion]"
                                                    ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="WFProcesoHabilitar" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                    <asp:ObjectDataSource ID="RadicadoDataSource" runat="server" InsertMethod="AddRadicado"
                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetGroupById" TypeName="RadicadoBLL"
                                                    UpdateMethod="AddRadicado">
                    <UpdateParameters>
                                                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
                                                    </UpdateParameters>
                    <InsertParameters>
                                                        <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
                                                        <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
                                                    </InsertParameters>
                       </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ODSUnMovimiento" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetUnDocExtBy" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFTipoDB" Name="WFMovimientoTipo" PropertyName="Value"
                                Type="Int32" />
                            <asp:ControlParameter ControlID="HFDepenOrig" Name="DependenciaCodDestino" PropertyName="Value"
                                Type="String" />
                            <asp:ControlParameter ControlID="HFGrupo" Name="GrupoCodigo" PropertyName="Value"
                                Type="String" />
                            <asp:ControlParameter ControlID="HFWFMovFecha" Name="WFMovimientoFecha" PropertyName="Value"
                                Type="DateTime" />
                            <asp:ControlParameter ControlID="HFNroRad" Name="NumeroDocumento" PropertyName="Value"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                </td>
            </tr>
        </table>
   
</asp:Content>

