<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaUnidad.aspx.cs" Inherits="ConsultaUnidad" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="System.Configuration" %>

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


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<script type="text/javascript">
    var postponedCallbackRequired = false;
    function OnListBoxIndexChanged(s, e) {
        if (CallbackPanel.InCallback())
            postponedCallbackRequired = true;
        else
            CallbackPanel.PerformCallback();
    }
    function OnEndCallback(s, e) {
        if (postponedCallbackRequired) {
            CallbackPanel.PerformCallback();
            postponedCallbackRequired = false;
        }
    }

   
    </script>
<head id="Head1" runat="server">
    <title></title>   
</head>
<body>
    <link href="AlfaNetStyle.css" rel="stylesheet" type="text/css" />
<form id="form1" runat="server">    
    <table style="font-size: 8pt; width: 100%;">
            <tr>
            <td>
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                    SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                    ContentCssClass="accordionContent" AutoSize="None" Height="921px">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="" >
                            <Header>
                                <a class="accordionLink" href="">Unidades Documentales.:</a>
                            </Header>
                            <Content>
                                <table style="width:100%; text-align:left; color:Black" >
                                    <tbody>
                                        <tr>
                                            <td style="WIDTH: 489px; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">Consulta Inventario Unidades Documentales
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; HEIGHT: 8px; BACKGROUND-COLOR: #eff3fb" colspan:3>
                                                <asp:UpdatePanel id="UpdatePanelFechas" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox id="ChBFechaUni" runat="server" Width="185px" Text="Entre Fechas Extremas" OnCheckedChanged="ChBFechaUni_CheckedChanged" AutoPostBack="True">
                                                        </asp:CheckBox>
                                                        <br />
                                                        <br />
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
                                                        <cc1:CalendarExtender id="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinal">
                                                        </cc1:CalendarExtender> 
                                                        <cc1:CalendarExtender id="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarInicial">
                                                        </cc1:CalendarExtender> 
                                                        <asp:Label id="LblFechaInicial" runat="server" Width="120px" Text="Fecha Inicial" Visible="False">
                                                            Fecha Extrema Inicial
                                                        </asp:Label> 
                                                        <asp:TextBox id="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False">
                                                        </asp:TextBox>
                                                        <asp:Image id="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/Imagenes/calendario.png" Visible="False">
                                                        </asp:Image> 
                                                        <asp:Label id="LblFechaFinal" runat="server" Width="120px" Visible="False">
                                                            Fecha Extrema Final
                                                        </asp:Label> 
                                                        <asp:TextBox id="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False">
                                                        </asp:TextBox> 
                                                        <asp:Image id="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/Imagenes/calendario.png" Visible="False">
                                                        </asp:Image>
                                                     </ContentTemplate>
                                                     <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ChBFechaUni" EventName="CheckedChanged">
                                                        </asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                            <asp:UpdatePanel id="UpdatePanelUnidCod" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="ChBUnidCod" runat="server" Text="Entre Unidades Documentales" Width="181px" OnCheckedChanged="ChBUnidCod_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                        <asp:Label ID="LblUnidCodInicial" runat="server" Text="Unidad Codigo Inicial" Visible="False" Width="120px">
                                                            Unidad Codigo Inicial
                                                        </asp:Label>
                                                        <asp:TextBox ID="TxtUnidCodInicial" runat="server" Font-Size="8pt" Visible="False" Width="70px">
                                                        </asp:TextBox>
                                                        <asp:Label ID="LblUnidCodFinal" runat="server" Visible="False" Width="120px">
                                                            Unidad Codigo Final
                                                        </asp:Label><asp:TextBox ID="TxtUnidCodFinal" runat="server" Font-Size="8pt" Visible="False" Width="70px">
                                                        </asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBUnidCod" EventName="CheckedChanged"/>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb">
                                            <asp:UpdatePanel id="UpdatePanelDependencia" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox id="ChBDependencia" runat="server" Width="300px" Text="Por Dependencia ...(Seleccione o ingrese criterio)" AutoPostBack="True" OnCheckedChanged="ChBDependencia_CheckedChanged">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label id="LblDependencia" runat="server" Width="60px" Visible="False" Text="Dependencia">
                                                    </asp:Label>
                                                    <cc1:PopupControlExtender id="PopupControlDependencia" runat="server" PopupControlID="PnlDependencia" TargetControlID="TxtBDependencia" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteDependencia" runat="server" TargetControlID="TxtBDependencia" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox id="TxtBDependencia" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox>
                                                    <asp:Panel id="PnlDependencia" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVDependencia" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                    <HoverNodeStyle Font-Underline="True">
                                                                    </HoverNodeStyle>
                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                            </asp:TreeView> 
                                                         </div>
                                                     </asp:Panel>
                                                 </ContentTemplate>
                                                 <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBDependencia" EventName="CheckedChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                 </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                            <asp:UpdatePanel id="UpdatePanelNombreUnidad" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox id="ChBNombreUnidad" runat="server" Width="300px" Text="Nombre Unidad" AutoPostBack="True" OnCheckedChanged="ChBNombreUnidad_CheckedChanged">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label id="LblNombreUnidad" runat="server" Width="120px" Visible="False" Text="Nombre Unidad">
                                                    </asp:Label>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteNombreUnidad" runat="server" TargetControlID="TxtBNombreUnidad" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetNombreUnidadByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox id="TxtBNombreUnidad" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox>
                                                 </ContentTemplate>
                                                 <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBNombreUnidad" EventName="CheckedChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                 </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb">
                                            <asp:UpdatePanel id="UpdatePanelSoporte" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="ChBUbicacion" runat="server" Text="Ubicación Geografica" Width="181px" OnCheckedChanged="ChBUbicacion_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                        <asp:Label ID="LblUbicacion" runat="server" Text="Ubicacion Geografica" Visible="False" Width="120px">
                                                            Ubicacion Geografica
                                                        </asp:Label>
                                                        <cc1:AutoCompleteExtender id="AutoCompleteExtenderUbicacion" runat="server" TargetControlID="TxtBUbicacion" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetUbicacionByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                        <asp:TextBox ID="TxtBUbicacion" runat="server" Font-Size="8pt" Visible="False" Width="200px">
                                                        </asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBUbicacion" EventName="CheckedChanged"/>
                                                </Triggers>
                                            </asp:UpdatePanel>                                                         
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                            <asp:UpdatePanel id="UpdatePanelForma" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="ChBForma" runat="server" Text="Forma de Conservación" Width="181px" OnCheckedChanged="ChBForma_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label ID="LblForma" runat="server" Text="FormadeConservacion" Visible="False" Width="120px">
                                                        Forma de Conservación
                                                    </asp:Label>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteExtenderForma" runat="server" TargetControlID="TxtBForma" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetFormaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox ID="TxtBForma" runat="server" Font-Size="8pt" Visible="False" Width="200px">
                                                    </asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBForma" EventName="CheckedChanged"/>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colspan="3">
                                            <asp:UpdatePanel id="UpdatePanelSerie" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox id="ChBSerie" runat="server" Width="185px" Text="Por Serie Documental" OnCheckedChanged="ChBSerie_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label id="LblSerie" runat="server" Width="120px" Visible="False" Text="Serie Documental">
                                                    </asp:Label>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteSerie" runat="server" TargetControlID="TxtBSerie" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetSerieByTextNull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <cc1:PopupControlExtender id="PopupControlSerie" runat="server" PopupControlID="PnlSerie" TargetControlID="TxtBSerie" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <asp:TextBox id="TxtBSerie" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox>
                                                    <asp:Panel id="PnlSerie" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVSerie" runat="server" Width="300px" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" OnSelectedNodeChanged="TreeVSerie_SelectedNodeChanged" ExpandDepth="0" ImageSet="XPFileExplorer" NodeIndent="15">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA">
                                                                </HoverNodeStyle>
                                                                <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="False" BackColor="#B5B5B5">
                                                                </SelectedNodeStyle>
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..." Value="0">
                                                                    </asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                </NodeStyle>
                                                            </asp:TreeView>
                                                        </div>
                                                    </asp:Panel>
                                              </ContentTemplate>
                                          </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                            <asp:UpdatePanel id="UPAccion" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox id="ChBAccion" runat="server" Width="185px" Text="Por Accion" AutoPostBack="True" OnCheckedChanged="ChBAccion_CheckedChanged">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label id="LblAccion" runat="server" Width="85px" Visible="False" Text="Accion">
                                                    </asp:Label>
                                                    <asp:RequiredFieldValidator id="RFVAccion" runat="server" ValidationGroup="Buscar" ControlToValidate="TxtBAccion" ErrorMessage="*" Enabled="False">
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteAccion" runat="server" TargetControlID="TxtBAccion" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <cc1:PopupControlExtender id="PopupControlAccion" runat="server" TargetControlID="TxtBAccion" PopupControlID="PnlAccion" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <asp:Panel id="PnlAccion" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVAccion" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVAccion_TreeNodePopulate" OnSelectedNodeChanged="TreeVAccion_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                <HoverNodeStyle Font-Underline="True">
                                                                </HoverNodeStyle>
                                                                <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                </SelectedNodeStyle>
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Accion..." Value="0">
                                                                    </asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                </NodeStyle>
                                                            </asp:TreeView>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:TextBox id="TxtBAccion" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete">
                                                    </asp:TextBox> 
                                               </ContentTemplate>
                                          </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; HEIGHT: 17px; BACKGROUND-COLOR: #eff3fb" colspan="3">
                                            <asp:UpdatePanel id="UpdatePanelTipologia" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="ChBTipologia" runat="server" Text="Tipologia" Width="181px" OnCheckedChanged="ChBTipologia_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label ID="LblTipologia" runat="server" Text="Tipologia" Visible="False" Width="120px">
                                                        Tipologia
                                                    </asp:Label>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteExtenderTipologia" runat="server" TargetControlID="TxtBTipologia" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetTipologiaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox ID="TxtBTipologia" runat="server" Font-Size="8pt" Visible="False" Width="200px">
                                                    </asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBTipologia" EventName="CheckedChanged"/>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff">
                                            <asp:UpdatePanel id="UpdatePanelRegInventario" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="ChBRegInventario" runat="server" Text="Registro Inventario" Width="181px" OnCheckedChanged="ChBRegInventario_CheckedChanged" AutoPostBack="True">
                                                    </asp:CheckBox>
                                                    <br />
                                                    <br />
                                                        <asp:Label ID="LblRegInventario" runat="server" Text="Registro Inventario Fisico" Visible="False" Width="120px">
                                                            Registro Inventario Fisico
                                                        </asp:Label>
                                                        <asp:TextBox ID="TxtBRegInventario" runat="server" Font-Size="8pt" Visible="False" Width="70px">
                                                        </asp:TextBox>
                                                        
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBRegInventario" EventName="CheckedChanged"/>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #507cd1" colSpan=3>
                                                <table style="WIDTH: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Table id="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                                    <asp:TableRow ID="TableRow1" runat="server">
                                                                        <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                                            <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None" CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar">
                                                                            </asp:LinkButton>
                                                                        </asp:TableCell> 
                                                                            <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton"> 
                                                                                <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False" CssClass="CommandButton"  OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda">
                                                                                    <a href="ConsultaUnidad.aspx">ConsultaUnidad.aspx</a>
                                                                                </asp:LinkButton>
                                                                            </asp:TableCell>
                                                                    </asp:TableRow>
                                                                </asp:Table>
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
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>                            
                            <Content>
                            <table>
                            <tbody>
                                <br />
                                <asp:Button ID = "btnExport" runat = "server" BackColor="#6592C1" Text= "Exportar a Excel" OnClick = "ExportToExcel" />
                                <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#A4C6F8" AutoGenerateColumns="False">
                                    <Columns>
                                       <asp:BoundField HeaderText="Registro Inventario" DataField="RegistroInventario" />
                                       <asp:BoundField HeaderText="Unidad Nombre" DataField="UnidadNombre" />
                                       <asp:BoundField HeaderText="Fecha Extrema Inicial" DataField="FechaExtremaInicial" />
                                       <asp:BoundField HeaderText="Fecha Extrema Final" DataField="FechaExtremaFinal" />
                                       <asp:BoundField HeaderText="Dependencia Nombre" DataField="DependenciaNombre" />
                                       <asp:BoundField HeaderText="Ubicacion Nombre" DataField="UbicacionNombre" />
                                       <asp:BoundField HeaderText="Forma Nombre" DataField="FormaNombre" />
                                       <asp:BoundField HeaderText="Numero Folios" DataField="NumeroFolios" />
                                       <asp:BoundField HeaderText="Serie Nombre" DataField="SerieNombre" />
                                       <asp:BoundField HeaderText="Accion Nombre" DataField="WFAccionNombre" />
                                       <asp:BoundField HeaderText="Tipologia Nombre" DataField="TipologiaNombre" />
                                       <asp:BoundField HeaderText="Unidad Detalle" DataField="UnidadDetalle" />
                                       <asp:BoundField HeaderText="Unidad Codigo" DataField="UnidadCodigo" />

<%--                                       <asp:BoundField HeaderText="Unidad Codigo" DataField="UnidadCodigo" />
                                       <asp:BoundField HeaderText="Fecha Extrema Inicial" DataField="FechaExtremaInicial" />
                                       <asp:BoundField HeaderText="Fecha Extrema Final" DataField="FechaExtremaFinal" />
                                       <asp:BoundField HeaderText="Unidad Nombre" DataField="UnidadNombre" />
                                       <asp:BoundField HeaderText="Unidad Detalle" DataField="UnidadDetalle" />
                                       <asp:BoundField HeaderText="Dependencia Nombre" DataField="DependenciaNombre" />
                                       <asp:BoundField HeaderText="Ubicacion Nombre" DataField="UbicacionNombre" />
                                       <asp:BoundField HeaderText="Forma Nombre" DataField="FormaNombre" />
                                       <asp:BoundField HeaderText="Numero Folios" DataField="NumeroFolios" />
                                       <asp:BoundField HeaderText="Serie Nombre" DataField="SerieNombre" />
                                       <asp:BoundField HeaderText="Accion Nombre" DataField="WFAccionNombre" />
                                       <asp:BoundField HeaderText="Tipologia Nombre" DataField="TipologiaNombre" />
                                       <asp:BoundField HeaderText="Registro Inventario" DataField="RegistroInventario" />--%>                                                                      
                                       <asp:TemplateField  HeaderText="Imagenes">                               
                                            <ItemTemplate>

                                                   <asp:LinkButton ID="LinkButton1" OnClick= "LinkImagenes_Click" CommandName ="RegistroInventario" CommandArgument = '<%#Eval("RegistroInventario")%>' runat="server">Imagenes</asp:LinkButton>
                                             
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </tbody>
                            </table>
                            </Content>
                            </cc1:AccordionPane>
                     </Panes>
                </cc1:Accordion>
                </td>
                </tr>
             
    </table>
</form>
<asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red" Width="100%">
</asp:Label>
<asp:Literal ID="literalMensaje" runat="server"/>
</body>
</html>