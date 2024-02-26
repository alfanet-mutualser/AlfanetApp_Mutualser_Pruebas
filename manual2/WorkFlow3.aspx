<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="WorkFlow3.aspx.cs" Inherits="AlfaNetManual_WorkFlow" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="tmanual" Font-Bold="True" Height="18px"
        Style="text-align: center" Text="WORK FLOW" Width="539px"></asp:Label>&nbsp; 
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/WorkFlow2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/WorkFlow4.aspx">HyperLink</asp:HyperLink><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp;<asp:Label ID="Label5" runat="server" Text="Workflow Opciones Generales. El Workflow se refiere a los documentos que se han radicado y distribuido a un escritorio en especial.  Cada usuario debe, para liberar su tarea, redireccionar a un subalterno o a otro escritorio para que ejecuten una acción determinada o si ya se termina el trámite se debe archivar. En el recuadro siguiente se analizan cada una de las opciones o funcionalidades que tiene cada usuario con este modulo de Workflow. Para efectos de une mejor comprensión a continuación se explican cada una de las opciones.  "
        Width="640px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<img
        src="../AlfaNetImagen/Manual/Work%20Flow/P9.bmp" /><br />
    &nbsp;<br />
    &nbsp;<asp:Label ID="Label2" runat="server" Height="198px" Text="Explicación opciones de Workflow. Radicado Nro.   Primero se visualiza el número del radicado, si este quiere verse en detalle basta con activar esta opción.  Procedencia. El nombre de la empresa, entidad, organización o tercera persona natural que generó originalmente el documento. Ver Acción.  Se visualiza la acción determinada o definida por la persona que realiza la radicación o el paso anterior. Cargado por.  Indica de qué dependencia o paso anterior viene el documento. Ver Post it. Si del paso o dependencia anterior viene un pos it o nota electrónica en esta columna se indica,  Respuesta. Fecha morada,  se activa la funcionalidad de registrar una respuesta, digitar una carta de respuesta, imprimir el sobre y digitalizar la imagen. Esta opción solo se utiliza en usuarios que tienen instalado el certificado o firma digital. Detalle. Si se activa se conoce el detalle del radicado tal cual se registro en el momento de recibo o radicación  de la comunicación"
        Width="638px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp;
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P14.bmp" style="height: 82px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label3" runat="server" Text="Explicación opciones de Workflow. Continuación. Pos it.  Si se quiere adjuntar una nota o post it electrónico debe activar el usuario esta opción y digitar la nota, tal cual la escribe  en un documento físico.  Se busca con esta funcionalidad del post it electrónico que no se elaboren documentos internos para pasar o indicar acciones o tareas o tramites entre dependencias, con esta opción se pretende reemplazar las instrucciones que se dan en papelitos sueltos, aleluyas, documentos internos y que estas acciones  queden registradas en el sistema, evitando así contratiempos entre los usuarios, y realizar en forma detallada el seguimiento a una tarea o tramite determinado."
        Width="638px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P11.bmp" style="height: 128px" /><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/WorkFlow2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/WorkFlow4.aspx">HyperLink</asp:HyperLink><br />
    <br />
</asp:Content>

