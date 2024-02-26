<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="PermisosPlantillas.aspx.cs" Inherits="AlfanetPlantilla_PermisosPlantillas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="plantillas.css" rel="stylesheet" type="text/css" />
    <script src="scriptPerPlantillas.js" type="text/javascript"></script>

    <link href="smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    
    <div class="contenedorPermisosPlantilla">
        <table class="tableContent">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMessage" CssClass="message" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="celdaHisq">
                    <asp:DropDownList ID="ddlPlantillas" CssClass="ddlPlantillas" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlPlantillas_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="celdaCentro">
                </td>
                <td class="celdaDer">
                    
                </td>
                <td></td>
            </tr>
            <tr>
                <td valign = "top" class="celdaHisq">
                    <asp:TextBox ID="txtDependencias" CssClass ="txtDependencias" runat="server"></asp:TextBox>
                </td>
                <td valign = "top" class="celdaCentro">
                    <asp:ImageButton ID="ibtnAdd" runat="server" 
                        ImageUrl="~/AlfaNetImagen/ToolBar/Add.png" onclick="ibtnAdd_Click" />
                </td>
                <td class="celdaDer">
                    <asp:ListBox ID="ltbDependencias" CssClass="ltbDependencias" runat="server"></asp:ListBox>
                </td>
                <td valign = "top">
                    <asp:ImageButton ID="ibtnQuitarItem" runat="server" 
                        ImageUrl="~/AlfaNetImagen/ToolBar/Delete.png" 
                        onclick="ibtnQuitarItem_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                </td>
                <td>
                
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                </td>
                <td>
                
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>

