using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContianer;
using Entity;
using BLL;
using IBLL;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class Major_releaseController : Controller
    {
        Isecond_kindBLL iskb = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ithird_kindBLL itkb = iocCreate.CreateTextBll<Ithird_kindBLL>("third_kindBLL");
        ImajorBLL imb = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        Ifirst_kindBLL ifkb = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        Imajor_releaseBLL imrb = iocCreate.CreateTextBll<Imajor_releaseBLL>("major_releaseBLL");
        IusersBLL iub = iocCreate.CreateTextBll<IusersBLL>("usersBLL");
        // GET: Major_release
        public ActionResult Index()
        {
            List<config_file_first_kind> list = ifkb.SelectAll();
            //List<config_file_second_kind> list1 = iskb.Select();
            //List<config_file_third_kind> list2 = itkb.Select();
          //  List<config_major> list3 = imb.Select();
            List<config_major_kind> list4 = imkb.Select();
            ViewBag.s = list;
          //  ViewBag.s1 = list1;
         //   ViewBag.s2 = list2;
         //   ViewBag.s3 = list3;
            ViewBag.s4 = list4;
            users u = (users)Session["getuser"];
            ViewBag.user = u.u_true_name;
            return View();
        }
        //二级
        public ActionResult GetbyYid(string id) {

            List<config_file_second_kind> list1 = iskb.SelectWhere(e=>e.first_kind_id==id);

            return Content(JsonConvert.SerializeObject(list1));
        }
        //三级
        public ActionResult GetbyEid(string id,string yid)
        {

            List<config_file_third_kind> list2 = itkb.SelectWhere(e => e.first_kind_id == yid && e.second_kind_id==id);

            return Content(JsonConvert.SerializeObject(list2));
        }

        //职业名称
        public ActionResult GetbyKid(string id)
        {
            
            List<config_major> list3 = imb.SelectWhere(e => e.major_kind_id == id );

            return Content(JsonConvert.SerializeObject(list3));
        }


        public ActionResult Carate(engage_major_release en)
        {

            config_file_first_kind s = ifkb.selectWhere(e => e.first_kind_id == en.first_kind_id).FirstOrDefault();
            config_file_second_kind s1 = iskb.SelectWhere(e => e.second_kind_id == en.second_kind_id).FirstOrDefault();
            config_file_third_kind s2 = itkb.SelectWhere(e => e.third_kind_id == en.third_kind_id).FirstOrDefault();
            config_major s3 = imb.SelectWhere(e => e.major_id == en.major_id).FirstOrDefault();
            config_major_kind s4 = imkb.SelectWhere(e => e.major_kind_id == en.major_kind_id).FirstOrDefault();

            //string sa= ;
            en.first_kind_name = s.first_kind_name;
            en.second_kind_name = s1.second_kind_name;
            en.third_kind_name = s2.third_kind_name;
            en.major_name = s3.major_name;
            en.major_kind_name = s4.major_kind_name;

            if (imrb.Add(en) > 0)
            {
                return Content("<script>alert('发布成功');location.href='/Major_release/Index2'</script>");
            }
            else
            {
                return Content("<script>alert('发布失败');location.href='/Major_release/Index'</script>");
            }



        }

        public ActionResult Index2()
        {

            return View();
        }

        public ActionResult List(int currentpage)
        {
            int rows;
            var data = imrb.SelectFenYe(e => e.mre_id, e => e.mre_id > 0, out rows, currentpage, 2);
            
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            engage_major_release erm = imrb.SelectWhere(e => e.mre_id == id).FirstOrDefault();
            ViewBag.user = iub.Select();

            return View(erm);
        }
        [HttpPost]
        public ActionResult Edit(engage_major_release emr)
        {
            if (imrb.Update(emr) > 0)
            {
                return Content("<script>alert('修改成功');location.href='/Major_release/Index2'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');location.href='/Major_release/Edit/"+emr.mre_id+"'</script>");
            }


        }
        public ActionResult Del(int id)
        {
            engage_major_release emr= imrb.SelectWhere(e=>e.mre_id==id).FirstOrDefault();
            if (imrb.Del(emr) > 0)
            {
                return Content("<script>alert('删除成功');location.href='/Major_release/Index2'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');location.href='/Major_release/Index2'</script>");
            }

          
        }



        public ActionResult index3() {
            return View();
        }

        public ActionResult shengqin(int id) {


            engage_major_release erm = imrb.SelectWhere(e => e.mre_id == id).FirstOrDefault();


            return View(erm);


        }


    }
}