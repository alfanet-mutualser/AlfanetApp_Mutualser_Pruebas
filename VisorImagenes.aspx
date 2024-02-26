<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisorImagenes.aspx.cs" Inherits="VImagenes" %>

<%@ Register Assembly="Neodynamic.WebControls.ImageDraw" Namespace="Neodynamic.WebControls.ImageDraw"
    TagPrefix="neoimg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Infragistics2.Web.v8.1, Version=8.1.20081.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
    
    <%@ Register Src="AlfaNetDocumentos/DocRecibido/NavDocRecibido.ascx" TagName="NavDocRecibido"
    TagPrefix="uc1" %>
<%@ Register Src="AlfaNetDocumentos/DocEnviado/NavDocEnviado.ascx" TagName="NavDocEnviado"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Visor Imagenes AlfaNet</title>
    <script language="javascript" type="text/javascript">
    
    function bderecho(e) 
    { 
        if (navigator.appName == 'Netscape' && (e.which == 3 || e.which == 2)) 
            return false; 
        else if (navigator.appName == 'Microsoft Internet Explorer' && (event.button == 2 || event.button == 3)) 
        {
            alert(" No esta permitida esta acción "); 
            return false; 
        } 
        return true; 
    } 
    if (document.layers) 
        window.captureEvents(Event.MOUSEDOWN); 
        
    window.onmousedown=bderecho; 
    document.onmousedown=bderecho;
    
// <!CDATA[

        function exit()
        {

        window.close()

        }

        function confirmSubmit()
{
var agree=confirm("Esta Completamente Seguro que Desea Eliminar la Imagen?");
if (agree)
	return true ;
else
	return false ;
}  
//function imprimir()
//{ if ((navigator.appName == "IExplorer")) { window.print() ; 
//} 
//else
//{ var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>'; 
//document.body.insertAdjacentHTML('beforeEnd', WebBrowser); WebBrowser1.ExecWB(6, -1); WebBrowser1.outerHTML = "";
//}
//}

   function Print(evt)
   //    function Print()  
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            
            //window.location.reload();
            window.print();
            
        }
        
        function ClientSidePrint(idDiv) 
            { 
                var w = 600;
                var h = 400;
                var l = (window.screen.availWidth - w)/2;
                var t = (window.screen.availHeight - h)/2;
            
                var sOption="toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,width=" + w + ",height=" + h + ",left=" + l + ",top=" + t; 
                // Get the HTML content of the div
                var sDivText = window.document.getElementById(idDiv).innerHTML;                
                // Open a new window
                var objWindow = window.open("", "Print", sOption);
                // Write the div element to the window
                objWindow.document.write(sDivText);
                objWindow.document.close(); 
                // Print the window            
                objWindow.print();
                // Close the window
                objWindow.close();            
            } 
// ]]>
  </script>
</head>
<body> 
    <form id="form1" runat="server">



    <div class="Splitters">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<ig:WebSplitter id="VerticalSplitter" runat="server" StyleSetName="Default" DynamicResize="True" style="vertical-align: top; text-align: center">
<SplitterBar CssClass="Default"></SplitterBar>
<Panes>
<ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="10%" MinSize="0px"><Template>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</Template>
</ig:SplitterPane>
<ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="90%" MinSize="0px" ScrollBars="Hidden"><Template>
<div style="VERTICAL-ALIGN: top; TEXT-ALIGN: left; height: 100%;">
<table class="Container" cellPadding="2">
<tbody>
<tr class="viewerHeader">
<td valign="top" align="left">

<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<TABLE style="WIDTH: 70%"><TBODY><TR><TD style="WIDTH: 32647px; height: 42px;"><asp:Label id="LblDocumentoNro" runat="server" Width="110px" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="width: 6px; height: 42px;">
    &nbsp; &nbsp;&nbsp;<asp:Label ID="LDocumentoFolio" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="110px"></asp:Label>&nbsp;
</TD><TD style="WIDTH: 339px; height: 42px;">
        &nbsp;&nbsp;
    </TD><TD style="WIDTH: 1265px; height: 42px;" align=right>
        &nbsp;&nbsp;
    </TD></TR><tr></tr></TBODY></TABLE>
    &nbsp;
</contenttemplate>  
</asp:UpdatePanel>

    <table border="0">
    <tbody><tr><td style="width: 26px; height: 24px;" valign="baseline"><asp:ImageButton id="prevButton" onclick="prevButton_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/prev.gif" CssClass="PointerCursor" AlternateText="Pagina Anterior..." ToolTip="Pagina Anterior..."></asp:ImageButton></TD><TD vAlign=baseline style="height: 24px"><asp:DropDownList id="ddlPages" runat="server" onselectedindexchanged="ddlPages_SelectedIndexChanged" AutoPostBack="True" CssClass="PointerCursor" ToolTip="Ir a la página..">
                    </asp:DropDownList></td><td valign=baseline style="width: 27px; height: 24px;"><asp:ImageButton id="nextButton" onclick="nextButton_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/next.gif" CssClass="PointerCursor" AlternateText="Pagina Siguiente..." ToolTip="Pagina Siguiente..."></asp:ImageButton></TD>
        <td align="left" style="width: 3px; height: 24px;" valign="middle">
            <asp:ImageButton ID="zoomMasButton" runat="server" AlternateText="Zoom In..." ToolTip="Acercar..." CssClass="PointerCursor" onclick="zoomMasButton_Click"
                ImageUrl="~/AlfaNetImagen/ToolBar/zoommas.gif"/></td>
        <td align="left" style="width: 3px; height: 24px;" valign="middle">
            <asp:ImageButton ID="zoomMenosButton" runat="server" AlternateText="Zoom Out..." ToolTip="Disminuir..." CssClass="PointerCursor" onclick="zoomMenosButton_Click"
                ImageUrl="~/AlfaNetImagen/ToolBar/zoommenos.gif" /></td>
        <td valign="middle" align="left" style="height: 24px">
        <asp:ImageButton id="rotarIzqButton" onclick="rotarIzqButton_Click" runat="server" ToolTip="Girar a la izquierda" ImageUrl="~/AlfaNetImagen/ToolBar/rotarizq.gif" CssClass="PointerCursor" AlternateText="Rotar a la izquierda...">
        </asp:ImageButton>
        <asp:ImageButton id="rotarDerButton" onclick="rotarDerButton_Click" runat="server" ToolTip="Girar a la derecha" ImageUrl="~/AlfaNetImagen/ToolBar/rotarder.gif" CssClass="PointerCursor" AlternateText="Rotar a la derecha..."></asp:ImageButton>
        </TD><TD vAlign=middle align=left style="height: 24px"></TD><TD style="WIDTH: 57px; height: 24px;" vAlign=middle align=left><asp:DropDownList id="ddlZoom" runat="server" onselectedindexchanged="ddlZoom_SelectedIndexChanged" AutoPostBack="True" CssClass="PointerCursor" ToolTip="Tamaño de la imágen...">
            
            <asp:ListItem Value="400">400%</asp:ListItem>
            <asp:ListItem Value="300">300%</asp:ListItem>
            <asp:ListItem Value="200">200%</asp:ListItem>
            <asp:ListItem Value="150">150%</asp:ListItem>
                        <asp:ListItem Value="100">100%</asp:ListItem>
                        <asp:ListItem Value="90">90%</asp:ListItem>
                        <asp:ListItem Value="80" Selected="True">80%</asp:ListItem>
            <asp:ListItem Value="70">70%</asp:ListItem>
            <asp:ListItem Value="60">60%</asp:ListItem>
            <asp:ListItem Value="50">50%</asp:ListItem>
            <asp:ListItem Value="40">40%</asp:ListItem>
            <asp:ListItem Value="30">30%</asp:ListItem>
            <asp:ListItem Value="20">20%</asp:ListItem>
                    </asp:DropDownList></TD><TD valign="middle" align="left" style="height: 24px">
                        &nbsp;</TD>
        <td align="left" valign="middle" style="height: 24px">
            &nbsp;
        </td>
        <td align="left" valign="middle" style="width: 90px; height: 24px;">
            &nbsp;</td>
        <td align="left" style="width: 60px; height: 24px;" valign="middle">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                OnClientClick="return exit();" />
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return exit();">Cerrar</asp:LinkButton></td>
    </TR></TBODY>
    </TABLE>
</td>
</tr><tr>
<td valign="top" align="center" colapan="3">
<div id ="currentPage" class="viewerContainer">
    <neoimg:ImageDraw ID="ImageDraw2" runat="server" CacheExpiresAtDateTime=""
        ImageFormat="Jpeg" Monochrome="False">
        <Canvas CenterElements="True" Fill-BackgroundColor="115, 111, 110" />
        <Elements>
            <neoimg:ImageElement  MultiPageIndex="0" Name="myTiff" NullImageUrl="~/AlfaNetImagen/iconos/icono_Blanco.JPG"
                Source="File" UseSourceDpi="False" >
            </neoimg:ImageElement>
        </Elements>
    </neoimg:ImageDraw><asp:Panel ID="Panel1" runat="server">
    <iframe id="FramePDF" name="iframe1" runat="server" enableviewstate="true" visible="false" style="width: 700px; height: 700px" frameborder="0" src="../../AlfaNetRepositorioImagenes/Registros/2010/6/VisorI2.pdf">
    </iframe>
    </asp:Panel>
    &nbsp;</div>
</td>
</tr>
</tbody>
</table>
</div>
</Template>
</ig:SplitterPane>
</Panes>
</ig:WebSplitter>  
</div> 
     <table>
            <tr>
                <td style="width: 100px">
                    <asp:HiddenField ID="HFRutaCodigo" runat="server" Value="1" />
                </td>
                <td style="width: 100px">
                    <asp:HiddenField ID="HFNroDoc" runat="server" />
                </td>
                <td style="width: 100px">
                    <asp:HiddenField ID="HFPath" runat="server" /><asp:HiddenField ID="HFFileName" runat="server" />
                </td>
                <td style="width: 100px">
                    <asp:HiddenField ID="HFZoom" runat="server" />
                </td>
            </tr>
        </table>  
    </form>
</body>
</html>
