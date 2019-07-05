using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContianer;
using System.Data;
using Newtonsoft.Json;
namespace UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            int u_roleid =Convert.ToInt32(Session["u_roleid"]);
            string sql = "";
            if (HttpContext.Request["id"]==null)
            {
                sql = string.Format(@"select id,text,QuanURL,state
from Quan q
inner join (
select QxId
from Jsqx
where JsId={0}
) j on q.id=j.QxId
where Pid=0", u_roleid);
            }
            else
            {
                sql = string.Format(@"select id,text,QuanURL,state
from Quan q
inner join (
select QxId
from Jsqx
where JsId={0}
) j on q.id=j.QxId
where Pid={1}", u_roleid, HttpContext.Request["id"]);
            }
            DataTable dt = DBhelper.Select(sql,"");
            return Content(JsonConvert.SerializeObject(dt));
        }
    }
}