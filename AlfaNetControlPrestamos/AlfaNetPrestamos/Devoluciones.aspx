<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Devoluciones.aspx.cs" Inherits="_Devoluciones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="global">
<script runat="server">

    protected void ODSDocRecExtVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        if (TxtProcedencia.Text != "")
        {
            String CodProcedencia = TxtProcedencia.Text;
            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            e.ParameterValues.Add("ProcedenciaNUI", CodProcedencia);
        }
    }
    protected void ODS_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        if (TextBox5.Text != "")
        {
            String CodProcedencia = TextBox5.Text;
            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            e.ParameterValues.Add("ProcedenciaNUI", CodProcedencia);
        }
    }
</script>

    <script type="text/javascript">
   
        function Resaltar_On(GridView)
        {
            if(GridView != null)
            {
                GridView.originalBgColor = GridView.style.backgroundColor;
                GridView.style.backgroundColor="#DBE7F6";
            }
        }

        function Resaltar_Off(GridView)
        {
            if(GridView != null)
            {
                GridView.style.backgroundColor = GridView.originalBgColor;
            }
        }

        function ColorRow(CheckBoxObj)
        {  

           if (CheckBoxObj.checked == true) {
           
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF';
           } 
           else
           {
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
    
        function OnTreeClick2(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
           ToggleControl.innerText = src.innerText;
           HFControl.innerText = "Dependencia";
        }
           function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
           ToggleControl.innerText = src.innerText;
           HFControl.innerText = "Serie";
           
        }
           function OnTreeClickMultitarea(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            ToggleControl.innerText = "Multitarea";
            HFControl.innerText = "Multitarea";
        }
           function url(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + src.innerText + '&GrupoCodigo=1&ControlDias=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
</script>
    <table  style="width: 900px">
        <tr>
            <td align="center" style="width: 1597px">
            
    
    <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="736px" style="vertical-align: top; text-align: float"> 
              <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               <div style="float: left; width: 465px; font-weight: bold;">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False" Font-Size="Larger">#</asp:Label>
                   PRESTAMOS&nbsp; DE CARPETAS</div>
                  <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="Label1" runat="server" Height="20px" Width="180px" style="vertical-align: middle; text-align: left" Font-Size="Smaller">(Ver Detalles...)</asp:Label>
                  </div>
                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
          </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0" Width="738px" style="vertical-align: top; text-align: float" HorizontalAlign="Center">
                       <%--<div id="CentrandoMar_80">--%>
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="text-align: center; height: 72px;">
                                        <table style="width: 270px; height: 35px; text-align: center;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LblProcedencia" runat="server" CssClass="LabelStyle" Font-Bold="True"
                                                        Text="Dependencia:" Width="130px"></asp:Label>
                                                </td>
                                                <td>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                                                        MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"
                                                        TargetControlID="TxtProcedencia" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                    <asp:TextBox ID="TxtProcedencia" runat="server" CssClass="TxtAutoComplete" Font-Size="8pt" TabIndex="10" Width="424px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImgBtnFindProcedencia" runat="server" CausesValidation="False"
                                                        Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" OnClick="ImgBtnFindProcedencia_Click"
                                                        ToolTip="Buscar Dependencia" ValidationGroup="false" Width="15px" />
                                                </td>
                                            </tr>
                                        </table>
                                </td>
                            </tr>
                        </table>
                    <%-- </div>   --%>
                        <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanelHeader" Width="730px" BackColor="Lavender" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;HAY PENDIENTES &nbsp;<asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; &nbsp; PRESTAMOS REALIZADOS</div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Prestamos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                            </div>
                        </asp:Panel>

                        
                        
                        <asp:Panel ID="Panel4" runat="server" CssClass="collapsePanel" Height="0" Width="736px" style="text-align: left">
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center">
                                        <asp:Button ID="BtnTerminarDocRecVen" runat="server" OnClick="BtnTerminarDocrecVen_Click"
                                            Text="Terminar" /></td>
                                    <td style="width: 409px">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LnkBtnSelTodosGVDocRecExtVen_Click"
                                            Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LnkBtnSelNingunoGVDocRecExtVen_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                            <asp:GridView ID="GVDocRecExtVen" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="1" DataKeyNames="PrestamoCodigo,WFMovimientoFecha,DependenciaCodigo,SerieCodigo,PrestamoCarpeta,GrupoCodigo,SerieNombre,DependenciaNombre"
                                DataSourceID="ODSDocRecExtVen" EmptyDataText="No tiene documentos recibidos externos vencidos"
                                Font-Size="Smaller" ForeColor="#333333" HorizontalAlign="Right" Width="730px" OnRowDataBound="GVDocRecExtVen_RowDataBound">
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prestamo No." SortExpression="PrestamoCodigo">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("PrestamoCodigo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                                Text='<%# Eval("PrestamoCodigo") %>' Visible="False"></asp:LinkButton>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("PrestamoCodigo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de Prestamo" SortExpression="WFMovimientoFecha">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Carpeta" SortExpression="PrestamoCarpeta">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Serie" SortExpression="SerieNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dependencia" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo" Visible="False">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo={0}&GrupoCodigo=1&Admon=S") %>'
                                                Target="_blank" Text="Imagenes"></asp:HyperLink>
                                            <br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}&Admon=S") %>'
                                                Target="_blank" Width="55px">Historico</asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            </asp:Panel>

                        
                        <asp:ObjectDataSource ID="ODSDocRecExtVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPrestamos"
                            TypeName="PrestamosBLL" filterexpression="DependenciaCodigo='{0}'" OnFiltering="ODSDocRecExtVen_Filtering" InsertMethod="Update_Prestamos">
                            <filterparameters>
                                <asp:ControlParameter ControlID="TxtProcedencia" Name="DependenciaCodOrigen" PropertyName="Text" />
                            </filterparameters>
                            <InsertParameters>
                                <asp:Parameter Name="PrestamoCodigo" Type="String" />
                                <asp:Parameter Name="GrupoCodigo" Type="String" />
                                <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                                <asp:Parameter Name="DependenciaCodigo" Type="String" />
                                <asp:Parameter Name="SerieCodigo" Type="String" />
                                <asp:Parameter Name="PrestamoCarpeta" Type="String" />
                            </InsertParameters>
                            
                        </asp:ObjectDataSource>
                            <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender2" runat="server"
        TargetControlID="Panel4"
        ExpandControlID="Panel3"
        CollapseControlID="Panel3" 
        Collapsed="True"
        TextLabelID="Label2"
        ImageControlID="Image2"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        &nbsp; &nbsp;
                    </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender1" runat="Server"
        TargetControlID="Panel1"
        ExpandControlID="Panel2"
        CollapseControlID="Panel2"
        TextLabelID="Label1"
        ImageControlID="Image1"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                <asp:Panel ID="Panel5" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="736px" style="vertical-align: top; text-align: left">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 465px; font-weight: bold;">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DEVOLUCIONES REALIZADAS&nbsp; DE CARPETAS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label7" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" CssClass="collapsePanel" Height="0" Width="738px" style="vertical-align: top; text-align: float" HorizontalAlign="Center">
                   <div id="CentrandoMAr_100b">
                    <table style="width: 100%; height: 100%">
                    
                        <tr>
                            <td style="text-align: float; width: 734px; height: 72px;">
                                <table style="width: 270px; height: 35px; text-align: float;">
                                    <tr>
                                        <td style="height: 47px">
                                            <asp:Label ID="Label8" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Dependencia:"
                                                Width="130px"></asp:Label>
                                        </td>
                                        <td style="height: 47px">
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                                        MinimumPrefixLength="0" ServiceMethod="GetDependenciaByText" ServicePath="../../AutoComplete.asmx"
                                                        TargetControlID="TextBox5" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="TxtAutoComplete" Font-Size="8pt"
                                                TabIndex="10" Width="424px"></asp:TextBox>
                                        </td>
                                        <td style="height: 47px">
                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                                        Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" OnClick="ImgBtnFindDependencia_Click"
                                                        ToolTip="Buscar Dependencia" ValidationGroup="false" Width="15px" />
                                        </td>
                                    </tr>
                                    
                                </table>
                                
                            </td>
                        </tr>
                    </table>
                    
                    
                    </div>
                    <asp:Panel ID="Panel7" runat="server" CssClass="collapsePanelHeader" Width="730px" BackColor="Lavender" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px">
                        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                            <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                &nbsp;HAY &nbsp;<asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="Larger"
                                    Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                    Width="25px">#</asp:Label>
                                &nbsp; DEVOLUCIONES&nbsp; REALIZADOS</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label10" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Height="20px" Width="180px">(Ver Prestamos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                        </div>
                       
                    </asp:Panel>
                    <asp:Panel ID="Panel8" runat="server" CssClass="collapsePanel" Height="0" Width="736px" style="text-align: left">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="1" DataKeyNames="PrestamoCodigo,WFMovimientoFecha,DependenciaCodigo,SerieCodigo,PrestamoCarpeta,GrupoCodigo,SerieNombre,DependenciaNombre"
                                DataSourceID="ObjectDataSource1" EmptyDataText="No tiene documentos recibidos externos vencidos"
                                Font-Size="Smaller" ForeColor="#333333" HorizontalAlign="Right" Width="730px" OnRowDataBound="GVDocRecExtVen_RowDataBound">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prestamo No." SortExpression="PrestamoCodigo">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PrestamoCodigo") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" PostBackUrl="javascript:void(0);"
                                            Text='<%# Eval("PrestamoCodigo") %>' Visible="False"></asp:LinkButton>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("PrestamoCodigo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha de Prestamo" SortExpression="WFMovimientoFecha">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoFecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carpeta" SortExpression="PrestamoCarpeta">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrestamoCarpeta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serie" SortExpression="SerieNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("SerieNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dependencia" SortExpression="DependenciaNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo" Visible="False">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo={0}&GrupoCodigo=1&Admon=S") %>'
                                            Target="_blank" Text="Imagenes"></asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("PrestamoCodigo", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}&Admon=S") %>'
                                            Target="_blank" Width="55px">Historico</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos recibidos externos vencidos !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBy"
                            TypeName="DSPrestamosTableAdapters.PrestamosTableAdapter" filterexpression="DependenciaCodigo='{0}'" OnFiltering="ODS_Filtering" DeleteMethod="Delete" UpdateMethod="Update" InsertMethod="Insert">
                        <filterparameters>
                            <asp:ControlParameter ControlID="TextBox5" Name="DependenciaCodOrigen" PropertyName="Text" />
                        </FilterParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="Original_PrestamoCodigo" Type="Int32" />
                            <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                            <asp:Parameter Name="WFMovimientoFechaDevolucion" Type="DateTime" />
                            <asp:Parameter Name="DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="SerieCodigo" Type="String" />
                            <asp:Parameter Name="PrestamoCarpeta" Type="String" />
                            <asp:Parameter Name="PrestamoEstado" Type="String" />
                            <asp:Parameter Name="Original_PrestamoCodigo" Type="Int32" />
                            <asp:Parameter Name="Original_GrupoCodigo" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="PrestamoCodigo" Type="Int32" />
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                            <asp:Parameter Name="DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="SerieCodigo" Type="String" />
                            <asp:Parameter Name="PrestamoEstado" Type="String" />
                            <asp:Parameter Name="PrestamoCarpeta" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
        TargetControlID="Panel8"
        ExpandControlID="Panel7"
        CollapseControlID="Panel7" 
        Collapsed="True"
        TextLabelID="Label10"
        ImageControlID="ImageButton3"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                    &nbsp; &nbsp;
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
        TargetControlID="Panel6"
        ExpandControlID="Panel5"
        CollapseControlID="Panel5"
        TextLabelID="Label7"
        ImageControlID="ImageButton1"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white" id="PnlMensaje" runat="server"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: gray" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje" __designer:wfdid="w8"></asp:Label></TD><TD style="BACKGROUND-COLOR: gray"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ValidationGroup="789" ImageAlign="Right" __designer:wfdid="w9"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align=center colSpan=2><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Black" Font-Bold="True" __designer:wfdid="w10"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="LblMessageBox" BackgroundCssClass="MessageStyle" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender> 
</contenttemplate>
                </asp:UpdatePanel>
                <%--<asp:UpdatePanel ID="UP1" runat="server">
                    <ContentTemplate>
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>--%>
           <table border="0">
               <tr>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmFecha" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmDepCod" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmTipo" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmGrupo" runat="server" />
                   </td>
               </tr>
           </table>
                </td>
        </tr>
    </table>
</div>    
  </asp:Content>



