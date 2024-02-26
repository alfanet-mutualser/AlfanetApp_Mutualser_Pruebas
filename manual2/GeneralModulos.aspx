<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="GeneralModulos.aspx.cs" Inherits="AlfaNetManual_GeneralModulos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;<br />
    &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="True" Height="18px" Text="PRESENTACIÓN GENERAL DE LOS MODULOS" style="text-align: center" CssClass="tmanual" Width="695px"></asp:Label><br />
    <br />
    &nbsp;<asp:Label ID="Label7" runat="server" CssClass="contmanual" Text="A continuación se presenta una matriz que resume las caracteristicas de cada uno de los modulos de AlfaNet."
        Width="694px"></asp:Label><br />
    <br />
    <table style="width: 594px; height: 28px">
        <tr>
            <td style="width: 3px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Nombre Modulo</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Imagen</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Detalle</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Relación con Otros Modulos</td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="width: 115px; height: 21px">
            </td>
            <td style="width: 138px; height: 21px">
            </td>
            <td style="width: 540px; height: 21px">
            </td>
            <td style="width: 212px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 24px; text-align: center;" class="contmanual">
                1.<br />
                Inicio</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Inicio/P1.bmp" style="width: 144px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label1" runat="server" Text="Permite este modulo entrar y operar el sistema.  Solamente personas autorizadas y que han sido previamente matriculadas en el Sistema, pueden tener acceso.  No todos los usuarios tienen acceso o permiso para manejar todas las funcionalidades.   "
                    Width="207px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label5" runat="server" Height="126px" Style="text-justify: distribute;
                    text-align: justify" Text="Administracion, usuarios, maestro de usuarios. " Width="204px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 21px; text-align: center;" class="contmanual">
                2.<br />
                Documentos</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 21px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P2.bmp" style="width: 147px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 21px">
                <asp:Label ID="Label4" runat="server" Text="Este modulo maneja la parte operativa y funcional del sistema.  Aquí se registran todos los datos del sistema. "
                    Width="207px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 21px">
                <asp:Label ID="Label2" runat="server" Height="88px" Style="text-justify: distribute;
                    text-align: justify" Text="Tiene relacion con todos los modulos del sistema."
                    Width="205px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 24px; text-align: center;" class="contmanual">
                3.
                <br />
                Work Flow</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P3.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label8" runat="server" Text="Modulo que permite conocer los documentos o tareas asignadas a cada usuario y al mismo tiempo direccionar las tareas a otros escritorios o usuarios, permite anexar imágenes, colocar posits electronicos y todas las opciones para distribuir documentos. "
                    Width="208px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label3" runat="server" Height="42px" Text="Depende del modulo de Documentos, pues existe la relacion directa entre lo que se radica en la opcion de documentos Recibidos y el Registro de documentos Enviados para su operación.  "
                    Width="204px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 20px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 20px; text-align: center;" class="contmanual">
                4. Administración</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 20px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P4.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 20px">
                <asp:Label ID="Label14" runat="server" Text="Permite este modulo, crear los maestros o tablas del sistema, esto es, los datos que conforman los parametros o variables que permiten la clasificacion y organización  de los datos que se consignen y registren en el sistema.  Este modulo permite crear tablas, y matricular usuarios. "
                    Width="205px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 20px">
                <asp:Label ID="Label6" runat="server" Text="Tiene relacion directa con todos los modulos. "
                    Width="206px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 37px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 37px; text-align: center;" class="contmanual">
                5.<br />
                Consultas</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 37px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P5.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 37px">
                <asp:Label ID="Label9" runat="server" Text="Aquí se puede  recuperar y consultar la informacion registrada y procesada en el sistema.  Teniendo en cuenta la forma en que se matriculan los datos en el sistema, asi mismo se suministra informacion de facil recuperacion. "
                    Width="204px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 37px">
                <asp:Label ID="Label15" runat="server" Text="Tiene relacion directa con el modulo de Documentos, pues el resultado depende tanto de la radicación como del registro de los documentos."
                    Width="204px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 17px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 17px; text-align: center;" class="contmanual">
                6.
                <br />
                Reportes</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 17px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P6.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 17px">
                <asp:Label ID="Label11" runat="server" Text="Admite este modulo realizar la impresión de los los maestros  o tablas del sistema; aunque no es recomendable "
                    Width="201px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 17px">
                <asp:Label ID="Label16" runat="server" Text="Tiene relacion directa con el modulo de Consultas, pues el resultado es elmismo de consultas pero permite su impresión."
                    Width="204px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 24px; text-align: center;" class="contmanual">
                7.<br />
                Prestamos</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P7.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label12" runat="server" Text="Aunque alfanet® permite el manejo virtual de los documentos  o registros  tambien maneja y administra una relacion directa con los archivos fisicos, indicando mediante la utilizacion de codigos relacionados  en algunos casos a las Tablas de Retencion Documental o al sistema de clasificacion propio de cada organización, el sitio exacto (correspondiente a una secuencia numerica ascendente)  donde se encuentra archivado fisicamente el documentos."
                    Width="202px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label17" runat="server" Text="Existe una relacion directa con el modulo Workflow de Documentos recibidos, porque alli define  el   usuario la carpeta fisica donde se archiva el documento."
                    Width="204px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 115px; border-bottom: silver thin solid; height: 24px; text-align: center;" class="contmanual">
                8.<br />
                Ayuda</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 138px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/General%20Modulos/P8.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 540px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label13" runat="server" Text="Sirve este modulo para consultar el manual, se recomienda identificar el modulo donde se encuentra la funcionalidad sobre la cual se desea investigar. "
                    Width="200px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 212px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label18" runat="server" Text="Todos los modulos" CssClass="contmanual"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

