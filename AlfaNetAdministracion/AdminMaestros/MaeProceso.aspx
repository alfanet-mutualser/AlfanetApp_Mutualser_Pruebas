<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaeProceso.aspx.cs" Inherits="_MaeProceso" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <table border="1" bordercolor="activeborder" cellpadding="0" cellspacing="0" style="width: 100%;
        height: 100%">
        <tr>
            <td style="height: 744px">
                <br />
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 479px; vertical-align: baseline; text-align: center;">
                            &nbsp;<asp:DetailsView ID="DVWFProceso" runat="server" AllowPaging="True" AutoGenerateRows="False"
                    CellPadding="4" DataKeyNames="WFProcesoCodigo" DataSourceID="WFProcesoDataSource"
                    ForeColor="#333333" GridLines="Vertical" HeaderText="Proceso" Height="50px" OnItemDeleted="DetailsView_ItemDeleted"
                    OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated"
                    Style="vertical-align: middle; text-align: left" Width="381px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    <EditRowStyle BackColor="#2461BF" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <Fields>

                        <asp:TemplateField HeaderText="Codigo" SortExpression="WFProcesoCodigo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFProcesoCodigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="WFProcesoNombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("WFProcesoNombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("WFProcesoNombre") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("WFProcesoNombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Aceptar" CausesValidation="True"
                                    CommandName="Update" ImageUrl="~/Images/ToolBar/Accept.png" Text="Actualizar" />&nbsp;<asp:ImageButton
                                        ID="ImageButton2" runat="server" AlternateText="Cancelar" CausesValidation="False"
                                        CommandName="Cancel" ImageUrl="~/Images/ToolBar/Cancel.png" Text="Cancelar" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Aceptar" CausesValidation="True"
                                    CommandName="Insert" ImageUrl="~/Images/ToolBar/Accept.png" Text="Insertar" />&nbsp;<asp:ImageButton
                                        ID="ImageButton2" runat="server" AlternateText="Cancelar" CausesValidation="False"
                                        CommandName="Cancel" ImageUrl="~/Images/ToolBar/Cancel.png" Text="Cancelar" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Editar" CausesValidation="False"
                                    CommandName="Edit" ImageUrl="~/Images/ToolBar/Edit.png" Text="Editar" />&nbsp;<asp:ImageButton
                                        ID="ImageButton2" runat="server" AlternateText="Adicionar" CausesValidation="False"
                                        CommandName="New" ImageUrl="~/Images/ToolBar/Add.png" Text="Nuevo" />&nbsp;<asp:ImageButton
                                            ID="ImageButton3" runat="server" AlternateText="Eliminar" CausesValidation="False"
                                            CommandName="Delete" ImageUrl="~/Images/ToolBar/Delete.png" Text="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:DetailsView>
                            &nbsp;<asp:DetailsView ID="DVWFProcesoDetalle" runat="server" AllowPaging="True" AutoGenerateRows="False"
                    CellPadding="4" DataKeyNames="WFProcesoCodigo,WFProcesoDetallePaso" DataSourceID="WFProcesoDetalleDataSource"
                    ForeColor="#333333" GridLines="None" HeaderText="Proceso" Height="50px" OnItemDeleted="DetailsView_ItemDeleted"
                    OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated"
                    Style="vertical-align: middle; text-align: left" Width="381px" EmptyDataText="No Hay Datos ...">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <RowStyle BackColor="#EFF3FB" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <Fields>
                                    <asp:BoundField DataField="WFProcesoCodigo" HeaderText="Codigo" ReadOnly="True" SortExpression="WFProcesoCodigo" />
                                    <asp:BoundField DataField="WFProcesoDetallePaso" HeaderText="Paso" ReadOnly="True"
                                        SortExpression="WFProcesoDetallePaso" />
                                    <asp:BoundField DataField="WFProcesoDetalleTiempo" HeaderText="Tiempo" SortExpression="WFProcesoDetalleTiempo" />
                                    <asp:BoundField DataField="WFProcesoDetalleFlujoAlterno" HeaderText="Flujo Alterno"
                                        SortExpression="WFProcesoDetalleFlujoAlterno" />
                                    <asp:BoundField DataField="WFAccionCodigo" HeaderText="Accion" SortExpression="WFAccionCodigo" />
                                    <asp:BoundField DataField="WFProcesoDetalleTipoCodigo" HeaderText="Tipo" SortExpression="WFProcesoDetalleTipoCodigo" />
                                    <asp:BoundField DataField="WFProcesoDetallePasoCodigo" HeaderText="Paso Codigo" SortExpression="WFProcesoDetallePasoCodigo" />
                                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/ToolBar/Cancel.png"
                                        DeleteImageUrl="~/Images/ToolBar/Delete.png" EditImageUrl="~/Images/ToolBar/Edit.png"
                                        InsertImageUrl="~/Images/ToolBar/Accept.png" NewImageUrl="~/Images/ToolBar/Add.png"
                                        ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" UpdateImageUrl="~/Images/ToolBar/Accept.png" />
                                </Fields>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderTemplate>
                                    Detalle del Proceso&nbsp;
                                </HeaderTemplate>
                                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="White" />
                </asp:DetailsView>
                            &nbsp;&nbsp;<br />
                            &nbsp;
                        </td>
                        <td>
                <asp:PlaceHolder ID="PlaceHolderProceso" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;
                <asp:ObjectDataSource ID="WFProcesoDataSource" runat="server" DeleteMethod="Delete"
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFProceso"
                    TypeName="DSProcesoTableAdapters.WFProcesoTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoNombre" Type="String" />
                        <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoNombre" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="WFProcesoDetalleDataSource" runat="server" DeleteMethod="Delete"
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFProcesoDetalleById"
                    TypeName="DSProcesoTableAdapters.WFProcesoDetalleTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="Original_WFProcesoDetallePaso" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoDetallePaso" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetalleTiempo" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetalleFlujoAlterno" Type="Int32" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoDetalleTipoCodigo" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetallePasoCodigo" Type="String" />
                        <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="Original_WFProcesoDetallePaso" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoDetallePaso" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetalleTiempo" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetalleFlujoAlterno" Type="Int32" />
                        <asp:Parameter Name="WFAccionCodigo" Type="String" />
                        <asp:Parameter Name="WFProcesoDetalleTipoCodigo" Type="Int32" />
                        <asp:Parameter Name="WFProcesoDetallePasoCodigo" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DVWFProceso" Name="WFProcesoCodigo" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
        </tr>
    </table>
    
           
</asp:Content>

