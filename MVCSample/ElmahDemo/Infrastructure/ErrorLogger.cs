using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElmahDemo.Infrastructure
{
    public class ErrorLogger
    {
        public static void LogError(Exception ex, string contextualMessage = null)
        {
            try
            {
                // log error to Elmah
                if (contextualMessage != null)
                {
                    // log exception with contextual information that's visible when 
                    // clicking on the error in the Elmah log
                    var annotatedException = new Exception(contextualMessage, ex);
                    ErrorSignal.FromCurrentContext().Raise(annotatedException, HttpContext.Current);
                }
                else
                {
                    ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
                }
            }
            catch (Exception)
            {
                // uh oh! just keep going
            }
        }
    }
}