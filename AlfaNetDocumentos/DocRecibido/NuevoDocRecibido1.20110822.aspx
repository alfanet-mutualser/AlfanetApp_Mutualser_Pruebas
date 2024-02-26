<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
  CodeFile="NuevoDocRecibido1.aspx.cs" Inherits="_NuevoDocRecibido1" %>
<%@ import Namespace="System.Configuration" %>
<%@ Register TagName="NavDocRecibido" Src="~/AlfaNetDocumentos/DocRecibido/NavDocRecibido.ascx" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <script type="text/jscript" language="javascript">
 
     function Disable_Attr(e, ToggleControl, HFControl) {
         var s_len = ToggleControl.value.length;
         var s_charcode = 0;
         var contador = 0;
         for (var s_i = 0; s_i < s_len; s_i++) {
             s_charcode = ToggleControl.value.charCodeAt(s_i);
             if (s_charcode == 124) {
                 contador = 1;
             }
         }

         if (contador == 0) {
             HFControl.value = "Dependencia";
         }

     } 
      
     function OnTreeSerieClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtSerieD.ClientID%>");
           var node = document.getElementById("<%=HFCargar.ClientID%>");
           node.innerText = "Serie";
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
     function OnTreeProcesoClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtSerieD.ClientID%>");
           var node = document.getElementById("<%=HFCargar.ClientID%>");
           node.innerText = "Proceso";
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
      function OnTreeClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtSerieD.ClientID%>");
           var node = document.getElementById("<%=HFCargar.ClientID%>");
           node.innerText = "Dependencia";
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
           function OnTreeAccionClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtAccion.ClientID%>");
           nodeText.innerText = src.innerText; 
        }
         //return false; //comment this if you want postback on node click
        }
           function OnTreeExpedienteClick(evt) 
        {   
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtExpediente.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
                function OnTreeMedioClick(evt) 
        {   
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtMedioRecibo.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
                function OnTreeNaturalezaClick(evt,ToggleControl) 
        {   
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtNaturaleza.ClientID%>");
           nodeText.innerText = src.innerText;
           ToggleControl.focus();            
          }
          
          
          //return false; //comment this if you want postback on node click
        }
        
        function urlProcedencia() 
        {
            hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroProcedencia.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        function urlNaturalza() 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroNaturaleza.aspx?Admon=S' , 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        
     </script>    
    <table id="TABLE1" style="width: 100%;">
       
        <tr>
            <td>
            </td>
            <td style="vertical-align: top">
            <table style="width: 100%">
                <tr>
                    <td>
                                    </td>
                    <td colspan="2" style="text-align: right;">
                                    <asp:UpdatePanel id="Updatepanel1000" runat="server">
                                        <contenttemplate>
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 145px; TEXT-ALIGN: left" colSpan=5><asp:Label id="Label1" runat="server" Width="145px" Text="Grupo:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 30%; TEXT-ALIGN: left" colSpan=1><asp:DropDownList id="DropDownListGrupo" runat="server" Width="170px" CssClass="TxtProp" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 60%"><cc1:TextBoxWatermarkExtender id="TBWBuscarRad" watermarkText="Nro de Radicado a Buscar" runat="server" TargetControlID="TxtBuscarRadicado">
                                    </cc1:TextBoxWatermarkExtender> 
    <cc1:AutoCompleteExtender id="ACBuscarRAd" runat="server" TargetControlID="TxtBuscarRadicado" 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
        CompletionListItemCssClass="autocomplete_listItem " 
        CompletionListCssClass="autocomplete_completionListElement" 
        ServicePath="../../AutoComplete.asmx" ServiceMethod="GetRadicadoByGrupo" 
        MinimumPrefixLength="1">
                                    </cc1:AutoCompleteExtender> <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="Debe Digitar Un Número de Radicado" ControlToValidate="TxtBuscarRadicado">*</asp:RequiredFieldValidator> <asp:TextBox id="TxtBuscarRadicado" runat="server" Width="150px" Font-Size="8pt" CausesValidation="True" CssClass="TxtAutoComplete" ValidationGroup="ValGroup1" AutoCompleteType="Homepage"></asp:TextBox> <asp:ImageButton id="ImgBtnFindRad" onclick="ImgBtnFindRad_Click" runat="server" Width="16px" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1" Height="15px" EnableViewState="False"></asp:ImageButton> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                        <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindRad"></asp:PostBackTrigger>
</triggers>
                                    </asp:UpdatePanel>
                    </td>
                </tr>             
                
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtBuscarRadicado"
                            Enabled="False" ErrorMessage="Debe Digitar Un Número de Radicado" Height="15px"
                            SetFocusOnError="True" ValidationGroup="ValGroup1" Width="7px" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="text-align: left;">
                        <table>
                            <tr>
                                <td>
                        <asp:Label ID="LblNroExterno" runat="server" CssClass="PropLabels"
                            Font-Bold="False" Font-Italic="False" Text="Número Externo:"
                            Width="145px"></asp:Label></td>
                                <td>
                        <asp:TextBox ID="TxtNumeroExterno" runat="server" TabIndex="6" Width="97px" CssClass="TxtProp"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="LblFechaRadicacion" runat="server" CssClass="PropLabels"
                            Font-Bold="False" Text="Fecha Radicación:" Width="110px"></asp:Label></td>
                                <td>
                                    <asp:Label ID="DateFechaRad" runat="server" Font-Bold="False" Width="100%" CssClass="PropLabelsFecha"></asp:Label>
                                    <asp:HiddenField ID="HFDate" runat="server" />
                                </td>
                            </tr>
                        </table>
                        &nbsp;<asp:Label ID="LblNumeroGuia" runat="server" CssClass="PropLabels" Font-Bold="False"
                            Text="Número de Guía:" Width="145px"></asp:Label>
                        <asp:TextBox ID="TxtNumeroGuia" runat="server" CssClass="TxtProp" TabIndex="6"
                            Width="97px"></asp:TextBox></td>
                </tr>
                </table>
                <asp:UpdatePanel id="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<TABLE><TBODY><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" Width="7px" ForeColor="White" SetFocusOnError="True" Height="15px" ErrorMessage="Seleccione la fecha de Procedencia" ControlToValidate="SelDateFechaProcedencia">*</asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: left" colSpan=2><TABLE><TBODY><TR><TD><asp:Label id="LblFechaProcedencia" runat="server" Width="145px" Text="* Fecha Procedencia:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD><cc1:CalendarExtender id="CEPro" runat="server" Enabled="True" TargetControlID="SelDateFechaProcedencia" PopupButtonID="Image1" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender> <asp:TextBox id="SelDateFechaProcedencia" tabIndex=6 runat="server" Width="97px" ValidationGroup="1" CssClass="TxtProp"></asp:TextBox>
    <asp:RangeValidator ID="RangeVFecVen0" runat="server" 
        ControlToValidate="SelDateFechaProcedencia" 
        ErrorMessage="La Fecha de Procedencia debe ser Menor que la Fecha de Radicacion" 
        MinimumValue="01/01/2000" Type="Date">*</asp:RangeValidator>
    </TD><TD style="WIDTH: 27px"><asp:Image id="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.gif"></asp:Image></TD><TD><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ForeColor="White" SetFocusOnError="True" ErrorMessage="Debe Ingresar Fecha de Vencimiento" ControlToValidate="SelDateFechaVencimiento">*</asp:RequiredFieldValidator><asp:RangeValidator id="RangeVFecVen" runat="server" ForeColor="White" ErrorMessage="La Fecha de Vencimiento debe ser Mayor que la Fecha de Radicacion" ControlToValidate="SelDateFechaVencimiento" Type="Date" MaximumValue="31/12/2050">*</asp:RangeValidator></TD><TD><asp:Label id="LblFechaVencimiento" runat="server" Width="145px" Text="* Fecha Vencimiento:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD><cc1:CalendarExtender id="CEVen" runat="server" TargetControlID="SelDateFechaVencimiento" PopupButtonID="Image2" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender> <asp:TextBox id="SelDateFechaVencimiento" tabIndex=7 runat="server" Width="97px" ValidationGroup="1" CssClass="TxtProp"></asp:TextBox></TD><TD><asp:Image id="Image2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.gif"></asp:Image></TD></TR></TBODY></TABLE></TD></TR><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" Width="7px" ForeColor="White" SetFocusOnError="True" Height="15px" ErrorMessage="Debe ingresar la Procedencia" ControlToValidate="TxtProcedencia">*</asp:RequiredFieldValidator></TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" colSpan=2><%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>--%><%--</ContentTemplate>
                                                                </asp:UpdatePanel>--%><asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate>
<TABLE><TBODY><TR><TD><asp:Label id="LblProcedencia" runat="server" Width="145px" Text="* Procedencia:" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="100%" Font-Italic="False" CssClass="TxtOpciones" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Size="XX-Small"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TxtProcedencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre" MinimumPrefixLength="1" CompletionInterval="100" CompletionSetCount="12" FirstRowSelected="True" UseContextKey="True" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement"></cc1:AutoCompleteExtender> <asp:TextBox id="TxtProcedencia" tabIndex=10 runat="server" Width="424px" Height="28px" CssClass="TxtAutoComplete" TextMode="MultiLine"></asp:TextBox> </TD><TD><asp:ImageButton id="ImgBtnFindProcedencia" onclick="ImgBtnFindProcedencia_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" ValidationGroup="false" Height="15px"></asp:ImageButton> </TD><TD><asp:ImageButton id="ImgBtnNewProcedencia" runat="server" Width="15px" ToolTip="Nueva Procedencia" OnClientClick="urlProcedencia();" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ImgBtnFindProcedencia" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD></TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" colSpan=2><TABLE style="WIDTH: 198px; HEIGHT: 1px"><TBODY><TR><TD><asp:Label style="TEXT-ALIGN: left" id="LblDetalle" runat="server" Width="145px" Text="Detalle:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD colSpan=3><cc1:Accordion id="Accordion1" runat="server" Width="470px" Height="41px" TransitionDuration="250" SuppressHeaderPostbacks="true" SelectedIndex="-1" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected" HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false" ContentCssClass="accordionContent" AutoSize="None">
                                            <Panes>
                                                <cc1:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                                                    <Header>
                                                        <a class="accordionLink" href="">Detalle.:</a>
                                                    </Header>
                                                    <Content>
                                                        <cc1:TextBoxWatermarkExtender ID="WatermarkDetalle" runat="server" TargetControlID="TxtDetalle"
                                                            WatermarkText="Escriba por favor el detalle del radicado...">
                                                        </cc1:TextBoxWatermarkExtender>
                                                        <asp:TextBox ID="TxtDetalle" runat="server" Height="100px" TabIndex="12" TextMode="MultiLine"
                                                            Width="430px"></asp:TextBox>
                                                    </Content>
                                                </cc1:AccordionPane>
                                            </Panes>
                                        </cc1:Accordion> </TD></TR></TBODY></TABLE></TD></TR><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="7px" ForeColor="White" SetFocusOnError="True" Height="15px" ErrorMessage="Debe ingresar la Naturaleza" ControlToValidate="TxtNaturaleza">*
                                                                    </asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: left" colSpan=2><%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>--%><%--</ContentTemplate>
                                                                </asp:UpdatePanel>--%><asp:UpdatePanel id="UpdatePanel3" runat="server" UpdateMode="Conditional"><ContentTemplate>
<TABLE style="WIDTH: 198px; HEIGHT: 1px"><TBODY><TR><TD><asp:Label id="LblNaturaleza" runat="server" Width="145px" Text="* Naturaleza:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD style="WIDTH: 433px"><cc1:AutoCompleteExtender id="AutoCompleteNatulezaDoc" runat="server" TargetControlID="TxtNaturaleza" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetNaturalezaByText" MinimumPrefixLength="0" UseContextKey="True" CompletionInterval="100"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCENaturaleza" runat="server" TargetControlID="ImgTreeNaturaleza" PopupControlID="PnlTreeNaturaleza">
                                    </cc1:PopupControlExtender> <asp:TextBox id="TxtNaturaleza" tabIndex=14 runat="server" Width="424px" CssClass="TxtAutoComplete" AutoPostBack="True" OnTextChanged="TxtNaturaleza_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 6px"><asp:Image id="ImgTreeNaturaleza" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> <asp:Panel style="LEFT: 707px; TOP: 786px" id="PnlTreeNaturaleza" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVNaturaleza" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVNaturaleza_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                        Text="Seleccione..." Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView> </DIV></asp:Panel> </TD><TD><asp:ImageButton id="ImgBtnNewNaturaleza" runat="server" Width="15px" ToolTip="Nueva Naturaleza" OnClientClick="urlNaturalza() ;" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="TxtNaturaleza" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <table style="width: 100%">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMedioRecibo"
                            ErrorMessage="Debe ingresar el Medio" Height="15px" SetFocusOnError="True" Width="7px" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="text-align: left">
                        <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>                        <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>--%>
                        <asp:UpdatePanel id="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <contenttemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD style="HEIGHT: 6px"><asp:Label id="LblMedioRecibo" runat="server" Width="145px" Text="* Medio de Recibo:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD style="HEIGHT: 6px"><cc1:AutoCompleteExtender id="AutoCompleteMedioRecibo" runat="server" TargetControlID="TxtMedioRecibo" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetMedioByText" MinimumPrefixLength="0" UseContextKey="True" CompletionInterval="100"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEMedio" runat="server" TargetControlID="ImgTreeMedio" PopupControlID="PnlTreeMedio">
                                    </cc1:PopupControlExtender> <asp:TextBox id="TxtMedioRecibo" tabIndex=16 runat="server" Width="424px" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD style="WIDTH: 59px; HEIGHT: 6px"><asp:Panel style="LEFT: 707px; TOP: 909px" id="PnlTreeMedio" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVMedio" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVMedio_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                        Text="Seleccione..." Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView> </DIV></asp:Panel> <asp:Image id="ImgTreeMedio" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image></TD><TD style="WIDTH: 3px; HEIGHT: 6px"><asp:ImageButton id="ImageButton8" runat="server" Width="15px" ToolTip="Nuevo Medio" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroMedio.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton8" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel></td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtExpediente"
                            ErrorMessage="Debe ingresar el Expediente" Height="15px" SetFocusOnError="True"
                            Width="7px" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="text-align: left;">
                        <%-- </ContentTemplate>
                                                                    </asp:UpdatePanel>--%>                        <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>--%>
                        <asp:UpdatePanel id="UpdatePanel5" runat="server">
                            <contenttemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="Label3" runat="server" Width="145px" Text="* Expediente:" Font-Bold="False" CssClass="PropLabels"></asp:Label> </TD><TD style="WIDTH: 433px"><cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" TargetControlID="TxtExpediente" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetExpedienteByTextNombre" MinimumPrefixLength="0" UseContextKey="True" CompletionInterval="100"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEExpediente" runat="server" TargetControlID="ImgTreeExpediente" PopupControlID="PnlTreeExpediente">
                                    </cc1:PopupControlExtender> <asp:TextBox id="TxtExpediente" tabIndex=18 runat="server" Width="424px" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD style="WIDTH: 3px"><asp:Image id="ImgTreeExpediente" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> <asp:Panel style="LEFT: 707px; TOP: 1013px" id="PnlTreeExpediente" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVExpediente" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                        Text="Seleccione..." Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton9" runat="server" Width="15px" ToolTip="Nuevo Expediente" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroExpediente.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtSerieD"
                            ErrorMessage="Debe ingresar el Destino (Cargar A)" Height="15px" SetFocusOnError="True"
                            Width="7px" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="text-align: left">
                        <%-- </ContentTemplate>
                                                                    </asp:UpdatePanel>--%>                        <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>--%>
                        <table style="width: 270px">
                            <tr>
                                <td style="height: 6px">
                                    <asp:Label ID="LblCargarA" runat="server" CssClass="PropLabels" Font-Bold="False"
                                        Text="* Cargar a:" Width="145px"></asp:Label></td>
                                <td style="height: 6px">
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                        MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"
                                        TargetControlID="TxtSerieD" UseContextKey="True" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement">
                                    </cc1:AutoCompleteExtender>
                                    <asp:HiddenField ID="HFCargar" runat="server" />
                                    <cc1:PopupControlExtender ID="PCETreeCargar" runat="server" BehaviorID="PopupControlExtender1"
                                        CommitProperty="value" CommitScript="e.value += ' - SEND A MEETING REQUEST!';"
                                        PopupControlID="Panel88" Position="Left" TargetControlID="ImgFindCargar">
                                    </cc1:PopupControlExtender>
                                    <asp:TextBox ID="TxtSerieD" runat="server" CssClass="TxtAutoComplete"
                                        TabIndex="20" Width="424px"></asp:TextBox>
                                    <asp:Panel ID="Panel88" runat="server" CssClass="popupControl" Height="300px" ScrollBars="Vertical"
                                        Width="350px">
                                        <div>
                                            <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeView1_TreeNodePopulate"
                                                ShowLines="True">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                                        Value="0"></asp:TreeNode>
                                                </Nodes>
                                            </asp:TreeView>
                                            <asp:TreeView ID="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate"
                                                ShowLines="True">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..."
                                                        Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                            <asp:TreeView ID="TreeVProceso" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVProceso_TreeNodePopulate"
                                                ShowLines="True">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Proceso..."
                                                        Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td style="width: 3px; height: 6px">
                                    <asp:Image ID="ImgFindCargar" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"
                                        Width="15px" /></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtAccion"
                            ErrorMessage="Debe ingresar la Accion" Height="15px" SetFocusOnError="True"
                            Width="7px" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="text-align: left">
                        <%--<asp:UpdatePanel ID="UpdatePanelEnterar" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>--%>
                        <asp:UpdatePanel id="UpdatePanel6" runat="server">
                            <contenttemplate>
<TABLE><TBODY><TR><TD><asp:Label id="LblAccion" runat="server" Width="145px" Text="* Acción:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteAccion" runat="server" TargetControlID="TxtAccion" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="0" UseContextKey="True" CompletionInterval="100"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEWFAccion" runat="server" TargetControlID="ImgTreeAccion" Position="Left" PopupControlID="PnlCrtAccion" CommitScript="e.value += ' - SEND A MEETING REQUEST!';" CommitProperty="value" BehaviorID="PopupControlExtender5">
                                    </cc1:PopupControlExtender> <asp:TextBox id="TxtAccion" tabIndex=22 runat="server" Width="424px" CausesValidation="True" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD><asp:Panel style="LEFT: 645px; TOP: 1321px" id="PnlCrtAccion" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVAccion" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVAccion_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                        Text="Seleccione..." Value="0"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView> </DIV></asp:Panel> <asp:Image id="ImgTreeAccion" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> </TD><TD><asp:ImageButton id="ImageButton10" runat="server" Width="15px" ToolTip="Nueva Accion" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroWorkFlowAccion.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" style="text-align: left">
                        <table>
                            <tr>
                                <td style="width: 145px">
                        <br />
                        <table>
                        <tr>
                        <td><asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red"  Text="Radicado Nro:" Width="92px"></asp:Label>
                                    </td>
                        </tr>
                        <tr>
                        <td>
                        <asp:Label ID="LbRadicado" runat="server" Font-Bold="False" ForeColor="Red" Height="16px"
                                        Width="69px"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td><asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Red" Text="Radicado por:" Width="92px"></asp:Label></td>
                        </tr>
                        <tr>
                        <td><asp:Label
                                            ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" Height="16px" Text="Radicador:" Width="69px"></asp:Label>
                                    </td>
                        </tr>
                        </table>
                                    
                        </td>
                                <td colspan="3">
                        <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                                FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                                HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="-1"
                                SuppressHeaderPostbacks="true" TransitionDuration="250" Width="470">
                            <Panes>
                                <cc1:AccordionPane ID="AccordionPane1" runat="server">
                                    <Header>
                                        <a class="accordionLink" href="">Anexo.:</a></Header>
                                    <Content>
                                        <asp:Label ID="LblAnexo" runat="server" CssClass="TxtFormulario" Text="Anexo.:">
                                                                                </asp:Label>
                                        <asp:TextBox ID="TxtAnexo" runat="server" Height="90px" TabIndex="23" TextMode="MultiLine"
                                            Width="420px"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender200" runat="server" TargetControlID="TxtAnexo"
                                                WatermarkText="Escriba por favor el Anexo del Registro...">
                                        </cc1:TextBoxWatermarkExtender>
                                    </Content>
                                </cc1:AccordionPane>
                                <cc1:AccordionPane ID="AccordionPane2" runat="server">
                                    <Header>
                                        <a class="accordionLink" href="">Enterar A.:</a></Header>
                                    <Content>
                                        <%--<asp:UpdatePanel ID="UpdatePanelEnterar" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>--%>
                                        <asp:Panel id="Paneldep" runat="server" DefaultButton="ImgBtnAdd">
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator21" runat="server" Width="7px" ValidationGroup="Enterar" SetFocusOnError="True" Height="15px" ErrorMessage="Seleccione la Dependencia" ControlToValidate="TxtDependencia1" Enabled="true">*</asp:RequiredFieldValidator><asp:UpdatePanel id="UpdatePanel8" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD style="WIDTH: 38px; HEIGHT: 10px"><cc1:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TxtDependencia1" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement"></cc1:AutoCompleteExtender> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender6" watermarkText="Seleccione una Dependencia..." runat="server" TargetControlID="TxtDependencia1">
                                                        </cc1:TextBoxWatermarkExtender> <asp:Label id="Label14" runat="server" Width="155px" Font-Bold="False" Text="Dependencia.:" CssClass="LabelStyle"></asp:Label> <asp:TextBox id="TxtDependencia1" tabIndex=25 runat="server" Width="353px" ValidationGroup="Enterar" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 38px; HEIGHT: 10px"><asp:ImageButton id="ImgBtnAdd" tabIndex=26 onclick="ImgBtnAdd_Click" runat="server" ValidationGroup="Enterar" ToolTip="Agregar Dependencia" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Enabled="True"></asp:ImageButton> <asp:ImageButton id="ImgBtnDelete" tabIndex=26 onclick="ImgBtnDelete_Click" runat="server" ValidationGroup="Enterar" CausesValidation="False" ToolTip="Eliminar Dependencia" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" Enabled="True"></asp:ImageButton> </TD></TR><TR><TD style="WIDTH: 38px; HEIGHT: 10px"><asp:ListBox id="ListBoxEnterar" runat="server" Width="360px"></asp:ListBox> <asp:RadioButtonList id="RBEnterarA" tabIndex=8 runat="server" Width="358px" Font-Size="8pt" ValidationGroup="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBEnterarA_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Dependencias Individuales</asp:ListItem>
<asp:ListItem Value="T">Todas Las Dependencias</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel></asp:Panel>
                                        <%--</ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="LinkButton6" EventName="Click" />
                                                                                        <asp:AsyncPostBackTrigger ControlID="LinkButton7" EventName="Click" />
                                                                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnAdd" EventName="Click" />
                                                                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnDelete" EventName="Click" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>--%>
                                    </Content>
                                </cc1:AccordionPane>
                            </Panes>
                        </cc1:Accordion>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </td>        
            <td>
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%; height: 20%">
                            </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%">
                            <asp:ImageButton ID="cmdAceptar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/Radicar.png" OnClick="cmdAceptarImg_Click" ToolTip="Radicar" /></td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%; height: 16px;">
                        </td>
                        <td style="width: 80%; height: 16px;">
                            <asp:Label ID="Label2" runat="server" Text="Radicar"></asp:Label></td>
                        <td style="width: 10%; height: 16px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdNuevo" OnClick="BtnNuevoRad_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/NewRadicado.png"
                                ToolTip="Nuevo Radicado" CausesValidation ="false" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Nuevo"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdActualizar" OnClick="cmdActualizar_Click" 
                                runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/ActualizarRadicado.png"
                                ToolTip="Actualizar Radicado" Width="36px" CommandArgument="2" 
                                CommandName="Actualizar" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Actualizar"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdCancel" OnClick="cmdCancel_Click" CausesValidation="False" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/cerrar.png"
                                ToolTip="Cerrar" Height="36px" Width="36px" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Cerrar"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 187px">
                        </td>
                        <td style="height: 187px">
                            
                            <uc2:NavDocRecibido ID="NavDocRecibido1" runat="server" Visible="true"/>
                        </td>
                        <td style="height: 187px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20%" colspan="3" rowspan="1">
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="vertical-align: top; text-align: center;">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ButtonHighlight"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 5%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789"></asp:ImageButton> </TD></TR><TR><TD style="BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><asp:Label id="LblMessageBox" runat="server" Width="350px" Font-Size="X-Large" ForeColor="Red"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel><cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" TargetControlID="LblMessageBox" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                                        </cc1:ModalPopupExtender> 
</contenttemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel id="UpdatePanel20" runat="server">
                <contenttemplate>
<cc1:ModalPopupExtender id="MPE2" runat="server" TargetControlID="ButtonOk" PopupControlID="PNL" BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" OkControlID="ButtonOk">
</cc1:ModalPopupExtender> <cc1:ConfirmButtonExtender id="CBE2" runat="server" TargetControlID="ButtonOk" DisplayModalPopupID="MPE2" OnClientCancel="cancelClick">
</cc1:ConfirmButtonExtender> <asp:Panel style="DISPLAY: none; WIDTH: 265px; BACKGROUND-COLOR: white" id="PNL" runat="server"><DIV style="TEXT-ALIGN: right"><TABLE><TBODY><TR><TD style="HEIGHT: 23px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Lbl555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 5%; HEIGHT: 23px; BACKGROUND-COLOR: gray"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789"></asp:ImageButton> </TD></TR><TR><TD align=center colSpan=2><BR /><asp:Label id="LblMessageBox2" runat="server" Width="250px" Font-Size="Small" ForeColor="Red" Font-Bold="True">Ya Existe un Radicado con el mismo Numero Externo, Fecha y Procedencia. Desea Continuar  con el Radicado?</asp:Label><BR /><BR /><asp:Button id="ButtonOk" onclick="ButtonOk_Click" runat="server" Text="OK"></asp:Button> <asp:Button id="ButtonCancel" runat="server" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></DIV></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="ButtonOk"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummaryRadicado" runat="server"
                    DisplayMode="List" Font-Size="10pt" Style="vertical-align: middle; text-align: left" />
                <asp:ObjectDataSource ID="GroupDataSource" runat="server" DeleteMethod="DeleteGrupo"
                    InsertMethod="AddGrupo" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGrupoByID"
                    TypeName="GrupoBLL" UpdateMethod="UpdateGrupo">
                    <DeleteParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="GrupoNombre" Type="String" />
                        <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                        <asp:Parameter Name="GrupoConsecutivo" Type="Int32" />
                        <asp:Parameter Name="GrupoHabilitar" Type="Boolean" />
                        <asp:Parameter Name="GrupoPermiso" Type="Boolean" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="GrupoNombre" Type="String" />
                        <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                        <asp:Parameter Name="GrupoConsecutivo" Type="Int32" />
                        <asp:Parameter Name="GrupoHabilitar" Type="Boolean" />
                        <asp:Parameter Name="GrupoPermiso" Type="Boolean" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                    SelectCommand="SELECT [WFProcesoCodigo], [WFProcesoDescripcion] FROM [WFProceso] WHERE ([WFProcesoHabilitar] = @WFProcesoHabilitar) ORDER BY [WFProcesoCodigo], [WFProcesoDescripcion]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFProcesoHabilitar" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:ObjectDataSource ID="RadicadoDataSource" runat="server" InsertMethod="AddRadicado"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetGroupById" TypeName="RadicadoBLL"
                    UpdateMethod="AddRadicado">
                    <UpdateParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoDetalle" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                        <asp:Parameter Name="WFMovimientoNotas" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoMultitarea" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoDetalle" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                        <asp:Parameter Name="WFMovimientoNotas" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoMultitarea" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red" Width="100%"></asp:Label></td>
            <td>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
    </table>
</asp:Content>

