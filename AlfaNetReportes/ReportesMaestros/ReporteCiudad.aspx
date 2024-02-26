<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteCiudad.aspx.cs" Inherits="_ReporteCiudad" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCiudad"
        TypeName="DSCiudadSQLTableAdapters.CiudadTableAdapter">        
    </asp:ObjectDataSource>
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="600px" Width="100%" AsyncRendering="False" SizeToReportContent="True">
        <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteCiudades.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSNaturaleza_Naturaleza" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSNaturalezaSQL_Naturaleza" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSCiudadSQL_Ciudad" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </asp:Panel>
   
</asp:Content>

