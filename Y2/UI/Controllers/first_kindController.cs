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
    public class first_kindController : Controller
    {
        Ifirst_kindBLL fbll = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        // GET: first_kind
        public ActionResult Index()
        {
            List<config_file_first_kind> list = fbll.SelectAll();
            return View(list);
        }
       
        // GET: first_kind/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: first_kind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: first_kind/Create
        [HttpPost]
        public ActionResult Create(config_file_first_kind fir)
        {
            //新增
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

        // GET: first_kind/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: first_kind/Edit/5
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

        // GET: first_kind/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: first_kind/Delete/5
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
