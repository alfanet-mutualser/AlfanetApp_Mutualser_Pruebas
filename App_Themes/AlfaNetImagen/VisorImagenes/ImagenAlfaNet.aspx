<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImagenAlfaNet.aspx.cs" Inherits="Imagen" %>

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
        &nbsp;<asp:ObjectDataSource ID="ODSImagen" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
            SelectMethod="ScalarImagenRad" TypeName="PruebaImgTableAdapters.ImagenesTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFImagen" Name="ImagenesId" PropertyName="Value"
                    Type="Int32" DefaultValue="" />
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
        <br />
        <asp:Label ID="LblTipo" runat="server" Text="Label"></asp:Label><br />
        <br />
        <br />
        &nbsp;<br />
        </div>
        &nbsp;
    </form>
</body>
</html>
