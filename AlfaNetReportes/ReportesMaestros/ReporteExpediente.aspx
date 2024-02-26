<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReporteExpediente.aspx.cs" Inherits="_ReporteExpediente" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt">
    <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <rsweb:ReportViewer ID="ExpedienteReportViewer" AsyncRendering="false"  runat="server" Font-Names="Verdana"
            Font-Size="8pt" Height="600px" ShowBackButton="True" Width="98%">
            <LocalReport ReportPath="AlfaNetReportes\ReportesMaestros\ReporteExpediente.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSExpediente_Expediente" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSExpedienteSQL_Expediente" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </asp:panel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExpediente"
            TypeName="DSExpedienteSQLTableAdapters.ExpedienteTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ExpedienteDataSource" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetExpediente"
            TypeName="DSExpedienteTableAdapters.ExpedienteTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                <asp:Parameter Name="ExpedienteNombre" Type="String" />
                <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
                <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                <asp:Parameter Name="ExpedienteNombre" Type="String" />
                <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp; &nbsp; &nbsp;&nbsp;
    </span>
           
</asp:Content>

