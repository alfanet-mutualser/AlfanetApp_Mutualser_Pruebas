<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ReArchviar.aspx.cs" Inherits="_ReArchviar" %>

<%@ import Namespace="System.Configuration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
 <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD><TABLE 
style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; width: 100%;" 
border=0><TBODY><TR>
    <td colspan="1" style="width: 10%">
    </td>
    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><Ajax:TextBoxWatermarkExtender id="TBWDocumento" watermarkText="Digite Numero de Documento..." runat="server" TargetControlID="TxtDocumento">
                </Ajax:TextBoxWatermarkExtender> <Ajax:AutoCompleteExtender id="ACDocumento" runat="server" TargetControlID="TxtDocumento" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDocArchivadosRecibidos" MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
        CompletionListItemCssClass="autocomplete_listItem " 
        CompletionListCssClass="autocomplete_completionListElement">
                </Ajax:AutoCompleteExtender> </TD>
    <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
    </td>
</TR><TR>
                    <td colspan="1" style="width: 20%">
                    </td>
                    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtDocumento">*</asp:RequiredFieldValidator> 
<asp:Label id="LblDocumento" runat="server" Width="176px" BackColor="CornflowerBlue" BorderColor="#B5C7DE" ForeColor="White" Text="* Número Documento" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid"></asp:Label> 
<asp:TextBox id="TxtDocumento" runat="server" CssClass="TxtAutoComplete"></asp:TextBox> 
<asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton></TD>
                    <td colspan="1" style="vertical-align: middle; width: 20%; text-align: center">
                    </td>
                </TR><TR>
    <td colspan="1" style="width: 10%">
    </td>
    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><STRONG><EM><SPAN 
style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="109px" ForeColor="RoyalBlue" Text="Buscar Por Grupo: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None"></asp:Label><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Italic="False" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">Radicados</asp:ListItem>
                            </asp:RadioButtonList></TD>
    <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
    </td>
</TR><TR>
                                <td colspan="1" style="width: 10%">
                                </td>
                                <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVDocumento" runat="server" Width="100%" ForeColor="#333333" DataKeyNames="NumeroDocumento,WFMovimientoPaso,DependenciaCodigo,WFMovimientoTipo,GrupoCodigo,WFMovimientoNotas,WFAccionNombre,Detalle,SerieCodigo" OnItemUpdated="DVDocumento_ItemUpdated" OnItemInserted="DVDocumento_ItemInserted" OnItemDeleted="DVDocumento_ItemDeleted" OnDataBound="DVDocumento_DataBound" GridLines="None" DataSourceID="CiudadByIdDataSource" CellPadding="4" AutoGenerateRows="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"  />
                    <RowStyle BackColor="#EFF3FB"  />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"  />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
                    <Fields>
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Numero Documento" ReadOnly="True"
                            SortExpression="NumeroDocumento" ></asp:BoundField>
                        <asp:BoundField DataField="WFMovimientoPaso" HeaderText="Paso" ReadOnly="True" SortExpression="WFMovimientoPaso" ></asp:BoundField>
                        <asp:TemplateField HeaderText="Dependencia Codigo Origen" SortExpression="DependenciaCodigo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DependenciaCodigo") %>'
                                    Width="98%"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DependenciaNombre" HeaderText="Dependencia Origen" SortExpression="DependenciaNombre" ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre" ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" ReadOnly="True" ></asp:BoundField>
                        <asp:TemplateField HeaderText="Serie Codigo" SortExpression="SerieCodigo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SerieCodigo") %>' Width="90%"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SerieNombre" HeaderText="Serie Nombre" SortExpression="SerieNombre" ReadOnly="True" ></asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png"
                                    OnClick="ImgBtnUpdateActualizar_Click"  />
                                &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False"
                                    CommandName="Cancel" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png"  />&nbsp;
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:ImageButton ID="ImgBtnInsert" runat="server" CommandName="Insert" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png"
                                    OnClick="ImgBtnInsert_Click" Visible="False"  />
                                &nbsp;<asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False"
                                    CommandName="Cancel" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" Visible="False"  />&nbsp;
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" OnClick="ImgBtnEdit_Click" Visible="False"  />
                                &nbsp;<asp:ImageButton ID="ImgBtnNew" runat="server" CausesValidation="False" CommandName="New"
                                    ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" OnClick="ImgBtnNew_Click" Visible="False"  />
                                &nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False"
                                    CommandName="Delete" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" OnClick="ImgBtnDelete_Click" Visible="False"  />&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#2461BF"  />
                    <AlternatingRowStyle BackColor="White"  />
                </asp:DetailsView> </TD>
                                <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
                                </td>
                            </TR><TR>
                    <td colspan="1" style="width: 10%">
                    </td>
                    <TD 
style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" colSpan=2><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="ValGroup" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator> 
<asp:Label id="Label3" runat="server" Width="144px" BackColor="CornflowerBlue" Visible="False" BorderColor="#B5C7DE" ForeColor="White" Text="* Nueva Serie" Font-Size="Medium" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid"></asp:Label> 
<asp:TextBox id="TextBox3" runat="server" Visible="False"  CssClass="TxtAutoComplete"></asp:TextBox> 
<Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="12" CompletionInterval="100"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
        CompletionListItemCssClass="autocomplete_listItem " 
        CompletionListCssClass="autocomplete_completionListElement">
                            </Ajax:AutoCompleteExtender> </TD>
                    <td colspan="1" style="vertical-align: middle; width: 10%; text-align: center">
                    </td>
                </TR><TR>
                                <td style="width: 10%">
                                </td>
                                <TD style="WIDTH: 57px; HEIGHT: 21px"> &nbsp;&nbsp;
                                    <asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Width="96px" Visible="False" ValidationGroup="ValGroup" CssClass="lnkbtn">Re-Archivar</asp:LinkButton></TD><TD 
style="VERTICAL-ALIGN: middle; HEIGHT: 21px; TEXT-ALIGN: center"></TD>
                                <td style="vertical-align: middle; width: 10%; text-align: center">
                                </td>
                            </TR><TR>
    <td style="width: 10%">
    </td>
    <TD style="WIDTH: 57px; HEIGHT: 21px"><Ajax:HoverMenuExtender id="hme2" runat="Server" TargetControlID="Image1" PopDelay="50" OffsetY="0" OffsetX="0" PopupPosition="Left" HoverCssClass="popupHover" PopupControlID="PopupMenu"></Ajax:HoverMenuExtender> 
<asp:Image id="Image1" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png"></asp:Image> 
<asp:Panel id="PopupMenu" runat="server" Width="100px" BorderWidth="1px" CssClass="popupMenu" Height="50px">
        <asp:LinkButton ID="LinkButton2" runat="server" 
            CommandName="Edit" Text="Edit" ></asp:LinkButton>
        <br  />
        <asp:LinkButton ID="LinkButton3" runat="server" 
            CommandName="Delete" Text="Delete" ></asp:LinkButton>
    </asp:Panel> </TD><TD 
style="VERTICAL-ALIGN: middle; HEIGHT: 21px; TEXT-ALIGN: center"></TD>
    <td style="vertical-align: middle; width: 10%; text-align: center">
    </td>
</TR></TBODY></TABLE><asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> 
<asp:ObjectDataSource id="CiudadByIdDataSource" runat="server" TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter" SelectMethod="GetMovimientoArchivado" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="String"  />
                        <asp:Parameter Name="NumeroDocumento" Type="String"  />
                    </SelectParameters>
                </asp:ObjectDataSource> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblDocumento" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle">
                </Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
<asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%" Height="1px"></asp:ValidationSummary> 
</TD></TR></TBODY></TABLE>
</asp:Content>



