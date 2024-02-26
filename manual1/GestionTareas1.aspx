<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="GestionTareas1.aspx.cs" Inherits="AlfaNetManual_Administracion" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="DarkBlue" Height="18px" Text="GESTIÓN DE TAREAS" style="text-align: center" CssClass="tmanual" Width="519px"></asp:Label>&nbsp;
    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/GestionTareas.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/GestionTareas2.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    &nbsp;<asp:Label ID="Label4" runat="server" CssClass="contmanual" Height="54px" Style="text-justify: distribute;
        text-align: justify" Text="3- Indique las características de la búsqueda, es decir si lo va hacer por: Fecha de Radicación, Vencimiento, Entre Dependencias... etc."
        Width="636px"></asp:Label><br />
    &nbsp;<asp:Label ID="Label5" runat="server" CssClass="contmanual" Height="48px" Style="text-justify: distribute;
        text-align: justify" Text="Para este caso emplearemos: Fecha de Radicación, si estan Resueltos o por Resolver y  por Naturaleza"
        Width="636px"></asp:Label><br />
    &nbsp;<asp:Label ID="Label7" runat="server"
        Height="38px" Style="text-justify: distribute; text-align: justify" Text="4- Seleccione la fecha inicial, dándole clic al calendario"
        Width="636px" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp;<img src="../AlfaNetImagen/Manual/GestionTareas/P4.bmp" style="width: 636px;
        height: 477px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label6" runat="server" CssClass="contmanual" Height="41px" Style="text-justify: distribute;
        text-align: justify" Text="5- Seleccione la fecha final, dándole clic al calendario"
        Width="636px"></asp:Label><br />
    &nbsp; &nbsp;<br />
    &nbsp;<img src="../AlfaNetImagen/Manual/GestionTareas/P5.bmp" style="width: 628px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="contmanual" Height="34px" Style="text-justify: distribute;
        text-align: justify" Text="6- Active la opción Resueltos o Por resolver y seleccione una de los elementos que allí se ven; para este caso emplearemos resueltos."
        Width="636px"></asp:Label>
    <asp:Label ID="Label2" runat="server" CssClass="contmanual" Height="34px" Style="text-justify: distribute;
        text-align: justify" Text="7- Active la opción Naturaleza e indiquela." Width="636px"></asp:Label><br />
    <br />
    <img src="../AlfaNetImagen/Manual/GestionTareas/P6.bmp" style="width: 634px; height: 608px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label8" runat="server" CssClass="contmanual" Height="34px" Style="text-justify: distribute;
        text-align: justify" Text="8- De clic en Buscar (Parte inferior de la Pantalla)"
        Width="636px"></asp:Label>&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/GestionTareas.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/GestionTareas2.aspx">HyperLink</asp:HyperLink><br />
</asp:Content>

