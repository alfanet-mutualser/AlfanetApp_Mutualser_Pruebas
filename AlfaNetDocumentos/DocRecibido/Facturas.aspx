<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Facturas.aspx.cs" Inherits="AlfaNetDocumentos_DocRecibido_Facturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="HFmDepCod" runat="server" />

    <script src="../../AlfaNetConsultas/Gestion/script_ConsultasFactura/jquery-1.4.4.min.js" ></script>


        <script language="javascript" type="text/javascript">

            function url(string) {
				var dep = string;
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                var Rad = src.innerText || src.innerHTML;
                var key = '<%= System.Configuration.ConfigurationManager.AppSettings["RutaNotificaciones"].ToString() %>';
                hidden = open(key + 'RadicacionMasiva.aspx?dep=' + dep , 'NewWindow', 'top=200,left=300, width=1000,height=900,status=yes, resizable=yes,scrollbars=yes');
                
            };

            function Timer() {
                setTimeout(LinkClick, 500);
            };

            function LinkClick() {


                    var link = document.getElementById("ctl00_ContentPlaceHolder1_HyperLink1");
                    link.click();

            };
        </script>
    <style>
        .ocultar{
            display:none;
        }
    </style>

    <div style="min-height:600px;">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LinKBtnStyleBig ocultar" ForeColor="Black" Font-Underline="false" Text="Clic Aqui"></asp:HyperLink> <%--OnClick="HyperLink1_Click"--%>
        <iframe id="facturasFrame" runat="server" class="ocultar" style="min-height:600px;" frameborder="0" width="100%" height="200">Si ves este mensaje, significa que tu navegador no tiene soporte para marcos o el mismo está deshabilitado</iframe>
    </div>
</asp:Content>

