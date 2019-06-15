using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace UI.Filters
{
    public class CustomerAttribute:ActionFilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.Exception.Message;
            filterContext.Controller.ViewData["s"] = message;
            filterContext.Result = new ViewResult() { 
                 ViewName="Error",
                 ViewData = filterContext.Controller.ViewData           
            };
            filterContext.ExceptionHandled = true;
        }
    }
}