<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Interactivo.aspx.cs" Inherits="AlfaNetManual_ManualInteractivo_Interactivo" Title="Manual Interactivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" for="Object1" event="onclick">
// <!CDATA[
return Object1_onclick()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
    <table>
        <tr>
            <td style="width: 100px">
                <object id="Object1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
        codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
        style="width: 165px; height: 60px"><param name="movie" value="Videos/TituloChevere.swf"><param
            name="quality" value="high">
        <embed height="600" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
            src="Alfanet             animacion 3D negro.swf" type="application/x-shockwave-flash" width="800"></embed>
    </object>
            </td>
            <td style="width: 100px">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Height="18px" Text="Manual Interactivo de AlfaNet" style="text-align: center" CssClass="tmanual" Width="640px" Font-Names="Cambria" Font-Size="X-Large"></asp:Label></td>
        </tr>
    </table>
    &nbsp;<br />
    <table style="width: 100%; height: 100%">
        <tr>
            <td>
            </td>
            <td style="width: 90%">
    <asp:Label ID="Label1" runat="server" Font-Names="Cambria" Font-Size="Large" Style="text-justify: inter-word;
        line-height: normal; letter-spacing: normal; text-align: justify" Text="Alfa® se concibió como un: Desarrollo lógico que permite radicar documentos recibidos, registrar documentos enviados, realizar trámites, gestión, archivo y consulta. Lejos estaban sus desarrolladores de imaginarse que mediante la Ley 594 del 14 de Julio de 2000 se aprobaba en Colombia la obligatoriedad de adelantar en las entidades del estado el Proyecto de GESTION DOCUMENTAL, el cual comprende básicamente, los principios conceptuales sobre los cuales fue desarrollado el sistema Alfa. " Width="100%"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 90%">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 80%">
    <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="Large" Text="El presente manual es una manera interactiva y rapida de aprender a conocer la aplicación AlfaNet ó reforzar la destresa de su manejo. Los siguientes links contienen videos interactivos ilustrativos que muestran como AlfaNet facilita la administracion, gestión, distribución, seguridad, entre otros, de los documentos." Width="100%"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 80%">
            </td>
            <td>
            </td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label4" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú Inicio:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Inicio de sesion recuperacion y cambio de contraseña.exe" Font-Names="Cambria">Inicio de Sesión recuperación y cambio de contraseña</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label5" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú Documentos:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink1"  style="text-align: center" runat="server" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Radicar un Documento.exe" Font-Names="Cambria">Cómo Radicar un Documento</asp:HyperLink>
    <br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Enviar un documento.exe" Font-Names="Cambria">Cómo Enviar un Documento</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/como buscar un documento enviado existente.exe" Font-Names="Cambria">Cómo buscar un Documento Enviado Existente</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink
        ID="HyperLink4" runat="server" Font-Names="Cambria" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Como buscar un radicado recibido existente.exe">Cómo buscar un Radicado Recibido Existente</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink
        ID="HyperLink7" runat="server" Font-Names="Cambria" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Visor de Imagenes.exe">Visor de Imágenes</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label6" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú WorkFlow:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Documentos Recibidos Externos.exe" Font-Names="Cambria">WorkFlow Documentos Recibidos Externos</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink8" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Documentos Enviados Externos.exe">WorkFlow Documentos Enviados Externos</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink9" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Documentos Enviados Internos.exe">WorkFlow Documentos Enviados Internos</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label7" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú Consultas:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink10" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Gestion Expedientes.exe">Gestión-Expedientes</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink11" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Gestion Recibidos.exe">Gestión-Recibidos</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink12" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Gestion Enviados.exe">Gestión-Enviados</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:HyperLink ID="HyperLink13" runat="server" Font-Names="Cambria"
        NavigateUrl="~/AlfaNetManual/ManualInteractivo/Videos/Gestion de Tareas.exe">Gestión-Gestión de Tareas</asp:HyperLink><br />
</asp:Content>

