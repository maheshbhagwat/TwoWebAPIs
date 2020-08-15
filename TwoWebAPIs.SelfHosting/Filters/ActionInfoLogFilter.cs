using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TwoWebAPIs.Common;

namespace TwoWebAPIs.Controllers
{
    public class ActionInfoLogFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Logger.LogMessage(string.Format("Begin Executing Action - {0}", actionContext.ActionDescriptor.ActionName));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                Logger.LogMessage(string.Format("Exception Occured: Request :- {0} , Execption:- {1}  ", actionExecutedContext.Request.ToString(), actionExecutedContext.Exception.ToString()));
            }
            Logger.LogMessage(string.Format("End Executing Action - {0}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName));
        }
    }
}
