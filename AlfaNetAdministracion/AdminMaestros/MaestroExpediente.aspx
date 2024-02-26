<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroExpediente.aspx.cs" Inherits="_MaestroExpediente" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript">
// <!CDATA[
function OnTreeClick(evt)
{
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if(isChkBoxClick)
    {
        var parentTable = GetParentByTagName("table", src);
        var nxtSibling = parentTable.nextSibling;
        //check if nxt sibling is not null & is an element node
        if(nxtSibling && nxtSibling.nodeType == 1)
        {
            if(nxtSibling.tagName.toLowerCase() == "div") //if node has children
            {
//                //check or uncheck children at all levels
                CheckUncheckChildren(parentTable.nextSibling, src.checked);
            }
        }
//        //check or uncheck parents at all levels
        CheckUncheckParents(src, src.checked);
    }
}

function CheckUncheckChildren(childContainer, check)
{
    var childChkBoxes = childContainer.getElementsByTagName("input");
    var childChkBoxCount = childChkBoxes.length;
    for(var i=0;i<childChkBoxCount;i++)
    {
        childChkBoxes[i].checked = check;
    }
}

function CheckUncheckParents(srcChild, check)
{
    var parentDiv = GetParentByTagName("div", srcChild);
    var parentNodeTable = parentDiv.previousSibling;
    if(parentNodeTable)
    {
        var checkUncheckSwitch;
        if(check) //checkbox checked
        {
            var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
            if(isAllSiblingsChecked)
                checkUncheckSwitch = true;
            else
            return; //do not need to check parent if any(one or more) child not checked
        }    
        else //checkbox unchecked
        {
            checkUncheckSwitch = false;
        }
        var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
        if(inpElemsInParentTable.length > 0)
        {
            var parentNodeChkBox = inpElemsInParentTable[0];
            parentNodeChkBox.checked = checkUncheckSwitch;
            //do the same recursively
            CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
        }
    }
}    
function AreAllSiblingsChecked(chkBox)
{
    var parentDiv = GetParentByTagName("div", chkBox);
    var childCount = parentDiv.childNodes.length;
    for(var i=0;i<childCount;i++)
    {
        if(parentDiv.childNodes[i].nodeType == 1)
        {
            //check if the child node is an element node
            if(parentDiv.childNodes[i].tagName.toLowerCase() == "table")
            {
                var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                //if any of sibling nodes are not checked, return false
                if(!prevChkBox.checked)
                {
                return false;
                }
             }
        }
    }
    return true;
}


////utility function to get the container of an element by tagname
function GetParentByTagName(parentTagName, childElementObj)
{
    var parent = childElementObj.parentNode;
    while(parent.tagName.toLowerCase() != parentTagName.toLowerCase())
    {
        parent = parent.parentNode;
    }
    return parent;
}



// ]]>
</script>
<TABLE style="WIDTH: 100%" height=400><TBODY><TR>
    <td style="width: 10%">
    </td>
    <TD 
style="WIDTH: 80%;">
<asp:UpdatePanel id="UpdatePanel4" runat="server">
<ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 10%"></TD><TD style="WIDTH: 80%"><ajax:autocompleteextender id="AutoCompleteExpediente" runat="server" targetcontrolid="TxtExpediente" servicepath="../../AutoComplete.asmx" servicemethod="GetExpedienteByTextNombrenull" minimumprefixlength="0" enablecaching="true" completionsetcount="12" completioninterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></ajax:autocompleteextender> 
<Ajax:TextBoxWatermarkExtender id="TxtBoxWatermarkExpediente1" watermarkText="Seleccione un Expediente ..." runat="server" TargetControlID="TxtExpediente"></Ajax:TextBoxWatermarkExtender> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ValGroup1" SetFocusOnError="True" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtExpediente">*</asp:RequiredFieldValidator> <asp:Label id="LblExpediente" runat="server" Width="100px" Text="Expediente" Font-Bold="False" CssClass="PropLabels"></asp:Label> <asp:TextBox id="TxtExpediente" runat="server" CssClass="TxtAutoComplete"></asp:TextBox> <asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton></TD><TD style="WIDTH: 10%"></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 72px"></TD><TD style="WIDTH: 40%"><TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Font-Italic="False" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE><asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField> </TD><TD style="WIDTH: 100px; HEIGHT: 72px"></TD></TR></TBODY></TABLE><Ajax:TabContainer style="TEXT-ALIGN: left" id="TCExpediente" runat="server" Width="650px" BackColor="White" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="TCExpediente_OnActiveTabChanged"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center><asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVExpediente" runat="server" Width="100%" DataSourceID="ExpedienteByIdDataSource" ForeColor="#333333" CssClass="DVStyle" OnItemInserting="DVExpediente_ItemInserting" OnItemInserted="DVExpediente_ItemInserted" OnItemUpdated="DVExpediente_ItemUpdated" OnItemDeleted="DVExpediente_ItemDeleted" OnDataBound="DVExpediente_DataBound" HorizontalAlign="Left" GridLines="None" DefaultMode="Insert" DataKeyNames="ExpedienteCodigo" CellPadding="4" AutoGenerateRows="False">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Expediente" SortExpression="ExpedienteCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ExpedienteCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ExpedienteCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RFVExpedienteCodigo" runat="server" ErrorMessage="Debe ingresar codigo de expediente" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ExpedienteCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="ExpedienteNombre"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("ExpedienteNombre") %>'></asp:Label><BR  /><asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ExpedienteNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Debe ingresar un nombre para el expediente">*</asp:RequiredFieldValidator> <asp:Label id="Label13" runat="server" ForeColor="White" Text="Expediente Asociado" Font-Bold="True"></asp:Label>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ExpedienteNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Debe ingresar un nombre para el expediente">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("ExpedienteNombre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Expediente Padre" SortExpression="ExpedienteNombrePadre"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True"><asp:ListItem Selected="True" Value="0"> Es Expediente ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Expediente  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TxtExpedientePadre" runat="server" Visible="False" Text='<%# Bind("ExpedienteCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TxtExpedientePadre" MinimumPrefixLength="0" ServiceMethod="GetExpedienteByTextNombre" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Expediente Padre ..." runat="server" TargetControlID="TxtExpedientePadre"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True"><asp:ListItem Selected="True" Value="0"> Es Expediente ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Expediente  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TxtExpedientePadre" runat="server" Visible="False" Text='<%# Bind("ExpedienteCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TxtExpedientePadre" MinimumPrefixLength="0" ServiceMethod="GetExpedienteByTextNombre" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Expediente Padre ..." runat="server" TargetControlID="TxtExpedientePadre"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("ExpedienteNombrePadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="ExpedienteHabilitar"><EditItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Checked='<%# Bind("ExpedienteHabilitar") %>'></asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Checked='<%# Bind("ExpedienteHabilitar") %>'></asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Enabled="false" Checked='<%# Bind("ExpedienteHabilitar") %>'></asp:CheckBox> <BR  />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Folio Inicial" SortExpression="ExpedienteDireccion"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ExpedienteDireccion") %>'></asp:TextBox>
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("ExpedienteDireccion") %>'></asp:TextBox>
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("ExpedienteDireccion") %>'></asp:Label>
</ItemTemplate>

<ControlStyle CssClass="TxtMaestro"></ControlStyle>
</asp:TemplateField>
<asp:BoundField DataField="ExpedienteTelefono1" HeaderText="Clasificacion 1" SortExpression="ExpedienteTelefono1">
<ControlStyle CssClass="TxtMaestro"></ControlStyle>
</asp:BoundField>
<asp:BoundField DataField="ExpedienteTelefono2" HeaderText="Clasificacion 2" SortExpression="ExpedienteTelefono2">
<ControlStyle CssClass="TxtMaestro"></ControlStyle>
</asp:BoundField>
<asp:BoundField DataField="ExpedienteFax" HeaderText="Clasificacion 3" SortExpression="ExpedienteFax">
<ControlStyle CssClass="TxtMaestro"></ControlStyle>
</asp:BoundField>
<asp:BoundField DataField="ExpedienteMail1" HeaderText="Correo Principal" SortExpression="ExpedienteMail1" Visible="False"></asp:BoundField>
<asp:BoundField DataField="ExpedienteMail2" HeaderText="Correo Secundario" SortExpression="ExpedienteMail2" Visible="False"></asp:BoundField>
<asp:BoundField DataField="ExpedientePaginaWeb" HeaderText="Pagina WEB" SortExpression="ExpedientePaginaWeb" Visible="False"></asp:BoundField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditExpediente" onclick="ImgBtnEditExpediente_Click" runat="server" Text="Actualizar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton2" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertExpediente" onclick="ImgBtnInsertExpediente_Click" runat="server" Text="Insertar" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" CommandName="Insert"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton2" runat="server" Text="Cancelar" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" CommandName="Cancel"></asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Editar" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" CommandName="Edit"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton2" runat="server" Text="Nuevo" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" CommandName="New">
</asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton3" runat="server" Text="Eliminar" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" OnClick="ImageButton3_Click" ></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Fields>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:DetailsView> 
<TABLE style="WIDTH: 100%; HEIGHT: 100%">
<TBODY><TR><TD style="TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False">
<HeaderTemplate>
<asp:Image id="Image1" runat="server" Width="16px" ImageUrl="~/AlfaNetImagen/ToolBar/lock_edit.png" Height="16px" Visible="False"></asp:Image> 
</HeaderTemplate>
<ContentTemplate>
<TABLE width="100%"><TBODY>
    <tr>
        <td colspan="2">
            <strong>
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 20%">
                        </td>
                        <td style="width: 60%">
                            El Expediente
                            <asp:Label ID="LblExp" runat="server"
                            Text="Nro Expediente"></asp:Label>

                            podra ser consultado por:<BR />
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
            </strong>
        </td>
    </tr>
    <TR><TD style="width: 23px; height: 82px;">
        <BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR />
        <BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD>
        <TD style="height: 82px"><BR />
            <asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="245px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="False">Ninguna Dependencia</asp:ListItem>
<asp:ListItem Value="True">Todas las Dependencia</asp:ListItem>
</asp:RadioButtonList>



 </TD></TR>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td colspan="3" style="height: 30px; text-align: center">
                        <strong>
                            <table style="width: 100%; height: 100%">
                                <tr>
                                    <td style="width: 20%">
                                    </td>
                                    <td style="width: 60%">
                Excepto las siguientes dependencias:
                                    </td>
                                    <td style="width: 20%">
                                    </td>
                                </tr>
                            </table>
                        </strong></td>
                </tr>
                <tr>
                    <td style="width: 40px; vertical-align: top; margin-top: 1px; margin-left: 1px;">
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both" BorderColor="Silver" BorderStyle="Inset" BorderWidth="1px">
                            <asp:TreeView ID="TreeVDependencia" runat="server" ExpandDepth="0" OnLoad="TreeVDependencia_Load"
                                OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate"   ShowCheckBoxes="All" ShowLines="True"
                                Width="350px">
<HoverNodeStyle Font-Bold="False" ForeColor="Black" />

<LeafNodeStyle Font-Bold="False" ForeColor="Black" />

<NodeStyle ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"
                                    Width="230px" />

<ParentNodeStyle Font-Bold="True" ForeColor="Black" />

<RootNodeStyle ForeColor="Black" />

<SelectedNodeStyle ForeColor="Black" />
</asp:TreeView>

                            &nbsp;<br />
                            <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" DataSourceID="ExpedienteByIdDataSource"
                                Visible="False"></dxwtl:ASPxTreeList>


 
                        </asp:Panel>



    </td>
                    <td style="width: 20%">
                        &nbsp;
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="height: 7px">
                    <asp:Button ID="BtnAdicionaUno" runat="server" Text=">" Width="35px" OnClick="BtnAdicionaUno_Click" Visible="False" />
</td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnAdicionaTodos" runat="server" Text=">>" Width="35px" OnClick="BtnAdicionaTodos_Click" />
</td>
                            </tr>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaUno" runat="server" Text="<" Width="35px" OnClick="BtnEliminaUno_Click" />
</td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaTodos" runat="server" Text="<<" Width="35px" OnClick="BtnEliminaTodos_Click" />
</td>
                            </tr>
                        </table>
                        &nbsp; &nbsp;&nbsp;
                    </td>
                    <td style="width: 40%">
                <asp:ListBox ID="ListBox1" runat="server" Height="300px" SelectionMode="Multiple" Width="100%"></asp:ListBox>


</td>
    <tr>
        <td colspan="2">
            <strong>
                <asp:ObjectDataSource id="ODSPermisoExpediente" runat="server" UpdateMethod="Update" TypeName="DSExpedienteSQLTableAdapters.ExpedientePermiso_ReadExpedientePermisoTableAdapter" SelectMethod="GetExpedientePermisoData" OldValuesParameterFormatString="original_{0}" InsertMethod="Insert" DeleteMethod="Delete">
                    <DeleteParameters>
<asp:Parameter Name="Original_ExpedienteCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</DeleteParameters>
<InsertParameters>
<asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
</InsertParameters>
<SelectParameters>
<asp:ControlParameter ControlID="HFCodigoSeleccionado" PropertyName="Value" Name="ExpedienteCodigo" Type="String"></asp:ControlParameter>
</SelectParameters>
<UpdateParameters>
<asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_ExpedienteCodigo" Type="String"></asp:Parameter>
<asp:Parameter Name="Original_DependenciaCodigo" Type="String"></asp:Parameter>
</UpdateParameters>
</asp:ObjectDataSource>



                &nbsp;&nbsp;&nbsp;&nbsp;</strong>


 
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">


 
        </td>
    </tr>
<STRONG style="height: 100%"> </STRONG>
                    </td>
                </tr>
</TBODY></TABLE>
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblExpediente" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle"></Ajax:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><br /></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel style="DISPLAY: none" id="Panel1" runat="server" Width="125px" Height="63px">
    <BR />
    <TABLE width=275 border=0>
        <TBODY>
            <TR>
                <TD style="BACKGROUND-COLOR: activecaption" align=center>
                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                        Text="Mensaje" Width="120px"></asp:Label></td>
                <TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption">
                    <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageAlign="Right"
                        ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" Style="vertical-align: top" />
                </td>
            </tr>
            <TR>
                <TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2>
                    <BR />
                    <IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label ID="Label7"
                        runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><br />
                    <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" /></td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
    <Ajax:ModalPopupExtender ID="MPEConfirmar" runat="server" TargetControlID="Label7" PopupControlID="Panel1" BackgroundCssClass="MessageStyle">
    </Ajax:ModalPopupExtender>
   
</ContentTemplate>
</asp:UpdatePanel> 
<asp:ObjectDataSource id="ExpedienteByIdDataSource" runat="server" UpdateMethod="UpdateExpediente" TypeName="ExpedienteBLL" SelectMethod="GetExpedienteById" OldValuesParameterFormatString="original_{0}" InsertMethod="AddExpediente" DeleteMethod="DeleteExpediente">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String"  />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ExpedienteCodigo" Type="String"  />
                            <asp:Parameter Name="ExpedienteNombre" Type="String"  />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String"  />
                            <asp:Parameter Name="ExpedienteHabilitar" Type="Boolean"  />
                            <asp:Parameter Name="ExpedientePermiso" Type="Boolean"  />
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String"  />
                            <asp:Parameter Name="ExpedienteDireccion" Type="String"  />
                            <asp:Parameter Name="ExpedienteTelefono1" Type="String"  />
                            <asp:Parameter Name="ExpedienteTelefono2" Type="String"  />
                            <asp:Parameter Name="ExpedienteFax" Type="String"  />
                            <asp:Parameter Name="ExpedienteMail1" Type="String"  />
                            <asp:Parameter Name="ExpedienteMail2" Type="String"  />
                            <asp:Parameter Name="ExpedientePaginaWeb" Type="String"  />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="ExpedienteCodigo" PropertyName="Value"
                                Type="String"  />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ExpedienteCodigo" Type="String"  />
                            <asp:Parameter Name="ExpedienteNombre" Type="String"  />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String"  />
                            <asp:Parameter Name="ExpedienteHabilitar" Type="Boolean"  />
                            <asp:Parameter Name="ExpedientePermiso" Type="Boolean"  />
                            <asp:Parameter Name="ExpedienteDireccion" Type="String"  />
                            <asp:Parameter Name="ExpedienteTelefono1" Type="String"  />
                            <asp:Parameter Name="ExpedienteTelefono2" Type="String"  />
                            <asp:Parameter Name="ExpedienteFax" Type="String"  />
                            <asp:Parameter Name="ExpedienteMail1" Type="String"  />
                            <asp:Parameter Name="ExpedienteMail2" Type="String"  />
                            <asp:Parameter Name="ExpedientePaginaWeb" Type="String"  />
                        </InsertParameters>
                    </asp:ObjectDataSource> 
                    <asp:ObjectDataSource id="ExpedientePermisoByIdDataSource" runat="server" TypeName="ExpedienteBLL" SelectMethod="GetExpedientePermisoById" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="ExpedienteCodigo" PropertyName="value"
                                Type="String"  />
                        </SelectParameters>
                    </asp:ObjectDataSource>           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</TD>
    <td style="width: 10%">
    </td>
    
</TR></TBODY></TABLE>
          
</asp:Content>



