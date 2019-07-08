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
    public class major_kindController : Controller
    {
        Imajor_kindBLL ioc = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        // GET: major_kind
        public ActionResult Index()
        {
            List<config_major_kind> list = ioc.Select();
            return View(list);
        }

        // GET: major_kind/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: major_kind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: major_kind/Create
        [HttpPost]
        [ActionName("add")]
        public ActionResult Create(config_major_kind t)
        {
            if (ModelState.IsValid)
            {
                List<config_major_kind> xx = ioc.Select();
                config_major_kind cfk = xx[xx.Count - 1];
           

                t.major_kind_id = (Convert.ToInt32(cfk.major_kind_id) + 1001).ToString().Substring(3);
               
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

        // GET: major_kind/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: major_kind/Edit/5
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

        // GET: major_kind/Delete/5
        public ActionResult Delete(short id)
        {
            config_major_kind stu = new config_major_kind()
            {
                mfk_id = id
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

        // POST: major_kind/Delete/5
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
