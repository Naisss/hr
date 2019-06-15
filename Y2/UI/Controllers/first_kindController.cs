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
        [ActionName("add")]
        public ActionResult Create(config_file_first_kind fir)
        {
            //新增
            if (ModelState.IsValid)
            {
                List<config_file_first_kind> xx = fbll.SelectAll();
                config_file_first_kind cfk = xx[xx.Count - 1];
                fir.first_kind_id = (Convert.ToInt32(cfk.first_kind_id) + 1001).ToString().Substring(2);

                int num = fbll.Insert(fir);
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
        [HttpGet]
        // GET: first_kind/Edit/5
        public ActionResult Edit(short id)
        {
            config_file_first_kind li = fbll.selectWhere(e => e.ffk_id == id).FirstOrDefault();
            
            return View(li);
        }

        // POST: first_kind/Edit/5
        [HttpPost]
      
        public ActionResult Edit(config_file_first_kind t)
        {
            int num = fbll.Update(t);
            if (num > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(num);
            }
        }

        // GET: first_kind/Delete/5
        public ActionResult Delete(short id)
        {
            config_file_first_kind stu = new config_file_first_kind()
            {
                ffk_id = id
            };
            int num = fbll.Del(stu);
            if (num > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(num);
            }
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
