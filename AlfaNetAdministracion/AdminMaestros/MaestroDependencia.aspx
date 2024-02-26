<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaestroDependencia.aspx.cs" Inherits="_MaestroDependencia" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>


    
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
<asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 80%">
                <TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 10%"></TD><TD style="WIDTH: 80%"><Ajax:Autocompleteextender id="AutoCompleteDependencia" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionListCssClass="autocomplete_completionListElement" completioninterval="100" completionsetcount="12" enablecaching="true" minimumprefixlength="0" servicemethod="GetDependenciaByTextnull" servicepath="../../AutoComplete.asmx" targetcontrolid="TxtDependencia"></Ajax:Autocompleteextender> <Ajax:TextBoxWatermarkExtender id="TxtBoxWatermarkDependencia" watermarkText="Seleccione un Dependencia ..." runat="server" TargetControlID="TxtDependencia"></Ajax:TextBoxWatermarkExtender><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDependencia" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator><asp:Label id="LblDependencia" runat="server" Width="89px" ForeColor="White" Text="Dependencia" Font-Bold="True" CssClass="PropLabels"></asp:Label>
    <asp:TextBox id="TxtDependencia" runat="server" Width="350px" CssClass="TxtAutoComplete"></asp:TextBox> <asp:ImageButton id="ImgBtnFind" onclick="ImgBtnFind_Click" runat="server" ToolTip="Buscar" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" ValidationGroup="ValGroup1"></asp:ImageButton> </TD><TD style="WIDTH: 10%"></TD></TR></TBODY></TABLE>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 80%">
                <TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 40%"><TABLE style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" border=0><TBODY><TR><TD style="WIDTH: 57px; HEIGHT: 8px"><STRONG><EM><SPAN style="FONT-FAMILY: Poor Richard"></SPAN></EM></STRONG><asp:Label id="LblFindBy" runat="server" Width="67px" Font-Size="Smaller" ForeColor="RoyalBlue" Text="Buscar Por: " Font-Bold="True" BorderStyle="None"></asp:Label></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 115px; HEIGHT: 8px; TEXT-ALIGN: center"><asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="106px" Font-Size="Smaller" ForeColor="RoyalBlue" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" Font-Italic="False" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
<asp:ListItem Value="2">Codigo</asp:ListItem>
</asp:RadioButtonList> <asp:HiddenField id="HFCodigoSeleccionado" runat="server"></asp:HiddenField></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 30%"></TD></TR></TBODY></TABLE>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 80%">
                <Ajax:TabContainer style="TEXT-ALIGN: left" id="TCDependencia" runat="server" Width="100%" BackColor="White" AutoPostBack="True" OnActiveTabChanged="TCDependencia_OnActiveTabChanged" ActiveTabIndex="1"><Ajax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                                <img src="../../AlfaNetImagen/ToolBar/user_edit.png"  />
                            
</HeaderTemplate>
<ContentTemplate>
<DIV align=center style="height: 310px">
<asp:DetailsView style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="DVDependencia" runat="server" Width="100%" DataSourceID="DependenciaByIdDataSource" ForeColor="#333333" CssClass="DVStyle" Height="100%" OnDataBound="DVDependencia_DataBound" OnItemDeleted="DVDependencia_ItemDeleted" OnItemUpdated="DVDependencia_ItemUpdated" OnItemInserted="DVDependencia_ItemInserted" HorizontalAlign="Left" GridLines="None" DefaultMode="Insert" DataKeyNames="DependenciaCodigo" CellPadding="4" AutoGenerateRows="False">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<CommandRowStyle BackColor="#D1DDF1" Font-Bold="True"></CommandRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True"></FieldHeaderStyle>
<Fields>
<asp:TemplateField HeaderText="Codigo Dependencia" SortExpression="DependenciaCodigo"><EditItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("DependenciaCodigo") %>'></asp:Label> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Debe ingresar un codigo de dependencia">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("DependenciaCodigo") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia" SortExpression="DependenciaNombre"><EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'>
</asp:Label> <asp:Label id="Label13" runat="server" Visible="False" ForeColor="White" Text="Dependencia Asociada" Font-Bold="False"></asp:Label> <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("DependenciaNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para la dependencia" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("DependenciaNombre") %>' CssClass="TxtMaestro"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un nombre para la dependencia" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'>
</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dependencia Padre" SortExpression="DependenciaCodigoPadre"><EditItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True" OnSelectedIndexChanged="RbtnLstSelPadre_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0"> Es Dependencia ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Dependencia  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox2" runat="server" Visible="False" Text='<%# Bind("DependenciaCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TextBox2" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Dependencia Padre ..." runat="server" TargetControlID="TextBox2"></Ajax:TextBoxWatermarkExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstSelPadre" runat="server" CssClass="DVRbtnLstStyle" AutoPostBack="True"><asp:ListItem Selected="True" Value="0"> Es Dependencia ?</asp:ListItem>
<asp:ListItem Value="1"> Es Sub Dependencia  ?</asp:ListItem>
</asp:RadioButtonList> <asp:TextBox id="TextBox2" runat="server" Visible="False" Text='<%# Bind("DependenciaCodigoPadre") %>' CssClass="TxtMaestroPadre1"></asp:TextBox> <Ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="TextBox2" MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"></Ajax:AutoCompleteExtender><Ajax:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Seleccione un Dependencia Padre ..." runat="server" TargetControlID="TextBox2"></Ajax:TextBoxWatermarkExtender> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("DependenciaNombrePadre") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Habilitar/DesHabilitar" SortExpression="DependenciaHabilitar"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Width="24px" Text='<%# Bind("DependenciaHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server">
</asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Width="24px" Text='<%# Bind("DependenciaHabilitar") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox1" runat="server">
</asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("DependenciaHabilitar") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Distribuye Tareas" SortExpression="DistriTareas">
    <EditItemTemplate>
<asp:TextBox id="TextBox50" runat="server" Width="24px" Text='<%# Bind("DistriTareas") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox10" runat="server">
</asp:CheckBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:TextBox id="TextBox50" runat="server" Width="24px" Text='<%# Bind("DistriTareas") %>' Visible="False"></asp:TextBox> <asp:CheckBox id="CheckBox10" runat="server">
</asp:CheckBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Label id="Label50" runat="server" Text='<%# Bind("DistriTareas") %>' Visible="False"></asp:Label> <asp:CheckBox id="CheckBox10" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
<asp:ImageButton id="ImgBtnEditDependencia" onclick="ImgBtnEditDependencia_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Actualizar" CommandName="Update" AlternateText="Aceptar"></asp:ImageButton> &nbsp;<asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel" AlternateText="Cancelar"></asp:ImageButton> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:ImageButton id="ImgBtnInsertDependencia" onclick="ImgBtnInsertDependencia_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Accept.png" CausesValidation="True" Text="Insertar" CommandName="Insert" AlternateText="Aceptar"></asp:ImageButton> <asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" CausesValidation="False" Text="Cancelar" CommandName="Cancel" AlternateText="Cancelar"></asp:ImageButton> 
</InsertItemTemplate>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Edit.png" CausesValidation="False" Text="Editar" CommandName="Edit" AlternateText="Editar">
</asp:ImageButton>
&nbsp; 
<asp:ImageButton id="ImageButton2" onclick="ImgBtnNewDependencia_Click" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" CausesValidation="False" Text="Nuevo" CommandName="New" AlternateText="Adicionar">
</asp:ImageButton>&nbsp; 
<asp:ImageButton id="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" CausesValidation="False" Text="Eliminar" OnClick="ImageButton3_Click" AlternateText="Eliminar">
</asp:ImageButton>&nbsp; 

</ItemTemplate>
</asp:TemplateField>
</Fields>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#EFF3FB"></RowStyle>
</asp:DetailsView> &nbsp;</DIV>
</ContentTemplate>
</Ajax:TabPanel>
<Ajax:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
<IMG id="IMG1" src="../../AlfaNetImagen/ToolBar/lock_edit.png" /> 
</HeaderTemplate>
<ContentTemplate>

    <Ajax:TabContainer ID="TabPermisos" runat="server" Width="100%" BackColor="White" OnActiveTabChanged="TPermisos_OnActiveTabChanged" AutoPostBack="true">
    <Ajax:TabPanel ID="TabDep" runat="server">
    <HeaderTemplate>
    Dependencias
    </HeaderTemplate>
        <ContentTemplate>
    <STRONG>Esta dependencia podrá consultar:<BR /></STRONG><TABLE><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR /><asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnLstPermiso" runat="server" Width="370px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnLstPermiso_SelectedIndexChanged" AutoPostBack="True" Height="52px" Enabled="False"><asp:ListItem Selected="True" Value="1">Todas</asp:ListItem>
<asp:ListItem Value="0">Ninguna</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE>
    <BR />
            <strong>Excepto las siguientes dependencias:<BR />
            </strong>
    <table style="width: 100%; font-weight: bold;">
    <tr>
                    <td style="width: 40%; vertical-align: top; margin-top: 1px; margin-left: 1px;">
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both" BorderColor="Silver" BorderStyle="Inset" BorderWidth="1px">
                            <asp:TreeView ID="TreeVDependencia" runat="server" ExpandDepth="0" 
                                OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate"   ShowCheckBoxes="All" ShowLines="True"
                                Width="350px">
                                <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
                                <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
                                <SelectedNodeStyle ForeColor="Black" />
                                <RootNodeStyle ForeColor="Black" />
                                <NodeStyle ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"
                                    Width="230px" />
                                <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
                            </asp:TreeView>
                            &nbsp;&nbsp;<br />

 
                        </asp:Panel>


    </td>
                    <td style="width: 10%">
                        &nbsp;
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="height: 7px">
                    <asp:Button ID="BtnAdicionaUno" runat="server" Text=">" Width="35px" OnClick="BtnAdicionaUno_Click" Visible="False" /></td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnAdicionaTodos" runat="server" Text=">>" Width="35px" OnClick="BtnAdicionaTodos_Click" /></td>
                            </tr>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaUno" runat="server" Text="<" Width="35px" OnClick="BtnEliminaUno_Click" /></td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaTodos" runat="server" Text="<<" Width="35px" OnClick="BtnEliminaTodos_Click" /></td>
                            </tr>
                        </table>
                        &nbsp; &nbsp;&nbsp;
                    </td>
                    <td style="width: 40%">
                <asp:ListBox ID="ListBox1" runat="server" Height="300px" SelectionMode="Multiple" Width="100%">
</asp:ListBox>

</td>
                </tr>
    <tr>
    <td colspan="3">
         <br />
        <br />
        <asp:Button ID="BtnHeredar1" runat="server" Text="Heredar" />
    </td>
    </tr>
    <tr>
        <td colspan="3" align="center">
        <br />
        <br />
        <asp:Panel ID="PnHeredar" runat="server" BackColor="white" Visible="true"> 
         <table width="100%">
         <tr>
         <td colspan="2">
             <asp:Label ID="LbMensajes" runat="server" Text="Las siguentes dependencias van a heredar los permisos antes configurados"></asp:Label>
         </td>
         </tr>
         <tr>
         <td colspan="2">
             <asp:TreeView ID="TreeVPreuba" runat="server" ExpandDepth="0" 
                                OnTreeNodePopulate="TreeVPreuba_TreeNodePopulate"   ShowCheckBoxes="All" ShowLines="True"
                                Width="350px">
                                <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
                                <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
                                <SelectedNodeStyle ForeColor="Black" />
                                <RootNodeStyle ForeColor="Black" />
                                <NodeStyle ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"
                                    Width="230px" />
                                <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
                            </asp:TreeView>
         </td>
         </tr>
          <tr>
         <td colspan="2">
             <asp:Label ID="Label4" runat="server" Text="Desea sobreescribir los permisos a estas dependencias?"></asp:Label>
         </td>
         <tr>
         <td align="center"><asp:Button ID="BtHeredarOK" runat="server"  Text="Aceptar" OnClick="BtHeredarOK_Clic" /></td>
         <td align="center"><asp:Button ID="BtHereCancelar" runat="server" OnClick="BtHeredarCan_Clic" Text="Cancelar" /></td>
         </tr>
         </table>  
        </asp:Panel>
         <Ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="MessageStyle"
        CancelControlID="BtHereCancelar" OkControlID="BtnHeredar1" PopupControlID="PnHeredar" TargetControlID="BtnHeredar1">
        </Ajax:ModalPopupExtender>
        <Ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to click this?"
        DisplayModalPopupID="ModalPopupExtender1" TargetControlID="BtnHeredar1">
        </Ajax:ConfirmButtonExtender>
        </td>
    </tr>
<STRONG style="height: 100%"> </STRONG>
                    </td>
    </table>
        </ContentTemplate>
    
    </Ajax:TabPanel>
    <Ajax:TabPanel ID="TabExp" runat="server" Width="100%" BackColor="White">
    <HeaderTemplate>
    Expedientes
    </HeaderTemplate>
    <ContentTemplate>
     <STRONG>Esta dependencia podrá consultar:<BR /></STRONG><TABLE><TBODY><TR><TD><BR /><IMG src="../../AlfaNetImagen/ToolBar/lock.png" /><BR /><BR /><IMG src="../../AlfaNetImagen/ToolBar/key.png" /><BR /></TD><TD style="WIDTH: 16px"><BR />
     <asp:RadioButtonList style="TEXT-ALIGN: left" id="RbtnDepPermiso" runat="server" Width="370px" ForeColor="Black" Font-Bold="False" CssClass="DVRbtnLstStyle" OnSelectedIndexChanged="RbtnDepPermiso_SelectedIndexChanged" AutoPostBack="True" Height="52px" Enabled="False">
     <asp:ListItem Selected="True" Value="1">Todas</asp:ListItem>
     <asp:ListItem Value="0">Ninguna</asp:ListItem>
     </asp:RadioButtonList></TD></TR></TBODY></TABLE>
    <BR />
            <strong>Excepto las siguientes dependencias:<BR />
            </strong>
    <table style="width: 100%; font-weight: bold;">
    <tr>
                    <td style="width: 40%; vertical-align: top; margin-top: 1px; margin-left: 1px;">
                        <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Both" BorderColor="Silver" BorderStyle="Inset" BorderWidth="1px">
                            <asp:TreeView ID="TreeVExpediente" runat="server" ExpandDepth="0" OnLoad="TreeVExpediente_Load"
                                OnTreeNodePopulate="TreeVExpediente_TreeNodePopulate"   ShowCheckBoxes="All" ShowLines="True"
                                Width="350px">
                                <ParentNodeStyle Font-Bold="True" ForeColor="Black" />
                                <HoverNodeStyle Font-Bold="False" ForeColor="Black" />
                                <SelectedNodeStyle ForeColor="Black" />
                                <RootNodeStyle ForeColor="Black" />
                                <NodeStyle ChildNodesPadding="10px" Font-Bold="False" Font-Size="8pt" ForeColor="Black"
                                    Width="230px" />
                                <LeafNodeStyle Font-Bold="False" ForeColor="Black" />
                            </asp:TreeView>
                            &nbsp;&nbsp;<br />

 
                        </asp:Panel>


    </td>
                    <td style="width: 10%">
                        &nbsp;
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="height: 7px">
                    <asp:Button ID="BtnAdicionaUnoB" runat="server" Text=">" Width="35px"  Visible="False" /></td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnAdicionaTodosB" runat="server" Text=">>" Width="35px" OnClick="BtnAdicionaTodosB_Click"  /></td>
                            </tr>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaUnoB" runat="server" Text="<" Width="35px" OnClick="BtnEliminaUnoB_Click"  /></td>
                            </tr>
                            <tr>
                                <td>
                <asp:Button ID="BtnEliminaTodosB" runat="server" Text="<<" Width="35px" OnClick="BtnEliminaTodosB_Click" /></td>
                            </tr>
                        </table>
                        &nbsp; &nbsp;&nbsp;
                    </td>
                    <td style="width: 40%">
                <asp:ListBox ID="ListBox2" runat="server" Height="300px" SelectionMode="Multiple" Width="100%">
</asp:ListBox>

</td>
                </tr>
    <tr>
        <td colspan="2">
            <strong>&nbsp;


                &nbsp;&nbsp;&nbsp;&nbsp;</strong>


 
        </td>
    </tr>
<STRONG style="height: 100%"> </STRONG>
                    </td>
    </table>
    </ContentTemplate>
    </Ajax:TabPanel>
    </Ajax:TabContainer> 
</ContentTemplate>
</Ajax:TabPanel>
</Ajax:TabContainer></td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 80%">
                <TABLE style="WIDTH: 450px"><TBODY><TR><TD style="WIDTH: 277%; TEXT-ALIGN: left"><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary> </TD></TR></TBODY></TABLE>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 80%">
                <table>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td style="width: 80%">
                            <asp:ObjectDataSource id="ODSPermisoDependencia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String"  />
                            <asp:Parameter Name="Original_DependenciaPermisoCodigo" Type="String"  />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="DependenciaPermisoCodigo" Type="String"  />
                            <asp:Parameter Name="DependenciaCodigo" Type="String"  />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="DependenciaCodigo" PropertyName="Value"
                                Type="String"  />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="DependenciaPermisoHabilitar" Type="Boolean"  />
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String"  />
                            <asp:Parameter Name="Original_DependenciaPermisoCodigo" Type="String"  />
                        </UpdateParameters>
                    </asp:ObjectDataSource> <asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><BR /><TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> <Ajax:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblDependencia" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></Ajax:ModalPopupExtender> 
    <asp:Panel ID="Panel1" runat="server" Height="63px" Style="display: none" Width="125px">
        <br />
        <table border="0" width="275">
            <tbody>
                <tr>
                    <td align="center" style="background-color: activecaption">
                        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                            Text="Mensaje" Width="120px"></asp:Label></td>
                    <td style="background-color: activecaption">
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
    <asp:ObjectDataSource id="DependenciaByIdDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDependenciaByID" TypeName="DependenciaBLL" DeleteMethod="DeleteDependencia" InsertMethod="AddDependencia" UpdateMethod="UpdateDependencia">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFCodigoSeleccionado" Name="DependenciaCodigo" PropertyName="Value"
                                Type="String"  />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String"  />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="DependenciaNombre" Type="String"  />
                            <asp:Parameter Name="DependenciaCodigoPadre" Type="String"  />
                            <asp:Parameter Name="DependenciaHabilitar" Type="String"  />
                            <asp:Parameter Name="DependenciaPermiso" Type="String"  />
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String"  />
                            <asp:Parameter Name="DistriTareas" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="DependenciaCodigo" Type="String"  />
                            <asp:Parameter Name="DependenciaNombre" Type="String"  />
                            <asp:Parameter Name="DependenciaCodigoPadre" Type="String"  />
                            <asp:Parameter Name="DependenciaHabilitar" Type="String"  />
                            <asp:Parameter Name="DependenciaPermiso" Type="String"  />
                            <asp:Parameter Name="DistriTareas" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource> 
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
           
</asp:Content>



