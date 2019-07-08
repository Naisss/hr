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
    public class public_charController : Controller
    {
        Ipublic_charBLL ioc = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        // GET: public_char
        public ActionResult Index()
        {
            List<config_public_char> list = ioc.Select();
            return View(list);
        }

        // GET: public_char/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: public_char/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: public_char/Create
        [HttpPost]
        [ActionName("add")]
        public ActionResult Create(config_public_char t)
        {
            if (ModelState.IsValid)
            {
      
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

        // GET: public_char/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: public_char/Edit/5
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

        // GET: public_char/Delete/5
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

        // POST: public_char/Delete/5
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
