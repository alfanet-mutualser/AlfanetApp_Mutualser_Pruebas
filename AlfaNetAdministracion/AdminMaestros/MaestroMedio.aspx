<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroMedio.aspx.cs" Inherits="_MaestroMedio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<TABLE style="WIDTH: 100%" height=400><TBODY><TR>
    <td style="width: 30%">
    </td>
    <TD style="WIDTH: 40%"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
    <table style="width: 100%">
        <tr>
            <td style="width: 8%">
            </td>
            <td style="width: 84%">
<ajax:autocompleteextender id="autoComplete1" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" completioninterval="100" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetMedioByTextnull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtMedio"></ajax:autocompleteextender> <Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Seleccione un Medio ..." runat="server" TargetControlID="TxtMedio"></Ajax:TextBoxWatermarkExtender> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtMedio" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator> <asp:Label id="LblMedio" runat="server" Width="60px" Text="Medio" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtMedio" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                <asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1" Width="17px"></asp:ImageButton></td>
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
    <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCMedio" runat="server" Width="500px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="TCMedio_ActiveTabChanged"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVMedio" runat="server" Width="460px" DataSourceID="MedioByIdDataSource" ForeColor="#333333" Height="50px" OnDataBound="DVDepartamento_DataBound" OnItemDeleted="DVDepartamento_ItemDeleted" OnItemInserted="DVDepartamento_ItemInserted" OnItemUpdated="DVDepartamento_ItemUpdated" GridLines="None" DataKeyNames="MedioCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Medio" SortExpression="MedioCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("MedioCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<table border="0">
<tr>
<td>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("MedioCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar codigo de medio" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator> 
  </td><td>  <asp:FormView ID="FVAutoNum" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <asp:TextBox ID="TxCons" runat="server" Visible="False" Width="13px" Text='<%# Eval("Consecutivo") %>'></asp:TextBox>
            <asp:CheckBox ID="CkAuto" runat="server" AutoPostBack="true"  OnCheckedChanged="CheckBox2_CheckedChanged1"
                Text="Auto" />
        </ItemTemplate>
    </asp:FormView>
    </td>
    </tr>
    </table>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("MedioCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Medio" SortExpression="MedioNombre"><EditItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("MedioNombre") %>'></asp:Label> <asp:Label id="Label13" runat="server" ForeColor="White" Text="Medio Asociado" Font-Bold="True"></asp:Label> <asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("MedioNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para el medio" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("MedioNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para el medio" ControlToValidate="TextBox4">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("MedioNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Medio Padre" SortExpression="MedioCodigoPadre"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="180px" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0"> Es Medio ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Medio  ?</asp:ListItem>
</asp:RadioButtonList><ajax:autocompleteextender id="ACMedio" runat="server" completioninterval="1000" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetMedioByText" servicepath="../../AutoComplete.asmx" targetcontrolid="TextBox1"></ajax:autocompleteextender><Ajax:TextBoxWatermarkExtender id="TBWMedio" watermarkText="Seleccione un Medio ..." runat="server" TargetControlID="TextBox1"></Ajax:TextBoxWatermarkExtender><asp:TextBox id="TextBox1" runat="server" Visible="False" Text='<%# Bind("MedioCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" Width="180px" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0"> Es Medio ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Medio  ?</asp:ListItem>
</asp:RadioButtonList><ajax:autocompleteextender id="ACMedio" runat="server" completioninterval="1000" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetMedioByText" servicepath="../../AutoComplete.asmx" targetcontrolid="TextBox1"></ajax:autocompleteextender><Ajax:TextBoxWatermarkExtender id="TBWMedio" watermarkText="Seleccione un Medio ..." runat="server" TargetControlID="TextBox1"></Ajax:TextBoxWatermarkExtender><asp:TextBox id="TextBox1" runat="server" Visible="False" Text='<%# Bind("MedioCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("MedioCodigoPadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="MedioHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("MedioHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("MedioHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("MedioHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
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
</asp:DetailsView> <BR  /><TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE>&nbsp;&nbsp;</DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3"><HeaderTemplate>
<asp:Image id="Image1" runat="server" Width="16px" CssClass="ajax__tab_xp" ImageUrl="~/AlfaNetImagen/ToolBar/box_48.png" Height="16px"></asp:Image> 
</HeaderTemplate>
<ContentTemplate>
<asp:Label id="Label4" runat="server" Width="176px" BackColor="CornflowerBlue" BorderColor="#B5C7DE" ForeColor="White" Text="Factor de Peso - Valor" Font-Bold="True" BorderStyle="Solid"></asp:Label> <BR  /><asp:TextBox id="TextBox4" runat="server" Width="70px" Enabled="False" MaxLength="10"></asp:TextBox> <Ajax:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="TextBox4" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder="" CultureTimePlaceholder="" CultureDatePlaceholder="" ClearMaskOnLostFocus="False" InputDirection="RightToLeft" MaskType="Number" Mask="9999,99"></Ajax:MaskedEditExtender> <asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Enabled="False">Guardar</asp:LinkButton> 
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False"><HeaderTemplate>
<IMG style="VISIBILITY: hidden" src="../../AlfaNetImagen/ToolBar/lock_edit.png" visible="false"  /> 
</HeaderTemplate>
<ContentTemplate>
<STRONG>De forma predeterminada a todas las dependencias se les:<BR  /></STRONG><TABLE style="FONT-WEIGHT: bold"><TBODY><TR><TD><BR  /><IMG src="../../AlfaNetImagen/ToolBar/lock.png"  /><BR  /><BR  /><IMG src="../../AlfaNetImagen/ToolBar/key.png"  /><BR  /></TD><TD style="WIDTH: 16px"><BR  /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="0">Denegar&#225; acceso a la consulta</asp:ListItem>
<asp:ListItem Value="1">Permitir&#225; acceso a la consulta</asp:ListItem>
</asp:RadioButtonList> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMedio" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" ForeColor="White" Text="Mensaje" Font-Size="14pt" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
        <Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
            CancelControlID="Button2" OkControlID="Button1" PopupControlID="Panel1" TargetControlID="Button1">
        </Ajax:ModalPopupExtender>
        <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
            DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
        </Ajax:ConfirmButtonExtender>
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
        <br />
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
        <asp:ObjectDataSource ID="MedioByIdDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMedioByID"
            TypeName="MedioBLL" DeleteMethod="DeleteMedio" InsertMethod="AddMedio" UpdateMethod="UpdateMedio">
           <SelectParameters>
                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="MedioCodigo" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_MedioCodigo" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="MedioNombre" Type="String" />
                <asp:Parameter Name="MedioCodigoPadre" Type="String" />
                <asp:Parameter Name="MedioHabilitar" Type="String" />
                <asp:Parameter Name="MedioPermiso" Type="String" />
                <asp:Parameter Name="Original_MedioCodigo" Type="String" />
                <asp:Parameter Name="MedioFactor" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="MedioCodigo" Type="String" />
                <asp:Parameter Name="MedioNombre" Type="String" />
                <asp:Parameter Name="MedioCodigoPadre" Type="String" />
                <asp:Parameter Name="MedioHabilitar" Type="String" />
                <asp:Parameter Name="MedioPermiso" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>        &nbsp;<br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
        SelectCommand="SELECT max(convert(bigint,dbo.UDF_ParseAlphaChars([MedioCodigo]))+1) as Consecutivo &#13;&#10;  FROM [dbo].[Medio]&#13;&#10;">
    </asp:SqlDataSource>
    <br />
</asp:Content>

