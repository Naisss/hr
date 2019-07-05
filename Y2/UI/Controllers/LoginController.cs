using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using IBLL;
using IocContianer;
using MvcApplication4.Filters;
namespace UI.Controllers
{
    public class LoginController : Controller
    {
        ILoginBll ib = iocCreate.CreateTextBll<ILoginBll>("LoginBll");
        public ActionResult Index()
        {
            return View();
        }
        [Login]
        public ActionResult DL(users u)
        {
            object user = ib.login(u.u_name, u.u_password);
            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using IBLL;
using IocContianer;
using MvcApplication4.Filters;
namespace UI.Controllers
{
    public class LoginController : Controller
    {
        ILoginBll ib = iocCreate.CreateTextBll<ILoginBll>("LoginBll");
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [Login]
        public ActionResult DL(users u)
        {
            object user = ib.login(u.u_name, u.u_password);
            object u_roleid = ib.u_roleidSelect(u.u_name,u.u_password);
            Session["user"] = user;
            Session["u_roleid"] = u_roleid;
            return RedirectToAction("Index", "Home");
        }

    }
}
