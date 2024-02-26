<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="HistorialWF.aspx.cs" Inherits="_HistorialWF" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%; height: 100%; border-collapse: collapse;">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 439px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 30%; height: 115px;">
            </td>
            <td style="width: 439px; height: 115px;">
                <asp:UpdatePanel id="Updatepanel1000" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="VERTICAL-ALIGN: top; HEIGHT: 50px" colSpan=7><TABLE __designer:dtid="281474976710667"><TBODY><TR><TD></TD><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="145px" BorderColor="#B5C7DE" Text="Grupo:" Font-Bold="True" __designer:dtid="281474976710674" Font-Italic="False" __designer:wfdid="w68" CssClass="PropLabels" BorderStyle="Solid" BorderWidth="2px"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="DropDownListGrupo" runat="server" Width="170px" __designer:wfdid="w69" CssClass="TxtProp" OnPreRender="DropDownListGrupo_SelectedIndexChanged" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 15px"></TD><TD style="HEIGHT: 15px"></TD><TD style="HEIGHT: 15px"></TD><TD style="HEIGHT: 15px"></TD></TR><TR __designer:dtid="281474976710668"><TD style="HEIGHT: 25px" __designer:dtid="281474976710669"><asp:RequiredFieldValidator id="RFVSearchHistorico" runat="server" __designer:dtid="281474976710670" __designer:wfdid="w70" ControlToValidate="TxtSearchHistorico" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*
</asp:RequiredFieldValidator></TD><TD style="WIDTH: 100px; HEIGHT: 25px" __designer:dtid="281474976710671"><asp:Label id="LblSearchHistorico" runat="server" Width="145px" BackColor="CornflowerBlue" BorderColor="#B5C7DE" ForeColor="White" Text="Numero Documento" Font-Bold="True" __designer:dtid="281474976710672" __designer:wfdid="w71" BorderStyle="Solid" BorderWidth="2px"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 25px" __designer:dtid="281474976710673"><asp:TextBox id="TxtSearchHistorico" runat="server" Width="242px" __designer:dtid="281474976710674" __designer:wfdid="w72" CssClass="TxtAutoComplete"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 25px" __designer:dtid="281474976710675"><asp:ImageButton id="ImgBtnFindHistorico" onclick="ImgBtnFindHistorico_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" __designer:dtid="281474976710676" __designer:wfdid="w73" CssClass="PointerCursor" ValidationGroup="ValGroup1"></asp:ImageButton></TD></TR></TBODY></TABLE><ajaxToolkit:TextBoxWatermarkExtender id="TWSearchHistoricio" watermarkText="Digite el Numero de Documento..." runat="server" __designer:dtid="281474976710666" __designer:wfdid="w74" TargetControlID="TxtSearchHistorico">
                </ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:AutoCompleteExtender id="ACSearchHistorico" runat="server" __designer:dtid="281474976710665" __designer:wfdid="w75" TargetControlID="TxtSearchHistorico" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetRadicadoByGrupo" ServicePath="../../AutoComplete.asmx"></ajaxToolkit:AutoCompleteExtender></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 115px">
            </td>
        </tr>
    
        <tr>
            <td style="width: 30%">
            </td>
            <td style="text-align: float; width: 439px;">
            
    <asp:UpdatePanel id="UpdatePanel4" runat="server">
        <contenttemplate>
<asp:HiddenField id="HFCodigoSeleccionado" runat="server" __designer:dtid="4785074604081158" __designer:wfdid="w92"></asp:HiddenField><asp:HiddenField id="HFGrupoSeleccionado" runat="server" __designer:dtid="3940649673949202" __designer:wfdid="w93"></asp:HiddenField><BR /><asp:DetailsView id="DetailsView1" runat="server" Width="100%" DataSourceID="ODSHistorico" ForeColor="#333333" __designer:wfdid="w94" CellPadding="4" GridLines="None" AutoGenerateRows="False">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<Fields>
<asp:BoundField DataField="WFMovimientoFecha" HeaderText="Fecha Radicado" SortExpression="WFMovimientoFecha"></asp:BoundField>
<asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre"></asp:BoundField>
<asp:BoundField DataField="CiudadNombre" HeaderText="Ciudad Procedencia" SortExpression="CiudadNombre"></asp:BoundField>
</Fields>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:DetailsView><BR />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" Width="400px"  Font-Bold="true" Height="35px"  runat="server" 
                    BackColor="#C9FEC1" Text=" &nbsp;&nbsp;&nbsp; En caso de
                 requerir  información  detallada del  proceso, es necesario  dar clic sobre el 
                escritorio o Post-It que desee detallar" BorderStyle="Outset"></asp:Label>
            <br />

<BR /><asp:Panel id="Panel1" runat="server" Width="100%" __designer:wfdid="w95"> </asp:Panel><BR /><asp:Label id="LblDetalleMultitarea" runat="server" Width="100%" BackColor="CornflowerBlue" Visible="False" BorderColor="#B5C7DE" ForeColor="White" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid" __designer:wfdid="w96" EnableTheming="True"></asp:Label><BR /><BR /><asp:Panel id="Panel2" runat="server" Width="100%" __designer:wfdid="w97"> </asp:Panel><BR /><asp:Label id="LblAccionEnterese" runat="server" Width="100%" BackColor="CornflowerBlue" Visible="False" BorderColor="#B5C7DE" ForeColor="White" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid" __designer:wfdid="w98"></asp:Label> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="ImgBtnFindHistorico" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
                <asp:ObjectDataSource ID="ODSHistorico" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetRadicadoHistorial" TypeName="DSRadicadoTableAdapters.Radicado_ConsultasHistoricoTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="RaicadoCodigo" PropertyName="Value"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="HFGrupoSeleccionado" Name="GrupoCodigo" PropertyName="Value"
                            Type="String" />
                        
                    </SelectParameters>
                </asp:ObjectDataSource>
                &nbsp;
            </td>
            <td style="width: 30%">
            </td>
        </tr>
        <tr>
            <td style="width: 30%">
            </td>
            <td style="text-align: center; width: 439px; height: 21px;">
                <asp:Label ID="ExceptionDetails" runat="server" ForeColor="Red" Width="100%"></asp:Label></td>
            <td style="height: 21px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 439px">
                </td>
            <td style="height: 21px">
            </td>
        </tr>
    </table>
</asp:Content>



