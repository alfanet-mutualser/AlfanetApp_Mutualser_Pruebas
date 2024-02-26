<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportarDatos.aspx.cs" Inherits="ImportarDatos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 217px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <table style="margin: 0 auto;">
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Seleccione Archivo para cargar masivamente:"></asp:Label>
                            </td>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#FFFFCC" BorderColor="#FFFFCC"
                                        BorderStyle="Solid" ForeColor="#003366" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Text="Import" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="margin: 0 auto;">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label4" runat="server" Text="Seleccionar una imagen:"
                                    Visible="False" />
                                <br />
                            </td>
                            <tr>
                                <td class="style1">
                                    <asp:FileUpload ID="FiUpImagenes" runat="server" AllowMultiple="true" Visible="False" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="cargarImagen" runat="server" Text="Cargar imágenes" OnClick="cargarImagen_Click"
                                        Visible="False" />
                                    <br />
                                </td>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" />
                                        <br />
                                        <asp:Label ID="lblSuccess1" runat="server" ForeColor="Green" />
                                        <br />
                                    </td>
                                </tr>
                            </tr>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <h2>
            Unidades Creadas</h2>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:Label ID="LblRegInv" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="LblImRutCod" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <div>
        <asp:RadioButton ID="disco" runat="server" Visible="false" GroupName="guardar" Checked="true" Text="Guardar imagen en disco" />
    </div>
    <p>
        <div>
            <div>
                <br />
                <br />
            </div>
            <div>
                <br />
                <br />
            </div>
            <div>
                <br />
            </div>
        </div>
    </p>
    </form>
    <asp:Literal ID="literalMensaje" runat="server" />
</body>
</html>
