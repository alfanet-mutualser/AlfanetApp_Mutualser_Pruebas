<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReportePais.aspx.cs" Inherits="_ReportePais" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="SerieReportViewer" AsyncRendering="False"  runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReportePais1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSaspnet_Users_aspnet_Profile_PorpertyUsers" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSUsuario_Usuariosxdependencia1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSPaisSQL_Pais" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        &nbsp;
    </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData"
            TypeName="DSUsuarioTableAdapters.Usuariosxdependencia1TableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetProfilePropertyUser"
            TypeName="DSaspnet_UsersTableAdapters.aspnet_Profile_PorpertyUsersTableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetPais"
            TypeName="DSPaisSQLTableAdapters.PaisTableAdapter"></asp:ObjectDataSource>
    </span>
           
</asp:Content>

