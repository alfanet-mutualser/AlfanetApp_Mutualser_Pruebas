<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroProcedencia.aspx.cs" Inherits="_MaestroProcedencia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <TABLE style="VERTICAL-ALIGN: text-top; WIDTH: 100%" height=400><TBODY><TR>
    <td style="width: 30%">
    </td>
    <TD style="width: 40%"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
<ajax:autocompleteextender id="autoComplete1" runat="server" completioninterval="100" completionsetcount="12" minimumprefixlength="0" servicemethod="GetProcedenciaByTextNombrenull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtProcedencia" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></ajax:autocompleteextender> <Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Seleccione una Procedencia ..." runat="server" TargetControlID="TxtProcedencia"></Ajax:TextBoxWatermarkExtender> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtProcedencia" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator> <asp:Label id="LblProcedencia" runat="server" Text="Procedencia" Font-Bold="False" CssClass="PropLabels"></asp:Label><asp:TextBox id="TxtProcedencia" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox>&nbsp;<asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton>&nbsp;<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%"><TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Italic="False"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList> <asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 30%"></TD></TR></TBODY></TABLE><Ajax:TabContainer style="TEXT-ALIGN: left" id="TCProcedencia" runat="server" Width="488px" BackColor="White" AutoPostBack="True" OnActiveTabChanged="TCProcedencia_ActiveTabChanged" ActiveTabIndex="0"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" 
        id="DVProcedencia" runat="server" Width="460px" 
        DataSourceID="ProcedenciaByIdDataSource" ForeColor="#333333" Height="50px" 
        OnItemUpdated="DVDepartamento_ItemUpdated" 
        OnItemInserted="DVDepartamento_ItemInserted" 
        OnItemDeleted="DVDepartamento_ItemDeleted" 
        OnDataBound="DVDepartamento_DataBound" GridLines="None" 
        DataKeyNames="ProcedenciaNUI" CellPadding="4" AutoGenerateRows="False" 
        EnableModelValidation="True">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Procedencia NUI" SortExpression="ProcedenciaNUI" Visible="False">
<EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("ProcedenciaNUI") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<table><tr><td>
<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProcedenciaNUI") %>' 
        Width="127px"></asp:TextBox> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox4" Enabled="False" 
        ErrorMessage="Debe ingresar un codigo NUI">*</asp:RequiredFieldValidator></td>
    <td>
        &#160;
    </td></tr></table>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("ProcedenciaNUI") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Procedencia NUI" SortExpression="ProcedenciaCodigo"><EditItemTemplate>
&nbsp;<asp:TextBox ID="TextBox16" runat="server" 
            Text='<%# Bind("ProcedenciaCodigo") %>'></asp:TextBox> 
</EditItemTemplate>
<InsertItemTemplate>
<table><tr><td valign="middle">
<asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ProcedenciaCodigo") %>' 
        Width="139px"></asp:TextBox> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="TextBox6" Enabled="True" 
        ErrorMessage="Debe ingresar un codigo NUI">*</asp:RequiredFieldValidator> 
</td> <td valign="top"><asp:FormView ID="FVAutoNum" runat="server" 
            DataSourceID="SqlDataSource1">
       <ItemTemplate>
            <asp:TextBox ID="TxCons" runat="server" Text='<%# Eval("Consecutivo") %>' 
               Visible="False" Width="13px"></asp:TextBox>
            <asp:CheckBox ID="CkAuto" runat="server" AutoPostBack="true" 
               OnCheckedChanged="CheckBox2_CheckedChanged1" Text="Auto" Visible="true" />
        </ItemTemplate>
    </asp:FormView>
    </td></tr></table>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label ID="Label6" runat="server" Text='<%# Bind("ProcedenciaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
<EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("ProcedenciaNombre") %>' CssClass="TxtMaestro"></asp:TextBox>
<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar un nombre para la procedencia" ControlToValidate="TextBox4">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>' CssClass="TxtMaestro"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar un nombre para la procedencia" ControlToValidate="TextBox5">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Procedencia Padre" SortExpression="ProcedenciaNUIPadre" Visible="False"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="200px" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Procedencia ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Procedencia  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox3" runat="server" Visible="False" Text='<%# Bind("ProcedenciaNUIPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
        <Ajax:AutoCompleteExtender id="ACProcedenciaPadre" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre" MinimumPrefixLength="0"></Ajax:AutoCompleteExtender>
        <Ajax:TextBoxWatermarkExtender id="TBWProcedenciaPadre" watermarkText="Seleccione Procedencia Padre ..." runat="server" TargetControlID="TextBox3"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="200px" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Procedencia ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Procedencia  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox3" runat="server" Visible="False" Text='<%# Bind("ProcedenciaNUIPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
    <Ajax:AutoCompleteExtender id="ACProcedenciaPadre" runat="server" TargetControlID="TextBox3" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre" MinimumPrefixLength="0"></Ajax:AutoCompleteExtender>
    <Ajax:TextBoxWatermarkExtender id="TBWProcedenciaPadre" watermarkText="Seleccione Procedencia Padre ..." runat="server" TargetControlID="TextBox3"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("ProcedenciaNUIPadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Direccion" SortExpression="ProcedenciaDireccion">
<EditItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Text='<%# Bind("ProcedenciaDireccion") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
        <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="Debe ingresar una direccion para la procedencia">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox7" runat="server" Text='<%# Bind("ProcedenciaDireccion") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
    <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="Debe ingresar una direccion para la procedencia">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label7" runat="server" Text='<%# Bind("ProcedenciaDireccion") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Primer Telefono" SortExpression="ProcedenciaTelefono1"><EditItemTemplate>
<asp:TextBox id="TextBox7" runat="server" Text='<%# Bind("ProcedenciaTelefono1") %>'></asp:TextBox> 
        <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" ErrorMessage="Debe ingresar numero telefonico para la procedencia">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox8" runat="server" Text='<%# Bind("ProcedenciaTelefono1") %>'></asp:TextBox> 
    <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8" ErrorMessage="Debe ingresar numero telefonico para la procedencia">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label8" runat="server" Text='<%# Bind("ProcedenciaTelefono1") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="SegundoTelefono" SortExpression="ProcedenciaTelefono2"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("ProcedenciaTelefono2") %>' id="TextBox9"></asp:TextBox>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("ProcedenciaTelefono2") %>' id="TextBox11"></asp:TextBox>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("ProcedenciaTelefono2") %>' id="Label11"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fax" SortExpression="ProcedenciaFax"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("ProcedenciaFax") %>' id="TextBox11"></asp:TextBox>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("ProcedenciaFax") %>' id="TextBox12"></asp:TextBox>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("ProcedenciaFax") %>' id="Label12"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Primer Mail" SortExpression="ProcedenciaMail1"><EditItemTemplate>
<asp:TextBox id="TextBox8" runat="server" Text='<%# Bind("ProcedenciaMail1") %>' CssClass="TxtMaestroPadre"></asp:TextBox> 
        <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="Debe ingresar una direccion de correo para la procedencia" ControlToValidate="TextBox8" Enabled="False">*</asp:RequiredFieldValidator> 
        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="El Texto No Corresponde a un Mail" ControlToValidate="TextBox8" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email Invalido</asp:RegularExpressionValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox9" runat="server" Text='<%# Bind("ProcedenciaMail1") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
    <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="Debe ingresar una direccion de correo para la procedencia" ControlToValidate="TextBox9" Enabled="False">*</asp:RequiredFieldValidator> 
    <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="El Texto No Corresponde a un Mail" ControlToValidate="TextBox9" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email Invalido</asp:RegularExpressionValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label9" runat="server" Text='<%# Bind("ProcedenciaMail1") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ProcedenciaMail2" HeaderText="Segundo Mail" SortExpression="ProcedenciaMail2"></asp:BoundField>
<asp:BoundField DataField="ProcedenciaPaginaWeb" HeaderText="Pagina Web" SortExpression="ProcedenciaPaginaWeb"></asp:BoundField>
<asp:TemplateField HeaderText="Codigo Ciudad" SortExpression="CiudadCodigo"><EditItemTemplate>
<asp:TextBox id="TextBox10" runat="server" Text='<%# Bind("CiudadCodigo") %>' CssClass="TxtMaestroPadre"></asp:TextBox> 
        <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox10" ErrorMessage="Debe ingresar una ciudad para la procedencia">*</asp:RequiredFieldValidator> 
        <Ajax:AutoCompleteExtender id="ACProcedenciaCiudad" runat="server" TargetControlID="TextBox10" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetCiudadByTextNombre" MinimumPrefixLength="1">
</Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TBWProcedenciaCiudad" watermarkText="Seleccione Ciudad..." runat="server" TargetControlID="TextBox10"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox10" runat="server" Text='<%# Bind("CiudadCodigo") %>' CssClass="TxtMaestroPadre"></asp:TextBox> 
    <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox10" ErrorMessage="Debe ingresar una ciudad para la procedencia">*</asp:RequiredFieldValidator> 
    <Ajax:AutoCompleteExtender id="ACProcedenciaCiudad" runat="server" TargetControlID="TextBox10" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetCiudadByTextNombre" MinimumPrefixLength="1"></Ajax:AutoCompleteExtender> 
    <Ajax:TextBoxWatermarkExtender id="TBWProcedenciaCiudad" watermarkText="Seleccione Ciudad ..." runat="server" TargetControlID="TextBox10"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label10" runat="server" Text='<%# Bind("CiudadCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="ProcedenciaHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("ProcedenciaHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Width="1px" Text='<%# Bind("ProcedenciaHabilitar") %>' Visible="False"></asp:TextBox> 
    <asp:CheckBox 
        id="CheckBox1" runat="server" Checked="True"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Width="22px" Text='<%# Bind("ProcedenciaHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" 
            ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" 
            onclick="ImgBtnUpdateActualizar_Click"></asp:ImageButton>&#160;&#160;<asp:ImageButton 
            ID="ImageButton4" runat="server" CausesValidation="False" CommandName="Cancel" 
            ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png"></asp:ImageButton>&nbsp; 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton ID="ImgBtnInsert" runat="server" CommandName="Insert" 
        ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" onclick="ImgBtnInsert_Click"></asp:ImageButton>&#160;&#160;<asp:ImageButton 
        ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Cancel" 
        ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png"></asp:ImageButton>&#160; 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
        CommandName="Edit" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png"></asp:ImageButton>&#160;&#160;<asp:ImageButton 
        ID="ImgBtnNew" runat="server" CausesValidation="False" CommandName="New" 
        ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" onclick="ImgBtnNew_Click"></asp:ImageButton>&#160;&#160;<asp:ImageButton 
        ID="ImgBtnDelete" runat="server" CausesValidation="False" 
        ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" onclick="ImgBtnDelete_Click"></asp:ImageButton>&#160; 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView>

 <TABLE style="WIDTH: 100%; HEIGHT: 100%">
     <TBODY><TR>
         <TD style="TEXT-ALIGN: left">
             <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary>

 </TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False"><HeaderTemplate>
<IMG style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png"  /> 
</HeaderTemplate>
<ContentTemplate>
<STRONG>De forma predeterminada a todas las dependencias se les:<BR /></STRONG><TABLE style="FONT-WEIGHT: bold"><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" AutoPostBack="True" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="0">Denegar&#225; acceso a la consulta</asp:ListItem>
<asp:ListItem Value="1">Permitir&#225; acceso a la consulta</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE><STRONG></STRONG>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblProcedencia" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label> <asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton></TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><IMG src="../../AlfaNetImagen/ToolBar/error.png" /> <asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> 
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
        <asp:UpdateProgress id="UpdateProgress1" runat="server">
                        <progresstemplate>
<IMG style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" src="../../AlfaNetImagen/Icono/Load.gif"  />
</progresstemplate>
                    </asp:UpdateProgress> 
</ContentTemplate>
</asp:UpdatePanel></TD>
    <td style="width: 30%">
    </td>
</TR></TBODY></TABLE>
    
        <asp:ObjectDataSource ID="ProcedenciaByIdDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProcedenciaByID"
            TypeName="ProcedenciaBLL" DeleteMethod="DeleteProcedencia" InsertMethod="AddProcedencia" UpdateMethod="UpdateProcedencia">
           <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="ProcedenciaCodigo" PropertyName="Value"
                                Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
                <asp:Parameter Name="Original_ProcedenciaNUI" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProcedenciaNUI" Type="String" />
                <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                <asp:Parameter Name="ProcedenciaNUIPadre" Type="String" />
                <asp:Parameter Name="ProcedenciaDireccion" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono1" Type="String" />
                <asp:Parameter Name="ProcedenciaTelefono2" Type="String" />
                <asp:Parameter Name="ProcedenciaFax" Type="String" />
                <asp:Parameter Name="ProcedenciaMail1" Type="String" />
                <asp:Parameter Name="ProcedenciaMail2" Type="String" />
                <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String" />
                <asp:Parameter Name="CiudadCodigo" Type="String" />
                <asp:Parameter Name="ProcedenciaHabilitar" Type="String" />
                <asp:Parameter Name="ProcedenciaPermiso" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT MAX(CONVERT (bigint, dbo.UDF_ParseAlphaChars(ProcedenciaNUI)) + 1) AS Consecutivo FROM Procedencia">
    </asp:SqlDataSource>
             
</asp:Content>

