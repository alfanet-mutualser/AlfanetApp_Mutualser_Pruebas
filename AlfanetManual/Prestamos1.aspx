<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="Prestamos1.aspx.cs" Inherits="AlfaNetManual_Prestamos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="tmanual" Font-Bold="True" Height="18px"
        Style="text-align: center" Text="PRESTAMOS" Width="549px"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/Prestamos.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/Prestamos2.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <br />
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server"
        Height="27px" Style="text-justify: distribute; text-align: justify" Text="Control de Prestamos:"
        Width="637px" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label2" runat="server"
        Height="48px" Style="text-justify: distribute; text-align: justify" Width="664px" CssClass="contmanual">Inicialmente se debe seleccionar la Serie elegida para realizar el préstamo activando la tabla de Series documentales (conocido en AlfaNet como Tablas de Retención Documental)</asp:Label><br />
    &nbsp;<img src="../AlfaNetImagen/Manual/Prestamos/P3.bmp" style="border-right: #000000 thin solid;
        border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid" /><br />
    &nbsp;<asp:Label ID="Label3" runat="server"
        Height="47px" Style="text-justify: distribute; text-align: justify" Width="665px" CssClass="contmanual">Al activar la opción prestar se puede visualizar el mensaje: Préstamo creado con su respectivo Número y  Hora de realización como se muestra a continuación.</asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <img src="../AlfaNetImagen/Manual/Prestamos/P2.bmp" /><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <img src="../AlfaNetImagen/Manual/Prestamos/P4.bmp" style="border-left-color: #ffcc66;
        border-bottom-color: #ffcc66; border-top-style: dotted; border-top-color: #ffcc66;
        border-right-style: dotted; border-left-style: dotted; border-right-color: #ffcc66;
        border-bottom-style: dotted" /><br />
    <br />
    &nbsp;<img src="../AlfaNetImagen/Manual/Prestamos/P5.bmp" style="border-right: #000000 thin solid;
        border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid" /><br />
    &nbsp;<br />
    &nbsp;<asp:Label ID="Label5" runat="server" Text="Existen varias opciones para la funcionalidad de préstamos, estas son: Préstamos (Aquí se realiza el registro de Prestamos),  Devoluciones (para validar cuando la carpeta física se devuelve) y  Consulta (para conocer el estado de los prestamos y sus devoluciones).   "
        Width="668px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <img src="../AlfaNetImagen/Manual/Prestamos/P6.bmp" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
    &nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/Prestamos.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/Prestamos2.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
</asp:Content>

