<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="migracionusuarios.aspx.cs" Inherits="AlfaNetAdministracion_AdminUsuario_migracionusuarios" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;<br />
    &nbsp; &nbsp;
    <br />
    <br />
    <br />
    <table border="2" style="width: 608px; height: 155px">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" BackColor="CornflowerBlue" BorderColor="#B5C7DE"
                    BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                    Text="Migración de Usuarios" Width="600px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 65px; text-align: center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True"
                    Font-Size="Small" ForeColor="ControlDarkDark" Height="45px" Width="181px">El siguiente Link realizara la migración de la tabla de usuarios desde la base de datos de manera autonoma</asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 72px">
                <asp:LinkButton ID="LinkButton1" runat="server" BorderStyle="Inset" OnClick="LinkButton1_Click">Migrar Usuarios</asp:LinkButton></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

