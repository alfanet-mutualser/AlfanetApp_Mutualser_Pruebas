<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="TablasMantenimiento.aspx.cs" Inherits="AlfaNetManual_Prestamos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="tmanual" Font-Bold="True" Height="18px"
        Style="text-align: center" Text="TABLA DE MANTENIMIENTO" Width="591px"></asp:Label>
    &nbsp; &nbsp;<asp:HyperLink
            ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/TablasMantenimiento1.aspx">HyperLink</asp:HyperLink>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <br />
    <br />
    &nbsp;<asp:Label ID="Label4" runat="server"
        Height="133px" Style="text-justify: distribute; text-align: justify" Text="Las tablas de mantenimiento o maestros del aplicativo constituyen las variables, categorización o índices que se registran en el sistema, debe tenerse en cuenta que por estas variables es como se clasifican los documentos o tareas que se encuentran registrados en el sistema y que por estas mismas variables es que se realiza la recuperación y consulta de los documentos.  Se recomienda de manera especial al administrador del sistema  hacer revisiones periódicas con el fin de evitar duplicidad y tratar al máximo de integrar  y no abrir registros innecesarios  o renombrar estos registros.  "
        Width="665px" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label2" runat="server"
        Height="92px" Style="text-justify: distribute; text-align: justify" Width="664px" CssClass="contmanual">Se debe estandarizar las tablas de acuerdo a necesidades específicas de cada área.  Tener en cuenta que la mayoría de las Tablas o maestros se encuentran  en tres niveles con el fin de ofrecer  agrupaciones generales o mayores y que el segundo nivel se encuentre inmenso dentro de la primera, y en igual forma la tercera clasificación en la segunda.   </asp:Label><br />
    &nbsp;<asp:Label ID="Label5" runat="server" CssClass="contmanual"
        Height="36px" Style="text-justify: distribute; text-align: justify" Width="664px" Font-Bold="True">Creación de nuevos registros en una tabla de mantenimiento.</asp:Label>
    <asp:Label ID="Label3" runat="server" CssClass="contmanual" Height="32px" Style="text-justify: distribute;
        text-align: justify" Width="664px">Existen dos formas para actualizar o crear un maestro o tabla:</asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp;<asp:Label ID="Label6" runat="server" CssClass="contmanual" Height="32px" Style="text-justify: distribute;
        text-align: justify" Width="664px">1- Desde la opción, Modulo de Administración, Maestros, de acuerdo a la siguiente grafica.</asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;<br />
    &nbsp;<asp:Label ID="Label7" runat="server" CssClass="contmanual" Height="169px" Style="text-justify: distribute;
        text-align: justify" Width="664px">Al dar clic en el menú Administración, se despliega un listado del cual se activa la opción Maestros  y se escoge luego la tabla que se quiere actualizar o alimentar con un nuevo  registro.   En el ejemplo siguiente vemos la opción  de crear un nuevo registro a la Tabla de Dependencias.  Puede verse que inicialmente se solicita el código, luego el nombre de la dependencia y luego si es una dependencia de primer nivel o de segundo nivel.  Primer nivel es  para las dependencias directivas del Fondo y la subdependencia para aquellas dependientes de las primeras.   Se recomienda siempre utilizar el código luego el cargo en forma resumida y a continuación el nombre del funcionario encargado de esa dependencia. </asp:Label><br />
    &nbsp;<br />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P36.bmp" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <img src="../AlfaNetImagen/Manual/Documentos%20Recibidos/P37.bmp" /><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:HyperLink
            ID="HyperLink4" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Avanzar.bmp"
            NavigateUrl="~/AlfaNetManual/TablasMantenimiento1.aspx">HyperLink</asp:HyperLink>
</asp:Content>

