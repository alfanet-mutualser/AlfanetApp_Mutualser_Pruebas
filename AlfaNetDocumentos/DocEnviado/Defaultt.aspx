<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Defaultt.aspx.cs" Inherits="_Defaultt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="global">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr style="background-color: white">
                    <td style="vertical-align: top;">
                                <asp:UpdatePanel id="UpdatePanel3" runat="server" Visible="False">
                                    <contenttemplate>
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="LblPara" runat="server" Width="125px" Text="* Para:" Font-Bold="False" CssClass="LabelStyle" __designer:wfdid="w2"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="txtJobTitle" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" __designer:wfdid="w3" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel id="UpdatePanel4" runat="server" Visible="False">
                                    <contenttemplate>
                                   
            
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="LblDireccion" runat="server" Width="125px" Font-Bold="False" Text="Direccion:" __designer:wfdid="w5" CssClass="LabelStyle"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="txtAddressLine1" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" __designer:wfdid="w6"></asp:TextBox></TD></TR></TBODY></TABLE>
   
</contenttemplate>

                                </asp:UpdatePanel>
                                <asp:UpdatePanel id="UpdatePanel5" runat="server" Visible="False">
                                   
                                    <contenttemplate>
                                    
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="LblCiudad" runat="server" Width="125px" Font-Bold="False" Text="Ciudad:" __designer:wfdid="w8" CssClass="LabelStyle"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="txtAddressLine2" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" __designer:wfdid="w9"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                                </asp:UpdatePanel>
                        <asp:UpdatePanel id="UpdatePanel100" runat="server">
                            <contenttemplate>
<asp:Panel style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white" id="PnlMensaje" runat="server"><TABLE><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ValidationGroup="789" ImageAlign="Right"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align=center colSpan=2><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label></TD></TR></TABLE></asp:Panel> <cc1:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></cc1:ModalPopupExtender> 
</contenttemplate>
                        </asp:UpdatePanel>
                        <asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" CssClass="lnkbtn">Generar Cartas</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="lnkbtn">Imprimir Cartas</asp:LinkButton></td>
           
                </tr>                
                <tr style="background-color: white">
                    <td colspan="1" style="vertical-align: top; font-weight: bolder; color: silver; font-family: Tahoma, Arial, sans-serif; width: 700px; left: 1%; top: 1%;">
                       <div>
                        <cc1:Accordion ID="AccordionFuente" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                                FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                                HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="0"
                                SuppressHeaderPostbacks="true" TransitionDuration="250" Width="100%">
                           <Panes>
                                <cc1:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass=""  HeaderCssClass="">
                                        <Header>
                                            <a class="accordionLink" href="">Informacion de Carta Respuesta.:</a>
                                        
</Header>
                                        <Content>
                                         <TABLE style="FONT-SIZE: 10pt; WIDTH: 100%"><TBODY><TR><TD align=center><TABLE style="BACKGROUND-COLOR: ghostwhite"><TBODY><TR><TD style="WIDTH: 557px; TEXT-ALIGN: left">CARTA DE RESPUESTA A RADICADO </TD></TR><TR><TD style="WIDTH: 557px; TEXT-ALIGN: left"><asp:UpdatePanel id="UpdatePanel20" runat="server"><ContentTemplate>
<TABLE><TBODY><TR><TD></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Width="126px" Text="Grupo a consultar:" Font-Bold="True" CssClass="PropLabels" Font-Italic="False">
</asp:Label></TD><TD vAlign=top align=left><asp:UpdatePanel id="Updatepanel1000" runat="server"><ContentTemplate>
<asp:DropDownList id="DropDownListGrupo" runat="server" Width="103px" CssClass="TxtProp" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged" AutoPostBack="true">
</asp:DropDownList> 
</ContentTemplate>
</asp:UpdatePanel></TD><TD vAlign=top align=left>&nbsp;</TD></TR><TR><asp:RequiredFieldValidator id="RFVRemite" runat="server" ControlToValidate="txtPhone" ErrorMessage="Debe Seleccionar una Remitente">*</asp:RequiredFieldValidator><TD><asp:Label id="LblRemite" runat="server" Width="125px" Text="Remite:" Font-Bold="False" CssClass="LabelStyle">
</asp:Label> </TD><TD><asp:TextBox id="txtPhone" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> <cc1:AutoCompleteExtender id="ACERemitente" runat="server" TargetControlID="txtPhone" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0">
                                    </cc1:AutoCompleteExtender> <asp:Panel id="Panel84" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical">
                                    <DIV><asp:TreeView id="TreeVRemite" runat="server" ExpandDepth="0" ImageSet="Simple2" OnTreeNodePopulate="TreeVDestino_TreeNodePopulate" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="False"  />
                                                        <HoverNodeStyle  Font-Underline="True"  />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"  />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione..."
                                                                Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px"  />
                                                    </asp:TreeView> </DIV></asp:Panel> <cc1:PopupControlExtender id="PopCRemite" runat="server" PopupControlID="Panel84" TargetControlID="ImgFindRemite" Position="Bottom" CommitScript="e.value;" CommitProperty="value">
                                            </cc1:PopupControlExtender> </TD><TD style="WIDTH: 3px"><asp:Image id="ImgFindRemite" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" Height="15px"></asp:Image></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> 
<HR />
</TD></TR><TR><TD 
style="WIDTH: 557px; TEXT-ALIGN: left"><asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="WIDTH: 3px"><asp:RequiredFieldValidator id="RFVDestino" runat="server" ControlToValidate="txtFullName" ErrorMessage="Debe Seleccionar Destinos">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblDestino" runat="server" Width="125px" Font-Bold="False" Text="Destino:" CssClass="LabelStyle">
</asp:Label> <asp:RadioButtonList id="RadioButtonList1" tabIndex=8 runat="server" Font-Size="Smaller" ForeColor="RoyalBlue" ValidationGroup="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Interno</asp:ListItem>
<asp:ListItem Value="0">Externo</asp:ListItem>
</asp:RadioButtonList> </TD><TD><asp:TextBox id="txtFullName" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Image id="ImgFindDestino" runat="server" Width="15px" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> <asp:Panel id="Paneldep" runat="server" Visible="False" DefaultButton="ImgBtnAdd"><TABLE style="WIDTH: 270px"><TBODY><TR><TD style="WIDTH: 359px"><asp:ListBox id="ListBoxEnterar" runat="server" Width="350px">
                                                                                                    </asp:ListBox> <asp:RadioButtonList id="RBEnterarA" tabIndex=8 runat="server" Width="348px" Font-Size="8pt" Visible="False" ValidationGroup="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBEnterarA_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Dependencias Individuales</asp:ListItem>
<asp:ListItem Value="T">Todas Las Dependencias</asp:ListItem>

</asp:RadioButtonList> </TD><TD style="WIDTH: 359px"><asp:ImageButton id="ImgBtnAdd" tabIndex=26 onclick="ImgBtnAdd_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" ValidationGroup="Enterar" ToolTip="Agregar Dependencia" Enabled="True">
                                                                                                    </asp:ImageButton> <asp:ImageButton id="ImgBtnDelete" tabIndex=26 onclick="ImgBtnDelete_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" ValidationGroup="Enterar" ToolTip="Eliminar Dependencia" Enabled="True" CausesValidation="False">
                                                                                                    </asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <cc1:PopupControlExtender id="PopCDestino" runat="server" TargetControlID="ImgFindDestino" Position="Bottom" PopupControlID="PnlDestino" CommitScript="e.text;" CommitProperty="text">
                                                </cc1:PopupControlExtender> <cc1:autocompleteextender id="ACEDestino" runat="server" targetcontrolid="txtFullName" servicepath="../../AutoComplete.asmx" servicemethod="GetDependenciaByText" minimumprefixlength="0" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
</cc1:autocompleteextender> <asp:Panel id="PnlDestino" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVDestino" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVDestino_TreeNodePopulate" ImageSet="Simple2" ExpandDepth="0" ShowCheckBoxes="All">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False" Text="Seleccione Dependencias Destino..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel></TD><TD></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="RadioButtonList1"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ImgBtnAdd"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ImgBtnDelete"></asp:PostBackTrigger>
</Triggers>
</asp:UpdatePanel> 
<HR />
</TD></TR><TR><TD style="TEXT-ALIGN: left" 
colSpan=2><asp:UpdatePanel id="UpdatePanel60" runat="server"><ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 3px"><asp:RequiredFieldValidator id="RFVTextoCarta" runat="server" ErrorMessage="Debe Escribir un Texto para la carta" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblDetalle" runat="server" Width="125px" Font-Bold="False" Text="Carta:" CssClass="LabelStyle"></asp:Label></TD><TD colSpan=1><asp:TextBox id="txtEmail" runat="server" Width="350px" Font-Names="Tahoma" Font-Size="8pt" TextMode="MultiLine" Height="100px"></asp:TextBox></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
                                        
</Content>
                                    </cc1:AccordionPane>
                                  
                                    <cc1:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass=""  HeaderCssClass="">
                                        <Header>
                                            <a class="accordionLink" href="">Informacion de Registro.:</a>
                                        
</Header>
                                        <Content>
            
                                        <TABLE style="WIDTH: 100%"><TBODY><TR><TD 
style="TEXT-ALIGN: center"><TABLE 
style="WIDTH: 88%" bgColor=ghostwhite><TBODY><TR><TD 
style="WIDTH: 13px"></TD><TD 
style="TEXT-ALIGN: left" colSpan=2><asp:Label id="LblFechaRadicacion" runat="server" Width="155px" Font-Bold="False" Text="Fecha  y Hora de Registro" CssClass="LabelStyle"></asp:Label> 
<asp:TextBox style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" id="DateFechaRad" tabIndex=-1 runat="server" Width="255px" BackColor="LightGray" Font-Size="8pt" ReadOnly="True">
</asp:TextBox> </TD></TR><TR><TD 
style="WIDTH: 13px"></TD><TD 
style="TEXT-ALIGN: left" colSpan=2><%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">--%><%--<ContentTemplate>--%><TABLE 
style="WIDTH: 100%; HEIGHT: 39%"><TBODY><TR><TD 
style="WIDTH: 158px"><asp:Label id="LblRadFuente" runat="server" Width="155px" Font-Bold="False" Text="Radicacion Fuente.:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:Accordion id="Accordion1" runat="server" Width="470" TransitionDuration="250" SuppressHeaderPostbacks="true" SelectedIndex="-1" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected" HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false" ContentCssClass="accordionContent" AutoSize="None">
                                                        <Panes>
                                                            <cc1:AccordionPane ID="AccordionPaneFuente" runat="server" ContentCssClass="" HeaderCssClass="">
                                                                <Header>
                                                                    <a class="accordionLink" href="">RadicadoFuente.:</a>
                                                                </Header>
                                                                <Content>
                                                                <asp:UpdatePanel id="UPFuente" runat="server"><ContentTemplate>
<asp:Panel id="PnlFuente" runat="server" DefaultButton="ImgBtnAddFuente">
<asp:RequiredFieldValidator id="RFVFuente" runat="server" ValidationGroup="Fuente" ErrorMessage="Seleccione la Radicado Fuente" ControlToValidate="TxtRadFuente" SetFocusOnError="True" Enabled="true">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Seleccione el Radicado Fuente" ControlToValidate="ListBoxFuente" SetFocusOnError="True" Enabled="False">*</asp:RequiredFieldValidator><asp:Label id="LblFuente" runat="server" Width="155px" Font-Bold="False" Text="Radicado Fuente.:" CssClass="LabelStyle"></asp:Label> 
<TABLE style="WIDTH: 250px"><TBODY>
 <tr>
 <td  >
<table>
<tr>
<td>
<asp:Label ID="LblGrupoRadicadoFuente" runat="server" CssClass="LabelStyle" Font-Bold="False"  Text="Grupo Fuente" Width="100px"></asp:Label>
</td>
<td>
<asp:UpdatePanel runat="server" ID="Updatepanel600">
<ContentTemplate>
<asp:DropDownList ID="DropDownListGrupoFuente" runat="server" 
Width="103px" CssClass="TxtProp" AutoPostBack="true" 
OnSelectedIndexChanged="DropDownListGrupoFuente_SelectedIndexChanged" >
</asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
</td>
</tr>
</table> 
</td>

<td>
</td>
</tr>
<TR><TD>
<cc1:TextBoxWatermarkExtender id="WatermarkRadFuente" watermarkText="Seleccione una Radicado Fuente..." runat="server" TargetControlID="TxtRadFuente">
                                                                </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteRadFuente" runat="server" TargetControlID="TxtRadFuente" MinimumPrefixLength="1" ServiceMethod="GetRadicadoByCodigo" ServicePath="../../AutoComplete.asmx">
                                                                </cc1:AutoCompleteExtender> <asp:Label id="Label1" runat="server" Width="14px"></asp:Label><asp:TextBox id="TxtRadFuente" tabIndex=12 runat="server" Width="350px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD><asp:ImageButton id="ImgBtnAddFuente" tabIndex=26 onclick="ImgBtnAddFuente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" ValidationGroup="Fuente" ToolTip="Agregar Radicado Fuente" Enabled="True">
 </asp:ImageButton> <asp:ImageButton id="ImgBtnDeleteFuente" tabIndex=26 onclick="ImgBtnDeleteFuente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" ToolTip="Eliminar Radicado Fuente" Enabled="True" CauseValidation="False">
 </asp:ImageButton> </TD></TR><TR><TD><asp:ListBox id="ListBoxFuente" runat="server" Width="350px" CausesValidation="True" DataValueField="RadicadoCodigoFuente" DataTextField="RadicadoCodigoFuente"></asp:ListBox> <asp:RadioButtonList id="RBFuente" tabIndex=8 runat="server" Width="350px" Font-Size="8pt" Visible="False" ValidationGroup="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBFuente_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Fuentes Individuales</asp:ListItem>
<asp:ListItem Value="T">Todas Las Fuentes</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel>
                                                                </Content>
                                                            </cc1:AccordionPane>
                                                        </Panes>
                                                    </cc1:Accordion> 
</TD></TR></TBODY></TABLE><%--</ContentTemplate>--%><%-- <Triggers>
                                                                  <asp:AsyncPostBackTrigger ControlID="LinkButton3" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%></TD></TR><TR><TD style="WIDTH: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" Width="7px" Height="15px" ErrorMessage="Debe ingresar la Naturaleza" ControlToValidate="TxtNaturaleza" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD 
style="TEXT-ALIGN: left" colSpan=2><asp:UpdatePanel id="UpdatePanel10" runat="server">
                <contenttemplate>
<TABLE style="WIDTH: 270px; HEIGHT: 19px"><TR><TD><asp:Label id="LblNaturaleza" runat="server" Width="155px" Font-Bold="False" Text="Naturaleza Documento.:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteNatulezaDoc" runat="server" TargetControlID="TxtNaturaleza" MinimumPrefixLength="0" ServiceMethod="GetNaturalezaByText" ServicePath="../../AutoComplete.asmx" CompletionInterval="100" UseContextKey="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCENaturaleza" runat="server" TargetControlID="ImgTreeNaturaleza" PopupControlID="PnlTreeNaturaleza">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtNaturaleza" tabIndex=16 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 19px"><asp:Image id="ImgTreeNaturaleza" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image><asp:Panel style="LEFT: 707px; TOP: 1007px" id="PnlTreeNaturaleza" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVNaturaleza" runat="server" ExpandDepth="0" ImageSet="Simple2" OnTreeNodePopulate="TreeVNaturaleza_TreeNodePopulate" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="False" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                                Text="Seleccione..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 19px"><asp:ImageButton id="ImageButton7" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Height="15px" CausesValidation="False" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroNaturaleza.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ToolTip="Nueva Naturaleza"></asp:ImageButton></TD></TR></TABLE>
</contenttemplate>
            </asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="7px" Height="15px" ErrorMessage="Debe ingresar el Medio" ControlToValidate="TxtMedioRecibo" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD 
style="TEXT-ALIGN: left" colSpan=2><%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>--%><%--</ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnMedio1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnMedio2" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%><asp:UpdatePanel id="UpdatePanel2" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="LblMedioRecibo" runat="server" Width="155px" Font-Bold="False" Text="Medio de Recibo.:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteMedioRecibo" runat="server" TargetControlID="TxtMedioRecibo" MinimumPrefixLength="0" ServiceMethod="GetMedioByText" ServicePath="../../AutoComplete.asmx" CompletionInterval="100" UseContextKey="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEMedio" runat="server" TargetControlID="ImgTreeMedio" PopupControlID="PnlTreeMedio">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtMedioRecibo" tabIndex=18 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 19px"><asp:Panel style="LEFT: 707px; TOP: 1149px" id="PnlTreeMedio" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVMedio" runat="server" ExpandDepth="0" ImageSet="Simple2" OnTreeNodePopulate="TreeVMedio_TreeNodePopulate" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="False" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                                Text="Seleccione..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView> </DIV></asp:Panel> <asp:Image id="ImgTreeMedio" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image></TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton8" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Height="15px" CausesValidation="False" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroMedio.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ToolTip="Nuevo Medio"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Width="7px" Height="15px" ErrorMessage="Debe ingresar el Expediente" ControlToValidate="TxtExpediente" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD 
style="TEXT-ALIGN: left" colSpan=2><%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>--%><%-- </ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnExpediente1" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LBtnExpediente2" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%><asp:UpdatePanel id="UpdatePanel6" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="LblExpediente" runat="server" Width="155px" Font-Bold="False" Text="Expediente.:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" TargetControlID="TxtExpediente" MinimumPrefixLength="0" ServiceMethod="GetExpedienteByTextNombre" ServicePath="../../AutoComplete.asmx" CompletionInterval="100" UseContextKey="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCEExpediente" runat="server" TargetControlID="ImgTreeExpediente" PopupControlID="PnlTreeExpediente">
                                            </cc1:PopupControlExtender> <asp:TextBox id="TxtExpediente" tabIndex=21 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD><asp:Image id="ImgTreeExpediente" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image><asp:Panel style="LEFT: 707px; TOP: 1384px" id="PnlTreeExpediente" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVExpediente" runat="server" ExpandDepth="0" ImageSet="Simple2" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" ShowLines="True">
                                                        <ParentNodeStyle Font-Bold="False" />
                                                        <HoverNodeStyle Font-Underline="True" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                        <Nodes>
                                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" ShowCheckBox="False"
                                                                Text="Seleccione..." Value="0"></asp:TreeNode>
                                                        </Nodes>
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                    </asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton9" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" Height="15px" CausesValidation="False" OnClientClick="hidden = open('../../AlfaNetAdministracion/AdminMaestros/MaestroExpediente.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes'); " ToolTip="Nuevo Expediente"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 13px; HEIGHT: 5px">
<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" Width="7px" Height="15px" ErrorMessage="Debe ingresar Serie" ControlToValidate="TextBox1" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD 
style="TEXT-ALIGN: left" colSpan=2>
<%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                    <ContentTemplate>--%><%--</ContentTemplate>
                                                                    <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="LinkButton4" EventName="Click" />
                                                                 <asp:AsyncPostBackTrigger ControlID="LinkButton5" EventName="Click" />
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%><TABLE 
style="WIDTH: 270px"><TBODY><TR><TD><asp:Label id="Label2" runat="server" Width="155px" Font-Bold="False" Text="Archivar En.:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TextBox1" MinimumPrefixLength="0" ServiceMethod="GetSerieByText" ServicePath="../../AutoComplete.asmx" CompletionInterval="100" UseContextKey="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender> 
<cc1:PopupControlExtender id="PCETreeCargar" runat="server" TargetControlID="ImgFindCargar" CommitProperty="value" CommitScript="e.value += ' - SEND A MEETING REQUEST!';" PopupControlID="Panel88" Position="Left" BehaviorID="PopupControlExtender1">
                                                    </cc1:PopupControlExtender> 
<asp:TextBox id="TextBox1" tabIndex=21 runat="server" Width="424px" CssClass="TxtAutoComplete"></asp:TextBox> 
</TD><TD style="WIDTH: 35px"><asp:Panel id="Panel88" runat="server" Width="350px" CssClass="popupControl" Height="300px" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True">
                                                                <ParentNodeStyle Font-Bold="False"       />
                                                                <HoverNodeStyle Font-Underline="True"       />
                                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"       />
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..."
                                                                        Value="0"></asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px"       />
                                                            </asp:TreeView> &nbsp; </DIV></asp:Panel> 
<asp:Image id="ImgFindCargar" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" Height="15px"></asp:Image> 
</TD><TD style="WIDTH: 3px"></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
                                
</Content>
                                    </cc1:AccordionPane>
                                
                                    <cc1:AccordionPane ID="AccordionPaneCarta" runat="server" ContentCssClass=""  HeaderCssClass="">
                                        <Header>
                                            <a class="accordionLink" href="">Modelo Carta Respuesta.:</a>
                                        
</Header>
                                        <Content>
                                         <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD align=center>PRESENTACION PREVIA DE CARTA DE RESPUESTA 
No. <BR />
<asp:Image id="imgCardPreview" runat="server" ></asp:Image></TD></TR></TBODY></TABLE>
                                        
</Content>
                                    </cc1:AccordionPane>
                                    </Panes>
                            </cc1:Accordion>
                           &nbsp;</div>
                    </td>
                </tr>
                <tr style="background-color: white">
                    <td colspan="1" style="font-weight: bolder; vertical-align: top; color: silver; font-family: Tahoma, Arial, sans-serif;
                        text-align: left; font-size: 10pt;">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="100%" />

    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
        Width="100%"></asp:Label></td>
                </tr>
            </table>
  <script type="text/jscript" language="javascript"> 
  
 function OnCheckBoxCheckChanged(evt,Control) 
 { 
        var src = window.event != window.undefined ? window.event.srcElement : evt.target; 
        var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
         var nodeClick = src.tagName.toLowerCase() == "a";    
        if (isChkBoxClick) { 
           Control.innerText = "Multiple";  
           }
         if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
         var nodeText = src.innerText || src.innerHTML;        
         var nodeText = document.getElementById("<%=txtFullName.ClientID%>");
         nodeText.innerText = src.innerText;
         }
            
    } 

          function OnTreeClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           //var nodeValue = GetNodeValue(src);        
           //alert("Text: " + nodeText + "," + "Value: " + nodeValue);
           var nodeText = document.getElementById("<%=txtPhone.ClientID%>");
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
        
    
             //Set the HTTP Handler for Business Car Generation        
        var imageGenerator = "BusinessCardGen.ashx";
        //First time card image load
        updateImageCard();
        
        //Set textbox handlers        
        $addHandler(document.getElementById("<%=txtFullName.ClientID%>"), "keyup", textBox_KeyUp);
//        $addHandler(document.getElementById("<%=txtJobTitle.ClientID%>"), "keyup", textBox_KeyUp);
//        $addHandler(document.getElementById("<%=txtAddressLine1.ClientID%>"), "keyup", textBox_KeyUp);
//        $addHandler(document.getElementById("<%=txtAddressLine2.ClientID%>"), "keyup", textBox_KeyUp);
        $addHandler(document.getElementById("<%=txtPhone.ClientID%>"), "keyup", textBox_KeyUp);
        $addHandler(document.getElementById("<%=txtEmail.ClientID%>"), "keyup", textBox_KeyUp);
    
        //Textbox KeyUp handler
        function textBox_KeyUp() 
        {
            updateImageCard();    
        }
        
        //Update image without postback
        function updateImageCard()
        {            
//            //Create URL for image generation
            //var imageUrl = imageGenerator + "?fullname=" + encodeURIComponent(document.getElementById("<%=txtFullName.ClientID%>").value)+ "&jobtitle=" + encodeURIComponent(document.getElementById("<%=txtJobTitle.ClientID%>").value) + "&addressline1=" + encodeURIComponent(document.getElementById("<%=txtAddressLine1.ClientID%>").value) + "&addressline2=" + encodeURIComponent(document.getElementById("<%=txtAddressLine2.ClientID%>").value) + "&phone=" + encodeURIComponent(document.getElementById("<%=txtPhone.ClientID%>").value) + "&email=" + encodeURIComponent(document.getElementById("<%=txtEmail.ClientID%>").value);
            var imageUrl = imageGenerator + "?fullname=" +  encodeURIComponent(document.getElementById("<%=txtFullName.ClientID%>").value)+"&phone=" + encodeURIComponent(document.getElementById("<%=txtPhone.ClientID%>").value) + "&email=" + encodeURIComponent(document.getElementById("<%=txtEmail.ClientID%>").value);
//            //Avoid client image caching
            var now = new Date();
            var id = "&id=" + now.getTime() + now.getMilliseconds();
//            
//            //Set URL to Preview Image control
            document.getElementById('<%=imgCardPreview.ClientID%>').src = imageUrl + id;                   
        }
         </script>
                      </div>
</asp:Content>