<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WFProceso.aspx.cs" Inherits="WFProceso" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="AlfaNetStyle.css" rel="stylesheet" type="text/css" />
    
    
    
    
    	<link rel="stylesheet" href="css/demos.css" media="screen" type="text/css">
	<style type="text/css">
	/* CSS for the demo. CSS needed for the scripts are loaded dynamically by the scripts */
	#mainContainer{
		width:600px;
		margin:0 auto;
		margin-top:10px;
		border:1px solid #000;
		padding:2px;
	}
	
	#capitals{
		width:200px;
		float:left;
		border:1px solid #000;
		background-color:#E2EBED;
		padding:3px;
		height:400px;
	}
	#countries{
		width:300px;
		float:right;
		margin:2px;
		height:400px;
	}	
	.dragableBox,.dragableBoxRight{
		width:110px;
		height:80px;
		border:1px solid #000;
		background-color:#FFF;		
		margin-bottom:5px;
		padding:10px;
		font-weight:bold;
		text-align:center;
	}
	div.dragableBoxRight{
		height:80px;
		width:120px;
		float:left;
		margin-right:15px;
		padding:5px;
		background-color:#c0c0c0;
	}
	.dropBox{
		width:190px;
		border:1px solid #000;
		background-color:#E2EBED;
		height:400px;
		margin-bottom:10px;
		padding:3px;
		overflow:auto;
	}		
	a{
		color:#F00;
	}
		
	.clear{
		clear:both;
	}
	img{
		border:0px;
	}	
	</style>	
	<script type="text/javascript" src="js/drag-drop-custom.js"></script>
    

</head>
<body style="text-align: center; background-color: transparent;">
    <form id="form1" runat="server">
        <br />
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
                <br />
                

         <div id="mainContainer">
         
		     <div class="konaBody">
		     </div>
                
                <table style="width: 653px; height: 58px;">
                
                
                
                    <tr>
                        <td style="width: 68px; height: 8px;">
                        </td>
                        <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                            width: 559px; border-bottom: black thin solid; vertical-align: middle; height: 8px; text-align: center;">
                                <table style="text-align: center; width: 124px;">
                                    <tr>
                                        <td style="width: 100px">
                                        <asp:ImageButton id="ImgBtnNuevo" runat="server" ImageUrl="~/Imagenes/tbNuevo.gif" OnClick="ImgBtnNuevo_Click" AlternateText="Nuevo Proceso"></asp:ImageButton></td>
                                        <td style="width: 100px; vertical-align: middle; text-align: center;">
                                            <asp:ImageButton ID="ImgBtnBuscar" runat="server" ImageUrl="~/Imagenes/tbBuscar.gif" AlternateText="Buscar Proceso" OnClick="ImgBtnBuscar_Click" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/TbGuardar.PNG" AlternateText="Guardar Proceso" Width="28px" /></td>
                                    </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 68px; border-bottom: black thin solid;
                            height: 1px; text-align: center;">
                            <strong><span style="color: #ff0000; vertical-align: middle; text-align: center;">
                                <asp:Label ID="Label1" runat="server" Text="Controles del WorkFlow" Width="180px"></asp:Label></span></strong></td>
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 559px; border-bottom: black thin solid;
                            height: 1px; text-align: center">
                            <strong><span style="color: #ff0000">
                                <asp:Label ID="Label3" runat="server" Text="Diseñador del WorkFlow" Width="260px"></asp:Label></span></strong></td>
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 80px; border-bottom: black thin solid;
                            height: 1px; vertical-align: middle; text-align: center;">
                            <strong><span style="color: #ff0000">
                                <asp:Label ID="Label4" runat="server" Text="Actividades del WorkFlow" Width="186px"></asp:Label></span></strong>
                                </td>
                    </tr>
                    <tr>
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 68px; border-bottom: black thin solid;
                            height: 1px; vertical-align: top; text-align: center;">
                            <br />
                            <div id="capitals" style="width: 168px; height: 457px;">
			                        <div id="dropContent">
                                        <br />
				                        <div class="dragableBox" id="box1"><img src="Imagenes/WFEscritorioImg.JPG" /></div>
				                        <div class="dragableBox" id="box2"><img src="Imagenes/WFDecisionImg.jpg" /></div>
				                        <div class="dragableBox" id="box3"><img src="Imagenes/WFArchivoImg.jpg" /></div>
				                        <div class="dragableBox" id="box4"><img src="Imagenes/WFDelegadoImg.jpg" /></div>
				                        <div class="dragableBox" id="box5"><img src="Imagenes/WFSubProcesoImg.jpg" /></div>
			                        </div>
		                    </div>
                        </td>
                        
                        
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 559px; border-bottom: black thin solid;
                            height: 1px; text-align: center;">
                            <table style="width: 347px">
                                <tr>
                                    <td style="width: 20%; text-align: center;">
                                        <img src="Imagenes/WFInicioImg.jpg" /></td>
                                    <td style="width: 340px; height: 63px; text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%; height: 23px; text-align: center">
                                        &nbsp;<img src="Imagenes/WFFlechaDer.gif" />&nbsp;</td>
                                    <td style="width: 340px; height: 23px; text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td style="width: 415px; vertical-align: middle; height: 334px; text-align: center;" colspan=2>
                                    
                                        <table style="width: 331px">
                                            <tr>
                                                <td style="width: 50%">
                                                    <div id="box101" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                                <td style="width: 50%">
                                                    <div id="box102" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="width: 194px">
                                                    <div id="box103" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                                <td style="width: 189px">
                                                    <div id="box104" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="width: 194px">
                                                    <div id="box105" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                                <td style="width: 189px">
                                                    <div id="box106" class="dragableBoxRight" >
                                                        </div>
                                                </td>
                                            </tr>
                                            
                                        </table>
		                    
                         </td>
                      </tr>
                                
                                <tr>
                                    <td style="width: 259px; text-align: center; height: 23px;">
                                        <img src="Imagenes/WFFlechaIzq.gif" /></td>
                                    <td style="width: 340px; text-align: left; height: 23px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 259px; text-align: center; height: 51px;">
                                        <img src="Imagenes/WFFinImg.jpg" /></td>
                                    <td style="width: 340px; height: 51px;">
                                    </td>
                                </tr>
                            </table>
                         </td>
                            
                            
                        <td bordercolor="buttonshadow" style="border-right: black thin solid; border-top: black thin solid;
                            border-left: black thin solid; width: 80px; border-bottom: black thin solid;
                            height: 1px; vertical-align: top;">
                            &nbsp;<div id="Div7">
                                <div id="Div6"><div id="xxxcapitals" style="width: 168px; height: 328px;">
                                    <div id="yyyContent">
                                        &nbsp;</div>
                                    <asp:Label ID="LblTiempo" runat="server" Font-Bold="True" Text="Tiempo (días)" Width="144px"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="TxtTiempo" runat="server"></asp:TextBox><br />
                                    <br />
                                    <asp:Label ID="LblAccion" runat="server" Font-Bold="True" Text="Accion" Width="144px"></asp:Label><br />
                                    <br />
                                    <asp:TextBox ID="TxtAccion" runat="server"></asp:TextBox><br />
                                    <br />
                                    <asp:Label ID="LblCargado" runat="server" Font-Bold="True" Text="Cargado a" Width="144px"></asp:Label><br />
                                    <br />
                                    <asp:TextBox ID="TxtCargado" runat="server"></asp:TextBox><br />
                                    <br />
                                    <asp:Label ID="LblPlantilla" runat="server" Font-Bold="True" Text="Plantilla" Width="144px"></asp:Label><br />
                                    <br />
                                    <asp:TextBox ID="TxtPlantilla" runat="server"></asp:TextBox></div>
                                    &nbsp;&nbsp;</div>
                            </div>
                        </td>
                        
                    </tr>
                    

                </table>
                
           <div class="clear"></div>
		   <div class="konaBody">
               <br />
               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/DragDropClon.aspx" Width="255px">DragDrop Clon</asp:HyperLink><br />
               &nbsp;</div>
	   </div>

     <div id="debug"></div>
                <asp:Panel id="Panel1" runat="server" Width="125px" Height="50px" style="vertical-align: middle; text-align: center">
                    <br />
                    <TABLE width=275 border=0><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label5" runat="server" Width="216px" ForeColor="White" Font-Bold="False" Text="Crear nuevo proceso" Font-Size="14pt"></asp:Label></TD><TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px" align=center colSpan=2>
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False"
                CellPadding="4" DataKeyNames="WFProcesoCodigo" DataSourceID="ObjectDataSource1"
                DefaultMode="Insert" ForeColor="#333333" GridLines="None" Height="50px" Width="343px" style="vertical-align: middle; text-align: left">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                <RowStyle BackColor="#EFF3FB" />
                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="WFProcesoCodigo" HeaderText="Codigo" SortExpression="WFProcesoCodigo" />
                    <asp:BoundField DataField="WFProcesoDescripcion" HeaderText="Descripcion"
                        SortExpression="WFProcesoDescripcion" />
                    <asp:BoundField DataField="WFProcesoHabilitar" HeaderText="Habilitar" SortExpression="WFProcesoHabilitar" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                </Fields>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:DetailsView>
        </TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" TargetControlID="Label5" PopupControlID="Panel1" BackgroundCssClass="MessageStyle"></cc1:ModalPopupExtender>
                <asp:Panel ID="Panel2" runat="server" Height="50px" Width="163px">
                    <TABLE border=0 style="width: 347px">
                        <TBODY>
                            <TR>
                                <TD style="BACKGROUND-COLOR: activecaption" align=center>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                        Text="Buscar proceso" Width="216px"></asp:Label></td>
                                <TD style="WIDTH: 12%; BACKGROUND-COLOR: activecaption">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Right" 
                                        Style="vertical-align: top" />
                                </td>
                            </tr>
                            <TR>
                                <TD style="HEIGHT: 45px" align=center colSpan=2>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCiudad"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="ValGroup1">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtCiudad" runat="server" CssClass="TxtAutoComplete"></asp:TextBox>
                                    <asp:ImageButton
                                        ID="ImgBtnFind" runat="server" 
                                        ToolTip="Buscar" ValidationGroup="ValGroup1" />&nbsp;<br />
                                    <table border="0" style="border-top-style: none; border-right-style: none; border-left-style: none;
                                        border-bottom-style: none">
                                        <tbody>
                                            <tr>
                                                <td style="width: 57px; height: 8px">
                                                    <strong><em><span style="font-family: Poor Richard"></span></em></strong>
                                                    <asp:Label ID="LblFindBy" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Smaller"
                                                        ForeColor="RoyalBlue" Text="Buscar Por: " Width="67px"></asp:Label></td>
                                                <td style="vertical-align: middle; width: 115px; height: 8px; text-align: center">
                                                    <asp:RadioButtonList ID="RadBtnLstFindby" runat="server" AutoPostBack="True" Font-Italic="False"
                                                        Font-Size="Smaller" ForeColor="RoyalBlue" OnSelectedIndexChanged="RadBtnLstFindby_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal" Width="106px">
                                                        <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                                        <asp:ListItem Value="2">Codigo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="MessageStyle" PopupControlID="Panel2" TargetControlID="Label2">
                </cc1:ModalPopupExtender>
                &nbsp;
</contenttemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFProceso"
            TypeName="DSProcesoTableAdapters.WFProcesoTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                <asp:Parameter Name="Original_WFProcesoDescripcion" Type="String" />
                <asp:Parameter Name="Original_WFProcesoHabilitar" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="WFProcesoDescripcion" Type="String" />
                <asp:Parameter Name="WFProcesoHabilitar" Type="String" />
                <asp:Parameter Name="Original_WFProcesoCodigo" Type="String" />
                <asp:Parameter Name="Original_WFProcesoDescripcion" Type="String" />
                <asp:Parameter Name="Original_WFProcesoHabilitar" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="WFProcesoCodigo" Type="String" />
                <asp:Parameter Name="WFProcesoDescripcion" Type="String" />
                <asp:Parameter Name="WFProcesoHabilitar" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp; &nbsp;&nbsp;
    </form>



<script type="text/javascript">



/*
// Custom drop actions for <div id="dropBox">
function dropItems(idOfDraggedItem,targetId,x,y)
{
	var html = document.getElementById('dropContent').innerHTML;
	if(html.length>0)html = html + '<br>';
	html = html + 'Item with id="' + idOfDraggedItem+'" dropped';
	document.getElementById('dropContent').innerHTML = html;
}


// Custom drop actions for <div id="dropBox2">

function dropItems2(idOfDraggedItem,targetId,x,y)
{
	var html = document.getElementById('dropContent2').innerHTML;
	if(html.length>0)html = html + '<br>';
	html = html + 'Item "' + document.getElementById(idOfDraggedItem).innerHTML + '" dropped';
	document.getElementById('dropContent2').innerHTML = html;
}
*/


// Custom drop action for the country boxes
function dropItems(idOfDraggedItem,targetId,x,y)
{

	var targetObj = document.getElementById(targetId);	// Creating reference to target obj
	var subDivs = targetObj.getElementsByTagName('DIV');	// Number of subdivs
	if(subDivs.length>0 && targetId!='capitals')return;	// Sub divs exists on target, i.e. element already dragged on it. => return from function without doing anything
	var sourceObj = document.getElementById(idOfDraggedItem);	// Creating reference to source, i.e. dragged object
	var numericIdTarget = targetId.replace(/[^0-9]/gi,'')/1;	// Find numeric id of target
	var numericIdSource = idOfDraggedItem.replace(/[^0-9]/gi,'')/1;	// Find numeric id of source
	
	
	if(numericIdTarget-numericIdSource==100){	// In the html above, there's a difference in 100 between the id of the country and it's capital(example:
		sourceObj.style.backgroundColor='#0F0';	// Set green background color for dragged object
	}else{
		sourceObj.style.backgroundColor='';	// Reset back to default white background color
	}
	
	
	if(targetId=='capitals'){	// Target is the capital box - append the dragged item as child of first sub div, i.e. as child of <div id="dropContent">
	    targetObj = targetObj.getElementsByTagName('DIV')[0];	
	}
	
	targetObj.appendChild(sourceObj);
	
}






var dragDropObj = new DHTMLgoodies_dragDrop();	// Creating drag and drop object


// Assigning drag events to the capitals
dragDropObj.addSource('box1',true);	// Make <div id="box1"> dragable. slide item back into original position after drop
dragDropObj.addSource('box2',true);	// Make <div id="box2"> dragable. slide item back into original position after drop
dragDropObj.addSource('box3',true);	// Make <div id="box3"> dragable. slide item back into original position after drop
dragDropObj.addSource('box4',true);	// Make <div id="box4"> dragable. slide item back into original position after drop
dragDropObj.addSource('box5',true);	// Make <div id="box5"> dragable. slide item back into original position after drop


// Assigning drop events on the countries
dragDropObj.addTarget('box101','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.addTarget('box102','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.addTarget('box103','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.addTarget('box104','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.addTarget('box105','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.addTarget('box106','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop

dragDropObj.addTarget('capitals','dropItems'); // Set <div id="leftColumn"> as a drop target. Call function dropItems on drop
dragDropObj.init();	// Initizlizing drag and drop object


</script>







</body>
</html>
