<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroEnviados3.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server" CssClass="tmanual" Font-Bold="True" Style="text-align: center"
        Text="REGISTRO DE DOCUMENTOS ENVIADOS" Width="518px"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server"
        ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp" NavigateUrl="~/AlfaNetManual/RegistroEnviados2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroEnviados4.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    <br />
    <table style="width: 640px; height: 28px">
        <tr>
            <td style="width: 3px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Imagen</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Explicación</td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="width: 187px; height: 21px">
            </td>
            <td style="width: 299px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 25px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 25px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P18.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label2" runat="server" Height="221px" Style="text-justify: distribute;
                    text-align: justify" Text="Archivar En.  Corresponde este campo a las series subseries y tipologías en que se encuentran clasificados los documentos, de acuerdo al sistema único de archivo o Tablas de Retención documental.  Este campo sirve para indicar la carpeta física donde se archiva el documento.  Debe existir una relación directa entre esta clasificación y el archivo físico, es decir que en este campo se indica el código de la carpeta donde  físicamente se archiva el documento."
                    Width="303px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P19.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="54px" Text="Anexo.  Se indica el numero de anexos u observaciones especiales sobre estos.  "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P20.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label1" runat="server" Text="Copiar A.   Al activar este icono se active la tabla de dependencias o áreas que se encuentran matriculadas en el sistema.   Se utiliza este campo para indicar   los destinatarios adicionales internos que deben enterarse o conocer la comunicación.  "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="129px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P21.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label6" runat="server" Text="Registrar un documento.  Cuando se encuentre debidamente digitada toda la información relacionada con el documento que se quiere registrar se activa  Registrar, y si se quiere ver el registro se activa  Registro. "
                    Width="302px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="112px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P22.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label7" runat="server" Text="En la parte superior derecha de la pantalla puede visualizarse tres opciones Registro, Sticker e Imágenes.  Si se quiere anexar la o las  imágenes se activa la opción de imágenes.    "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="87px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P23.bmp" style="width: 314px;
                    height: 109px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label5" runat="server" Text="Al activar la opción de imágenes se debe activar la opción Browser la cual permite localizar la imagen que se quiere anexar al radicado, luego se da la opción de adjuntar y la imagen o imágenes quedan encadenadas al radicado. " style="text-justify: distribute; text-align: justify" CssClass="contmanual" Width="302px" Height="125px"></asp:Label></td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroEnviados2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroEnviados4.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</asp:Content>

