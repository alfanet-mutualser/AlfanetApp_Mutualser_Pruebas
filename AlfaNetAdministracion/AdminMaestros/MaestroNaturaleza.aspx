<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroNaturaleza.aspx.cs" Inherits="_MaestroNaturaleza" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<TABLE style="VERTICAL-ALIGN: text-top; WIDTH: 100%" height=400><TBODY><TR>
    <td style="width: 30%">
    </td>
    <TD style="width: 40%"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
    <table style="width: 100%">
        <tr>
            <td style="width: 8%">
            </td>
            <td style="width: 94%">
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtNaturaleza">*</asp:RequiredFieldValidator> <asp:Label id="LblNaturaleza" runat="server" Width="60px" Text="Naturaleza" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtNaturaleza" runat="server" CssClass="TxtAutoComplete"></asp:TextBox><asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton> <Ajax:TextBoxWatermarkExtender id="TBWSearchNaturaleza" watermarkText="Seleccione una Naturaleza ..." runat="server" TargetControlID="TxtNaturaleza"></Ajax:TextBoxWatermarkExtender>
<ajax:autocompleteextender id="ACSearchNaturaleza" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" targetcontrolid="TxtNaturaleza" servicepath="../../AutoComplete.asmx" servicemethod="GetNaturalezaByTextnull" minimumprefixlength="0" enablecaching="true" completionsetcount="12" completioninterval="100"></ajax:autocompleteextender> 
            </td>
            <td style="width: 8%">
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="width: 30%">
            </td>
            <td>
                <TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Italic="False"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE><asp:HiddenField id="HFCodigoSeleccionado" runat="server">
</asp:HiddenField> 
            </td>
            <td style="width: 30%">
            </td>
        </tr>
    </table>
    <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCNaturaleza" runat="server" Width="500px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="TCNaturaleza_ActiveTabChanged"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
<IMG height=16 src="../../AlfaNetImagen/ToolBar/user_edit.png"  /> 
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVNaturaleza" runat="server" Width="460px" DataSourceID="NaturalezaByIdDataSource" ForeColor="#333333" Height="50px" OnItemUpdated="DVDepartamento_ItemUpdated" OnItemInserted="DVDepartamento_ItemInserted" OnItemDeleted="DVDepartamento_ItemDeleted" OnDataBound="DVDepartamento_DataBound" GridLines="None" DataKeyNames="NaturalezaCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Naturaleza" SortExpression="NaturalezaCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("NaturalezaCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<table>
<tr>
<td>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("NaturalezaCodigo") %>' Width="137px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar un Codigo de naturaleza" ControlToValidate="TextBox4">*</asp:RequiredFieldValidator> 
 </td><td><asp:FormView ID="FVAutoNum" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <asp:TextBox ID="TxCons" runat="server" Visible="False" Width="13px" Text='<%# Eval("Consecutivo") %>'></asp:TextBox>
            <asp:CheckBox ID="CkAuto" runat="server" AutoPostBack="true"  OnCheckedChanged="CheckBox2_CheckedChanged1"
                Text="Auto" />
        </ItemTemplate>
    </asp:FormView>
    </td>
</tr></table>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("NaturalezaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Naturaleza" SortExpression="NaturalezaNombre"><EditItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:Label>&nbsp;<asp:Label id="Label13" runat="server" Visible="False" ForeColor="White" Text="NaturalezaAsociada" Font-Bold="True"></asp:Label><asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("NaturalezaNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para la naturaleza" ControlToValidate="TextBox4">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("NaturalezaNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para la naturaleza" ControlToValidate="TextBox5">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("NaturalezaNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Naturaleza Padre" SortExpression="NaturalezaCodigoPadre"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Naturaleza ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Naturaleza  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox1" runat="server" Visible="False" Text='<%# Bind("NaturalezaCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><Ajax:AutoCompleteExtender id="ACNaturalezaPadre" runat="server" TargetControlID="TextBox1" MinimumPrefixLength="0" ServiceMethod="GetNaturalezaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="TBWNaturalezaPadre" watermarkText="Seleccione Naturaleza Padre ..." runat="server" TargetControlID="TextBox1">
</Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Naturaleza ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Naturaleza  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox1" runat="server" Visible="False" Text='<%# Bind("NaturalezaCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><Ajax:AutoCompleteExtender id="ACNaturalezaPadre" runat="server" TargetControlID="TextBox1" MinimumPrefixLength="0" ServiceMethod="GetNaturalezaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="TBWNaturalezaPadre" watermarkText="Seleccione Naturaleza Padre ..." runat="server" TargetControlID="TextBox1"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("NaturalezaCodigoPadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Naturaleza Dias Vence" SortExpression="NaturalezaDiasVence"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Width="60px" Text='<%# Bind("NaturalezaDiasVence") %>'></asp:TextBox>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Width="60px" Text='<%# Bind("NaturalezaDiasVence") %>'></asp:TextBox>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("NaturalezaDiasVence") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="NaturalezaHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="10px" Visible="False" Text='<%# Bind("NaturalezaHabilitar") %>'></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="10px" Visible="False" Text='<%# Bind("NaturalezaHabilitar") %>'></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Width="16px" Visible="False" Text='<%# Bind("NaturalezaHabilitar") %>'></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EsTramite en Linea" SortExpression="NaturalezaPQR"><EditItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Width="1px" Visible="False" Text='<%# Bind("NaturalezaPQR") %>'></asp:TextBox> <asp:CheckBox id="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Width="1px" Visible="False" Text='<%# Bind("NaturalezaPQR") %>'></asp:TextBox> <asp:CheckBox id="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label6" runat="server" Visible="False" Text='<%# Bind("NaturalezaPQR") %>'></asp:Label> <asp:CheckBox id="CheckBox2" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia Tramite en Linea" SortExpression="NaturalezaDependenciaPQR"><EditItemTemplate>
<asp:TextBox id="TextBox7" runat="server" Visible="False" Text='<%# Bind("NaturalezaDependenciaPQR") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TextBox7" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Dependencia ..." runat="server" TargetControlID="TextBox7"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox7" runat="server" Visible="False" Text='<%# Bind("NaturalezaDependenciaPQR") %>' CssClass="TxtMaestroPadre1"></asp:TextBox><Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" TargetControlID="TextBox7" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Dependencia  ..." runat="server" TargetControlID="TextBox7"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label7" runat="server" Text='<%# Bind("NaturalezaDependenciaPQR") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre Dependencia" SortExpression="DependenciaNombre"><EditItemTemplate>
<asp:Label id="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Label id="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditExpediente" onclick="ImgBtnEditExpediente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Actualizar" CommandName="Update">
</asp:ImageButton> &nbsp;<asp:ImageButton id="ImageButton2" onclick="ImageButton2_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel">
</asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertExpediente" onclick="ImgBtnInsertExpediente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Insertar" CommandName="Insert">
</asp:ImageButton> <asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel">
</asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" Text="Editar" CommandName="Edit">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton2" onclick="ImgBtnNewExpediente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Text="Nuevo" CommandName="New">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton3" onclick="ImgBtnDeleteExpedientePermiso_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" Text="Eliminar">
</asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> </DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False"><HeaderTemplate>
<IMG style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png"  /> 
</HeaderTemplate>
<ContentTemplate>
<STRONG>De forma predeterminada a todas las dependencias se les:<BR /></STRONG><TABLE style="FONT-WEIGHT: bold"><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="0">Denegar&#225; acceso a la consulta</asp:ListItem>
<asp:ListItem Value="1">Permitir&#225; acceso a la consulta</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE><STRONG>Excepto las siguientes dependencias: <BR /><asp:ObjectDataSource id="ODSPermisoNaturaleza" runat="server" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" TypeName="DSNaturalezaSQLTableAdapters.NaturalezaPermiso_ReadNaturalezaPermisoByIdTableAdapter" SelectMethod="GetNaturalezaPermiso_ReadNaturalezaPermisoData" OldValuesParameterFormatString="original_{0}"><DeleteParameters>
<asp:Parameter Name="Original_NaturalezaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
</InsertParameters>
<SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="NaturalezaCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
<UpdateParameters>
<asp:Parameter Name="Original_NaturalezaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</UpdateParameters>
</asp:ObjectDataSource> &nbsp; <BR /><DIV style="Z-INDEX: 101; LEFT: 100px; WIDTH: 100px; POSITION: absolute; TOP: 100px; HEIGHT: 100px"></DIV><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVExpedientePermiso" runat="server" Width="400px" ForeColor="#333333" CssClass="DVStyle" Height="50px" OnDataBound="DVExpediente_DataBound" OnItemDeleted="DVExpediente_ItemDeleted" OnItemInserted="DVExpediente_ItemInserted" OnItemUpdated="DVExpediente_ItemUpdated" DataSourceID="ODSPermisoNaturaleza" HorizontalAlign="Left" GridLines="None" DefaultMode="Insert" DataKeyNames="NaturalezaCodigo,DependenciaCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Naturaleza Codigo" SortExpression="NaturalezaCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("NaturalezaCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("NaturalezaCodigo") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("NaturalezaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia Codigo" SortExpression="DepependenciaCodigo"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("DependenciaCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<Ajax:AutoCompleteExtender id="ACDepPer" runat="server" TargetControlID="TextBox2" Enabled="True" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="TWDepPer" watermarkText="Seleccion Dependencia Permiso" runat="server" TargetControlID="TextBox2" Enabled="True"></Ajax:TextBoxWatermarkExtender> <asp:TextBox id="TextBox2" runat="server" Width="200px" Text='<%# Bind("DependenciaCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Dependencia necesaria para agregar el permiso" Enabled="False">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditExpediente" onclick="ImgBtnEditExpediente_Click" runat="server" Text="Actualizar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Update">
</asp:ImageButton> <asp:ImageButton id="ImageButton2" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel">
</asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertExpedientePermiso" onclick="ImgBtnInsertExpedientePermiso_Click" runat="server" Text="Insertar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Insert">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton2" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" Visible="False" CausesValidation="False" CommandName="Cancel">
</asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Editar" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" CommandName="Edit">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton2" runat="server" Text="Nuevo" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" CommandName="New">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton3" runat="server" Text="Eliminar" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" CommandName="Delete">
</asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> <BR /><asp:GridView id="GVExpedientePermiso" runat="server" Width="399px" ForeColor="#333333" Height="0px" DataSourceID="ODSPermisoNaturaleza" GridLines="None" DataKeyNames="DependenciaCodigo,NaturalezaCodigo" CellPadding="1" OnRowDeleted="GVExpedientePermiso_RowDeleted" PageSize="5" AutoGenerateColumns="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
<Columns>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="NaturalezaCodigo" HeaderText="Naturaleza" ReadOnly="True" SortExpression="NaturalezaCodigo"></asp:BoundField>
<asp:TemplateField HeaderText="Dependencia" SortExpression="DependenciaCodigo"><EditItemTemplate>
<asp:Label runat="server" Text='<%# Eval("DependenciaCodigo") %>' id="Label1"></asp:Label>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="DependenciaNombre"><EditItemTemplate>
<asp:Label runat="server" Text='<%# Eval("DependenciaNombre") %>' id="Label3"></asp:Label>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("DependenciaNombre") %>' id="Label3"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>
<EmptyDataTemplate>
<SPAN style="COLOR: red">No se han definido permisos </SPAN>
</EmptyDataTemplate>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
</asp:GridView> </STRONG>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblNaturaleza" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="63px" Style="display: none" Width="125px">
            <br />
            <table border="0" width="275">
                <tbody>
                    <tr>
                        <td align="center" style="background-color: activecaption">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                Text="Mensaje" Width="120px"></asp:Label></td>
                        <td style="width: 12%; background-color: activecaption">
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="Right"
                                ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 45px; background-color: highlighttext">
                            <br />
                            <img src="../../AlfaNetImagen/ToolBar/error.png" />
                            &nbsp;&nbsp;
                            <asp:Label ID="Label7" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
                            &nbsp;&nbsp;<br />
                            <br />
                            &nbsp;
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Aceptar" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="Cancelar" /><br />
                            <br />
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
            CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
        </Ajax:ModalPopupExtender>
        <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
            DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
        </Ajax:ConfirmButtonExtender>
</ContentTemplate>
</asp:UpdatePanel><BR /><TABLE 
style="WIDTH: 100%; HEIGHT: 6%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> 
</TD></TR></TBODY></TABLE></TD>
    <td style="width: 30%">
    </td>
</TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="NaturalezaByIdDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetNaturalezaByID"
            TypeName="NaturalezaBLL" DeleteMethod="DeleteNaturaleza" InsertMethod="AddNaturaleza" UpdateMethod="UpdateNaturaleza">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="NaturalezaCodigo" PropertyName="Value"
                                Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_NaturalezaCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NaturalezaNombre" Type="String" />
                <asp:Parameter Name="NaturalezaCodigoPadre" Type="String" />
                <asp:Parameter Name="NaturalezaDiasVence" Type="Int32" />
                <asp:Parameter Name="NaturalezaHabilitar" Type="String" />
                <asp:Parameter Name="NaturalezaPermiso" Type="String" />
                <asp:Parameter Name="NaturalezaPQR" Type="String" />
                <asp:Parameter Name="NaturalezaDependenciaPQR" Type="String" />
                <asp:Parameter Name="Original_NaturalezaCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                <asp:Parameter Name="NaturalezaNombre" Type="String" />
                <asp:Parameter Name="NaturalezaCodigoPadre" Type="String" />
                <asp:Parameter Name="NaturalezaDiasVence" Type="Int32" />
                <asp:Parameter Name="NaturalezaHabilitar" Type="String" />
                <asp:Parameter Name="NaturalezaPermiso" Type="String" />
                <asp:Parameter Name="NaturalezaPQR" Type="String" />
                <asp:Parameter Name="NaturalezaDependenciaPQR" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>         
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT MAX(CONVERT (int, dbo.UDF_ParseAlphaChars(NaturalezaCodigo)) + 1) AS Consecutivo FROM Naturaleza">
    </asp:SqlDataSource>
</asp:Content>

