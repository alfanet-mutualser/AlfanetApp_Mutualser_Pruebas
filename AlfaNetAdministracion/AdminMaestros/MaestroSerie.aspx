<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroSerie.aspx.cs" Inherits="_MaestroSerie" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<TABLE style="WIDTH: 100%"><TBODY><TR>
    <td style="width: 30%">
    </td>
    <TD style="width: 40%;"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
    <table style="width: 100%">
        <tr>
            <td style="width: 8%">
            </td>
            <td style="width: 84%">
                <Ajax:TextBoxWatermarkExtender id="TBWSearchSerie" watermarkText="Seleccione una Serie ..." runat="server" TargetControlID="TxtSerie"></Ajax:TextBoxWatermarkExtender>
<ajax:autocompleteextender id="ACSearchSerie" runat="server" completioninterval="100" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetSerieByTextnull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtSerie" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></ajax:autocompleteextender> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtSerie" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator> <asp:Label id="LblSerie" runat="server" Width="60px" Text="Serie" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtSerie" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                <asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton> 
            </td>
            <td style="width: 8%">
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="width: 30%">
            </td>
            <td style="width: 40%">
                <TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Size="Smaller" Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" ForeColor="RoyalBlue" Font-Size="Smaller" Font-Italic="False" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE><asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField>
            </td>
            <td style="width: 30%">
            </td>
        </tr>
    </table>
    <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCSerie" runat="server" Width="500px" BackColor="White" AutoPostBack="True" OnActiveTabChanged="TCSerie_ActiveTabChanged" ActiveTabIndex="0"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVSerie" runat="server" Width="460px" DataSourceID="SerieByIdDataSource" ForeColor="#333333" Height="46px" OnItemUpdated="DVDepartamento_ItemUpdated" OnItemInserted="DVDepartamento_ItemInserted" OnItemDeleted="DVDepartamento_ItemDeleted" OnDataBound="DVDepartamento_DataBound" GridLines="None" DataKeyNames="SerieCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Serie" SortExpression="SerieCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("SerieCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar codigo para la serie">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Serie" SortExpression="SerieNombre"><EditItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:Label> <asp:Label id="Label13" runat="server" ForeColor="White" Text="Serie Asociada"></asp:Label> <asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("SerieNombre") %>' CssClass="TxtMaestro"></asp:TextBox>&nbsp; <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar un nombre para la serie">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("SerieNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="Debe ingresar un nombre para la serie">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Serie Padre" SortExpression="SerieCodigoPadre"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="170px" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Serie ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Serie  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox3" runat="server" Visible="False" Text='<%# Bind("SerieCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="ACSeriePadre" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="0"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TBWSeriePadre" watermarkText="Seleccione Serie Padre ..." runat="server" TargetControlID="TextBox3"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="170px" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Serie ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Serie  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox3" runat="server" Visible="False" Text='<%# Bind("SerieCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="ACSeriePadre" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetSerieByText" MinimumPrefixLength="0"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TBWSeriePadre" watermarkText="Seleccione Serie Padre ..." runat="server" TargetControlID="TextBox3"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("SerieCodigoPadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tiempo" SortExpression="SerieTiempo"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SerieTiempo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un tiempo para la serie">*</asp:RequiredFieldValidator>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SerieTiempo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un tiempo para la serie">*</asp:RequiredFieldValidator>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("SerieTiempo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="SerieHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("SerieHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server" Width="105px"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("SerieHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Width="1px" Text='<%# Bind("SerieHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditExpediente" onclick="ImgBtnEditExpediente_Click" runat="server" Text="Actualizar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Update">
</asp:ImageButton> <asp:ImageButton id="ImageButton2" onclick="ImageButton2_Click" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel">
</asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertExpediente" onclick="ImgBtnInsertExpediente_Click" runat="server" Text="Insertar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Insert">
</asp:ImageButton> <asp:ImageButton id="ImageButton2" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel">
</asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" Text="Editar" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" CommandName="Edit">
</asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton2" onclick="ImgBtnNewExpediente_Click" runat="server" Text="Nuevo" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" CommandName="New">
</asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton3" onclick="ImgBtnDeleteExpedientePermiso_Click" runat="server" Text="Eliminar" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False">
</asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False"><HeaderTemplate>
<IMG style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png"  /> 
</HeaderTemplate>
<ContentTemplate>
<STRONG>De forma predeterminada a todas las dependencias se les:<BR /></STRONG><TABLE style="FONT-WEIGHT: bold"><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" AutoPostBack="True" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="0">Denegar&#225; acceso a la consulta</asp:ListItem>
<asp:ListItem Value="1">Permitir&#225; acceso a la consulta</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE><STRONG>Excepto las siguientes dependencias: <BR /><asp:ObjectDataSource id="ODSPermisoSerie" runat="server" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" TypeName="DSSerieSQLTableAdapters.SeriePermiso_ReadSeriePermisoByIdTableAdapter" SelectMethod="GetSeriePermiso" OldValuesParameterFormatString="original_{0}"><DeleteParameters>
<asp:Parameter Name="Original_SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
</InsertParameters>
<SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="SerieCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
<UpdateParameters>
<asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_SerieCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</UpdateParameters>
</asp:ObjectDataSource> <asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVExpedientePermiso" runat="server" Width="320px" ForeColor="#333333" CssClass="DVStyle" Height="50px" OnDataBound="DVExpediente_DataBound" OnItemDeleted="DVExpediente_ItemDeleted" OnItemInserted="DVExpediente_ItemInserted" OnItemUpdated="DVExpediente_ItemUpdated" DataSourceID="ODSPermisoSerie" HorizontalAlign="Left" GridLines="None" DefaultMode="Insert" DataKeyNames="SerieCodigo,DependenciaCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Serie Codigo" SortExpression="SerieCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("SerieCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("SerieCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia Codigo" SortExpression="DepependenciaCodigo"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("DependenciaCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<Ajax:AutoCompleteExtender id="ACDepPer" runat="server" TargetControlID="TextBox2" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="TWDepPer" watermarkText="Seleccion Dependencia Permiso" runat="server" TargetControlID="TextBox2"></Ajax:TextBoxWatermarkExtender> <asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("DependenciaCodigo") %>'>
</asp:TextBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditExpediente" onclick="ImgBtnEditExpediente_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Actualizar" CommandName="Update">
</asp:ImageButton> <asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel">
</asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertExpedientePermiso" onclick="ImgBtnInsertExpedientePermiso_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Insertar" CommandName="Insert">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton2" runat="server" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel">
</asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" Text="Editar" CommandName="Edit">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Text="Nuevo" CommandName="New">
</asp:ImageButton>&nbsp; <asp:ImageButton id="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" Text="Eliminar" CommandName="Delete">
</asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> <BR /><asp:GridView id="GVExpedientePermiso" runat="server" Width="288px" ForeColor="#333333" Height="0px" DataSourceID="ODSPermisoSerie" GridLines="None" DataKeyNames="SerieCodigo,DependenciaCodigo" CellPadding="1" OnRowDeleted="GVExpedientePermiso_RowDeleted" PageSize="5" AutoGenerateColumns="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
<Columns>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="SerieCodigo" HeaderText="Serie Codigo" ReadOnly="True" SortExpression="SerieCodigo"></asp:BoundField>
<asp:BoundField DataField="DependenciaCodigo" HeaderText="Dependencia Codigo" ReadOnly="True" SortExpression="DependenciaCodigo"></asp:BoundField>
<asp:BoundField DataField="DependenciaNombre" HeaderText="Dependencia Nombre" ReadOnly="True" SortExpression="DependenciaNombre"></asp:BoundField>
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
</Ajax:TabContainer> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblSerie" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
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
                            &nbsp; &nbsp;<br />
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
        <br />
        <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
            CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
        </Ajax:ModalPopupExtender>
        <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
            DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
        </Ajax:ConfirmButtonExtender>
</ContentTemplate>
</asp:UpdatePanel></TD>
    <td style="width: 30%">
    </td>
</TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="SerieByIdDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSerieByID"
            TypeName="SerieBLL" DeleteMethod="DeleteSerie" InsertMethod="AddSerie" UpdateMethod="UpdateSerie">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="SerieCodigo" PropertyName="Value"
                                Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_SerieCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="SerieNombre" Type="String" />
                <asp:Parameter Name="SerieCodigoPadre" Type="String" />
                <asp:Parameter Name="SerieTiempo" Type="Int32" />
                <asp:Parameter Name="SerieHabilitar" Type="String" />
                <asp:Parameter Name="SeriePermiso" Type="String" />
                <asp:Parameter Name="Original_SerieCodigo" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="SerieCodigo" Type="String" />
                <asp:Parameter Name="SerieNombre" Type="String" />
                <asp:Parameter Name="SerieCodigoPadre" Type="String" />
                <asp:Parameter Name="SerieTiempo" Type="Int32" />
                <asp:Parameter Name="SerieHabilitar" Type="String" />
                <asp:Parameter Name="SeriePermiso" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
         
</asp:Content>
