<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ConsultaPrestamos.aspx.cs" Inherits="_ConsultaPrestamos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Import Namespace="System.Configuration" %>
<%--<%@ Register Src="../NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc1" %>
<%@ Register Src="NavDocRecibido.ascx" TagName="NavDocRecibido" TagPrefix="uc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="global">
    <script language="javascript" type="text/javascript">
// <!CDATA[
        function OnTreeSerieClick(evt) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick) {        
           //innerText works in IE but fails in Firefox (I'm sick of browser anomalies), so use innerHTML as well        
           var nodeText = src.innerText || src.innerHTML;        
           var nodeText = document.getElementById("<%=TxtBProcedencia.ClientID%>");
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
           var nodeText = document.getElementById("<%=TxtBDestino.ClientID%>");
           nodeText.innerText = src.innerText; 
        }
        }
// ]]>
    </script>

    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td style="width: 100%;">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="280px" BackColor="White"><TABLE style="WIDTH: 385px"><TR><TD style="BACKGROUND-COLOR: silver" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 5%; BACKGROUND-COLOR: silver"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ValidationGroup="789" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px" align=center colSpan=2><BR /><asp:Label id="LblMessageBox" runat="server" Font-Size="XX-Large" ForeColor="Black"></asp:Label> </TD></TR></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" BackgroundCssClass="MessageStyle" TargetControlID="LblMessageBox" PopupControlID="PnlMensaje">
                        </cc1:ModalPopupExtender> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <cc1:Accordion ID="MyAccordion" runat="server" Width="100%" TransitionDuration="250"
                    SuppressHeaderPostbacks="true" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" FramesPerSecond="40" FadeTransitions="false"
                    ContentCssClass="accordionContent" AutoSize="None">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Consulta de Prestamos.:</a>
                            </Header>
                            <Content>
                               <TABLE style="WIDTH: 100%; TEXT-ALIGN: left" 
forecolor="White"><TBODY><TR><TD 
style="WIDTH: 489px; COLOR: white; HEIGHT: 16px; BACKGROUND-COLOR: #507cd1; TEXT-ALIGN: center">Consulta de Prestamos Realizados </TD></TR><TR><TD 
style="WIDTH: 100%; HEIGHT: 8px; BACKGROUND-COLOR: #eff3fb" colSpan=3><asp:UpdatePanel id="UpdatePanelFechas" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBFechaRad" runat="server" Width="185px" Text="Entre Fechas de Prestamo" AutoPostBack="True" OnCheckedChanged="ChBFechaRad_CheckedChanged"></asp:CheckBox> <BR /><cc1:CalendarExtender id="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" PopupButtonID="ImgCalendarFinal" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarInicial" runat="server" TargetControlID="TxtFechaInicial" PopupButtonID="ImgCalendarInicial" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender> <asp:Label id="LblFechaInicial" runat="server" Width="70px" Text="Fecha Inicial" Visible="False"></asp:Label> <asp:TextBox id="TxtFechaInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image> <asp:Label id="LblFechaFinal" runat="server" Width="70px" Visible="False">FechaFinal</asp:Label> <asp:TextBox id="TxtFechaFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> <asp:Image id="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="False"></asp:Image> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBFechaRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UpdatePanelNroRad" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
<asp:CheckBox id="ChBNroRad" runat="server" Width="181px" Text="Entre Números de Prestamos" AutoPostBack="True" OnCheckedChanged="ChBNroRad_CheckedChanged"></asp:CheckBox><BR /><asp:Label id="LblNroRadInicial" runat="server" Width="120px" Text="Numero Prestamo Inicial" Visible="False"></asp:Label><asp:TextBox id="TxtNroRadInicial" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox><asp:Label id="LblNroRadFinal" runat="server" Width="120px" Visible="False">Numero Prestamo Final</asp:Label><asp:TextBox id="TxtNroRadFinal" runat="server" Width="70px" Font-Size="8pt" Visible="False"></asp:TextBox> 
</ContentTemplate>
                                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBNroRad" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                            </asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #eff3fb"><asp:UpdatePanel id="UpdatePanelDestino" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBDestino" runat="server" Width="185px" Text="Por Dependencia" OnCheckedChanged="ChBDestino_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR /><asp:Label id="LblDestino" runat="server" Width="60px" Visible="False" Text="Dependencia"></asp:Label><cc1:PopupControlExtender id="PopupControlDestino" runat="server" PopupControlID="PnlDestino" TargetControlID="TxtBDestino" Position="Right">
                                                    </cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteDestino" runat="server" TargetControlID="TxtBDestino" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender> <asp:TextBox id="TxtBDestino" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlDestino" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowLines="True">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <HoverNodeStyle Font-Underline="True" />
                                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                                                        Value="0"></asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                            </asp:TreeView>&nbsp;&nbsp; </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBDestino" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; BACKGROUND-COLOR: #ffffff"><asp:UpdatePanel id="UpdatePanelProcedencia" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBox id="ChBProcedencia" runat="server" Width="185px" Text="Por Serie" OnCheckedChanged="ChBProcedencia_CheckedChanged" AutoPostBack="True"></asp:CheckBox><BR /><asp:Label id="LblProcedencia" runat="server" Width="60px" Visible="False" Text="Serie"></asp:Label> <cc1:PopupControlExtender id="PopupControlSerie" runat="server" PopupControlID="PnlSerie" TargetControlID="TxtBProcedencia" Position="Right"></cc1:PopupControlExtender> <cc1:AutoCompleteExtender id="AutoCompleteProcedencia" runat="server" TargetControlID="TxtBProcedencia" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetSerieByText" ServicePath="../../AutoComplete.asmx" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> <asp:TextBox id="TxtBProcedencia" runat="server" Width="400px" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete"></asp:TextBox> <asp:Panel id="PnlSerie" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVSerie" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView>&nbsp; </DIV></asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ChBProcedencia" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD 
style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #507cd1" colSpan=3><asp:Table id="Table3" runat="server" Width="125px" ForeColor="White" Height="30px" CellSpacing="4" CellPadding="0">
                                                <asp:TableRow ID="TableRow1" runat="server">
                                                    <asp:TableCell ID="clBuscar" runat="server" CssClass="BarButton">
                                                        <asp:LinkButton ID="cmdBuscar" ForeColor="White" runat="server" BorderStyle="None"
                                                            CssClass="CommandButton" OnClick="cmdBuscar_Click" TabIndex="24" Text="Buscar"></asp:LinkButton>
                                                    </asp:TableCell>
                                                    <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                                        <asp:LinkButton ID="Nuevo" runat="server" ForeColor="White" BorderStyle="None" CausesValidation="False"
                                                            CssClass="CommandButton" OnClick="BtnNuevo_Click" TabIndex="24" Text="Nueva Busqueda"></asp:LinkButton>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>                       
                                                                                
                                                          
</TD></TR></TBODY></TABLE>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados.:</a>
                            </Header>
                            <Content>
                            <asp:GridView id="GVBuscar" runat="server" Width="100%" DataSourceID="ODSBuscar" Font-Size="Smaller" ForeColor="#333333" CellPadding="1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PrestamoCodigo,WFMovimientoFecha,DependenciaCodigo,SerieCodigo,PrestamoCarpeta,GrupoCodigo,SerieNombre,DependenciaNombre" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField Visible="False"><EditItemTemplate>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:CheckBox ID="SelectorDocumento" runat="server"   />
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Prestamo No." SortExpression="PrestamoCodigo"><EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PrestamoCodigo") %>'>
                                </asp:Label>
                            
</EditItemTemplate>
<FooterTemplate>
                            
</FooterTemplate>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                    Text='<%# Eval("PrestamoCodigo") %>' Visible="False"></asp:LinkButton>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("PrestamoCodigo") %>'></asp:Label>
                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha de Prestamo" SortExpression="WFMovimientoFecha"><EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Carpeta" SortExpression="PrestamoCarpeta"><EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Serie" SortExpression="SerieNombre"><EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia" SortExpression="DependenciaNombre"><EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha de Devolucion" SortExpression="WFMovimientoFecha"><EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoFechaDevolucion") %>'></asp:TextBox>
                            
</EditItemTemplate>
<ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("WFMovimientoFechaDevolucion") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo" Visible="False"><ItemTemplate>
                                <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo={0}&GrupoCodigo=1&Admon=S") %>'
                                    Target="_blank" Text="Imagenes"></asp:HyperLink>
                                <br   />
                                <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}&Admon=S") %>'
                                    Target="_blank" Width="55px">Historico</asp:HyperLink>
                            
</ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<EmptyDataTemplate>
                        No Hay Prestamos que correspondan con la combinacion de criterios de busqueda!
                    
</EmptyDataTemplate>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
                            </Content>
                        </cc1:AccordionPane>
                         <cc1:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Reporte.:</a>
                            </Header>
                            <Content>
                               <rsweb:reportviewer id="ReportViewer1" runat="server" width="100%" height="400px" font-size="8pt" font-names="Verdana">
<LocalReport ReportPath="AlfaNetControlPrestamos\AlfaNetPrestamos\Prestamos.rdlc"><DataSources>
<rsweb:ReportDataSource Name="DSPrestamos_Prestamos" DataSourceId="ODSBuscar"></rsweb:ReportDataSource>
</DataSources>
</LocalReport>
</rsweb:reportviewer>

                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
                
                <asp:ObjectDataSource id="ODSBuscar" runat="server" InsertMethod="Terminar_Prestamos" TypeName="PrestamosBLL" SelectMethod="GetConsultasPrestamos" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:Parameter Name="PrestamoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="PrestamoCodigo1" Type="String"></asp:Parameter>
<asp:Parameter Name="WFMovimientoFecha" Type="String"></asp:Parameter>
<asp:Parameter Name="WFMovimientoFecha1" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
</SelectParameters>
<InsertParameters>
<asp:Parameter Name="PrestamoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFMovimientoFechaDevolucion" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="PrestamoEstado" Type="String"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource>
                                
            </td>
        </tr>
        <tr>
            <td style="width: 591px">
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="420px"></asp:Label>
                <asp:ValidationSummary Style="vertical-align: middle; text-align: left" ID="ValidationSummaryRadicado"
                    runat="server" Width="418px" Height="1px" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
