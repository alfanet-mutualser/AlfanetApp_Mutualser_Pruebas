<%@ Page Language="C#"  AutoEventWireup="true"
  CodeFile="Default3.aspx.cs" Inherits="uploadFiles.Default"%>
<%@ Import Namespace="DSRadicadoTableAdapters" %>
<%@ Import Namespace="DSGrupoSQLTableAdapters" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.NetworkInformation" %>

    <head>
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/gridjs/dist/gridjs.umd.js"></script>
        <script src="../../Scripts/jquery.blockUI.js"s></script>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link href="~/AlfaNetStyle.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
    </head>

    <div class="table table-bordered">     
        <form runat="server" id="formMigracionMasiva">
            <table class="table">
                <tr>
                    <th colspan="3" class="text-center">
                        <h3 class="alert-primary" style="font-weight: bold; font-size: large; background-image: url('../../AlfaNetImagen/MainMaster/LightBlue.jpg');">INTEGRACIÓN DE IMÁGENES </h3>
                    </th>
                </tr>
                <table style="height: 8px">
                    <tbody>
                        <tr style="table-layout: auto" >
                            <th colspan="2">Importar Imágenes de correspondencia: &nbsp;
                            </th>
                            <td style="font-size: xx-small">
                                <input type="radio" id="Radio1" name="Grupo" runat="server" checked />
                                Recibida
                            </td>
                
                            <td style="font-size: xx-small">
                                <input type="radio" id="Radio2" name="Grupo" runat="server" />
                                Enviada
                            </td>
                        </tr>
                    </tbody>
                </table>

                <tr>
                    <table class="table" style="table-layout: auto; empty-cells: hide; caption-side: top">
                        <tr>
                            <th id="totalFiles" style="font-size: xx-small">Nombre de archivo(s)</th>
                            <th id="totalSize" style="font-size: xx-small">Tamaño(s)</th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                    <table class="table">
                                        <tbody >
                                            <!-- Las filas se agregarán aquí dinámicamente -->
                                            <select  id="fileDetails" multiple style="font-size: xx-small; width: 100%; height: 160px;">

                                            </select>
                                        </tbody>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </tr>
                
            </table>
            <table class="table" style="font-size: xx-small; width: 100%;">
                <tr>
                    <td class="text-center">
                        <p >Seleccionar Archivo(s)</p>
                        <asp:fileupload id="FileUpload1" runat="server" allowmultiple="True" multiple="Multiple"  Font-Bold="False" Font-Italic="False" Font-Size="XX-Small" Font-Strikeout="False" Font-Underline="False" />
                    </td>
                    <td class="text-center">
                        <p >Seleccionar Carpeta</p>
                        <asp:fileupload id="FileUpload2" runat="server" webkitdirectory="multiple" multiple="Multiple" Font-Size="XX-Small"/>
                    </td>
                </tr>
                <tr>
                    <td  class="text-center">
                        <asp:Button ID="Button1" runat="server" BorderStyle="None" OnClick="BtnDelete_Click" Text="Cancelar Carga de archivos" />
                    </td>

                    <td class="text-center"  >
                        <asp:Button ID="Button2" runat="server" BorderStyle="None" OnClick="BtnDelete_Click" Text="Cancelar Carga de archivos" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="container text-center">
                        <asp:button id="BtnSubirFile" runat="server" text="Subir" type="submit" onclick="BtnSubir_Click" Font-Underline="False"  />
                    </td>
                </tr>
            </table>
            </form>
        
            <div style="max-height: 500px; min-height: 20px; border: 1px solid #000; overflow: auto; display: flex; align-items: center;">
            <asp:label id="Label1" runat="server" font-names="Arial Black" font-overline="False" font-size="Smaller" width="100%"></asp:label>
        </div>
            
    </div>

<script type="text/javascript">


       $(document).ready(function () {

           //Spinner cargando...
           $("#BtnSubirFile, #Button1, #Button2").click(function () {
               $.blockUI.version = 2.53;
               $.blockUI({

                css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: 0.5,
            color: '#fff'
        },
        message:  'Cargando...'

               });
           });

           $("#<%= FileUpload1.ClientID %>").change(function () {
                showSelectedFiles(this);
                 // Verificar si FileUpload1 tiene archivos seleccionados
                if (this.files.length > 0) {
                    // Vaciar el contenido de FileUpload2
                    $("#FileUpload2").remove();
                    $("#Button2").remove();
                }

           });


             $("#<%= FileUpload2.ClientID %>").change(function () {
                  showSelectedFiles(this);
                  $("#FileUpload2").empty();
                 if (this.files.length > 0) {
                     // Vaciar el contenido de FileUpload1
                     $("#FileUpload1").remove();
                     $("#Button1").remove();
                 }


           });     
    });

        // Muestra los archivos seleciconados
       function showSelectedFiles(input) {

           var totalArchivos = document.getElementById("totalFiles");
                totalArchivos.innerHTML = "Nombre de archivo(s)";
           var size = document.getElementById("totalSize");
                size.innerHTML = "Tamaño(s) ";
           var totalSize = 0;
           var tableBody = $("#fileDetails");

                tableBody.empty(); // Limpiar el contenido de la tabla antes de mostrar los nuevos archivos

           for (var i = 0; i < input.files.length; i++) {
               var file = input.files[i];
               var fileName = file.name;
               var fileSize = getFileSize(file.size);
               var array = [];
               array.push(fileName);
               
                             
               var tableRow = $("<option>");
               var fileNameCell = $("<td>").text(fileName);
               var fileSizeCell = $("<td>").text(" " + fileSize);

               totalSize += file.size;
               tableRow.append(fileNameCell, fileSizeCell);
               tableBody.append(tableRow);

                }

           totalArchivos.innerText += " " + input.files.length;
           totalSize = getFileSize(totalSize);
           size.innerHTML += " " + totalSize;
        }
  
        // Transforma la vista de Kb a Mb en el tamaños de los archivos
       function getFileSize(size)
       {
          var sizeInBytes = size;
          var sizeInKb = sizeInBytes / 1024;
          var sizeInMb = sizeInKb / 1024;

          if (sizeInMb >= 1) {
            return sizeInMb.toFixed(2) + " MB";
          }
          else if (sizeInKb >= 1)
          {
            return sizeInKb.toFixed(2) + " KB";
          }
          else
          {
            return sizeInBytes + " bytes";
          }
       }
        
    </script>
    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {
            string ModuloLog = "Migración";
            string ConsecutivoCodigo = "15";
            string Grupo = Request["Grupo"];
            //Radio1.Checked = false;
            //Radio2.Checked = false;
            //OBTENER IP Y NOMBREPC
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    Session["IP"] = localIP;
                }
            }
            Session["Nombrepc"] = host.HostName.ToString();//FINALIZA OBTENER IP Y NOMBRE PC
            if (Radio1.Checked == true)
            {
                Session["Grupo"] = "1";
                string ActLogCod = "ACCESO";
                DateTime WFMovimientoFecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                //Se Realiza el Log
                int NumeroDocumento = Convert.ToInt32("0");
                string GrupoCod = Session["Grupo"].ToString();
                string Datosini = "";
                string Datosfin1 = "Acceso a modulo de Migracion Recibidos.";
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                Session["Navega"] = Navegador;

                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter AccediendoMigracion = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                AccediendoMigracion.InsertMigracion(LogId, UserId, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog,
                                    Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el Consecutivo de LOG
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            else if (Radio2.Checked)
            {
                Radio2.Checked = true;
                Session["Grupo"] = "2";
                string ActLogCod = "ACCESO";
                DateTime WFMovimientoFecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                //Se Realiza el Log
                int NumeroDocumento = Convert.ToInt32("0");
                string GrupoCod = Session["Grupo"].ToString();
                string Datosini = "";
                string Datosfin1 = "Acceso a modulo de Migracion Enviados.";
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                Session["Navega"] = Navegador;

                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter AccediendoMigracion = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                AccediendoMigracion.InsertMigracion(LogId, UserId, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog,
                                    Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Se actualiza el Consecutivo de LOG
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }

        }
</script>

