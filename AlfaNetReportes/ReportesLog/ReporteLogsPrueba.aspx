<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ReporteLogsPrueba.aspx.cs" Inherits="AlfaNetReportes_ReportesLog_ReporteLogs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;
    
    <asp:Label ID="Label4" runat="server" Text="Busqueda Por Fechas:"></asp:Label>
    <br />
    <br />
    <asp:CheckBox ID="ChBFechaReport" runat="server" Text="Entre Fechas de Reporte:" OnCheckedChanged="ChBFechaReport_CheckedChanged" AutoPostBack="True" />
    <br />
    <br />
    <cc1:CalendarExtender id="CalendarFinal" runat="server" TargetControlID="TxtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarFinal">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender id="CalendarInicial" runat="server" TargetControlID="TxtFechaIni" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarInicial">
    </cc1:CalendarExtender>
    <asp:Label ID="LblFechaInicial" runat="server" Text="Fecha Inicial:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TxtFechaIni" runat="server"  Width="87px"></asp:TextBox>
    <asp:Image id="ImgCalendarInicial" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="true"></asp:Image> 
    &nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Label ID="LblFechaFinal" runat="server" Text="Fecha Final:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TxtFechaFinal"  runat="server" Width="87px"></asp:TextBox>
    <asp:Image id="ImgCalendarFinal" runat="server" Width="27px" Height="20px" ImageUrl="~/AlfaNetImagen/ToolBar/calendario.png" Visible="true"></asp:Image> 

    
    
    <br />

    
    
    <br />
    <br />
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnLog %>" SelectCommand="buscar_reporte_inicio" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="fechabuscar1" Type="DateTime" />
            <asp:Parameter Name="fechabuscar2" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>--%>

    <asp:CheckBox ID="ChbUsuario" Text="Por usuario:" runat="server" AutoPostBack="True" OnCheckedChanged="ChbUsuario_CheckedChanged" />
    <br />
    <br />
    <asp:Label ID="LblUsername" runat="server" Text="Username:"></asp:Label>
    &nbsp;<asp:TextBox ID="TxtUsername" runat="server" Width="128px"></asp:TextBox>

    
    
    
    <br />
    <br />
    <asp:CheckBox ID="ChbActividad" runat="server" AutoPostBack="True" OnCheckedChanged="ChbActividad_CheckedChanged" Text="Por Actividad:" />
    <br />
    <br />
    <asp:Label ID="LblActividad" runat="server">Por Actividad:</asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TxtActividad" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="LblGrupodigo" runat="server" Text="Grupo Codigo:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="DropDownListGrupoCodigo" runat="server" AutoPostBack="True">
        <asp:ListItem Value="1">RADICADO</asp:ListItem>
        <asp:ListItem Value="2">REGISTRO</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" EnableModelValidation="True" BorderStyle="Inset" Width="100%" >
    </asp:GridView>

 <asp:ObjectDataSource ID="ODSReporteLog" runat="server" SelectMethod="GetReporteLogs" TypeName="ReporteLogBLL">

        <SelectParameters>
                        <asp:Parameter Name="GrupoCodigo" Type="Int32" />
                        <asp:Parameter Name="fechaini" Type="String" />
                        <asp:Parameter Name="fechafin" Type="String" />
                        <asp:Parameter Name="username" Type="String" />
                        <asp:Parameter Name="ActividadLogica" Type="String" />
                    </SelectParameters>

   

     </asp:ObjectDataSource>

     <asp:Label ID="Lblerror" runat="server"></asp:Label>
    <br />
    
    
    <div align="center"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar"  /> </div>
       
    </asp:Content>

