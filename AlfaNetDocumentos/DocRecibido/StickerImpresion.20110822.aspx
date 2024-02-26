<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StickerImpresion.aspx.cs" Inherits="AlfaNetDocumentos_DocRecibido_StickerImpresion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sticker Impresion</title>
     <script language="javascript" type="text/javascript">
    function exit()
        {

        window.close()

        }
    </script>
    <script src="jscripts/cufon-yui.js"type="text/javascript"></script>
    <script src="jscripts/3_of_9_Barcode_400.font.js" type="text/javascript"></script>
	<script type="text/javascript">
			//Cufon.replace('h1'); // Works without a selector engine
			Cufon.replace('#LblCodigoBarras'); // Requires a selector engine for IE 6-7, see above
	 </script>

    <script language="javascript" type="text/javascript">
        function prevenirDeborde(){
            contenedor = document.getElementById("pnlContenido");
            sticker = document.getElementById("PnlSticker");
            if (IE){
                BordeMax = contenedor.offsetLeft + contenedor.offsetWidth;
                Borde = sticker.offsetLeft + sticker.offsetWidth;
                VerticalMax = contenedor.offsetTop + contenedor.offsetHeight;
                Vertical = sticker.offsetTop + sticker.offsetHeight;

                if(Borde > BordeMax)
                    sticker.style.left = BordeMax - sticker.offsetWidth;
                    
                if(Vertical > VerticalMax)
                    sticker.style.top = VerticalMax - sticker.offsetHeight;
                
                if(0 > sticker.offsetLeft)
                    sticker.style.left = 0;
                if(0 > sticker.offsetTop)
                    sticker.style.top= 0;

            }
            else{
                BordeMax = parseInt(window.getComputedStyle(contenedor, null).getPropertyValue("left")) + parseInt(window.getComputedStyle(contenedor, null).getPropertyValue("width"));
                Borde =    parseInt(window.getComputedStyle(sticker, null).getPropertyValue("left"))    + parseInt(window.getComputedStyle(sticker, null).getPropertyValue("width"));

                VerticalMax = parseInt(window.getComputedStyle(contenedor, null).getPropertyValue("top")) + parseInt(window.getComputedStyle(contenedor, null).getPropertyValue("height"));
                Vertical =    parseInt(window.getComputedStyle(sticker, null).getPropertyValue("top"))    + parseInt(window.getComputedStyle(sticker, null).getPropertyValue("height"));

                if(Borde > BordeMax){
                    nvoleft = BordeMax - parseInt(window.getComputedStyle(sticker, null).getPropertyValue("width"));
                    nvoleft = nvoleft + "px";
                    sticker.style.left = nvoleft;
                }

                if(Vertical > VerticalMax){
                    nvoTop = VerticalMax - parseInt(window.getComputedStyle(sticker, null).getPropertyValue("height"));
                    nvoTop = nvoleft + "px";
                    sticker.style.top = nvoTop;
                }


                if(0 > parseInt(window.getComputedStyle(sticker, null).getPropertyValue("left")))
                    sticker.style.left = "0px";
                if(0 > parseInt(window.getComputedStyle(sticker, null).getPropertyValue("top")))
                    sticker.style.top= "0px";
            } 
        }
        //La variable IE determina si estamos utilizando IE
	    var IE = document.all?true:false;
	    //Si no utilizamos IE capturamos el evento del mouse
	    if (!IE){
	        //document.captureEvents(Event.MOUSEMOVE)
            document.body.addEventListener('mousemove',prevenirDeborde,true);
        }
    </script>
    <style type="text/css">
.Sticker {
  margin: 0mm;
  padding: 0mm;
  width: 65mm;
  height: 24mm;
  font-family: "Calibri","Arial Narrow","Times New Roman","Arial","Georgia","Geneva","Andele Mono","Trebuchet";
  font-size: 8.5pt;
  overflow: hidden;
  /*
  border-style: solid;
  border-width: 1px;
  */
}
.StickerTabla {
  margin: 0mm;
  padding: 0mm;
  width: 100%;
  border-collapse: collapse;
}
.StickerTabla td, .StickerTabla tr, .StickerTabla div {
  margin: 0mm;
  padding: 0mm;
  /*height: 4mm;*/
  overflow: hidden;
}

  </style>

</head>
<body onmousemove="prevenirDeborde()" style=" margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;">    
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
         <cc1:DragPanelExtender ID="DragPanelExtender1" runat="server" TargetControlID="PnlSticker" DragHandleID="PnlSticker">
                    </cc1:DragPanelExtender>
        <asp:HiddenField ID="HFSticker" runat="server" />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
            OnClientClick="return exit();" Visible="False" /><asp:LinkButton ID="LinkButton2" runat="server"
                OnClientClick="return exit();" Visible="False">Cerrar</asp:LinkButton>
        <asp:Panel ID="pnlContenido" runat="server" HorizontalAlign="Left" style="left:0mm; top:0mm; height:280mm; width:215mm;">
                        <asp:Panel ID="PnlSticker" runat="server" Direction="LeftToRight" CssClass="Sticker">
                                <table class="StickerTabla">
                                    <tbody>
                                        <tr>
                                            <td colspan="1" rowspan="3" style="vertical-align: top; width:17mm;">
        <asp:Image ID="Image1" runat="server" style="width: 16mm; height: 12mm;" 
            ImageUrl="~/AlfaNetDocumentos/DocRecibido/logo_small.png"  /></td>
                                            <td colspan="1" rowspan="1" style="vertical-align: top">
                                                <asp:Panel ID="Panel2" runat="server" style="width: 48mm;">
                                                    <asp:Label ID="LblCliente" runat="server" style="font-weight: bold" 
                                                        Text="Mutual SER EPS-S"></asp:Label>
                                                </asp:Panel>
                                             </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" rowspan="1">
                                        <asp:Label ID="Label1" runat="server" Text="Fecha: " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblStickerFecRad" runat="server"></asp:Label>
                                        <asp:Label ID="Label17" runat="server" Text="Hora:  "></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" rowspan="1">
                                        <asp:Label ID="Label8" runat="server" Text="Radicado No: " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblStickerNroRad" runat="server" style="font-weight: bold;"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlProcedencia" runat="server">
                                                    <asp:Label ID="LabelProcedencia" runat="server" Text="Origen:" Font-Bold="True"></asp:Label>
                                                </asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="Procedencia:"></asp:Label>
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                                    <asp:Label ID="Label11" runat="server" Text="Destino: " Font-Bold="True"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:Panel ID="pnlTramiteA" runat="server" style="width:48mm; height:4mm; text-align:left; overflow:hidden;">
                                                    <asp:Label ID="LblStickercargarA" runat="server"></asp:Label>
                                                </asp:Panel>
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                            <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Direccion: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="pnlDireccion" runat="server" style=" width:48mm; height:4mm; overflow:hidden;">
                                                    <asp:Label ID="LblDireccion" runat="server"></asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Panel ID="pnlCiudad" runat="server" style=" width:48mm; height:4mm; overflow:hidden;">
                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </asp:Panel>
                                             </td>
                                        </tr>
                                    </tbody>
                                </table>
                        </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <asp:Label ID="Label13" runat="server" Font-Size="XX-Small" Text=" RADICADOR:  " Visible="False"></asp:Label><asp:Label ID="LblStickerUsr" runat="server" Font-Size="XX-Small" Font-Bold="False" Visible="False"></asp:Label>&nbsp;
                                     <asp:Label ID="Label19" runat="server" Font-Size="Small" Visible="False"> FOLIOS: </asp:Label>
                                    
                                    <asp:Label ID="Label3" runat="server"
                                    Font-Size="Small" Font-Bold="True" Visible="False">FOLIOS: </asp:Label>
                                     <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text="CIUDAD: " Font-Bold="True"></asp:Label>&nbsp;
                            <asp:Label ID="LblCodigoBarras" runat="server"
                                Font-Size="30pt" Font-Names="3 of 9 Barcode">Archivar Ltda</asp:Label>
                <asp:Label ID="Label6" runat="server" Font-Size="X-Small" Text="Hora:  " Font-Bold="True" Visible="False"></asp:Label></asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
