<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="WorkFlow1.aspx.cs" Inherits="AlfaNetManual_WorkFlow" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="tmanual" Font-Bold="True" Height="18px"
        Style="text-align: center" Text="WORK FLOW" Width="547px"></asp:Label><asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/WorkFlow.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/WorkFlow2.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <br />
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server"
        Height="76px" Style="text-justify: distribute; text-align: justify" Text="Workflow Escritorio. Al abrir el escritorio con perfil de Workflow se puede visualizar tres opciones: Documentos recibidos externos, Documentos enviados externos y Documentos enviados internos.   Se debe activar cada una de las opciones para conocer en detalle la relación de documentos que se recibieron, se radicaron y se realizo la distribución como primera opción a este escritorio especifico."
        Width="637px" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp;&nbsp; 
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P3.bmp" style="width: 609px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label2" runat="server" Text="Workflow. Documentos recibidos externos.  Se registran todos los documentos que se han recibido, radicado y direccionado directamente a este usuario específico para que inicie el proceso de trámite.  Existen tres variables principales: Documentos anteriores recibidos externos. Documentos anteriores enviados externos. Documentos anteriores enviados Internos." Height="87px" Width="634px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label7" runat="server" Height="86px" Text="Se debe activar cada una de estas opciones para obtener la relación completa.  Se tiene en este grafico la opción con una circunferencia roja que simula un semáforo con la explicación de que se tienen documentos vencidos, Amarillo que se tienen documentos a vencer y verde que se tienen documentos pendientes de tramite."
        Width="634px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label>
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P4.bmp" style="width: 623px; height: 206px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label6" runat="server" Text="Workflow. Histórico Recibido. Histórico enviado.   De cada uno de los documentos recibidos en la opción Workflow, al abrir se encuentra una relación de los documentos que fueron distribuidos directamente a este escritorio específico.  Histórico recibido. Son los registros de los radicados que ya fueron tramitados por este usuario específico. Histórico Enviado es la relación de los documentos recibidos en este escritorio de otras dependencias y que ya se encuentran tramitados. "
        Width="634px" Height="106px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P5.bmp" /><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink3" runat="server"
        ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp" NavigateUrl="~/AlfaNetManual/WorkFlow.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/WorkFlow2.aspx">HyperLink</asp:HyperLink><br />
</asp:Content>

