using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Web.LayoutRenderers;

namespace LogSessions.NLogExtension
{
    public static class RegisterLogSessions
    {
        public static void Register()
        {
            AspNetLayoutRendererBase.Register("LogKey",
                (logEventInfo, httpContext, loggingConfiguration)
                    => httpContext.Items["LogKey"]); // usage ${LogKey}

            AspNetLayoutRendererBase.Register("LogStep",
                (logEventInfo, httpContext, loggingConfiguration)
                    =>
                {
                    if(httpContext.Items.TryGetValue("LogStep", out object val))
                    {
                        int intVal = (int) val;
                        intVal++;
                        httpContext.Items["LogStep"] = intVal;
                        return intVal;
                    }
                    
                    httpContext.Items["LogStep"] = 1;
                    return 1;
                }); // usage ${LogStep}
        }
    }
}
