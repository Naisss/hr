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
    public class salary_itemController : Controller
    {
        Ipublic_charBLL ioc = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        // GET: salary_item
        public ActionResult Index()
        {
            List<config_public_char> list = ioc.selectWhere(e => e.attribute_kind.Equals("薪酬设置"));
            return View(list);
        }

        // GET: salary_item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: salary_item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: salary_item/Create
        [HttpPost]
        [ActionName("add")]
        public ActionResult Create(config_public_char t)
        {
            if (ModelState.IsValid)
            {

                t.attribute_kind = "薪酬设置";
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

        // GET: salary_item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: salary_item/Edit/5
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

        // GET: salary_item/Delete/5
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

        // POST: salary_item/Delete/5
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
