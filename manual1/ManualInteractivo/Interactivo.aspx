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
    <table style="width: 600px;">
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td>
                <object id="Object1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
        codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"><param name="movie" value="Videos/TituloChevere.swf"><param
            name="quality" value="high">
        <embed pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
            src="Videos/TituloChevere.swf" type="application/x-shockwave-flash"></embed>
    </object>
                        </td>
                        <td style="width: 100px">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Height="10px" Text="Manual Interactivo de AlfaNet" style="text-align: center" CssClass="tmanual" Width="400px" Font-Names="Cambria" Font-Size="X-Large"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 90%">
    <asp:Label ID="Label1" runat="server" Font-Names="Cambria" Font-Size="Small" Style="text-justify: inter-word;
        line-height: normal; letter-spacing: normal; text-align: justify" Text="Alfa® se concibió como un: Desarrollo lógico que permite radicar documentos recibidos, registrar documentos enviados, realizar trámites, gestión, archivo y consulta. Lejos estaban sus desarrolladores de imaginarse que mediante la Ley 594 del 14 de Julio de 2000 se aprobaba en Colombia la obligatoriedad de adelantar en las entidades del estado el Proyecto de GESTION DOCUMENTAL, el cual comprende básicamente, los principios conceptuales sobre los cuales fue desarrollado el sistema Alfa. " Width="100%"></asp:Label></td>
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
        <tr>
            <td>
            </td>
            <td style="width: 80%">
    <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="El presente manual es una manera interactiva y rapida de aprender a conocer la aplicación AlfaNet ó reforzar la destresa de su manejo. Los siguientes links contienen videos interactivos ilustrativos que muestran como AlfaNet facilita la administracion, gestión, distribución, seguridad, entre otros, de los documentos." Width="100%"></asp:Label></td>
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
    &nbsp; &nbsp; &nbsp; -<asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Cambria" OnClick="LinkButton2_Click"
        Style="text-align: center">Inicio de Sesión recuperación y cambio de contraseña</asp:LinkButton><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label5" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú Documentos:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; -<asp:LinkButton ID="LinkButton1" style="text-align: center" runat="server" Font-Names="Cambria" OnClick="LinkButton1_Click">Cómo Radicar un Documento</asp:LinkButton><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    -<asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Cambria" OnClick="LinkButton3_Click"
        Style="text-align: center">Cómo Enviar un Documento</asp:LinkButton><br /> 
      <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    -<asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Cambria" OnClick="LinkButton4_Click" Style="text-align: center">Cómo buscar un Documento Enviado Existente</asp:LinkButton><br /> 
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton5" runat="server" Font-Names="Cambria" OnClick="LinkButton5_Click" Style="text-align: center">Cómo buscar un Radicado Recibido Existente</asp:LinkButton><br /> 
    
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton6" runat="server" Font-Names="Cambria" OnClick="LinkButton6_Click" Style="text-align: center">Visor de Imágenes</asp:LinkButton><br /> 

    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label6" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú WorkFlow:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton7" runat="server" Font-Names="Cambria" OnClick="LinkButton7_Click" Style="text-align: center">WorkFlow Documentos Recibidos Externos</asp:LinkButton><br /> 

    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton8" runat="server" Font-Names="Cambria" OnClick="LinkButton8_Click" Style="text-align: center">WorkFlow Documentos Enviados Externos</asp:LinkButton><br /> 


    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton9" runat="server" Font-Names="Cambria" OnClick="LinkButton9_Click" Style="text-align: center">WorkFlow Documentos Enviados Internos</asp:LinkButton><br /> 

    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label7" runat="server" Font-Names="Cambria" Font-Size="Large" ForeColor="DarkBlue"
        Text="Menú Consultas:"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    -<asp:LinkButton ID="LinkButton10" runat="server" Font-Names="Cambria" OnClick="LinkButton10_Click" Style="text-align: center">Gestión-Expedientes</asp:LinkButton><br /> 
     
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    -<asp:LinkButton ID="LinkButton11" runat="server" Font-Names="Cambria" OnClick="LinkButton11_Click" Style="text-align: center">Gestión-Recibidos</asp:LinkButton><br /> 
 
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    -<asp:LinkButton ID="LinkButton12" runat="server" Font-Names="Cambria" OnClick="LinkButton12_Click" Style="text-align: center">Gestión-Enviados</asp:LinkButton><br /> 
   
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; 
    -<asp:LinkButton ID="LinkButton13" runat="server" Font-Names="Cambria" OnClick="LinkButton13_Click" Style="text-align: center">Gestión-Gestión de Tareas</asp:LinkButton><br /> 
  <br />
</asp:Content>

