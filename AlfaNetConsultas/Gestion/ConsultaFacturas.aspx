<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConsultaFacturas.aspx.cs" Inherits="AlfaNetConsultas_Gestion_ConsultaFacturas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="HFmDepCod" runat="server" />
    <div style="min-height:600px;">
        <iframe id="facturasFrame" runat="server" style="min-height:600px;" frameborder="0" width="100%" height="200">Si ves este mensaje, significa que tu navegador no tiene soporte para marcos o el mismo está deshabilitado</iframe>
    </div>
</asp:Content>

