<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteGrupo.aspx.cs" Inherits="_ReporteGrupo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
        <br />
        <rsweb:ReportViewer ID="GrupoReportViewer" AsyncRendering="false"  runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="400px" Width="715px">
            <LocalReport EnableExternalImages="true" ReportPath="AlfaNetReportes\ReportesMaestros\ReporteGrupo.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="GrupoDataSource" Name="DSGrupo_Grupo" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="GrupoDataSource" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetGrupo" TypeName="DSGrupoTableAdapters.GrupoTableAdapter"
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="GrupoCodigo" Type="String" />
                <asp:Parameter Name="GrupoNombre" Type="String" />
                <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                <asp:Parameter Name="GrupoConsecutivo" Type="Double" />
                <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="GrupoCodigo" Type="String" />
                <asp:Parameter Name="GrupoNombre" Type="String" />
                <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                <asp:Parameter Name="GrupoConsecutivo" Type="Double" />
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp; &nbsp;
    </span>
           
</asp:Content>

