<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteMedio.aspx.cs" Inherits="_ReporteMedio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="MedioReportViewer"  AsyncRendering="false" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteMedio.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSMedio_Medio" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSMedioSQL_Medio" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMedio"
            TypeName="DSMedioSQLTableAdapters.MedioTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_MedioCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="MedioNombre" Type="String" />
                <asp:Parameter Name="MedioCodigoPadre" Type="String" />
                <asp:Parameter Name="MedioHabilitar" Type="String" />
                <asp:Parameter Name="MedioPermiso" Type="String" />
                <asp:Parameter Name="MedioFactor" Type="String" />
                <asp:Parameter Name="Original_MedioCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="MedioCodigo" Type="String" />
                <asp:Parameter Name="MedioNombre" Type="String" />
                <asp:Parameter Name="MedioCodigoPadre" Type="String" />
                <asp:Parameter Name="MedioHabilitar" Type="String" />
                <asp:Parameter Name="MedioPermiso" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="MedioDataSource" runat="server" SelectMethod="GetMedio"
            TypeName="DSMedioTableAdapters.MedioTableAdapter"></asp:ObjectDataSource>
        &nbsp;
    </span>
           
</asp:Content>

