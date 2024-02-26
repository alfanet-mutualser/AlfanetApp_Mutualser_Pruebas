<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroEnviados.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="REGISTRO DE DOCUMENTOS ENVIADOS" style="text-align: center" CssClass="tmanual" Width="526px"></asp:Label>&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroEnviados2.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;<br />
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
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P5.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label5" runat="server" Height="147px" Style="text-justify: distribute;
                    text-align: justify" Text="REGISTRAR. Se activa este botón cuando se termina de  digitar o registrar los datos exigidos, en la pantalla de registro de documentos enviados. NUEVO se activa  cuando se quiere registrar un nuevo  documento o tarea y cerrar cuando se quiere terminar y salirse de esta opción.  "
                    Width="304px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 21px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P6.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 21px">
                <asp:Label ID="Label2" runat="server" Height="82px" Style="text-justify: distribute;
                    text-align: justify" Text="Se activa este botón cuando se quiere recuperar un registro ya realizado.  Se coloca el número del registro y luego se activa la lupa. "
                    Width="303px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 26px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 26px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P7.bmp" style="width: 308px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 26px">
                <asp:Label ID="Label3" runat="server" Height="72px" Text="Fecha y hora de registro.  Son activadas directamente por el sistema por lo tanto no debe tratar de modificarse. "
                    Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P8.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label1" runat="server" Text="Registro.   Cuando se quiere realizar un registro, Sticker cuando se quiere imprimir el Sticker, el cual puede imprimirse en un Sticker o rotulo o directamente en el documento.  Se recomienda la impresión directa en el documento. Imágenes.  Sirve este botón para asociar o encadenar el registro a la imagen correspondiente al documento o documentos que se están registrando."
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="182px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P9.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label6" runat="server" Text="Dependencia que remite.   Se encuentran en esta tabla todas las dependencias  que se encuentran dentro del sistema.  Se debe  Iniciar digitando el nombre o código de la pendencia e inmediatamente se desplega el correspondiente.  Luego se activa teniendo presente que corresponda a la dependencia perteneciente a la persona que firma la comunicación.  "
                    Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="185px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Enviados/P10.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label7" runat="server" Text="Destino.  Existen destinos internos o externos. Destinos internos son aquellos que se encuentran en la Tabla de dependencias y Externos los que se encuentran en la tabla de Procedencias o Destinos.  Se debe indicar o seleccionar  el botón según sea la situación. "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="125px"></asp:Label></td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroEnviados2.aspx">HyperLink</asp:HyperLink>
</asp:Content>

