
<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteRadicado.aspx.cs" Inherits="AlfaNetReportes_ReportesDocumentos_ReporteRadicado" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: middle; width: 100px; text-align: center">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="400px" Width="493px">
        <LocalReport ReportPath="C:\ALFANET\Aplicacion\AlfaNetReportes\ReportesMaestros\Radicado.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSRadicado_RadicadoReporte" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRadicadoReporte"
        TypeName="DSRadicadoTableAdapters.RadicadoReporteTableAdapter" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="144" Name="RadicadoCodigo" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
 
</asp:Content>

