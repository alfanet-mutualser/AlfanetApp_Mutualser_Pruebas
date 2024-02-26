<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="~/AlfanetPlantilla/EditorPlantillas.aspx.cs" Inherits="AlfanetPlantilla_EditorPlantillas" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <script type="text/javascript">
     
     function concatena() {
     
         // get the Editor's client-side object
         var editor = $get("cke_ctl00_ContentPlaceHolder1_Editor");
         alert( editor.document.getBody().getName() );
         // get the EditPanel
         var editPanel = editor.get_editPanel();
         // if the current mode is 'Design'
         if (editPanel.get_activeMode() == CKEditor.NET.ActiveModeType.Design) {
             // get the DesignPanel's object
             var designPanel = editPanel.get_activePanel();
             // For 'Undo'
             designPanel._saveContent();
             // What to do - insert some text at current selection
             //---------------------------------------------------
             var valor = "";
             var sel = document.getElementById('<%= LstCamposSel.ClientID %>');
             var listLength = sel.options.length;
             for (var i = 0; i < listLength; i++) {
                 if (sel.options[i].selected) {
                     valor = sel.options[i].value;
                 }
             }
             designPanel.insertHTML("<span style='color:#ff0000;'>" + "##" + valor + "##" + "</span>");
             //---------------------------------------------------
             // Notify Editor about content changed and update toolbars linked to the edit panel
             setTimeout(function() { designPanel.onContentChanged(); editPanel.updateToolbar(); }, 0);
             // Ensure focus in design panel
             designPanel.focusEditor();
             alert("Campo Insertado");
         }
     }
     
  </script>
      
    <asp:ObjectDataSource ID="ODSPlantilla" runat="server" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPlantilla" 
        TypeName="Plantillas.DSPlantillaTableAdapters.PlantillaTableAdapter">
        <InsertParameters>
            <asp:Parameter Name="Codigo" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="Tipo" Type="Int32" />
            <asp:Parameter Name="Estado" Type="Boolean" />
            <asp:Parameter Name="HTML" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>

    <asp:Panel ID="PnlMenu" runat="server">
    
    
        <table style="width: 400px">
        <tr>
            <td align="left" class="style6">
        <asp:LinkButton ID="LnkNuevaP" runat="server" onclick="LnkNuevaP_Click">Nueva Plantilla</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" class="style6">
        <asp:LinkButton ID="LnkModificarP" runat="server" onclick="LnkModificarP_Click">Modificar Plantilla</asp:LinkButton>
            </td>
            <td bgcolor="White" align="left">
                <asp:DropDownList ID="LstPlantillasModificar" runat="server" Width="200px" CssClass="TxtAutoComplete">
                </asp:DropDownList>
            &nbsp;<asp:LinkButton ID="LnkVerModificar" runat="server" 
                    onclick="LnkVerModificar_Click">Ver</asp:LinkButton>
            </td>
        </tr>
       
    </table>
    
    
    </asp:Panel>
    <br />
    <div style="text-align: center">
        <table width="100%">
            <tr>
                <td align="right" style="width: 19px">
                    &nbsp; &nbsp;
                </td>
                <td align="right" style="width: 15px">
                </td>
                <td align="right" style="width: 9px">
                </td>
                <td align="right" style="width: 18px">
                    &nbsp;</td>
                <td align="right" style="width: 100px">
                    <asp:ImageButton ID="ImgBtnLimpiar" runat="server" ImageUrl="~/AlfaNetPlantilla/Images/btn_Nuevo.gif"
                        OnClick="ImgBtnLimpiar_Click" />&nbsp;<asp:ImageButton ID="ImgBtnGuardar" runat="server"
                            ImageUrl="~/AlfaNetPlantilla/Images/btnAceptarClaro.gif" OnClick="ImgBtnGuardar_Click"
                            ValidationGroup="VG_CRUD" />&nbsp;<asp:ImageButton ID="ImgBtnModificar" runat="server"
                                ImageUrl="~/AlfaNetPlantilla/Images/btn_modificar.gif" OnClick="ImgBtnModificar_Click"
                                ValidationGroup="VG_CRUD" />&nbsp;
                    <asp:ImageButton ID="ImgBtnRegresar" runat="server" ImageUrl="~/AlfaNetPlantilla/Images/btnRegresarClaro.gif"
                        OnClick="ImgBtnRegresar_Click" /></td>
            </tr>
        </table>
    </div>
    
<asp:Panel ID="PnlPlantilla" runat="server">

 <asp:Label ID="LblResultado" runat="server" Font-Bold="True" ForeColor="Red" Text="..." Width="600px">
 </asp:Label>
<asp:UpdatePanel ID="upeditor" runat="server"><ContentTemplate>
    <table class="style1" style="width: 800px">
        <tr>
            <td class="style4" align="center" style="height: 205px">
                <table bgcolor="#CCCCCC" style="width: 291px; height: 145px;" align="left">
                    <tr>
                        <td align="left" class="style5">
                            <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Código"></asp:Label>
                        </td>
                        <td width="600" align="left">
                            <asp:TextBox ID="TxtCodigo" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtCodigo" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="VG_CRUD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style5">
                            <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                                Text="Descripción"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtDescripcion" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="VG_CRUD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style5">
                            <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                                Text="Habilitada"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="ChkEstado" runat="server" Checked="True" Text="..." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="height: 205px">
                <table class="style1" style="width: 64%">
                    <tr>
                        <td>
                            <asp:ListBox ID="LstCampos" runat="server" Height="150px" 
                                SelectionMode="Multiple" Width="230px"></asp:ListBox>
                            <br />
                        </td>
                        <td class="style2">
                            <table class="style1" style="font-weight: 700">
                                <tr>
                                    <td class="style3">
                                        <asp:Button ID="BtnAddOne" runat="server" onclick="BtnAddOne_Click" Text="&gt;" 
                                            Width="30px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Button ID="BtnAddMany" runat="server" Text="&gt;&gt;" Width="30px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Button ID="BttnLessOne" runat="server" Text="&lt;&lt;" Width="30px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Button ID="BtnLessMany" runat="server" Text="&lt;" Width="30px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:ListBox ID="LstCamposSel" runat="server" Font-Bold="True"  AutoPostBack="true"
                                Font-Underline="True" ForeColor="#0066FF" Height="150px" Width="230px" OnSelectedIndexChanged="LstCamposSel_SelectedIndexChanged">
                            </asp:ListBox>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        
    <CKEditor:CKEditorControl ID="Editor" runat="server" Toolbar="MyToolbar"></CKEditor:CKEditorControl>      
    </ContentTemplate></asp:UpdatePanel>

</asp:Panel>

</asp:Content>
