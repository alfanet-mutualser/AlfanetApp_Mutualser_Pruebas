using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices;


public class User
{
       public string UserName { get; set; }
 
       public string DisplayName { get; set; }
 
       public string Company { get; set; }
 
       public string Deparment { get; set; }
 
       public string JobTitle{ get; set; }
 
       public string Email { get; set; }
 
       public string Phone { get; set; }
 
       public string Mobile { get; set; }
       public string item { get; set; }

       public string[] GetADUsers(string prefixText)
    {
        List<String> rst = new List<String>(20);
        SearchResult result = null;
        string path = ConfigurationManager.ConnectionStrings["ADConnectionString"].ConnectionString;

        DirectoryEntry _path = new DirectoryEntry(path);
        _path.AuthenticationType = AuthenticationTypes.Secure;
        DirectorySearcher search = new DirectorySearcher(_path);
        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        SearchResultCollection iResult = search.FindAll();


        User item;
        if (iResult != null)
        {
            for (int counter = 0; counter < iResult.Count; counter++)
            {
                result = iResult[counter];
                if (result.Properties.Contains("samaccountname"))
                {
                    item = new User();

                    item.UserName = (String)result.Properties["samaccountname"][0];
                    rst.Add(item.UserName);
                }
            }
        }

        search.Dispose();
        search.Dispose();

        return (rst.ToArray());
}
     
}