<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ImagenUpload.aspx.cs" Inherits="AlfaNetImagen_VisorImagenes_ImagenUpload" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; width: 100px; text-align: center">
<asp:UpdatePanel id="UpdatePanel1" runat="server">
   <contenttemplate>
<asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload><BR /> <asp:Button id="BtnEnviar" onclick="BtnEnviar_Click" runat="server" Text="Enviar"></asp:Button>
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><BR /><asp:Label id="LblRuta" runat="server" Width="315px" Text="Label"></asp:Label><BR /><asp:Label id="ExceptionDetails" runat="server" Width="315px" ForeColor="Red" Text="Label" Visible="False" Font-Bold="True"></asp:Label><BR /><asp:HiddenField id="HFTipoDoc" runat="server" Value="1"></asp:HiddenField> <asp:HiddenField id="HFNroDoc" runat="server"></asp:HiddenField><asp:HiddenField id="HFPath" runat="server"></asp:HiddenField> 
</contenttemplate>
  <triggers>
<asp:PostBackTrigger ControlID="BtnEnviar"></asp:PostBackTrigger>
</triggers>
</asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
