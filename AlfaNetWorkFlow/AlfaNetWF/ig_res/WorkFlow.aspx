<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeFile="WorkFlow.aspx.cs" Inherits="_WorkFlow_old" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Configuration" %>


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
    <script type="text/javascript">
   
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

    <table width="100%">
        <tr>
            <td align="center">            
       <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left; font-size:small" Width="100%"> 
              <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               <div style="float: left; width: 350px; font-weight: bold;">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False">#</asp:Label>
                  DOCUMENTOS RECIBIDOS EXTERNOS</div>
                  <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="Label1" runat="server" Height="20px" Width="180px" style="vertical-align: middle; text-align: left" Font-Size="Smaller">(Ver Detalles...)</asp:Label>
                  </div>
                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
        </asp:Panel>
         
                    <asp:Panel ID="Panel1" runat="server" Height="0" Width="100%" style="vertical-align: top; text-align: left; font-size:small" CssClass="collapsePanel">
            <div>
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="text-align: float">
                                    <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td style="width: 20%">
                                            </td>
                                            <td>
                                        <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                            <contenttemplate>
<table style="WIDTH: 270px; HEIGHT: 1px; TEXT-ALIGN: center"><TBODY><TR><TD>&nbsp;</TD><TD style="FONT-SIZE: 10pt"><ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TxtProcedencia" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetProcedenciaByTextNombre" ServicePath="../../AutoComplete.asmx">
                                                    </ajaxToolkit:AutoCompleteExtender> <asp:TextBox id="TxtProcedencia" tabIndex=10 runat="server" Width="424px" Font-Size="Small" CssClass="TxtAutoComplete" Height="28px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImgBtnFindProcedencia" onclick="ImgBtnFindProcedencia_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" Height="15px" ValidationGroup="false"></asp:ImageButton> </TD><TD style="WIDTH: 7px">&nbsp;</TD></TR><TR><TD colSpan=4><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="375px" ForeColor="RoyalBlue" Height="19px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">Procedencia NUI</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></table>
</contenttemplate>
                                            <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindProcedencia"></asp:PostBackTrigger>
</triggers>
                                        </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 20%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </div>
                        <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Red" BorderStyle="Solid" BorderWidth="3px">
                           
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaroja.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label14" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label19" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS VENCIDOS</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                            </div>
                         
                        </asp:Panel>        
                        
                        <asp:Panel ID="Panel4" runat="server" CssClass="collapsePanel" Height="0" Width="100%">
                            
                            <table>
                            <tr>
                                <td>
                                    <asp:Button ID="BtnTerminarDocRecVen" runat="server" OnClick="BtnTerminarDocrecVen_Click" Text="Terminar" /></td>
                                <td>
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LnkBtnSelTodosGVDocRecExtVen_Click">Todos</asp:LinkButton>
                                    ,
                                    <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LnkBtnSelNingunoGVDocRecExtVen_Click">Ninguno</asp:LinkButton></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Red" OnInit="Label5_Init" EnableViewState="False">Hay Documentos Vencidos de sus dependencias</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel21" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#0000C0" HorizontalAlign="Left">
                                                    <table>
                                                        <tr>
                                                            <td style="background-color: #0066ff">
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="White" Text="Dependencias con Documentos Vencidos"
                                                                                ></asp:Label>
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                <asp:ImageButton ID="ImageButton18" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                                                                    <table style="border-left-color: #0066ff; border-bottom-color: #0066ff; border-top-style: solid; border-top-color: #0066ff; border-right-style: solid; border-left-style: solid; border-right-color: #0066ff; border-bottom-style: solid" border="2">
                                                                                        <tr>
                                                                                            <td style="background-color: #0066ff; text-align: left">
                                                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="White" Text="Lista de Documentos"
                                                                                                    ></asp:Label></td>
                                                                                            <td style="background-color: #0066ff; text-align: right">
                                                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                        DataSourceID="ObjectDataReadDocumentos" ForeColor="Black" GridLines="None" AllowPaging="True" OnRowDataBound="GridView4_RowDataBound" Width="230px" BorderColor="RoyalBlue" BorderStyle="Solid" PageSize="12">
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
                     
                            <asp:GridView id="GVDocRecExtVen" runat="server" DataSourceID="ODSDocRecExtVen" ForeColor="#333333" OnRowDataBound="GVDocRecExtVen_RowDataBound" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,WFProcesoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
<FooterStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BorderColor="#4F93E3"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="V.B.">
<EditItemTemplate>                                        
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento">
<EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        
</EditItemTemplate>
<FooterTemplate>
                                        
</FooterTemplate>
<ItemTemplate>
    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
        Text='<%# Eval("NumeroDocumento") %>' Visible="False"></asp:LinkButton>
    <asp:HyperLink ID="HyperLink1" runat="server"
    Text='<%# Eval("NumeroDocumento") %>' Font-Underline="True" ForeColor="Blue"></asp:HyperLink>
     <asp:Label id="Label60" runat="server" Visible="False" Text='<%# Bind("Respuesta") %>'></asp:Label> 
<asp:Panel style="LEFT: 499px" id="PnlRpta" runat="server" HorizontalAlign="Left" CssClass="popupControl">
<asp:Label id="Label80" runat="server" Width="76px" Text="Registro Nro.:"></asp:Label><BR  />
</asp:Panel> <asp:Image id="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif">
</asp:Image><ajaxToolkit:PopupControlExtender id="PCERpta" runat="server" TargetControlID="Image1" PopupControlID="PnlRpta">
            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("GrupoNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel150" runat="server" CssClass="popupControl" Style="left: 34px">
            <asp:Label ID="Label4" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("GrupoNombre") %>'></asp:Label></asp:Panel>
            <asp:Image ID="Image60" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/box_48.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender10" runat="server"
                    PopupControlID="Label4" TargetControlID="Image60">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Label ID="Label3" runat="server"  Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="40px"></ItemStyle>
    <ControlStyle Font-Size="Smaller" />
    <FooterStyle Width="40px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Label ID="Label2" runat="server"  Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
    <ControlStyle Font-Size="Smaller" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    <asp:TemplateField HeaderText="Rpta">
        <EditItemTemplate>
            &nbsp;
        </EditItemTemplate>
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
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
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel15" runat="server" CssClass="popupControl" Style="left: 34px">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
    <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo"
        SortExpression="NaturalezaCodigo" Visible="False" />
<asp:TemplateField HeaderText="Cargar a:"><ItemTemplate>
    <asp:HiddenField ID="HFCargar" runat="server" />
    <asp:TextBox id="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox> 
    <asp:Panel id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" style="left: 213px; top: 132px;" HorizontalAlign="Left">
    <DIV>
    <asp:TreeView id="TreeVDependencia"  runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" Width="350px" >
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "Expand" Text=" Seleccione Dependencia..." Value="0"></asp:TreeNode>
                </Nodes>

<NodeStyle Width="230px" ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"></NodeStyle>
        <RootNodeStyle ForeColor="Black" />
        <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
        <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
        <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
        <SelectedNodeStyle ForeColor="Black" />
            </asp:TreeView> 
            <asp:TreeView id="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" >
<Nodes>
<asp:TreeNode PopulateOnDemand="True" SelectAction="None" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                </Nodes>
                <ParentNodeStyle Font-Bold="True" />
                <LeafNodeStyle ForeColor="Black" />
                <NodeStyle Font-Size="8pt" />
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
        </DIV></asp:Panel> <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" Position="Right" OffsetY="30"></ajaxToolkit:PopupControlExtender>                                   
</ItemTemplate>
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Acci&#243;n:"><ItemTemplate>
                                            <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Width="180px" Enabled="False"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        
</ItemTemplate>
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo"><ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />
                                        
</ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#A9C6EF" ForeColor="White"></PagerStyle>
<EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                
</EmptyDataTemplate>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
</asp:GridView>
                                    </td>
                                </tr>
                                                   
                        </table>
                           </asp:Panel>         
                                        
                                        
                        <asp:ObjectDataSource ID="ODSDocRecExtVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocVenv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocVenv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo1" Type="Int32" />
                                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                            </SelectParameters>
                            
                        </asp:ObjectDataSource>
                            <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender2" runat="server"
        TargetControlID="Panel4"
        ExpandControlID="Panel3"
        CollapseControlID="Panel3" 
        Collapsed="True"
        TextLabelID="Label2"
        ImageControlID="Image2"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:Panel ID="Panel5" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaamarilla.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label20" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtProxVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label21" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS PROXIMOS A VENCER</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label3" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image3" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </asp:Panel><asp:Panel ID="Panel6" runat="server" CssClass="collapsePanel" Height="0px" Width="100%">
                            <p><table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button4" runat="server" OnClick="BtnTerminarDocRecProx_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LnkBtnSelTodosDocRecExtProxVen_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LnkBtnSelNingunoDocRecExtProxVen_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                            <asp:GridView id="GVDocRecExtProxVen" runat="server" Width="99%" DataSourceID="ODSDocRecExtProxVen" ForeColor="#333333" OnRowDataBound="GVDocRecExtProxVen_RowDataBound" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,WFProcesoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" UseAccessibleHeader="False" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                                <FooterStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="V.B.">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                                Text='<%# Eval("NumeroDocumento") %>' Visible="False"></asp:LinkButton>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True"
                                                Text='<%# Eval("NumeroDocumento") %>' CssClass="LinKBtnStyleBig"></asp:HyperLink><asp:Label ID="Label60" runat="server" Text='<%# Bind("Respuesta") %>'
                                                Visible="False"></asp:Label>
                                            <asp:Panel ID="PnlRpta" runat="server" CssClass="popupControl" HorizontalAlign="Left"
                                                Style="left: 499px">
                                                <asp:Label ID="Label80" runat="server" Text="Registro Nro.:" Width="76px"></asp:Label><br />
                                            </asp:Panel>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" />
                                            <ajaxToolkit:PopupControlExtender ID="PCERpta" runat="server" PopupControlID="PnlRpta"
                                                TargetControlID="Image1">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("GrupoNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text='<%# Bind("GrupoNombre") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  />
                                            <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender5" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven">
                                            </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                            &nbsp;
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender6" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen">
                                            </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post It">
                                        <ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rpta">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
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
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel21" runat="server" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
    <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo"
        SortExpression="NaturalezaCodigo" Visible="False" />
                                    <asp:TemplateField HeaderText="Cargar a:">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HFCargar" runat="server" />
                                            <asp:TextBox ID="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                            <asp:Panel id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" HorizontalAlign="Left">
                                                <DIV>
                                                    <asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate"
                                                        ShowLines="True" >
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" Width="230px" />
                                                        <LeafNodeStyle ForeColor="Black" />
                                                    </asp:TreeView>
                                                    <asp:TreeView id="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True" >
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="None" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                        <LeafNodeStyle ForeColor="Black" />
                                                    </asp:TreeView>
                                                    <asp:TreeView id="TreeVMultitarea" runat="server" PopulateNodesFromClient="true" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowCheckBoxes="All" ExpandDepth="0" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                                                        <LeafNodeStyle ForeColor="Black" />
                                                    </asp:TreeView>
                                                    </div>
                                            </asp:Panel>
                                            
                                            <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" Position="Right" OffsetY="30">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acci&#243;n:">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br  />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink><br/>
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                            <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos proximos a vencer !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#A9C6EF" Font-Bold="False" ForeColor="White" Font-Size="Smaller" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                            </asp:GridView>
                                &nbsp;
                            </p>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ODSDocRecExtProxVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocProxVenv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocProxVenv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender3" runat="server"
        TargetControlID="Panel6"
        ExpandControlID="Panel5"
        CollapseControlID="Panel5" 
        Collapsed="True"
        TextLabelID="Label3"
        ImageControlID="Image3"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:Panel ID="Panel7" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label22" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtPen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label24" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS PENDIENTES</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label4" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image4" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </asp:Panel>
                        <asp:Panel ID="Panel8" runat="server" CssClass="collapsePanel" Width="100%" Height="100%">
                            <p><table style="width: 560px">
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Button ID="Button5" runat="server" OnClick="BtnTerminarDocRecPen_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LnkBtnSelTodosDocRecExtPen_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LnkBtnSelNingunoDocRecExtPen_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                            <asp:GridView id="GVDocRecExtPen" runat="server" DataSourceID="ODSDocRecExtPen" ForeColor="#333333" OnRowDataBound="GVDocRecExtPen_RowDataBound" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,WFProcesoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="V.B.">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                                Text='<%# Eval("NumeroDocumento") %>' Visible="False"></asp:LinkButton>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                                Text='<%# Eval("NumeroDocumento") %>'>
        </asp:HyperLink><asp:Label ID="Label60" runat="server" Text='<%# Bind("Respuesta") %>'
                                                Visible="False"></asp:Label>
                                            <asp:Panel ID="PnlRpta" runat="server" CssClass="popupControl" HorizontalAlign="Left"
                                                Style="left: 499px">
                                                <asp:Label ID="Label80" runat="server" Text="Registro Nro.:" Width="76px"></asp:Label><br />
                                            </asp:Panel>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" />
                                            <ajaxToolkit:PopupControlExtender ID="PCERpta" runat="server" PopupControlID="PnlRpta"
                                                TargetControlID="Image1">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("GrupoNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text='<%# Bind("GrupoNombre") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    <asp:TemplateField HeaderText="Rpta">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
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
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" />
            <asp:Panel ID="Panel22" runat="server" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label></asp:Panel>
            <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
    <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo"
        SortExpression="NaturalezaCodigo" Visible="False" />
                                    <asp:TemplateField HeaderText="Cargar a:">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HFCargar" runat="server" />
                                            <asp:TextBox ID="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                            <asp:Panel id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" HorizontalAlign="Left">
                                                <DIV>
                                                    <asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" Width="230px" />
                                                    </asp:TreeView>
                                                    <asp:TreeView id="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True" >
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Archivar..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView>
                                                    <asp:TreeView id="TreeVMultitarea" runat="server" PopulateNodesFromClient="true" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowCheckBoxes="All" ExpandDepth="0" ShowLines="True" >
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView>
                                                    &nbsp;&nbsp;</div>
                                            </asp:Panel>
                                            <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" Position="Right" OffsetY="30">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acci&#243;n:">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br  />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                            <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos Pendientes !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                            </asp:GridView>
                            </p>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ODSDocRecExtPen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocPendv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocPendv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender4" runat="server"
        TargetControlID="Panel8"
        ExpandControlID="Panel7"
        CollapseControlID="Panel7" 
        Collapsed="True"
        TextLabelID="Label4"
        ImageControlID="Image4"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/><asp:Panel ID="Panel25" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                    &nbsp;<asp:Label ID="Label25" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>&nbsp;<asp:Label ID="LblDocRecCopia" runat="server" Font-Bold="False"
                        Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                        text-align: center" Width="25px">#</asp:Label>&nbsp; 
                    <asp:Label ID="Label26" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS COPIA</asp:Label></div>
                <div style="float: left; margin-left: 20px;">
                    <asp:Label ID="Label23" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                        Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                </div>
                <asp:ImageButton ID="ImageBtnCopia" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
            </div>
        </asp:Panel>
                        <asp:Panel ID="Panel26" runat="server" CssClass="collapsePanel" Height="0" Width="100%">
                            <p>
                                <table style="width: 560px">
                                    <tr>
                                        <td style="width: 26px; text-align: center;">
                                            <asp:Button ID="BtnTerminaCopia" runat="server" OnClick="BtnTerminarCop_Click" Text="Terminar" /></td>
                                        <td style="width: 409px;">
                                            &nbsp;Seleccionar:&nbsp;
                                            <asp:LinkButton ID="LnkBtnTdsCopia" runat="server" OnClick="LnkBtnSelTodosDocRecExtCopia_Click"
                                                Width="54px">Todos</asp:LinkButton>
                                            ,
                                            <asp:LinkButton ID="LnkBtnNgnCopia" runat="server" OnClick="LnkBtnSelNingunoDocRecExtCopia_Click"
                                                Width="61px">Ninguno</asp:LinkButton></td>
                                    </tr>
                                </table>
                                <asp:GridView id="GVDocRecExtCopia" runat="server" Width="100%" DataSourceID="ODSDocRecCopia" ForeColor="#333333" OnRowDataBound="GVDocRecExtCopia_RowDataBound" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,WFProcesoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="V.B.">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                                    Text='<%# Eval("NumeroDocumento") %>' Visible="False"></asp:LinkButton>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                                    Text='<%# Eval("NumeroDocumento") %>'>
        </asp:HyperLink><asp:Label ID="Label60" runat="server" Text='<%# Bind("Respuesta") %>'
                                                    Visible="False"></asp:Label>
                                                <asp:Panel ID="PnlRpta" runat="server" CssClass="popupControl" HorizontalAlign="Left"
                                                    Style="left: 499px">
                                                    <asp:Label ID="Label80" runat="server" Text="Registro Nro.:" Width="76px"></asp:Label><br />
                                                </asp:Panel>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif" />
                                                <ajaxToolkit:PopupControlExtender ID="PCERpta" runat="server" PopupControlID="PnlRpta"
                                                    TargetControlID="Image1">
                                                </ajaxToolkit:PopupControlExtender>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("GrupoNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text='<%# Bind("GrupoNombre") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
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
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel23" runat="server" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>' AssociatedControlID="Image6"></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
     <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo"
        SortExpression="NaturalezaCodigo" Visible="False" />
                                        <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br  />
                                                <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink>
                                                <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No tiene documentos recibidos externos copias !
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                                </asp:GridView>
                                &nbsp;
                            </p>
                        </asp:Panel>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDocRecCopia" runat="server"
        TargetControlID="Panel26"
        ExpandControlID="Panel25"
        CollapseControlID="Panel25" 
        Collapsed="True"
        TextLabelID="Label23"
        ImageControlID="ImageBtnCopia"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:ObjectDataSource ID="ODSDocRecCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocCopiav1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocCopiav1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
  
                        
      </asp:Panel>
      
      <asp:ObjectDataSource ID="ODSDocRec" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
          <SelectParameters>
              <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
              <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
              <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
          </SelectParameters>
      </asp:ObjectDataSource>
                <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender1" runat="Server"
        TargetControlID="Panel1"
        ExpandControlID="Panel2"
        CollapseControlID="Panel2"
        TextLabelID="Label1"
        ImageControlID="Image1"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="True"/>
                <br />
                <asp:Panel ID="Panel16" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left" Width="100%">
            
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvExt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS EXTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label13" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton4" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                
                </asp:Panel>
       
                <asp:Panel ID="Panel9" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="vertical-align: top; text-align: left">
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td>
                                <asp:UpdatePanel id="UpdatePanel4" runat="server">
                    
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
                <asp:Panel ID="Panel12" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left">
                            <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                        <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                            &nbsp;<asp:Label ID="Label27" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                            &nbsp;<asp:Label ID="LblDocEnvExtCopia" runat="server" Font-Bold="False" Font-Size="Larger"
                                Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                Width="25px">#</asp:Label>&nbsp; 
                            <asp:Label ID="Label28" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS COPIA EXTERNOS</asp:Label></div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label9" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
        </div>
            
                </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="text-align: float">
                        <table style="width: 360px">
                            <tr>
                                <td>
                                    <asp:Button ID="BtnTerminarCopEnvExt" runat="server" OnClick="BtnTerminarCopEnvExt_Click" Text="Terminar" /></td>
                                <td>
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LnkBtnSelTodosDocEnvExtCopia_Click">Todos</asp:LinkButton>
                                    ,
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LnkBtnSelNingunoDocEnvExtCopia_Click">Ninguno</asp:LinkButton></td>
                            </tr>
                        </table><asp:GridView id="GVDocEnvExtCopia" runat="server" Width="100%" DataSourceID="ODSDocEnvExtCopia" ForeColor="#333333" OnRowDataBound="GVDocEnvExtCopia_RowDataBound" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="V.B.">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registro No." SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle"                                             Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" Visible="False"></asp:LinkButton>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                            Text='<%# Eval("NumeroDocumento") %>'>
                                                 </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False" />
                                <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remitente" SortExpression="DependenciaNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel24" runat="server" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>' AssociatedControlID="Image6"></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" Target="_blank" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                        <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>'  runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos Enviados Externos Copias !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvExtCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocCopiaEnviadosv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocCopiaEnviadosv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
        TargetControlID="Panel11"
        ExpandControlID="Panel12"
        CollapseControlID="Panel12" 
        Collapsed="True"
        TextLabelID="Label7"
        ImageControlID="ImageButton1"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
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
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                        DataSourceID="ObjectDataSource2">
                        <Columns>
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" ReadOnly="True"
                                SortExpression="NumeroDocumento" Visible="False" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server"
        TargetControlID="Panel9"
        ExpandControlID="Panel16"
        CollapseControlID="Panel16"
        TextLabelID="Label13"
        ImageControlID="ImageButton4"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="True"/>
                <br />
                <asp:Panel ID="Panel17" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left" Width="100%">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvInt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS INTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label15" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel18" runat="server" CssClass="collapsePanel" Width="100%" style="vertical-align: top; text-align: left" Height="0px" HorizontalAlign="Center">
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 100px">
                                <asp:UpdatePanel id="UpdatePanel3" runat="server">
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
                    <asp:Panel ID="Panel19" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px">
                        <div style="padding:5px; cursor: pointer;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                            <div style="float: left; vertical-align: middle; color: activecaption; text-align: left; font: caption; width: 400px;">
                                &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocEnvIntVen" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; &nbsp;DOCUMENTOS RECIBIDOS</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label17" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Width="180px" Height="20px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton6" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                    </asp:Panel>
                    <asp:Panel ID="Panel20" runat="server" CssClass="collapsePanel" Width="100%" style="text-align: left" Height="100%">
                        <table style="width: 360px">
                            <tr>
                                <td style="width: 25px; text-align: center">
                                    <asp:Button ID="BtnTerminarDocEnvIntVen" runat="server" OnClick="BtnTerminarIntEnvVen_Click" Text="Terminar" /></td>
                                <td style="width: 212px">
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LnkBtnSelTodosDocEnvIntVen_Click" Width="20px">Todos</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp,
                                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LnkBtnSelNingunoDocEnvIntVen_Click"
                                        Width="34px">Ninguno</asp:LinkButton></td>
                            </tr>
                        </table>
                        <asp:GridView id="GVDocEnvIntVen" runat="server" Width="100%" DataSourceID="ODSDocEnvIntVen" ForeColor="#333333" OnRowDataBound="GVDocEnvIntVen_RowDataBound" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                            <FooterStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="V.B.">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registro No." SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" 
                                            Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" Visible="False"></asp:LinkButton>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                            Text='<%# Eval("NumeroDocumento") %>'>
                                                 </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False" />
                                <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remite" SortExpression="DependenciaNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("DependenciaNombre2") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("DependenciaNombre2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    <asp:TemplateField HeaderText="Rpta">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="Panel27" runat="server" BorderStyle="None" CssClass="popupControl">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label></asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cargar a:">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HFCargar" runat="server" />
                                        <asp:TextBox ID="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                        <asp:Panel id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" HorizontalAlign="Left">
                                            <DIV>
                                                <asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" Width="230px" />
                                                </asp:TreeView>
                                                <asp:TreeView id="TreeVFinalizar" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Archivar..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                                                </asp:TreeView>
                                                <asp:TreeView id="TreeVMultitarea" runat="server" Width="256px" PopulateNodesFromClient="true" ExpandDepth="0" ShowLines="True" NodeWrap="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowCheckBoxes="All">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione MultiTarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
                                                </asp:TreeView>                                                
                                                &nbsp;
                                                &nbsp;&nbsp;</div>
                                        </asp:Panel>
                                        <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" Position="Right">
                                        </ajaxToolkit:PopupControlExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acci&#243;n:">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="180px" Enabled="False"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink><br />
                                         <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo" SortExpression="NaturalezaCodigo"
                                    Visible="False" />
                                <asp:BoundField DataField="DependenciaCodOrigen" HeaderText="DependenciaCodOrigen"
                                    SortExpression="DependenciaCodOrigen" Visible="False" />
                            </Columns>
                            <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos Enviados Internos !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                        </asp:GridView>
                        &nbsp;
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvIntVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadosv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocEnviadosv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender5" runat="server"
        TargetControlID="Panel20"
        ExpandControlID="Panel19"
        CollapseControlID="Panel19" 
        Collapsed="True"
        TextLabelID="Label17"
        ImageControlID="ImageButton6"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                    <asp:Panel ID="Panel10" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocCopiaInt" runat="server" Font-Bold="False" Font-Size="Larger"
                        Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                        Width="25px">#</asp:Label>&nbsp; DOCUMENTOS COPIA</div>
                <div style="float: left; margin-left: 20px;">
                    <asp:Label ID="Label7" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                        Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                </div>
                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
            </div>
        </asp:Panel>
                    <asp:Panel ID="Panel13" runat="server" CssClass="collapsePanel" Height="0" Width="100%">
                        <p>
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="BtnTerminarDocEnvIntCop" runat="server" OnClick="BtnTerminarEnvIntCop_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LnkBtnSelTodosDocEnvIntCopia_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LnkBtnSelNingunoDocEnvIntCopia_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table><asp:GridView id="GVDocEnvIntCopia" runat="server" Width="100%" DataSourceID="ODSDocEnvIntCopia" ForeColor="#333333" OnRowDataBound="GVDocEnvExtCopia_RowDataBound" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" BorderColor="#4F93E3" BorderStyle="Solid" BorderWidth="1px">
                                <FooterStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="V.B.">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registro No." SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" 
                                                Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" Visible="False"></asp:LinkButton>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                                Text='<%# Eval("NumeroDocumento") %>'>
                                                 </asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" Visible="False" />
                                    <asp:TemplateField HeaderText="Ver Acci&#243;n" SortExpression="WFAccionNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remitente" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Proviene de:" SortExpression="DependenciaNombre"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px" HorizontalAlign="Left">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender4" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven">
    </ajaxToolkit:HoverMenuExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Post It" SortExpression="WFMovimientoNotas"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender3" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post It"><ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
    
<asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle"><EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                        
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen" Enabled="False">
                                            </ajaxToolkit:PopupControlExtender>
                                        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
                Text='<%# Bind("NaturalezaNombre") %>' AssociatedControlID="Image6"></asp:Label>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" /><ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Label1" TargetControlID="Image6">
                </ajaxToolkit:HoverMenuExtender>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Wrap="False" />
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imágenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br/>
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink><br/>
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                            <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>'  runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="50px"/>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NaturalezaCodigo" HeaderText="NaturalezaCodigo" SortExpression="NaturalezaCodigo"
                                        Visible="False" />
                                    <asp:BoundField DataField="DependenciaCodOrigen" HeaderText="DependenciaCodOrigen"
                                        SortExpression="DependenciaCodOrigen" Visible="False" />
                                </Columns>
                                <PagerStyle BackColor="#A9C6EF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos Enviados Internos Copia!
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#A9C6EF" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataRowStyle BackColor="White" BorderColor="White" BorderStyle="Solid" />
                            </asp:GridView>
                            &nbsp;
                            &nbsp;&nbsp;
                        </p>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvIntCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocCopiaEnviadosv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocCopiaEnviadosv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
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
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
        TargetControlID="Panel13"
        ExpandControlID="Panel10"
        CollapseControlID="Panel10" 
        Collapsed="True"
        TextLabelID="Label7"
        ImageControlID="ImageButton1"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
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
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter" OnFiltering="ODSDocEnvIntVen_Filtering">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender8" runat="server"
        TargetControlID="Panel18"
        ExpandControlID="Panel17"
        CollapseControlID="Panel17"
        TextLabelID="Label15"
        ImageControlID="ImageButton5"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="True"/>
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
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>--%>
                </td>
        </tr>
    </table>
</div>
  </asp:Content>



