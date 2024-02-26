<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="VisorImagenes.aspx.cs" Inherits="_VisorImagenes" %>

<%@ Register Src="../../AlfaNetDocumentos/DocEnviado/NavDocEnviado.ascx" TagName="NavDocEnviado"
    TagPrefix="uc2" %>

<%@ Register Src="../../AlfaNetDocumentos/DocRecibido/NavDocRecibido.ascx" TagName="NavDocRecibido"
    TagPrefix="uc1" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebToolbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebToolbar" TagPrefix="igtbar" %>
<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

 <script type="text/javascript">
  
  //Image zoom in/out script- by javascriptkit.com
//Visit JavaScript Kit (http://www.javascriptkit.com) for script
//Credit must stay intact for use

//var zoomfactor=0.10 //Enter factor (0.05=5%)

  function togglePopupImage(thumbnail){
  
  alert(thumbnail.src)
    //$get('spnImageText').innerHTML = thumbnail.alt;
    //$get('imgPopup').src = thumbnail.src;  
  }

  
</script>

    <span style="font-size: 10pt">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: none; vertical-align: top; width: 700px; color: inactivecaption;
                    font-family: Sans-Serif; background-color: transparent; text-align: left">
                    <uc1:NavDocRecibido ID="NavDocRecibido1" runat="server" />
                    <uc2:NavDocEnviado ID="NavDocEnviado1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="color: inactivecaption; font-family: Sans-Serif; background-image: none;
                    background-color: transparent; width: 700px; text-align: center; height: 219px; vertical-align: middle;">
                                                            &nbsp;
                    <br />
                    <asp:Label ID="Label22" runat="server" Font-Size="14pt" Height="17px" Style="text-align: center; vertical-align: middle;"
                        Width="696px"></asp:Label><br />
                    <br />
                                            <table id="Table4" language="javascript" onclick="return TABLE2_onclick()">
                                                    <tr>
                                                        <td style="width: 79px">
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="9pt"
                                                                ForeColor="CornflowerBlue" Text="Imagen :" Width="40px"></asp:Label></td>
                                                        <td align="right" style="width: 78px; vertical-align: middle; background-color: lightskyblue; text-align: center;">
                                                            <asp:FileUpload ID="FileUpload12" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2" style="height: 9px; vertical-align: middle; background-color: lightskyblue; text-align: center;">
                                                            <asp:Button ID="BtnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar"
                                                                UseSubmitBehavior="False" ValidationGroup="123" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 9px">
                                                            <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                                                                Width="346px">
                                                </asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 17px">
                                                            <asp:Label ID="Label7" runat="server" ForeColor="Red" Width="317px"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                            <asp:ObjectDataSource ID="ODSRadImagen" runat="server"
                                                                InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRadDataImagenes"
                                                                TypeName="PruebaImgTableAdapters.ImagenesTableAdapter">
                                                                <InsertParameters>
                                                                    <asp:Parameter Name="ImagenesId" Type="Int32" />
                                                                    <asp:Parameter Name="ImagenesDescripcion" Type="String" />
                                                                    <asp:Parameter Name="ImagenesNivel" Type="String" />
                                                                    <asp:Parameter Name="ImagenesIdPadre" Type="String" />
                                                                    <asp:Parameter Name="ImanegenesRuta" Type="String" />
                                                                    <asp:Parameter Name="Imagen" Type="Object" />
                                                                </InsertParameters>
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="HFImagenes" Name="NroRadicado" PropertyName="Value"
                                                                        Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                            <asp:HiddenField ID="HFImagenes" runat="server" />
                                <asp:ObjectDataSource ID="ODSRegImagen" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetRegImagenData" TypeName="PruebaImgTableAdapters.RegSelectImagenTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="HFImagenes" Name="NroRadicado" PropertyName="Value"
                                            Type="Int32" />
                                    </SelectParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ImagenesId" Type="Int32" />
                                        <asp:Parameter Name="ImagenesDescripcion" Type="String" />
                                        <asp:Parameter Name="ImagenesNivel" Type="String" />
                                        <asp:Parameter Name="ImagenesIdPadre" Type="String" />
                                        <asp:Parameter Name="ImanegenesRuta" Type="String" />
                                        <asp:Parameter Name="Imagen" Type="Object" />
                                    </InsertParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField ID="HFTipoDoc" runat="server" />
                    <table>
                        <tr>
                            <td style="width: 100px">
                                                <asp:DataList ID="DataList1" runat="server" DataKeyField="ImagenesId"
                                                    RepeatColumns="4" Width="199px" CellPadding="4" ForeColor="#333333">
                                                    <ItemTemplate>
                                                        <a href='<%# Eval("ImagenesId", "ImagenAlfaNet.aspx?codImagen={0}") %>' target="_blank">
                                                            <asp:Image ID="Image3" runat="server" AlternateText='<%# Eval("ImagenesDescripcion", "ImagenesDescripcion: {0}") %>'
                                                                Height="120px" ImageUrl='<%# Eval("ImagenesId", "ImagenAlfaNet.aspx?codImagen={0}") %>' Width="124px" />
                                                            <br />
                                                            Nombre:
                                                            <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("ImagenesDescripcion") %>'></asp:Label><br />
                                                        </a>
                                                    </ItemTemplate>
                                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                    <ItemStyle BackColor="#EFF3FB" />
                                                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingItemStyle BackColor="White" />
                                                </asp:DataList></td>
                        </tr>
                    </table>
                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink><br />
                </td>
            </tr>
        </table>
    </span>
                            <asp:ObjectDataSource ID="RadicadoDataSource" runat="server" UpdateMethod="AddRadicado"
                                TypeName="RadicadoBLL" SelectMethod="GetGroupById" OldValuesParameterFormatString="original_{0}"
                                InsertMethod="AddRadicado">
                                <UpdateParameters>
                                    <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFecha" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoFechaProcedencia" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="ProcedenciaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoNumeroExterno" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="NaturalezaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="DependenciaCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoDetalle" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="RadicadoFechaVencimiento" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="ExpedienteCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="MedioCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="DependenciaCodDestino" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFAccionCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFechaEst" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoFechaFin" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoTipo" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoNotas" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="SerieCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="WFMovimientoMultitarea" Type="String"></asp:Parameter>
                                </InsertParameters>
                            </asp:ObjectDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                                SelectCommand="SELECT [WFProcesoCodigo], [WFProcesoDescripcion], [WFProcesoHabilitar] FROM [WFProceso] WHERE ([WFProcesoHabilitar] = @WFProcesoHabilitar)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="S" Name="WFProcesoHabilitar" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:ObjectDataSource ID="GroupDataSource" runat="server" UpdateMethod="UpdateGrupo"
                                TypeName="GrupoBLL" SelectMethod="GetGrupoByID" OldValuesParameterFormatString="original_{0}"
                                InsertMethod="AddGrupo" DeleteMethod="DeleteGrupo">
                                <DeleteParameters>
                                    <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
                                    <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
                                </UpdateParameters>
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="" Name="GrupoCodigo" Type="String"></asp:Parameter>
                                </SelectParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="GrupoCodigo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoNombre" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoCodigoPadre" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="GrupoConsecutivo" Type="Int32"></asp:Parameter>
                                    <asp:Parameter Name="GrupoHabilitar" Type="Boolean"></asp:Parameter>
                                    <asp:Parameter Name="GrupoPermiso" Type="Boolean"></asp:Parameter>
                                </InsertParameters>
                            </asp:ObjectDataSource>
</asp:Content>

