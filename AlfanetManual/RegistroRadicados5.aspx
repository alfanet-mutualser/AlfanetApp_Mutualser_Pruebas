<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroRadicados5.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label4" runat="server" CssClass="tmanual" Font-Bold="True" Style="text-align: center"
        Text="REGISTRO PARA LA RADICACIÓN DE DOCUMENTOS" Width="567px"></asp:Label>
    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados4.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;&nbsp;
    <br />
    <br />
    <table style="width: 640px; height: 66px">
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
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P32.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label8" runat="server" Height="118px" Style="text-justify: distribute;
                    text-align: justify" Text="Radicar, Nuevo Radicado y Cerrar.Cuando se termina de registrar o digitar o validar los datos se procedea activar el icono Radicar, acción mediante la cual se da un Número consecutivo ascendente que corresponde al Radicado."
                    Width="310px" CssClass="contmanual"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" CssClass="contmanual" Height="75px" Style="text-justify: distribute;
                    text-align: justify" Text="Nuevo Radicado, se emplea para realizar un Nuevo Registro y Cerrar se emplea para salir de la pantalla."
                    Width="310px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 17px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 17px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P45.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 17px">
                <asp:Label ID="Label2" runat="server" Height="105px" Style="text-justify: distribute;
                    text-align: justify" Text="En la parte superior derecha se visualiza el número del radicado.  Si se quiere imprimir el Autoadhesivo se activa el icono de Sticker. "
                    Width="308px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P33.bmp" style="width: 300px;
                    height: 127px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="54px" Text="Visualización del numero del radicado en el Sticker"
                    Width="308px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 29px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 29px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P34.bmp" style="width: 296px;
                    height: 203px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 29px">
                <asp:Label ID="Label1" runat="server" Text="Adjuntar imagen al radicado. Se visualiza al activar el icono Imagen,  desde:" Height="58px" Width="309px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Documentos Recibidos/P10.bmp" /><br />
                <asp:Label ID="Label6" runat="server" Text="Esta opción, se procede  a activar Browser, luego que se valida o  encuentra la imagen que se ha digitalizado y que debe haber sido guardada con el mismo número de radicación,  se procede a activar el icono Adjuntar.   Dando como resultado la visualización de la imagen. "
                    Width="308px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="133px"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;&nbsp;
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px; text-align: center;">
                &nbsp;&nbsp;&nbsp; &nbsp;
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P35.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label7" runat="server" Height="74px" Text="Cuando se activa el icono adjuntar, enseguida se visualiza esta imagen confirmando que la imagen ha sido adicionada. "
                    Width="309px" style="text-justify: newspaper; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados4.aspx">HyperLink</asp:HyperLink>
</asp:Content>

