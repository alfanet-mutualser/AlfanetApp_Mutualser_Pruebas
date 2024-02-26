<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroRadicados4.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" CssClass="tmanual" Font-Bold="True" Style="text-align: center"
        Text="REGISTRO PARA LA RADICACIÓN DE DOCUMENTOS" Width="623px"></asp:Label>
    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados3.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados5.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P44.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label5" runat="server" Height="174px" Style="text-justify: distribute;
                    text-align: justify" Text="Procedencia.  Nótese que tan pronto se inicia el registro o a digitar el nombre de la procedencia, esta hace búsqueda automática.  En el ejemplo vemos que se digito Ana María y puede verse como aparece de inmediato  el nombre de Ana María Carvajal.  Tan pronto se localice la Procedencia, esta se activa  para que quede registrada en el campo respectivo."
                    Width="304px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 22px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 22px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P27.bmp" style="width: 415px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 22px">
                <asp:Label ID="Label2" runat="server" Height="93px" Style="text-justify: distribute;
                    text-align: justify" Text="DETALLE.  En este campo debe registrarse el resumen del contenido del documento.  Se deben utilizar palabras claves que sirvan para identificar el documento."
                    Width="303px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P28.bmp" style="width: 410px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="187px" Text="NATURALEZA.  Esta es una variable que sirve para clasificar e identificar tipologías documentales.  Estas tipologías documentales son requeridas por los usuarios pero es el administrador del sistema quien debe establecer la necesidad de su creación, teniendo en cuenta que sean representativas y sirvan como llave de búsqueda o índice de recuperación de la información."
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 29px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 29px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P29.bmp" style="width: 410px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 29px">
                <asp:Label ID="Label1" runat="server" Text="MEDIO DE RECIBO.  Este campo no se llena y se encuentra bloqueado en esta funcionalidad.  Por defecto se coloca siempre medio de Recibo Portal." Height="89px" Width="304px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label> &nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P30.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label7" runat="server" Text="EXPEDIENTE.  Este campo no se lleva y se encuentra bloqueado en esta funcionalidad.  La persona encargada  que recibe esta solicitud  será quien asigne el expediente al cual pertenece al documento o tramite solicitado a través del Portal. "
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="133px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P31.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label6" runat="server" Text="CARGAR A Y ACCION.  El administrador del sistema asigna por defecto a que dependencia y usuario van dirigidos estos trámites, la persona encargada reasignara el tramite al funcionario encargado de acuerdo al tipo de solicitud o tramite.  "
                    Width="302px" style="text-justify: distribute; text-align: justify" CssClass="contmanual" Height="128px"></asp:Label></td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados3.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados5.aspx">HyperLink</asp:HyperLink>
</asp:Content>

