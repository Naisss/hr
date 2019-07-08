using Entity;
using IBLL;
using IocContianer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class Engage_interviewController : Controller
    {
        // GET: Engage_interview


        Imajor_releaseBLL imrb = iocCreate.CreateTextBll<Imajor_releaseBLL>("major_releaseBLL");
        Ipublic_charBLL ipcb = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        Iengage_resumeBLL ierb = iocCreate.CreateTextBll<Iengage_resumeBLL>("engage_resumeBLL");
        ImajorBLL imb = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        Iengage_interviewBLL ieib = iocCreate.CreateTextBll<Iengage_interviewBLL>("engage_interviewBLL");
        IusersBLL iub = iocCreate.CreateTextBll<IusersBLL>("usersBLL");


        //面试登记查询页面
        public ActionResult SelectInterview() {
            ViewBag.fl = imkb.Select();
            return View();
        }
        //按职业分类id查询职业表
        public ActionResult bymkidList(string id)
        {


            List<config_major> l = imb.SelectWhere(e => e.major_kind_id == id);

            return Json(l, JsonRequestBehavior.AllowGet);
        }



        //将条件存session
        public ActionResult Selewhere(string humanMajorKindId, string humanMajorId, string primarKey, string startDate, string endDate, bool booll)
        {

            if (booll == false)
            {
                // ierb.SelectWhere(e=>e.check_status==0);
                Session["whee"] = null;
                return Content("ok");
            }
            else
            {
                Dictionary<string, object> di = new Dictionary<string, object>();
                di.Add("kid", humanMajorKindId);
                di.Add("mid", humanMajorId);
                di.Add("key", primarKey);
                di.Add("staDate", startDate);
                di.Add("endDate", endDate);

                Session["whee"] = di;
                return Content("ok");
                //=ierb.SelectWhere(e=>e.human_major_kind_id==humanMajorKindId&& e.human_name.Contains(primarKey) && e.human_name.Contains(primarKey)|| e.human_telephone.Contains(primarKey)|| e.human_idcard.Contains(primarKey)|| e.human_history_records.Contains(primarKey)&&e.human_religion.CompareTo(startDate)>=0&& e.human_religion.CompareTo(endDate) <= 0&& e.check_status >0);
            }

        }





        //面试登记
        public ActionResult Index()
        {


            return View();
        }



        //面试登记
        public ActionResult getlist(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
         
            int rows;
            if (Session["whee"] == null)
            {
                where = e => e.interview_status == 0;
            }
            else
            {
                Dictionary<string, object> di = (Dictionary<string, object>)Session["whee"];
                string humanMajorKindId = di["kid"].ToString();
                string humanMajorId = di["mid"].ToString();
                string primarKey = di["key"].ToString();
                DateTime startDate = Convert.ToDateTime(di["staDate"]);
                DateTime endDate = Convert.ToDateTime(di["endDate"]);


                where = e => e.human_major_kind_id == humanMajorKindId && e.human_major_id == humanMajorId && (e.human_name.Contains(primarKey) || e.human_telephone.Contains(primarKey) || e.human_idcard.Contains(primarKey) || e.human_history_records.Contains(primarKey)) && e.regist_time >= startDate && e.regist_time <= endDate && e.interview_status==0;
            }        
            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }

        
        //面试详细登记页面
        [HttpGet]
        public ActionResult CreateDJ(int id) {
          engage_resume er=  ierb.SelectWhere(e=>e.res_id==id).FirstOrDefault();
         

            ViewBag.er = er;
            users u = (users)Session["getuser"];
            ViewBag.user = u.u_true_name;
           
            engage_interview ei= ieib.SelectWhere(e=>e.resume_id==id).FirstOrDefault();
      
            if (ei == null)
            {

                ViewBag.ei = null;
            }
            else {
                ei.interview_amount++;
                ViewBag.ei = ei;
            }
            return View();

        }



        //面试详细登记
        [HttpPost]
        public ActionResult CreateDJ(engage_interview einter)
        {
           engage_resume er= ierb.SelectWhere(e => e.res_id == einter.resume_id).FirstOrDefault(); ;
            er.interview_status = 1;
            ierb.Update(er);

            einter.interview_status = 1;
            einter.check_status = 0;
            if (einter.interview_amount > 1)
            {
               engage_interview en= ieib.SelectWhere(e=>e.resume_id==einter.resume_id).FirstOrDefault();
                //en.interview_amount = einter.interview_amount;
                //en.interview_comment = einter.interview_comment;
                //en.interview_status = einter.interview_status;
                //en.IQ_degree = einter.IQ_degree;
                //en.EQ_degree = einter.EQ_degree;
                //en.image_degree = einter.image_degree;

                einter.ein_id = en.ein_id;
                if (ieib.Update(einter) > 0)
                {
                    return Content("<script>alert('登记成功');location.href='/Engage_interview/index'</script>");

                }
                else
                {
                    return Content("<script>alert('登记成功');location.href='/Engage_interview/CreateDJ/" + einter.resume_id + "'</script>");
                }
            }
            else {
                if (ieib.Insert(einter) > 0)
                {
                    return Content("<script>alert('登记成功');location.href='/Engage_interview/index'</script>");

                }
                else
                {
                    return Content("<script>alert('登记成功');location.href='/Engage_interview/CreateDJ/" + einter.resume_id + "'</script>");
                }
            }


           
        }



        //面试筛选
        public ActionResult index2() {

            return View();
        }

        //面试筛选数据
        public ActionResult SelctInter(int currentpage)
        {
            Expression<Func<engage_interview, bool>> where = null;

                 int rows;
        
                where = e => e.check_status == 0;

            var data = ieib.SelectFenYe(e => e.ein_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }




        //点击筛选
        [HttpGet]
        public ActionResult saixuaninter(int id,int iid)
        {
            engage_resume er = ierb.SelectWhere(e => e.res_id == iid).FirstOrDefault();


            ViewBag.er2 = er;
            
            engage_interview ei = ieib.SelectWhere(e => e.ein_id == id).FirstOrDefault();
            ViewBag.ei2 = ei;
            ViewBag.us = iub.Select() ;
            return View();
        }

        //修改筛选后的值
        [HttpPost]
        public ActionResult saixuaninter(engage_interview eiter)
        {
            if (eiter.check_comment == "建议面试")
            {
               engage_resume er= ierb.SelectWhere(e => e.res_id == eiter.resume_id).FirstOrDefault() ;
                er.interview_status = 0;

                ierb.Update(er);
                engage_interview ei = ieib.SelectWhere(e=>e.ein_id==eiter.ein_id).FirstOrDefault();
                ei.check_status = 0;
                ieib.Update(ei);
                return Content("<script>alert('再次面试');location.href='/Engage_interview/index';</script>");
            }
            else if (eiter.check_comment == "建议录用") {
                engage_resume er = ierb.SelectWhere(e => e.res_id == eiter.resume_id).FirstOrDefault();
                er.interview_status = 2;
                ierb.Update(er);
                engage_interview ei = ieib.SelectWhere(e => e.ein_id == eiter.ein_id).FirstOrDefault();
                eiter.check_status = 1;
                ieib.Update(eiter);
                return Content("<script>alert('建议录用');location.href='/Engage_resume/index3';</script>");
            }

            else {

                engage_resume er = ierb.SelectWhere(e => e.res_id == eiter.resume_id).FirstOrDefault();
                

                ierb.Del(er);
                engage_interview ei = ieib.SelectWhere(e => e.ein_id == eiter.ein_id).FirstOrDefault();
               
                ieib.Del(ei);
                return Content("<script>alert('已删除');location.href='/Engage_interview/index2';</script>");
            }
            
        }

    }
}