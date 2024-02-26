<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="Administracion1.aspx.cs" Inherits="AlfaNetManual_Administracion" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label10" runat="server" CssClass="tmanual" Font-Bold="True"
        ForeColor="DarkBlue" Height="18px" Style="text-align: center" Text="ADMINISTRACIÓN"
        Width="585px"></asp:Label>
    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/Administracion.aspx">HyperLink</asp:HyperLink><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;
    <br />
    <br />
    <table style="width: 640px; height: 28px">
        <tr>
            <td style="width: 3px">
            </td>
            <td colspan="2" style="border-right: silver thin solid; border-top: silver thin solid;
                border-left: silver thin solid; border-bottom: silver thin solid; text-align: center" class="contmanual">
                FUNCIONALIDAD DEL MODULO ADMINISTRACIÓN</td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Imagen</td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; text-align: center" class="contmanual">
                Explicación</td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td style="width: 187px; height: 21px">
            </td>
            <td style="width: 356px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 25px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 25px">
                &nbsp; &nbsp; &nbsp; &nbsp;<img src="../AlfaNetImagen/Manual/Administracion/P21.bmp" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; height: 25px">
                <asp:Label ID="Label5" runat="server" Height="123px" Style="text-justify: distribute;
                    text-align: justify" Text="Administración usuarios. Antes de crear los usuarios  debe de estar debidamente creada e identificada la tabla de Dependencias.  Adicionalmente se debe tener el listado de usuarios, sus perfiles de acuerdo al nivel, el nombre de usuario y el Password que se asignara.  "
                    Width="307px" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 18px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 18px">
                <img src="../AlfaNetImagen/Manual/Administracion/P22.bmp" style="width: 309px; height: 261px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; height: 18px">
                <asp:Label ID="Label2" runat="server" Height="146px" Style="text-justify: distribute;
                    text-align: justify" Text="Administración. Usuarios. En la grafica de la izquierda puede visualizarse la pantalla general para la creación de usuarios del sistema.  Esta pantalla solo puede ser activada por el administrador del sistema.  Este modulo consta de tres partes principales las cuales se explican independientemente cada una. "
                    Width="308px" CssClass="contmanual"></asp:Label><br />
                <asp:Label ID="Label3" runat="server" Height="26px" Text="1. Creación de usuarios. Datos del usuario"
                    Width="307px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Height="26px" Width="309px" style="text-justify: distribute; text-align: justify" CssClass="contmanual">2. Perfil del Usuario</asp:Label><br />
                <asp:Label ID="Label4" runat="server" Height="26px" Width="308px" style="text-justify: distribute; text-align: justify" CssClass="contmanual">3. Dependencia del usuario. </asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Administracion/P23.bmp" style="width: 307px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label6" runat="server" Height="45px" Style="text-justify: distribute;
                    text-align: justify" Text="1. Administración. Creación usuarios. Datos del usuario. "
                    Width="309px" CssClass="contmanual"></asp:Label><br />
                <asp:Label ID="Label7" runat="server" Height="82px" Text="Datos del usuario.  Es importante llenar todos los campos de datos del usuario como son Nombre y Apellidos, Login Contraseña confirmar contraseña y dirección de corre electrónico.   " style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Administracion/P24.bmp" style="width: 307px; height: 78px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label8" runat="server" Text="Perfil del Usuario. En el perfil del usuario se debe activar el correspondiente a ese usuario o la combinación de varios perfiles.  Existen básicamente los perfiles de Administrador, Consultas, Documentos, reportes, Workflow. " style="text-justify: distribute; text-align: justify" CssClass="contmanual" Width="307px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 24px">
            </td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 187px; border-bottom: silver thin solid; height: 24px">
                <img src="../AlfaNetImagen/Manual/Administracion/P25.bmp" style="width: 306px; height: 86px" /></td>
            <td style="border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid;
                width: 356px; border-bottom: silver thin solid; height: 24px">
                <asp:Label ID="Label9" runat="server" Text="Dependencia del usuario. Con el fin de crear el vinculo entre el usuario y la dependencia a la cual pertenece este usuario, de tal forma que pueda recibir los documentos que se distribuyan a su escritorio virtual,  y el perfil se requiere vincular el usuario a la dependencia que corresponda para lo cual se debe activar  esta opción.  " style="text-justify: distribute; text-align: justify" CssClass="contmanual" Width="308px"></asp:Label></td>
        </tr>
    </table>
    <br />
    &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/Administracion.aspx">HyperLink</asp:HyperLink><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</asp:Content>

