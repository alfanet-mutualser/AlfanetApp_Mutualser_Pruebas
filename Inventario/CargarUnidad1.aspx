<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargarUnidad.aspx.cs" Inherits="CargarUnidad" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="StyleSheet.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
    <link href="AlfaNetStyle.css" rel="stylesheet" type="text/css" />
        <form id="form1" runat="server">
        <br />        
        <br />
        <asp:ScriptManager ID="ScriptManager" runat="server">
                                                        </asp:ScriptManager>
        <asp:UpdatePanel id="UpdatePanelDependencia" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
            <asp:Label id="LbCodDependencia" runat="server" Width="145px" Text="Dependencia:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
                                                    <cc1:PopupControlExtender id="PopupControlDependencia" runat="server" PopupControlID="PnlDependencia" TargetControlID="DDLDependencia" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <cc1:AutoCompleteExtender id="AutoCompleteDependencia" runat="server" TargetControlID="DDLDependencia" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetDependenciaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox id="DDLDependencia" runat="server" Width="400px" Font-Size="8pt" CssClass="TxtAutoComplete">
                                                    </asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="NombreDependencia" runat="server" TargetControlID= "DDLDependencia" WatermarkText="Nombre Dependencia" WatermarkCssClass="WaterMarkedTextBox"></cc1:TextBoxWatermarkExtender>
                                                    <asp:Panel id="PnlDependencia" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVDependencia" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" OnSelectedNodeChanged="TreeVDependencia_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                    <HoverNodeStyle Font-Underline="True">
                                                                    </HoverNodeStyle>
                                                                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                    </SelectedNodeStyle>
                                                                    <Nodes>
                                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0">
                                                                        </asp:TreeNode>
                                                                    </Nodes>
                                                                    <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                    </NodeStyle>
                                                            </asp:TreeView>
                                                                                                                     </div>
                                                     </asp:Panel> 
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="DDLDependencia" ErrorMessage="*Favor Ingrese Dependencia"></asp:RequiredFieldValidator>
            </ContentTemplate>
                                                 
                                            </asp:UpdatePanel>
                                                             
            <%--<asp:DropDownList ID="DDLDependencia" runat="server" DataSourceID="SqlDataSource1" DataTextField="DependenciaNombre" DataValueField="DependenciaCodigo" EnableTheming="True" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT [DependenciaCodigo], [DependenciaNombre] FROM [Dependencia] where DependenciaHabilitar = '1' and DependenciaPermiso = '1'"></asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="*Favor Ingrese Dependencia" InitialValue="0"></asp:RequiredFieldValidator>
--%>            <br />
            <br />
            <asp:Label id="LbNomUnidad" runat="server" Width="145px" Text="Nombre Unidad:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBNomUnidad" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBNomUnidad" ErrorMessage="*Favor Ingrese el nombre de la unidad."></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label id="LbDetUnidad" runat="server" Width="145px" Text="Detalle Unidad:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBDetUnidad" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TBDetUnidad" ErrorMessage="*Favor Ingrese el detalle de la unidad."></asp:RequiredFieldValidator>
<%--            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1"  runat="server"></cc1:ToolkitScriptManager>
--%>            <br />
            <br />
            <asp:Label id="LbFechaExtremaInicial" runat="server" Width="145px" Text="Fecha Extrema Inicial:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBFechaExtremaInicial" runat="server"></asp:TextBox>&nbsp; <asp:Image id="Imagen1" runat="server" ImageUrl="Imagenes/calendario.gif" ></asp:Image>
            <cc1:CalendarExtender ID="CEFechaExtremaInicial" runat="server" Enabled="True" TargetControlID="TBFechaExtremaInicial" PopupButtonID="Imagen1" Format="dd/MM/yyyy"></cc1:CalendarExtender>            
            <asp:Label id="LbFechaExtremaFinal" runat="server" Width="145px" Text="Fecha Extrema Final:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBFechaExtremaFinal" runat="server"></asp:TextBox>&nbsp; <asp:Image id="Imagen2" runat="server" ImageUrl="Imagenes/calendario.gif" ></asp:Image>
            <cc1:CalendarExtender ID="CEFechaExtremaFinal" runat="server" Enabled="True" TargetControlID="TBFechaExtremaFinal" PopupButtonID="Imagen2" Format="dd/MM/yyyy"></cc1:CalendarExtender>
            &nbsp;&nbsp;&nbsp;            
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TBFechaExtremaInicial" ErrorMessage="*Favor Ingrese la fecha Extrema Inicial"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TBFechaExtremaFinal" ErrorMessage="*Favor Ingrese la fecha Extrema Final"></asp:RequiredFieldValidator>
            &nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TBFechaExtremaInicial" ErrorMessage="*Fecha Extrema Final debe ser mayor o igual a la Fecha Extrema Inicial" Operator="GreaterThanEqual" Type="Date" ControlToValidate="TBFechaExtremaFinal"></asp:CompareValidator>
            <br />
            <asp:Label id="LbUbicacion" runat="server" Width="145px" Text="Ubicacion:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>        
            <%--<asp:DropDownList ID="DDLUbicacion" runat="server" DataSourceID="SqlDataSource2" DataTextField="UbicacionNombre" DataValueField="UbicacionCodigo" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT * FROM [UbicacionGeografica] where UbicacionHabilitar = '1'"></asp:SqlDataSource>
--%>        <cc1:AutoCompleteExtender id="AutoCompleteExtenderUbicacion" runat="server" TargetControlID="DDLUbicacion" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetUbicacionByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            <asp:TextBox ID="DDLUbicacion" runat="server" Font-Size="8pt" Width="200px">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DDLUbicacion" ErrorMessage="*Favor Ingrese la Ubicación Geografica" InitialValue="0"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label id="LbForma" runat="server" Width="145px" Text="Almacenamiento:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
<%--            <asp:DropDownList ID="DDLForma" runat="server" DataSourceID="SqlDataSource3" DataTextField="FormaNombre" DataValueField="FormaCodigo" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>
--%>
            <cc1:AutoCompleteExtender id="AutoCompleteExtenderForma" runat="server" TargetControlID="DDLForma" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetFormaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            <asp:TextBox ID="DDLForma" runat="server" Font-Size="8pt" Width="200px">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label id="LbNumFolios" runat="server" Width="145px" Text="Numero de Folios:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBNumFolios" runat="server"></asp:TextBox>
            &nbsp;
<%--            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT * FROM [Forma_de_conservacion] where FormaHabilitar = '1'"></asp:SqlDataSource>
--%>            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DDLForma" ErrorMessage="*Favor Ingrese el tipo de almacenamiento." InitialValue="0"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBNumFolios" ErrorMessage="*Favor Ingrese la cantidad de Folios"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TBNumFolios" ErrorMessage="*Favor Ingrese la cantidad de Folios" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />
            <br />
                                                                    <asp:UpdatePanel id="UpdatePanelSerie" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
            <asp:Label id="LbSerie" runat="server" Width="145px" Text="Serie:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <%--<asp:DropDownList ID="DDLSerie" runat="server" DataSourceID="SqlDataSource4" DataTextField="SerieNombre" DataValueField="SerieCodigo" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT * FROM [Serie] where SerieHabilitar = '1' and SeriePermiso = '1'"></asp:SqlDataSource>
            --%>

            <cc1:AutoCompleteExtender id="AutoCompleteSerie" runat="server" TargetControlID="DDLSerie" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetSerieByTextNull" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <cc1:PopupControlExtender id="PopupControlSerie" runat="server" PopupControlID="PnlSerie" TargetControlID="DDLSerie" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <asp:TextBox id="DDLSerie" runat="server" Width="400px" Font-Size="8pt" CssClass="TxtAutoComplete">
                                                    </asp:TextBox>
                                                    <asp:Panel id="PnlSerie" runat="server" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVSerie" runat="server" Width="300px" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" OnSelectedNodeChanged="TreeVSerie_SelectedNodeChanged" ExpandDepth="0" ImageSet="XPFileExplorer" NodeIndent="15">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA">
                                                                </HoverNodeStyle>
                                                                <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="False" BackColor="#B5B5B5">
                                                                </SelectedNodeStyle>
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..." Value="0">
                                                                    </asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                </NodeStyle>
                                                            </asp:TreeView>
                                                        </div>
                                                    </asp:Panel>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DDLSerie" ErrorMessage="*Favor Ingrese la serie" InitialValue="0"></asp:RequiredFieldValidator>
            </ContentTemplate>
                                          </asp:UpdatePanel>
            <br />
            <br />
                        <asp:UpdatePanel id="UPAccion" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>     
            <asp:Label id="LbAccion" runat="server" Width="145px" Text="Accion:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
<%--            <asp:DropDownList ID="DDLAccion" runat="server" DataSourceID="SqlDataSource5" DataTextField="WFAccionNombre" DataValueField="WFAccionCodigo" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT * FROM [WFAccion] where WFAccionHabilitar = '1'"></asp:SqlDataSource>
            --%>
                                              
                                                    <cc1:AutoCompleteExtender id="AutoCompleteAccion" runat="server" TargetControlID="DDLAccion" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetWFAccionTextByText" MinimumPrefixLength="1" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <cc1:PopupControlExtender id="PopupControlAccion" runat="server" TargetControlID="DDLAccion" PopupControlID="PnlAccion" Position="Right">
                                                    </cc1:PopupControlExtender>
                                                    <asp:Panel id="PnlAccion" runat="server" Width="300px" Height="300px" CssClass="popupControl" ScrollBars="Vertical">
                                                        <div>
                                                            <asp:TreeView id="TreeVAccion" runat="server" Width="300px" ShowLines="True" OnTreeNodePopulate="TreeVAccion_TreeNodePopulate" OnSelectedNodeChanged="TreeVAccion_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False">
                                                                </ParentNodeStyle>
                                                                <HoverNodeStyle Font-Underline="True">
                                                                </HoverNodeStyle>
                                                                <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True">
                                                                </SelectedNodeStyle>
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Accion..." Value="0">
                                                                    </asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                                                </NodeStyle>
                                                            </asp:TreeView>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:TextBox id="DDLAccion" runat="server" Width="400px" Font-Size="8pt" CssClass="TxtAutoComplete">
                                                    </asp:TextBox> 
                                               </ContentTemplate>
                                          </asp:UpdatePanel>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DDLAccion" ErrorMessage="*Favor Ingrese la acción." InitialValue="0"></asp:RequiredFieldValidator>
            <br />
            <br />
                                                                    <asp:UpdatePanel id="UpdatePanelTipologia" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
            <asp:Label id="LbTipologia" runat="server" Width="145px" Text="Tipologia:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
<%--            <asp:DropDownList ID="DDLTipologia" runat="server" DataSourceID="SqlDataSource6" DataTextField="TipologiaNombre" DataValueField="TipologiaCodigo" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
            </asp:DropDownList>--%>
                             <cc1:AutoCompleteExtender id="AutoCompleteExtenderTipologia" runat="server" TargetControlID="DDLTipologia" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetTipologiaByTextnull" MinimumPrefixLength="1" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:TextBox ID="DDLTipologia" runat="server" Font-Size="8pt" Width="200px">
                                                    </asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
<%--            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:InventariosConnectionString %>" SelectCommand="SELECT * FROM [Tipologia] where TipologiaHabilitar = '1'"></asp:SqlDataSource>
--%>            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DDLTipologia" ErrorMessage="*Favor Ingrese la Tipologia." InitialValue="0"></asp:RequiredFieldValidator>        
            <br />
            <br />
            <asp:Label id="LBRegInventario" runat="server" Width="145px" Text="Registro Inventario:" Font-Bold="False" Font-Italic="False" CssClass="PropLabels"></asp:Label>
            <asp:TextBox ID="TBRegInventario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TBRegInventario" ErrorMessage="*Favor Ingrese el Registro del Inventario Fisico"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TBRegInventario" ErrorMessage="*Favor Ingrese el Registro del Inventario Fisico" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="BtnGuardar" runat="server" ImageUrl="~/Imagenes/archivar.jpg" OnClick="BtnGuardar_Click" ToolTip="Radicar" />
            <br />
            <br />
            <asp:Label ID="lblMessage2" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </form>
    </body>
</html>
