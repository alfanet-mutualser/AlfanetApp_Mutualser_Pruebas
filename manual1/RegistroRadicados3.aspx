<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroRadicados3.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label4" runat="server" CssClass="tmanual" Font-Bold="True" Style="text-align: center"
        Text="REGISTRO PARA LA RADICACIÓN DE DOCUMENTOS" Width="568px"></asp:Label>
    <asp:HyperLink
        ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados4.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
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
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P22.bmp" style="width: 358px;
                    height: 125px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label5" runat="server" Height="115px" Style="text-justify: distribute;
                    text-align: justify" Text="Anexos.  En esta opción deben registrarse las novedades sobre los anexos, como numero de anexos, estado de recibo, faltantes y cualquier otra observación que la persona que radica considera necesaria y conveniente. "
                    Width="304px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 22px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 22px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P23.bmp" style="width: 360px;
                    height: 163px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 22px">
                <asp:Label ID="Label2" runat="server" Height="105px" Style="text-justify: distribute;
                    text-align: justify" Text="Enterar a. Corresponde a las copias al carbón esto es  el envío virtual de la comunicación otras dependencias internas o que se encuentren dentro del  sistema matriculados como usuarios."
                    Width="303px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P24.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="167px" Text="DOCUMENTOS. Tramites en Linea. Se accede a esta funcionalidad cuando se activa esta opción en el Menú DOCUMENTOS.  Estos trámites en línea sirven para que los usuarios externos puedan accesar al aplicativo a través del portal del Fondo.  En el portal se debe estar matriculado previamente con  usuario y login   para tener acceso a este servicio "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 29px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 29px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P25.bmp" style="width: 361px;
                    height: 265px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 29px">
                <asp:Label ID="Label1" runat="server" Text="DOCUMENTOS. TRAMITES EN LINEA. PROCEDIMIENTO.   La fecha y hora es suministrada por el sistema.  " Height="68px" Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Image ID="Image1" runat="server" DescriptionUrl="~/AlfaNetImagen/Manual/Documentos Recibidos/P26.bmp"
                    ImageUrl="~/AlfaNetImagen/Manual/Documentos Recibidos/P26.bmp" /><br />
                <asp:Label ID="Label6" runat="server" Text="NUI.  Que sirve para identificar la procedencia utilizando el Nit o la cedula o cualquier otro identificador mediante números.  " Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="74px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                </td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados4.aspx">HyperLink</asp:HyperLink>
</asp:Content>

