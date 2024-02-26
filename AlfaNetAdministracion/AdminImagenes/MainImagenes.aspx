<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MainImagenes.aspx.cs" Inherits="_MainImagenes" %>


<%@ Register Assembly="Infragistics2.WebUI.WebSchedule.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="ig_sched" %>

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
                    CARPETAS</td>
            </tr>
            <tr>
                <td style="width: 255px; height: 420px; position: static;">
                    <ignav:UltraWebTree ID="TreeViewCarpeta" runat="server" DefaultImage="ig_treeOfficeFolder.gif" DefaultSelectedImage="ig_treeOfficeFolder.gif"
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
                    <igtbl:UltraWebGrid ID="DGCarpeta" runat="server" Browser="Xml"
                        DataSourceID="CarpetaDataSource" EnableAppStyling="True" Height="235px" Style="left: 275px; top: -63px;" StyleSetName="BlueGel"
                        Width="572px">
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
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaCodigo" HeaderText="Codigo" IsBound="True"
                                        Key="CarpetaCodigo">
                                        <Header Caption="Codigo">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaNombre" HeaderText="Nombre" IsBound="True"
                                        Key="CarpetaNombre">
                                        <Header Caption="Nombre">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaAno" DataType="System.Int32" HeaderText="A&#241;o"
                                        IsBound="True" Key="CarpetaAno">
                                        <Header Caption="A&#241;o">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaMes" DataType="System.Int32" HeaderText="Mes"
                                        IsBound="True" Key="CarpetaMes">
                                        <Header Caption="Mes">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaUbicacion" HeaderText="Ubicacion" IsBound="True"
                                        Key="CarpetaUbicacion">
                                        <Header Caption="Ubicacion">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="CarpetaCodigoPadre" HeaderText="Carpeta_Padre"
                                        IsBound="True" Key="CarpetaCodigoPadre">
                                        <Header Caption="Carpeta_Padre">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="6" />
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
                            HeaderClickActionDefault="SortMulti" LoadOnDemand="Xml" Name="DGCarpeta" NoDataMessage="No hay datos para mostrar:"
                            RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeCellDefault="Extended"
                            SelectTypeColDefault="Extended" SelectTypeRowDefault="Extended" TableLayout="Fixed"
                            Version="4.00" ViewType="OutlookGroupBy" AllowColSizingDefault="Free">
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
                                Width="572px">
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
                    </igtbl:UltraWebGrid><asp:DetailsView  OnItemInserted="DetailsView_ItemInserted" OnItemUpdated="DetailsView_ItemUpdated" OnItemDeleted="DetailsView_ItemDeleted" ID="DVCarpeta" runat="server" AutoGenerateRows="False" BorderColor="#8080FF"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="1" DataKeyNames="CarpetaCodigo"
                        DataSourceID="CarpetaByIdDataSource" DefaultMode="Insert" Font-Names="MS Sans Serif"
                        Font-Size="12pt" ForeColor="#333333" GridLines="None" Height="50px" HorizontalAlign="Center"
                        Width="573px" style="vertical-align: middle; text-align: left">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <EditRowStyle BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:TemplateField HeaderText="Codigo" SortExpression="CarpetaCodigo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtCodigo" runat="server" Text='<%# Bind("CarpetaCodigo") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtCodigo" runat="server" ControlToValidate="TxtCodigo"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TxtCodigo" runat="server" Text='<%# Bind("CarpetaCodigo") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtCodigo" runat="server" ControlToValidate="TxtCodigo"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CarpetaCodigo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="CarpetaNombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("CarpetaNombre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtNombre" runat="server" ControlToValidate="TxtNombre"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("CarpetaNombre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtNombre" runat="server" ControlToValidate="TxtNombre"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CarpetaNombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mes" SortExpression="CarpetaMes">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="LstMes" runat="server" SelectedValue='<%# Bind("CarpetaMes") %>'
                                        Width="150px">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar...</asp:ListItem>
                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="LstMes" runat="server" SelectedValue='<%# Bind("CarpetaMes") %>'
                                        Width="150px">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar...</asp:ListItem>
                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CarpetaMes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="A&#241;o" SortExpression="CarpetaAno">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="LstAño" runat="server" SelectedValue='<%# Bind("CarpetaAno") %>'
                                        Width="150px">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar...</asp:ListItem>
                                        <asp:ListItem>2000</asp:ListItem>
                                        <asp:ListItem>2001</asp:ListItem>
                                        <asp:ListItem>2002</asp:ListItem>
                                        <asp:ListItem>2003</asp:ListItem>
                                        <asp:ListItem>2004</asp:ListItem>
                                        <asp:ListItem>2005</asp:ListItem>
                                        <asp:ListItem>2006</asp:ListItem>
                                        <asp:ListItem>2007</asp:ListItem>
                                        <asp:ListItem>2008</asp:ListItem>
                                        <asp:ListItem>2009</asp:ListItem>
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("CarpetaAno") %>'
                                        Width="150px">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar...</asp:ListItem>
                                        <asp:ListItem>2000</asp:ListItem>
                                        <asp:ListItem>2001</asp:ListItem>
                                        <asp:ListItem>2002</asp:ListItem>
                                        <asp:ListItem>2003</asp:ListItem>
                                        <asp:ListItem>2004</asp:ListItem>
                                        <asp:ListItem>2005</asp:ListItem>
                                        <asp:ListItem>2006</asp:ListItem>
                                        <asp:ListItem>2007</asp:ListItem>
                                        <asp:ListItem>2008</asp:ListItem>
                                        <asp:ListItem>2009</asp:ListItem>
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CarpetaAno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ubicacion" SortExpression="CarpetaUbicacion">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtUbicacion" runat="server" Text='<%# Bind("CarpetaUbicacion") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtUbicacion" runat="server" ControlToValidate="TxtUbicacion"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TxtUbicacion" runat="server" Text='<%# Bind("CarpetaUbicacion") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtUbicacion" runat="server" ControlToValidate="TxtUbicacion"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("CarpetaUbicacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Carpeta_Padre" SortExpression="CarpetaCodigoPadre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtCarpetaPadre" runat="server" Text='<%# Bind("CarpetaCodigoPadre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtCarpetaPadre" runat="server" ControlToValidate="TxtCarpetaPadre"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TxtCarpetaPadre" runat="server" Text='<%# Bind("CarpetaCodigoPadre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtCarpetaPadre" runat="server" ControlToValidate="TxtCarpetaPadre"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarpetaCodigoPadre") %>'></asp:Label>
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
                                                CommandName="Delete" ImageUrl="~/Images/ToolBar/Delete.png" Text="Eliminar" OnClientClick="return confirm('Esta seguro que desea eliminar este registro?');"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:DetailsView>
                    <asp:ObjectDataSource ID="CarpetaDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCarpeta" TypeName="DSCarpetaTableAdapters.CarpetaTableAdapter"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="CarpetaByIdDataSource" runat="server" DeleteMethod="Delete"
                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCarpetaById"
                        TypeName="DSCarpetaTableAdapters.CarpetaTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_CarpetaCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CarpetaCodigo" Type="String" />
                            <asp:Parameter Name="CarpetaNombre" Type="String" />
                            <asp:Parameter Name="CarpetaAno" Type="Int32" />
                            <asp:Parameter Name="CarpetaMes" Type="Int32" />
                            <asp:Parameter Name="CarpetaUbicacion" Type="String" />
                            <asp:Parameter Name="CarpetaCodigoPadre" Type="String" />
                            <asp:Parameter Name="Original_CarpetaCodigo" Type="String" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DGCarpeta" Name="CarpetaCodigo" PropertyName="DisplayLayout.ActiveRow.DataKey"
                                Type="String" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CarpetaCodigo" Type="String" />
                            <asp:Parameter Name="CarpetaNombre" Type="String" />
                            <asp:Parameter Name="CarpetaAno" Type="Int32" />
                            <asp:Parameter Name="CarpetaMes" Type="Int32" />
                            <asp:Parameter Name="CarpetaUbicacion" Type="String" />
                            <asp:Parameter Name="CarpetaCodigoPadre" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp; 
                </td>
            </tr>
        </table>
    </span></strong>
    
           
</asp:Content>
