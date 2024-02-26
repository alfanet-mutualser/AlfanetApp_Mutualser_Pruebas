<HTML>
<HEAD>
<META http-equiv="Content-Type" content="text/html; charset=utf-8">

<TITLE>XDownload 06_redirect_display.asp</TITLE>
</HEAD>
<BODY>

<h3>Download Results</h3>

<table border="1" cellspacing="0">
<TR>
	<TH>URL</TH><TH>Path</TH><TH>Size</TH><TH>Success</TH><TH>Status</TH>
</TR>

<%
count = Request.Form("path").Count

For i = 1 To count

%>

<TR>
	<TD><% = Request.Form("URL")(i)%></TD>
	<TD><% = Request.Form("Path")(i)%></TD>
	<TD><% = Request.Form("Size")(i)%></TD>
	<TD><% = Request.Form("Status")(i)%></TD>
	<TD><% = Request.Form("Success")(i)%></TD>	
</TR>

<%
Next
%>

</table>

</BODY>
</HTML>
