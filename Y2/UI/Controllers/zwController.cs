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
    public class zwController : Controller
    {
        Ipublic_charBLL ioc = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        // GET: zw
        public ActionResult Index()
        {
            List<config_public_char> list = ioc.selectWhere(e => e.attribute_kind.Equals("职称"));
            return View(list);
        }

        // GET: zw/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: zw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zw/Create
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

        // GET: zw/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: zw/Edit/5
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

        // GET: zw/Delete/5
        public ActionResult Delete(short id)
        {
            config_public_char stu = new config_public_char()
            {
                pbc_id = id
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

        // POST: zw/Delete/5
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
