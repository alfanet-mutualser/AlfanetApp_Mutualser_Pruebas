<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="ArmaArbol.aspx.cs" Inherits="_MaeExpediente" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
    
    <%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <strong><span style="font-size: 24pt; color: #716f64">
        <table border="2" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%" bordercolor="scrollbar">
            <tr>
                <td colspan="2" style="height: 13px">
                    EXPEDIENTE</td>
            </tr>
            <tr>
                <td style="width: 255px; height: 420px; position: static;">
                    <ignav:UltraWebTree ID="TreeViewExpediente" runat="server" DefaultImage="ig_treeOfficeFolder.gif" DefaultSelectedImage="ig_treeOfficeFolder.gif"
                        DisabledClass="" Font-Size="12pt" Height="428px" TargetFrame=""
                        TargetUrl="" Width="223px" FileUrl="" AllowDrag="True" AllowDrop="True">
                        <Images>
                            <DefaultImage Url="ig_treeOfficeFolder.gif" />
                            <SelectedImage Url="ig_treeOfficeFolder.gif" />
                            <CollapseImage Url="ig_treeXPMinus.gif" />
                            <ExpandImage Url="ig_treeXPPlus.gif" />
                        </Images>
                        <NodeStyle>
                            <Padding Bottom="2px" Left="2px" Right="2px" Top="2px" />
                        </NodeStyle>
                        <SelectedNodeStyle BackColor="#316AC5" ForeColor="Silver">
                            <Padding Bottom="2px" Left="2px" Right="2px" Top="2px" />
                        </SelectedNodeStyle>
                        <ClientSideEvents DragStart="TreeViewSerie_Drop" />
                    </ignav:UltraWebTree>
                    </td>
                <td style="height: 420px; background-image: none; text-align: center;">
                    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>&nbsp;<br />
                    <igtbl:UltraWebGrid ID="DGExpediente" runat="server" Browser="Xml"
                        DataSourceID="ExpedienteDataSource" EnableAppStyling="True" Height="235px" Style="left: 275px; top: -63px;" StyleSetName="BlueGel"
                        Width="432px">
                        <Bands>
                            <igtbl:UltraGridBand CellTitleModeDefault="Always" ColFootersVisible="No"
                                DefaultColWidth="130px">
                                <FooterStyle BackColor="LightSlateGray" Height="1px" />
                                <RowEditTemplate>
                                    <br />
                                    <p align="center">
                                        <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                            type="button" value="OK" />&nbsp;
                                        <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                            type="button" value="Cancel" /></p>
                                </RowEditTemplate>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <FilterOptions AllowRowFiltering="OnClient" ShowAllCondition="No" ShowEmptyCondition="Yes"
                                    ShowNonEmptyCondition="Yes">
                                </FilterOptions>
                                <Columns>
                                    <igtbl:TemplatedColumn AllowGroupBy="No" AllowRowFiltering="False" Width="20px">
                                        <CellTemplate>
                                            <asp:ImageButton ID="ImgBtnSelect" runat="server" AlternateText="Seleccionar" CausesValidation="False"
                                                CommandName="Select" ImageUrl="~/Images/ToolBar/Select.png" OnClick="ImgBtnSelect_Click"
                                                Text="Seleccionar" />
                                        </CellTemplate>
                                        <FooterTemplate>
                                            &nbsp;
                                        </FooterTemplate>
                                        <CellButtonStyle BackColor="Transparent">
                                        </CellButtonStyle>
                                    </igtbl:TemplatedColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ExpedienteCodigo" HeaderText="Codigo" IsBound="True"
                                        Key="ExpedienteCodigo">
                                        <Header Caption="Codigo">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ExpedienteNombre" HeaderText="Nombre" IsBound="True"
                                        Key="ExpedienteNombre">
                                        <Header Caption="Nombre">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ExpedienteCodigoPadre" HeaderText="Codigo_Padre"
                                        IsBound="True" Key="ExpedienteCodigoPadre">
                                        <Header Caption="Codigo_Padre">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                </Columns>
                                <RowTemplateStyle BackColor="Window" BorderColor="Window" BorderStyle="Ridge">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowSortingDefault="OnClient"
                            BorderCollapseDefault="Separate" ColWidthDefault="80px"
                            HeaderClickActionDefault="SortMulti" LoadOnDemand="Xml" Name="DGExpediente" NoDataMessage="No hay datos para mostrar:"
                            RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeCellDefault="Extended"
                            SelectTypeColDefault="Extended" SelectTypeRowDefault="Extended" TableLayout="Fixed"
                            Version="4.00" ViewType="OutlookGroupBy">
                            <GroupByBox Prompt="Agrupar por :">
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                            </GroupByRowStyleDefault>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            <FooterStyleDefault BackColor="LightSlateGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <FilterOptionsDefault AllowRowFiltering="OnClient" FilterComparisonType="CaseInsensitive"
                                FilterRowView="Top" FilterUIType="FilterRow" RowFilterMode="SiblingRowsOnly"
                                ShowAllCondition="No" ShowEmptyCondition="Yes" ShowNonEmptyCondition="Yes" ContainsString="Contiene" DoesNotContainString="No Contiene" DoesNotEndWithString="No Termina Con" DoesNotStartWithString="No Empieza Con" EmptyString="Vacio" EndsWithString="Termina Con" EqualsString="Igual " GreaterThanOrEqualsString="Mayor o Igual Que" GreaterThanString="Mayor Que" LessThanOrEqualsString="Menor o Igual Que" LessThanString="Menor Que" LikeString="Como" NonEmptyString="No Vacio" NotEqualsString="No Igual " NotLikeString="No Como" StartsWithString="Empieza Con">
                                <FilterOperandDropDownStyle BackColor="Blue" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px">
                                    <Padding Left="2px" />
                                </FilterOperandDropDownStyle>
                                <FilterHighlightRowStyle BackColor="Red" ForeColor="White">
                                </FilterHighlightRowStyle>
                                <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Height="300px" Width="200px">
                                    <Padding Left="2px" />
                                </FilterDropDownStyle>
                                <FilterOperandButtonStyle BackColor="White">
                                </FilterOperandButtonStyle>
                                <FilterOperandItemHoverStyle BackColor="Desktop" Cursor="Hand" HorizontalAlign="Left">
                                </FilterOperandItemHoverStyle>
                                <FilterOperandItemStyle BackColor="Menu" HorizontalAlign="Left">
                                </FilterOperandItemStyle>
                                <FilterRowStyle BackColor="White">
                                </FilterRowStyle>
                            </FilterOptionsDefault>
                            <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Left">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="235px"
                                Width="432px">
                            </FrameStyle>
                            <Pager AllowPaging="True" MinimumPagesForDisplay="2" NextText="-&gt;" PageSize="5"
                                PrevText="&lt;-" ChangeLinksColor="True">
                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
                            </Pager>
                            <AddNewBox>
                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
                            </AddNewBox>
                            <SelectedRowStyleDefault BackColor="Transparent" Font-Bold="True" Font-Overline="False"
                                Font-Size="12pt" ForeColor="Red" TextOverflow="Ellipsis">
                            </SelectedRowStyleDefault>
                        </DisplayLayout>
                    </igtbl:UltraWebGrid><asp:DetailsView  OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated" OnItemDeleted="DetailsView_ItemDeleted" ID="DVExpediente" runat="server" AutoGenerateRows="False" BorderColor="#8080FF"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="1" DataKeyNames="ExpedienteCodigo"
                        DataSourceID="ExpedienteByIdDataSource" DefaultMode="Insert" Font-Names="MS Sans Serif"
                        Font-Size="12pt" ForeColor="#333333" GridLines="None" Height="50px" HorizontalAlign="Center"
                        Width="432px" style="vertical-align: middle; text-align: left">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <EditRowStyle BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="ExpedienteCodigo" HeaderText="ExpedienteCodigo" ReadOnly="True"
                                SortExpression="ExpedienteCodigo" />
                            <asp:BoundField DataField="ExpedienteNombre" HeaderText="ExpedienteNombre" SortExpression="ExpedienteNombre" />
                            <asp:BoundField DataField="ExpedienteCodigoPadre" HeaderText="ExpedienteCodigoPadre"
                                SortExpression="ExpedienteCodigoPadre" />
                        </Fields>
                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:DetailsView>
                    <asp:ObjectDataSource ID="ExpedienteDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExpediente" TypeName="DSExpedienteTableAdapters.ExpedienteTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ExpedienteNombre" Type="String" />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="ExpedienteNombre" Type="String" />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ExpedienteByIdDataSource" runat="server" DeleteMethod="Delete"
                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetExpedienteById"
                        TypeName="DSExpedienteTableAdapters.ExpedienteTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="ExpedienteNombre" Type="String" />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DGExpediente" Name="ExpedienteCodigo" PropertyName="DisplayLayout.ActiveRow.DataKey"
                                Type="String" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="ExpedienteNombre" Type="String" />
                            <asp:Parameter Name="ExpedienteCodigoPadre" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </span></strong>
    
           
</asp:Content>

