<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroPais.aspx.cs" Inherits="_MaestroPais" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"><table style="vertical-align: text-top; width: 100%">
    <tr >
        <td style="width: 30%">
        </td>
        <td style="width: 40%">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <Ajax:TextBoxWatermarkExtender ID="TxtBoxWatermarkPais" runat="server" TargetControlID="TxtPais"
                        WatermarkText="Seleccione un Pais ...">
                    </Ajax:TextBoxWatermarkExtender>
                    <Ajax:AutoCompleteExtender ID="AutoCompletePais" runat="server" CompletionInterval="1000"
                        CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="12" EnableCaching="true"
                        MinimumPrefixLength="0" ServiceMethod="GetPaisByTextNombrenull" ServicePath="../../AutoComplete.asmx"
                        TargetControlID="TxtPais">
                    </Ajax:AutoCompleteExtender>
                    <table style="width: 100%">
                        <tbody>
                            <tr>
                                <td style="width: 8%">
                                </td>
                                <td style="width: 84%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPais"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator>
                                    <asp:Label ID="LblPais" runat="server" Font-Bold="False"
                                        Text="Pais" Width="60px" CssClass="PropLabels"></asp:Label>
                                    <asp:TextBox ID="TxtPais" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBtnFind" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"
                                        OnClick="ImgBtnFind_Click" ToolTip="Buscar" ValidationGroup="ValGroup1" />
                                </td>
                                <td style="width: 8%">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="width: 100%">
                        <tbody>
                            <tr>
                                <td style="width: 30%">
                                </td>
                                <td style="width: 40%">
                                    <table border="0" style="border-top-style: none; border-right-style: none; border-left-style: none;
                                        border-bottom-style: none">
                                        <tbody>
                                            <tr>
                                                <td style="width: 57px; height: 8px">
                                                    <strong><em><span style="font-family: Poor Richard"></span></em></strong>
                                                    <asp:Label ID="LblFindBy" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Smaller"
                                                        ForeColor="RoyalBlue" Text="Buscar Por: " Width="67px"></asp:Label></td>
                                                <td style="vertical-align: middle; width: 115px; height: 8px; text-align: center">
                                                    <asp:RadioButtonList ID="RadBtnLstFindby" runat="server" AutoPostBack="True" Font-Italic="False"
                                                        Font-Size="Smaller" ForeColor="RoyalBlue" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal" Width="106px">
                                                        <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                                        <asp:ListItem Value="2">Codigo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:HiddenField ID="HFCodigoSeleccionado" runat="server" />
                                </td>
                                <td style="width: 30%">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <Ajax:TabContainer ID="TCPais" runat="server" ActiveTabIndex="0" AutoPostBack="True"
                        BackColor="White" Style="text-align: left" Width="500px">
                        <Ajax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div align="center">
                                    <asp:DetailsView ID="DVPais" runat="server" AutoGenerateRows="False" CellPadding="4"
                                        DataKeyNames="PaisCodigo" DataSourceID="PaisByIdDataSource" ForeColor="#333333"
                                        GridLines="None" Height="50px" OnDataBound="DVDepartamento_DataBound" OnItemDeleted="DVDepartamento_ItemDeleted"
                                        OnItemInserted="DVDepartamento_ItemInserted" OnItemUpdated="DVDepartamento_ItemUpdated"
                                        Style="vertical-align: middle; text-align: left" Width="460px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                        <Fields>
                                            <asp:TemplateField HeaderText="Codigo Pais" SortExpression="PaisCodigo">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("PaisCodigo") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <InsertItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PaisCodigo") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                                        ErrorMessage="Debe ingresar codigo para el pais">*</asp:RequiredFieldValidator>
                                                </InsertItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PaisCodigo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pais" SortExpression="PaisNombre">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="TxtMaestro" Text='<%# Bind("PaisNombre") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1"
                                                        ErrorMessage="Debe ingresar nombre para el pais">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <InsertItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="TxtMaestro" Text='<%# Bind("PaisNombre") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                                                        ErrorMessage="Debe ingresar nombre para el pais">*</asp:RequiredFieldValidator>
                                                </InsertItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PaisNombre") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="PaisHabilitar">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PaisHabilitar") %>' Visible="False"
                                                        Width="1px"></asp:TextBox>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </EditItemTemplate>
                                                <InsertItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PaisHabilitar") %>' Visible="False"
                                                        Width="1px"></asp:TextBox>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </InsertItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PaisHabilitar") %>' Visible="False"></asp:Label>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png"
                                                        OnClick="ImgBtnUpdateActualizar_Click" />&nbsp;&nbsp;<asp:ImageButton ID="ImageButton4"
                                                            runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" />&nbsp;
                                                </EditItemTemplate>
                                                <InsertItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnInsert" runat="server" CommandName="Insert" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png"
                                                        OnClick="ImgBtnInsert_Click" />&nbsp;&nbsp;<asp:ImageButton ID="ImageButton7" runat="server"
                                                            CausesValidation="False" CommandName="Cancel" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" />&nbsp;
                                                </InsertItemTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" OnClick="ImgBtnEdit_Click" />&nbsp;&nbsp;<asp:ImageButton
                                                            ID="ImgBtnNew" runat="server" CausesValidation="False" CommandName="New" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png"
                                                            OnClick="ImgBtnNew_Click" />&nbsp;&nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server"
                                                                CausesValidation="False" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png"
                                                                OnClick="ImgBtnDelete_Click" />&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Fields>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                    </asp:DetailsView>
                                    <br />
                                    <table style="width: 100%; height: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="100%" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    &nbsp;&nbsp;</div>
                            </ContentTemplate>
                        </Ajax:TabPanel>
                    </Ajax:TabContainer>&nbsp;&nbsp;&nbsp;<br />
                    <Ajax:ModalPopupExtender ID="MPEMensaje" runat="server" BackgroundCssClass="MessageStyle"
                        PopupControlID="PnlMensaje" TargetControlID="LblPais">
                    </Ajax:ModalPopupExtender>
                    <asp:Panel ID="PnlMensaje" runat="server" Height="63px" Style="display: none" Width="125px">
                        <br />
                        <table border="0" width="275">
                            <tbody>
                                <tr>
                                    <td align="center" style="background-color: activecaption">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="White"
                                            Text="Mensaje" Width="120px"></asp:Label></td>
                                    <td align="center" style="width: 6px; background-color: activecaption">
                                        <asp:ImageButton ID="btnCerrar" runat="server" CausesValidation="False" ImageAlign="Right"
                                            ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" /></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 45px; background-color: highlighttext">
                                        <br />
                                        <img src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label ID="LblMessageBox"
                                            runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
                                        <br />
                                        <div>
                                            &nbsp;&nbsp;</div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
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
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="../../AlfaNetImagen/Icono/Load.gif" style="vertical-align: middle; text-align: center" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="width: 30%">
        </td>
    </tr>
</table>
   <asp:ObjectDataSource ID="PaisByIdDataSource" runat="server" DeleteMethod="DeletePais"
        InsertMethod="AddPais" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPaisByID"
        TypeName="PaisBLL" UpdateMethod="UpdatePais">
        <DeleteParameters>
            <asp:Parameter Name="Original_PaisCodigo" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="PaisNombre" Type="String" />
            <asp:Parameter Name="PaisHabilitar" Type="String" />
            <asp:Parameter Name="Original_PaisCodigo" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="HFCodigoSeleccionado" DefaultValue="" Name="PaisCodigo"
                PropertyName="value" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="PaisCodigo" Type="String" />
            <asp:Parameter Name="PaisNombre" Type="String" />
            <asp:Parameter Name="PaisHabilitar" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>         
</asp:Content>

