<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DocRecibido.aspx.cs" Inherits="AlfaNetConsultas_Gestion_DocRecibido" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentDocRecibido" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">

        function url(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        function urlInt(evt, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
        function urlRpta(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S&RptaImg=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
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
        function Expediente(evt, NumeroDocumento, Expediente, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }

        function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
        }
        function popup_Shown(s, e) {
            callbackPanel.AdjustControl();
        }
    </script>
    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td>
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                        SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                        HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                        ContentCssClass="accordionContent" AutoSize="None">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">
                                    Documentos Recibidos.:
                                </a>
                            </Header>
                            <Content>
                                <table style="WIDTH: 100%; TEXT-ALIGN: left" forecolor="White">
                                    <tbody>
                                        <tr>
                                            <td style="WIDTH: 489px; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">
                                                Consulta de Correspondencia Recibida
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 8px; BACKGROUND-COLOR: #eff3fb" colspan="3">
                                                <asp:UpdatePanel id="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBFechaRad" runat="server" Width="185px" Text="Entre Fechas de Radicacion" 
                                                                OnCheckedChanged="ChBFechaRad_CheckedChanged" AutoPostBack="True">
                                                        </asp:CheckBox>
                                                        <br />
                                                        <cc1:CalendarExtender id="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" 
                                                                Format="yyyy/MM/dd" PopupButtonID="ImgCalendarFinal">
                                                        </cc1:CalendarExtender>
                                                        <cc1:CalendarExtender id="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" 
                                                                Format="yyyy/MM/dd" PopupButtonID="ImgCalendarInicial">
                                                        </cc1:CalendarExtender>
                                                        <asp:Label id="LblFechaInicial" runat="server" Width="70px" Text="Fecha Inicial" Visible="False">
                                                        </asp:Label>
                                                        <asp:TextBox id="TxtFechaInicial" contenteditable="false" runat="server" Width="70px" Font-Size="8pt" Visible="False">
                                                        </asp:TextBox>
                                                        <asp:Image id="ImgCalendarInicial" runat="server" Width="27px" Height="20px" 
                                                                ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False">
                                                        </asp:Image>
                                                        <asp:Label id="LblFechaFinal" runat="server" Width="70px" Visible="False">
                                                            FechaFinal
                                                        </asp:Label>
                                                        <asp:TextBox id="TxtFechaFinal" runat="server" Width="70px" contenteditable="false" Font-Size="8pt" Visible="False">
                                                        </asp:TextBox>
                                                        <asp:Image id="ImgCalendarFinal" runat="server" Width="27px" Height="20px" 
                                                                ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False">
                                                        </asp:Image> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                                <asp:UpdatePanel id="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBNroRad" runat="server" Text="Entre Numeros de Radicacion" Width="181px"
                                                                OnCheckedChanged="ChBNroRad_CheckedChanged" AutoPostBack="True"   />
                                                        <br   />
                                                        <asp:Label ID="LblNroRadInicial" runat="server" Text="Numero Radicado Inicial" Visible="False"
                                                                Width="120px">
                                                        </asp:Label>
                                                        <asp:TextBox ID="TxtNroRadInicial" runat="server" Font-Size="8pt"
                                                                Visible="False" Width="70px">
                                                        </asp:TextBox>
                                                        <asp:Label ID="LblNroRadFinal" runat="server"
                                                                Visible="False" Width="120px">
                                                            Numero Radicado Final
                                                        </asp:Label>
                                                        <asp:TextBox ID="TxtNroRadFinal" runat="server" Font-Size="8pt" Visible="False" Width="70px">
                                                        </asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBNroRad" EventName="CheckedChanged"   />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb">
                                                <asp:UpdatePanel id="UpdatePanelDestino" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBDestino" runat="server" Width="300px" Text="Por Destino ...(Seleccione o ingrese criterio)" 
                                                                AutoPostBack="True" OnCheckedChanged="ChBDestino_CheckedChanged">
                                                        </asp:CheckBox>
                                                        <br   />
                                                        <asp:Label id="LblDestino" runat="server" Width="60px" Visible="False" Text="Destino">
                                                        </asp:Label>
                                                        <cc1:PopupControlExtender id="PopupControlDestino" runat="server" PopupControlID="PnlDestino" 
                                                                TargetControlID="TxtBDestino" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteDestino" runat="server" TargetControlID="TxtBDestino" 
                                                                ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" 
                                                                MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" 
                                                                CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:TextBox id="TxtBDestino" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                        </asp:TextBox>
                                                        <asp:Panel id="PnlDestino" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView id="TreeVDependencia" runat="server" Width="300px" ShowLines="True" 
                                                                        OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" 
                                                                        OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>
                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>
                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Dependencia..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" 
                                                                            Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                                <asp:TreeView id="TreeVSerie" runat="server" Width="300px" Visible="False" ShowLines="True" ExpandDepth="0">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Serie..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>

                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" 
                                                                            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                                <asp:TreeView id="TreeVProceso" runat="server" Width="300px" Visible="False" ShowLines="True" ExpandDepth="0">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Proceso..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>

                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" 
                                                                            Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBDestino" EventName="CheckedChanged">
                                                        </asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                                <asp:UpdatePanel id="UpdatePanelProcedencia" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBProcedencia" runat="server" Width="300px" 
                                                                Text="Por Procedencia ...(Seleccione o ingrese criterio)" 
                                                                AutoPostBack="True" OnCheckedChanged="ChBProcedencia_CheckedChanged">
                                                        </asp:CheckBox>
                                                        <br />
                                                        <asp:Label id="LblProcedencia" runat="server" Width="60px" Visible="False" Text="Procedencia">
                                                        </asp:Label>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteProcedencia" runat="server" TargetControlID="TxtBProcedencia" 
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                                                CompletionListItemCssClass="autocomplete_listItem " 
                                                                CompletionListCssClass="autocomplete_completionListElement" CompletionSetCount="20" 
                                                                MinimumPrefixLength="1" ServiceMethod="GetProcedenciaByTextNombreNull" 
                                                                ServicePath="../../AutoComplete.asmx">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:TextBox id="TxtBProcedencia" runat="server" Width="400px" Font-Size="8pt" 
                                                                Visible="False" CssClass="TxtAutoComplete">
                                                        </asp:TextBox> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged">
                                                        </asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colspan="3">
                                                <asp:UpdatePanel id="UpdatePanelExpediente" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBExpediente" runat="server" Width="185px" Text="Por Expediente" 
                                                                AutoPostBack="True" OnCheckedChanged="ChBExpediente_CheckedChanged">
                                                        </asp:CheckBox>
                                                        <br/>
                                                        <asp:Label id="LblExpediente" runat="server" Width="60px" Visible="False" Text="Procedencia">
                                                        </asp:Label>
                                                        <cc1:PopupControlExtender id="PopupControlExpediente" runat="server" PopupControlID="PnlExpediente" 
                                                                TargetControlID="TxtBExpediente" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" TargetControlID="TxtBExpediente" 
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                                                CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" 
                                                                CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetExpedienteByTextNombreNull" 
                                                                ServicePath="../../AutoComplete.asmx">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:TextBox id="TxtBExpediente" runat="server" Width="400px" Font-Size="8pt" 
                                                                Visible="False" CssClass="TxtAutoComplete">
                                                        </asp:TextBox>
                                                        <asp:Panel id="PnlExpediente" runat="server" Height="300px" 
                                                                CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView id="TreeVExpediente" runat="server" Width="300px" ShowLines="True" 
                                                                        OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" 
                                                                        OnSelectedNodeChanged="TreeVExpediente_SelectedNodeChanged" 
                                                                        ExpandDepth="0" ImageSet="Simple">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Expediente..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>

                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" 
                                                                            Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBExpediente" EventName="CheckedChanged">
                                                        </asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colspan="3">
                                                <asp:UpdatePanel id="UpdatePanelMedio" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBMedio" runat="server" Width="185px" Text="Por Medio de Recibo" 
                                                                AutoPostBack="True" OnCheckedChanged="ChBMedio_CheckedChanged">
                                                        </asp:CheckBox>
                                                        <br />
                                                        <asp:Label id="LblMedio" runat="server" Width="60px" Visible="False" Text="Medio">
                                                        </asp:Label>
                                                        <cc1:PopupControlExtender id="PopupControlMedio" runat="server" PopupControlID="PnlMedio" 
                                                                TargetControlID="TxtBMedio" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteMedio" runat="server" TargetControlID="TxtBMedio" 
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                                                CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" 
                                                                MinimumPrefixLength="1" ServiceMethod="GetMedioByTextNull" ServicePath="../../AutoComplete.asmx">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:TextBox id="TxtBMedio" runat="server" Width="400px" Font-Size="8pt" 
                                                                Visible="False" CssClass="TxtAutoComplete">
                                                        </asp:TextBox>
                                                        <asp:Panel id="PnlMedio" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView id="TreeVMedio" runat="server" Width="300px" ShowLines="True" 
                                                                        OnTreeNodePopulate="TreeVMedio_TreeNodePopulate" 
                                                                        OnSelectedNodeChanged="TreeVMedio_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Medio..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" 
                                                                            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBMedio" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colspan="3">
                                                <asp:UpdatePanel id="UpdatePanelNaturaleza" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBNaturaleza" runat="server" Width="250px" 
                                                                Text="Por Naturaleza ...(Seleccione o ingrese criterio)" AutoPostBack="True" 
                                                                OnCheckedChanged="ChBNaturaleza_CheckedChanged">
                                                        </asp:CheckBox>
                                                        <br />
                                                        <asp:Label id="LblNaturaleza" runat="server" Width="60px" Visible="False" Text="Naturaleza">
                                                        </asp:Label>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteNaturaleza" runat="server" TargetControlID="TxtBNaturaleza" 
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                                                CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" 
                                                                MinimumPrefixLength="1" ServiceMethod="GetNaturalezaByTextNull" 
                                                                ServicePath="../../AutoComplete.asmx">
                                                        </cc1:AutoCompleteExtender>
                                                        <cc1:PopupControlExtender id="PopupControlNaturaleza" runat="server" PopupControlID="PnlNaturaleza" 
                                                                TargetControlID="TxtBNaturaleza" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <asp:TextBox id="TxtBNaturaleza" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                        </asp:TextBox>
                                                        <asp:Panel id="PnlNaturaleza" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView id="TreeVNaturaleza" runat="server" Width="300px" ShowLines="True" 
                                                                        OnTreeNodePopulate="TreeVNaturaleza_TreeNodePopulate" 
                                                                        OnSelectedNodeChanged="TreeVNaturaleza_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" 
                                                                                Text="Seleccione Naturaleza..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" 
                                                                            Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel> 
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBNaturaleza" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colspan="3">
                                                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBOtros" runat="server" Text="Por Otros Detalles" Width="185px"
                                                                AutoPostBack="True" OnCheckedChanged="ChBOtros_CheckedChanged"   />
                                                        <br   />
                                                        <asp:Label ID="LblBuscarPor" runat="server" Text="Buscar Por" Visible="False" Width="60px">
                                                        </asp:Label>
                                                        <asp:DropDownList ID="DDLOtros" runat="server" Visible="False">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                            <asp:ListItem Value="Detalle">Detalle</asp:ListItem>
                                                            <asp:ListItem Value="NroExterno">Nro Externo</asp:ListItem>
                                                            <asp:ListItem Value="Anexo">Anexo</asp:ListItem>
                                                            <asp:ListItem Value="NúmerodeGuía">Número de Guía</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TxtBOtros" runat="server" Visible="False" Width="400px">
                                                        </asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #507cd1" colspan="3">
                                                <table style="WIDTH: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Table id="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                                    <asp:TableRow ID="TableRow1" runat="server">
                                                                        <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                                                    CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar">
                                                                            </asp:LinkButton>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                                    CssClass="CommandButton" OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda">
                                                                            </asp:LinkButton>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                </asp:Table>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList id="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                    <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">
                                    Resultados.:
                                </a>
                            </Header>
                            <Content>
                                <table style="WIDTH: 100%; HEIGHT: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server">
                                                </dxwgv:ASPxGridViewExporter>
                                                <table class="style1">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <dxe:ASPxComboBox id="listExportFormat" runat="server" ValueType="System.String" 
                                                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" 
                                                                        ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                                                    <Items>
                                                                        <dxe:ListEditItem Text="Pdf" Value="0"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Excel" Value="1"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Rtf" Value="2"></dxe:ListEditItem>
                                                                        <dxe:ListEditItem Text="Csv" Value="3"></dxe:ListEditItem>
                                                                    </Items>
                                                                    <ButtonStyle Width="13px"></ButtonStyle>
                                                                </dxe:ASPxComboBox>
                                                            </td>
                                                            <td>
                                                                <dxe:ASPxButton id="ButtonOpen" onclick="ButtonOpen_Click" runat="server" Text="Abrir" 
                                                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td style="WIDTH: 65px">
                                                                <dxe:ASPxButton id="ButtonSaveAs" onclick="ButtonSaveAs_Click" runat="server" Text="Guardar" 
                                                                        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                </dxe:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <dxpc:ASPxPopupControl id="popup" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                                                        CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" ClientInstanceName="popup" 
                                                        AllowDragging="True" PopupHorizontalAlign="OutsideRight" HeaderText="Vinculo a Respuesta">
                                                    <ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
                                                    <ContentCollection>
                                                        <dxpc:PopupControlContentControl runat="server">
                                                            <dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" 
                                                                    Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
                                                                <LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

                                                                <LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
                                                                <PanelCollection>
                                                                    <dxp:PanelContent runat="server">
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:Literal runat="server" ID="litText">
                                                                                        </asp:Literal>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </dxp:PanelContent>
                                                                </PanelCollection>
                                                            </dxcp:ASPxCallbackPanel>
                                                        </dxpc:PopupControlContentControl>
                                                    </ContentCollection>
                                                </dxpc:ASPxPopupControl>
                                                <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                                    <ContentTemplate>
                                                        <dxwgv:ASPxGridView id="ASPxGridView1" runat="server" Width="100%" 
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                                                                CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RadicadoCodigo" 
                                                                OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
                                                            <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
                                                                <Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

                                                                <LoadingPanel ImageSpacing="10px"></LoadingPanel>
                                                            </Styles>

                                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

                                                            <SettingsPager ShowSeparators="True">
                                                                <Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)">
                                                                </Summary>
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
                                                                <CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png">
                                                                </CollapsedButton>

                                                                <ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png">
                                                                </ExpandedButton>

                                                                <DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png">
                                                                </DetailCollapsedButton>

                                                                <DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png">
                                                                </DetailExpandedButton>

                                                                <FilterRowButton Height="13px" Width="13px"></FilterRowButton>
                                                            </Images>

                                                            <SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" 
                                                                    ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" 
                                                                    EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" 
                                                                    EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" 
                                                                    CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" 
                                                                    CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" 
                                                                    HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" 
                                                                    FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" 
                                                                    FilterBarCreateFilter="Crear Filtro">
                                                            </SettingsText>
                                                            <Columns>
                                                                <dxwgv:GridViewCommandColumn VisibleIndex="0">
                                                                    <ClearFilterButton Visible="True"></ClearFilterButton>
                                                                </dxwgv:GridViewCommandColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="Radicado" VisibleIndex="1">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                    <DataItemTemplate>
                                                                        <asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("RadicadoCodigo") %>' 
                                                                                Font-Underline="True" CssClass="LinKBtnStyleBig">
                                                                        </asp:HyperLink>
                                                                    </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Radicacion" VisibleIndex="2" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy hh:mm" >
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Caption="Procedencia" VisibleIndex="3">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="200px" Caption="Detalle" VisibleIndex="4">
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
                                                                <dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Caption="Destino" VisibleIndex="8">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="Respuesta" Caption="Rpta" VisibleIndex="9">
                                                                    <Settings AllowDragDrop="False" AllowAutoFilter="False" ShowFilterRowMenu="False" 
                                                                            AllowHeaderFilter="False" ShowInFilterControl="False" AllowGroup="False">
                                                                    </Settings>
                                                                    <DataItemTemplate>
                                                                        Rpta:
                                                                        <br />
                                                                        <asp:Label id="Label6" runat="server" Visible="true" Text='<%# Bind("Respuesta1") %>'>
                                                                        </asp:Label>
                                                                        <a onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')" href="javascript:void(0);">
                                                                            <asp:Image id="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif">
                                                                            </asp:Image>
                                                                        </a>
                                                                    </DataItemTemplate>
                                                                </dxwgv:GridViewDataTextColumn>
                                                                <dxwgv:GridViewDataTextColumn FieldName="ExpedienteCodigo" UnboundType="String" Caption="Opciones" 
                                                                        VisibleIndex="10">
                                                                    <Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" 
                                                                            ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" 
                                                                            AllowSort="False" AllowGroup="False">
                                                                    </Settings>
                                                                    <DataItemTemplate>
                                                                        <asp:HyperLink id="HyperLinkVisor" runat="server" Text="Imágenes" Font-Underline="True" 
                                                                                CssClass="LinKBtnStyleBig">
                                                                        </asp:HyperLink>
                                                                        <br />
                                                                        <asp:HyperLink id="HprLnkHisExtven" runat="server" Font-Underline="True" 
                                                                                CssClass="LinKBtnStyleBig">
                                                                            Histórico
                                                                        </asp:HyperLink>
                                                                        <br />
                                                                        <asp:HyperLink id="HprLnkExp" runat="server" Text="Expediente" CssClass="LinKBtnStyleBig" 
                                                                                Target="_blank">
                                                                        </asp:HyperLink>
                                                                        <asp:HiddenField id="HFExp" runat="server" Value='<%# Eval("ExpedienteCodigo") %>'>
                                                                        </asp:HiddenField>
                                                                        <asp:HiddenField id="HFGrupo" runat="server" Value='<%# Eval("GrupoCodigo") %>'>
                                                                        </asp:HiddenField> 
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
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>           
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane3" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="" >
                                    Reporte.:
                                </a>
                            </Header>
                            <Content>                                                          
                                <rsweb:reportviewer id="ReportViewer1" runat="server" BackColor="White" width="100%" height="400px" font-size="8pt" 
                                        font-names="Verdana" AsyncRendering="false">
                                    <LocalReport ReportPath="AlfaNetConsultas\Gestion\DocRecibido.rdlc" EnableExternalImages="True">
                                        <DataSources>
                                            <rsweb:ReportDataSource DataSourceId="ODSBuscarGraph" Name="DSRadicado_Radicado_ConsultasRadicado" />
                                        </DataSources>
                                    </LocalReport>
                                </rsweb:reportviewer>
                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion> 
                <asp:ObjectDataSource ID="ODSBuscarGraph" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetConsultasRadicado" TypeName="RadicadoBLL" UpdateMethod="UpdateRadicado">
                    <SelectParameters>
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo1" Type="String" />
                        <asp:Parameter DefaultValue="" Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="DependenciaNomDestino" Type="String" />
                        <asp:Parameter Name="RadicadoDetalle" Type="String" />
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                        <asp:Parameter Name="RadicadoAnexo" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaNombre" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
                        <asp:Parameter Name="RadicadoGuia" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter Name="GrupoCodigo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                        <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoDetalle" Type="String" />
                        <asp:Parameter Name="RadicadoAnexo" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="Original_RadicadoCodigo" Type="String" />
                        <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
                        <asp:Parameter Name="NumeroGuia" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                        Width="100%">
                </asp:Label>
                <asp:Label ID="MyLabelTemp" runat="server" Width="100%">
                </asp:Label>
                <asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                        runat="server" Width="100%" Font-Size="10pt" DisplayMode="List">
                </asp:ValidationSummary>
            </td>
        </tr>
    </table>
</asp:Content>

