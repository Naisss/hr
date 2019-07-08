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
    public class second_kindController : Controller
    {
        // GET: second_kind
        Isecond_kindBLL ioc = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ifirst_kindBLL fbll = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        public ActionResult Index()
        {
            List<config_file_second_kind> list = ioc.Select();
            return View(list);
        }

        // GET: second_kind/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private void GetList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var xllist = fbll.SelectAll(); /*st.BanJiClass.Select(e => e);*/
            foreach (var item in xllist)
            {
                SelectListItem c = new SelectListItem()
                {
                    Text = item.first_kind_name,
                    Value = item.first_kind_id
                };
             
                list.Add(c);   
              
            }
            ViewData["dt"] = list;
        }

        // GET: second_kind/Create
        public ActionResult Create()
        {
            GetList();
            return View();
        }

        // POST: second_kind/Create
        [HttpPost]
        [ActionName("add")]
        public ActionResult Create(config_file_second_kind se)
        {
            if (ModelState.IsValid)
            {
                List<config_file_second_kind> xx = ioc.Select();
                config_file_second_kind cfk = xx[xx.Count - 1];
                config_file_first_kind fk = fbll.selectWhere(e => e.first_kind_id == se.first_kind_id).FirstOrDefault();

                se.second_kind_id = (Convert.ToInt32(cfk.second_kind_id) + 1001).ToString().Substring(2);
                se.first_kind_name = fk.first_kind_name;
                int num = ioc.Insert(se);
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

        // GET: second_kind/Edit/5
        public ActionResult Edit(short id)
        {
            config_file_second_kind li = ioc.selectWhere(e => e.fsk_id == id).FirstOrDefault();

            return View(li);
        }

        // POST: second_kind/Edit/5
        [HttpPost]
        public ActionResult Edit(config_file_second_kind t)
        {
            int num = ioc.Update(t);
            if (num > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(num);
            }
        }

        // GET: second_kind/Delete/5
        public ActionResult Delete(short id)
        {
            config_file_second_kind stu = new config_file_second_kind()
            {
                fsk_id = id
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

        // POST: second_kind/Delete/5
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
