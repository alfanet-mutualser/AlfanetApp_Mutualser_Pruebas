<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="DocumentoRecibido.aspx.cs" Inherits="AlfaNetManual_DocumentoRecibido" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="DOCUMENTOS RECIBIDOS" style="text-align: center" CssClass="tmanual" Width="560px"></asp:Label>
    &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
        NavigateUrl="~/AlfaNetManual/DocumentoRecibido2.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" Height="144px" Style="text-justify: distribute;
        text-align: justify" Text="Se permite con este modulo registrar y matricular en el sistema todos los documentos, tareas, comunicaciones que se quieren controlar o administrar en el sistema, y que hayan sido recibidos de terceras entidades, personas naturales u organizaciones, el cual una vez se haya terminado de parametrizar o indexar, (mediante la identificación de sus índices, parámetros o variables teniendo en cuenta las tablas o maestros que se encuentran en el sistema) suministra un UNICO NUMERO CONSECUTIVO ASCENDENTE, el cual sirve para identificar ese documento, no se repiten números consecutivos.  La matricula dada por el sistema permite que se haga seguimiento a ese documento especifico hasta su destino final.  "
        Width="640px" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img
        src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P1.bmp" /><br />
    <br />
    &nbsp;<asp:Label ID="Label2" runat="server" Style="text-justify: distribute; text-align: justify"
        Text="Recomendación:   No se deben radicar documentos recibidos internos puesto que estos se controlan de salida es decir dentro de la Funcionalidad Documentos Enviados Internos. Por ser un aplicativo Web el sistema permite radicar documentos desde sitios remotos o geográficamente separados, con la ventaja  que el consecutivo se conserva."
        Width="639px" CssClass="contmanual" Height="90px"></asp:Label><br />
    <br />
    &nbsp;<asp:Label ID="Label3" runat="server" Text="A continuación se muestra la Pantalla de radicación de documentos recibidos:" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;<img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P2.bmp" />&nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink1" runat="server"
        ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp" NavigateUrl="~/AlfaNetManual/DocumentoRecibido2.aspx">HyperLink</asp:HyperLink>
</asp:Content>

