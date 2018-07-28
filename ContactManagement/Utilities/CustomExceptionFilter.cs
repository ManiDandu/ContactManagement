using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ContactManagement.Utilities
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            Logger.LogException(actionExecutedContext.Exception); 
        }
    }
}