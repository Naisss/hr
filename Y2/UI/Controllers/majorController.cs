using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using IBLL;
using IocContianer;
namespace UI.Controllers
{
    public class majorController : Controller
    {

        ImajorBLL ioc = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        // GET: major
        public ActionResult Index()
        {
            List<config_major> list = ioc.Select();
            return View(list);
        }

        // GET: major/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: major/Create
        public ActionResult Create()
        {
            GetList();
            return View();
        }
        private void GetList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var xllist = imkb.Select(); /*st.BanJiClass.Select(e => e);*/
            foreach (var item in xllist)
            {
                SelectListItem c = new SelectListItem()
                {
                    Text = item.major_kind_name,
                    Value = item.major_kind_id
                };

                list.Add(c);

            }
            ViewData["dt"] = list;
        }//I级
        // POST: major/Create
        [HttpPost]
        [ActionName("add")]
        public ActionResult Create(config_major t)
        {
            if (ModelState.IsValid)
            {
                List<config_major> xx = ioc.Select();
                config_major cfk = xx[xx.Count - 1];
                config_major_kind ck = imkb.selectWhere(e => e.major_kind_id == t.major_kind_id).FirstOrDefault();
                t.major_kind_name = ck.major_kind_name;
                t.major_id = (Convert.ToInt32(cfk.major_id) + 1001).ToString().Substring(2);

                int num = ioc.Insert(t);
                if (num > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: major/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: major/Edit/5
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

        // GET: major/Delete/5
        public ActionResult Delete(short id)
        {
            config_major stu = new config_major()
            {
                mak_id = id
            };
            int num = ioc.Del(stu);
            if (num > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(num);
            }
        }

        // POST: major/Delete/5
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
