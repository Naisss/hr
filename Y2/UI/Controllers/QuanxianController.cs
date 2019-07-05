using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContianer;
using IBLL;
using Newtonsoft.Json;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace UI.Controllers
{
    public class QuanxianController : Controller
    {
        // GET: User
        IQuanxianBll ib = iocCreate.CreateTextBll<IQuanxianBll>("QuanxianBll");
        public  ActionResult Users()
        {
            return View();
        }
        public ActionResult Show()
        {
            string currentPage = HttpContext.Request["cr"];
            Dictionary<string, object> di = ib.FYslect(currentPage,"");
            ViewBag.rows = di["rows"];
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult Add()
        {
            string sql = "select  *  from  JueSe";
            DataTable dt = DBhelper.Select(sql,"");
            ViewBag.data = dt;
            return View();
        }
        [HttpPost]
        public  ActionResult Add(users  u)
        {
            string sql = string.Format("insert   into  users values('{0}','{1}','{2}','{3}')",u.u_name,u.u_true_name,u.u_password,u.u_roleid);
            if (DBhelper.InsertUpdateDelte(sql,"")>0)
            {
                return Content("<script>window.location.href='/Quanxian/Users'</script>");
            }
            else
            {
                return Content("添加失败");
            }
        }
        [HttpGet]
        public ActionResult Update(int  id)
        {
            string sql = "select  *  from  JueSe";
            DataTable dt = DBhelper.Select(sql, "");
            ViewBag.data = dt;
            string sql1=string.Format("select  RoleName  from  Yonghu where  u_id='{0}'", id);
            string RoleName =(string)(DBhelper.Select(sql1,"").Rows[0]["RoleName"]);
            ViewBag.RoleName = RoleName;
            string sql2 = string.Format("select * from  users where u_id='{0}'", id);
            DataTable  dt2 =DBhelper.Select(sql2,"");
            users u = new users();
            if (dt2.Rows.Count > 0)
            {
                u.u_true_name=(string)dt2.Rows[0]["u_true_name"];
                u.u_id =Convert.ToInt16(dt2.Rows[0]["u_id"]);
                u.u_name =(string)dt2.Rows[0]["u_name"];
                u.u_password = (string)dt2.Rows[0]["u_password"];
                u.u_roleid = (int)dt2.Rows[0]["u_roleid"];
            }
            return View(u);
        }
        [HttpPost]
        public ActionResult Update(users u)
        {
            string sql = string.Format("update   users  set u_name='{0}',u_password='{1}',u_true_name='{2}',u_roleid='{3}' where u_id='{4}'", u.u_name,u.u_password,u.u_true_name,u.u_roleid,u.u_id);
            if (DBhelper.InsertUpdateDelte(sql, "") > 0)
            {
                return Content("<script>window.location.href='/Quanxian/Users'</script>");
            }
            else
            {
                return Content("修改失败!");
            }
        }
        public  ActionResult Del(int  id)
        {
            string sql = string.Format("delete  from users where u_id='{0}'",id);
            if (DBhelper.InsertUpdateDelte(sql, "") > 0)
            {
                return Content("<script>window.location.href='/Quanxian/Users'</script>");
            }
            else
            {
                return Content("删除失败!");
            }
        }
        public ActionResult List()
        {
            return View();
        }
        public  ActionResult List1(int cr)
        {
           SqlParameter[] ps =
           {
            new SqlParameter(){ParameterName="@pageSize",Value=2},
            new  SqlParameter(){ParameterName="@keyName",Value="RoleId"},
            new SqlParameter(){ParameterName="@tableName",Value="JueSe"},
            new SqlParameter(){ParameterName="@where",Value=""},
            new SqlParameter(){ParameterName="@currentPage",Value=cr},
            new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
            new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
            };
            DataTable dt = DBhelper.SelectProc(ps, "WebService1");
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = dt;
            di["rows"] = ps[5].Value;
            di["pages"] = ps[6].Value;
            return Content(JsonConvert.SerializeObject(di));
        }
        public  ActionResult Success()
        {
            return View();
        }
        public  ActionResult information(int  id)
        {
            string sql = string.Format("select  *  from  JueSe  where  RoleId='{0}'", id);
            DataTable dt = DBhelper.Select(sql,"");
            JueSe js = new JueSe();
            if (dt.Rows.Count > 0)
            {
                js.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                js.RoleName=(string)(dt.Rows[0]["RoleName"]);
                js.Sm=(string)(dt.Rows[0]["Sm"]);
                js.Display=(string)(dt.Rows[0]["Display"]);
            }
            return View(js);
        }

        public ActionResult QX(int rid)
        {
            string sql = "";
            //int ss = Convert.ToInt32(Session["u_roleid"]);//获取登录的权限ID
            if (HttpContext.Request["id"] == null)
            {
                //根节点
                sql = string.Format(@"select id,text,state,case
	when qr.QxId is null then 0
	else 1
 end as checked
from Quan q
left join(
select QxId
from Jsqx
where JsId='{0}'
) qr on q.id=qr.QxId
where Pid=0
", rid);
            }
            else
            {
                sql = string.Format(@"select id,text,state,case
	when qr.QxId is null then 0
	else 1
 end as checked
from Quan q
left join(
select QxId
from Jsqx
where JsId='{0}'
) qr on q.id=qr.QxId
where Pid='{1}'", rid, HttpContext.Request["id"]);
            }
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Edit()
        {
            string RoleName = HttpContext.Request["RoleName"];
            string Sm = HttpContext.Request["Sm"];
            string Display = HttpContext.Request["Display"];
            var rid =HttpContext.Request["QxId"];
            string[] str = rid.Split(',');
            var jsid = HttpContext.Request["JsId"];
            string sql = string.Format("delete  from  Jsqx where JsId='{0}'", jsid);
            DBhelper.InsertUpdateDelte(sql,"");
            int res = 0;
            for (var  i =0;i<str.Length;i++)
            {
                string sql1 = string.Format("insert into Jsqx(QxId,JsId) values('{0}','{1}')", str[i],jsid);
                if (DBhelper.InsertUpdateDelte(sql1,"")>0)
                {
                    res=1;
                }
            }
            string sql2 = string.Format("update  JueSe set RoleName='{0}',Sm='{1}',Display='{2}' where RoleId='{3}'", RoleName, Sm, Display, jsid);
            if (DBhelper.InsertUpdateDelte(sql2, "") > 0)
            {
                res++;
            }
            if (res ==2)
            {
                return Content("ok");
            }
            return View();
        }
        public   ActionResult Delete(int id)
        {
            string sql = string.Format("delete   from  JueSe  where  RoleId ='{0}'", id);
            int num = DBhelper.InsertUpdateDelte(sql,"");
            int i = 0;
            if (num>0)
            {
                i++;  
            }
            string sql1 = string.Format("delete   from  Jsqx  where  JsId ={0}", id);
            int num1 = DBhelper.InsertUpdateDelte(sql1,"");
            if (num1>0)
            {
                i++;
            }
            //string sql2 = string.Format("update users set u_roleid=0  where  u_roleid={0}", id);
            //int num2 = DBhelper.InsertUpdateDelte(sql2,"");
            //if (num2>0)
            //{
            //    i++;
            //}
            if (i==2)
            {
                return Content("<script>window.location.href='/Quanxian/List'</script>");
            }
            else
            {
                return Content("<script>alert('已存在用户绑定该权限，不能删除！');window.location.href='/Quanxian/List'</script>");
            }
        }
        public ActionResult AddJs()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult AddJs(JueSe  js)
        {
            string sql = string.Format("insert  into  JueSe(RoleName,Sm,Display) values('{0}','{1}','{2}')", js.RoleName, js.Sm, js.Display);
            int num = DBhelper.InsertUpdateDelte(sql,"");
            if (num>0)
            {
                string sql1 = string.Format("select RoleId from JueSe where RoleName='{0}'", js.RoleName);
                int RoleId =Convert.ToInt32(DBhelper.Select(sql1, "").Rows[0]["RoleId"]);
                string sql2 = string.Format("insert into Jsqx (JsId) values({0})",RoleId);
                if (DBhelper.InsertUpdateDelte(sql2, "") > 0)
                {
                    return Content("<script>window.location.href='/Quanxian/List'</script>");
                }    
            }
            return View();
        }
    }

}