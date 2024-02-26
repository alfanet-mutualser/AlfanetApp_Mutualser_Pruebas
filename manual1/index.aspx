<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="AlfaNetManual_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">

    
    <div id ="currentPage" class="viewerContainer">
    <asp:Panel ID="Panel1" runat="server">
    <iframe id="FramePDF" name="iframe1" runat="server" enableviewstate="true" visible="false" style="width: 700px; height: 700px" frameborder="0" src="~/AlfaNetRepositorioImagenes/Registros/2010/6/VisorI2.pdf">
    </iframe>
    </asp:Panel>
    &nbsp;
    <asp:Label ID="lerror" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
