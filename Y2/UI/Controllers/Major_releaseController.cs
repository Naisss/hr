using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContianer;
using Entity;
using BLL;
using IBLL;
namespace UI.Controllers
{
    public class Major_releaseController : Controller
    {
        Isecond_kindBLL iskb = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ithird_kindBLL itkb = iocCreate.CreateTextBll<Ithird_kindBLL>("third_kindBLL");
        ImajorBLL imb = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");

        // GET: Major_release
        public ActionResult Index()
        {
            List<config_file_second_kind> list1 = iskb.Select();
            List<config_file_third_kind> list2 = itkb.Select();
            List<config_major> list3 = imb.Select();
            List<config_major_kind> list4 = imkb.Select();
            ViewBag.s1 = list1;
            ViewBag.s2 = list2;
            ViewBag.s3 = list3;
            ViewBag.s4 = list4;
            return View();
        }
        public ActionResult Index2()
        {
           
            return View();
        }

    }
}