using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcApplication4.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (Convert.ToInt32(filterContext.HttpContext.Session["user"]) !=1)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}