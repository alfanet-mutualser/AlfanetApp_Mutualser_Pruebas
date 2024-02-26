<%@ Application Language="C#" %>

<%@ Import Namespace="System.Workflow.Runtime" %>

<script runat="server">

    
    
    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación

        String SelDBConnStr = ConfigurationManager.AppSettings["SelectDB"];
        switch(SelDBConnStr)
        {
            
            case "1":
                Application["SelectedDB"] = ConfigurationManager.ConnectionStrings["ConnStrSQLServer"];
                break;
            
            case "2":
                Application["SelectedDB"] = ConfigurationManager.ConnectionStrings["ConnStrOracle"];
                break;
                
            case "3":
                Application["SelectedDB"] = ConfigurationManager.ConnectionStrings["ConnStrPostgres"];
                break;      
            
        }
        
        //System.Workflow.Runtime.WorkflowRuntime workflowRuntime =
        //new System.Workflow.Runtime.WorkflowRuntime();

        //System.Workflow.Runtime.Hosting.ManualWorkflowSchedulerService manualService =
        //    new System.Workflow.Runtime.Hosting.ManualWorkflowSchedulerService();
        //workflowRuntime.AddService(manualService);

        //workflowRuntime.StartRuntime();

        //Application["WorkflowRuntime"] = workflowRuntime;    
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación
        Application["SelectedDB"] = null;

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión
 
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }
       
</script>
