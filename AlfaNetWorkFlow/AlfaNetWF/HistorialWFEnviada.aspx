<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="HistorialWFEnviada.aspx.cs" Inherits="_HistorialWFNEnviada" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%; height: 100%; border-collapse: collapse;">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 40%">
                <asp:UpdatePanel id="Updatepanel1000" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="VERTICAL-ALIGN: top; HEIGHT: 50px" colSpan=7><TABLE><TBODY><TR><TD></TD><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="145px" BorderColor="#B5C7DE" Text="Grupo:" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid" CssClass="PropLabels" Font-Italic="False"></asp:Label></TD><TD style="WIDTH: 251px"><asp:DropDownList id="DropDownListGrupo" runat="server" Width="170px" CssClass="TxtProp" OnPreRender="DropDownListGrupo_SelectedIndexChanged" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 15px"></TD><TD style="HEIGHT: 15px"></TD><TD style="WIDTH: 251px; HEIGHT: 15px"></TD><TD style="WIDTH: 100px; HEIGHT: 15px"></TD></TR><TR><TD><asp:RequiredFieldValidator id="RFVSearchHistorico" runat="server" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtSearchHistorico">*
</asp:RequiredFieldValidator></TD><TD style="WIDTH: 100px"><asp:Label id="LblSearchHistorico" runat="server" Width="138px" BackColor="CornflowerBlue" BorderColor="#B5C7DE" ForeColor="White" Text="Numero Documento" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid"></asp:Label></TD><TD style="WIDTH: 251px"><asp:TextBox id="TxtSearchHistorico" runat="server" Width="242px" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:ImageButton id="ImgBtnFindHistorico" onclick="ImgBtnFindHistorico_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1" CssClass="PointerCursor">
</asp:ImageButton></TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:TextBoxWatermarkExtender id="TWSearchHistoricio" watermarkText="Digite el Numero de Documento..." runat="server" TargetControlID="TxtSearchHistorico">
                </ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:AutoCompleteExtender id="ACSearchHistorico" runat="server" TargetControlID="TxtSearchHistorico" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetRegistroCodigoByGrupo" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="12" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100"></ajaxToolkit:AutoCompleteExtender></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 30%">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: float">
    <asp:UpdatePanel id="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> <asp:HiddenField id="HFGrupoSeleccionado" runat="server"></asp:HiddenField> <DIV style="WIDTH: 100%; HEIGHT: 100%"><TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD colSpan=3><asp:DetailsView id="DetailsView1" runat="server" Width="440px" DataSourceID="ODSHistorico" ForeColor="#333333" HorizontalAlign="Left" Height="18px" AutoGenerateRows="False" GridLines="None" CellPadding="4">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<Fields>
<asp:BoundField DataField="WFMovimientoFecha" HeaderText="Fecha Registro" SortExpression="WFMovimientoFecha"></asp:BoundField>
<asp:BoundField DataField="DependenciaNombre" HeaderText="Dependencia Remitente" SortExpression="DependenciaNombre"></asp:BoundField>
<asp:BoundField DataField="SerieNombre" HeaderText="Archivado En" SortExpression="SerieNombre"></asp:BoundField>
</Fields>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:DetailsView> </TD></TR><TR><TD colSpan=3><asp:Panel id="Panel1" runat="server" Width="100%" HorizontalAlign="Center" Direction="LeftToRight"> 
</asp:Panel><BR /></TD></TR><TR><TD style="HEIGHT: 25px" colSpan=3><asp:Label id="LblDetalleMultitarea" runat="server" Width="435px" BackColor="CornflowerBlue" Visible="False" BorderColor="#B5C7DE" ForeColor="White" Font-Bold="True" BorderStyle="Solid" BorderWidth="2px"></asp:Label></TD></TR><TR><TD colSpan=3><BR /><BR /><asp:Panel id="Panel2" runat="server" Width="100%" HorizontalAlign="Center" Direction="LeftToRight"> </asp:Panel><BR /></TD></TR><TR><TD colSpan=3><asp:Label id="LblAccionEnterese" runat="server" Width="435px" BackColor="CornflowerBlue" Visible="False" BorderColor="#B5C7DE" ForeColor="White" Font-Bold="True" BorderStyle="Solid" BorderWidth="2px"></asp:Label></TD></TR></TBODY></TABLE>&nbsp;&nbsp;</DIV><asp:ObjectDataSource id="ODSHistorico" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRegistroHistorico" TypeName="DSRegistroTableAdapters.Registro_ConsultasHistoricoTableAdapter"><SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="RegistroCodigo" Type="Int32"></asp:ControlParameter>
<asp:ControlParameter ControlID="HFGrupoSeleccionado" PropertyName="Value" Name="GrupoCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="ImgBtnFindHistorico" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: center;">
                </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" ForeColor="Crimson"></asp:Label></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>



