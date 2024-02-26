<%@ Page Language="C#" Debug="true" %>

<%@ import NameSpace = "csNetUploadTrial" %>
<%@ Import NameSpace = "System.Data" %>
<%@ Import NameSpace = "System.Data.SqlClient" %>
<%@ Import NameSpace = "System.IO" %>


<html>

<head>
  <title>Multi-image TIFF Processing - A Demo for csXImage</title>
  <style type="text/css">
  .curlycontainer{
    border: 1px solid #b8b8b8;
    margin-bottom: 1em;
    width: 300px;
  }

    .curlycontainer .innerdiv{
    background: transparent url(images/brcorner.gif) bottom right no-repeat;
    position: relative;
    left: 2px;
    top: 2px;
    padding: 1px 4px 15px 5px;
  }
  </style>
</head>

<script type="text/javascript" language="JavaScript">

  var Pages = new Array()
  var ImageCount
  var CurrentImage
  
  var Success;
  var FileName;
  var FileExt;
  var FileType;

  function Initialisation()
  {
    document.form1.scanbutton.disabled = false;
    //document.form1.loadbutton.disabled = false;
    document.form1.savebutton.disabled = true;

    document.form1.rotate90button.disabled = true;
    document.form1.rotate180button.disabled = true;
    document.form1.rotate270button.disabled = true;
    
    document.form1.prevbutton.disabled = true;
    document.form1.nextbutton.disabled = true;

    document.form1.pagenumtext.value = "";

    csxi.AutoZoom = true;
    csxi.ScaleToGray = true;

    ImageCount = 0;
  }

  function ScanClick()
  {
    csxi.SelectTwainDevice();
    
    csxi.TwainMultiImage = true;
    csxi.UseADF = true;
    ImageCount = 0;
    csxi.Acquire();
    CurrentImage = ImageCount;

    if (ImageCount > 0)
    {
      document.form1.savebutton.disabled = false;
      document.form1.rotate90button.disabled = false;
      document.form1.rotate180button.disabled = false;
      document.form1.rotate270button.disabled = false;
      
      if (ImageCount > 1)
      {
        document.form1.prevbutton.disabled = false;
        document.form1.nextbutton.disabled = false;
      }
      else
      {
        document.form1.prevbutton.disabled = true;
        document.form1.nextbutton.disabled = true;
      }
    }
    
      FileName = csxi.LastFileName;
      FileName = 'Prueba.TIF';
      FileName = FileName.substring(FileName.lastIndexOf('\\') + 1);
      FileExt = FileName.substring(FileName.lastIndexOf('.') + 1);
      switch (FileExt.toUpperCase())
      {
        case  'BMP' :
          FileType = 0;
          break;
        case 'GIF' :
          FileType = 1;
          break;
        case 'JPG' :
          FileType = 2;
          break;
        case 'PCX' :
          FileType = 3;
          break;
        case 'PNG' :
          FileType = 4;
          break;
        case 'WBMP' :
          FileType = 5;
          break;
        case 'PSD' :
          FileType = 6;
          break;
        case 'TIF' :
          FileType = 7;
          break;
        case 'TIFF' :
          FileType = 7;
          break;
        default :
          FileType = 2;
          break;
      }

  }

  function PrevClick()
  {
    if (CurrentImage > 1)
    {
      CurrentImage -= 1;
      csxi.ReadBinary(0, Pages[CurrentImage]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
    }
  }

  function NextClick()
  {
    if (CurrentImage < ImageCount)
    {
      CurrentImage += 1;
      csxi.ReadBinary(0, Pages[CurrentImage]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
    }
  }

  function Rotate90Click()
  {
    csxi.Rotate(90.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function Rotate180Click()
  {
    csxi.Rotate(180.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function Rotate270Click()
  {
    csxi.Rotate(270.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function SaveClick()
  {
    for(var i = 1; i<=ImageCount; i++)
    {
      csxi.ReadBinary(0, Pages[i]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + i + " of " + ImageCount; 
      if (csxi.ColorFormat == 6)
      {
        csxi.Compression = 2;
      }
      else
      {
        csxi.Compression = 0;
      } 
      csxi.AddToTIF(0);
    }
    csxi.WriteTIFDialog();
    csxi.ReadBinary(0, Pages[CurrentImage]);
    csxi.Redraw();
    document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
  }

//  function LoadClick()
//  {
//    csxi.ReadImageNumber = 1;
//    csxi.LoadDialog();
//    Pages[1] = csxi.WriteBinary(0);
//    csxi.Redraw();
//    ImageCount = csxi.ImageCount(csxi.LastFileName);
//    if (ImageCount > 1)
//    {
//      for(var i = 2; i<=ImageCount; i++)
//      {
//        csxi.ReadImageNumber = i;
//        csxi.LoadFromFile(csxi.LastFileName);
//        Pages[i] = csxi.WriteBinary(0);
//        csxi.Redraw();
//      }
//    }
//    CurrentImage = 1;
//    csxi.ReadBinary(0, Pages[CurrentImage]);
//    csxi.Redraw();
//    document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount;
// 
//    if (ImageCount > 0)
//    {
//      document.form1.savebutton.disabled = false;
//      document.form1.rotate90button.disabled = false;
//      document.form1.rotate180button.disabled = false;
//      document.form1.rotate270button.disabled = false;
//      
//      if (ImageCount > 1)
//      {
//        document.form1.prevbutton.disabled = false;
//        document.form1.nextbutton.disabled = false;
//      }
//      else
//      {
//        document.form1.prevbutton.disabled = true;
//        document.form1.nextbutton.disabled = true;
//      }
//    }
//  }

function UploadClick()
  {
    var btn = document.getElementById('uploadbutton'); 
 
   
    
    var url = 'http://192.168.1.101/AlfaNet/AlfaNetDocumentos/DocEnviado/filesave1.aspx';

    
    
    var xmlhttp=false;

    if (!xmlhttp && typeof XMLHttpRequest!='undefined') {
	try {
		xmlhttp = new XMLHttpRequest();
	} catch (e) {
		xmlhttp=false;
	}
    }
    if (!xmlhttp && window.createRequest) {
	try {
		xmlhttp = window.createRequest();
	} catch (e) {
		xmlhttp=false;
	}
    }
    
  xmlhttp.open("GET", url,true);
  xmlhttp.onreadystatechange=function() {
  if (xmlhttp.readyState==4) {
          if (xmlhttp.status==200) 
          {
             for(var i = 1; i<=ImageCount; i++)
             {
                csxi.ReadBinary(0, Pages[i]);
                csxi.Redraw();
                document.form1.pagenumtext.value = "Page " + i + " of " + ImageCount; 
             if (csxi.ColorFormat == 6)
             {
                csxi.Compression = 2;
             }
             else
             {
                csxi.Compression = 0;
             } 
                 csxi.AddToTIF(0);
             }
           
            
            
          
            Success = csxi.PostImage(url, FileName , '',FileType);
            
     
            if (Success)
            {
                alert('Image Uploaded');
                
            }
            else
            {
                alert('Upload Failed');
                
            } 
            
            
          }
          else if (xmlhttp.status==404) alert("URL doesn't exist!")
          else alert("Status is "+xmlhttp.status)

  }
 }
 xmlhttp.send(null)

  
    
    //Add the URL to the file saving script, including the http:// prefix.
    //The third parameter is the name that would appear in the HTML input type=file tag. csNetUpload does not use it.
    /*
    Success = csxi.PostImage('http://192.168.1.101/alfanet/AlfaNetDocumentos/DocRecibido/filesave1.aspx', FileName , '',FileType);
    
    if (Success)
    {
      alert('Image Uploaded')
    }
    else
    {
      alert('Upload Failed')
    } */
  }

function csxiacquire()
  {
    csxi.Redraw();
    ImageCount += 1;
    Pages[ImageCount] = csxi.WriteBinary(0);
    document.form1.pagenumtext.value = "Page " + ImageCount + " of " + ImageCount; 
  }


//-->
</script>

<script language="Javascript" for="csxi" event="onacquire()">
  csxiacquire()
</script>

<body onLoad="Initialisation()">
<div class="curlycontainer">
  <div class="innerdiv">
  
  <object classid="clsid:5220cb21-c88d-11cf-b347-00aa00a28331">
    <param name="LPKPath" value="../../csximage.lpk" />
  </object>
  <object id="csxi" classid="clsid:62e57fc5-1ccd-11d7-8344-00c1261173f0"  codebase="../../csXImage.ocx" width="400" height="450">
  </object>

  <form name=form1>
    <table>
      <tr>
      <td colspan="3" align="center" valign="middle">
      <img id="imLoading" src="images/ajax-loader.gif" style="visibility:hidden" />
      </td>
      </tr>
      <tr>
        <td><input type=button name=prevbutton value="Anterior" onClick="PrevClick()"></td>
        <td><input type=button name=nextbutton value="Siguiente" onClick="NextClick()"></td>
        <td><input type=text name=pagenumtext value=""></td>
      </tr>
      <tr>
        <td><input type=button name=scanbutton value="Escanear" onClick="ScanClick()"></td>
        <td>
            <input name="uploadbutton" onclick="UploadClick()" style="width: 110px" type="button"
                value="Subir Imágen" /></td>
        <td><input type=button name=savebutton value="Guardar" onClick="SaveClick()"></td>
      </tr>
      <tr>
        <td><input type=button name=rotate90button value="Rotar 90°" onClick="Rotate90Click()"></td>
        <td><input type=button name=rotate180button value="Rotar 180°" onClick="Rotate180Click()"></td>
        <td><input type=button name=rotate270button value="Rotar 270°" onClick="Rotate270Click()"></td>
      </tr>

    </table>
  </div>
  </div>
  </form>

</body>
</html>