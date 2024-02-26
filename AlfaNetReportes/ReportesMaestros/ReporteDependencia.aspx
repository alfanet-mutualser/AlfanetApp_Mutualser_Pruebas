<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteDependencia.aspx.cs" Inherits="_ReporteDependencia" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="DependenciaReportViewer" AsyncRendering="False" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteDependencia1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DSaspnet_Users_aspnet_Profile_PorpertyUsers" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DSUsuario_Usuariosxdependencia1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DSPaisSQL_Pais" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DSDependenciaSQL_Dependencia" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDependencia"
            TypeName="DSDependenciaSQLTableAdapters.DependenciaTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="DependenciaNombre" Type="String" />
                <asp:Parameter Name="DependenciaCodigoPadre" Type="String" />
                <asp:Parameter Name="DependenciaHabilitar" Type="String" />
                <asp:Parameter Name="DependenciaPermiso" Type="String" />
                <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="DependenciaCodigo" Type="String" />
                <asp:Parameter Name="DependenciaNombre" Type="String" />
                <asp:Parameter Name="DependenciaCodigoPadre" Type="String" />
                <asp:Parameter Name="DependenciaHabilitar" Type="String" />
                <asp:Parameter Name="DependenciaPermiso" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetDepartamento"
            TypeName="DSDepartamentoSQLTableAdapters.DepartamentoTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCiudad"
            TypeName="DSCiudadSQLTableAdapters.CiudadTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="DependenciaDataSource" runat="server" SelectMethod="GetDependencia"
            TypeName="DSDependenciaTableAdapters.DependenciaTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetProfilePropertyUser"
            TypeName="DSaspnet_UsersTableAdapters.aspnet_Profile_PorpertyUsersTableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetData"
            TypeName="DSUsuarioTableAdapters.Usuariosxdependencia1TableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetPais"
            TypeName="DSPaisSQLTableAdapters.PaisTableAdapter"></asp:ObjectDataSource>
    </span>
           
</asp:Content>

