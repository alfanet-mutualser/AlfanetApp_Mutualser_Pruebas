<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteProcedencia.aspx.cs" Inherits="_ReporteProcedencia" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="ProcedenciaReportViewer" AsyncRendering="false" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteProcedencia.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSProcedencia_Procedencia" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSProcedenciaSQL_Procedencia" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetProcedencia"
            TypeName="DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProcedenciaNUI" Type="String" />
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
            </InsertParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ProcedenciaDataSource" runat="server" SelectMethod="GetProcedencia"
            TypeName="DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProcedenciaNUI" Type="String" />
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
            </InsertParameters>
    </asp:ObjectDataSource>
    </span>
           
</asp:Content>

