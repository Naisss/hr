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
    public class standard2Controller : Controller
    {
        Ipublic_charBLL it = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        IstandardBLL ioc = iocCreate.CreateTextBll<IstandardBLL>("standardBLL");
        Istandard_detailsBLL ii = iocCreate.CreateTextBll<Istandard_detailsBLL>("standard_detailsBLL");
        // GET: standard2
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
        public ActionResult ff(int currentpage)
        {
            string bh = Session["bh"].ToString();
            string gjz = Session["gjz"].ToString();
            string start1 = Session["start"].ToString();
            string endtime1 = Session["endtime"].ToString();


            if (bh != "" || gjz != "" || start1 != "" || endtime1 != "")
            {
                //string sql = string.Format(@"select * from dbo.salary_standard where standard_id Like '%{0}%'", bh);
                //DataTable Da = DBhelper.Select(sql, "standard1Controller");

                DateTime start = Convert.ToDateTime("1900-6-6");
                DateTime endtime = Convert.ToDateTime("2500-6-6");
                if (start1 == "")
                {
                    DateTime start2 = Convert.ToDateTime("1001-6-6");
                    start = start2;

                }
                else if (start1 != "")
                {
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
                var data = ioc.SelectFenYe(e => e.ssd_id, e => e.standard_id.Contains(bh) && (e.standard_name.Contains(gjz) || e.designer.Contains(gjz) || e.changer.Contains(gjz) || e.checker.Contains(gjz)) && (e.regist_time > start && e.regist_time < endtime), out rows, currentpage, 2);
                Dictionary<string, object> dtion = new Dictionary<string, object>();
                dtion.Add("data", data);
                dtion.Add("rows", rows);
                dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
                return Content(JsonConvert.SerializeObject(dtion));
            }
            return View();
        }


        // GET: standard2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: standard2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: standard2/Create
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

        // GET: standard2/Edit/5
        public ActionResult Edit(string id)
        {
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

        // POST: standard2/Edit/5
        [HttpPost]
        public ActionResult Edit(salary_standard sa, FormCollection ad)
        {
          
            int de = ioc.AUD(String.Format(@"update  dbo.salary_standard  set   changer='{0}',salary_sum='{1}',change_time='{2}',change_status='{3}',remark='{4}'   where standard_id='{5}'", sa.changer, sa.salary_sum, sa.change_time, 1, sa.remark, sa.standard_id));
            int xhm = 0;
            if (de > 0)
            {
                for (int i = 0; i < SelectList(sa.standard_id); i++)
                {
                    salary_standard_details bb = new salary_standard_details();
                    bb.sdt_id = Convert.ToInt16(ad["details" + i + ".sdtId"]);
                    bb.standard_id = ad["details" + i + ".standardId"];
                    bb.standard_name = ad["details" + i + ".standardName"];
                    bb.item_id = Convert.ToInt16(ad["details" + i + ".item_id"]);
                    bb.item_name = ad["details" + i + ".itemName"];
                    bb.salary = Convert.ToDecimal(ad["details" + i + ".salary"]);

                    xhm = ii.Update(bb);
                }
                if (xhm > 0)
                {

                    return Content("<script>alert('修改成功');location.href='/standard2/Index'</script>");
                }

            }

            return View();
        }

        public int SelectList(string id)
        {

            List<salary_standard_details> List1 = ii.selectWhere(e => e.standard_id == id).ToList();
            return List1.Count();
        }
        // GET: standard2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: standard2/Delete/5
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
