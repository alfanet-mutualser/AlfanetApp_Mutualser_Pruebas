<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeFile="WorkFlow.aspx.cs" Inherits="_WorkFlow" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl"
    TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Configuration" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>--%>
  <%--  <%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="" %>--%>
    <%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="global">
<script runat="server">
        
    protected void ODSDocRecExtVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtProcedencia.Text;
        if (TxtProcedencia.Text != "")
        {
            
            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList1.SelectedValue == "0")
            {
                //e.ParameterValues.Clear();
                ODSDocRecExtVen.FilterExpression = "ProcedenciaNUI='{0}'";
                ODSDocRecExtProxVen.FilterExpression = "ProcedenciaNUI='{0}'";
                ODSDocRecExtPen.FilterExpression = "ProcedenciaNUI='{0}'";
                ODSDocRecCopia.FilterExpression = "ProcedenciaNUI='{0}'";
                e.ParameterValues.Add("ProcedenciaNUI", CodProcedencia);
            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                //e.ParameterValues.Clear();
                ODSDocRecExtVen.FilterExpression = "NumeroDocumento='{0}'";
                ODSDocRecExtProxVen.FilterExpression = "NumeroDocumento='{0}'";
                ODSDocRecExtPen.FilterExpression = "NumeroDocumento='{0}'";
                ODSDocRecCopia.FilterExpression = "NumeroDocumento='{0}'";
                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                //e.ParameterValues.Clear();
                ODSDocRecExtVen.FilterExpression = "NaturalezaCodigo='{0}'";
                ODSDocRecExtProxVen.FilterExpression = "NaturalezaCodigo='{0}'";
                ODSDocRecExtPen.FilterExpression = "NaturalezaCodigo='{0}'";
                ODSDocRecCopia.FilterExpression = "NaturalezaCodigo='{0}'";
                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            ODSDocRecExtVen.FilterExpression = null;
            //e.ParameterValues.
            //e.ParameterValues.Clear();
            //e.ParameterValues.RemoveAt(0);
            //e.ParameterValues.Remove("ProcedenciaNUI");
            
            //e.ParameterValues.Add("NumeroDocumento", CodProcedencia);            
        }
    }
</script>
<script src="_scripts/jquery-1.5.js" type="text/javascript"></script>
<script type="text/javascript">
          
           $(document).ready(function() {
                $(".ContenidoPanel").show();
                $(".ContenidoPanel2").hide();
                $(".ArrowSube").attr("class", "ArrowSube");
                $(".ArrowSube2").attr("class", "ArrowSube2");
                $(".ExpandTexto").html("(Ocultar Detalles..)");
                $(".ExpandTexto2").html("(Ocultar Documentos..)");
                
                $("DIV.PanelDes > DIV.PanelMovible").toggle(
                function() {
                    $(this).parent().find(".ContenidoPanel").slideToggle(200);
                    $(this).parent().find(".ArrowSube").attr("class", "ArrowBaja");
                    $(this).parent().find(".ExpandTexto").html("(Mostar Detalles..)");
                },
                function() {
                    $(this).parent().find(".ContenidoPanel").slideToggle(200);
                    $(this).parent().find(".ArrowBaja").attr("class", "ArrowSube");
                    $(this).parent().find(".ExpandTexto").html("(Ocultar Detalles..)");
                    
                });
                
                $("DIV.PanelDes2 > DIV.PanelMovible2").toggle(
                function() {
                    $(this).parent().find(".ContenidoPanel2").slideToggle(200);
                    $(this).parent().find(".ArrowSube2").attr("class", "ArrowBaja2");
                    $(this).parent().find(".ExpandTexto2").html("(Mostrar Documentos..)");
                },
                function() {
                    $(this).parent().find(".ContenidoPanel2").slideToggle(200);
                    $(this).parent().find(".ArrowBaja2").attr("class", "ArrowSube2");
                    $(this).parent().find(".ExpandTexto2").html("(Ocultar Documentos..)");
                    
                });

            });            
        
        
        
        //Funcion para controlar el evento de cargar a:
       function Disable_Attr(e,ToggleControl,HFControl)
        {
             var s_len=ToggleControl.value.length ;
             var s_charcode = 0;
             var contador = 0;
             for (var s_i=0;s_i<s_len;s_i++)
             {
                s_charcode = ToggleControl.value.charCodeAt(s_i);
                if(s_charcode == 124)
                {
                   contador = 1;
                }
              }
              
              if(contador == 0)
              {
                 HFControl.value = "Dependencia";
              }
           
        } 
     
   
        function Resaltar_On(GridView)
        {
            if(GridView != null)
            {
                GridView.originalBgColor = GridView.style.backgroundColor;
                GridView.style.backgroundColor="#DBE7F6";
            }
        }
        function Resaltar_Off(GridView)
        {
            if(GridView != null)
            {
                GridView.style.backgroundColor = GridView.originalBgColor;
            }
        }

        function ColorRow(CheckBoxObj)
        {  
            
           if (CheckBoxObj.checked == true) 
           {
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF'; 
           }                  
         
           else
           {
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
        function ColorRowVen(CheckBoxObj,ToggleControl,ToggleControlAccion)
        {   
           if (CheckBoxObj.checked == true) 
           {
                ToggleControl.disabled = false;
                ToggleControl.className = '';
                ToggleControl.focus();
                             
                ToggleControlAccion.disabled = false;
                ToggleControlAccion.className = '';
                //ToggleControlAccion.focus();    
                                             
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF';
                                
           } 
           else
           {
                ToggleControl.disabled = true;
                ToggleControl.className = 'disabled';
                ToggleControl.innerText = "";                
                               
                ToggleControlAccion.disabled = true;
                ToggleControlAccion.className = 'disabled';
                ToggleControlAccion.innerText = "";
                
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
       
         
      
        function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
          ToggleControl.value = src.innerText || src.innerHTML;
          HFControl.value = "Serie";  
//         return false;          
        }      
       
        
        function OnTreeClick2(evt,ToggleControl,HFControl) 
        {    
          var src ;
          if( window.event != window.undefined)
          {
            src = window.event.srcElement;
          }
          else
          {
            src = evt.target;
          }
        
          //var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";
          var Rad = src.innerText || src.innerHTML;                      
           if (nodeClick)        
           ToggleControl.value = Rad;           
           HFControl.value = "Dependencia";
           //return false; 
        }
           function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
          ToggleControl.value = src.innerText || src.innerHTML;
          HFControl.value = "Serie";  
//         return false;          
        }      
          
           function OnTreeClickMultitarea(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            //ToggleControl.value = "Dependencia";
            HFControl.value = "Dependencia";
            return false; 
        }
           function OnTreeClickFinalizar(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            ToggleControl.value = "Finalizar";
            HFControl.value = "Finalizar";
        }
           function url(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt,Grupo)
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad  + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S&RptaImg=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt)
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S&RptaImg=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Enviada
           function VImagenesReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Historico Recibida
           function Historico(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Expediente
           function Expediente(evt,NumeroDocumento,Expediente,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
         //Historico ENVIDAD
           function HistoricoReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        
          function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
            }
        function popup_Shown(s, e) {
        callbackPanel.AdjustControl();
            }
</script>    
<asp:UpdatePanel ID="UdPnRecExtVen" runat="server">
  <ContentTemplate>
<dxpc:ASPxPopupControl id="popup" runat="server" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" HeaderText="Vinculo a Respuesta" PopupHorizontalAlign="OutsideRight" AllowDragging="True" ClientInstanceName="popup">
<ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
<ContentCollection>
<dxpc:PopupControlContentControl runat="server"><dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
<LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

<LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
<PanelCollection>
<dxp:PanelContent runat="server">
<asp:Panel runat="server" ID="PnlContent">
    </asp:Panel>
 </dxp:PanelContent>
</PanelCollection>
</dxcp:ASPxCallbackPanel>
 </dxpc:PopupControlContentControl>
</ContentCollection>
</dxpc:ASPxPopupControl>

</ContentTemplate>
</asp:UpdatePanel>

<table width="100%">
        <tr>
            <td align="left">   
            <div id="Div3" class="PanelDes">
              <div id="Div4" class="PanelMovible"> 
            <div id="Div5" class="HeaderNumero">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False">#</asp:Label>&nbsp;</div>
            <div id="Div6" class="HeaderTitulo">
                DOCUMENTOS RECIBIDOS EXTERNOS</div>
            <div id="Div7" class="ExpandTexto"></div>
            <div id="Div8" class="ArrowSube"></div>
        </div>
        <div id="Div9" class="ContenidoPanel" style="display:none">
        
            <div>
                        <table>
                            <tr>
                                <td style="text-align: float">
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                        <asp:UpdatePanel id="UpdatePanel2" runat="server" Visible="false">
                                            <contenttemplate>
<table style="WIDTH: 270px; HEIGHT: 1px; TEXT-ALIGN: center"><TBODY><TR><TD>&nbsp;</TD><TD style="FONT-SIZE: 10pt"><ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TxtProcedencia" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetProcedenciaByTextNombre" ServicePath="../../AutoComplete.asmx">
                                                    </ajaxToolkit:AutoCompleteExtender> <asp:TextBox id="TxtProcedencia" tabIndex=10 runat="server" Width="424px" Font-Size="Small" CssClass="TxtAutoComplete" Height="28px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImgBtnFindProcedencia" onclick="ImgBtnFindProcedencia_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" Height="15px" ValidationGroup="false"></asp:ImageButton> </TD><TD style="WIDTH: 7px">&nbsp;</TD></TR><TR><TD colSpan=4><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="375px" ForeColor="RoyalBlue" Height="19px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False"><asp:ListItem Selected="True" Value="0">Procedencia NUI</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></table>
</contenttemplate>
            
                                        </asp:UpdatePanel>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </div>
                        <div id="Div24" class="PanelDes2">
        <div id="Div25" class="PanelMovible2" style="border-color:red; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div26" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/alarmaroja.gif" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp;
            </div>
            <div id="Div27" class="HeaderTitulo2">DOCUMENTOS VENCIDOS</div>
            <div id="Div28" class="ArrowSube2"></div>
            <div id="Div29" class="ExpandTexto2"></div>
        </div>
        <div id="Div30" class="ContenidoPanel2" style="display:none">
                        
                  <asp:UpdatePanel ID="UPv1" runat="server" UpdateMode="Conditional"><ContentTemplate>
                            
                            <table>
                            <tr>
                                <td>
                                    <asp:Button ID="BtnTerminarDocRecVen" runat="server" OnClick="BtnTerminarDocrecVen_Click" Text="Terminar" />
                                </td>
                                    <td style="width: 555px">
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Red" OnInit="Label5_Init" EnableViewState="False">Hay Documentos Vencidos de sus dependencias</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel21" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#4F93E3" HorizontalAlign="Left">
                                                    <table>
                                                        <tr>
                                                            <td style="background-color: #94b6e8">
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="White" Text="Dependencias con Documentos Vencidos"
                                                                                ></asp:Label>
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                <asp:ImageButton ID="ImageButton18" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView3" runat="server" BorderColor="White" AutoGenerateColumns="False" CellPadding="4"
                                                                    DataKeyNames="DependenciaCodigo" DataSourceID="ObjectDataSourceReadAllDependencias"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="GridView3_RowDataBound" AllowPaging="True" HorizontalAlign="Left" EmptyDataText="Sus Dependencias no tienen Documentos Vencidos." Width="360px">
                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                    <Columns>
                                                                        <asp:TemplateField></asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Codigo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("DependenciaCodigo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Dependencia">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("DependenciaNombre") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Lista de Vencidos">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton6" runat="server">Ver Documentos...</asp:LinkButton><br />
                                                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline">
                                                                                    <ContentTemplate>
                                                                                    <table style="border-left-color: #4f93e3; border-bottom-color: #4f93e3; border-top-style: solid; border-top-color: #4f93e3; border-right-style: solid; border-left-style: solid; border-right-color: #4f93e3; border-bottom-style: solid" border="2">
                                                                                        <tr>
                                                                                            <td style="background-color: #94b6e8; text-align: left">
                                                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="White" Text="Lista de Documentos"
                                                                                                    ></asp:Label></td>
                                                                                            <td style="background-color: #94b6e8; text-align: right">
                                                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <asp:GridView ID="GridView4" runat="server"  AutoGenerateColumns="False" CellPadding="4"
                                                                                        DataSourceID="ObjectDataReadDocumentos" ForeColor="Black" GridLines="None" AllowPaging="True" OnRowDataBound="GridView4_RowDataBound" Width="230px" BorderColor="White" BorderStyle="Solid" PageSize="12">
                                                                                        <RowStyle BackColor="#EFF3FB" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Radicado">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("RadicadoCodigo") %>' Font-Underline="True" ForeColor="Blue"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="D&#237;as">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("DiasVencimiento") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:HyperLink ID="HprLnkImgExtVen1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Imágenes</asp:HyperLink>
                                                                                                    <br />
                                                                                                    <asp:HyperLink ID="HprLnkHisExtven1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink>&nbsp;<br />
                                                                                                    <asp:HyperLink ID="HprLnkExp" runat="server" CssClass="LinKBtnStyleBig" Target="_blank"
                                                                                                        Text="Expediente"></asp:HyperLink>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                        <EditRowStyle BackColor="#2461BF" />
                                                                                        <AlternatingRowStyle BackColor="White" />
                                                                                    </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <br />
                                                                                &nbsp;
                                                                                &nbsp;&nbsp;
                                                <asp:ObjectDataSource ID="ObjectDataReadDocumentos" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetData" TypeName="DSWorkFlowTableAdapters.WFMovimientosReadDocumentosTableAdapter">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="50" Name="DependenciaCodigo" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
                                                                                    CancelControlID="ImageButton19"
                                                                                    PopupControlID="UpdatePanel10"
                                                                                    TargetControlID="LinkButton6" Enabled="True"> 
                                                                                </ajaxToolkit:ModalPopupExtender>
                                                                                <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" Style="visibility: hidden" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;</asp:Panel>
                                                <asp:ObjectDataSource ID="ObjectDataSourceReadAllDependencias" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="HFmDepCod" Name="Dependencia" PropertyName="Value"
                                                            Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                                    CancelControlID="ImageButton18"
                                                    PopupControlID="Panel21"
                                                    TargetControlID="Label5" Enabled="True"> 
                                                </ajaxToolkit:ModalPopupExtender>
                                                &nbsp; &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                                <tr>
                                    <td colspan="3">
                                        
                                                            <dxwgv:ASPxGridView ID="ASPxGVDocRecExtVen" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocRecExtVen"
                                                                Width="100%" OnHtmlRowPrepared="ASPxGVDocRecExtVen_HtmlRowPrepared" EnableCallBacks="False">
                                                                <Styles CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>
                                                                <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>
                                                                <SettingsPager ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</SettingsPager>
                                                                <ImagesFilterControl>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</ImagesFilterControl>
                                                                <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>
                                                                <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                                                                <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server" __designer:dtid="281474976710814" __designer:wfdid="w2"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Radicado&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' __designer:dtid="281474976710821" Font-Underline="True" __designer:wfdid="w39"></asp:HyperLink>
<asp:HiddenField ID="Label60" runat="server" Value='<%# Bind("Respuesta") %>' Visible="false" />
<a id="LnkRpta" runat="server" href="javascript:void(0);">
<asp:Image id="Image1" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" __designer:dtid="281474976710826" __designer:wfdid="w41">
</asp:Image>
</a>

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Width="25px" Caption="Procedencia" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="23px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label30" runat="server" Width="87px" Font-Size="Smaller"    Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor" __designer:wfdid="w1"></asp:Image><asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl" __designer:wfdid="w2"><asp:TextBox id="TxtDocNotasExtVen" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine" __designer:wfdid="w3"></asp:TextBox> </asp:Panel> <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender3" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w4">
    </ajaxToolkit:HoverMenuExtender> <ajaxToolkit:PopupControlExtender id="PCEDocNotasExtVen" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w5">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7"><DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" Width="13px" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RadicadoDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender7" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="139px" Caption="Cargar a:" VisibleIndex="10"><DataItemTemplate>
<asp:HiddenField id="HFCargar" runat="server" __designer:wfdid="w21"></asp:HiddenField> <asp:TextBox id="TxtCargarDocVen" runat="server" Width="152px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w22"></asp:TextBox> <asp:Panel style="LEFT: 213px; TOP: 132px" id="PnlCargarDocVen" runat="server" Height="300px" CssClass="popupControl" HorizontalAlign="Left" __designer:wfdid="w23" ScrollBars="Both"><DIV><asp:TreeView id="TreeVDependencia" runat="server" Width="350px" __designer:wfdid="w24" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate">
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text=" Seleccione Dependencia..." Value="0"></asp:TreeNode>
                </Nodes>

<NodeStyle Width="230px" ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"></NodeStyle>
        <RootNodeStyle ForeColor="Black" />
        <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
        <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
        <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
        <SelectedNodeStyle ForeColor="Black" />
            </asp:TreeView> <asp:TreeView id="TreeVSerie" runat="server" __designer:wfdid="w25" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate">
<Nodes>
<asp:TreeNode PopulateOnDemand="True" SelectAction="None" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                </Nodes>
                <ParentNodeStyle Font-Bold="True" />
                <LeafNodeStyle ForeColor="Black" />
                <NodeStyle Font-Size="8pt" />
            </asp:TreeView> <asp:TreeView id="TreeVMultitarea" runat="server" __designer:wfdid="w26" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" PopulateNodesFromClient="true" ShowCheckBoxes="All" ShowLines="True">
    <ParentNodeStyle Font-Bold="True" />
    <HoverNodeStyle Font-Underline="True" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
    <Nodes>
        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                </Nodes>
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                <LeafNodeStyle ForeColor="Black" />
            </asp:TreeView> </DIV></asp:Panel> <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" Enabled="True" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w27"></ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" __designer:wfdid="w28" Position="Right" OffsetY="30"></ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="139px" Caption="Acci&#243;n:" VisibleIndex="11"><DataItemTemplate>
<asp:TextBox id="TxtAccionDocExtVen" runat="server" Width="139px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w19"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccionDocExtVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w20">
                                            </ajaxToolkit:AutoCompleteExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="11px" Caption="Opciones" VisibleIndex="12">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFProceso" Value='<%# Bind("WFProcesoCodigo") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                                                                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                                                <StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
                                                            </dxwgv:ASPxGridView>


                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                                    
                                    </td>
                                </tr>
                                                   
                        </table>
                         <asp:ObjectDataSource ID="ODSDocRecExtVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocVen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" OnFiltering="ODSDocRecExtVen_Filtering">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                            </SelectParameters>
                            
                        </asp:ObjectDataSource>
                        </ContentTemplate></asp:UpdatePanel>
        
         </div>
        </div>
                        <div id="Div17" class="PanelDes2">
        <div id="Div18" class="PanelMovible2" style="border-color:yellow; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div19" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/alarmaamarilla.gif" />&nbsp;
                USTED TIENE&nbsp;
               <asp:Label ID="LblDocRecExtProxVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp;
            </div>
            <div id="Div20" class="HeaderTitulo2">DOCUMENTOS PROXIMOS A VENCER</div>
            <div id="Div22" class="ArrowSube2"></div>
            <div id="Div21" class="ExpandTexto2"></div>
        </div>
        <div id="Div23" class="ContenidoPanel2" style="display:none">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button4" runat="server" OnClick="BtnTerminarDocRecProx_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;"> 
                                    </td>
                                </tr>
                            </table>
                            <br />
                            
                            <dxwgv:ASPxGridView ID="ASPxGVDocRecExtProxVen" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocRecExtProxVen"
                                                                Width="100%" OnHtmlRowPrepared="ASPxGVDocRecExtVen_HtmlRowPrepared" EnableCallBacks="False">
                                <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                                <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                                <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                                <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                                <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                                <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                                <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server" __designer:dtid="281474976710814" __designer:wfdid="w2"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Radicado&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' __designer:dtid="281474976710821" Font-Underline="True" __designer:wfdid="w39"></asp:HyperLink>
<asp:HiddenField ID="Label60" runat="server" Value='<%# Bind("Respuesta") %>' Visible="false" />
<a id="LnkRpta" runat="server" href="javascript:void(0);">
<asp:Image id="Image1" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" __designer:dtid="281474976710826" __designer:wfdid="w41">
</asp:Image>
</a>

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Width="25px" Caption="Procedencia" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="23px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label30" runat="server" Font-Size="Smaller" Width="88px"   Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor" __designer:wfdid="w1"></asp:Image><asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl" __designer:wfdid="w2"><asp:TextBox id="TxtDocNotasExtVen" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine" __designer:wfdid="w3"></asp:TextBox> </asp:Panel> <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender3" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w4">
    </ajaxToolkit:HoverMenuExtender> <ajaxToolkit:PopupControlExtender id="PCEDocNotasExtVen" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w5">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7"><DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" Width="13px" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RadicadoDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" Width="50px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender7" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="145px" Caption="Cargar a:" VisibleIndex="10"><DataItemTemplate>
<asp:HiddenField id="HFCargar" runat="server" __designer:wfdid="w21"></asp:HiddenField> <asp:TextBox id="TxtCargarDocVen" runat="server" Width="152px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w22"></asp:TextBox> <asp:Panel style="LEFT: 213px; TOP: 132px" id="PnlCargarDocVen" runat="server" Height="300px" CssClass="popupControl" HorizontalAlign="Left" __designer:wfdid="w23" ScrollBars="Both"><DIV><asp:TreeView id="TreeVDependencia" runat="server" Width="350px" __designer:wfdid="w24" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate">
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text=" Seleccione Dependencia..." Value="0"></asp:TreeNode>
                </Nodes>

<NodeStyle Width="230px" ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"></NodeStyle>
        <RootNodeStyle ForeColor="Black" />
        <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
        <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
        <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
        <SelectedNodeStyle ForeColor="Black" />
            </asp:TreeView> <asp:TreeView id="TreeVSerie" runat="server" __designer:wfdid="w25" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate">
<Nodes>
<asp:TreeNode PopulateOnDemand="True" SelectAction="None" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                </Nodes>
                <ParentNodeStyle Font-Bold="True" />
                <LeafNodeStyle ForeColor="Black" />
                <NodeStyle Font-Size="8pt" />
            </asp:TreeView> <asp:TreeView id="TreeVMultitarea" runat="server" __designer:wfdid="w26" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" PopulateNodesFromClient="true" ShowCheckBoxes="All" ShowLines="True">
    <ParentNodeStyle Font-Bold="True" />
    <HoverNodeStyle Font-Underline="True" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
    <Nodes>
        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                </Nodes>
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                <LeafNodeStyle ForeColor="Black" />
            </asp:TreeView> </DIV></asp:Panel> <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" Enabled="True" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w27"></ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" __designer:wfdid="w28" Position="Right" OffsetY="30"></ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="139px" Caption="Acci&#243;n:" VisibleIndex="11"><DataItemTemplate>
<asp:TextBox id="TxtAccionDocExtVen" runat="server" Width="139px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w19"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccionDocExtVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w20">
                                            </ajaxToolkit:AutoCompleteExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="11px" Caption="Opciones" VisibleIndex="12">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFProceso" Value='<%# Bind("WFProcesoCodigo") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                            </dxwgv:ASPxGridView>
                            
                       
                        <asp:ObjectDataSource ID="ODSDocRecExtProxVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocProxVen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" FilterExpression="ProcedenciaNUI='{0}'" OnFiltering="ODSDocRecExtVen_Filtering">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                    <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                    <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                    <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                    <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                                </SelectParameters>
                            <FilterParameters>
                                <asp:ControlParameter ControlID="TxtProcedencia" Name="ProcedenciaNUI" PropertyName="Text" />
                            </FilterParameters>
                            </asp:ObjectDataSource>
                            </ContentTemplate></asp:UpdatePanel>
         </div>
        </div>
                        <div id="Div10" class="PanelDes2">
        <div id="Div11" class="PanelMovible2" style="border-color:Green; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div12" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocRecExtPen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
            </div>
            <div id="Div13" class="HeaderTitulo2">DOCUMENTOS PENDIENTES</div>
            <div id="Div15" class="ArrowSube2"></div>
            <div id="Div14" class="ExpandTexto2"></div>
        </div>
        <div id="Div16" class="ContenidoPanel2" style="display:none">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                        <asp:Panel ID="Panel8" runat="server" CssClass="collapsePanel" Width="100%" Height="100%">
                            <p/><table style="width: 560px">
                                <tr>
                                    <td style="text-align: center; width: 26px;">
                                        <asp:Button ID="Button5" runat="server" OnClick="BtnTerminarDocRecPen_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;"></td>
                                </tr>
                            </table>
                            
                            <dxwgv:ASPxGridView ID="ASPxGVDocRecExtPen" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocRecExtPen"
                                                                Width="100%" OnHtmlRowPrepared="ASPxGVDocRecExtVen_HtmlRowPrepared" EnableCallBacks="False">
                                <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                                <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                                <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                                <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                                <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                                <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                                <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server" __designer:dtid="281474976710814" __designer:wfdid="w2"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Radicado&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' __designer:dtid="281474976710821" Font-Underline="True" __designer:wfdid="w39"></asp:HyperLink>
<asp:HiddenField ID="Label60" runat="server" Value='<%# Bind("Respuesta") %>' Visible="false" />
<a id="LnkRpta" runat="server" href="javascript:void(0);">
<asp:Image id="Image1" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" __designer:dtid="281474976710826" __designer:wfdid="w41">
</asp:Image>
</a>

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Width="25px" Caption="Procedencia" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="23px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label30" runat="server" Font-Size="Smaller" Width="88px"   Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor" __designer:wfdid="w1"></asp:Image><asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl" __designer:wfdid="w2"><asp:TextBox id="TxtDocNotasExtVen" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine" __designer:wfdid="w3"></asp:TextBox> </asp:Panel> <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender3" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w4">
    </ajaxToolkit:HoverMenuExtender> <ajaxToolkit:PopupControlExtender id="PCEDocNotasExtVen" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w5">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7"><DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" Width="13px" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RadicadoDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" Width="50px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender7" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="145px" Caption="Cargar a:" VisibleIndex="10"><DataItemTemplate>
<asp:HiddenField id="HFCargar" runat="server" __designer:wfdid="w21"></asp:HiddenField> <asp:TextBox id="TxtCargarDocVen" runat="server" Width="152px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w22"></asp:TextBox> <asp:Panel style="LEFT: 213px; TOP: 132px" id="PnlCargarDocVen" runat="server" Height="300px" CssClass="popupControl" HorizontalAlign="Left" __designer:wfdid="w23" ScrollBars="Both"><DIV><asp:TreeView id="TreeVDependencia" runat="server" Width="350px" __designer:wfdid="w24" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate">
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text=" Seleccione Dependencia..." Value="0"></asp:TreeNode>
                </Nodes>

<NodeStyle Width="230px" ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"></NodeStyle>
        <RootNodeStyle ForeColor="Black" />
        <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
        <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
        <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
        <SelectedNodeStyle ForeColor="Black" />
            </asp:TreeView> <asp:TreeView id="TreeVSerie" runat="server" __designer:wfdid="w25" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate">
<Nodes>
<asp:TreeNode PopulateOnDemand="True" SelectAction="None" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                </Nodes>
                <ParentNodeStyle Font-Bold="True" />
                <LeafNodeStyle ForeColor="Black" />
                <NodeStyle Font-Size="8pt" />
            </asp:TreeView> <asp:TreeView id="TreeVMultitarea" runat="server" __designer:wfdid="w26" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" PopulateNodesFromClient="true" ShowCheckBoxes="All" ShowLines="True">
    <ParentNodeStyle Font-Bold="True" />
    <HoverNodeStyle Font-Underline="True" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
    <Nodes>
        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                </Nodes>
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                <LeafNodeStyle ForeColor="Black" />
            </asp:TreeView> </DIV></asp:Panel> <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" Enabled="True" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w27"></ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" __designer:wfdid="w28" Position="Right" OffsetY="30"></ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="139px" Caption="Acci&#243;n:" VisibleIndex="11"><DataItemTemplate>
<asp:TextBox id="TxtAccionDocExtVen" runat="server" Width="139px" Font-Size="9pt" Height="15px" Enabled="False" CssClass="TextBoxStyleGrid" __designer:wfdid="w19"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccionDocExtVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" __designer:wfdid="w20">
                                            </ajaxToolkit:AutoCompleteExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="11px" Caption="Opciones" VisibleIndex="12">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFProceso" Value='<%# Bind("WFProcesoCodigo") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                            </dxwgv:ASPxGridView>
                            
                            
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ODSDocRecExtPen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocPen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" FilterExpression="ProcedenciaNUI='{0}'" OnFiltering="ODSDocRecExtVen_Filtering">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                    <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                    <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                    <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                    <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                                </SelectParameters>
                            <FilterParameters>
                                <asp:ControlParameter ControlID="TxtProcedencia" Name="ProcedenciaNUI" PropertyName="Text" />
                            </FilterParameters>
                            </asp:ObjectDataSource>
                       </ContentTemplate></asp:UpdatePanel>
                            </div>
        </div>       
                        <div id="Div31" class="PanelDes2">
        <div id="Div32" class="PanelMovible2" style="border-color:#6960EC; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div33" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocRecCopia" runat="server" Font-Bold="False"
                        Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                        text-align: center" Width="25px">#</asp:Label>&nbsp;
            </div>
            <div id="Div34" class="HeaderTitulo2">DOCUMENTOS COPIA</div>
            <div id="Div35" class="ArrowSube2"></div>
            <div id="Div36" class="ExpandTexto2"></div>
        </div>
        <div id="Div37" class="ContenidoPanel2" style="display:none">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional"><ContentTemplate>
     
                       
                                <table style="width: 560px">
                                    <tr>
                                        <td style="width: 26px; text-align: center;">
                                            <asp:Button ID="BtnTerminaCopia" runat="server" OnClick="BtnTerminarCop_Click" Text="Terminar" /></td>
                                        <td style="width: 409px;">
                                           </td>
                        
                                    </tr>
                                </table>
                               
                                <dxwgv:ASPxGridView ID="ASPxGVDocRecExtCopia" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocRecCopia"
                                                                Width="100%" OnHtmlRowPrepared="ASPxGVDocRecExtCopia_HtmlRowPrepared" EnableCallBacks="False">
                                    <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                                    <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                                    <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                                    <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                                    <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                                    <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                                    <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server" __designer:dtid="281474976710814" __designer:wfdid="w2"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Radicado&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' __designer:dtid="281474976710821" Font-Underline="True" __designer:wfdid="w39"></asp:HyperLink>
<asp:HiddenField ID="Label60" runat="server" Value='<%# Bind("Respuesta") %>' Visible="false" />
<a id="LnkRpta" runat="server" href="javascript:void(0);">
<asp:Image id="Image1" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" __designer:dtid="281474976710826" __designer:wfdid="w41">
</asp:Image>
</a>

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Width="200px" Caption="Procedencia" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="200px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label30" runat="server" Font-Size="Smaller" Width="88px"   Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor" __designer:wfdid="w1"></asp:Image><asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl" __designer:wfdid="w2"><asp:TextBox id="TxtDocNotasExtVen" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine" __designer:wfdid="w3"></asp:TextBox> </asp:Panel> <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender3" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w4">
    </ajaxToolkit:HoverMenuExtender> <ajaxToolkit:PopupControlExtender id="PCEDocNotasExtVen" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven" __designer:wfdid="w5">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7"><DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" Width="13px" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RadicadoDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" Width="50px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender7" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="16px" Caption="Opciones" VisibleIndex="10">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFProceso" Value='<%# Bind("WFProcesoCodigo") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                    <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                                </dxwgv:ASPxGridView>
                                
                            
                        
                      </ContentTemplate></asp:UpdatePanel>
        </div>
        </div>
                        <asp:ObjectDataSource ID="ODSDocRecCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopia"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" FilterExpression="ProcedenciaNUI='{0}'" OnFiltering="ODSDocRecExtVen_Filtering">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="2" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="2" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                            </SelectParameters>
                            <FilterParameters>
                                <asp:ControlParameter ControlID="TxtProcedencia" Name="ProcedenciaNUI" PropertyName="Text" />
                            </FilterParameters>
                        </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODSDocRec" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
          <SelectParameters>
              <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
              <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
              <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
          </SelectParameters>
      </asp:ObjectDataSource>
            
                <br />
                </div>
                </div>
                <br />
               <div id="Div45" class="PanelDes">
        <div id="Div46" class="PanelMovible"> 
            <div id="Div47" class="HeaderNumero">
                       <asp:Label ID="LblDocEnvExt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                    &nbsp;</div>
            <div id="Div48" class="HeaderTitulo">
                DOCUMENTOS ENVIADOS EXTERNOS</div>
            <div id="Div49" class="ExpandTexto"></div>
            <div id="Div50" class="ArrowSube"></div>
            </div>
        <div id="Div51" class="ContenidoPanel" style="display:none">
           
                   <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td>
                                <asp:UpdatePanel id="UpdatePanel4" runat="server" Visible="False">
                    
                    <contenttemplate>
<DIV id="Div1"><TABLE><TBODY><TR><TD>&nbsp;</TD><TD style="FONT-SIZE: 10pt"><ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender4" runat="server" TargetControlID="TxtDependenciaExt" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></ajaxToolkit:AutoCompleteExtender> <asp:TextBox id="TxtDependenciaExt" tabIndex=10 runat="server" Width="424px" Font-Size="Small" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImgBtnFindDependenciaExt" onclick="ImgBtnFindDependenciaExt_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" Height="15px" ValidationGroup="false"></asp:ImageButton> </TD><TD style="WIDTH: 7px">&nbsp;</TD></TR><TR><TD colSpan=4><asp:RadioButtonList id="RadioButtonList3" runat="server" Width="425px" ForeColor="RoyalBlue" Height="19px" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0">Dependencia Remite</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE></DIV>
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindDependenciaExt"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                    
        <div id="Div38" class="PanelDes2">
        <div id="Div39" class="PanelMovible2" style="border-color:#6960EC; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div40" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocEnvExtCopia" runat="server" Font-Bold="False" Font-Size="Larger"
                                Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                Width="25px">#</asp:Label>&nbsp;
            </div>
            <div id="Div41" class="HeaderTitulo2">DOCUMENTOS COPIA EXTERNOS</div>
            <div id="Div42" class="ArrowSube2"></div>
            <div id="Div43" class="ExpandTexto2"></div>
        </div>
        <div id="Div44" class="ContenidoPanel2" style="display:none">
         
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 360px">
                            <tr>
                                <td>
                                    <asp:Button ID="BtnTerminarCopEnvExt" runat="server" OnClick="BtnTerminarCopEnvExt_Click" Text="Terminar" /></td>
                                <td></td>
                            </tr>
                        </table>
                        
                        <dxwgv:ASPxGridView ID="ASPxGVDocEnvExtCopia" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocEnvExtCopia"
                                                                OnHtmlRowPrepared="ASPxRowBoundCopiaEnv_HtmlRowPrepared"
                                                                Width="100%"  EnableCallBacks="False">
                            <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                            <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                            <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                            <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                            <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                            <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
<columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Registro&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' Font-Underline="True"></asp:HyperLink>


</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="200px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label32" runat="server" Font-Size="Smaller" Width="88px"   Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="200px" Caption="Remitente" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label33" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PopupControlExtender3" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender8" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor"></asp:Image>
<asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl">
<asp:TextBox id="TextBox10" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine"></asp:TextBox>
 </asp:Panel> 
 <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender9" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven">
    </ajaxToolkit:HoverMenuExtender> 
    <ajaxToolkit:PopupControlExtender id="PopupControlExtender4" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender5" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>

<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
               <asp:Image ID="Image8" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="Panel29" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox12" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender11" runat="server" PopupControlID="Panel29"
        TargetControlID="Image8">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender6" runat="server" PopupControlID="Panel29"
                                                Position="Left" TargetControlID="Image8" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox13" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender12" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender7" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="16px" Caption="Opciones" VisibleIndex="10">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                            <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                            <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                        </dxwgv:ASPxGridView>

                    <asp:ObjectDataSource ID="ODSDocEnvExtCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter" OnFiltering="ODSDocEnvExtCopia_Filtering">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
       
       
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter" FilterExpression="NaturalezaCodigo='{0}'" OnFiltering="ODSDocEnvExtCopia_Filtering">
            <FilterParameters>
                <asp:ControlParameter ControlID="TxtDependenciaExt" Name="CodProcedencia" />
            </FilterParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo" Type="Int32" />
                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
          
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="white" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                        DataSourceID="ObjectDataSource2">
                        <Columns>
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" ReadOnly="True"
                                SortExpression="NumeroDocumento" Visible="False" />
                        </Columns>
                    </asp:GridView>
                
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </ContentTemplate></asp:UpdatePanel>
               </div>
            </div>  
               </div>
               </div>
                <br />
                 <div id="Div52" class="PanelDes">
        <div id="Div53" class="PanelMovible"> 
            <div id="Div54" class="HeaderNumero">
                       <asp:Label ID="LblDocEnvInt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                    &nbsp;</div>
            <div id="Div55" class="HeaderTitulo">
                DOCUMENTOS ENVIADOS INTERNOS</div>
            <div id="Div56" class="ExpandTexto"></div>
            <div id="Div57" class="ArrowSube"></div>
            </div>
        <div id="Div58" class="ContenidoPanel" style="display:none"> 
                
               
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 100px">
                                <asp:UpdatePanel id="UpdatePanel3" runat="server" Visible="False">
                    <contenttemplate>
   <div id="Div2">                 
<TABLE style="WIDTH: 270px; HEIGHT: 1px; TEXT-ALIGN: float"><TBODY><TR><TD>&nbsp;</TD><TD style="FONT-SIZE: 10pt"><ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TxtDependencia" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></ajaxToolkit:AutoCompleteExtender> <asp:TextBox id="TxtDependencia" tabIndex=10 runat="server" Width="424px" Font-Size="Small" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImgBtnFindDependencia" onclick="ImgBtnFindDependencia_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" Height="15px" ValidationGroup="false"></asp:ImageButton> </TD><TD style="WIDTH: 7px">&nbsp;</TD></TR><TR><TD colSpan=4><asp:RadioButtonList id="RadioButtonList2" runat="server" Width="425px" ForeColor="RoyalBlue" Height="19px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">Dependencia Remite</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE>
</div>
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindDependencia"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                    <br />
                      <div id="Div59" class="PanelDes2">
        <div id="Div60" class="PanelMovible2" style="border-color:Green; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div61" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocEnvIntVen" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; 
            </div>
            <div id="Div62" class="HeaderTitulo2">DOCUMENTOS RECIBIDOS</div>
            <div id="Div63" class="ArrowSube2"></div>
            <div id="Div64" class="ExpandTexto2"></div>
        </div>
        <div id="Div65" class="ContenidoPanel2" style="display:none">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 360px">
                            <tr>
                                <td style="width: 25px; text-align: center">
                                    <asp:Button ID="BtnTerminarDocEnvIntVen" runat="server" OnClick="BtnTerminarIntEnvVen_Click" Text="Terminar" /></td>
                                <td style="width: 212px">
                                        </td>
                            </tr>
                        </table>
                     
                        <dxwgv:ASPxGridView ID="ASPxGVDocEnvIntVen" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocEnvIntVen"
                                                                Width="100%" 
                                                                OnHtmlRowPrepared="ASPxRowBoundEnvIntVen_HtmlRowPrepared"
                                                                EnableCallBacks="False">
                            <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                            <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                            <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                            <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                            <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                            <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                            <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server" __designer:dtid="281474976710814" __designer:wfdid="w2"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Registro&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>

<asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" 
                                            Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" Visible="False"></asp:LinkButton>
<asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                            Text='<%# Eval("NumeroDocumento") %>'>
                                                 </asp:HyperLink>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="23px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="25px" Caption="Remite" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label3" runat="server" Font-Size="Smaller"   Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PopupControlExtender8" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender13" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>

<HeaderStyle Font-Size="8pt"></HeaderStyle>
</DataItemTemplate>
<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender14" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender9" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6">
<DataItemTemplate>
      <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender10" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7">
<DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender15" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender11" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Panel ID="Panel27" runat="server" BorderStyle="None" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>                        
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="162px" Caption="Cargar a:" VisibleIndex="10">
<DataItemTemplate>
<asp:HiddenField ID="HFCargar" runat="server" />
                  <asp:TextBox ID="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="161px" Enabled="False"></asp:TextBox>
                            <asp:Panel id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" HorizontalAlign="Left">
                                            <div>
                                               <asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" Width="230px" />
                                                </asp:TreeView>
                                                <asp:TreeView id="TreeVFinalizar" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text="Seleccione Archivar..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                        NodeSpacing="0px" VerticalPadding="0px" />
                                                      </asp:TreeView>
                                                <asp:TreeView id="TreeVMultitarea" runat="server" PopulateNodesFromClient="true" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowCheckBoxes="All" ExpandDepth="0" ShowLines="True">
                                                 <ParentNodeStyle Font-Bold="True" />
                                                  <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                <LeafNodeStyle ForeColor="Black" />
                                                </asp:TreeView>                                   
                                                &nbsp;
                                                &nbsp;&nbsp;</div>
                                        </asp:Panel>
                                        <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" OffsetY="30" Position="Right">
                                        </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="149" Caption="Acci&#243;n:" VisibleIndex="11">
<DataItemTemplate>
    <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="145px" Enabled="False"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender5" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="11px" Caption="Opciones" VisibleIndex="12">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFDepCodOr" Value='<%# Bind("DependenciaCodOrigen") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                            <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                            <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                        </dxwgv:ASPxGridView>
                        
                 
                    <asp:ObjectDataSource ID="ODSDocEnvIntVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocEnviado"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter" OnFiltering="ODSDocEnvIntVen_Filtering">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                            <asp:Parameter DefaultValue="1" Name="WFControlDias" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </ContentTemplate></asp:UpdatePanel>
                </div>
        </div>
          <div id="Div66" class="PanelDes2">
        <div id="Div67" class="PanelMovible2" style="border-color:#6960EC; border-style:solid; border-width:3px; background-color:#FFF9FB;"> 
            <div id="Div68" class="HeaderNumero2">
                <img alt='' src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;
                USTED TIENE&nbsp;
                <asp:Label ID="LblDocCopiaInt" runat="server" Font-Bold="False" Font-Size="Larger"
                        Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                        Width="25px">#</asp:Label>&nbsp;
            </div>
            <div id="Div69" class="HeaderTitulo2">DOCUMENTOS COPIA</div>
            <div id="Div70" class="ArrowSube2"></div>
            <div id="Div71" class="ExpandTexto2"></div>
        </div>
        <div id="Div72" class="ContenidoPanel2" style="display:none">
                  <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                  
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="BtnTerminarDocEnvIntCop" runat="server" OnClick="BtnTerminarEnvIntCop_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                    
                                            </td>
                                </tr>
                            </table>
                          
                            <dxwgv:ASPxGridView ID="ASPxGVDocEnvIntCopia" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocEnvIntCopia"
                                                                OnHtmlRowPrepared="ASPxRowBoundCopiaEnv_HtmlRowPrepared"
                                                                Width="100%"  EnableCallBacks="False">
                                <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                                <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                                <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                                <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                                <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                                <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                                <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Registro&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" ForeColor="Blue" Text='<%# Eval("NumeroDocumento") %>' Font-Underline="True"></asp:HyperLink>


</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="200px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label32" runat="server" Font-Size="Smaller" Width="88px"   Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="200px" Caption="Remitente" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label29" runat="server" Font-Size="Smaller"   Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label33" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="50px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" Width="15px" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PopupControlExtender3" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender8" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image id="ImgDocNotasExtVen" runat="server" Width="15px" Visible="false" ImageUrl="../../AlfaNetImagen/ToolBar/VerPostIt.png"  Height="25px" CssClass="PointerCursor"></asp:Image>
<asp:Panel style="LEFT: 34px" id="PnlNotasDocExtven" runat="server" CssClass="popupControl">
<asp:TextBox id="TextBox10" runat="server" Width="400px" BackColor="Transparent" Text='<%# Bind("WFMovimientoNotas") %>' Height="100px" BorderStyle="None" TextMode="MultiLine"></asp:TextBox>
 </asp:Panel> 
 <ajaxToolkit:HoverMenuExtender id="HoverMenuExtender9" runat="server" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven">
    </ajaxToolkit:HoverMenuExtender> 
    <ajaxToolkit:PopupControlExtender id="PopupControlExtender4" runat="server" Enabled="False" TargetControlID="ImgDocNotasExtVen" PopupControlID="PnlNotasDocExtven">
                                            </ajaxToolkit:PopupControlExtender> 
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6"><DataItemTemplate>
     <asp:Image ID="Image5" runat="server" Width="12px" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender5" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="14px" Caption="Detalle" VisibleIndex="7">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
               <asp:Image ID="Image8" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="Panel29" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox12" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender11" runat="server" PopupControlID="Panel29"
        TargetControlID="Image8">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender6" runat="server" PopupControlID="Panel29"
                                                Position="Left" TargetControlID="Image8" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           <asp:Image ID="Image7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png" CssClass="PointerCursor" Height="15px" Width="14px"  />
                                            <asp:Panel ID="Panel28" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox13" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="10px" Text='<%# Bind("NaturalezaNombre") %>' TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender12" runat="server" PopupControlID="Panel28"
        TargetControlID="Image7">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender7" runat="server" PopupControlID="Panel28"
                                                Position="Left" TargetControlID="Image7" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>                             
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="16px" Caption="Opciones" VisibleIndex="9">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                            </dxwgv:ASPxGridView>
                           
                            &nbsp; &nbsp; &nbsp;
                            &nbsp;
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                       
                    <asp:ObjectDataSource ID="ODSDocEnvIntCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter" OnFiltering="ODSDocEnvIntVen_Filtering">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="6" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                   </div>
                   </div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                        DataSourceID="ObjectDataSource1" Width="290px">
                        <Columns>
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" ReadOnly="True"
                                SortExpression="NumeroDocumento" Visible="False" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter" OnFiltering="ODSDocEnvIntVen_Filtering" FilterExpression="NaturalezaCodigo='{0}'">
                        <FilterParameters>
                            <asp:ControlParameter ControlID="TxtDependencia" Name="CodProcedencia" />
                        </FilterParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="6" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
            
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" OnFiltering="ODSDocEnvIntVen_Filtering">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
               </ContentTemplate>
               </asp:UpdatePanel>
               </div>
        
        </div>
        </div>

                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white" id="PnlMensaje" runat="server"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="12pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align=center colSpan=2><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</contenttemplate>
                </asp:UpdatePanel>
           <table border="0">
               <tr>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmFecha" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmDepCod" runat="server" />
                   </td>
                   <td style="width: 100px;">
                <asp:HiddenField ID="HFmTipo" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmGrupo" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px">
                       <asp:HiddenField ID="HFMultiTarea" runat="server" />
                       <asp:SqlDataSource ID="SqlDSMultitarea" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                           SelectCommand="SELECT [DistriTareas] FROM [Dependencia] WHERE ([DependenciaCodigo] = @DependenciaCodigo)">
                           <SelectParameters>
                               <asp:ControlParameter ControlID="HFmDepCod" Name="DependenciaCodigo" PropertyName="Value"
                                   Type="String" />
                           </SelectParameters>
                       </asp:SqlDataSource>
                   </td>
               </tr>
           </table>
                <%--<asp:UpdatePanel ID="UP1" runat="server">
                    <ContentTemplate>
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><img alt='' src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>--%>
                </td>
        </tr>
    </table>
</div>
</asp:Content>



    