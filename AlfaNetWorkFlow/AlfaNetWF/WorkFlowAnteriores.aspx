<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="WorkFlowAnteriores.aspx.cs" Inherits="_WorkFlowAnteriores" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="global">
<script runat="server">
   
</script>

    <script type="text/javascript">
   
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

           if (CheckBoxObj.checked == true) {           
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF';
           } 
           else
           {
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
    
        function OnTreeClick2(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
           ToggleControl.innerText = src.innerText;
           HFControl.innerText = "Dependencia";
        }
           function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
           ToggleControl.innerText = src.innerText;
           HFControl.innerText = "Serie";
           
        }
           function OnTreeClickMultitarea(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            ToggleControl.innerText = "Multitarea";
            HFControl.innerText = "Multitarea";
        }
           function url(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=1&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
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
         //Historico Enviada
           function HistoricoReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Expediente
           function Expediente(evt,NumeroDocumento,Expediente,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
</script>
    <table  style="width: 100%">
        <tr>
            <td align="center" style="width: 98%">
            
    
    <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="100%" style="vertical-align: top; text-align: left"> 
              <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               <div style="float: left; width: 451px; font-weight: bold;">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False" Font-Size="Larger">#</asp:Label>
                  DOCUMENTOS ANTERIORES &nbsp;RECIBIDOS EXTERNOS</div>
                  <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="Label1" runat="server" Height="20px" Width="180px" style="vertical-align: middle; text-align: left" Font-Size="Smaller">(Ver Detalles...)</asp:Label>
                  </div>
                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
          </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="vertical-align: top; text-align: left" HorizontalAlign="Center">
           <div>
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="text-align: float; width: 100%;">
                                    <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td style="width: 20%">
                                            </td>
                                            <td style="width: 100px">
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                            <contenttemplate>
<asp:TextBox id="TxtProcedencia" tabIndex=10 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" Height="28px" AutoCompleteType="Disabled" TextMode="MultiLine"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TxtProcedencia" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" MinimumPrefixLength="0" ServiceMethod="GetProcedenciaByTextNombre" ServicePath="../../AutoComplete.asmx">
                                                </ajaxToolkit:AutoCompleteExtender><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="375px" ForeColor="RoyalBlue" Height="19px" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0">Procedencia NUI</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList> 
</contenttemplate>
                                            <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindProcedencia"></asp:PostBackTrigger>
</triggers>
                                        </asp:UpdatePanel>
                                                
                                                   
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImgBtnFindProcedencia" runat="server" 
                                                        CausesValidation="False" Height="16px" 
                                                        ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" 
                                                        OnClick="ImgBtnFindProcedencia_Click" ToolTip="Buscar Procedencia" 
                                                        ValidationGroup="false" Width="15px" />
                                                </td>
                                            </tr>
                                           
                                        </table>
                                            </td>
                                            <td style="width: 20%">
                                            </td>
                                        </tr>
                                    </table>
                    
                                </td>
                            </tr>
                        </table>
                 </div>       
                        <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                                <div style="float: left; width: 480px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label5" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE </asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; &nbsp;
                                    <asp:Label ID="Label6" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS ANTERIORES RECIBIDOS</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                            </div>
                            
                        </asp:Panel>

                        
                        
                        <asp:Panel ID="Panel4" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="text-align: left">
                            <br />
                            <asp:GridView id="GVDocRecExtVen" runat="server" Width="100%" DataSourceID="ODSDocRecExtVen" ForeColor="#333333" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,WFMovimientoFecha,WFMovimientoFecha1,WFmovimientoFechaFin,RadicadoFechaVencimiento,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnRowDataBound="GVDocRecExtVen_RowDataBound">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento"><EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        
</EditItemTemplate>
<FooterTemplate>
                                        
</FooterTemplate>
<ItemTemplate>
    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
        Text='<%# Eval("NumeroDocumento") %>' OnClientClick="url(event);" Visible="False"></asp:LinkButton>
    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True"
        Text='<%# Eval("NumeroDocumento") %>'></asp:HyperLink>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="Smaller"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
    <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" />
    <asp:BoundField DataField="WFMovimientoFecha" HeaderText="Fecha Radicacion" SortExpression="WFMovimientoFecha" />
    <asp:BoundField DataField="WFMovimientoFecha1" HeaderText="Fecha de Inicio Tarea"
        SortExpression="WFMovimientoFecha1" />
    <asp:BoundField DataField="WFmovimientoFechaFin" HeaderText="Fecha Fin de Tarea"
        SortExpression="WFmovimientoFechaFin" />
    <asp:BoundField DataField="RadicadoFechaVencimiento" HeaderText="Fecha Vencimiento"
        SortExpression="RadicadoFechaVencimiento" />
<asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo"><ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imagenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br  />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Historico</asp:HyperLink><br    />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Eval("GrupoCodigo") %>' runat="server" />
                                        
</ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
</asp:TemplateField>
    <asp:BoundField DataField="ProcedenciaCodigo" HeaderText="ProcedenciaCodigo" SortExpression="ProcedenciaCodigo"
        Visible="False" />
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<EmptyDataTemplate>
                                    No tiene Documentos Recibidos Externos Anteriores !
                                
</EmptyDataTemplate>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
                            &nbsp;
                            </asp:Panel>

                        
                        <asp:ObjectDataSource ID="ODSDocRecExtVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocRecAnteriores"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoAnteriorRecibidoTableAdapter" OnFiltering="ODSDocRecExtVen_Filtering">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                            </SelectParameters>
                             
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" OnFiltering="ODSDocRecExtVen_Filtering" SelectMethod="GetDocRecAnteriores" TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoAnteriorRecibidoTableAdapter" FilterExpression="ProcedenciaCodigo='{0}'">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                            </SelectParameters>
                            <FilterParameters>
                                <asp:ControlParameter ControlID="TxtProcedencia" Name="ProcedenciaCodigo" PropertyName="Text" DefaultValue="1111111111111" />
                            </FilterParameters>
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Height="1px">
                            <HeaderStyle Height="1px" Width="1px" />
                            <Columns>
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" SortExpression="NumeroDocumento"
                                    Visible="False" />
                            </Columns>
                        </asp:GridView>
  
                        
      </asp:Panel><asp:ObjectDataSource ID="ODSDocRec" runat="server" OldValuesParameterFormatString="original_{0}"
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
                <asp:Panel ID="Panel16" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="100%" style="vertical-align: top; text-align: left">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 451px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvExt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ANTERIORES ENVIADOS EXTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label13" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel9" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="vertical-align: top; text-align: left">
         <div>       &nbsp;</div>     
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 100px">
                <table style="width: 270px; height: 35px; text-align: float;">
                  
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="width: 682px">
                            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                <contenttemplate>
<asp:TextBox id="TxtDependenciaExt" tabIndex=10 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" AutoCompleteType="Disabled"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender4" runat="server" TargetControlID="TxtDependenciaExt" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100"></ajaxToolkit:AutoCompleteExtender><asp:RadioButtonList id="RadioButtonList3" runat="server" Width="411px" ForeColor="RoyalBlue" Height="19px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">Dependencia Destino</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList> 
</contenttemplate>
                                <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindDependenciaExt"></asp:PostBackTrigger>
</triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImgBtnFindDependenciaExt" runat="server" 
                                                        CausesValidation="False" Height="16px" 
                                                        ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" 
                                                        OnClick="ImgBtnFindDependenciaExt_Click" ToolTip="Buscar Procedencia" 
                                                        ValidationGroup="false" Width="15px" />
                        </td>
                  </tr>
           
                </table>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel12" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left">
                            <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" height="14" width="14" />&nbsp;</div>
                        <div style="float: left; width: 480px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                            &nbsp;<asp:Label ID="Label7000" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                            &nbsp;<asp:Label ID="LblDocEnvExtCopia" runat="server" Font-Bold="False" Font-Size="Larger"
                                Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                Width="25px">#</asp:Label>&nbsp; 
                            <asp:Label ID="Label8" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS ANTERIORES ENVIADOS EXTERNOS</asp:Label>
                        </div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label9" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
                    </div>
                </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="text-align: left">
                        <br />
                        <asp:GridView id="GVDocEnvExtCopia" runat="server" Width="100%" DataSourceID="ODSDocEnvExtCopia" ForeColor="#333333" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,WFMovimientoFecha,WFMovimientoFecha1,WFmovimientoFechaFin,DependenciaCodOrigen,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnRowDataBound="GVDocEnvExtCopia_RowDataBound">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="Registro No." SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle"                                             Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" OnClientClick="urlInt(event);" Visible="False"></asp:LinkButton>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True"
                                            Text='<%# Eval("NumeroDocumento") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" />
                                <asp:BoundField DataField="WFMovimientoFecha" HeaderText="Fecha Registro" SortExpression="WFMovimientoFecha" />
                                <asp:BoundField DataField="WFMovimientoFecha1" HeaderText="Fecha Inicio Tarea" SortExpression="WFMovimientoFecha1" />
                                <asp:BoundField DataField="WFmovimientoFechaFin" HeaderText="Fecha Finalizacion de Tarea"
                                    SortExpression="WFmovimientoFechaFin" />
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imagenes" CssClass="LinKBtnStyleBig" Font-Underline="True"></asp:HyperLink><br  />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" CssClass="LinKBtnStyleBig" Font-Underline="True">Historico</asp:HyperLink><br    />
                                        <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                        <asp:HiddenField ID="HFGrupo" Value='<%# Eval("GrupoCodigo") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DependenciaCodOrigen" HeaderText="DependenciaCodOrigen"
                                    SortExpression="DependenciaCodOrigen" Visible="False" />
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos Enviados externos Anteriores !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvExtCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadoAnterioresExternos"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoEnviadoAnterioresTableAdapter" OnFiltering="ODSDocEnvExtCopia_Filtering">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
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
        SuppressPostBack="true"/><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadoAnterioresExternos"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoEnviadoAnterioresTableAdapter" OnFiltering="ODSDocEnvExtCopia_Filtering" FilterExpression="NaturalezaCodigo='{0}'">
            <FilterParameters>
                <asp:ControlParameter ControlID="TxtDependenciaExt" Name="CodProcedencia" />
            </FilterParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo" Type="Int32" />
                <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo2" Type="Int32" />
                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                        <Columns>
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" SortExpression="NumeroDocumento"
                                Visible="False" />
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
                <asp:Panel ID="Panel17" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="100%" style="vertical-align: top; text-align: left">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 452px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvInt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ANTERIORES ENVIADOS INTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label15" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel18" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="vertical-align: top; text-align: left">
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 100px">
                <table style="width: 270px; height: 35px; text-align: float;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="width: 682px">
                            <asp:UpdatePanel id="UpdatePanel4" runat="server">
                                <contenttemplate>
<asp:TextBox id="TxtDependencia" tabIndex=10 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" AutoCompleteType="Disabled"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TxtDependencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100"></ajaxToolkit:AutoCompleteExtender><asp:RadioButtonList id="RadioButtonList2" runat="server" Width="411px" ForeColor="RoyalBlue" Height="19px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">Dependencia Origen</asp:ListItem>
<asp:ListItem Value="1">Numero Documento</asp:ListItem>
<asp:ListItem Value="2">Naturaleza</asp:ListItem>
</asp:RadioButtonList> 
</contenttemplate>
                                <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindDependencia"></asp:PostBackTrigger>
</triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 18px">
                            <asp:ImageButton ID="ImgBtnFindDependencia" runat="server" 
                                                        CausesValidation="False" Height="16px" 
                                                        ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" 
                                                        OnClick="ImgBtnFindDependencia_Click" ToolTip="Buscar Procedencia" 
                                                        ValidationGroup="false" Width="15px" />
                        </td>
                    </tr>
                </table>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel19" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px">
                        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                            <div style="float: left; width: 480px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                &nbsp;<asp:Label ID="Label10" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                &nbsp;<asp:Label ID="LblDocEnvIntVen" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; &nbsp;
                                <asp:Label ID="Label11" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS ANTERIORES ENVIADOS INTERNOS</asp:Label></div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label17" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton6" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                    </asp:Panel>
                    <asp:Panel ID="Panel20" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="text-align: left">
                        <br />
                        <asp:GridView id="GVDocEnvIntVen" runat="server" Width="100%" DataSourceID="ODSDocEnvIntVen" ForeColor="#333333" HorizontalAlign="Right" EmptyDataText="No tiene documentos recibidos externos vencidos" DataKeyNames="NumeroDocumento,WFMovimientoFecha,WFMovimientoFecha1,WFmovimientoFechaFin,DependenciaCodOrigen,ExpedienteCodigo" CellPadding="1" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnRowDataBound="GVDocEnvExtCopia_RowDataBound">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="Registro No." SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" 
                                            Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" OnClientClick="urlInt(event);" Visible="False"></asp:LinkButton>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True"
                                            Text='<%# Eval("NumeroDocumento") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="GrupoNombre" HeaderText="Grupo" SortExpression="GrupoNombre" />
                                <asp:BoundField DataField="WFMovimientoFecha" HeaderText="Fecha de Registro" SortExpression="WFMovimientoFecha" />
                                <asp:BoundField DataField="WFMovimientoFecha1" HeaderText="FechaInicio Tarea" SortExpression="WFMovimientoFecha1" />
                                <asp:BoundField DataField="WFmovimientoFechaFin" HeaderText="Fecha Finalizacion de Tarea"
                                    SortExpression="WFmovimientoFechaFin" />
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Imagenes" CssClass="LinKBtnStyleBig"></asp:HyperLink><br  />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Historico</asp:HyperLink><br    />
                                           <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                        <asp:HiddenField ID="HFGrupo" Value='<%# Eval("GrupoCodigo") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DependenciaCodOrigen" HeaderText="DependenciaCodOrigen"
                                    SortExpression="DependenciaCodOrigen" Visible="False" />
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos recibidos externos vencidos !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvIntVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadoAnterioresExternos"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoEnviadoAnterioresTableAdapter" OnFiltering="ODSDocEnvIntCopia_Filtering">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="6" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
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
        SuppressPostBack="true"/><asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadoAnterioresExternos"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoEnviadoAnterioresTableAdapter" OnFiltering="ODSDocEnvIntCopia_Filtering" FilterExpression="NaturalezaCodigo='{0}'">
            <FilterParameters>
                <asp:ControlParameter ControlID="TxtDependencia" Name="CodProcedencia" />
            </FilterParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="6" Name="WFMovimientoTipo" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo2" Type="Int32" />
                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3">
                        <Columns>
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" SortExpression="NumeroDocumento"
                                Visible="False" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
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
<asp:Panel style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white" id="PnlMensaje" runat="server"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ValidationGroup="789" ImageAlign="Right"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align=center colSpan=2><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle"></ajaxToolkit:ModalPopupExtender> 
</contenttemplate>
                </asp:UpdatePanel>
                <%--<asp:UpdatePanel ID="UP1" runat="server">
                    <ContentTemplate>
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>--%>
           <table border="0">
               <tr>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmFecha" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmDepCod" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmTipo" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmGrupo" runat="server" />
                   </td>
               </tr>
           </table>
                </td>
        </tr>
    </table>
</div>    
  </asp:Content>



