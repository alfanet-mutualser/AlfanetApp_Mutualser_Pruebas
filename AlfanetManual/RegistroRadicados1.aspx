<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="RegistroRadicados1.aspx.cs" Inherits="AlfaNetManual_RegistroRadicados1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server" CssClass="tmanual" Font-Bold="True" Style="text-align: center"
        Text="REGISTRO PARA LA RADICACIÓN DE DOCUMENTOS" Width="569px"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados.aspx">HyperLink</asp:HyperLink>
    <asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;
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
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P14.bmp" style="width: 243px;
                    height: 159px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label5" runat="server" Height="317px" Style="text-justify: distribute;
                    text-align: justify" Text="Fecha de Vencimiento.  Esta funcionalidad sirve para asignar tiempos para el  cumplimiento de la tarea o tiempo para realizar la gestión de cada una de las tareas o comunicaciones radicadas en el sistema. En atención a políticas internas de cada organización el radicador debe asignar los tiempos que la organización o entidad haya determinado.  Cuando no se encuentren determinados estos tiempos, se recomienda por defecto que se asignen 15 días para su trámite o cualquier otro que el usuario determine. Se recomienda establecer políticas claras para determinar los tiempos de cumplimiento de la gestión, teniendo en cuenta la modalidad, naturaleza o tipología del documento. "
                    Width="304px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 22px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 22px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P15.bmp" style="width: 379px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 22px">
                <asp:Label ID="Label2" runat="server" Height="309px" Style="text-justify: distribute;
                    text-align: justify" Text="Procedencia.   Existe un maestro importante para el sistema que es la tabla de procedencias (terceras empresas, organizaciones, institutos, personas naturales) que deben matricularse en el sistema. Se recomienda de manera especial anteponer el NUI (Numero de identificación único para el sistema correspondiente a la cedula de la persona natural o nit de la organización).  Se recomienda que el administrador del sistema establezca políticas claras para estandarizar la creación de Procedencias con el fin de no DUPLICAR las procedencias con diferente  nombre o abreviatura.  Se sugiere de manera especial utilizar el mismo nombre que aparece en el logotipo de la Comunicación.  "
                    Width="303px" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P16.bmp" style="width: 375px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 299px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="205px" Text="Detalle.   En este campo se debe registrar el resumen o contenido principal que trata la comunicación, también debe utilizarse para hacer anotaciones especiales que considere debe hacerse por parte de la persona que realiza la radicación.  También se utiliza para hacer anotaciones especiales de seguimiento y control y cualquier otro dato que el administrador de radicación considere importante  tener en cuenta."
                    Width="303px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
                <br />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/RegistroRadicados.aspx">HyperLink</asp:HyperLink><asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/RegistroRadicados2.aspx">HyperLink</asp:HyperLink>&nbsp;<br />
</asp:Content>

