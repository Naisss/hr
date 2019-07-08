using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using IBLL;
using IocContianer;
using Newtonsoft.Json;
using Dao;
using System.Data;
namespace UI.Controllers
{
    public class standard1Controller : Controller
    {
        Ipublic_charBLL it = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        IstandardBLL ioc = iocCreate.CreateTextBll<IstandardBLL>("standardBLL");
        Istandard_detailsBLL ii = iocCreate.CreateTextBll<Istandard_detailsBLL>("standard_detailsBLL");
        // GET: standard1
        public ActionResult Index()
        {
         
         
            return View();
        }
        public ActionResult Index2()
        {
            string bh = Request["standard.standardId"];
            string gjz = Request["utilbean.primarKey"];
            string start = Request["utilbean.startDate"];
            string endtime = Request["utilbean.endDate"];
            Session["bh"] = bh;
            Session["gjz"] = gjz;
            Session["start"] = start;
            Session["endtime"] = endtime;
            return View();
        }
        public ActionResult ff(int currentpage) {
            string bh = Session["bh"].ToString(); 
            string gjz = Session["gjz"].ToString();
            string start1 =  Session["start"].ToString() ;
            string endtime1 = Session["endtime"].ToString();

              
            if (bh != "" || gjz != "" || start1!="" || endtime1!="")
            {
                //string sql = string.Format(@"select * from dbo.salary_standard where standard_id Like '%{0}%'", bh);
                //DataTable Da = DBhelper.Select(sql, "standard1Controller");

                DateTime start = Convert.ToDateTime("1900-6-6");
                DateTime endtime = Convert.ToDateTime("2500-6-6");
                if (start1 == "")
                {
                    DateTime start2 = Convert.ToDateTime("1001-6-6");
                    start = start2;

                } else if (start1 !="") {
                   start = Convert.ToDateTime(start1);
                }
                if (endtime1 == "")
                {
                    DateTime endtime2 = Convert.ToDateTime("9999-6-6");
                    endtime = endtime2;
                }
                else if (endtime1 != "")
                {
               endtime = Convert.ToDateTime(endtime1);
                }
                int rows;
                var data = ioc.SelectFenYe(e => e.ssd_id, e => e.standard_id.Contains(bh) && (e.standard_name.Contains(gjz) || e.designer.Contains(gjz) || e.changer.Contains(gjz) || e.checker.Contains(gjz)) && (e.regist_time> start && e.regist_time< endtime)  , out rows, currentpage, 2);
                Dictionary<string, object> dtion = new Dictionary<string, object>();
                dtion.Add("data", data);
                dtion.Add("rows", rows);    
                dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
                return Content(JsonConvert.SerializeObject(dtion));
            }           
            return View();
        }



        public ActionResult Index3(string id) {
            ViewBag.id = id;
            return View();
        }
        public ActionResult wheress(string id)
        {

            salary_standard li = ioc.selectWhere(e => e.standard_id == id).FirstOrDefault();
            List<salary_standard_details> li1 = ii.selectWhere(e => e.standard_id == id).ToList();
            Dictionary<string, object> don = new Dictionary<string, object>();
            don["li"] = li;
            don["li1"] = li1;

            return Content(JsonConvert.SerializeObject(don));
        }
        // GET: standard1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: standard1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: standard1/Create
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

        // GET: standard1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: standard1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: standard1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: standard1/Delete/5
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
