<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteSeguridad.aspx.cs" Inherits="_ReporteUsuario" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="SerieReportViewer" AsyncRendering="False"  runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteSeguridad.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSaspnet_Users_aspnet_Profile_PorpertyUsers" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSUsuario_Usuariosxdependencia1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSDependenciaSQL_Dependencia_ReadDependenciaPermisos" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetDependenciaPermisos"
            TypeName="DSDependenciaSQLTableAdapters.Dependencia_ReadDependenciaPermisosTableAdapter">
        </asp:ObjectDataSource>
    </asp:Panel>

    </span>
           
</asp:Content>

