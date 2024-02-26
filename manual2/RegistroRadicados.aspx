<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroRadicados.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="REGISTRO PARA LA RADICACIÓN DE DOCUMENTOS" style="text-align: center" CssClass="tmanual" Width="571px"></asp:Label>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;&nbsp;
    <br />
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
            <td style="width: 3px; height: 26px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 26px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P9.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 26px">
                <asp:Label ID="Label5" runat="server" Height="151px" Style="text-justify: distribute;
                    text-align: justify" Text="Cuando se termina de validar los datos utilizando los maestros o tablas de la pantalla de ¨radicación de documentos recibidos¨, el usuario  activa la opción ¨radicar¨ e inmediatamente el sistema suministra el numero de matricula o identificación. UNICO NUMERO CONSECUTIVO ASCENDENTE."
                    Width="304px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 21px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P10.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 21px">
                <asp:Label ID="Label2" runat="server" Height="77px" Style="text-justify: distribute;
                    text-align: justify" Text="Sticker.  Al activar la opción de sticker se activa el formato para imprimir  el sticker utilizando fuente de código de barras. "
                    Width="303px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P10.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="73px" Text="Imágenes. Permite tener acceso a las imágenes e insertarlas o vincularlas al radicado."
                    Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P11.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label1" runat="server" Text="Permite registrar el número de identificación perteneciente a la tercera empresa  u organización.  Cuando el documento no traiga este número de identificación se deja el campo en blanco."
                    Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="112px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P12.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px" class="contmanual">
                <asp:Label ID="Label6" runat="server" Text="Cuando un documento se registra en este campo debe, utilizando la agenda que trae el aplicativo, indicarse la fecha exacta correspondiente al documento o registro que se realiza.  En caso excepcional que no traiga la fecha se coloca la correspondiente al día de radicado, y en el campo ¨detalle¨ indicar que no se puede identificar la fecha del documento original."
                    Width="304px" style="text-justify: distribute; text-align: justify" Height="190px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P13.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label7" runat="server" Text="El sistema permite visualizar la fecha en que se radica el documento.  Esta fecha no puede ser cambiada ni modificada por el usuario ni por el administrador del sistema."
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="90px"></asp:Label></td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink>
</asp:Content>

