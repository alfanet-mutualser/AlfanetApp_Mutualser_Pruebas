<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavDocEnviado.ascx.cs" Inherits="AlfaNetDocumentos_NavDocEnviado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<table>
    <tr>
        <td style="vertical-align: middle; width: 66px; text-align: center">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx"
                Width="73px">Registro</asp:HyperLink></td>
        <td style="vertical-align: middle; width: 70px; text-align: center">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/AlfaNetDocumentos/DocRecibido/Sticker.aspx"
                Width="73px">Sticker</asp:HyperLink></td>
        <td style="vertical-align: middle; width: 100px; text-align: center">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx"
                Width="115px">Visor de Imagenes</asp:HyperLink></td>
    </tr>
</table>--%>

    <script type="text/javascript">            

         //Variable global para el estado del checkbox
        
        var EstadoCk = 0;

       //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,GrupoCodigo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + GrupoCodigo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=1000,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
            
        }
         //Visor de Imagenes Recibida
           function RegresarRadicado(evt,NumeroDocumento) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx?RadicadoCodigo=' + NumeroDocumento);
            
        }   
       //Visor de Imagenes Recibida
           function ImpresionSticker(evt,NumeroDocumento,GrupoCodigo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&Admon=S&CodBar=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=2&Admon=S&GrupoPadreCodigo=2&CodBar='+EstadoCk, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
        }           
           
       
        function url(CheckBoxObj,GrupoCodigo) 
        {
            //var email= prompt('Please enter your email address', ' ');
            //alert(document.getElementById("<%=HFRegistroCodigo.ClientID%>").getAttribute("value"));
            //var ID = this.document.getElementById("<%=HFGrupoCodigo.ClientID%>").Value;
            //ID.Value = email;
            var CodBar;
             if (CheckBoxObj.checked == true) 
           {
           CodBar = '1';    
           } 
           else
           {
           CodBar = '0';
           }
            //var Grupo = document.getElementById("<%=HFGrupoCodigo.ClientID%>").getAttribute("value");
            //var NroDoc = document.getElementById("<%=HFRegistroCodigo.ClientID%>").getAttribute("value");
             EstadoCk = CodBar;         
            //hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S&RadicadoCodigo='+NroDoc+'&GrupoCodigo='+GrupoCodigo+'&GrupoPadreCodigo=1&CodBar='+CodBar, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
             //hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S&RadicadoCodigo='+NroDoc+'&GrupoCodigo='+GrupoCodigo+'&GrupoPadreCodigo=2&CodBar='+CodBar, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
           //window.open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S" + "&RadicadoCodigo="+Request["RadicadoCodigo"]+ "&GrupoCodigo="+Request["GrupoCodigo"]+ "', 'NewWindow','top=0,left=0, width=800,height=600,titlebar=yes,menubar=yes, resizable=yes,scrollbars=yes');
        }      
             
</script>
<table style="width: 100%">
    <tr>
        <td>
            <asp:Image ID="Image3" runat="server" Height="42px" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/sticker.png"
                ToolTip="Impresion de Sticker" Width="36px" /><br />
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="False" Text="|||||||" ToolTip="Sticker Codigo de Barras"
                Width="36px" /></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Sticker"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" Height="42px" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/imagenes.png"
                ToolTip="Visor de Imagenes" Width="36px" /></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Imagenes"></asp:Label></td>
    </tr>
     <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" CssClass="popupControl" Height="590px" Width="440px">
            
<iframe runat="server" id="Default3" style="width: 440px; height: 590px" enableviewstate="true" visible="false"></iframe> 
    <br />
            </asp:Panel>
            <asp:Image ID="Image2" runat="server" Visible="False" Height="42px" ImageUrl="~/AlfaNetImagen/ToolBar/images.jpg"
                Width="36px" ToolTip="Visor de Imagenes" />
            <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" OffsetX="-486" OffsetY="-550" PopupControlID="Panel1" Position="Right" TargetControlID="Image2">
            </cc1:PopupControlExtender>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LbScanner" runat="server" Visible="false" Text="Escanear"></asp:Label></td>
    </tr>
</table>
<asp:HiddenField ID="HFRegistroCodigo" runat="server" />
<asp:HiddenField ID="HFGrupoCodigo" runat="server" />
<asp:HiddenField ID="HFGrupoPadreCodigo"  runat="server" />
