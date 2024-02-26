<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteNaturaleza.aspx.cs" Inherits="_ReporteNaturaleza" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="NaturalezaReportViewer" AsyncRendering="false"  runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%" DocumentMapWidth="100%" ZoomMode="Percent">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteNaturaleza.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSNaturaleza_Naturaleza" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSNaturalezaSQL_Naturaleza" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetNaturaleza"
            TypeName="DSNaturalezaSQLTableAdapters.NaturalezaTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="NaturalezaDataSource" runat="server" SelectMethod="GetNaturaleza"
            TypeName="DSNaturalezaTableAdapters.NaturalezaTableAdapter"></asp:ObjectDataSource>
        &nbsp;
    </span>
           
</asp:Content>

