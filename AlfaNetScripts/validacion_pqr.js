// Archivo JScript
/*funcion para habilitar el div de telefono y mail en el formulario de consultas*/
function enable_divtel(objname)
{                       document.getElementById("HFIsClicked").value = "1"; 
                        var txtBox = document.getElementById("txtmail");
                        var txtBox2 = document.getElementById("tbtelefono");
                        if(navigator.appName.indexOf("Microsoft") > -1){
                            document.getElementById("lvCorreo").style.display='';
                            document.getElementById("lbTel").style.display='';
                            txtBox.style.display ='';
                            txtBox2.style.display ='';
                            //document.getElementById("divmail").style.display='block';
                        }
                        else
                        {
                            document.getElementById("lvCorreo").style.display='';
                            document.getElementById("lbTel").style.display='';
                             txtBox.style.display ='';
                            txtBox2.style.display ='';
                            //document.getElementById("divmail").style.display='table-row';
                        }
                        
                        txtBox.style.display ='';
                        txtBox2.style.display ='';
}
/*funciones para habilitarlos estilos en los textbox*/
       function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if ((obj.className == "WaterMarkedTextBox") || (obj.className == "AlarmTextBox2") || (obj.className == "NormalTextBox")) {
                obj.value = "";
                obj.className = "NormalTextBox";
                if (obj.value == "User ID" || obj.value == "" || obj.value == null) {
                    obj.style.color = "black";
                }
            }
            if((obj.className == "WaterMarkedTextBoxDet") || (obj.className == "TextBoxDet"))
            {
                obj.value = "";
                obj.className = "TextBoxDet";
                if (obj.value == "User ID" || obj.value == "" || obj.value == null) {
                    obj.style.color = "black";
                }
            }
            //WaterMarkedTextBoxDet
        }
        function Blur(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.className != "WaterMarkedTextBox") {
                obj.value = waterMarkText;
                if (objname != "txtPwd") {
                    obj.className = "WaterMarkedTextBox";
                }
                else {
                    obj.className = "WaterMarkedTextBoxPSW";
                }
            }
            else {
                obj.className = "NormalTextBox";
            }

            if (obj.value == "User ID" || obj.value == "" || obj.value == null) {
                obj.style.color = "gray";
            }
        }
		
		function alfanumerico(texto){
		var letras="abcdefghyjklmnñopqrstuvwxyz0123456789";
   		texto = texto.toLowerCase();
   			for(i=0; i<texto.length; i++){
      			if (letras.indexOf(texto.charAt(i),0) ==-1){
         			return 1;
      			}
   			}
   			return 0;
		}
		
		function numerico(texto){
		var letras="0123456789";
   		texto = texto.toLowerCase();
   			for(i=0; i<texto.length; i++){
      			if (letras.indexOf(texto.charAt(i),0) ==-1){
         			return 1;
      			}
   			}
   			return 0;
		}
		
		
		function correo(texto){
		 var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
  		 
   		 if(reg.test(texto) == false) 
		 {
		 	return 1;
		 }
		 else
		 {
		 	return 0;
		 }
      

		}
		
		function Trim(text)
		{
			while(text.value.charAt(0)==' ')
			{
			   text.value=text.value.substring(1,text.value.length )
			}
		    while(text.value.charAt(text.value.length-1)==' ')
			{
			   text.value=text.value.substring(0,text.value.length-1)
			}
			return text.value;

		} 
		
		function validador_campos(texto,tipo,object,mensaje,mensajeerror)
		{
			if(Trim(texto) == '')
			{
			    if((obj.className == "WaterMarkedTextBoxDet") || (obj.className == "TextBoxDet"))
				{
				    obj.className = "WaterMarkedTextBoxDet";
				    obj.value = mensaje;
				    obj.style.color = "gray";
				}
				else
				{
				    obj.className = "WaterMarkedTextBox";
				    obj.value = mensaje;
				    obj.style.color = "gray";
				}
			}
			else
			{
			switch (tipo)
			{
				case 1: if(alfanumerico(texto.value)== 1)
				{
				    if((obj.className == "WaterMarkedTextBoxDet") || (obj.className == "TextBoxDet"))
				    {
				        obj.className  = "WaterMarkedTextBoxDet";
					    obj.value = mensajeerror;
				    }
				    else
				    {
					    obj.className  = "AlarmTextBox2";
					    obj.value = mensajeerror;
					}
				}
				else
				{
					obj.className  = "NormalTextBox";
				}
				break;
				
				case 2: if(correo(texto.value)== 1)
				{
					obj.className  = "AlarmTextBox2";
					obj.value = mensajeerror;
				}
				else
				{
					obj.className  = "NormalTextBox";
				}
				break;
				
				case 3: if(numerico(texto.value)== 1)
				{
					obj.className  = "AlarmTextBox2";
					obj.value = mensajeerror;
				}
				else
				{
				  if((obj.className == "WaterMarkedTextBoxDet") || (obj.className == "TextBoxDet"))
				  {
				    	obj.className  = "TextBoxDet";
				  }
				  else
				  {
				    	obj.className  = "NormalTextBox";
				  }
				
				}
				break;
				
			
				
				default: 
			}
			}
			return false
			
		}
		
		
		

        function validateDropDown(obj,valor,divisor)
        {
            var elemento=document.getElementById(obj.id);
           
            if(elemento.value == valor)
            {
              elemento.className = "WaterMarkedDDLError";
            }
            else
            {
              elemento.className = "divddlnorm";  
            }
            
            for (i = 0; i < elemento.options.length; i++)
            {
               var elm2 = elemento.options[i].value;
            
                    if (elemento.options[i].value == 0)
                    {
                                    DDListPoint.options[DDListPoint.selectedIndex].selected = false;
                                    DDListPoint.selectedIndex = i;                                    
                                    DDListPoint.options[i].selected = true;
                                    DDListPoint.selectedItem = DDListPoint.options[i];
                                    break;
                    }
            }
            
            var Producto = obj.value;//
            alert(Producto);
          
        }
        
        function MyApp(sender){
        var lbMatch = false;
        var loDDL2 = document.form1.DDLTipoID;
        for(var i=0; i< loDDL2.length-1; i++){
            lbMatch = sender.value==loDDL2.options[i].value;       
            lsSelected = lbMatch ? "<=SELECTED" : "";
            if(lbMatch)
                loDDL2.selectedIndex = sender.selectedIndex;
            //alert("DDL1:"+sender.value+ "  DDL2:"+loDDL2.options[i].value + lsSelected );
        }
        }
        
        
        function validateDropDownDepartamento(obj,valor,divisor)
        {
            var elemento=document.getElementById(obj.id);
            //var elemento = obj.value;
            if(elemento.value == valor)
            {
              elemento.className = "WaterMarkedDDLError";
            }
            else
            {
            
               elemento.className = "divddlnorm";
               /*for (i = 0; i < elemento.options.length; i++)
               {
                 
                 if(elemento.options[i].selected == true)
                 {
                    var elm2 = elemento.options[i].value;
                    if (elm2 != "170")
                    {
                        $get("CascadingDropDown2_ClientState").disabled = true;
                        $get("CascadingDropDown3_ClientState").disabled = true;
                        document.getElementById("tddepartamento").style.display='none';
                        document.getElementById("tdciudad1").style.display='none';
                        document.getElementById("tdciudad2").style.display='block';
           
                    }
                    else
                    {
                        $get("CascadingDropDown2_ClientState").disabled = false;
                        $get("CascadingDropDown3_ClientState").disabled = false;
                        document.getElementById("tddepartamento").style.display='block';
                        document.getElementById("tdciudad1").style.display='block';
                        document.getElementById("tdciudad2").style.display='none';
                    }
                    
                 }
                 
               }*/
                   
            }
            /*
            for (i = 0; i < elemento.options.length; i++)
            {
               var elm2 = elemento.options[i].value;
            
                    if (elemento.options[i].value == 0)
                    {
                                    DDListPoint.options[DDListPoint.selectedIndex].selected = false;
                                    DDListPoint.selectedIndex = i;                                    
                                    DDListPoint.options[i].selected = true;
                                    DDListPoint.selectedItem = DDListPoint.options[i];
                                    break;
                    }
            }
            
            var Producto = obj.value;//
            alert(Producto);*/
        }
        
        function validateDropDownPais(obj,valor,divisor)
        {
            var elemento=document.getElementById(obj.id);
            //var elemento = obj.value;
            if(elemento.value == valor)
            {
              elemento.className = "WaterMarkedDDLError";
            }
            else
            {
               elemento.className = "divddlnorm";
               for (i = 0; i < elemento.options.length; i++)
               {
                 
                 if(elemento.options[i].selected == true)
                 {
                    var elm2 = elemento.options[i].value;
                    if (elm2 != "170")
                    {
                        $get("CascadingDropDown2_ClientState").disabled = true;
                        $get("CascadingDropDown3_ClientState").disabled = true;
                        document.getElementById("tddepartamento").style.display='none';
                        document.getElementById("tdciudad1").style.display='none';
                     
                          document.getElementById("tdciudad2").style.display='block';
                       
                          document.getElementById("tdciudad2").style.display='table-row'; 
                       
           
                    }
                    else
                    {
                        $get("CascadingDropDown2_ClientState").disabled = false;
                        $get("CascadingDropDown3_ClientState").disabled = false;
                        document.getElementById("tdciudad2").style.display='none';
                        if(navigator.appName.indexOf("Microsoft") > -1){
                            document.getElementById("tddepartamento").style.display='block';
                            document.getElementById("tdciudad1").style.display='block';
                        }
                        else
                        {
                            document.getElementById("tddepartamento").style.display='table-row';
                            document.getElementById("tdciudad1").style.display='table-row';
                        }
                        
                    }
                    
                 }
                 
               }
                   
            }
            /*
            for (i = 0; i < elemento.options.length; i++)
            {
               var elm2 = elemento.options[i].value;
            
                    if (elemento.options[i].value == 0)
                    {
                                    DDListPoint.options[DDListPoint.selectedIndex].selected = false;
                                    DDListPoint.selectedIndex = i;                                    
                                    DDListPoint.options[i].selected = true;
                                    DDListPoint.selectedItem = DDListPoint.options[i];
                                    break;
                    }
            }
            
            var Producto = obj.value;//
            alert(Producto);*/
        }
        
        function revclass(obj,tipo,tipo2)
        {
          return false;
        
        }
        
        function disableEnterKey(e)
        {
            var key;     
            if(window.event)
                key = window.event.keyCode; //IE
            else
                 key = e.which; //firefox     
            return (key != 13);
        }

        
        function validateDropDownID(obj,valor,divisor)
        {
            var elemento=document.getElementById(obj.id);
            //var elemento = obj.value;
            if(elemento.value == valor)
            {
              elemento.className = "WaterMarkedDDLError";
              document.getElementById("txtUserId").disabled=true;
               document.getElementById("txtUserId").value = "Seleccione primero el tipo de documento";
              document.getElementById("HFSelectDoc").value = "0";         
            }
            else
            {
              elemento.className = "divddlnorm";  
              document.getElementById("txtUserId").disabled=false;
              for (i = 0; i < elemento.options.length; i++)
              {
                
                 var elm2 = elemento.options[i].value;
                 if(elemento.options[i].selected == true)
                 {
                    
                    if(elm2 == "cc")
                    {
                         document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS";
                         document.getElementById("txtUserId").value = "Digite su numero de documento";
                         document.getElementById("txtInfoProcId").value = "Digite su nombre y apellido";
                         document.getElementById("HFSelectDoc").value = "1";
                    }
                    if(elm2 == "ti")
                    {
                         document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS";
                         document.getElementById("txtUserId").value = "Digite su numero de documento";
                         document.getElementById("txtInfoProcId").value = "Digite su nombre y apellido";
                         document.getElementById("HFSelectDoc").value = "2";
                    }
                    if(elm2 == "ce")
                    {
                          document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS";
                         document.getElementById("txtUserId").value = "Digite su numero de documento";
                         document.getElementById("txtInfoProcId").value = "Digite su nombre y apellido";
                         document.getElementById("HFSelectDoc").value = "3";
                    }
                    if(elm2 == "nit")
                    {
                         document.getElementById("LbNameNui").innerHTML="RAZON SOCIAL";
                         document.getElementById("txtUserId").value = "Digite su número de NIT Ejemplo: 7878787";
                         document.getElementById("txtInfoProcId").value = "Digite la razón social";
                         document.getElementById("HFSelectDoc").value = "4";
                    }
                    if(elm2 == "pas")
                    {
                         document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS";
                         document.getElementById("txtUserId").value = "Digite su número de pasaporte Ej:78787878787";
                         document.getElementById("txtInfoProcId").value = "Digite su nombre y apellido";
                         document.getElementById("HFSelectDoc").value = "5";
                    }
                 }
                  /*
                    if (elemento.options[i].value == 0)
                    {
                                    DDListPoint.options[DDListPoint.selectedIndex].selected = false;
                                    DDListPoint.selectedIndex = i;                                    
                                    DDListPoint.options[i].selected = true;
                                    DDListPoint.selectedItem = DDListPoint.options[i];
                                    break;
                    }*/
              }
              //document.getElementById("txtUserId").value = "Seleccione primero el tipo de documento";
                       
            }
            /*
            for (i = 0; i < elemento.options.length; i++)
            {
               var elm2 = elemento.options[i].value;
            
                    if (elemento.options[i].value == 0)
                    {
                                    DDListPoint.options[DDListPoint.selectedIndex].selected = false;
                                    DDListPoint.selectedIndex = i;                                    
                                    DDListPoint.options[i].selected = true;
                                    DDListPoint.selectedItem = DDListPoint.options[i];
                                    break;
                    }
            }
            
            var Producto = obj.value;//
            alert(Producto);*/
          
        }
        
        /*Función de validación del campo tipo de identificación*/
        function validarchkbox(obj)
        {
             var elemento=document.getElementById(obj.id);
             if(obj.id == "chkcedula" )
             {
                if(elemento.checked == true)
                {
                    document.getElementById("chkpass").checked = false;
                    document.getElementById("chknit").checked = false;
                    document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS"
                    document.getElementById("txtUserId").disabled=false;
                    document.getElementById("txtUserId").value = "Digite su número de cedula Ej:78787878787";
                    document.getElementById("txtUserId").className="WaterMarkedTextBox";
                    document.getElementById("HFSelectDoc").value = "1";
                    
                }
                else
                {
                    if((document.getElementById("chkpass").checked == false) && (document.getElementById("chknit").checked==false))
                    {
                        document.getElementById("txtUserId").disabled=true;
                        document.getElementById("txtUserId").className = "WaterMarkedTextBox";
                        document.getElementById("txtUserId").value = "Seleccione primero el tipo de documento";
                        document.getElementById("HFSelectDoc").value = "0";
                    }
                }
             }
             if(obj.id == "chkpass" )
             {
                if(elemento.checked == true)
                {
                    document.getElementById("chkcedula").checked = false;
                    document.getElementById("chknit").checked = false;
                    document.getElementById("LbNameNui").innerHTML="NOMBRES Y APELLIDOS"
                    document.getElementById("txtUserId").disabled=false;
                    document.getElementById("txtUserId").value = "Digite su número de cedula Ej:878787887787";
                    document.getElementById("HFSelectDoc").value = "2";
                    
                }
                else
                {
                    if((document.getElementById("chkcedula").checked == false) && (document.getElementById("chknit").checked==false))
                    {
                        document.getElementById("txtUserId").disabled=true;
                        document.getElementById("txtUserId").className = "WaterMarkedTextBox";
                        document.getElementById("txtUserId").value = "Seleccione primero el tipo de documento";
                        document.getElementById("HFSelectDoc").value = "0";
                    }
                }
             }
               if(obj.id == "chknit" )
             {
                if(elemento.checked == true)
                {
                    document.getElementById("chkcedula").checked = false;
                    document.getElementById("chkpass").checked = false;
                    document.getElementById("LbNameNui").innerHTML="RAZON SOCIAL"
                    document.getElementById("txtUserId").disabled=false;
                    document.getElementById("txtUserId").value = "Digite su número de NIT Ej:8787878871";
                    document.getElementById("HFSelectDoc").value = "3";
                }
                else
                {
                    if((document.getElementById("chkcedula").checked == false) && (document.getElementById("chkpass").checked==false))
                    {
                        document.getElementById("txtUserId").disabled=true;
                        document.getElementById("txtUserId").className = "WaterMarkedTextBox";
                        document.getElementById("txtUserId").value = "Seleccione primero el tipo de documento";
                        document.getElementById("HFSelectDoc").value = "0";
                    }
                }
             }  
        }
        
        function revisar_chk()
        {
            if((document.getElementById("chkpass").checked == true) || ( document.getElementById("chkcedula").checked == true) || (document.getElementById("chknit").checked == true))
            {
              return 1;
            }
            else
            {
              return 0;
            }
        }
        
        function count_caract(obj)
        {
            cant = obj.value.length;
            document.getElementById('lblContador').innerHTML = cant;
            if(cant>=2000)
            {
                if (document.layers)
                document.captureEvents(Event.KEYPRESS);
                var keyCode = event.keyCode;
                if ( keyCode == 16 || (keyCode >= 32 && keyCode <= 44) || keyCode == 46 || keyCode == 47     || (keyCode >= 58)    || keyCode == 45)
                event.returnValue = false;
            }
       }
      
