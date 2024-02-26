<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="GestionTDocRecibido.aspx.cs" Inherits="_GestionTDocRecibido" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<%@ Import Namespace="System.Configuration" %>
<%--<%@ Register Src="../NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc1" %>
<%@ Register Src="NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div>
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
        
         function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
            }
        function popup_Shown(s, e) {
        callbackPanel.AdjustControl();
            }


         //// ]]>

    </script>


    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td style="text-align: center">
                <asp:ObjectDataSource ID="ODSBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetGTRadicadov3" TypeName="RadicadoBLL" UpdateMethod="UpdateRadicado">
                    <SelectParameters>
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="WFMovimientoFechaFin" Type="String" />
                        <asp:Parameter Name="WFMovimientoFechaFin1" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento" Type="String" />
                        <asp:Parameter Name="RadicadoFechaVencimiento1" Type="String" />
                        <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                        <asp:Parameter Name="WFMovimientoTipo1" Type="Int32" />
                        <asp:Parameter Name="WFMovimientoPasoActual" Type="String" />
                        <asp:Parameter Name="WFMovimientoPasoFinal" Type="String" />
                        <asp:Parameter Name="DependenciaCodOrigen" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="RadicadoCodigoFuente" Type="String" />
                        <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="Detalle" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
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
                    </UpdateParameters>
                    
                </asp:ObjectDataSource>
                
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                    SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                    ContentCssClass="accordionContent" AutoSize="None">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Consulta Gestion de Tareas.:</a>
                            </Header>
                            <Content>
                                <TABLE style="WIDTH: 100%; TEXT-ALIGN: left" 
forecolor="White"><TBODY><TR><TD 
style="WIDTH: 100%; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">Consulta Gestion de Tareas 
Recibida</TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 8px" colSpan=3>Ver:&nbsp;<asp:DropDownList id="DDLSel" runat="server" Width="500px" CausesValidation="True" ValidationGroup="Buscar">
                             <asp:ListItem Value="Seleccione...">Seleccione...</asp:ListItem>
                             <asp:ListItem Value="1">Documentos Archivados</asp:ListItem>
                             <asp:ListItem Value="2">Documentos Pendientes de Tramite</asp:ListItem>
                             <asp:ListItem Value="0">Documentos Archivados o Pendientes de Tramite</asp:ListItem>
                         </asp:DropDownList>&nbsp;
    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="Buscar" ControlToValidate="DDLSel" ErrorMessage="Debe Seleccionar un tipo de Documento" InitialValue="Seleccione..." SetFocusOnError="True"></asp:RequiredFieldValidator></TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 8px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
<cc1:CalendarExtender id="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinal">
                                                    </cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarInicial">
                                                    </cc1:CalendarExtender> <asp:CheckBox id="ChBFechaRad" runat="server" Width="181px" Text="Entre Fechas de Radicacion" OnCheckedChanged="ChBFechaRad_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR /><TABLE><TBODY><TR><TD><asp:Label id="LblFechaInicial" runat="server" Width="63px" Text="Fecha Inicial" Visible="False"></asp:Label> <asp:RequiredFieldValidator id="RFVFechaRadIni" runat="server" ValidationGroup="Buscar" ErrorMessage="*" ControlToValidate="TxtFechaInicial" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image></TD><TD><asp:Label id="LblFechaFinal" runat="server" Width="55px" Visible="False">FechaFinal</asp:Label> <asp:RequiredFieldValidator id="RFVFecharadFin" runat="server" ValidationGroup="Buscar" ErrorMessage="*" ControlToValidate="TxtFechaFinal" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                            </asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UPFechaFin" runat="server" UpdateMode="Conditional">
                                            <contenttemplate>
<cc1:CalendarExtender id="CalendarFinFinal" runat="server" TargetControlID="TxtFechaFinFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinFinal"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarFinInicial" runat="server" TargetControlID="TxtFechaFinInicial" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinInicial"></cc1:CalendarExtender><asp:CheckBox id="ChBFechaFin" runat="server" Width="181px" Text="Entre Fechas de Finalizacion" OnCheckedChanged="ChBFechaFin_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR /><TABLE><TBODY><TR><TD><asp:Label id="LblFechaFinInicial" runat="server" Width="63px" Text="Fecha Inicial" Visible="False"></asp:Label> <asp:RequiredFieldValidator id="RFVFechaFinIni" runat="server" ValidationGroup="Buscar" ErrorMessage="*" ControlToValidate="TxtFechaFinInicial" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaFinInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarFinInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image></TD><TD><asp:Label id="LblFechaFinFinal" runat="server" Width="55px" Visible="False">FechaFinal</asp:Label> <asp:RequiredFieldValidator id="RFVFechaFinFin" runat="server" ValidationGroup="Buscar" ErrorMessage="*" ControlToValidate="TxtFechaFinFinal" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaFinFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarFinFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image></TD></TR></TBODY></TABLE>
</contenttemplate>
                                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                        </asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb"><asp:UpdatePanel id="UPFechaVencimiento" runat="server" UpdateMode="Conditional">
                                            <contenttemplate>
<cc1:CalendarExtender id="CalendarVenFinal" runat="server" TargetControlID="TxtFechaVenFinal" PopupButtonID="ImgCalendarVenFinal" Format="dd/MM/yyyy"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarVenInicial" runat="server" TargetControlID="TxtFechaVenInicial" PopupButtonID="ImgCalendarVenInicial" Format="dd/MM/yyyy"></cc1:CalendarExtender><asp:CheckBox id="ChBFechaVen" runat="server" Width="163px" Text="Entre Fechas de Vencimiento" AutoPostBack="True" OnCheckedChanged="ChBFechaVen_CheckedChanged"></asp:CheckBox><BR /><TABLE><TBODY><TR><TD><asp:Label id="LblFechaVenInicial" runat="server" Width="63px" Visible="False" Text="Fecha Inicial"></asp:Label> <asp:RequiredFieldValidator id="RFVFechaVenIni" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtFechaVenInicial" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaVenInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarVenInicial" runat="server" Width="27px" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Height="20px"></asp:Image></TD><TD><asp:Label id="LblFechaVenFinal" runat="server" Width="55px" Visible="False">FechaFinal</asp:Label> <asp:RequiredFieldValidator id="RFVFechaVenFin" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtFechaVenFinal" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtFechaVenFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarVenFinal" runat="server" Width="27px" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Height="20px"></asp:Image></TD></TR></TBODY></TABLE>
</contenttemplate>
                                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                        </asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UpdatePanelDestino" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBDependencias" runat="server" Width="185px" Text="Entre Dependencias" AutoPostBack="True" OnCheckedChanged="ChBDependencias_CheckedChanged"></asp:CheckBox> <cc1:AutoCompleteExtender id="ACEDepDestino" runat="server" TargetControlID="TxtBDepDestino" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PCDepDestino" runat="server" TargetControlID="TxtBDepDestino" PopupControlID="PnlDepDestino" Position="Right"></cc1:PopupControlExtender> <cc1:PopupControlExtender id="PopupControlDepOrigen" runat="server" TargetControlID="TxtBDepOrigen" PopupControlID="PnlDestino" Position="Right"></cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteDepOrigen" runat="server" TargetControlID="TxtBDepOrigen" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20"></cc1:AutoCompleteExtender> <TABLE><TBODY><TR><TD><asp:Label id="LblDepOrigen" runat="server" Width="300px" Visible="False" Text="Dependencia Origen ...(Seleccione o ingrese criterio)"></asp:Label> <asp:RequiredFieldValidator id="RFVDepOrigen" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBDepOrigen" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <asp:TextBox id="TxtBDepOrigen" runat="server" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD><asp:Label id="LblDepDestino" runat="server" Width="300px" Visible="False" Text="Dependencia Destino ...(Seleccione o ingrese criterio)"></asp:Label> <asp:RequiredFieldValidator id="RFVDepDestino" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBDepDestino" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator><asp:TextBox id="TxtBDepDestino" runat="server" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
 </asp:TextBox>&nbsp;&nbsp; </TD></TR></TBODY></TABLE><asp:Panel id="PnlDestino" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVDependencia" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView>&nbsp;&nbsp; </DIV></asp:Panel> <asp:Panel style="LEFT: 302px" id="PnlDepDestino" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TVDepDestino" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TVDepDestino_SelectedNodeChanged" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView>&nbsp;&nbsp; </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBDependencias" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UPFuente" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBFuente" runat="server" Width="185px" Text="Resueltos o Por Resolver" AutoPostBack="True" OnCheckedChanged="ChBFuente_CheckedChanged"></asp:CheckBox><BR />&nbsp; <asp:Label id="LblFuente" runat="server" Width="85px" Visible="False" Text="Radicado Fuente"></asp:Label> <asp:RequiredFieldValidator id="RFVFuente" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBFuente" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <asp:RadioButtonList id="RadioButtonList1" runat="server" Width="180px" Visible="False" RepeatDirection="Horizontal"><asp:ListItem Value="1">Resueltos</asp:ListItem>
<asp:ListItem Value="0">Por Resolver</asp:ListItem>
</asp:RadioButtonList> <cc1:AutoCompleteExtender id="AutoCompleteFuente" runat="server" TargetControlID="TxtBFuente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetRadicadoByCodigo" MinimumPrefixLength="1"></cc1:AutoCompleteExtender><asp:TextBox id="TxtBFuente" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
    </asp:TextBox>&nbsp; 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBFuente" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UPProceso" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBProceso" runat="server" Width="185px" Text="Por Proceso" AutoPostBack="True" OnCheckedChanged="ChBProceso_CheckedChanged"></asp:CheckBox> <BR /><asp:Label id="LblProceso" runat="server" Width="85px" Visible="False" Text="Proceso">
</asp:Label> <asp:RequiredFieldValidator id="RFVProceso" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBProceso" ErrorMessage="*" Enabled="False">
</asp:RequiredFieldValidator> <cc1:AutoCompleteExtender id="AutoCompleteProceso" runat="server" TargetControlID="TxtBProceso" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFProcesoTextByText " MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlProceso" runat="server" TargetControlID="TxtBProceso" PopupControlID="Panel88" Position="Right"></cc1:PopupControlExtender> <asp:Panel id="Panel88" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVProceso" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVProceso_TreeNodePopulate" OnSelectedNodeChanged="TreeVProceso_SelectedNodeChanged" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Proceso..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> <asp:TextBox id="TxtBProceso" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
</asp:TextBox> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UPAccion" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBAccion" runat="server" Width="185px" Text="Por Accion" AutoPostBack="True" OnCheckedChanged="ChBAccion_CheckedChanged">
</asp:CheckBox> <BR /><asp:Label id="LblAccion" runat="server" Width="85px" Visible="False" Text="Accion">
</asp:Label> <asp:RequiredFieldValidator id="RFVAccion" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBAccion" ErrorMessage="*" Enabled="False">
</asp:RequiredFieldValidator> <cc1:AutoCompleteExtender id="AutoCompleteAccion" runat="server" TargetControlID="TxtBAccion" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
</cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlAccion" runat="server" TargetControlID="TxtBAccion" PopupControlID="PnlAccion" Position="Right">
 </cc1:PopupControlExtender> <asp:Panel id="PnlAccion" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVAccion" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVAccion_TreeNodePopulate" OnSelectedNodeChanged="TreeVAccion_SelectedNodeChanged" ExpandDepth="0">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Accion..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> <asp:TextBox id="TxtBAccion" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
</asp:TextBox> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UpdatePanelNaturaleza" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBNaturaleza" runat="server" Width="185px" Text="Por Naturaleza" AutoPostBack="True" OnCheckedChanged="ChBNaturaleza_CheckedChanged"></asp:CheckBox><BR /><asp:Label id="LblNaturaleza" runat="server" Width="60px" Visible="False" Text="Naturaleza"></asp:Label> <asp:RequiredFieldValidator id="RFVNaturaleza" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBNaturaleza" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <cc1:AutoCompleteExtender id="AutoCompleteNaturaleza" runat="server" TargetControlID="TxtBNaturaleza" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetNaturalezaByText" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlNaturaleza" runat="server" TargetControlID="TxtBNaturaleza" PopupControlID="PnlNaturaleza" Position="Right">
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
<asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelExpediente" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBExpediente" runat="server" Width="185px" Text="Por Expediente" AutoPostBack="True" OnCheckedChanged="ChBExpediente_CheckedChanged"></asp:CheckBox><BR /><asp:Label id="LblExpediente" runat="server" Width="60px" Visible="False" Text="Expediente"></asp:Label> <asp:RequiredFieldValidator id="RFVExpediente" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBExpediente" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator> <cc1:AutoCompleteExtender id="AutoCompleteExpediente" runat="server" TargetControlID="TxtBExpediente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetExpedienteByTextNombre" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender> <cc1:PopupControlExtender id="PopupControlExpediente" runat="server" TargetControlID="TxtBExpediente" PopupControlID="PnlExpediente" Position="Right">
                                                    </cc1:PopupControlExtender> <asp:TextBox id="TxtBExpediente" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlExpediente" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVExpediente" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" OnSelectedNodeChanged="TreeVExpediente_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
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
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #ffffff" colSpan=3><asp:UpdatePanel id="UpdatePanelProcedencia" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
<asp:CheckBox id="ChBProcedencia" runat="server" Width="185px" Text="Por Procedencia" AutoPostBack="True" OnCheckedChanged="ChBProcedencia_CheckedChanged"></asp:CheckBox><BR /><asp:Label id="LblProcedencia" runat="server" Width="300px" Visible="False" Text="Procedencia ...(Seleccione o ingrese Criterio)"></asp:Label> <asp:RequiredFieldValidator id="RFVProcedencia" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBProcedencia" ErrorMessage="*" Enabled="False">
</asp:RequiredFieldValidator> <cc1:AutoCompleteExtender id="ACEProcedencia" runat="server" TargetControlID="TxtBProcedencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender> <asp:TextBox id="TxtBProcedencia" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox> 
</ContentTemplate>
                                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                            </asp:UpdatePanel> </TD></TR>
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            <TR><TD 
style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UPDetalle" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
<asp:CheckBox id="ChBDetalle" runat="server" Width="185px" Text="Por Detalle" AutoPostBack="True" OnCheckedChanged="ChBDetalle_CheckedChanged"></asp:CheckBox><BR /><asp:Label id="lbDetalle" runat="server" Width="300px" Visible="False" Text="Criterio de Busqueda por DETALLE"></asp:Label> <asp:RequiredFieldValidator id="RFVDetalle" runat="server" ValidationGroup="Buscar" ControlToValidate="TXTDetalle" ErrorMessage="*" Enabled="False">
</asp:RequiredFieldValidator><asp:TextBox id="TXTDetalle" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox> 
</ContentTemplate>
                                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBDetalle" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                            </asp:UpdatePanel> </TD></TR>
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            <TR><TD 
style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #507cd1" colSpan=3><asp:Table id="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellPadding="0" CellSpacing="4">
                                                <asp:TableRow ID="TableRow1" runat="server">
                                                    <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton"> <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                            CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar" ValidationGroup="Buscar"></asp:LinkButton></asp:TableCell>
                                                    <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton"> <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                            CssClass="CommandButton" OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda"></asp:LinkButton></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                                
                                                  <asp:ImageButton id="ImgBtnBuscar" onclick="cmdBuscar_Click" runat="server" Width="18px" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/tbBuscar.gif" Height="17px" ValidationGroup="Buscar"></asp:ImageButton></TD></TR></TBODY></TABLE>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                              <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD><dxwgv:ASPxGridViewExporter id="ASPxGridViewExporter1" runat="server">
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
</TD></TR></TBODY></TABLE><dxpc:ASPxPopupControl id="popup" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" ClientInstanceName="popup" AllowDragging="True" PopupHorizontalAlign="OutsideRight" HeaderText="Vinculo a Respuesta">
<ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
<ContentCollection>
<dxpc:PopupControlContentControl runat="server"><dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
<LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

<LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
<PanelCollection>
<dxp:PanelContent runat="server"><TABLE><TBODY><TR><TD align=center><asp:Literal runat="server" ID="litText"></asp:Literal>

 </TD></TR></TBODY></TABLE></dxp:PanelContent>
</PanelCollection>
</dxcp:ASPxCallbackPanel>
 </dxpc:PopupControlContentControl>
</ContentCollection>
</dxpc:ASPxPopupControl> <asp:UpdatePanel id="UpdatePanel10" runat="server"><ContentTemplate>
<dxwgv:ASPxGridView id="ASPxGridView1" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RadicadoCodigo" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
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
<dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="Radicado" VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("RadicadoCodigo") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Radicacion" VisibleIndex="2">
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
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Caption="Dependencia Actual" VisibleIndex="5">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Respuesta" Caption="Rpta" VisibleIndex="6">
<Settings AllowDragDrop="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowGroup="False"></Settings>
<DataItemTemplate>
Rpta:<BR /><asp:Label id="Label6" runat="server" Visible="False" Text='<%# Bind("Respuesta") %>'>
</asp:Label> <A onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')" href="javascript:void(0);">
<asp:Image id="Image1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif">
</asp:Image> </A>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Caption="Accion" VisibleIndex="7"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" Caption="Expediente" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="SerieNombre" Caption="Serie" VisibleIndex="9"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Caption="Naturaleza" VisibleIndex="10">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Opciones" UnboundType="String" Caption="Opciones" VisibleIndex="11">
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
                    </Panes>
                </cc1:Accordion>
                
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
