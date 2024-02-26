<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.IO" %>

<script runat="server" language="C#">

void Page_Load( Object sender, EventArgs e)
{

	TableRow objRow;
	TableCell objCell;

	objCount.Text = Request.Form["Count"];

	int nCount = int.Parse( Request.Form["Count"] );

	for( int i = 0; i < nCount; i++ )
	{
		objRow = new TableRow();

		objCell = new TableCell(); 
		objCell.Text = Request["Path"].Split(',')[i];
		objRow.Cells.Add( objCell );

		objCell = new TableCell(); 
		objCell.Text = Request["Size"].Split(',')[i];
		objRow.Cells.Add( objCell );

		objCell = new TableCell(); 
		objCell.Text = Request["ContentType"].Split(',')[i];
		objRow.Cells.Add( objCell );

		objTable.Rows.Add( objRow );
	}
}

</script>


<HTML>
<BODY>

<HEAD>
<META http-equiv="Content-Type" content="text/html; charset=utf-8">
<TITLE>XUpload Code Sample: 02_redirect_display.aspx</TITLE>
</HEAD>

<h3>Success! <asp:Label runat="server" id="objCount"/> file(s) uploaded.</h3>

<asp:table id="objTable" runat="server" border="1">
	<asp:TableRow>
		<asp:TableCell text="Path"/>
		<asp:TableCell text="Size"/>
		<asp:TableCell text="ContentType"/>
	</asp:TableRow>
</asp:table>

</BODY>
</HTML>