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
    public class standardController : Controller
    {
        Ipublic_charBLL it = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        IstandardBLL ioc = iocCreate.CreateTextBll<IstandardBLL>("standardBLL");
        Istandard_detailsBLL ii = iocCreate.CreateTextBll<Istandard_detailsBLL>("standard_detailsBLL");
        // GET: standard
        public ActionResult Index() {    
       
            return View();
        
        }
        public ActionResult Index2() {

                List<config_public_char> list = it.selectWhere(e => e.attribute_kind==("薪酬设置"));

          


                return Content(JsonConvert.SerializeObject(list));
            }
        // GET: standard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult FYXS() {

            return View();
        }
        public ActionResult List(int currentpage)
        {
         
            int rows;
           
            var data = ioc.SelectFenYe(e => e.ssd_id, e => e.ssd_id > 0     , out rows, currentpage, 2);

            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }
        // GET: standard/Create
        public ActionResult Create()
        {
            ViewBag.bianhao = ioc.GUID();
            return View();
        }
        //public ActionResult sele() {

        public int count() {
            List<config_public_char> list = it.selectWhere(e => e.attribute_kind.Equals("薪酬设置"));
            return list.Count; 
        }

        //    return View(JsonConvert.SerializeObject(list));
        //}
        // POST: standard/Create
        [HttpPost]
        public ActionResult Create(salary_standard ss,FormCollection fom)
        {
            ss.check_status = 0;
            ss.change_status = 0;
            string Name = Request["standard.standardName"];
            string ze = Request["standard.salarySum"];
            string zdr = Request["standard.designer"];
            string bh = Request["standard.standardId"];
            string djr = Request["standard.register"];
            string djsj = Request["standard.registTime"];
            string bz = Request["standard.remark"];
            ss.standard_id = bh;
            ss.standard_name = Name;
            ss.designer = zdr;
            ss.register = djr;
            ss.regist_time =Convert.ToDateTime( djsj);
            ss.remark = bz;
            ss.salary_sum =Convert.ToDecimal( ze);
            int num = ioc.Insert(ss);
            int num1 = 0;
            for (int i = 0; i < count(); i++)
            {
                if (fom["details" + i + ".itemId"] == null)
                {

                }
                else
                {
                    salary_standard_details je = new salary_standard_details();
                    //for (int i=0;i< count();i++) {

                    je.standard_id = ss.standard_id;
                    je.standard_name = ss.standard_name;
                    je.item_id = Convert.ToInt16(fom["details" + i + ".itemId"]);
                    je.item_name = (fom["details" + i + ".attribute_name"]);
                    je.salary = Convert.ToDecimal(fom["details" + i + ".salary"]);
                    num1 = ii.Insert(je);
                    //}
                }
            }
            if (num > 0 && num1 > 0)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    return View();
                }

           
        }

        // GET: standard/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult wheress(string id)
        {

            salary_standard li = ioc.selectWhere(e => e.standard_id == id).FirstOrDefault();
            List<salary_standard_details> li1 = ii.selectWhere(e=>e.standard_id == id).ToList();
            Dictionary<string, object> don = new Dictionary<string, object>();
            don["li"] = li;
            don["li1"]=li1;
           
            return Content(JsonConvert.SerializeObject(don));
        }

        public int SelectList(string id) {

            List<salary_standard_details> List1 = ii.selectWhere(e => e.standard_id == id).ToList();
            return List1.Count();
        }
        // POST: standard/Edit/5
        [HttpPost]
        public ActionResult Edit(salary_standard sa, FormCollection ad)
        {

            //int de = ioc.AUD(String.Format("delete  from salary_standard  where standard_id='{0}'", sa.standard_id));
            int de = ioc.AUD(String.Format(@"update  dbo.salary_standard  set   checker='{0}',salary_sum='{1}',check_time='{2}',check_status='{3}',check_comment='{4}'   where standard_id='{5}'", sa.checker, sa.salary_sum, sa.check_time, 1,sa.check_comment,sa.standard_id));
            //sa.change_status = 1;
            //int mun = ioc.Insert(sa);
            int xhm = 0;
            if (de > 0 ) {
                for (int i=0;i<SelectList(sa.standard_id);i++) {
                    salary_standard_details bb = new salary_standard_details();
                    bb.sdt_id = Convert.ToInt16(ad["details"+i+".sdtId"]);
                    bb.standard_id = ad["details" + i + ".standardId"];
                    bb.standard_name=ad["details" + i + ".standardName"];
                    bb.item_id= Convert.ToInt16(ad["details" + i + ".item_id"]);
                    bb.item_name= ad["details" + i + ".itemName"];
                    bb.salary = Convert.ToDecimal(ad["details" + i + ".salary"]);

                    xhm = ii.Update(bb);
                }
                if (xhm > 0)
                {

                    return Content("<script>alert('修改成功');location.href='/standard/Index'</script>");
                }

            }
           
            return View();
        }

        // GET: standard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: standard/Delete/5
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
