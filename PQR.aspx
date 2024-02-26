<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="PQR.aspx.cs" Inherits="PQR" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl"
    TagPrefix="dxuc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script type="text/javascript">
    function urlInt(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + src.innerText + '&Admon=S&ImagenFolio=1&GrupoCodigo=2', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
</script>
        <table id="TABLE1" style="font-size: 8pt; width: 100%;">
            <tr>
                <td style="font-size: 8pt; background-image: none; vertical-align: top; color: inactivecaption;
                    font-family: Sans-Serif; background-color: transparent; text-align: center;">
                    &nbsp;<asp:Label ID="Label1" runat="server" CssClass="LabelStyle" Font-Bold="True" Font-Italic="False"
                        Font-Size="Medium" Text="! Bienvenido al Sistema de Tramites en línea !"
                        Width="549px" BackColor="Desktop"></asp:Label><br />
                    <img src="AlfaNetImagen/Logo/LogoEmpresa.jpg" style="width: 200px; height: 63px" />
                    <hr />
                    <table bgcolor="ghostwhite" style="vertical-align: top; border-top-style: none;
                        border-right-style: none; border-left-style: none; text-align: center; border-bottom-style: none; margin-top: 1px; margin-left: 1px; margin-right: 1px;" id="TABLE2">
                        <tr>
                            <td colspan="3" style="vertical-align: top; text-align: center">
                                <table style="width: 100%; height: 100%">
                                    <tr>
                                        <td>
                                <asp:Table ID="Table3" runat="server" CellPadding="0" CellSpacing="2">
                                    <asp:TableRow ID="TableRow1" runat="server">
                                        <asp:TableCell ID="clAceptar" runat="server" CssClass="BarButton">
                                            <asp:LinkButton ID="cmdAceptar" runat="server" OnClick="cmdAceptar_Click" Text="Radicar Tramite" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                        </asp:TableCell>
                                        <asp:TableCell runat="server">|</asp:TableCell>
                                        <asp:TableCell ID="clNuevo" runat="server" CssClass="BarButton">
                                            <asp:LinkButton ID="cmdNuevo" runat="server" OnClick="BtnNuevoRad_Click" CausesValidation="false"
                                                Text="Nuevo Tramite" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                        </asp:TableCell>
                                        <asp:TableCell ID="TableCell2" runat="server" CssClass="BarButton">
                                            <asp:LinkButton ID="clConsulta" runat="server" OnClick="cmdConsultar_Click" CausesValidation="false"
                                                Text="Consulta Tramite" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                        </asp:TableCell>
                                        <asp:TableCell ID="TableCell1" runat="server">|</asp:TableCell>
                                        <asp:TableCell ID="clActualizar" runat="server" CssClass="BarButton">
                                            <asp:LinkButton ID="cmdActualizar" runat="server" OnClick="cmdActualizar_Click" CausesValidation="false"
                                                Text="Grabar Tramite" CssClass="lnkbtn">
                                        </asp:LinkButton>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" BorderWidth="0px" Font-Bold="True" Font-Size="Small"
                                                ForeColor="ControlDarkDark"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="vertical-align: top; text-align: center">
                                <asp:UpdatePanel id="UpdatePanel8" runat="server" Visible="False">
                                    <contenttemplate>
<TABLE><TBODY><TR><TD><asp:Label style="TEXT-ALIGN: left" id="Label15" runat="server" Width="240px" Text="Nit o CC Para Consultar tramites:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 3px"><asp:RequiredFieldValidator id="RFVSearchNUI" runat="server" Width="7px" SetFocusOnError="True" ErrorMessage="Debe Numero de Radicado a Consultar" ControlToValidate="TxtNuiCon" Height="15px" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator></TD><TD style="WIDTH: 159px"><asp:TextBox id="TxtNuiCon" runat="server" Width="150px" Font-Size="8pt" CausesValidation="True" CssClass="TxtAutoComplete" ValidationGroup="ValGroup1" AutoCompleteType="Homepage"></asp:TextBox> </TD><TD style="TEXT-ALIGN: right" colSpan=2></TD></TR><TR><TD style="WIDTH: 3px"><asp:Label style="TEXT-ALIGN: left" id="LblBuscarRad" runat="server" Width="240px" Text="Numero de Tramite en linea:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 3px"><asp:RequiredFieldValidator id="RequiredFieldValidator60" runat="server" Width="7px" SetFocusOnError="True" ErrorMessage="Debe Numero de Radicado a Consultar" ControlToValidate="TxtBuscarRadicado" Height="15px" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator></TD><TD style="WIDTH: 159px">&nbsp;<asp:TextBox id="TxtBuscarRadicado" runat="server" Width="150px" Font-Size="8pt" CausesValidation="True" CssClass="TxtAutoComplete" ValidationGroup="ValGroup1" AutoCompleteType="Homepage"></asp:TextBox>&nbsp;<BR />&nbsp; </TD><TD style="TEXT-ALIGN: right" colSpan=2>&nbsp;<asp:ImageButton id="ImgBtnFindRad" onclick="ImgBtnFindRad_Click" runat="server" Width="16px" ToolTip="Buscar Tramite" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" Height="15px" ValidationGroup="ValGroup1" EnableViewState="False"></asp:ImageButton>&nbsp;&nbsp; </TD></TR></TBODY></TABLE><cc1:AutoCompleteExtender id="ACBuscarRAd" runat="server" Enabled="False" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" MinimumPrefixLength="0" ServiceMethod="GetRadicadoByCodigo" ServicePath="AutoComplete.asmx" TargetControlID="TxtBuscarRadicado"></cc1:AutoCompleteExtender> <asp:RadioButtonList id="RBLSearchNUI" runat="server" Width="166px" ForeColor="RoyalBlue" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBLSearchNUI_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="0">Anonimo</asp:ListItem>
<asp:ListItem Selected="True" Value="1">Identificado</asp:ListItem>
</asp:RadioButtonList> 
</contenttemplate>
                                    <triggers>
<asp:PostBackTrigger ControlID="ImgBtnFindRad"></asp:PostBackTrigger>
</triggers>
                                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; text-align: left; height: 1px;">
                                <asp:Panel ID="Panel1" runat="server">
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                                            <img src="AlfaNetImagen/ToolBar/People.JPG" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:Label ID="DateFechaRad" runat="server" Font-Bold="True" Font-Size="XX-Small"
                                                ForeColor="ControlDarkDark" Width="133px"></asp:Label><br />
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="ControlDarkDark" Enabled="False" Visible="False">Regitrarme en el sistema</asp:LinkButton><br />
                                <br />
                                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="ControlDarkDark" Enabled="False" Visible="False">Actualizar mis datos</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 16px;">
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </td>
                            <td colspan="2" style="vertical-align: top; text-align: left; width: 610px;">
                                <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>--%>
                                <%--</ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="False">
                                                                    <contenttemplate>
<TABLE><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 142px; TEXT-ALIGN: left"><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" Width="7px" Height="15px" ControlToValidate="TxtProcedencia" ErrorMessage="Debe ingresar la Procedencia" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 142px; TEXT-ALIGN: left"><asp:Label id="LblProcedencia" runat="server" Width="140px" Text="Procedencia:" Font-Bold="True" CssClass="LabelStyle"></asp:Label> <asp:RadioButtonList id="RadBtnLstFindby" runat="server" Width="99px" Font-Size="XX-Small" ForeColor="RoyalBlue" Font-Italic="False" Height="1px" AutoPostBack="True" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="2">NUI</asp:ListItem>
<asp:ListItem Value="1">Nombre</asp:ListItem>
</asp:RadioButtonList></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 438px; TEXT-ALIGN: left"><cc1:AutoCompleteExtender id="AutoCompleteExtender2" runat="server" TargetControlID="TxtProcedencia" ServicePath="AutoComplete.asmx" ServiceMethod="GetProcedenciaByTextNombre" MinimumPrefixLength="0" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" CompletionInterval="100"></cc1:AutoCompleteExtender> <asp:SqlDataSource id="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>" SelectCommand="SELECT [TTCODTAB], [TTCODCLA], [TTVALORC] FROM [TBTABLAS] WHERE (([TTCODTAB] = @TTCODTAB) AND ([TTCODCLA] = @TTCODCLA))"><SelectParameters>
<asp:Parameter DefaultValue="PROANONI" Name="TTCODTAB" Type="String"></asp:Parameter>
<asp:Parameter DefaultValue="01" Name="TTCODCLA" Type="String"></asp:Parameter>
</SelectParameters>
</asp:SqlDataSource> <asp:DropDownList id="DropDownList2" runat="server" Width="181px" DataSourceID="SqlDataSource1" DataValueField="TTVALORC" DataTextField="TTVALORC" OnLoad="DropDownList2_Load"></asp:DropDownList> <asp:TextBox id="TxtProcedencia" tabIndex=10 runat="server" Width="420px" Font-Size="8pt" CssClass="TxtAutoComplete" Height="28px" BorderStyle="Groove" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 6px"><asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" ValidationGroup="false" Height="15px"></asp:ImageButton> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                                                </asp:UpdatePanel>
                                <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                <ContentTemplate>
<TABLE style="WIDTH: 609px"><TBODY><TR><TD colSpan=3 rowSpan=2>&nbsp;<asp:UpdatePanel id="UpdatePanel80" runat="server"><ContentTemplate>
<asp:RequiredFieldValidator id="RFVAddNUI" runat="server" ControlToValidate="TxtAddNUI" ErrorMessage="Digite su Nit o CC">*</asp:RequiredFieldValidator> <asp:Label id="Label10" runat="server" Width="146px" Text="Digite su Nit o CC:" Font-Bold="True" CssClass="LabelStyle"></asp:Label> <asp:TextBox id="TxtAddNUI" runat="server" Width="150px" ValidationGroup="ValGroupAdd" AutoPostBack="True" OnTextChanged="TxtAddNUI_TextChanged"></asp:TextBox> <asp:RadioButtonList id="RBLAddNUI" runat="server" Width="166px" ForeColor="RoyalBlue" AutoPostBack="True" OnSelectedIndexChanged="RBLAddNUI_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Value="0">Anonimo</asp:ListItem>
<asp:ListItem Selected="True" Value="1">Identificado</asp:ListItem>
</asp:RadioButtonList>&nbsp; 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="TxtAddNUI" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD><TD style="WIDTH: 18px" rowSpan=2></TD></TR><TR></TR></TBODY></TABLE><asp:UpdatePanel id="UpdatePanel9" runat="server" Visible="False"><ContentTemplate>
<TABLE style="WIDTH: 606px"><TBODY><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" Width="1px" ControlToValidate="TxtAddNombre" ErrorMessage="Ingrese el Nombre" SetFocusOnError="True">*</asp:RequiredFieldValidator> </TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="LblProcedencia2" runat="server" Width="140px" Text="Nombre:" Font-Bold="True" CssClass="LabelStyle"></asp:Label>&nbsp;<asp:TextBox id="TxtAddNombre" runat="server" Width="410px" Font-Size="10pt" BorderStyle="Groove"></asp:TextBox></TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImgBtnFndProc" onclick="ImageButton1_Click" runat="server" Width="15px" ToolTip="Buscar Procedencia" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" ValidationGroup="false" Height="15px"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label11" runat="server" Width="140px" Text="Pais:" Font-Bold="True" CssClass="LabelStyle">
</asp:Label> <asp:DropDownList id="DDLPais" runat="server"></asp:DropDownList> </TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label12" runat="server" Width="140px" Text="Departamento:" Font-Bold="True" CssClass="LabelStyle"></asp:Label> <asp:DropDownList id="DDLDepartamento" runat="server"></asp:DropDownList></TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label13" runat="server" Width="140px" Text="Ciudad:" Font-Bold="True" CssClass="LabelStyle"></asp:Label>&nbsp;<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList> <cc1:CascadingDropDown id="CascadingDropDown5" runat="server" TargetControlID="DropDownList1" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetCiudadByDepartamento" ParentControlID="DDLDepartamento" Category="Ciudad" PromptText="Seleccione Ciudad">
                                            </cc1:CascadingDropDown> <cc1:CascadingDropDown id="CascadingDropDown1" runat="server" TargetControlID="DDLPais" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetPais" Category="Pais" PromptText="Seleccione un país ..."></cc1:CascadingDropDown> <cc1:CascadingDropDown id="CascadingDropDown2" runat="server" TargetControlID="DDLDepartamento" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetDepartamentoByPais " ParentControlID="DDLPais" Category="Departamento" PromptText="Seleccione un Departamento..."></cc1:CascadingDropDown> <asp:ObjectDataSource id="ODSAddProcedencia" runat="server" UpdateMethod="UpdateProcedencia" TypeName="ProcedenciaBLL" SelectMethod="GetProcedencia" OldValuesParameterFormatString="original_{0}" InsertMethod="AddProcedencia" DeleteMethod="DeleteProcedencia">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="Original_ProcedenciaNUI" Type="String"  />
                                                </DeleteParameters>
                                                <UpdateParameters >
                                                    <asp:Parameter Name="ProcedenciaCodigo" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaNombre" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaNUIPadre" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaDireccion" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaTelefono1" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaTelefono2" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaFax" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaMail1" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaMail2" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String"  />
                                                    <asp:Parameter Name="CiudadCodigo" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaHabilitar" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaPermiso" Type="String"  />
                                                    <asp:Parameter Name="Original_ProcedenciaNUI" Type="String"  />
                                                </UpdateParameters>
                                                <InsertParameters >
                                                    <asp:Parameter Name="ProcedenciaNUI" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaCodigo" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaNombre" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaNUIPadre" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaDireccion" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaTelefono1" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaTelefono2" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaFax" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaMail1" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaMail2" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaPaginaWeb" Type="String"  />
                                                    <asp:Parameter Name="CiudadCodigo" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaHabilitar" Type="String"  />
                                                    <asp:Parameter Name="ProcedenciaPermiso" Type="String"  />
                                                </InsertParameters>
                                            </asp:ObjectDataSource> </TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" Width="1px" ControlToValidate="TxtAddDireccion" ErrorMessage="Ingrese la Direccion" SetFocusOnError="True">*</asp:RequiredFieldValidator> </TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label22" runat="server" Width="140px" Text="Direccion:" Font-Bold="True" CssClass="LabelStyle">
                                        </asp:Label> <asp:TextBox id="TxtAddDireccion" runat="server" Width="410px" BorderStyle="Groove"></asp:TextBox></TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" Width="1px" ControlToValidate="TxtAddTel1" ErrorMessage="Ingrese el Telefono 1" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label44" runat="server" Width="140px" Text="Telefono 1:" Font-Bold="True" CssClass="LabelStyle">
                                        </asp:Label> <asp:TextBox id="TxtAddTel1" runat="server" Width="75px" BorderStyle="Groove"></asp:TextBox> </TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" Width="1px" ControlToValidate="TxtAddEmail1" ErrorMessage="Ingrese el E-Mail 1" SetFocusOnError="True">*</asp:RequiredFieldValidator> </TD><TD style="WIDTH: 877px" colSpan=2><asp:Label id="Label77" runat="server" Width="140px" Text="E-Mail 1:" Font-Bold="True" CssClass="LabelStyle"></asp:Label> <asp:TextBox id="TxtAddEmail1" runat="server" Width="165px" BorderStyle="Groove"></asp:TextBox></TD><TD style="WIDTH: 18px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> 
</ContentTemplate>
                                </asp:UpdatePanel>
                        
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 10px"></TD><TD colSpan=2><asp:Label style="TEXT-ALIGN: left" id="LblDetalle" runat="server" Width="379px" Text="Ingrese su Solicitud, Petición, Queja o reclamo:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" Width="1px" ControlToValidate="TxtDetalle" ErrorMessage="Debe Ingresar su Solicitud" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD colSpan=2><asp:TextBox id="TxtDetalle" runat="server" Width="570px" Height="100px" TextMode="MultiLine" BorderStyle="Groove"></asp:TextBox></TD><TD style="WIDTH: 18px"></TD></TR><TR><TD style="WIDTH: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="7px" Height="15px" ControlToValidate="DDLNaturaleza" ErrorMessage="Debe ingresar la Naturaleza" SetFocusOnError="True">*
                                                                    </asp:RequiredFieldValidator></TD><TD><asp:Label id="LblNaturaleza" runat="server" Width="206px" Text="Seleccione el tipo de solicitud:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 435px"><cc1:autocompleteextender id="AutoCompleteNatulezaDoc" runat="server" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement" usecontextkey="True" targetcontrolid="TxtNaturaleza" servicepath="AutoComplete.asmx" servicemethod="GetNaturalezaByTextIdnullPQR" minimumprefixlength="0" completioninterval="100"></cc1:autocompleteextender> <cc1:CascadingDropDown id="CascadingDropDown3" runat="server" TargetControlID="DDLNaturaleza" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetNaturalezaByPQR" PromptText="Seleccione Tipo de Solicitud" Category="Naturaleza"></cc1:CascadingDropDown> <asp:DropDownList id="DDLNaturaleza" runat="server" Width="365px"></asp:DropDownList> <cc1:CascadingDropDown id="CascadingDropDown4" runat="server" TargetControlID="DDLNaturalezaDependenciaPQR" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetDependenciaByNaturaleza" Category="Dependencia" ParentControlID="DDLNaturaleza"></cc1:CascadingDropDown> <DIV style="HEIGHT: 1px; BACKGROUND-COLOR: transparent"><BR /><asp:DropDownList id="DDLNaturalezaDependenciaPQR" runat="server" Width="365px" BackColor="WhiteSmoke"></asp:DropDownList></DIV><asp:TextBox id="TxtNaturaleza" tabIndex=14 runat="server" Font-Size="8pt" Visible="False" CssClass="TxtAutoComplete" BorderStyle="Groove"></asp:TextBox> </TD><TD style="WIDTH: 18px"><asp:ImageButton id="ImageButton2" onclick="ImageButton2_Click1" runat="server" Width="15px" ToolTip="Buscar Naturaleza" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" ValidationGroup="false" Height="15px"></asp:ImageButton> </TD></TR><TR><TD style="WIDTH: 10px"></TD><TD></TD><TD style="WIDTH: 435px"><DIV style="Z-INDEX: 101; LEFT: 100px; WIDTH: 100px; POSITION: absolute; TOP: 100px; HEIGHT: 100px"></DIV><DIV style="Z-INDEX: 102; LEFT: 100px; WIDTH: 100px; POSITION: absolute; TOP: 100px; HEIGHT: 100px"></DIV></TD><TD style="WIDTH: 18px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                </asp:UpdatePanel>
                                <table>
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel id="UpdatePanel100" runat="server">
                                                <contenttemplate>
<TABLE style="WIDTH: 607px"><TBODY><TR><TD style="TEXT-ALIGN: left" align=right colSpan=4><asp:HiddenField id="HFNroDoc" runat="server"></asp:HiddenField>&nbsp;&nbsp; <asp:Label id="LblImagen" runat="server" Text="Si usted lo requiere adjunte uno o varios documentos al tramite:" Font-Bold="True" CssClass="LabelStyle"></asp:Label>&nbsp;<asp:Label id="LblDocumentoNro" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: right" colSpan=2>&nbsp; <IMG src="AlfaNetImagen/ToolBar/file.gif" /></TD><TD style="TEXT-ALIGN: left" align=right colSpan=2><dxuc:ASPxUploadControl id="ASPxUploadControl1" runat="server" Width="100%" Height="3px" ShowProgressPanel="True" ShowAddRemoveButtons="True">
<RemoveButton Text="Remover"></RemoveButton>

<UploadButton Text="Adjuntar"></UploadButton>

<CancelButton Text="Cancelar"></CancelButton>

<AddButton Text="Agregar Nuevo Archivo"></AddButton>
</dxuc:ASPxUploadControl> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                            </asp:UpdatePanel></td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD style="height: 48px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="7px" Height="15px" ControlToValidate="TxtMedioRecibo" ErrorMessage="Debe ingresar el Medio" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD style="height: 48px"><asp:Label id="LblMedioRecibo" runat="server" Width="140px" Text="Medio de Recibo:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="height: 48px"><cc1:autocompleteextender id="AutoCompleteMedioRecibo" runat="server" usecontextkey="True" targetcontrolid="TxtMedioRecibo" servicepath="AutoComplete.asmx" servicemethod="GetMedioByText" minimumprefixlength="0" completioninterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:autocompleteextender> <asp:TextBox id="TxtMedioRecibo" tabIndex=16 runat="server" Width="424px" Font-Size="8pt" Text='<%# Eval("MedioCodigo") %>' CssClass="TxtAutoComplete" BorderStyle="Groove"></asp:TextBox> </TD><TD style="WIDTH: 3px; height: 48px;"><asp:ImageButton id="ImageButton3" onclick="ImageButton3_Click1" runat="server" Width="15px" ToolTip="Buscar Medio" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" CausesValidation="False" Height="15px" ValidationGroup="false"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Width="7px" Height="15px" ControlToValidate="TxtExpediente" ErrorMessage="Debe ingresar el Expediente" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="Label3" runat="server" Width="140px" Font-Bold="True" Text="Expediente:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:autocompleteextender id="AutoCompleteExpediente" runat="server" usecontextkey="True" targetcontrolid="TxtExpediente" servicepath="AutoComplete.asmx" servicemethod="GetExpedienteByTextNombre" minimumprefixlength="0" completioninterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:autocompleteextender> <asp:TextBox id="TxtExpediente" tabIndex=18 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" BorderStyle="Groove"></asp:TextBox> </TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton4" onclick="ImageButton4_Click1" runat="server" Width="15px" Height="15px" ValidationGroup="flase" CausesValidation="False" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Width="7px" SetFocusOnError="True" ErrorMessage="Debe ingresar el Destino" ControlToValidate="TxtSerieD" Height="15px">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblCargarA" runat="server" Width="140px" Text="Radicado Por:" Font-Bold="True" CssClass="LabelStyle"></asp:Label></TD><TD style="WIDTH: 416px"><cc1:autocompleteextender id="AutoCompleteExtender1" runat="server" completioninterval="100" minimumprefixlength="0" servicemethod="GetDependenciaByText" servicepath="AutoComplete.asmx" targetcontrolid="TxtSerieD" usecontextkey="True"></cc1:autocompleteextender><asp:HiddenField id="HFCargar" runat="server"></asp:HiddenField> <cc1:popupcontrolextender id="PopupControlExtender1" runat="server" targetcontrolid="ImgFindCargar" position="Top" popupcontrolid="Panel88" commitscript="e.value += ' - SEND A MEETING REQUEST!';" commitproperty="value" behaviorid="PopupControlExtender1">
                                    </cc1:popupcontrolextender> <asp:TextBox id="TxtSerieD" tabIndex=20 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" BorderStyle="Groove"></asp:TextBox> <asp:Panel id="Panel88" runat="server" Width="424px" CssClass="popupControl" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeView1" runat="server" ShowLines="True" OnTreeNodePopulate="TreeView1_TreeNodePopulate" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <HoverNodeStyle Font-Underline="True" />
                                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..."
                                                                        Value="0"></asp:TreeNode>
                                                                </Nodes>
                                                            </asp:TreeView> <asp:TreeView id="TreeVSerie" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" OnSelectedNodeChanged="TreeVSerie_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <HoverNodeStyle Font-Underline="True" />
                                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Serie..."
                                                                        Value="0"></asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                            </asp:TreeView> <asp:TreeView id="TreeVProceso" runat="server" ShowLines="True" OnTreeNodePopulate="TreeVProceso_TreeNodePopulate" OnSelectedNodeChanged="TreeVProceso_SelectedNodeChanged" ExpandDepth="0">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <HoverNodeStyle Font-Underline="True" />
                                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                                <Nodes>
                                                                    <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Proceso..."
                                                                        Value="0"></asp:TreeNode>
                                                                </Nodes>
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                            </asp:TreeView> </DIV></asp:Panel> </TD><TD style="WIDTH: 3px"><asp:Image id="ImgFindCargar" runat="server" Width="15px" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png" Height="15px"></asp:Image></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                    <Triggers>
<asp:AsyncPostBackTrigger ControlID="TreeVProceso" EventName="SelectedNodeChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="TreeView1" EventName="SelectedNodeChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="TreeVSerie" EventName="SelectedNodeChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
<TABLE style="WIDTH: 270px"><TBODY><TR><TD><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Width="7px" Height="15px" ControlToValidate="TxtAccion" ErrorMessage="Debe ingresar la Accion" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD><asp:Label id="LblAccion" runat="server" Width="140px" Font-Bold="True" Text="Accion:" CssClass="LabelStyle"></asp:Label></TD><TD><cc1:autocompleteextender id="AutoCompleteAccion" runat="server" usecontextkey="True" targetcontrolid="TxtAccion" servicepath="AutoComplete.asmx" servicemethod="GetWFAccionTextByText" minimumprefixlength="0" completioninterval="100"></cc1:autocompleteextender> <asp:TextBox id="TxtAccion" tabIndex=22 runat="server" Width="424px" Font-Size="8pt" CssClass="TxtAutoComplete" CausesValidation="True" BorderStyle="Groove"></asp:TextBox> </TD><TD style="WIDTH: 3px"><asp:ImageButton id="ImageButton5" onclick="ImageButton5_Click1" runat="server" Width="15px" Height="15px" ValidationGroup="false" CausesValidation="False" ImageUrl="~/AlfaNetImagen/ToolBar/zoom.png"></asp:ImageButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                </asp:UpdatePanel>
                                </td>
                        </tr>
                    </table>
                    <hr />
                   </td>
            </tr>
            <tr>
                <td style="font-size: 8pt; background-image: none; vertical-align: top; color: inactivecaption;
                    font-family: Sans-Serif; background-color: transparent; text-align: center">
                    <asp:Panel ID="PnlRegistraDatos" runat="server" CssClass="popupControl9" Enabled="False" Visible="False">
                        <table>
                            <tr>
                                <td colspan="2" style="vertical-align: top; width: 142px; height: 21px; text-align: left">
                                    &nbsp;&nbsp;
                                    <asp:Button ID="BtnAdicionar" runat="server" OnClick="BtnAdicionar_Click" Text="Adicionar"
                                        ValidationGroup="ValGroupAdd" CssClass="PointerCursor" Font-Bold="False" />
                                    
                                    <br />
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValGroupAdd"
                                        Width="270px" />
                                    &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="width: 546px">
                            <tr>
                                <td style="width: 2148px">
                                    <asp:Label ID="Label2" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Direccion:"
                                        Width="75px"></asp:Label>
                                    <asp:TextBox ID="TxtDireccion" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Enabled="False" ReadOnly="True" Width="451px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 2148px">
                                    <asp:Label ID="Label4" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Telefono 1:"
                                        Width="75px"></asp:Label>
                                    <asp:TextBox ID="TxtTel1" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="90px"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Telefono 2:"
                                        Width="75px"></asp:Label>
                                    <asp:TextBox ID="TxtTel2" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="90px"></asp:TextBox>
                                    <asp:Label ID="Label6" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Fax:"
                                        Width="74px"></asp:Label>
                                    <asp:TextBox ID="TxtFax" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="90px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 2148px">
                                    <asp:Label ID="Label7" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="E-Mail 1:"
                                        Width="100px"></asp:Label>
                                    <asp:TextBox ID="TxtEmail1" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="165px"></asp:TextBox>
                                    &nbsp;<asp:Label ID="Label8" runat="server" CssClass="LabelStyle" Font-Bold="True"
                                        Text="E-Mail 2:" Width="75px"></asp:Label>
                                    <asp:TextBox ID="TxtEmail2" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="165px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 2148px">
                                    <asp:Label ID="Label9" runat="server" CssClass="LabelStyle" Font-Bold="True" Text="Pagina Web:"
                                        Width="100px"></asp:Label>
                                    <asp:TextBox ID="TxtPaginaWeb" runat="server" BackColor="WhiteSmoke" BorderStyle="Groove"
                                        Width="426px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<asp:Panel style="DISPLAY: none; VERTICAL-ALIGN: top; TEXT-ALIGN: center" id="PnlMensaje" runat="server" BackColor="ButtonHighlight"><TABLE width=300><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 5%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" CssClass="PointerCursor" ValidationGroup="789"></asp:ImageButton> </TD></TR><TR><TD align=center colSpan=2><BR /><TABLE><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 35px"><IMG src="AlfaNetImagen/ToolBar/error.png" /></TD><TD style="HEIGHT: 35px">&nbsp; <asp:Label id="LblUploadDetails" runat="server" ForeColor="Red"></asp:Label><BR /><asp:Label id="LblMessageBox" runat="server" Width="400px" Font-Size="Medium" ForeColor="Red"></asp:Label></TD></TR></TBODY></TABLE> <asp:Image id="Image1" runat="server" Width="18px" Visible="False" ImageUrl="~/AlfaNetImagen/ToolBar/495mini.JPG" Height="19px"></asp:Image>&nbsp;&nbsp;&nbsp;&nbsp; <TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Button id="Button1" runat="server" BackColor="Silver" Font-Size="Small" ForeColor="White" Text="Aceptar" Font-Bold="True" Font-Italic="False" CssClass="PointerCursor"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Label id="LblRpta" runat="server" Width="97px" BackColor="Silver" Font-Size="Small" ForeColor="White" Text="Respuesta" Font-Bold="True" CssClass="PointerCursor" Height="18px" BorderStyle="Outset"></asp:Label></TD></TR></TBODY></TABLE>&nbsp; <asp:HiddenField id="HFRpta" runat="server"></asp:HiddenField><BR /><asp:Panel style="LEFT: 499px" id="PnlRpta" runat="server" CssClass="popupControl" HorizontalAlign="Left">
<asp:Label id="Label80" runat="server" Width="76px" Text="Registro Nro.:"></asp:Label><BR  />
</asp:Panel> <cc1:PopupControlExtender id="PCERpta" runat="server" TargetControlID="LblRpta" PopupControlID="PnlRpta" Position="Right"></cc1:PopupControlExtender> </TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp;&nbsp;</asp:Panel> <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="LblMessageBox" popupcontrolid="PnlMensaje" backgroundcssclass="MessageStyle"></cc1:modalpopupextender> 
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummaryRadicado" runat="server" DisplayMode="List"
                        Font-Size="10pt" Style="vertical-align: middle; text-align: left" Width="100%" />
                    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                        Width="100%"></asp:Label>
                    <asp:ObjectDataSource ID="GroupDataSource" runat="server" DeleteMethod="DeleteGrupo"
                        InsertMethod="AddGrupo" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGrupoByID"
                        TypeName="GrupoBLL" UpdateMethod="UpdateGrupo">
                        <DeleteParameters>
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                            <asp:Parameter Name="GrupoNombre" Type="String" />
                            <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                            <asp:Parameter Name="GrupoConsecutivo" Type="Int32" />
                            <asp:Parameter Name="GrupoHabilitar" Type="Boolean" />
                            <asp:Parameter Name="GrupoPermiso" Type="Boolean" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="GrupoCodigo" Type="String" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                            <asp:Parameter Name="GrupoNombre" Type="String" />
                            <asp:Parameter Name="GrupoCodigoPadre" Type="String" />
                            <asp:Parameter Name="GrupoConsecutivo" Type="Int32" />
                            <asp:Parameter Name="GrupoHabilitar" Type="Boolean" />
                            <asp:Parameter Name="GrupoPermiso" Type="Boolean" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ODSPlantillaPQR" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPlantillaPQR"
                        TypeName="DSRadicadoTableAdapters.PlantillaPQRTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_MedioCodigo" Type="String" />
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="Original_AccionCodigo" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Original_MedioCodigo" Type="String" />
                            <asp:Parameter Name="Original_ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="Original_AccionCodigo" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="MedioCodigo" Type="String" />
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="AccionCodigo" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="RadicadoDataSource" runat="server" InsertMethod="AddRadicado"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetGroupById" TypeName="RadicadoBLL"
                        UpdateMethod="AddRadicado">
                        <UpdateParameters>
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                            <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime" />
                            <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                            <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                            <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                            <asp:Parameter Name="DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="RadicadoDetalle" Type="String" />
                            <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="MedioCodigo" Type="String" />
                            <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                            <asp:Parameter Name="WFAccionCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime" />
                            <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime" />
                            <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter Name="WFMovimientoNotas" Type="String" />
                            <asp:Parameter Name="SerieCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoMultitarea" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="GrupoCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoFecha" Type="DateTime" />
                            <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime" />
                            <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                            <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                            <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                            <asp:Parameter Name="DependenciaCodigo" Type="String" />
                            <asp:Parameter Name="RadicadoDetalle" Type="String" />
                            <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime" />
                            <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                            <asp:Parameter Name="MedioCodigo" Type="String" />
                            <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                            <asp:Parameter Name="WFAccionCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime" />
                            <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime" />
                            <asp:Parameter Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter Name="WFMovimientoNotas" Type="String" />
                            <asp:Parameter Name="SerieCodigo" Type="String" />
                            <asp:Parameter Name="WFMovimientoMultitarea" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
 </asp:Content>   
  
