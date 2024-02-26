<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroWorkFlowProceso.aspx.cs" Inherits="_MaestroWorkFlowProceso" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<TABLE style="WIDTH: 100%; HEIGHT: 100%" borderColor=activeborder cellSpacing=0 
cellPadding=0 border=1><TBODY><TR><TD style="HEIGHT: 1px">   &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
    <table style="width: 100%">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 40%">
                <asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
    &nbsp; &nbsp;&nbsp;
    <table style="width: 100%">
        <tr>
            <td style="width: 8%">
            </td>
            <td style="width: 84%">
<cc1:autocompleteextender id="AutoCompleteDepartamento" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" completioninterval="100" enablecaching="true" minimumprefixlength="0" servicemethod="GetWFProcesoTextByTextnull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtDepartamento"></cc1:autocompleteextender> <cc1:textboxwatermarkextender id="TxtBoxWatermarkDepartamento" watermarkText="Seleccione un Proceso ..." runat="server" targetcontrolid="TxtDepartamento"></cc1:textboxwatermarkextender> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDepartamento" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator> <asp:Label id="LblProceso" runat="server" Text="Proceso" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtDepartamento" runat="server" CssClass="TxtAutoComplete"></asp:TextBox><asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton></td>
            <td style="width: 8%">
            </td>
        </tr>
    </table>
    &nbsp;<BR />
    <table style="width: 100%">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 40%">
                <TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" AutoPostBack="True" Font-Italic="False" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                            <asp:ListItem Value="2">Codigo</asp:ListItem>
                                        </asp:RadioButtonList></TD></TR></TBODY></TABLE>
            </td>
            <td style="width: 30%; height: 20px">
            </td>
        </tr>
    </table>
    <asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> <asp:HiddenField id="HFNroDetCount" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="HDFSeleccion" runat="server" />
                    &nbsp;&nbsp;<BR /><cc1:tabcontainer style="TEXT-ALIGN: left" id="TCDepartamento" runat="server" activetabindex="0" autopostback="True" backcolor="White" width="500px"><cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                    <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                                
</HeaderTemplate>
<ContentTemplate>
<asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVWFProceso" runat="server" Width="460px" ForeColor="#333333" OnDataBound="DVWFProceso_DataBound" OnItemDeleted="DetailsView_ItemDeleted" OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated" OnPageIndexChanged="DVWFProceso_PageIndexChanged" OnPageIndexChanging="DVWFProceso_PageIndexChanging" Height="50px" DataSourceID="WFProcesoDataSource" GridLines="Vertical" DefaultMode="Insert" DataKeyNames="WFProcesoCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>

<Fields>
<asp:TemplateField HeaderText="Codigo Proceso" SortExpression="WFProcesoCodigo"><EditItemTemplate>
                                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("WFProcesoCodigo") %>'></asp:Label>
                                                 
</EditItemTemplate>
<InsertItemTemplate>
                                                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"
                                                         ErrorMessage="Debe ingresar un codigo para el proceso">*</asp:RequiredFieldValidator>
                                                 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Descripcion" SortExpression="WFProcesoDescripcion"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("WFProcesoDescripcion") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe ingresar un nombre para el proceso">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("WFProcesoDescripcion") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar un nombre para el proceso">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("WFProcesoDescripcion") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Proceso Padre" SortExpression="WFProcesoCodigoPadre" Visible="False"><EditItemTemplate>
<cc1:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TextBox2" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFProcesoTextByText " MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender> <asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("WFProcesoCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Seleccione Proceso Padre" runat="server" TargetControlID="TextBox2">
                                                     </cc1:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("WFProcesoCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <cc1:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TextBox2" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFProcesoTextByText " MinimumPrefixLength="0">
                                                     </cc1:AutoCompleteExtender> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Seleccione Proceso Padre" runat="server" TargetControlID="TextBox2">
                                                     </cc1:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("WFProcesoCodigoPadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/Deshabilitar" SortExpression="WFProcesoHabilitar"><EditItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoHabilitar") %>'
                                                         Visible="False"></asp:TextBox>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                 
</EditItemTemplate>
<InsertItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoHabilitar") %>'
                                                         Visible="False"></asp:TextBox>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                 
</InsertItemTemplate>
<ItemTemplate>
                                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFProcesoHabilitar") %>' Visible="False"></asp:Label>
                                                     <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False"  />
                                                 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEdit" onclick="ImgBtnEdit_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Update"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImageButton4" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsert" onclick="ImgBtnInsert_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Insert"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImageButton7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton>&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" CommandName="Edit"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImgBtnNew" onclick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" CommandName="New"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImgBtnDelete" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" OnClick="ImgBtnDelete_Click"></asp:ImageButton>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<RowStyle BackColor="#EFF3FB"></RowStyle>

</asp:DetailsView> <asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Visible="False">Agregar Detalle al Proceso</asp:LinkButton> <asp:ObjectDataSource id="WFProcesoDetalleDataSource" runat="server" UpdateMethod="Update" TypeName="DSProcesoTableAdapters.WFProcesoDetalle1TableAdapter" SelectMethod="GetWFProcesoDetalleById" OldValuesParameterFormatString="original_{0}" InsertMethod="Insert" DeleteMethod="Delete"><DeleteParameters>
<asp:Parameter Name="Original_WFProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_WFProcesoDetallePaso" Type="Int32"></asp:Parameter>
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="WFProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetallePaso" Type="Int32"></asp:Parameter>
<asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFSubProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetalleTiempo" Type="Int32"></asp:Parameter>
<asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFActividadCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="PlantillaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetalleHabilitar" Type="String"></asp:Parameter>
</InsertParameters>
<SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="WFProcesoCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
<UpdateParameters>
<asp:Parameter Name="WFProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetallePaso" Type="Int32"></asp:Parameter>
<asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFSubProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetalleTiempo" Type="Int32"></asp:Parameter>
<asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFActividadCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="PlantillaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDetalleHabilitar" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_WFProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_WFProcesoDetallePaso" Type="Int32"></asp:Parameter>
</UpdateParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="WFProcesoDataSource" runat="server" UpdateMethod="Update" TypeName="DSProcesoTableAdapters.WFProceso1TableAdapter" SelectMethod="GetProcesoById" OldValuesParameterFormatString="original_{0}" InsertMethod="Insert" DeleteMethod="Delete"><DeleteParameters>
<asp:Parameter Name="Original_WFProcesoCodigo" Type="String"></asp:Parameter>
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="WFProcesoCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoDescripcion" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoHabilitar" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoCodigoPadre" Type="String"></asp:Parameter>
</InsertParameters>
<SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="WFProcesoCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
<UpdateParameters>
<asp:Parameter Name="WFProcesoDescripcion" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoHabilitar" Type="String"></asp:Parameter>
<asp:Parameter Name="WFProcesoCodigoPadre" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_WFProcesoCodigo" Type="String"></asp:Parameter>
</UpdateParameters>
</asp:ObjectDataSource> <asp:HiddenField id="HFRbtLst" runat="server" Value="1"></asp:HiddenField> <asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVWFProcesoDetalle" runat="server" Width="460px" Visible="False" ForeColor="#333333" OnDataBound="DVWFProcesoDetalle_DataBound" OnItemDeleted="DetailsView_ItemDeleted" OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated" Height="50px" DataSourceID="WFProcesoDetalleDataSource" GridLines="None" DefaultMode="Insert" DataKeyNames="WFProcesoCodigo,WFProcesoDetallePaso" CellPadding="4" AutoGenerateRows="False" HeaderText="Proceso" EmptyDataText="No Hay Datos ..." AllowPaging="True">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Proceso" SortExpression="WFProcesoCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("WFProcesoCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Label id="Label1" runat="server" Width="57px" Text='<%# Eval("WFProcesoCodigo") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Detalle Paso" SortExpression="WFProcesoDetallePaso"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("WFProcesoDetallePaso") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("WFProcesoDetallePaso") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label6" runat="server" Text='<%# Bind("WFProcesoDetallePaso") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tiempo" SortExpression="WFProcesoDetalleTiempo"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Width="80px" Text='<%# Bind("WFProcesoDetalleTiempo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar un tipo para ejecutar el paso dentro del porceso" ControlToValidate="TextBox5">*</asp:RequiredFieldValidator> <DIV style="Z-INDEX: 101; LEFT: 100px; WIDTH: 100px; POSITION: absolute; TOP: 100px; HEIGHT: 100px"></DIV> <cc1:NumericUpDownExtender id="NUDE1" runat="server" Width="80" TargetControlID="TextBox5" ServiceUpMethod ServiceDownMethod Maximum="365" Minimum="1"></cc1:NumericUpDownExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox7" runat="server" Width="80px" Text='<%# Bind("WFProcesoDetalleTiempo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar un tipo para ejecutar el paso dentro del porceso" ControlToValidate="TextBox7">*</asp:RequiredFieldValidator> <cc1:NumericUpDownExtender id="NUDE1" runat="server" Width="80" TargetControlID="TextBox7" ServiceUpMethod ServiceDownMethod Maximum="365" Minimum="1"></cc1:NumericUpDownExtender>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label7" runat="server" Text='<%# Bind("WFProcesoDetalleTiempo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Seleccione..."><EditItemTemplate>
<asp:RadioButtonList id="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Dependencia</asp:ListItem>
<asp:ListItem Value="0">Serie</asp:ListItem>
</asp:RadioButtonList> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Seleccione Dependencia" runat="server" TargetControlID="TextBox2">
                                                     </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TextBox2" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender> <asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("DependenciaCodigo") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><BR  /><asp:Label id="Label9" runat="server" Text='<%# Eval("DependenciaNombre") %>'></asp:Label><BR  /><cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione Serie" runat="server" TargetControlID="TextBox3">
                                                     </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText " MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender> <asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("SerieCodigo") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><BR  /><asp:Label id="Label10" runat="server" Text='<%# Eval("SerieNombre") %>'></asp:Label>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList id="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Dependencia</asp:ListItem>
<asp:ListItem Value="0">Serie</asp:ListItem>
</asp:RadioButtonList><asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("DependenciaCodigo") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><asp:Label id="Label9" runat="server" Text='<%# Eval("DependenciaNombre") %>'></asp:Label> <cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TextBox2" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Seleccione Dependencia" runat="server" TargetControlID="TextBox2">
                                                     </cc1:TextBoxWatermarkExtender> <asp:TextBox id="TextBox3" runat="server" Visible="False" Text='<%# Bind("SerieCodigo") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><asp:Label id="Label10" runat="server" Text='<%# Eval("SerieNombre") %>'></asp:Label>&nbsp; <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione Serie" runat="server" TargetControlID="TextBox3">
                                                     </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteExtender3" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText " MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender>&nbsp;&nbsp;&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label> <asp:Label id="Label9" runat="server" Text='<%# Eval("DependenciaNombre") %>'></asp:Label><BR  /><asp:Label id="Label3" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:Label>&nbsp;<asp:Label id="Label10" runat="server" Text='<%# Eval("SerieNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Accion" SortExpression="WFAccionCodigo"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("WFAccionCodigo") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar una accion para el paso del proceso">*</asp:RequiredFieldValidator> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender4" watermarkText="Seleccione Accion" runat="server" TargetControlID="TextBox4">
                                                     </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteExtender4" runat="server" TargetControlID="TextBox4" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText " MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender> <asp:Label id="Label8" runat="server" Text='<%# Eval("WFAccionNombre") %>'></asp:Label>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("WFAccionCodigo") %>' CssClass="TxtMaestroPadre1">
</asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar una accion para el paso del proceso">*</asp:RequiredFieldValidator> <cc1:TextBoxWatermarkExtender id="TextBoxWatermarkExtender4" watermarkText="Seleccione Accion" runat="server" TargetControlID="TextBox4">
                                                     </cc1:TextBoxWatermarkExtender> <cc1:AutoCompleteExtender id="AutoCompleteExtender4" runat="server" TargetControlID="TextBox4" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText " MinimumPrefixLength="0" CompletionInterval="100">
                                                     </cc1:AutoCompleteExtender>&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("WFAccionCodigo") %>'></asp:Label>&nbsp;<asp:Label id="Label8" runat="server" Text='<%# Eval("WFAccionNombre") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="WFProcesoDetalleHabilitar"><EditItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoDetalleHabilitar") %>'
                                                         Visible="False"></asp:TextBox>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                 
</EditItemTemplate>
<InsertItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoDetalleHabilitar") %>'
                                                         Visible="False"></asp:TextBox>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                 
</InsertItemTemplate>
<ItemTemplate>
                                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFProcesoDetalleHabilitar") %>'
                                                         Visible="False"></asp:Label>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnUpdateDetalle" onclick="ImgBtnUpdateDetalle_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Update"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImgBtnCancelDetalle" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertDetalle" onclick="ImgBtnInsertDetalle_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Insert"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImgBtnCancelDetalle" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton>&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<%--<asp:ImageButton id="ImgBtnEditDetalle" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" CommandName="Edit"></asp:ImageButton>--%> &nbsp;<asp:ImageButton id="ImgBtnNewDetalle" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" CommandName="New"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImgBtnDeleteDetalle" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" OnClick="ImgBtnDeleteDetalle_Click"></asp:ImageButton>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
<HeaderTemplate>
                                             Detalle del Proceso&nbsp;
                                         
</HeaderTemplate>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> <TABLE style="WIDTH: 100%; HEIGHT: 12%"><TBODY><TR><TD style="TEXT-ALIGN: center"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ControlLightLight"><TABLE style="WIDTH: 200px"><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label runat="server" Text="Mensaje" Font-Bold="False" Font-Size="14pt" ForeColor="White" Width="120px" ID="Label555"></asp:Label>

</TD><TD style="WIDTH: 2%; BACKGROUND-COLOR: activecaption"><asp:ImageButton runat="server" ValidationGroup="789" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ID="btnCerrar" style="VERTICAL-ALIGN: top"></asp:ImageButton>

 </TD></TR><TR><TD style="BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR  /><asp:Label runat="server" Font-Size="Medium" ForeColor="Red" Width="198px" ID="LblMessageBox"></asp:Label>

 </TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="MPEMensaje" runat="server" Enabled="True" TargetControlID="LblMessageBox" DynamicServicePath="" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></cc1:ModalPopupExtender> <br /><asp:Panel ID="Panel1" runat="server" Height="63px" Style="display: none" Width="125px"><br /><table border="0" width="275"><tbody><tr><td align="center" style="background-color: activecaption"><asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                            Text="Mensaje" Width="120px"></asp:Label> </td><td style="width: 12%; background-color: activecaption"><asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="Right"
                            ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" /> </td></tr><tr><td align="center" colspan="2" style="height: 45px; background-color: highlighttext"><br /><img src="../../AlfaNetImagen/ToolBar/error.png" /> &nbsp;&nbsp; <asp:Label ID="Label7" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label> &nbsp; &nbsp;<br /><br />&nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Aceptar" /> &nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="Cancelar" /> <br /><br /></td></tr></tbody></table></asp:Panel> <br />
    <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
        CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
    </Ajax:ModalPopupExtender>
    <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
        DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
    </Ajax:ConfirmButtonExtender>
    <br />
    &nbsp; 
</ContentTemplate>
</cc1:TabPanel>
</cc1:tabcontainer> 
</ContentTemplate>
</asp:UpdatePanel>  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 30%">
            </td>
        </tr>
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 100px">
                <asp:Label id="ExceptionDetails" runat="server" Width="100%" ForeColor="Red" Font-Size="10pt"></asp:Label>
                <asp:PlaceHolder id="PlaceHolderProceso" runat="server"></asp:PlaceHolder> 
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <TABLE style="WIDTH: 100%;" 
cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD 
style="VERTICAL-ALIGN: baseline; WIDTH: 100%" rowSpan=2>
    &nbsp;
</TD><TD style="width: 30%"></TD></TR><TR><TD>
    &nbsp;</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>        
</asp:Content>

    