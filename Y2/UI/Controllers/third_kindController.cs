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
    public class third_kindController : Controller
    {

        Ithird_kindBLL ioc = iocCreate.CreateTextBll<Ithird_kindBLL>("third_kindBLL");
        Isecond_kindBLL sed = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ifirst_kindBLL fbll = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        // GET: third_kind
        public ActionResult Index()
        {
            List<config_file_third_kind> list = ioc.Select();
            return View(list);
        }//查询所有

        // GET: third_kind/Details/5
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
        }//I级
        private void GetList1()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var xllist = sed.Select(); /*st.BanJiClass.Select(e => e);*/
            foreach (var item in xllist)
            {
                SelectListItem c = new SelectListItem()
                {
                    Text = item.second_kind_name,
                    Value = item.second_kind_id
                };

                list.Add(c);

            }
            ViewData["dt1"] = list;
        }//II级
        private void GetList2() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text="是",Value="是", Selected = true });
            list.Add(new SelectListItem() { Text = "否", Value = "否" });
            ViewData["dt2"] = list;

        }//是否
        // GET: third_kind/Create
        public ActionResult Create()
        {
            GetList();
            GetList1();
            GetList2();
            return View();
        }//新增

        // POST: third_k
        [ActionName("add")]
        public ActionResult Create(config_file_third_kind dd)
        {
            if (ModelState.IsValid)
            {
                List<config_file_third_kind> xx = ioc.Select();
                config_file_third_kind cfk = xx[xx.Count - 1];
                config_file_first_kind fk = fbll.selectWhere(e => e.first_kind_id == dd.first_kind_id).FirstOrDefault();
                config_file_second_kind ck=sed.selectWhere(e => e.second_kind_id == dd.second_kind_id).FirstOrDefault();
                dd.third_kind_id = (Convert.ToInt32(cfk.third_kind_id) + 1001).ToString().Substring(2);
                dd.first_kind_id = fk.first_kind_id;
                dd.first_kind_name = fk.first_kind_name;
                dd.second_kind_id = ck.second_kind_id;
                dd.second_kind_name = ck.second_kind_name;
                int num = ioc.Insert(dd);
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
        }//新增

        // GET: third_kind/Edit/5
        public ActionResult Edit(short id)
        {
            config_file_third_kind li = ioc.selectWhere(e => e.ftk_id == id).FirstOrDefault();
            GetList2();
            return View(li);
        }//修改

        // POST: third_kind/Edit/5
        [HttpPost]
        public ActionResult Edit(config_file_third_kind T)
        {
            config_file_second_kind ck = sed.selectWhere(e => e.second_kind_name == T.second_kind_name).FirstOrDefault();
            config_file_first_kind kf = fbll.selectWhere(e => e.first_kind_name == T.first_kind_name).FirstOrDefault();
            T.first_kind_id = ck.first_kind_id;
            T.second_kind_id = ck.second_kind_id;
            int num = ioc.Update(T);
            if (num > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(num);
            }
        }//修改

        // GET: third_kind/Delete/5
        public ActionResult Delete(short id)
        {
            config_file_third_kind stu = new config_file_third_kind()
            {
                ftk_id = id
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
        }//删除

        // POST: third_kind/Delete/5
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
