<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="NuevoDocEnviadoInt.aspx.cs" Inherits="_NuevoDocEnviadoInt" ValidateRequest="false"%>

<%@ Register Src="NavDocEnviado.ascx" TagName="NavDocEnviado" TagPrefix="uc1"%>
<%@ Import Namespace="System.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript">
// <!CDATA[
// ]]> 
        function OnTreeClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TxtDependencia.ClientID%>");
           nodeText.innerText = src.innerText; 
        }
          
          //return false; //comment this if you want postback on node click
        }
           function OnTreeDestinoClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TxtDestino.ClientID%>");
           nodeText.innerText = src.innerText; 
        }
          
          //return false; //comment this if you want postback on node click
        }
            function OnTreeNaturalezaClick(evt) 
        {   
            //alert("hola"); 
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TxtNaturaleza.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
           function OnTreeExpedienteClick(evt) 
        {   
            //alert("hola"); 
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TxtExpediente.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
           function OnTreeSerieClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TextBox1.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
          
          //return false; //comment this if you want postback on node click
        }
            function OnTreeMedioClick(evt) 
        {   
            //alert("hola"); 
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=TxtMedioRecibo.ClientID%>");
           nodeText.innerText = src.innerText; 
           
          }
        }
          
         function checkControl(TxtDestino) 
          {   
            var nodeText = document.getElementById("<%=TxtDestino.ClientID%>");
            nodeText.innerText  = ""; 
            nodeText.innerHTML  = ""; 
            
//            var RBL = document.getElementById("<%=RadioButtonList1.ClientID%>");
//            if( RBL != null ){ RBL.focus(); }
            
            var ACDestino = document.getElementById("<%=AutoCompleteExtender3.ClientID%>");
            if( ACDestino != null )
            { 
                ACDestino.set_serviceMethod("GetProcedenciaByTextNombre");                       
            }         
                     
          }
          
         
        
    </script>
    <table style="width: 100%; text-align: float;">
        <tr>
            <td>
            </td>
            <td colspan="2" style="width: 70%">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <table style="width: 74%; text-align: center;">
                    <tbody>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" style="text-align: left">
                <asp:UpdatePanel id="Updatepanel1000" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 160px; TEXT-ALIGN: left"><asp:Label id="Label5" runat="server" Width="160px" Text="Grupo a consultar:" Font-Bold="False" CssClass="PropLabels" Font-Italic="False"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="DropDownListGrupo" runat="server" Width="170px" CssClass="TxtProp" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></TD><TD style="TEXT-ALIGN: right">
    <cc1:AutoCompleteExtender id="AutoCompleteBuscarRAd" runat="server" 
        CompletionListCssClass="autocomplete_completionListElement" 
        TargetControlID="TxtBuscarRadicado" ServicePath="../../AutoComplete.asmx" 
        ServiceMethod="GetRegistroCodigoByCodigo" MinimumPrefixLength="1" CompletionListItemCssClass="autocomplete_listItem " 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkBuscarRad" watermarkText="Nro de Registro a Buscar" runat="server" TargetControlID="TxtBuscarRadicado">
                            </cc1:TextBoxWatermarkExtender> &nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Width="7px" SetFocusOnError="True" Height="15px" ErrorMessage="Debe ingresar el numero de Registro" ControlToValidate="TxtBuscarRadicado" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator> <asp:TextBox id="TxtBuscarRadicado" runat="server" Width="150px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> <asp:ImageButton id="ImgBtnFindRad" onclick="ImgBtnFindRad_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindRad"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" style="text-align: left;">
                                &nbsp;<asp:Label ID="LblFechaRadicacion" runat="server" CssClass="PropLabels" Font-Bold="False"
                                    Text="Fecha  y Hora de Registro:" Width="160px"></asp:Label>
                                <asp:Label ID="DateFechaRad" runat="server" CssClass="PropLabelsFecha"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtDependencia"
                                    ErrorMessage="Debe ingresar la Dependencia que Remite" Height="15px" SetFocusOnError="True"
                                    Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                <%-- </ContentTemplate>
                                                                <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="Option1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="Option3" EventName="Click"   CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement"   />
                                                                </Triggers>
                                                            </asp:UpdatePanel>--%>
                                <table style="width: 270px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblDependencia" runat="server" CssClass="PropLabels" Font-Bold="False"
                                                Text="Dependencia  Remite.:" Width="160px"></asp:Label></td>
                                        <td>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteDependencia" runat="server" CompletionInterval="10"
                                                MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"
                                                TargetControlID="TxtDependencia" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListCssClass="autocomplete_completionListElement" EnableCaching="False">
                                            </cc1:AutoCompleteExtender>
                                            <cc1:PopupControlExtender ID="PopCRemite" runat="server" CommitProperty="value" CommitScript="e.value;"
                                                PopupControlID="Panel84" Position="Bottom" TargetControlID="ImgFindRemite">
                                            </cc1:PopupControlExtender>
                                            <asp:Panel ID="Panel84" runat="server" CssClass="popupControl" Height="300px" ScrollBars="Vertical"
                                                Width="350px">
                                                <div>
                                                    <asp:TreeView ID="TreeVRemite" runat="server" ExpandDepth="0" ImageSet="Simple2"
                                                        OnTreeNodePopulate="TreeVRemite_TreeNodePopulate" ShowLines="True" Width="300px">
                                                        <ParentNodeStyle Font-Bold="False" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione..."
                                                                Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView>
                                                </div>
                                            </asp:Panel>
                                            <asp:TextBox ID="TxtDependencia" runat="server" CssClass="TxtAutoComplete" Font-Size="8pt"
                                                name="Txtdependencia" TabIndex="2" ValidationGroup="1" Width="424px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Image ID="ImgFindRemite" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"
                                                Width="15px" />
                                        </td>
                                        <td style="width: 3px">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtDestino"
                                    ErrorMessage="Debe ingresar el Gestino Interno o Externo" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                    <contenttemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="LblDestino" runat="server" Width="160px" Text="Destino.:" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:RadioButtonList id="RadioButtonList1" tabIndex=8 runat="server" Font-Size="Smaller" ForeColor="RoyalBlue" ValidationGroup="1" CssClass="TxtOpciones" RepeatDirection="Horizontal" AutoPostBack="True" OnLoad="RadioButtonList1_Load" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="100%"><asp:ListItem Value="1">Interno</asp:ListItem>
<asp:ListItem Value="0">Externo</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 399px">
        <cc1:AutoCompleteExtender id="AutoCompleteDestino" runat="server" 
             CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement"
            TargetControlID="TxtDestino" ServicePath="../../AutoComplete.asmx"
            ServiceMethod="GetDependenciaByText" MinimumPrefixLength="1"
            CompletionInterval="100" UseContextKey="True"
            CompletionSetCount="12"></cc1:AutoCompleteExtender><cc1:PopupControlExtender id="PopCDestino" runat="server" TargetControlID="ImgFindDestino" Position="Bottom" PopupControlID="PnlDestino" CommitScript="e.text;" CommitProperty="text">
                                                </cc1:PopupControlExtender> <asp:Panel id="PnlDestino" runat="server" Width="350px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVDestino" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVDestino_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> <asp:TextBox id="TxtDestino" tabIndex=10 runat="server" Width="424px" Font-Size="8pt" CausesValidation="True" Height="30px" CssClass="TxtAutoComplete" TextMode="MultiLine"></asp:TextBox></TD><TD><asp:Image id="ImgFindDestino" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" Height="15px"></asp:Image></TD><TD><asp:ImageButton id="ImageButton12" runat="server" Width="15px" Visible="False" ToolTip="Nueva Procedencia" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroProcedencia.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtDestino"
                                    ErrorMessage="Debe ingresar el Radicado Fuente" Height="15px" SetFocusOnError="True"
                                    Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">--%>
                                <%--<ContentTemplate>--%>
                                <table style="width: 100%; height: 39%">
                                    <tr>
                                        <td style="width: 158px;">
                                <asp:Label ID="LblRadFuente" runat="server" CssClass="PropLabels" Font-Bold="False"
                                    Text="Radicacion Fuente.:" Width="160px"></asp:Label></td>
                                        <td>
                                <cc1:Accordion ID="AccordionFuente" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                                    FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                                    HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="-1"
                                    SuppressHeaderPostbacks="true" TransitionDuration="250" Width="470">
                                   <Panes>
                                        <cc1:AccordionPane ID="AccordionPaneFuente" runat="server" ContentCssClass="" HeaderCssClass="">
                                            <Header>
                                                <a class="accordionLink" href="">RadicadoFuente.:</a>
                                            
</Header>
                                            <Content>
                                              <asp:UpdatePanel id="UPFuente" runat="server"><ContentTemplate>
<asp:Panel id="PnlFuente" runat="server" DefaultButton="ImgBtnAddFuente"><TABLE style="WIDTH: 250px"><TBODY><TR><TD><TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="LblGrupoRadicadoFuente" runat="server" Width="164px" Text="Grupo Radicado Fuente.:" Font-Bold="False" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 100px"><asp:UpdatePanel id="Updatepanel6" runat="server"><ContentTemplate>
<asp:DropDownList id="DropDownListGrupoFuente" runat="server" Width="103px" CssClass="TxtProp" AutoPostBack="true" OnSelectedIndexChanged="DropDownListGrupoFuente_SelectedIndexChanged">
</asp:DropDownList> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR></TBODY></TABLE> </TD><TD></TD></TR><TR><TD><asp:RequiredFieldValidator id="RFVFuente" runat="server" Enabled="true" ValidationGroup="Fuente" SetFocusOnError="True" ErrorMessage="Seleccione la Radicado Fuente" ControlToValidate="TxtRadFuente">*</asp:RequiredFieldValidator> <asp:Label id="LblFuente" runat="server" Width="155px" Text="Radicado Fuente.:" Font-Bold="False" CssClass="LabelStyle"></asp:Label> <cc1:TextBoxWatermarkExtender id="WatermarkRadFuente" watermarkText="Seleccione una Radicado Fuente..." runat="server" TargetControlID="TxtRadFuente">
                                                                </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteRadFuente" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtRadFuente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetRadicadoFuenteByGrupo" MinimumPrefixLength="0" CompletionInterval="100"></cc1:AutoCompleteExtender> <asp:Label id="Label1" runat="server"></asp:Label><asp:TextBox id="TxtRadFuente" tabIndex=12 runat="server" Width="342px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD><asp:ImageButton id="ImgBtnAddFuente" tabIndex=26 onclick="ImgBtnAddFuente_Click" runat="server" ToolTip="Agregar Radicado Fuente" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Enabled="True" ValidationGroup="Fuente">
 </asp:ImageButton> <asp:ImageButton id="ImgBtnDeleteFuente" tabIndex=26 onclick="ImgBtnDeleteFuente_Click" runat="server" ToolTip="Eliminar Radicado Fuente" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" Enabled="True" CauseValidation="False">
 </asp:ImageButton> </TD></TR><TR><TD><asp:ListBox id="ListBoxFuente" runat="server" Width="350px" DataTextField="RadicadoCodigoFuente" DataValueField="RadicadoCodigoFuente"></asp:ListBox> <asp:RadioButtonList id="RBFuente" tabIndex=8 runat="server" Width="350px" Font-Size="8pt" Visible="False" ValidationGroup="1" AutoPostBack="True" OnSelectedIndexChanged="RBFuente_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Fuentes Individuales</asp:ListItem>
<asp:ListItem Value="T">Todas Las Fuentes</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel>
                                            
</Content>
                                        </cc1:AccordionPane>
                                        </Panes>
                                </cc1:Accordion>
                                        </td>
                                    </tr>
                                </table>
                                
                                <%--</ContentTemplate>--%>
                                <%-- <Triggers>
                                                                  <asp:AsyncPostBackTrigger ControlID="LinkButton3" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--</SPAN>--%>
                            </td>
                            <td colspan="2" style="text-align: left">
                                <table>
                                    <tr>
                                        <td>
                                <asp:Label ID="LblDetalle" runat="server" CssClass="PropLabels" Font-Bold="False"
                                    Text="Detalle.:" Width="160px"></asp:Label></td>
                                        <td style="width: 685px">
                                <cc1:Accordion ID="Accordion2" runat="server" Width="470" TransitionDuration="250"
                                    SuppressHeaderPostbacks="true" SelectedIndex="-1" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                                    ContentCssClass="accordionContent" AutoSize="None">
                                    <Panes>
                                        <cc1:AccordionPane ID="AccordionPane3" runat="server">
                                            <Header>
                                                <a class="accordionLink" href="">Detalle.:</a>
                                            </Header>
                                            <Content>
                                                <cc1:TextBoxWatermarkExtender ID="WatermarkDetalle" runat="server" TargetControlID="TxtDetalle"
                                                    WatermarkText="Escriba por favor el detalle del registro...">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="TxtDetalle" runat="server" Height="100px" TabIndex="12" TextMode="MultiLine"
                                                    Width="450px"></asp:TextBox>
                                            </Content>
                                        </cc1:AccordionPane>
                                    </Panes>
                                </cc1:Accordion>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNaturaleza"
                                    ErrorMessage="Debe ingresar la Naturaleza" Height="15px" SetFocusOnError="True"
                                    Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>--%>
                                <%-- </ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnNaturaleza1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LbtnNaturaleza2" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                                <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                    <contenttemplate>
<TABLE style="WIDTH: 270px; HEIGHT: 19px"><TBODY><TR><TD><asp:Label id="LblNaturaleza" runat="server" Width="160px" Text="Naturaleza Documento.:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteNatulezaDoc" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtNaturaleza" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetNaturalezaByText" MinimumPrefixLength="0" CompletionInterval="100" UseContextKey="True"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCENaturaleza" runat="server" TargetControlID="ImgTreeNaturaleza" PopupControlID="PnlTreeNaturaleza">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtNaturaleza" tabIndex=16 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" OnTextChanged="TxtNaturaleza_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 19px"><asp:Image id="ImgTreeNaturaleza" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image><asp:Panel style="LEFT: 707px; TOP: 1007px" id="PnlTreeNaturaleza" runat="server" Width="350px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVNaturaleza" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVNaturaleza_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False" Text="Seleccione..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 19px"><asp:ImageButton id="ImageButton7" runat="server" Width="15px" ToolTip="Nueva Naturaleza" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroNaturaleza.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMedioRecibo"
                                    ErrorMessage="Debe ingresar el Medio" Height="15px" SetFocusOnError="True" Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>--%>
                                <%--</ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnMedio1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnMedio2" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                                <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                    <contenttemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="LblMedioRecibo" 
        runat="server" Width="160px" Text="Medio de Envio.:" Font-Bold="False" 
        CssClass="PropLabels"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteMedioRecibo" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtMedioRecibo" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetMedioByText" MinimumPrefixLength="0" CompletionInterval="100" UseContextKey="True"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEMedio" runat="server" TargetControlID="ImgTreeMedio" PopupControlID="PnlTreeMedio">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtMedioRecibo" tabIndex=18 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 19px"><asp:Panel style="LEFT: 707px; TOP: 1149px" id="PnlTreeMedio" runat="server" Width="350px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVMedio" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVMedio_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False" Text="Seleccione..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> <asp:Image id="ImgTreeMedio" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image></TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton8" runat="server" Width="15px" ToolTip="Nuevo Medio" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroMedio.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
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
                                        <td>
                                <asp:Label ID="Label4" runat="server" CssClass="PropLabels" Font-Bold="False"
                                    Text="Guia.:" Width="160px"></asp:Label></td>
                                        <td>
                                <cc1:Accordion ID="Accordion1" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                                    SelectedIndex="-1" ContentCssClass="accordionContent" FadeTransitions="false"
                                    FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false"
                                    SuppressHeaderPostbacks="true" Width="470">
                                    <Panes>
                                        <cc1:AccordionPane ID="AccordionPane4" runat="server">
                                            <Header>
                                                <a href="" class="accordionLink">Guia.:</a></Header>
                                            <Content>
                                                
                                            <asp:UpdatePanel id="UpdatePanel20" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                <TABLE><TBODY><TR><TD 
style="WIDTH: 76px; HEIGHT: 10px"><asp:Label id="LblGuia" runat="server" Width="145px" Text="Guia.:" Font-Bold="False" CssClass="LabelStyle"> </asp:Label> 
</TD><TD style="WIDTH: 76px; HEIGHT: 10px"><asp:TextBox id="TxtGuia" tabIndex=20 runat="server" ValidationGroup="1"> </asp:TextBox> 
<cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Digite el Nro de Guia..." runat="server" TargetControlID="TxtGuia">
</cc1:TextBoxWatermarkExtender> </TD></TR><TR><TD style="WIDTH: 76px; HEIGHT: 10px"><asp:Label id="LblPesoEnvio" runat="server" Width="145px" Text="Peso Envio (gr).:" Font-Bold="False" CssClass="LabelStyle"></asp:Label> 
</TD><TD style="WIDTH: 76px; HEIGHT: 10px"><asp:TextBox id="TxtPesoEnvio" tabIndex=19 runat="server" ValidationGroup="1" OnTextChanged="TxtPesoEnvio_TextChanged" AutoPostBack="True"> </asp:TextBox> 
<cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Digite el Peso de Envio..." runat="server" TargetControlID="TxtPesoEnvio">
</cc1:TextBoxWatermarkExtender> </TD></TR><TR><TD style="WIDTH: 76px; HEIGHT: 10px"><asp:Label id="LblValor" runat="server" Width="145px" Text="Valor($).:" Font-Bold="False" CssClass="LabelStyle"> </asp:Label> 
</TD><TD style="WIDTH: 76px; HEIGHT: 10px"><asp:TextBox id="TxtValor" tabIndex=21 runat="server" ValidationGroup="1"> </asp:TextBox> 
<cc1:maskededitextender id="MaskedEditExtender1" runat="server" clearmaskonlostfocus="False" cultureampmplaceholder="" culturecurrencysymbolplaceholder="" culturedateformat="" culturedateplaceholder="" culturedecimalplaceholder="" culturethousandsplaceholder="" culturetimeplaceholder="" enabled="True" mask="9999999999,99" masktype="Number" targetcontrolid="TxtValor" ErrorTooltipEnabled="false"></cc1:maskededitextender> 
<cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender4" watermarkText="Digite el valor de Envio.." runat="server" TargetControlID="TxtValor">
</cc1:TextBoxWatermarkExtender> </TD></TR><TR><TD style="WIDTH: 76px"><asp:Label id="LblMotDev" runat="server" Width="145px" Visible="False" Text="Motivo Devolucion.:" Font-Bold="False" CssClass="LabelStyle"></asp:Label></TD><TD>
<asp:DropDownList id="DropDownList1" runat="server" Width="200px" DataSourceID="SQLDS" Visible="False" AppendDataBoundItems="False" DataTextField="TTVALORC" DataValueField="TTCODCLA">
</asp:DropDownList>
<asp:SqlDataSource id="SQLDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" 
SelectCommand="SELECT [TTCODCLA], [TTVALORC] FROM [TBTABLAS] WHERE ([TTCODTAB] = @TTCODTAB) ORDER BY [TTCODCLA]">
<SelectParameters>
<asp:Parameter DefaultValue="MOTDEVRE" Name="TTCODTAB" Type="String"></asp:Parameter>
</SelectParameters>
</asp:SqlDataSource> </TD></TR><TR><TD 
style="WIDTH: 76px"><asp:Label id="LblFecDev" runat="server" Width="145px" Visible="False" Text="Fecha Devolucion.:" Font-Bold="False" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:CalendarExtender id="CEFecDev" runat="server" Enabled="True" TargetControlID="TxtFecMotDev" BehaviorID="CEFecDev" PopupButtonID="ImgFecDev" Format="dd/MM/yyyy">
    </cc1:CalendarExtender> <asp:TextBox id="TxtFecMotDev" tabIndex=21 runat="server" Width="97px" Visible="False" ValidationGroup="1"></asp:TextBox> 
<asp:Image id="ImgFecDev" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.gif"></asp:Image></TD></TR></TBODY></TABLE>

</ContentTemplate>
</asp:UpdatePanel>
                                            
                                            </Content>
                                        </cc1:AccordionPane>
                                    </Panes>
                                </cc1:Accordion>
                               
                               
                                


                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtExpediente"
                                    ErrorMessage="Debe ingresar el Expediente" Height="15px" SetFocusOnError="True"
                                    Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>--%>
                                <%-- </ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnExpediente1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnExpediente2" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                    <contenttemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="LblExpediente" runat="server" Width="160px" Text="Expediente.:" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtExpediente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetExpedienteByTextNombre" MinimumPrefixLength="0" CompletionInterval="100" UseContextKey="True"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEExpediente" runat="server" TargetControlID="ImgTreeExpediente" PopupControlID="PnlTreeExpediente">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtExpediente" tabIndex=21 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD><asp:Image id="ImgTreeExpediente" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image><asp:Panel style="LEFT: 707px; TOP: 1384px" id="PnlTreeExpediente" runat="server" Width="350px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVExpediente" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False" Text="Seleccione..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton9" runat="server" Width="15px" ToolTip="Nuevo Expediente" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroExpediente.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Height="15px"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="Debe ingresar la Serie" Height="15px" SetFocusOnError="True"
                                    Width="7px">*</asp:RequiredFieldValidator></td>
                            <td colspan="2" style="text-align: left">
                                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                    <ContentTemplate>--%>
                                <%--</ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LinkButton4" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LinkButton5" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                                <table style="width: 270px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" CssClass="PropLabels" Font-Bold="False" Text="Archivar En.:"
                                                Width="160px"></asp:Label></td>
                                        <td>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                                                MinimumPrefixLength="0" ServiceMethod="GetSerieByText" ServicePath="../../AutoComplete.asmx"
                                                TargetControlID="TextBox1" UseContextKey="True" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement">
                                            </cc1:AutoCompleteExtender>
                                            <cc1:PopupControlExtender ID="PCETreeCargar" runat="server" BehaviorID="PopupControlExtender1"
                                                CommitProperty="value" CommitScript="e.value += ' - SEND A MEETING REQUEST!';"
                                                PopupControlID="Panel88" Position="Left" TargetControlID="ImgFindCargar">
                                            </cc1:PopupControlExtender>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TxtAutoComplete" TabIndex="21"
                                                Width="424px"></asp:TextBox>
                                        </td>
                                        <td style="width: 35px">
                                            <asp:Panel ID="Panel88" runat="server" CssClass="popupControl" Height="300px" ScrollBars="Vertical"
                                                Width="350px">
                                                <div>
                                                    <asp:TreeView ID="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate"
                                                        ShowLines="True" Width="300px">
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
                                                    &nbsp;
                                                </div>
                                            </asp:Panel>
                                            <asp:Image ID="ImgFindCargar" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"
                                                Width="15px" />
                                        </td>
                                        <td style="width: 3px">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" style="text-align: left">
                                <table>
                                    <tr>
                                        <td style="width: 164px">
                                        <table>
                                        <tr>
                                        <td>
                                         <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Red"  Text="Registro Nro:" Width="102px"></asp:Label><br />
                                           
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>
                                             <asp:Label ID="Label6" runat="server" Font-Bold="False" ForeColor="Red" Height="16px"
                                               Width="154px"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>
                                                
                                        <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Red"  Text="Registrado por:" Width="102px"></asp:Label>
                                         
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" Height="16px"
                                                 Text="Registrado por:" Width="154px"></asp:Label>
                                           
                                        </td>
                                        </tr>
                                        </table>
                                           </td>
                                        <td>
                                <cc1:Accordion ID="MyAccordion" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                                    SelectedIndex="-1" ContentCssClass="accordionContent" FadeTransitions="false"
                                    FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false"
                                    SuppressHeaderPostbacks="true" Width="470">
                                    <Panes>
                                        <cc1:AccordionPane ID="AccordionPane1" runat="server">
                                            <Header>
                                                <a href="" class="accordionLink">Anexo.:</a></Header>
                                            <Content>
                                                <asp:Label ID="LblAnexo" runat="server" CssClass="TxtFormulario" Text="Anexo.:">
                                                </asp:Label>
                                                <asp:TextBox ID="TxtAnexo" TabIndex="23" runat="server" Height="90px" TextMode="MultiLine"
                                                    Width="400px"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender200" runat="server" TargetControlID="TxtAnexo"
                                                    WatermarkText="Escriba por favor el Anexo del Registro...">
                                                </cc1:TextBoxWatermarkExtender>
                                            </Content>
                                        </cc1:AccordionPane>
                                        <cc1:AccordionPane ID="AccordionPane2" runat="server">
                                            <Header>
                                                <a href="" class="accordionLink">Copiar A.:</a></Header>
                                                
                                           <Content>
                                             
                                             <asp:UpdatePanel id="UpdatePanelEnterar" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:Panel id="Paneldep" runat="server" DefaultButton="ImgBtnAdd"><asp:RequiredFieldValidator id="RequiredFieldValidator21" runat="server" Width="7px" Height="15px" ValidationGroup="Enterar" SetFocusOnError="True" ErrorMessage="Seleccione la Dependencia" ControlToValidate="TxtDependencia1" Enabled="true">*</asp:RequiredFieldValidator><asp:Label id="Label14" runat="server" Width="145px" Font-Bold="False" Text="Destino.:" CssClass="LabelStyle" Visible="False"></asp:Label> 
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="TxtOpciones"
        RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" Visible="False">
        <asp:ListItem Selected="True" Value="1">Interno</asp:ListItem>
        <asp:ListItem Value="0">Externo</asp:ListItem>
    </asp:RadioButtonList><TABLE style="WIDTH: 270px"><TBODY><TR><TD style="WIDTH: 359px"><cc1:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TxtDependencia1" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender6" watermarkText="Seleccione una Dependencia..." runat="server" TargetControlID="TxtDependencia1">
                                                                                                    </cc1:TextBoxWatermarkExtender> <asp:TextBox id="TxtDependencia1" tabIndex=25 runat="server" Width="345px" CssClass="TxtAutoComplete" ValidationGroup="Enterar"></asp:TextBox> </TD><TD><asp:ImageButton id="ImgBtnAdd" tabIndex=26 onclick="ImgBtnAdd_Click" runat="server" ValidationGroup="Enterar" ToolTip="Agregar Dependencia" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Enabled="True"></asp:ImageButton> <asp:ImageButton id="ImgBtnDelete" tabIndex=26 onclick="ImgBtnDelete_Click" runat="server" ValidationGroup="Enterar" ToolTip="Eliminar Dependencia" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" Enabled="True"></asp:ImageButton> </TD></TR><TR><TD style="WIDTH: 359px"><asp:ListBox id="ListBoxEnterar" runat="server" Width="350px"></asp:ListBox> <asp:RadioButtonList id="RBEnterarA" tabIndex=8 runat="server" Width="348px" Font-Size="8pt" ValidationGroup="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBEnterarA_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Destinos Individuales</asp:ListItem>
<asp:ListItem Value="T">Todos los Destinos</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ImgBtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ImgBtnDelete" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel>
                                             
                                            </Content> 
                                
                                            
                                            
                                        </cc1:AccordionPane>
                                    </Panes>
                                </cc1:Accordion>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                
<asp:ObjectDataSource ID="ODSRadFuente" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRadFuente" TypeName="DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_RegistroCodigo" Type="Int32" />
                        <asp:Parameter Name="Original_RadicadoCodigoFuente" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Original_RegistroCodigo" Type="Int32" />
                        <asp:Parameter Name="Original_RadicadoCodigoFuente" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="RegistroCodigo" Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="RegistroCodigo" Type="Int32" />
                        <asp:Parameter Name="RadicadoCodigoFuente" Type="Int32" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
            <td>               
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%; height: 20%">
                        </td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%">
                            <asp:ImageButton ID="cmdAceptar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/Radicar.png"
                                OnClick="cmdAceptar_Click" ToolTip="Registrar" /></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%">
                            <asp:Label ID="Label100" runat="server" Text="Registrar"></asp:Label></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdNuevo" runat="server" CausesValidation="false" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/NewRadicado.png"
                                OnClick="BtnNuevoRad_Click" ToolTip="Nuevo Registro" /></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Nuevo"></asp:Label></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdActualizar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/ActualizarRadicado.png"
                                OnClick="cmdActualizar_Click" ToolTip="Actualizar Registro" Width="36px" /></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Actualizar</td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:ImageButton ID="cmdCancel" runat="server" CausesValidation="False" Height="36px"
                                ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/cerrar.png" OnClick="cmdCancel_Click"
                                ToolTip="Cerrar" Width="36px" /></td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Cerrar</td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                <uc1:NavDocEnviado ID="NavDocEnviado1" runat="server" />
                        </td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlinkCarta" runat="server" target="_blank" 
                                NavigateUrl="~/AlfaNetDocumentos/DocEnviado/DocEnviadoDevPorNoCompetencia.aspx?Admon=S" 
                                ImageUrl="~/AlfaNetImagen/iconos/icono_txt.gif" Visible="False"
                                >
                                <asp:Image ID="ImgCartaPlantilla" runat="server" ImageUrl="~/AlfaNetImagen/iconos/icono_txt.gif"  />
                            </asp:HyperLink>
                        </td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        <asp:Label ID="lbCartaPlantilla" runat="server" Text="Carta de Plantilla" Visible="False"></asp:Label>
                        </td>
                        <td style="width: 41px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 20%">
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
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <contenttemplate>
<asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ControlLightLight"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 5%; HEIGHT: 24px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789"></asp:ImageButton> </TD></TR><TR><TD align=center colSpan=2><BR /><asp:Label id="LblMessageBox" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" TargetControlID="LblMessageBox" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                            </cc1:ModalPopupExtender> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
    <asp:ValidationSummary ID="ValidationSummaryRadicado" runat="server" DisplayMode="List"
        Font-Size="10pt" Style="vertical-align: middle; text-align: float"
        Width="100%" />
    <asp:Label ID="ExceptionDetails" runat="server" Width="100%" Font-Size="10pt" ForeColor="Red"></asp:Label><asp:ObjectDataSource ID="RadicadoDataSource" runat="server" UpdateMethod="AddRadicado"
        TypeName="RadicadoBLL" SelectMethod="GetGroupById" OldValuesParameterFormatString="original_{0}"
        InsertMethod="AddRadicado">
        <UpdateParameters>
            <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
            <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
            <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
            <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
            <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
            <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GroupDataSource" runat="server" UpdateMethod="UpdateGrupo"
        TypeName="GrupoBLL" SelectMethod="GetGrupoByID" OldValuesParameterFormatString="original_{0}"
        InsertMethod="AddGrupo" DeleteMethod="DeleteGrupo">
        <DeleteParameters>
            <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="GrupoCodigo" Type="String"></asp:Parameter>
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
            <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT [WFProcesoCodigo], [WFProcesoDescripcion], [WFProcesoHabilitar] FROM [WFProceso] WHERE ([WFProcesoHabilitar] = @WFProcesoHabilitar)">
        <SelectParameters>
            <asp:Parameter DefaultValue="S" Name="WFProcesoHabilitar" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
