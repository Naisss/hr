using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using IBLL;
using IocContianer;
using Newtonsoft.Json;
using Dao;
using System.Data;
using System.Data.SqlClient;

namespace UI.Controllers
{
    public class major_changeController : Controller
    {
    
        Ihuman_fileBll hf = iocCreate.CreateTextBll<Ihuman_fileBll>("human_fileBLL");
        Imajor_changeBll mb = iocCreate.CreateTextBll<Imajor_changeBll>("major_changeBll");
        Ifile_third_Bll ib = iocCreate.CreateTextBll<Ifile_third_Bll>("file_third_kindBll");
        // GET: major_change
        public ActionResult Index()
        {
            String sql = "select first_kind_id,first_kind_name  from  dbo.config_file_first_kind";
            DataTable dt = DBhelper.Select(sql, "");
            ViewBag.first = dt;

         
          


            //List<config_file_third_kind> list = ib.SelectAll();
            string sqlhuman_file = "select   *  from   human_file";
            DataTable dthuman_file = DBhelper.Select(sqlhuman_file,"");
            return View(dthuman_file);
        }

        //二级阶段
        public ActionResult GetbyYid(string id)
        {

            String sql =string.Format("select * from  dbo.config_file_second_kind where first_kind_id='{0}'",id);
            DataTable dt = DBhelper.Select(sql, "");
          

            return Content(JsonConvert.SerializeObject(dt));
        }
        //三级阶段
        public ActionResult GetbyEid(string id, string yid)
        {

            String sql =string.Format("select * from  dbo.config_file_third_kind where first_kind_id='{0}' and second_kind_id='{1}'", yid,id);
            DataTable dt = DBhelper.Select(sql, "");

            return Content(JsonConvert.SerializeObject(dt));
        }


        public ActionResult CX()
        {
            var startDate = Request["startDate"];
            var endDate = Request["endDate"];
            int currentPage = 1;
            string fn = Request["fid"];
            string sn = Request["sid"];
            string tn = Request["tid"];
            string where = "";
            //if (fn == "0"&&startDate!=null&&endDate!=null)
            //{
            //where = "where (regist_time>'"+startDate+"' and regist_time< '" + endDate+"'";
            //SqlParameter[] ps =
            //{
            //new SqlParameter(){ParameterName="@pageSize",Value=2},
            //new SqlParameter(){ParameterName="@keyName",Value="huf_id"},
            //new SqlParameter(){ParameterName="@tableName",Value="human_file"},
            //new SqlParameter(){ParameterName="@where",Value=where},
            //new SqlParameter(){ParameterName="@currentPage",Value=currentPage},
            //new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
            //new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
            //};
            //    DataTable dt = DBhelper.SelectProc(ps, "WebService1");
            //    ViewBag.data =  dt;
            //    ViewBag.rows =  Convert.ToInt32(ps[5].Value)+1;
            //    ViewBag.pages = ps[6].Value;
            //    ViewBag.currentPage = currentPage;
            //    ViewBag.pageSize = 2;
            //    return View();
            //}
            if (fn=="0"&& startDate==""&&endDate=="")
            {
                where = "where check_status=1";
                SqlParameter[] ps =
                {
                new SqlParameter(){ParameterName="@pageSize",Value=2},
                new SqlParameter(){ParameterName="@keyName",Value="huf_id"},
                new SqlParameter(){ParameterName="@tableName",Value="human_file"},
                new SqlParameter(){ParameterName="@where",Value=where},
                new SqlParameter(){ParameterName="@currentPage",Value=currentPage},
                new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
                new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
                };
                DataTable dt = DBhelper.SelectProc(ps, "WebService1");
                ViewBag.data = dt;
                ViewBag.rows = ps[5].Value;
                ViewBag.pages = ps[6].Value;
                ViewBag.currentPage = currentPage;
                ViewBag.pageSize = 2;
                return View();
            }
            else   if (fn!="0"&&sn!="0"&&tn!="0"&&startDate != null && endDate != null)
            {
                where = "where regist_time>'" + startDate + "' and regist_time< '" + endDate + "' and first_kind_id="+fn+ "and second_kind_id="+sn+ "and third_kind_id="+tn+ "and  check_status=1";
                SqlParameter[] ps =
                {
                new SqlParameter(){ParameterName="@pageSize",Value=2},
                new SqlParameter(){ParameterName="@keyName",Value="huf_id"},
                new SqlParameter(){ParameterName="@tableName",Value="human_file"},
                new SqlParameter(){ParameterName="@where",Value=where},
                new SqlParameter(){ParameterName="@currentPage",Value=currentPage},
                new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
                new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
                };
                DataTable dt = DBhelper.SelectProc(ps, "WebService1");
                ViewBag.data = dt;
                ViewBag.rows = ps[5].Value;
                ViewBag.pages = ps[6].Value;
                ViewBag.currentPage = currentPage;
                ViewBag.pageSize = 2;
                return View();
            }
             return View();

            //if (fn=="0"&&sn=="0"&&tn=="0")
            //{
            //    List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.first_kind_id!=null, out rows, currentPage, pageSize);
            //    ViewBag.list = list;
            //    ViewBag.rows = rows;
            //    ViewBag.pages = (rows - 1) / pageSize + 1;
            //    ViewBag.currentPage = currentPage;
            //    ViewBag.pageSize = pageSize;
            //    return View();    
            //}
            //else if (fn=="0"&&sn!="0"&&tn=="0")
            //{
            //    List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.second_kind_id==sn, out rows, currentPage, pageSize);
            //    ViewBag.list = list;
            //    ViewBag.rows = rows;
            //    ViewBag.pages = (rows - 1) / pageSize + 1;
            //    ViewBag.currentPage = currentPage;
            //    ViewBag.pageSize = pageSize;
            //    return View();
            //}
            //else if (fn == "0" && sn == "0" && tn != "0")
            //{
            //    List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.third_kind_id == tn, out rows, currentPage, pageSize);
            //    ViewBag.list = list;
            //    ViewBag.rows = rows;
            //    ViewBag.pages = (rows - 1) / pageSize + 1;
            //    ViewBag.currentPage = currentPage;
            //    ViewBag.pageSize = pageSize;
            //    return View();
            //}
            //else { 
            //    List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.first_kind_id ==fn, out rows, currentPage, pageSize);
            //    ViewBag.list = list;
            //    ViewBag.rows = rows;
            //    ViewBag.pages = (rows - 1) / pageSize + 1;
            //    ViewBag.currentPage = currentPage;
            //    ViewBag.pageSize = pageSize;
            //    return View();
            //}
        }
        public ActionResult Show()
        {
            return Content("ok");
        }
        public ActionResult Index1()
        {
            int currentPage = Convert.ToInt32(HttpContext.Request["currentPage"]);
        //    int rows;
        //    int pageSize = 2;
        //    List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.first_kind_id !=null, out rows, currentPage, pageSize);
        //    Dictionary<string, object> di = new Dictionary<string, object>();
        //    di["list"] = list;
        //    di["rows"] = rows;
        //    di["pages"] = (rows - 1) / pageSize + 1;
        SqlParameter[] ps =
               {
                new SqlParameter(){ParameterName="@pageSize",Value=2},
                new SqlParameter(){ParameterName="@keyName",Value="huf_id"},
                new SqlParameter(){ParameterName="@tableName",Value="human_file"},
                new SqlParameter(){ParameterName="@where",Value=""},
                new SqlParameter(){ParameterName="@currentPage",Value=currentPage},
                new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
                new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
                };
            DataTable dt = DBhelper.SelectProc(ps, "WebService1");
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["data"] = dt;
            di["rows"] = ps[5].Value;
            di["pages"] = ps[6].Value;

            return Content(JsonConvert.SerializeObject(di));
        }
        // GET: major_change/Details/5
        public ActionResult SH()
        {
            return View();
        }
        public ActionResult SH1()
        {
            int currentPage = Convert.ToInt32(HttpContext.Request["currentPage"]);
            int rows;
            int pageSize = 2;
            List<major_change> list = mb.FenYe<int>(e => e.mch_id, e => e.check_status == 1, out rows, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            ViewBag.rows = rows;
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = (rows - 1) / pageSize + 1;
            return Content(JsonConvert.SerializeObject(di));
        }

        // GET: major_change/Create
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult SHSuccess()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public  ActionResult major_changeUpdate(int  id)
        {
            
            //major_change mc = mb.selectWhere(e => e.mch_id == id).FirstOrDefault();
            human_file h = hf.SelectWhere(e => e.huf_id == id ).FirstOrDefault(); 
            String sql = "select * from config_major_kind ";
            DataTable dt = DBhelper.Select(sql, "");
            ViewBag.dt = dt;


            String sql1 = "select * from config_major ";
            DataTable dt1 = DBhelper.Select(sql1, "");
            ViewBag.dt1 = dt1;
            users u=(users)Session["getuser"];
            ViewBag.user = u.u_true_name;

            String sql2 = "select * from salary_standard ";
            DataTable dt2 = DBhelper.Select(sql2, "");
            ViewBag.dt2 = dt2;

            string sql3 = "select * from dbo.config_file_first_kind ";
            DataTable dt3 = DBhelper.Select(sql3, "");
            ViewBag.dt3 = dt3;
            return View(h);
        }

        [HttpPost]
        public ActionResult major_changeUpdate(major_change  MCG,int huid)
        {
            MCG.check_status = 1;
            if (mb.Insert(MCG) > 0)
            {

                string sql = string.Format("update human_file set check_status = 2 where huf_id='{0}'",huid);
                DBhelper.InsertUpdateDelte(sql,"");
                return Content("<script>window.location.href='/major_change/Success'</script>");
            }
            else
            {
                return Content("<script>alert('操作失败!')</script>");
            }
        }
       [HttpGet]
        public ActionResult DDSH(int   id)
        {

            major_change mc = mb.selectWhere(e => e.mch_id == id).FirstOrDefault();
            String sql = "select * from config_major_kind ";
            DataTable dt = DBhelper.Select(sql, "");
            ViewBag.dt = dt;
            String sql1 = "select * from config_major ";
            DataTable dt1 = DBhelper.Select(sql1, "");
            ViewBag.dt1 = dt1;

            String sql2 = "select * from salary_standard ";
            DataTable dt2 = DBhelper.Select(sql2, "");
            ViewBag.dt2 = dt2;
            users u = (users)Session["getuser"];
            ViewBag.user = u.u_true_name;
            string sql3 = "select * from config_file_third_kind ";
            DataTable dt3 = DBhelper.Select(sql3, "");
            ViewBag.dt3 = dt3;
            return View(mc);
        }
        [HttpPost]
        public ActionResult DDSH(major_change  mcaaa)
        {
            if (mcaaa.check_status == 2) { 
            if (mb.Update(mcaaa) > 0)
            {
                string sql = string.Format("update  major_change set  check_status =2 where mch_id='{0}'", mcaaa.mch_id);
                DBhelper.InsertUpdateDelte(sql,"");
                return Content("<script>window.location.href='/major_change/SHSuccess'</script>");
            }
            }
            else if(mcaaa.check_status==3)
            {
                string sql1 = string.Format("update  major_change  set   check_status =3 where mch_id='{0}'", mcaaa.mch_id);
                DBhelper.InsertUpdateDelte(sql1,"");
                return Content("<script>window.location.href='/major_change/SHSuccess'</script>");
            }
            return View();
        }
        public ActionResult locate()
        {
            String sql = "select first_kind_id,first_kind_name   from dbo.config_file_first_kind";
            DataTable dt = DBhelper.Select(sql, "");
            ViewBag.first = dt;

            //String sql1 = "select second_kind_id,second_kind_name   from major_change ";
            //DataTable dt1 = DBhelper.Select(sql1, "");
            //ViewBag.second = dt1;

            //String sql2 = "select third_kind_id,third_kind_name   from major_change ";
            //DataTable dt2 = DBhelper.Select(sql2, "");
            //ViewBag.third = dt2;

            //String sql3 = "select major_kind_id,major_kind_name   from major_change ";
            //DataTable dt3 = DBhelper.Select(sql3, "");
            //ViewBag.majorkind= dt3;

            //String sql4 = "select major_id,major_name   from major_change ";
            //DataTable dt4 = DBhelper.Select(sql4, "");
            //ViewBag.major = dt4;

            return View();
        }
        public ActionResult Find2()
        {
            string firstid = HttpContext.Request["firstid"];
            String sql = string.Format("select second_kind_id,second_kind_name from human_file  where first_kind_id ='{0}'", firstid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Find3()
        {
            string secondid = HttpContext.Request["secondid"];
            String sql = string.Format("select third_kind_id,third_kind_name from human_file  where second_kind_id ='{0}'", secondid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult FindTwo()
        {
            string firstid = HttpContext.Request["firstid"];
            String sql =string.Format("select second_kind_id,second_kind_name from dbo.config_file_second_kind  where first_kind_id ='{0}'", firstid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult FindThree()
        {
            string secondid = HttpContext.Request["secondid"];
            string firstid = HttpContext.Request["firstid"];
            String sql = string.Format("select third_kind_id,third_kind_name from dbo.config_file_third_kind  where second_kind_id ='{0}' and first_kind_id='{1}'", secondid, firstid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        // POST: major_change/Create
        public   ActionResult FindMajor()
        {
            string tid = HttpContext.Request["thirdKindId"];
            string sql = string.Format("select major_kind_id,major_kind_name from dbo.config_major_kind ");
            DataTable   dt  =DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult FindMid()
        {
            string mkid = HttpContext.Request["mkid"];
            string sql = string.Format("select major_id,major_name from config_major  where major_kind_id = '{0}'", mkid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Find2ji()
        {
            string firstid = HttpContext.Request["firstid"];
            String sql = string.Format("select second_kind_id,second_kind_name from config_file_third_kind  where first_kind_id ='{0}'", firstid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Find3ji()
        {
            string secondid = HttpContext.Request["secondid"];
            String sql = string.Format("select third_kind_id,third_kind_name from config_file_third_kind  where second_kind_id ='{0}'", secondid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult FindMJ()
        {
            string mkid = HttpContext.Request["mkid"];
            string sql = string.Format("select major_id,major_name from config_major  where major_kind_id = '{0}'", mkid);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult FindSalary_sum()
        {
            string standard_id = HttpContext.Request["standard_id"];
            string sql = string.Format("select salary_sum from salary_standard  where standard_id = '{0}'", standard_id);
            DataTable dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public   ActionResult list()
        {
            string fn = HttpContext.Request["fid"];
            string sn = HttpContext.Request["sid"];
            string tn = HttpContext.Request["tid"];
            string mkid = HttpContext.Request["mkid"];
            string mid = HttpContext.Request["mid"];
            var startDate = HttpContext.Request["startDate"];
            var endDate = HttpContext.Request["endDate"];
            if (fn == "0" && startDate == "" && endDate == "")
            {
                string sql = string.Format("select * from major_change  where check_status = 2 ");
                DataTable dt = DBhelper.Select(sql, "");
                ViewBag.list = dt;
                return View();
            }
            else if (fn != "0" && sn != "0" && tn != "0" && startDate != "" && endDate != "" && mkid != "0" &&mid!="0")
            {
                string sql = string.Format("select * from major_change  where first_kind_id='{0}' and second_kind_id='{1}' and  third_kind_id='{2}' and  major_kind_id='{3}' and major_id='{4}' and (regist_time>='{5}' and regist_time <='{6}') and check_status = 2", fn, sn, tn, mkid, mid , startDate,endDate);
                DataTable dt = DBhelper.Select(sql, "");
                ViewBag.list = dt;
            }
            return View();        
        }
        // GET: major_change/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public   ActionResult CK(int  id)
        {
            major_change mc = mb.selectWhere(e => e.mch_id == id).FirstOrDefault();
            users u =(users)Session["getuser"];
            ViewBag.user = u.u_true_name;
            return View(mc);
        }
        // POST: major_change/Edit/5
        [HttpPost]
       

        // GET: major_change/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: major_change/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
