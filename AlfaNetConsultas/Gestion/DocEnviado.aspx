<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="DocEnviado.aspx.cs" Inherits="_DocEnviado" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
    <%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
    <%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Import Namespace="System.Configuration" %>
<%--<%@ Register Src="../NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc1" %>
<%@ Register Src="NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="global">
    <script language="javascript" type="text/javascript">
// <!CDATA[
        // function url(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //            function urlInt(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //        //Respuesta
        //           function urlRpta(evt) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //        }
        //         //Visor de Imagenes Recibida
        //           function VImagenes(evt,NumeroDocumento) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //            
        //        }
        //        //Visor de Imagenes Enviada
        //           function VImagenesReg(evt,NumeroDocumento) 
        //        {
        //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        //            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        //
        //        }

        function url(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
             var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        function urlInt(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
             var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
        function urlRpta(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Recibida
        function VImagenes(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Visor de Imagenes Enviada
        function VImagenesReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function Historico(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        //Historico Recibida
        function HistoricoReg(evt, NumeroDocumento, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
         //Expediente
           function Expediente(evt,NumeroDocumento,Expediente,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }


        //// ]]>

    </script>

    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td style="text-align: center; height: 500px;">
                <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                    TransitionDuration="250" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Documentos Enviados.:</a>
                            </Header>
                            <Content>
                                <TABLE style="WIDTH: 100%; TEXT-ALIGN: left" 
forecolor="White"><TBODY><TR><TD 
style="WIDTH: 100%; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">Consulta de Correspondencia 
Enviada</TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 8px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBFechaReg" runat="server" Text="Entre Fechas de Registro" Width="185px"
                                                            AutoPostBack="True" OnCheckedChanged="ChBFechaRad_CheckedChanged"   />
                                                        <br   />
                                                        <cc1:CalendarExtender ID="CalendarFinal" runat="server" PopupButtonID="ImgCalendarFinal"
                                                            TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarInicial" runat="server" PopupButtonID="ImgCalendarInicial"
                                                            TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:Label ID="LblFechaInicial" runat="server" Text="Fecha Inicial" Width="70px"
                                                            Visible="False"></asp:Label>
                                                        <asp:TextBox ID="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarInicial" runat="server" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png"
                                                            Width="27px" Visible="False"   />
                                                        <asp:Label ID="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label>
                                                        <asp:TextBox ID="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarFinal" runat="server" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png"
                                                            Width="27px" Visible="False"   />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaReg" EventName="CheckedChanged"   />
                                                    </Triggers>
                                                </asp:UpdatePanel> 
</TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBNroReg" runat="server" Text="Entre Numeros de Registro" Width="181px"
                                                            OnCheckedChanged="ChBNroReg_CheckedChanged" AutoPostBack="True"   /><br   />
                                                        <asp:Label ID="LblNroRegInicial" runat="server" Text="Numero Registro Inicial" Visible="False"
                                                            Width="120px"></asp:Label><asp:TextBox ID="TxtNroRegInicial" runat="server" Font-Size="8pt"
                                                                Visible="False" Width="70px"></asp:TextBox><asp:Label ID="LblNroRegFinal" runat="server"
                                                                    Visible="False" Width="120px">Numero Registro Final</asp:Label><asp:TextBox ID="TxtNroRegFinal"
                                                                        runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBNroReg" EventName="CheckedChanged"   />
                                                    </Triggers>
                                                </asp:UpdatePanel> 
</TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb"><asp:UpdatePanel id="UpdatePanelDestino" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
<asp:CheckBox id="ChBDestino" runat="server" Width="377px" Text="Por Destinatario o Dependencia Destino ...(Seleccione o ingrese criterio)" OnCheckedChanged="ChBDestino_CheckedChanged" AutoPostBack="True"></asp:CheckBox> <cc1:PopupControlExtender id="PopupControlDestino" runat="server" PopupControlID="PnlDestino" TargetControlID="TxtBDestino" Position="Right">
                                                        </cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteDestino" runat="server" TargetControlID="TxtBDestino" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetDependenciaByTextnull" ServicePath="../../AutoComplete.asmx">
                                                        </cc1:AutoCompleteExtender> <asp:RadioButtonList id="RadioButtonList1" tabIndex=8 runat="server" Width="98px" Visible="false" Font-Size="8pt" ValidationGroup="1" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">Interno</asp:ListItem>
                                                            <asp:ListItem Value="0">Externo</asp:ListItem>
                                                        </asp:RadioButtonList> <asp:Label id="LblDestino" runat="server" Width="60px" Visible="False" Text="Destino"></asp:Label> <asp:TextBox id="TxtBDestino" runat="server" Width="400px" Visible="False" Font-Size="8pt" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel style="LEFT: 21px" id="PnlDestino" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVDependencia" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
                                                                    <ParentNodeStyle Font-Bold="False"   />
                                                                    <HoverNodeStyle Font-Underline="True"   />
                                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"   />
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                                                            Value="0"></asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                        NodeSpacing="0px" VerticalPadding="0px"   />
                                                                </asp:TreeView> <asp:TreeView id="TreeVProceso" runat="server" Visible="False" ShowLines="True" ExpandDepth="0">
                                                                    <ParentNodeStyle Font-Bold="False"   />
                                                                    <HoverNodeStyle Font-Underline="True"   />
                                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"   />
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Proceso..."
                                                                            Value="0"></asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                        NodeSpacing="0px" VerticalPadding="0px"   />
                                                                </asp:TreeView> </DIV></asp:Panel>
</ContentTemplate>
                                                    <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBDestino" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                                </asp:UpdatePanel> 
</TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UpdatePanelProcedencia" runat="server" Visible="False" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBProcedencia" runat="server" Width="114px" Text="Por Procedencia" OnCheckedChanged="ChBProcedencia_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR   /><asp:Label id="LblProcedencia" runat="server" Width="60px" Visible="False" Text="Procedencia"></asp:Label><cc1:AutoCompleteExtender id="AutoCompleteProcedencia" runat="server" TargetControlID="TxtBProcedencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombrenull" MinimumPrefixLength="1" CompletionSetCount="20"></cc1:AutoCompleteExtender> <asp:TextBox id="TxtBProcedencia" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelExpediente" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBExpediente" runat="server" Width="115px" Text="Por Expediente" OnCheckedChanged="ChBExpediente_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR   /><asp:Label id="LblExpediente" runat="server" Width="60px" Visible="False" Text="Procedencia"></asp:Label> <cc1:PopupControlExtender id="PopupControlExpediente" runat="server" PopupControlID="PnlExpediente" TargetControlID="TxtBExpediente" Position="Right">
                                                        </cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" TargetControlID="TxtBExpediente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetExpedienteByTextNombrenull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <asp:TextBox id="TxtBExpediente" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlExpediente" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVExpediente" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" OnSelectedNodeChanged="TreeVExpediente_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Expediente..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBExpediente" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UpdatePanelMedio" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBMedio" runat="server" Width="121px" Text="Por Medio de Envio" OnCheckedChanged="ChBMedio_CheckedChanged" AutoPostBack="True"></asp:CheckBox> <BR   /><asp:Label id="LblMedio" runat="server" Width="60px" Visible="False" Text="Medio"></asp:Label><cc1:PopupControlExtender id="PopupControlMedio" runat="server" PopupControlID="PnlMedio" TargetControlID="TxtBMedio" Position="Right">
                                                        </cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteMedio" runat="server" TargetControlID="TxtBMedio" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetMedioByTextNull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <asp:TextBox id="TxtBMedio" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlMedio" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVMedio" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVMedio_TreeNodePopulate" OnSelectedNodeChanged="TreeVMedio_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Medio..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBMedio" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 1px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelNaturaleza" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBNaturaleza" runat="server" Width="250px" Text="Por Naturaleza ...(Seleccione o ingrese criterio)" OnCheckedChanged="ChBNaturaleza_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR   /><asp:Label id="LblNaturaleza" runat="server" Width="60px" Visible="False" Text="Naturaleza"></asp:Label> <cc1:AutoCompleteExtender id="AutoCompleteNaturaleza" runat="server" TargetControlID="TxtBNaturaleza" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetNaturalezaByTextNull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlNaturaleza" runat="server" PopupControlID="PnlNaturaleza" TargetControlID="TxtBNaturaleza" Position="Right">
                                                        </cc1:PopupControlExtender> <asp:TextBox id="TxtBNaturaleza" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlNaturaleza" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVNaturaleza" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVNaturaleza_TreeNodePopulate" OnSelectedNodeChanged="TreeVNaturaleza_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Naturaleza..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBNaturaleza" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 1px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UpdatePanelRemite" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
<asp:CheckBox id="ChBRemite" runat="server" Width="300px" Text="Por Dependencia Remite ...(Seleccione o ingrese criterio)" OnCheckedChanged="ChBRemite_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR   /><asp:Label id="LblRemite" runat="server" Width="121px" Visible="False" Text="Dependencia que Remite"></asp:Label> <cc1:AutoCompleteExtender id="AutoCompleteRemite" runat="server" TargetControlID="TxtBRemite" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                        </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlRemite" runat="server" PopupControlID="PnlRemite" TargetControlID="TxtBRemite" Position="Right">
                                                        </cc1:PopupControlExtender> <asp:TextBox id="TxtBRemite" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlRemite" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVRemite" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVRemite_TreeNodePopulate" OnSelectedNodeChanged="TreeVRemite_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia que Remite..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> 
</ContentTemplate>
                                                    <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBRemite" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                                </asp:UpdatePanel> 
</TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 1px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelSerie" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBSerie" runat="server" Width="258px" Text="Por Archivado en" OnCheckedChanged="ChBSerie_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR   /><asp:Label id="LblSerie" runat="server" Width="109px" Visible="False" Text="Serie Documental"></asp:Label> <cc1:AutoCompleteExtender id="AutoCompleteSerie" runat="server" TargetControlID="TxtBSerie" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByTextNull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlSerie" runat="server" PopupControlID="PnlSerie" TargetControlID="TxtBSerie" Position="Right">
                                                        </cc1:PopupControlExtender> <asp:TextBox id="TxtBSerie" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlSerie" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVSerie" runat="server" Width="300px" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" OnSelectedNodeChanged="TreeVSerie_SelectedNodeChanged" ExpandDepth="0" ImageSet="XPFileExplorer" NodeIndent="15">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="False" BackColor="#B5B5B5"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBRemite" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="ChBOtros" runat="server" Text="Por Otros Detalles" Width="185px"
                                                                AutoPostBack="True" OnCheckedChanged="ChBOtros_CheckedChanged"   /><br   />
                                                            <asp:Label ID="LblBuscarPor" runat="server" Text="Buscar Por" Visible="False" Width="60px"></asp:Label>
                                                            <asp:DropDownList ID="DDLOtros" runat="server" Visible="False">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="Detalle">Detalle</asp:ListItem>
                                                                <asp:ListItem Value="Radicado">Radicado Fuente</asp:ListItem>
                                                                <asp:ListItem Value="Anexo">Anexo</asp:ListItem>
                                                                <asp:ListItem Value="NumerodeGuia">Número de Guía</asp:ListItem>
                                                            </asp:DropDownList><asp:TextBox ID="TxtBOtros" runat="server" Visible="False" Width="400px"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel> 
</TD></TR><TR><TD 
style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #507cd1" colSpan=3><TABLE style="WIDTH: 100%"><TBODY><TR><TD><asp:Table id="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                        <asp:TableRow ID="TableRow1" runat="server">
                                                            <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton"> <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                                    CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar"></asp:LinkButton></asp:TableCell>
                                                            <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton"> <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                    CssClass="CommandButton" OnClick="BtnNuevo_Click" com TabIndex="24" Text="Nueva Busqueda" CommandArgument="Select"></asp:LinkButton></asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table></TD><TD></TD><TD><asp:RadioButtonList id="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                            </asp:RadioButtonList></TD></TR></TBODY></TABLE> 
</TD></TR></TBODY></TABLE> 
                                
                                 
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                                <TABLE style="WIDTH: 100%; HEIGHT: 100%">
                                <TBODY>
                                <TR>
                                <TD><dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server">
</dxwgv:ASPxGridViewExporter> <TABLE class="style1"><TBODY><TR><TD><dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/"><Items>
<dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
<dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
<dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
<dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
</Items>

<ButtonStyle Width="13px"></ButtonStyle>
</dxe:ASPxComboBox> </TD><TD><dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> 
</TD><TD style="WIDTH: 65px"><dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                    </dxe:ASPxButton> 
</TD></TR></TBODY></TABLE>
<asp:UpdatePanel id="UpdatePanel10" runat="server"><ContentTemplate>
<dxwgv:ASPxGridView id="ASPxGridView1" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RegistroCodigo" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
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

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewCommandColumn VisibleIndex="0">
<ClearFilterButton Visible="True"></ClearFilterButton>
</dxwgv:GridViewCommandColumn>
<dxwgv:GridViewDataTextColumn FieldName="RegistroCodigo" Caption="Registro" VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("RegistroCodigo") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Registro" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Destino" Caption="Destino" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RegistroDetalle" Width="200px" Caption="Detalle" VisibleIndex="4">
<PropertiesTextEdit>
<ValidationSettings Display="Dynamic"></ValidationSettings>
</PropertiesTextEdit>

<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Caption="Naturaleza" VisibleIndex="5">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="MedioNombre" Caption="Medio" VisibleIndex="6">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" Caption="Expediente" VisibleIndex="7">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieNombre" Caption="Serie" VisibleIndex="8"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Opciones" UnboundType="String" Caption="Opciones" VisibleIndex="9">
<Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLinkVisor" runat="server" Text="Imágenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink><BR /><asp:HyperLink id="HprLnkHisExtven" runat="server" Width="55px" Font-Underline="True" CssClass="LinKBtnStyleBig">Histórico</asp:HyperLink><BR /><asp:HyperLink id="HprLnkExp" runat="server" Text="Expediente" CssClass="LinKBtnStyleBig" Target="_blank"></asp:HyperLink> <asp:HiddenField id="HFExp" runat="server" Value='<%# Eval("ExpedienteCodigo") %>'></asp:HiddenField> <asp:HiddenField id="HFGrupo" runat="server" Value='<%# Eval("GrupoCodigo") %>'></asp:HiddenField>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:ASPxGridView> 
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD></TR></TBODY></TABLE>
                            </Content>
                        </cc1:AccordionPane>
                         <cc1:AccordionPane ID="AccordionPane3" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Reporte.:</a>
                            </Header>
                            <Content>
                               
                <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="400px" Width="100%">
                    <LocalReport ReportPath="AlfaNetConsultas\Gestion\DocEnviado.rdlc" EnableExternalImages="true">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ODSBuscar" Name="DSRegistro_Registro_ConsultasRegistro" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                            </Content>
                        </cc1:AccordionPane>
                        
                    </Panes>
                </cc1:Accordion>
                <asp:ObjectDataSource ID="ODSBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetConsultasRegistro" TypeName="RegistroBLL" InsertMethod="CopiasRegistro" UpdateMethod="UpdateRegistro">
                    <SelectParameters>
                        <asp:Parameter Name="RegistroTipo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="RegistroCodigo" Type="String" />
                        <asp:Parameter Name="RegistroCodigo1" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter DefaultValue="" Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="RegistroDetalle" Type="String" />
                        <asp:Parameter Name="AnexoExtRegistro" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaNombre" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="RemiteNombre" Type="String" />
                        <asp:Parameter Name="DestinoNombre" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
                        <asp:Parameter Name="RegistroGuia" Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodDestino" Type="String" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                        <asp:Parameter Name="WFMovimientoNotas" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="RegistroCodigo" Type="String" />
                        <asp:Parameter Name="Grupo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                        <asp:Parameter Name="WFMovimientoMultitarea" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RegistroCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                        <asp:Parameter Name="ProcedenciaCodDestino" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="Int32" />
                        <asp:Parameter Name="RegistroDetalle" Type="String" />
                        <asp:Parameter Name="RegistroGuia" Type="String" />
                        <asp:Parameter Name="RegPesoEnvio" Type="String" />
                        <asp:Parameter Name="RegistroEmpGuia" Type="String" />
                        <asp:Parameter Name="AnexoExtRegistro" Type="String" />
                        <asp:Parameter Name="LogDigitador" Type="String" />
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="RegValorEnvio" Type="String" />
                        <asp:Parameter Name="RegistroTipo" Type="String" />
                        <asp:Parameter Name="Original_RegistroCodigo" Type="String" />
                        <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="CodigoMotDevolucion" Type="String" />
                        <asp:Parameter Name="FechaDevolucion" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="100%"></asp:Label>
                <asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                    runat="server" Width="100%" Height="1px" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
  </div>  
</asp:Content>
