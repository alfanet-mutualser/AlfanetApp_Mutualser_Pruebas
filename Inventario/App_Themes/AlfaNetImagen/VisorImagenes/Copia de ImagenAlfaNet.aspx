<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copia de ImagenAlfaNet.aspx.cs" Inherits="Imagen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
      <style>
        .modalBackground {
            background-color:Gray;
            filter:alpha(opacity=70);
            opacity:0.7;
        }
        .thumbnail{
            height: 100px;
            width: 130px;
            cursor: hand;
        } 
        .imgpopup{
            height: 500px;
            width: 600px;
        }            
    </style>
    
     <script language="JavaScript1.2">

//Image zoom in/out script- by javascriptkit.com
//Visit JavaScript Kit (http://www.javascriptkit.com) for script
//Credit must stay intact for use

var zoomfactor=0.10 //Enter factor (0.05=5%)

function zoomhelper(){
if (parseInt(whatcache.style.width)>10&&parseInt(whatcache.style.height)>10){
whatcache.style.width=parseInt(whatcache.style.width)+parseInt(whatcache.style.width)*zoomfactor*prefix
whatcache.style.height=parseInt(whatcache.style.height)+parseInt(whatcache.style.height)*zoomfactor*prefix
}
}

function zoom(originalW, originalH, what, state){
if (!document.all&&!document.getElementById)
return
whatcache=eval("document.images."+what)
prefix=(state=="in")? 1 : -1
if (whatcache.style.width==""||state=="restore"){
whatcache.style.width=originalW
whatcache.style.height=originalH
if (state=="restore")
return
}
else{
zoomhelper()
}
beginzoom=setInterval("zoomhelper()",100)
}

function clearzoom(){
if (window.beginzoom)
clearInterval(beginzoom)
}

</script>
    
    <script type="text/javascript">
        var currentImgId = 'img01';
    
        function onNextImageClick(){
        
            switch(currentImgId){
                case 'img01':
                    currentImgId = 'img02';
                    break;
                case 'img02':
                    currentImgId = 'img03';                
                    break;
                case 'img03':
                    currentImgId = 'img04';                
                    break;
                case 'img04':
                    currentImgId = 'img05';               
                    break;
                case 'img05':
                    currentImgId = 'img01';                
                    break;     
                default: 
                    alert("Unknown image!");                                                                               
            }
            
            togglePopupImage($get(currentImgId));
        }
        
        function onPreviousImageClick(){
        
            switch(currentImgId){
                case 'img01':
                    currentImgId = 'img05';
                    break;
                case 'img02':
                    currentImgId = 'img01';                
                    break;
                case 'img03':
                    currentImgId = 'img02';                
                    break;
                case 'img04':
                    currentImgId = 'img03';               
                    break;
                case 'img05':
                    currentImgId = 'img04';                
                    break;     
                default: 
                    alert("Unknown image!");                                                                               
            }
            
            togglePopupImage($get(currentImgId));        
        }
    
        function togglePopupImage(thumbnail){
            $get('spnImageText').innerHTML = thumbnail.alt;
            $get('imgPopup').src = thumbnail.src;             
        }
    </script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server">
        </asp:ScriptManager>
        
              <asp:Image ID="Image3" runat="server" AlternateText='<%# Eval("ImagenesDescripcion", "ImagenesDescripcion: {0}") %>'
                 Height="120px" ImageUrl='<%# Eval("ImagenesId", "ImagenAlfaNet.aspx?codImagen={0}") %>' Width="124px" />
        <asp:Image ID="Image1" runat="server" Height="38px" Width="37px" /><br />
        <br />
        <img id="img01" runat="server" alt="Big gold ball hovering on water" class="thumbnail"
            height="1660" onclick="togglePopupImage(this);" src="../MainPages/MainAdministracion.JPG"
            width="1275" /><cc1:modalpopupextender id="ModalPopupExtender1" runat="server" backgroundcssclass="modalBackground"
                cancelcontrolid="btnCancel" drag="true" dropshadow="false" popupcontrolid="pnlPopup"
                targetcontrolid="img01" x="0" y="0">
            </cc1:modalpopupextender><img id="img02" runat="server" alt="Upclose facial of a tiger"
                class="thumbnail" height="1617" onclick="togglePopupImage(this);" src="../MainPages/MainConsultas.jpg"
                width="1275" /><cc1:modalpopupextender id="ModalPopupExtender2" runat="server" backgroundcssclass="modalBackground"
                    cancelcontrolid="btnCancel" drag="true" dropshadow="false" popupcontrolid="pnlPopup"
                    targetcontrolid="img02" x="0" y="0">
            </cc1:modalpopupextender><img id="img03" runat="server" alt="King-Kong" class="thumbnail"
                onclick="togglePopupImage(this);" src="../MainPages/MainDocumentos.JPG" /><cc1:modalpopupextender
                    id="ModalPopupExtender3" runat="server" backgroundcssclass="modalBackground"
                    cancelcontrolid="btnCancel" drag="true" dropshadow="false" popupcontrolid="pnlPopup"
                    targetcontrolid="img03" x="0" y="0">
            </cc1:modalpopupextender><img id="img04" runat="server" alt="The Hoya's mascot" class="thumbnail"
                height="1240" onclick="togglePopupImage(this);" src="../MainPages/MainEstadisticas.JPG"
                width="1274" /><cc1:modalpopupextender id="ModalPopupExtender4" runat="server" backgroundcssclass="modalBackground"
                    cancelcontrolid="btnCancel" drag="true" dropshadow="false" popupcontrolid="pnlPopup"
                    targetcontrolid="img04" x="0" y="0">
            </cc1:modalpopupextender><img id="img05" runat="server" alt="My future home" class="thumbnail"
                height="1626" onclick="togglePopupImage(this);" src="../MainPages/MainInicio.JPG"
                width="1258" /><cc1:modalpopupextender id="ModalPopupExtender5" runat="server" backgroundcssclass="modalBackground"
                    cancelcontrolid="btnCancel" drag="true" dropshadow="false" popupcontrolid="pnlPopup"
                    targetcontrolid="img05" x="0" y="0">
            </cc1:modalpopupextender><br />
        <asp:Panel ID="pnlPopup" runat="server">
            <table>
                <tr>
                    <td colspan="2">
                        <a href="#" onmouseout="clearzoom()" onmouseover="zoom(99,100,'imgPopup','in')">Zoom
                            In</a> | <a href="#" onmouseover="zoom(99,100,'imgPopup','restore')">Normal</a>
                        | <a href="#" onmouseout="clearzoom()" onmouseover="zoom(120,60,'imgPopup','out')">Zoom
                            Out</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img id="imgPopup" runat="server" class="imgpopup" /></td>
                    <td align="right">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="text-align: left">
                        <asp:Button ID="Button2" runat="server" OnClientClick="onPreviousImageClick(); return false;"
                            Text="Anterior" />
                        <asp:Button ID="Button3" runat="server" OnClientClick="onNextImageClick(); return false;"
                            Text="Siguiente" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cerrar" />
                    </td>
                    <td>
                        <span id="spnImageText"></span>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:ObjectDataSource ID="ODSImagen" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
            SelectMethod="ScalarImagenRad" TypeName="PruebaImgTableAdapters.ImagenesTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFImagen" Name="ImagenesId" PropertyName="Value"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="ImagenesId" Type="Int32" />
                <asp:Parameter Name="ImagenesDescripcion" Type="String" />
                <asp:Parameter Name="ImagenesNivel" Type="String" />
                <asp:Parameter Name="ImagenesIdPadre" Type="String" />
                <asp:Parameter Name="ImanegenesRuta" Type="String" />
                <asp:Parameter Name="Imagen" Type="Object" />
            </InsertParameters>
        </asp:ObjectDataSource>
        </div>
        <asp:HiddenField ID="HFImagen" runat="server" />
        <asp:ObjectDataSource ID="ODSRegImagen" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
            SelectMethod="ScalarImagenReg" TypeName="PruebaImgTableAdapters.RegSelectImagenTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFImagen" Name="ImagenesId" PropertyName="Value" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="ImagenesId" Type="Int32" />
                <asp:Parameter Name="ImagenesDescripcion" Type="String" />
                <asp:Parameter Name="ImagenesNivel" Type="String" />
                <asp:Parameter Name="ImagenesIdPadre" Type="String" />
                <asp:Parameter Name="ImanegenesRuta" Type="String" />
                <asp:Parameter Name="Imagen" Type="Object" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
