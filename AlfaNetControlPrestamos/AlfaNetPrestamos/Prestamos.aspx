<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="Prestamos.aspx.cs" Inherits="_Prestamos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR>
        <td style="width: 10%; text-align: center">
        </td>
        <TD style="WIDTH: 735px; TEXT-ALIGN: center"> &nbsp;<BR /><asp:Label id="LblTitulo" runat="server" Text=".:Control de Prestamos:." Font-Size="Small" Font-Bold="True" CssClass="LabelStyle"></asp:Label><BR />   &nbsp;&nbsp;
            <TABLE 
style="TEXT-ALIGN: left; width: 100%;"><TBODY><TR><TD style="HEIGHT: 46px"><asp:RequiredFieldValidator id="RFVPrestamo" runat="server" ValidationGroup="Buscar" ErrorMessage="Debe Ingresar un Número de Prestamo Pra la Consulta" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator></TD><TD 
style="HEIGHT: 46px" colSpan=2><asp:Label id="Label1" runat="server" Text="* Número de prestamo" CssClass="LabelStyle"></asp:Label> 
<asp:TextBox id="TextBox1" runat="server" Width="175px" CssClass="TxtAutoComplete"></asp:TextBox> 
<asp:ImageButton id="ImgBtn" onclick="ImgBtn_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="Buscar"></asp:ImageButton><ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TextBox1" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetPrestamoByCodigo" MinimumPrefixLength="0">
                            </ajaxToolkit:AutoCompleteExtender> </TD><TD 
style="HEIGHT: 46px"></TD></TR><TR><TD></TD><TD colSpan=2> <asp:Label style="TEXT-ALIGN: left" id="Label22" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></TD><TD></TD></TR><TR><TD><asp:RequiredFieldValidator id="RFVSerie" runat="server" ErrorMessage="Debe Selecciona una Serie para Prestamo" ControlToValidate="TxtBSerie">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblSerie" runat="server" Text="* Serie para prestamo.:" CssClass="LabelStyle"></asp:Label> 
<ajaxToolkit:AutoCompleteExtender id="ACSerie" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtBSerie" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="1">
                            </ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCESerie" runat="server" TargetControlID="ImgTreeSerie" PopupControlID="PnlSerie">
                            </ajaxToolkit:PopupControlExtender> </TD><TD><asp:TextBox id="TxtBSerie" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD><asp:Image id="ImgTreeSerie" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> 
<asp:Panel style="LEFT: 1px" id="PnlSerie" runat="server" Width="350px" CssClass="popupControl" HorizontalAlign="Left" ScrollBars="Vertical" Height="300px"><DIV><asp:TreeView id="TreeVSerie" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ExpandDepth="0">
                                        <ParentNodeStyle Font-Bold="False"  />
                                        <HoverNodeStyle Font-Underline="True"  />
                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"  />
                                        <Nodes>
                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..."
                                    Value="0"></asp:TreeNode>
                                        </Nodes>
                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px"  />
                                    </asp:TreeView> &nbsp; </DIV></asp:Panel> 
</TD></TR><TR><TD><asp:RequiredFieldValidator id="RFVCarpeta" runat="server" ErrorMessage="Debe Digitar el Nombre de la Carpeta para Prestamo" ControlToValidate="TxtBCarpeta">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblCarpeta" runat="server" Text="* Carpeta para prestamo.:" CssClass="LabelStyle"></asp:Label></TD><TD><asp:TextBox id="TxtBCarpeta" runat="server" Width="350px"></asp:TextBox></TD><TD></TD></TR><TR><TD><asp:RequiredFieldValidator id="RFVDependencia" runat="server" ErrorMessage="Debe Selecciona una Dependencia para Prestamo" ControlToValidate="TxtBDependencia">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblDependencia" runat="server" Text="* Dependencia para prestamo.:" CssClass="LabelStyle"></asp:Label> 
<ajaxToolkit:AutoCompleteExtender id="ACDependenica" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TxtBDependencia" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="1">
                            </ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCEDependencia" runat="server" TargetControlID="ImgTreeDependencia" PopupControlID="PnlDependencia">
                            </ajaxToolkit:PopupControlExtender> </TD><TD><asp:TextBox id="TxtBDependencia" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD><asp:Image id="ImgTreeDependencia" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:Image> 
<asp:Panel style="LEFT: 1px" id="PnlDependencia" runat="server" Width="350px" CssClass="popupControl" HorizontalAlign="Left" ScrollBars="Vertical" Height="300px"><DIV><asp:TreeView id="TreeVDependencia" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ExpandDepth="0">
                                        <ParentNodeStyle Font-Bold="False"  />
                                        <HoverNodeStyle Font-Underline="True"  />
                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"  />
                                        <Nodes>
                                            <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                    Value="0"></asp:TreeNode>
                                        </Nodes>
                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px"  />
                                    </asp:TreeView> &nbsp; </DIV></asp:Panel> 
</TD></TR><TR><TD style="HEIGHT: 21px" 
colSpan=1></TD><TD style="HEIGHT: 21px" 
colSpan=3><asp:HiddenField id="HFWFMovimientoFecha" runat="server"></asp:HiddenField> 
</TD></TR><TR><TD colSpan=1></TD><TD colSpan=3><asp:Table id="Table3" runat="server" CellSpacing="2" CellPadding="0">
                                <asp:TableRow ID="TableRow1" runat="server">
                                    <asp:TableCell ID="clAceptar" runat="server" CssClass="BarButton">
                                        <asp:LinkButton ID="cmdAceptar" runat="server" OnClick="cmdAceptar_Click" Text="Prestar" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell1" runat="server">|</asp:TableCell>
                                    <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                        <asp:LinkButton ID="cmdNuevo" runat="server" CausesValidation="false" OnClick="BtnNuevo_Click"
                                            Text="Nuevo" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell2" runat="server">|</asp:TableCell>
                                    <asp:TableCell ID="clModificar" runat="server" CssClass="BarButton">
                                        <asp:LinkButton ID="cmdActualizar" runat="server" OnClick="cmdActualizar_Click" Text="Actualizar" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                    </asp:TableCell>
                                   </asp:TableRow>
                            </asp:Table> <asp:ObjectDataSource id="ODSPrestamos" runat="server" TypeName="PrestamosBLL" SelectMethod="GetPrestamos" OldValuesParameterFormatString="original_{0}" InsertMethod="Create_Prestamos">
                                <InsertParameters>
                                    <asp:Parameter Name="PrestamoCodigo" Type="String"  />
                                    <asp:Parameter Name="GrupoCodigo" Type="String"  />
                                    <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"  />
                                    <asp:Parameter Name="DependenciaCodigo" Type="String"  />
                                    <asp:Parameter Name="SerieCodigo" Type="String"  />
                                    <asp:Parameter Name="PrestamoCarpeta" Type="String"  />
                                </InsertParameters>
                            </asp:ObjectDataSource> <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="PnlMensaje" runat="server" BackColor="ButtonHighlight" Style="display: none">
                                        <table>
                                            <tr>
                                                <td align="center" style="background-color: gray">
                                                    <asp:Label ID="Label555" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                                        Text="Mensaje" Width="120px"></asp:Label></td>
                                                <td style="width: 5%; background-color: gray">
                                                    <asp:ImageButton ID="btnCerrar" runat="server" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                                                        Style="vertical-align: top" ValidationGroup="789"  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Label ID="LblMessageBox" runat="server" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajaxToolkit:modalpopupextender id="ModalPopupExtender1" runat="server" backgroundcssclass="MessageStyle"
                                        popupcontrolid="PnlMensaje" targetcontrolid="LblMessageBox">
                                        </ajaxToolkit:modalpopupextender>
                                </ContentTemplate>
                            </asp:UpdatePanel> </TD></TR><TR><TD colSpan=1></TD><TD colSpan=3><asp:ValidationSummary style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="ValidationSummaryRadicado" runat="server" Width="100%" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary> 
<asp:ValidationSummary style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="ValidationSummary1" runat="server" Width="100%" Font-Size="10pt" ValidationGroup="Buscar" DisplayMode="List"></asp:ValidationSummary> 
<asp:Label id="ExceptionDetails" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD></TR><TR><TD colSpan=1></TD><TD colSpan=3> &nbsp;</TD></TR></TBODY></TABLE></TD>
        <td style="width: 10%; text-align: center">
        </td>
    </TR><TR></TR><TR></TR></TBODY></TABLE>
</asp:Content>



