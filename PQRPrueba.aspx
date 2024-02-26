<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="PQRPrueba.aspx.cs" Inherits="PQRPrueba" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl"
    TagPrefix="dxuc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script type="text/javascript">
    function urlInt(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + src.innerText + '&Admon=S&ImagenFolio=1&GrupoCodigo=2', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
</script>
<TABLE
><TBODY>
<TR>
<TD >
<cc1:autocompleteextender 
id="AutoCompleteMedioRecibo" 
runat="server" usecontextkey="True" 
targetcontrolid="TxtMedioRecibo" servicepath="AutoComplete.asmx" 
servicemethod="GetMedioByText" minimumprefixlength="0" 
completioninterval="100" CompletionListCssClass="autocomplete_completionListElement" 
CompletionListItemCssClass="autocomplete_listItem " 
CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
</cc1:autocompleteextender> 
<asp:TextBox id="TxtMedioRecibo"  runat="server" CssClass="TxtAutoComplete">
</asp:TextBox> 
</TD>
</TR>
</TBODY>
</TABLE>
<dxuc:ASPxUploadControl id="ASPxUploadControl1" 
 runat="server"></dxuc:ASPxUploadControl>
 </asp:Content>   
  
