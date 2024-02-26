<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteProcesos.aspx.cs" Inherits="_ReporteProcesos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
     <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="SerieReportViewer" runat="server" AsyncRendering="false"  Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="97%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteProcesos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DSSerie_Serie" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DSProceso_WFProceso" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DSProceso_WFProceso1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetProceso"
            TypeName="DSProcesoTableAdapters.WFProceso1TableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFProceso"
            TypeName="DSProcesoTableAdapters.WFProcesoTableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="SerieDataSource" runat="server" SelectMethod="GetSerie"
            TypeName="DSSerieTableAdapters.SerieTableAdapter"></asp:ObjectDataSource>
    </span>
           
</asp:Content>

