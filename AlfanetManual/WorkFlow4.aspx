<%@ Page Language="C#" MasterPageFile="~/AlfaNetManual/MainManual.master" AutoEventWireup="true" CodeFile="WorkFlow4.aspx.cs" Inherits="AlfaNetManual_WorkFlow" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="tmanual" Font-Bold="True" Height="18px"
        Style="text-align: center" Text="WORK FLOW" Width="572px"></asp:Label>&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/WorkFlow3.aspx">HyperLink</asp:HyperLink><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp;<br />
    <br />
    &nbsp;<asp:Label ID="Label5" runat="server" Text="Funcionalidad de Workflow. Acción. Esta funcionalidad es quizás la más importante pues al activarse permite que el usuario escoja una de estas opciones:"
        Width="640px" Height="47px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label2" runat="server" Height="25px" Text="1. Pasar a una dependencia, utilizando la tabla de Dependencias."
        Width="640px" CssClass="contmanual"></asp:Label>
    &nbsp;<asp:Label ID="Label3" runat="server" Text="2.&#9;Archivar el documento o tarea  utilizando la tabla de Series. "
        Width="640px" Height="24px" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label4" runat="server" Height="24px" Text="3. Seleccionar una multitarea. Utilizando la tabla de Dependencias."
        Width="640px" CssClass="contmanual"></asp:Label><br />
    &nbsp;<asp:Label ID="Label6" runat="server" Height="23px" Text="Nótese que al activar el mouse se despliegan las diferentes opciones que ofrece este modulo."
        Width="640px" CssClass="contmanual"></asp:Label><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img
        src="../AlfaNetImagen/Manual/Work%20Flow/P12.bmp" style="width: 235px; height: 210px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label7" runat="server" Height="66px" Text="CARGAR A. Cuando una tarea o documento deba enviarse a otra dependencia para que realice una tarea determinada se utiliza esta opción la cual permite al activarse, que se seleccione la dependencia, se pueden visualizar los tres niveles de dependencias.  "
        Width="639px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P13.bmp" style="width: 447px; height: 153px" /><br />
    <br />
    &nbsp;<asp:Label ID="Label8" runat="server" Height="86px" Text="ACCION. Una vez se seleccione la dependencia  a la cual se le envía  o pasa el documento o tarea se debe indicar la acción,  en esta columna, al activarse se pueden ver las diferentes acciones que se encuentran registrados en la tabla maestra  Si no es suficiente esta opción y se requiere dar mayor claridad, se debe utilizar el post it electrónico donde se puede ampliar la acción o instrucciones que se quieran dar.    "
        Width="639px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img src="../AlfaNetImagen/Manual/Work%20Flow/P17.bmp" /><br />
    &nbsp;<asp:Label ID="Label9" runat="server" Height="149px" Text="Terminar acción de trámite.  Cuando un usuario termina la acción de trámite, esto es, pasar a otra dependencia o usuario, archivar la tarea porque esta ya se cumplió o enviar la tarea o el documento  a otras dependencias para que realicen acciones adicionales, luego de haber hecho las indicaciones requeridas esto es, cargar a una dependencia, definir la acción, registrar  el post it,  debe terminar la tarea para lo cual debe primero chulear el recuadro que se encuentra a la izquierda y luego activar la opción Terminar.  Esta es la única forma de conseguir liberar el escritorio de la tarea. El responder y registrar una comunicación como respuesta a una recibida, no libera al usuario de la tarea."
        Width="639px" style="text-justify: distribute; text-align: justify" CssClass="contmanual"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <img src="../AlfaNetImagen/Manual/Work%20Flow/P19.bmp" /><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/AlfaNetImagen/Manual/Retroceder.bmp"
        NavigateUrl="~/AlfaNetManual/WorkFlow3.aspx">HyperLink</asp:HyperLink><br />
</asp:Content>

