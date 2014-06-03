using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace MF0493_3
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-1.10.1.min.js",
                    DebugPath = "~/scripts/jquery-1.10.1.min.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.js"
                });
        }
    }
}