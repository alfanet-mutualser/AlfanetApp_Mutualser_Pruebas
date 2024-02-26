<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConsultaFactura.aspx.cs" Inherits="AlfaNetConsultas_Gestion_ConsultaFactura" %>

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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="script_ConsultasFactura/RadicacionMasiva.js" type="text/javascript"></script>
    <link href="css_ConsultasFactura/radicacionmasivastyle.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="script_ConsultasFactura/Test.js" type="text/javascript"></script>
    <script src="script_ConsultasFactura/consultas.js" type="text/javascript"></script>
    <script src="script_ConsultasFactura/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script_ConsultasFactura/swfobject.js" type="text/javascript"></script>
    <link href="css_ConsultasFactura/uploadify.css" rel="stylesheet" type="text/css" />
    <link href="../../ColumnaOculta.css" rel="stylesheet" type="text/css" />

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
        function Expediente(evt, NumeroDocumento, Expediente, Grupo) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

        }
        function AddValues() {

            var txtValue = document.getElementById(" <% = txtCompEgreso.ClientID %> ");
            var listBox = document.getElementById(" <% = lbxCompEgreso.ClientID %> ");
            var option = document.createElement("OPCIÓN");
            option.innerHTML = txtValue.value;
            option.value = txtValue.value;
            listBox.appendChild(opción);
            txtValue.value = "";
            return false;
        }
        //// ]]>

    </script>

    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td style="text-align: center; height: 315px;">
                <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                    TransitionDuration="250" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Facturas.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; text-align: left" forecolor="White">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100%; color: white; height: 16px; background-color: #507cd1; text-align: center">Consulta de Facturación</td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBFechaReg" runat="server" Text="Entre Fechas de Radicación" Width="185px"
                                                            AutoPostBack="True" OnCheckedChanged="ChBFechaRad_CheckedChanged" />
                                                        <br />
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
                                                            Width="27px" Visible="False" />
                                                        <asp:Label ID="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label>
                                                        <asp:TextBox ID="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                        <asp:Image ID="ImgCalendarFinal" runat="server" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png"
                                                            Width="27px" Visible="False" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaReg" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBNroReg" runat="server" Text="Entre Numeros de Radicado" Width="181px"
                                                            OnCheckedChanged="ChBNroReg_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblNroRegInicial" runat="server" Text="Numero Radicado Inicial" Visible="False"
                                                            Width="120px"></asp:Label><asp:TextBox ID="TxtNroRegInicial" runat="server" Font-Size="8pt"
                                                                Visible="False" Width="70px"></asp:TextBox><asp:Label ID="LblNroRegFinal" runat="server"
                                                                    Visible="False" Width="120px">Numero Radicado Final</asp:Label><asp:TextBox ID="TxtNroRegFinal"
                                                                        runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBNroReg" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelNumRemision" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkRemision" runat="server" Text="Entre Numeros de Remisión" Width="181px" OnCheckedChanged="ChkRemision_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblRemiIni" runat="server" Text="Remisión Inicial" Visible="False"
                                                            Width="80px"></asp:Label>
                                                        <asp:TextBox ID="TxtRemiIni" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                        <asp:Label ID="LblRemiFin" runat="server" Visible="False" Width="80px">Remisión Final</asp:Label>
                                                        <asp:TextBox ID="TxtRemiFin" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkRemision" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelNumFactura" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkNumFactura" runat="server" Text="Entre Numeros de Factura" Width="181px" OnCheckedChanged="ChkNumFactura_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblFactIni" runat="server" Text="Factura Inicial" Visible="False"
                                                            Width="120px"></asp:Label>
                                                        <asp:TextBox ID="TxtFactIini" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                        <asp:Label ID="LblFactFin" runat="server" Visible="False" Width="120px">Factura Final</asp:Label>
                                                        <asp:TextBox ID="TxtFactFIn" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkNumFactura" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelComprobEgr" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkComprobantes" runat="server" Text="Entre Comprobantes de Egreso" Width="181px" OnCheckedChanged="ChkComprobantes_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblComprobIni" runat="server" Text="Comprobante Inicial" Visible="False"
                                                            Width="120px"></asp:Label>
                                                        <asp:TextBox ID="TxtCOmprobIni" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                        <asp:Label ID="LblComprobFin" runat="server" Visible="False" Width="120px">Comprobante Final</asp:Label>
                                                        <asp:TextBox ID="TxtCOmprobFin" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkComprobantes" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelValFacturas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkValFacturas" runat="server" Text="Entre Valores de Facturas" Width="181px" OnCheckedChanged="ChkValFacturas_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblValFactIni" runat="server" Text="Valor Inicial" Visible="False"
                                                            Width="120px"></asp:Label>
                                                        <asp:TextBox ID="TxtValFactIni" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                        <asp:Label ID="LblValFactFin" runat="server" Visible="False" Width="120px">Valor Final</asp:Label>
                                                        <asp:TextBox ID="TxtValFactFin" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkValFacturas" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 1px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelProcedencia" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBProcedencia" runat="server" Width="114px" Text="Por Procedencia" OnCheckedChanged="ChBProcedencia_CheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                                        <asp:Label ID="LblProcedencia" runat="server" Width="60px" Visible="False" Text="Procedencia"></asp:Label><cc1:AutoCompleteExtender ID="AutoCompleteProcedencia" runat="server" TargetControlID="TxtBProcedencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombrenull" MinimumPrefixLength="1" CompletionSetCount="20"></cc1:AutoCompleteExtender>
                                                    <asp:RadioButtonList ID="RadioButtonList1" TabIndex="8" runat="server" Width="200px" Visible="false" Font-Size="8pt" ValidationGroup="1" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">Por Nombre</asp:ListItem>
                                                                <asp:ListItem Value="0">Por Codigo</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        <asp:TextBox ID="TxtBProcedencia" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelUbicacion" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkUbic" runat="server" Width="114px" Text="Por Ubicación" OnCheckedChanged="ChkUbic_CheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                                        <asp:Label ID="LblUbic" runat="server" Width="60px" Visible="False" Text="Buscar"></asp:Label><cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtUbic" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetCiudadByTextNombrenull" MinimumPrefixLength="1" CompletionSetCount="20"></cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtUbic" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkUbic" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelCodCiudades" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkCodCiudades" runat="server" Text="Entre codigos de Ciudad" Width="181px" OnCheckedChanged="ChkCodCiudades_CheckedChanged" AutoPostBack="True" /><br />
                                                        <asp:Label ID="LblCodIni" runat="server" Text="Codigó Inicial" Visible="False"
                                                            Width="120px"></asp:Label>
                                                        <asp:TextBox ID="TxtCodIni" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                        <asp:Label ID="LblCodFin" runat="server" Visible="False" Width="120px">Codigó Final</asp:Label>
                                                        <asp:TextBox ID="TxtCodFin" runat="server" Font-Size="8pt" Visible="False" Width="70px"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkCodCiudades" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChkDetalle" runat="server" Width="150px" Text="Por Detalle" OnCheckedChanged="ChkDetalle_CheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                                        <asp:Label ID="LblDetalle" runat="server" Width="60px" Visible="False" Text="Buscar"></asp:Label>
                                                        <asp:TextBox ID="TxtDetalle" runat="server" Width="400px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChkUbic" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelUndAlmac" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="cbxUnidad" runat="server" Text="Por unidad de almacenamiento"
                                                            AutoPostBack="True" OnCheckedChanged="cbxUnidad_CheckedChanged" /><br />
                                                        <asp:Label ID="LblUndAlmac" runat="server" Width="60px" Visible="False" Text="Buscar"></asp:Label>
                                                        <asp:TextBox ID="txtUnidad" runat="server" Width="400px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cbxUnidad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelXModalidad" runat="server" Visible="False" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="cbxModalidad" runat="server" Text="Por modalidad de  contrato"
                                                            AutoPostBack="True" OnCheckedChanged="cbxModalidad_CheckedChanged" /><br />
                                                        <asp:Label ID="LblModalidad" runat="server" Width="60px" Visible="False" Text="Buscar"></asp:Label>
                                                        <asp:TextBox ID="txtModalidad" runat="server" Width="400px" Font-Size="8pt" Visible="False"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cbxModalidad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 17px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelExpediente" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="cbxExpediente" runat="server" Text="Por expediente" AutoPostBack="True"
                                                            OnCheckedChanged="cbxExpediente_CheckedChanged" /><br />
                                                        <asp:Label ID="LblExpediente" runat="server" Width="60px" Visible="False" Text="Buscar:"></asp:Label>
                                                        <cc1:PopupControlExtender ID="PopupControlExpediente" runat="server" PopupControlID="PnlExpediente" TargetControlID="TxtBExpediente" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExpediente" runat="server" TargetControlID="TxtBExpediente" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetExpedienteByTextNombrenull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtBExpediente" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                        <asp:Panel ID="PnlExpediente" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView ID="TreeVExpediente" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate" OnSelectedNodeChanged="TreeVExpediente_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Expediente..." Value="0"></asp:TreeNode>
                                                                    </Nodes>

                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cbxExpediente" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; background-color: #ffffff">
                                                <asp:UpdatePanel ID="UpdatePanelImg" runat="server"  UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="cbxPorImagen" runat="server" Text="Consultar por Imagen" AutoPostBack="True" OnCheckedChanged="cbxPorImagen_CheckedChanged" /><br />
                                                        <asp:Label ID="LblImg" runat="server" Width="60px" Visible="False" Text="Imagen:"></asp:Label>
                                                        <asp:RadioButtonList ID="RblImagen" runat="server" RepeatDirection="Horizontal" Visible="False">
                                                            <asp:ListItem Value="1">Con Imagen</asp:ListItem>
                                                            <asp:ListItem Value="2">Sin Imagen</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cbxPorImagen" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="width: 100%; height: 8px; background-color: #eff3fb" colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelRemite" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ChBRemite" runat="server" Width="300px" Text="Por Radicador ...(Seleccione o ingrese criterio)" OnCheckedChanged="ChBRemite_CheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                                        <asp:Label ID="LblRemite" runat="server" Width="121px" Visible="False" Text="Dependencia que Remite"></asp:Label>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteRemite" runat="server" TargetControlID="TxtBRemite" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                        </cc1:AutoCompleteExtender>
                                                        <cc1:PopupControlExtender ID="PopupControlRemite" runat="server" PopupControlID="PnlRemite" TargetControlID="TxtBRemite" Position="Right">
                                                        </cc1:PopupControlExtender>
                                                        <asp:TextBox ID="TxtBRemite" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox>
                                                        <asp:Panel ID="PnlRemite" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                            <div>
                                                                <asp:TreeView ID="TreeVRemite" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVRemite_TreeNodePopulate" OnSelectedNodeChanged="TreeVRemite_SelectedNodeChanged" ExpandDepth="0" ImageSet="Simple">
                                                                    <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

                                                                    <HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia que Remite..." Value="0"></asp:TreeNode>
                                                                    </Nodes>

                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
                                                                </asp:TreeView>
                                                            </div>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBRemite" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr></tr>
                                        <tr>
                                            <td
                                                style="width: 100%; color: white; background-color: #507cd1" colspan="3">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                                    <asp:TableRow ID="TableRow1" runat="server">
                                                                        <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                                                CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar"></asp:LinkButton>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                                                CssClass="CommandButton" OnClick="BtnNuevo_Click" com TabIndex="24" Text="Nueva Busqueda" CommandArgument="Select"></asp:LinkButton>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                </asp:Table>
                                                            </td>
                                                            <td></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="RBLTblRpt" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="1">Tabla Resultados</asp:ListItem>
                                                                    <asp:ListItem Value="0">Reporte</asp:ListItem>
                                                                </asp:RadioButtonList></td>
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
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                                <table style="width: 100%; height: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" >
                                                        <Styles>  
                                                            <Default Font-Size="Small"></Default>  
                                                            <Cell Font-Size="Small"></Cell>  
                                                            <Title Font-Size="Medium" Font-Bold="true" Font-Underline="true"></Title>  
                                                        </Styles> 
                                                </dxwgv:ASPxGridViewExporter>
                                                <div id="Divexportar">
                                                    <table class="style1">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <dxe:ASPxComboBox ID="listExportFormat" runat="server" ValueType="System.String" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
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
                                                                    <dxe:ASPxButton ID="ButtonOpen" OnClick="ButtonOpen_Click" runat="server" Text="Abrir" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                    </dxe:ASPxButton>
                                                                </td>
                                                                <td style="width: 65px">
                                                                    <dxe:ASPxButton ID="ButtonSaveAs" OnClick="ButtonSaveAs_Click" runat="server" Text="Guardar" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue">
                                                                    </dxe:ASPxButton>
                                                                </td>
                                                                <%--                                                                    <td>
                                                                        <asp:Label ID="Lblmostrarmensaje" runat="server" Text=""></asp:Label>
                                                                    </td>--%>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                    <ContentTemplate>
                                                        <div id="grid" class="rm_data_container">
                                                            <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" Visible="true">
                                                                <Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
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

                                                                <SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
                                                                <Columns>
                                                                    <dxwgv:GridViewCommandColumn VisibleIndex="0">
                                                                        <ClearFilterButton Visible="True"></ClearFilterButton>
                                                                    </dxwgv:GridViewCommandColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="RADICADO" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                        <DataItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("RadicadoCodigo") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
                                                                        </DataItemTemplate>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="facn_numero" Caption="REGISTRO OASIS" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="facn_recibo" Caption="Nº REMISI&Oacute;N" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="FechaRadicacion" Width="160px" Caption="Fecha Radicación" VisibleIndex="4">
                                                                        <PropertiesTextEdit>
                                                                            <ValidationSettings Display="Dynamic"></ValidationSettings>
                                                                        </PropertiesTextEdit>

                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNUI" Caption="ProcedenciaNUI" VisibleIndex="5" CellStyle-CssClass="ColumnaOculta">
                                                                        <HeaderStyle CssClass="ColumnaOculta" />
                                                                        <CellStyle CssClass="ColumnaOculta"></CellStyle>
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="ProcedenciaNombre" Caption="PROCEDENCIA" VisibleIndex="6">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="Detalle" Caption="DETALLE" VisibleIndex="7" Width="200px">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="facc_factura" Caption="FACTURA PRESTADOR" VisibleIndex="8">
                                                                        <Settings AutoFilterCondition="Contains"></Settings>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" Caption="EXPEDIENTE" VisibleIndex="9"></dxwgv:GridViewDataTextColumn>

                                                                    <dxwgv:GridViewDataTextColumn FieldName="Imagen" Caption="IMAGEN" VisibleIndex="10"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="dependenciaNombre" Caption="RADICADOR" VisibleIndex="11"></dxwgv:GridViewDataTextColumn>
                                                                    <dxwgv:GridViewDataTextColumn FieldName="Opciones" UnboundType="String" Caption="Opciones" VisibleIndex="12">
                                                                        <Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False"></Settings>
                                                                        <DataItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkVisor" runat="server" Text="Imágenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink><br />
                                                                            <a href="#tab-2" onclick="OpenEdit(this);" class="active LinKBtnStyleBig">Editar</a>
                                                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" Width="55px" Font-Underline="True" CssClass="LinKBtnStyleBig" Visible="false">Histórico</asp:HyperLink><br />
                                                                            <asp:HyperLink ID="HprLnkExp" runat="server" Text="Expediente" CssClass="LinKBtnStyleBig" Target="_blank" Visible="false"></asp:HyperLink>
                                                                            <asp:HiddenField ID="HFExp" runat="server" Value='<%# Eval("ExpedienteCodigo") %>'></asp:HiddenField>
                                                                            <%--<asp:HiddenField ID="HFGrupo" runat="server" Value='<%# Eval("GrupoCodigo") %>'></asp:HiddenField>--%>
                                                                            <span id="Span1" style="display: none;"><%# Eval("RadicadoCodigo")%></span>
                                                                            <span id="Span2" style="display: none;"><%# Eval("FechaRadicacion")%></span>
                                                                            <span id="Span3" style="display: none;"><%# Eval("ProcedenciaNombre")%></span>
                                                                            <span id="Span4" style="display: none;"><%# Eval("Detalle")%></span>
                                                                            <span id="Span5" style="display: none;"><%# Eval("Facc_factura")%></span>
                                                                            <span id="Span9" style="display: none;"><%# Eval("ExpedienteNombre")%></span>
                                                                            <span id="Span11" style="display: none;"><%# Eval("Facn_numero")%></span>
                                                                            <span id="Span12" style="display: none;"><%# Eval("Facn_recibo")%></span>
                                                                            <span id="ProcedenciaNUI" style="display: none;"><%# Eval("ProcedenciaNUI")%></span>
                                                                            <span id="comp_egreso" style="display: none;"><%# Eval("comprobante_egreso")%></span>
                                                                            <span id="Facn_empresa" style="display: none;"><%# Eval("facn_empresa")%></span>
                                                                            <span id="Facc_documento" style="display: none;"><%# Eval("facc_documento")%></span>
                                                                            <span id="Facn_ubicacion" style="display: none;"><%# Eval("facn_ubicacion")%></span>
                                                                            <span id="Facv_total" style="display: none;"><%# Eval("facv_total")%></span>
                                                                            <span id="Facc_estado" style="display: none;"><%# Eval("facc_estado")%></span>
                                                                            <span id="Facc_prefijo" style="display: none;"><%# Eval("facc_prefijo")%></span>
                                                                            <span id="Facn_factura2" style="display: none;"><%# Eval("facn_factura2")%></span>
                                                                            <span id="Facc_alto_costo" style="display: none;"><%# Eval("facc_alto_costo")%></span>
                                                                            <span id="Terc_nombre" style="display: none;"><%# Eval("terc_nombre")%></span>
                                                                            <span id="Facf_confirmacion" style="display: none;"><%# Eval("facf_confirmacion")%></span>
                                                                            <span id="Facv_copago" style="display: none;"><%# Eval("facv_copago")%></span>
                                                                            <span id="Facv_responsable" style="display: none;"><%# Eval("facv_responsable")%></span>
                                                                            <span id="Facc_conciliado" style="display: none;"><%# Eval("facc_conciliado")%></span>
                                                                            <span id="Facv_imputable" style="display: none;"><%# Eval("facv_imputable")%></span>
                                                                            <span id="Facf_radicado" style="display: none;"><%# Eval("facf_radicado")%></span>
                                                                            <span id="Facf_final" style="display: none;"><%# Eval("facf_final")%></span>
                                                                            <span id="Facc_almacenamiento" style="display: none;"><%# Eval("facc_almacenamiento")%></span>
                                                                            <span id="Cntc_concepto" style="display: none;"><%# Eval("cntc_concepto")%></span>
                                                                            <span id="Conc_nombre" style="display: none;"><%# Eval("conc_nombre")%></span>
                                                                            <span id="Facv_tercero" style="display: none;"><%# Eval("facv_tercero")%></span>
                                                                            <span id="FechaProcedencia" style="display: none;"><%# Eval("FechaProcedencia")%></span>
                                                                            <span id="Facn_recibo" style="display: none;"><%# Eval("facn_recibo")%></span>
                                                                        </DataItemTemplate>
                                                                    </dxwgv:GridViewDataTextColumn>
                                                                </Columns>

                                                                <Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

                                                                <StylesEditors>
                                                                    <ProgressBar Height="25px"></ProgressBar>
                                                                </StylesEditors>
                                                            </dxwgv:ASPxGridView>
                                                        </div>
                                                        <div id="tab-2" style="display: none;" class="rm_edit_content">
                                                            <div style="text-align: center">
                                                                <div class="rm_contenedormensaje">
                                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                                </div>
                                                                <br />
                                                                <table style="text-align: center">
                                                                    <tr>
                                                                        <td class="rm_align_left">
                                                                            <asp:Button ID="btnEdit" CssClass="btns2" runat="server" Text="Editar..." OnClick="btnEdit_Click" OnClientClick="putNewDetalle();" />
                                                                        </td>
                                                                        <td>
                                                                            <h2>Editar</h2>
                                                                        </td>
                                                                        <td class="rm_align_rigth">
                                                                            <input type="button" id="btnRegresar" onclick="Regresar();" class="btns2"
                                                                                value="<< Regresar" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <br />
                                                            <div id="DivCuerpo" class="rm_edit_body">
                                                                <table>
                                                                    <tr>
                                                                        <td class="rm_title rm_align_left">
                                                                            <p>Numero de Radicado:</p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRadicadoCodigo" CssClass="txtRadicadoCodigo" onkeydown="return false;" ClientIDMode="Static" AutoPostBack="False" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Fecha radicaci&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="spm_fecharadicacion" CssClass="spm_fecharadicacion" ClientIDMode="Static"
                                                                                Enabled="false" onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                NIT Prestador:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtProcNui" CssClass="txtProcNui" ClientIDMode="Static" Enabled="false"
                                                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Nombre prestador:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="spm_procedencia" CssClass="procedencia" ClientIDMode="Static" Enabled="false"
                                                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Detalle:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxAreaDetalle" CssClass="txtDetalle" runat="server" ClientIDMode="Static"
                                                                                AutoPostBack="False" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Comprobantes de egreso:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_compEgreso" CssClass="txt_compEgreso" ClientIDMode="Static" Enabled="false"
                                                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Agregar comprobantes<br />
                                                                                de egreso:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCompEgreso" CssClass="rm_compegreso" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btnAdd" CssClass="rm_btnadd" ToolTip="Agregar Comprobantes" runat="server" ImageUrl="~/AlfaNetConsultas/Gestion/image_ConsultasFactura/Add.png" OnClick="btnAdd_Click" OnClientClick="putClicked();" />

                                                                        </td>
                                                                        <td>
                                                                            <asp:RegularExpressionValidator ID="revValidateNumsCompEgreso" ControlToValidate="txtCompEgreso"
                                                                                ValidationGroup="validar" ValidationExpression="\d+" runat="server" ErrorMessage="Campo Numérico."></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:ListBox ID="lbxCompEgreso" CssClass="rm_lbxCompEgreso" runat="server"></asp:ListBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Registro Oasis:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRegistroOasis" CssClass="txtRegistroOasis" ClientIDMode="Static"
                                                                                Enabled="false" onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Nº Remisi&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRemision" CssClass="txtRemision" ClientIDMode="Static" Enabled="false"
                                                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                N&uacute;mero factura prestador:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacPrestador" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacPrestador" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Expediente:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtExpediente2" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtExpediente" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Empresa:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacn_empresa" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacn_empresa" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Tipo documento:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_documento" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_documento" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Ubicaci&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacn_ubicacion" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacn_ubicacion" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Valor factura:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacv_total" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacv_total" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Estado:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_estado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_estado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Prefijo:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_prefijo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_prefijo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                N&uacute;mero factura:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacn_factura2" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacn_factura2" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Alto costo:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_alto_costo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_alto_costo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Fecha de confirmaci&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacf_confirmacion" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacf_confirmacion" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Copago:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacv_copago" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacv_copago" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Responsable:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacv_responsable" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacv_responsable" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Conciliaci&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_conciliado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_conciliado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Imputable:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacv_imputable" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacv_imputable" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Fecha de radicaci&oacute;n Oasis:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacf_radicado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacf_radicado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Fecha de prestaci&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacf_final" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacf_final" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Digitalizado:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_digitalizado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_digitalizado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Unidad de almacenamiento:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacc_almacenamiento" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacc_almacenamiento" Enabled="true" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                C&oacute;digo modalidad:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCntc_concepto" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtCntc_concepto" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                Modalidad contrato:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtConc_nombre" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtConc_nombre" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <p class="rm_title">
                                                                                N&uacute;mero remisi&oacute;n:
                                                                            </p>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFacn_recibo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                                                CssClass="txtFacn_recibo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
																	<tr>
                                                                        <td>
  
                                                                            <asp:TextBox ID="txtdatosRow" runat="server" TextMode="MultiLine" CssClass="txtdatosRow" AutoPostBack="False" Enabled="true" ClientIDMode="Static"></asp:TextBox>

                                                                        </td>
                                                                    </tr>


                                                                </table>
                                                            </div>

                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="ButtonSaveAs"></asp:PostBackTrigger>
                                                        <asp:PostBackTrigger ControlID="ButtonOpen"></asp:PostBackTrigger>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>--%>
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
                <asp:ObjectDataSource ID="ODSBuscar" runat="server" SelectMethod="BuscarRad" TypeName="FacturaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="Radicador" Type="String" />
                        <asp:Parameter Name="porImagen" Type="String" />
                        <asp:Parameter Name="radInicial" Type="String" />
                        <asp:Parameter Name="radFinal" Type="String" />
                        <asp:Parameter Name="comEgresoIni" Type="String" />
                        <asp:Parameter Name="comEgresoFin" Type="String" />
                        <asp:Parameter Name="fechaInicial" Type="String" />
                        <asp:Parameter Name="fechaFinal" Type="String" />
                        <asp:Parameter Name="FacnReciboIni" Type="String" />
                        <asp:Parameter Name="FacnReciboFin" Type="String" />
                        <asp:Parameter Name="facValorMenor" Type="String" />
                        <asp:Parameter Name="facValorMayor" Type="String" />
                        <asp:Parameter Name="numFacIni" Type="String" />
                        <asp:Parameter Name="numFacFinal" Type="String" />
                        <asp:Parameter Name="nombreNit" Type="String" />
                        <asp:Parameter Name="detalle" Type="String" />
                        <asp:Parameter Name="ubicacion" Type="String" />
                        <asp:Parameter Name="modalidad" Type="String" />
                        <asp:Parameter Name="unidad" Type="String" />
                        <asp:Parameter Name="expediente" Type="String" />
                        <asp:Parameter Name="ciudadInicial" Type="String" />
                        <asp:Parameter Name="ciudadFinal" Type="String" />

                    </SelectParameters>
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
    <asp:HiddenField id="datosRow" runat="server" Value="" />

</asp:Content>

