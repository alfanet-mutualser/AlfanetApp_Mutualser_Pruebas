<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroCiudad.aspx.cs" Inherits="_MaestroCiudad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


<asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%; TEXT-ALIGN: center"><ajax:autocompleteextender id="AutoCompleteCiudad" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" completioninterval="100" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetCiudadByTextNombrenull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtCiudad"></ajax:autocompleteextender> <Ajax:TextBoxWatermarkExtender id="TxtBoxWatermarkCiudad" watermarkText="Seleccione una Ciudad ..." runat="server" TargetControlID="TxtCiudad"></Ajax:TextBoxWatermarkExtender> <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD></TD><TD style="WIDTH: 100px"><TABLE><TBODY><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCiudad" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblCiudad" runat="server" Width="60px" Text="Ciudad" Font-Bold="False" CssClass="PropLabels"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 25px"><asp:TextBox id="TxtCiudad" runat="server" CssClass="TxtAutoComplete"></asp:TextBox></TD><TD style="HEIGHT: 25px"><asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton></TD></TR></TBODY></TABLE></TD><TD></TD></TR></TBODY></TABLE> </TD><TD style="WIDTH: 30%"></TD></TR><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%; TEXT-ALIGN: center"><TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD></TD><TD style="WIDTH: 100px"><TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Font-Italic="False" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE></TD><TD></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 30%"></TD></TR><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%"><asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCCiudad" runat="server" Width="500px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png" />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVCiudad" runat="server" Width="460px" DataSourceID="CiudadByIdDataSource" ForeColor="#333333" Height="50px" OnDataBound="DVDepartamento_DataBound" OnItemDeleted="DVDepartamento_ItemDeleted" OnItemInserted="DVDepartamento_ItemInserted" OnItemUpdated="DVDepartamento_ItemUpdated" GridLines="None" DataKeyNames="CiudadCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Ciudad" SortExpression="CiudadCodigo"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("CiudadCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("CiudadCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe Ingresar un Codigo" Display="Dynamic">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("CiudadCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ciudad" SortExpression="CiudadNombre"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("CiudadNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe ingresar un nombre para la ciudad">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("CiudadNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Debe ingresar un nombre para la ciudad">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("CiudadNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo Departamento" SortExpression="DepartamentoCodigo"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("DepartamentoCodigo") %>' CssClass="TxtMaestroPadre"></asp:TextBox> <asp:RequiredFieldValidator id="RVCiudadDpto" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un codigo de departamento">*</asp:RequiredFieldValidator> <Ajax:AutoCompleteExtender id="ACCiudadDepartamento" runat="server" TargetControlID="TextBox1" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetDepartamentoByTextNombre" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender> <Ajax:TextBoxWatermarkExtender id="TBWCiudadDepartamento" watermarkText="Seleccione Departamento..." runat="server" TargetControlID="TextBox1"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("DepartamentoCodigo") %>' CssClass="TxtMaestroPadre"></asp:TextBox> <asp:RequiredFieldValidator id="RVCiudadDpto" runat="server" ControlToValidate="TextBox1" ErrorMessage="Debe ingresar un codigo de departamento">*</asp:RequiredFieldValidator> <Ajax:AutoCompleteExtender id="ACCiudadDepartamentoPadre" runat="server" TargetControlID="TextBox1" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetDepartamentoByTextNombre" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Seleccione Departamento..." runat="server" TargetControlID="TextBox1"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("DepartamentoCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Departamento" SortExpression="DepartamentoNombre"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("DepartamentoNombre") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
&nbsp;<asp:Label id="Label1" runat="server" Text='<%# Eval("DepartamentoNombre") %>'></asp:Label> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("DepartamentoNombre") %>'></asp:Label> 
</ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="CiudadHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("CiudadHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("CiudadHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("CiudadHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImageButton5" onclick="ImgBtnUpdateActualizar_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Update"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImageButton4" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False"></asp:ImageButton>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsert" onclick="ImgBtnInsert_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CommandName="Insert"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImageButton7" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CommandName="Cancel" CausesValidation="False"></asp:ImageButton>&nbsp; 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" onclick="ImgBtnEdit_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CommandName="Edit" CausesValidation="False"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImgBtnNew" onclick="ImgBtnNew_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CommandName="New" CausesValidation="False"></asp:ImageButton>&nbsp;&nbsp;<asp:ImageButton id="ImgBtnDelete" onclick="ImgBtnDelete_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False"></asp:ImageButton>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> &nbsp; <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer></TD><TD style="WIDTH: 30%"></TD></TR><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%"><Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="Button1" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle" CancelControlID="Button2" OkControlID="Button1"></Ajax:ModalPopupExtender> 
    <Ajax:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="Button1" DisplayModalPopupID="MPEMensaje" ConfirmText="Are you sure you want to click this?" OnClientCancel="cancelClick">
    </Ajax:ConfirmButtonExtender>
    <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px">
 
    <BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR />
    <br />
</TD></TR></TBODY></TABLE></asp:Panel>
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
    <Ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to click this?"
        DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
    </Ajax:ConfirmButtonExtender>
</TD><TD style="WIDTH: 30%"></TD></TR></TBODY></TABLE><asp:ObjectDataSource id="CiudadByIdDataSource" runat="server" UpdateMethod="UpdateCiudad" InsertMethod="AddCiudad" DeleteMethod="DeleteCiudad" TypeName="CiudadBLL" SelectMethod="GetCiudadByID" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="CiudadCodigo" PropertyName="value"
                    Type="String"  />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_CiudadCodigo" Type="String"  />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="CiudadCodigo" Type="String"  />
                <asp:Parameter Name="CiudadNombre" Type="String"  />
                <asp:Parameter Name="DepartamentoCodigo" Type="String"  />
                <asp:Parameter Name="CiudadHabilitar" Type="String"  />
                <asp:Parameter Name="Original_CiudadCodigo" Type="String"  />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="CiudadCodigo" Type="String"  />
                <asp:Parameter Name="CiudadNombre" Type="String"  />
                <asp:Parameter Name="DepartamentoCodigo" Type="String"  />
                <asp:Parameter Name="CiudadHabilitar" Type="String"  />
            </InsertParameters>
        </asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>
