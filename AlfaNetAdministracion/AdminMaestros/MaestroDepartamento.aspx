<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroDepartamento.aspx.cs" Inherits="_MaestroDepartamento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                    <td style="vertical-align: top; width: 40%">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 3%">
                                                </td>
                                                <td style="width: 94%">
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDepartamento"
                                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="LblDepartamento" runat="server" Font-Bold="False"
                                            Text="Departamento" CssClass="PropLabels"></asp:Label>
                                        <asp:TextBox ID="TxtDepartamento" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                        <asp:ImageButton ID="ImgBtnFind" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"
                                            OnClick="ImgBtnFind_Click" ToolTip="Buscar" ValidationGroup="ValGroup1" />&nbsp;
                                                </td>
                                                <td style="width: 3%">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 30%; height: 7px">
                                                </td>
                                                <td style="width: 40%; height: 7px">
                                        <table border="0" style="border-top-style: none; border-right-style: none; border-left-style: none;
                                            border-bottom-style: none">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 57px;">
                                                        <strong><em><span style="font-family: Poor Richard"></span></em></strong>
                                                        <asp:Label ID="LblFindBy" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Smaller"
                                                            ForeColor="RoyalBlue" Text="Buscar Por: " Width="70px"></asp:Label></td>
                                                    <td style="vertical-align: middle; width: 115px; text-align: center">
                                                        <asp:RadioButtonList ID="RadBtnLstFindby" runat="server" AutoPostBack="True" Font-Italic="False"
                                                            Font-Size="Smaller" ForeColor="RoyalBlue" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged"
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                                            <asp:ListItem Value="2">Codigo</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                                </td>
                                                <td style="width: 7px; height: 7px">
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="HFCodigoSeleccionado" runat="server" />
                                    </td>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                    <td style="vertical-align: top; width: 40%;">
                                        <Ajax:TabContainer ID="TCDepartamento" runat="server" ActiveTabIndex="0" AutoPostBack="True"
                                            BackColor="White" Style="text-align: left" Width="500px">
                                            <Ajax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                <HeaderTemplate>
                                                    <img src="../../AlfaNetImagen/ToolBar/user_edit.png" />
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <div align="center">
                                                        <asp:DetailsView ID="DVDepartamento" runat="server" AutoGenerateRows="False" CellPadding="4"
                                                            DataKeyNames="DepartamentoCodigo" DataSourceID="DepartamentoByIdDataSource" ForeColor="#333333"
                                                            GridLines="None" OnDataBound="DVDepartamento_DataBound" OnItemDeleted="DVDepartamento_ItemDeleted"
                                                            OnItemInserted="DVDepartamento_ItemInserted" OnItemUpdated="DVDepartamento_ItemUpdated"
                                                            Style="vertical-align: middle; text-align: left" Width="460px">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                                            <Fields>
                                                                <asp:TemplateField HeaderText="Codigo Departamento" SortExpression="DepartamentoCodigo">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DepartamentoCodigo") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DepartamentoCodigo") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDepartamento" runat="server" ControlToValidate="TextBox3"
                                                                            ErrorMessage="Debe ingresar codigo de departamento">*</asp:RequiredFieldValidator>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DepartamentoCodigo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Departamento" SortExpression="DepartamentoNombre">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TxtMaestro" Text='<%# Bind("DepartamentoNombre") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDepartamentoname" runat="server" ControlToValidate="TextBox3"
                                                                            ErrorMessage="Debe ingresar nombre para el departamento">*</asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="TxtMaestro" Text='<%# Bind("DepartamentoNombre") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDepartamentoname" runat="server" ControlToValidate="TextBox4"
                                                                            ErrorMessage="Debe ingresar nombre para el departamento">*</asp:RequiredFieldValidator>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("DepartamentoNombre") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Codigo Pais" SortExpression="PaisCodigo">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TxtMaestroPadre" Text='<%# Bind("PaisCodigo") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDepartamentopais" runat="server" ControlToValidate="TextBox1"
                                                                            ErrorMessage="Debe ingresar codigo de pais">*</asp:RequiredFieldValidator><br />
                                                                        <Ajax:AutoCompleteExtender ID="ACDepartamentoPais" runat="server" MinimumPrefixLength="0"
                                                                            ServiceMethod="GetPaisByTextNombre" ServicePath="../../AutoComplete.asmx" TargetControlID="TextBox1">
                                                                        </Ajax:AutoCompleteExtender>
                                                                        <Ajax:TextBoxWatermarkExtender ID="TBWDepartamentoPais" runat="server" TargetControlID="TextBox1"
                                                                            WatermarkText="Seleccione Pais...">
                                                                        </Ajax:TextBoxWatermarkExtender>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TxtMaestroPadre" Text='<%# Bind("PaisCodigo") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDepartamentopais" runat="server" ControlToValidate="TextBox1"
                                                                            ErrorMessage="Debe ingresar codigo de pais">*</asp:RequiredFieldValidator><br />
                                                                        <Ajax:AutoCompleteExtender ID="ACDepartamentoPais" runat="server" MinimumPrefixLength="0"
                                                                            ServiceMethod="GetPaisByTextNombre" ServicePath="../../AutoComplete.asmx" TargetControlID="TextBox1">
                                                                        </Ajax:AutoCompleteExtender>
                                                                        <Ajax:TextBoxWatermarkExtender ID="TBWDepartamentoPais" runat="server" TargetControlID="TextBox1"
                                                                            WatermarkText="Seleccione Pais...">
                                                                        </Ajax:TextBoxWatermarkExtender>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PaisCodigo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pais" SortExpression="PaisNombre">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PaisNombre") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Eval("PaisNombre") %>'></asp:Label>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("PaisNombre") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="DepartamentoHabilitar">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DepartamentoHabilitar") %>'
                                                                            Visible="False" Width="1px"></asp:TextBox>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DepartamentoHabilitar") %>'
                                                                            Visible="False" Width="1px"></asp:TextBox>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DepartamentoHabilitar") %>'
                                                                            Visible="False"></asp:Label>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
                                                    </div>
                                                </ContentTemplate>
                                            </Ajax:TabPanel>
                                        </Ajax:TabContainer></td>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                    <td>
                                        <Ajax:AutoCompleteExtender ID="AutoCompleteDepartamento" runat="server" CompletionInterval="100"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem " CompletionSetCount="12" EnableCaching="true"
                                            MinimumPrefixLength="0" ServiceMethod="GetDepartamentoByTextNombrenull" ServicePath="../../AutoComplete.asmx"
                                            TargetControlID="TxtDepartamento">
                                        </Ajax:AutoCompleteExtender>
                                    <Ajax:ModalPopupExtender ID="MPEMensaje" runat="server" BackgroundCssClass="MessageStyle"
                                            PopupControlID="PnlMensaje" TargetControlID="LblDepartamento">
                                        </Ajax:ModalPopupExtender>
                                        <asp:Panel ID="PnlMensaje" runat="server" Height="63px" Style="display: none" Width="125px">
                                            <br />
                                            <table border="0" width="275">
                                                <tbody>
                                                    <tr>
                                                        <td align="center" style="background-color: activecaption">
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                                                Text="Mensaje" Width="120px"></asp:Label></td>
                                                        <td style="width: 12%; background-color: activecaption">
                                                            <asp:ImageButton ID="btnCerrar" runat="server" CausesValidation="False" ImageAlign="Right"
                                                                ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="height: 45px; background-color: highlighttext">
                                                            <br />
                                                            <img src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label ID="LblMessageBox"
                                                                runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><br />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel><Ajax:ModalPopupExtender ID="MPEPregunta" runat="server" BackgroundCssClass="MessageStyle"
                                            PopupControlID="Panel1" TargetControlID="Button1" CancelControlID="Button2" OkControlID="Button1">
                                        </Ajax:ModalPopupExtender>
                                        <Ajax:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to click this?"
                                            DisplayModalPopupID="MPEPregunta" OnClientCancel="cancelClick" TargetControlID="Button1">
                                        </Ajax:ConfirmButtonExtender>
                                        &nbsp;<br />
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
                                                            &nbsp;&nbsp;&nbsp;<br />
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
                                        &nbsp;<br />
                                        &nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <img src="../../AlfaNetImagen/Icono/Load.gif" style="vertical-align: middle; text-align: center" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <Ajax:TextBoxWatermarkExtender ID="TxtBoxWatermarkDepartamento" runat="server" TargetControlID="TxtDepartamento"
                                            WatermarkText="Seleccione un Departamento ...">
                                        </Ajax:TextBoxWatermarkExtender>
                                    </td>
                                    <td style="vertical-align: top; width: 30%">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:ObjectDataSource ID="DepartamentoByIdDataSource" runat="server" DeleteMethod="DeleteDepartamento"
                            InsertMethod="AddDepartamento" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDepartamentoByID" TypeName="DepartamentoBLL" UpdateMethod="UpdateDepartamento">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="DepartamentoCodigo"
                                    PropertyName="Value" Type="String" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="original_DepartamentoCodigo" Type="String" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="DepartamentoNombre" Type="String" />
                                <asp:Parameter Name="PaisCodigo" Type="String" />
                                <asp:Parameter Name="DepartamentoHabilitar" Type="String" />
                                <asp:Parameter Name="original_DepartamentoCodigo" Type="String" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="DepartamentoCodigo" Type="String" />
                                <asp:Parameter Name="DepartamentoNombre" Type="String" />
                                <asp:Parameter Name="PaisCodigo" Type="String" />
                                <asp:Parameter Name="DepartamentoHabilitar" Type="String" />
                            </InsertParameters>
                        </asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>
