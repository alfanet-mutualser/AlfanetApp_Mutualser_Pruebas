<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteUsuarioxRoles.aspx.cs" Inherits="ReporteUsuarioxRoles" Title="Página sin título" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">  
        <rsweb:ReportViewer ID="SerieReportViewer" AsyncRendering="False"  runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
        
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteUsuarioxRoles.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                        Name="DSUsuariosxRoles_DTUsuariosxRoles" />
                </DataSources>
            </LocalReport>        
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetData" 
            TypeName="DSUsuariosxRolesTableAdapters.DTUsuariosxRolesTableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="DataSet1TableAdapters.DataTable1TableAdapter">
        </asp:ObjectDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </asp:Panel>
</span>
</asp:Content>

