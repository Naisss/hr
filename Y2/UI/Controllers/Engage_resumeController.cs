using IBLL;
using IocContianer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Dynamic;

namespace UI.Controllers
{
    public class Engage_resumeController : Controller
    {


        Imajor_releaseBLL imrb = iocCreate.CreateTextBll<Imajor_releaseBLL>("major_releaseBLL");
        Ipublic_charBLL ipcb = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        Iengage_resumeBLL ierb = iocCreate.CreateTextBll<Iengage_resumeBLL>("engage_resumeBLL");
        ImajorBLL imb = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        Iengage_interviewBLL ieib = iocCreate.CreateTextBll<Iengage_interviewBLL>("engage_interviewBLL");
        Ihuman_fileBll ihdb = iocCreate.CreateTextBll<Ihuman_fileBll>("human_fileBLL");
        IusersBLL iub = iocCreate.CreateTextBll<IusersBLL>("usersBLL");
        // GET: Engage_resume
        //主页
        public ActionResult Index(engage_major_release me)
        {
            ViewBag.guoji = ipcb.SelectWhere(e => e.attribute_kind == "国籍");
            ViewBag.minzu = ipcb.SelectWhere(e => e.attribute_kind == "民族");
            ViewBag.xinyan = ipcb.SelectWhere(e => e.attribute_kind == "宗教信仰");
            ViewBag.mianmao = ipcb.SelectWhere(e => e.attribute_kind == "政治面貌");
            ViewBag.xueli = ipcb.SelectWhere(e => e.attribute_kind == "学历");
            ViewBag.nianxian = ipcb.SelectWhere(e => e.attribute_kind == "教育年限");
            ViewBag.zhuanye = ipcb.SelectWhere(e => e.attribute_kind == "专业");
            ViewBag.techang = ipcb.SelectWhere(e => e.attribute_kind == "特长");
            ViewBag.aihao = ipcb.SelectWhere(e => e.attribute_kind == "爱好");
            users u = (users)Session["getuser"];
            ViewBag.user = u.u_true_name;
           
            if (me.mre_id == 0) {
                Session["zpid"] = null;//走了两遍
            }
            else
            {
                Session["zpid"] = me.mre_id;
            }
            ViewBag.mr = me;

            ViewBag.aa = imkb.Select();
            ViewBag.bb = imb.Select();





            return View();
        }



        //按职业分类id查询职业表
        public ActionResult GetbyKid(string id)
        {
            List<config_major> list = imb.SelectWhere(e => e.major_kind_id == id);
            return Content(JsonConvert.SerializeObject(list));
        }
        //登记

        public ActionResult Create(engage_resume er)
        {
            if (er.human_major_name == null)
            {
                er.human_major_name = imb.SelectWhere(e => e.major_id == er.human_major_id).FirstOrDefault().major_name;
                er.human_major_kind_name = imkb.SelectWhere(e => e.major_kind_id == er.human_major_kind_id).FirstOrDefault().major_kind_name;
            }

            er.check_status = 0;
            if (ierb.Insert(er) > 0)
            {
                return Content("<script>alert('登记成功');location.href='/Engage_resume/Index2'</script>");
            }
            else
            {
                return Content("<script>alert('登记失败');location.href='/Major_release/Index3'</script>");

            }

        }



        //筛选页面
        public ActionResult index2()
        {
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

        //  筛选后的结果页面
        public ActionResult WhereList()
        {
            return View();
        }


        //筛选分页
        public ActionResult WList(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
            int rows;
            if (Session["whee"] == null)
            {
                where = e => e.check_status == 0;
            }
            else
            {
                Dictionary<string, object> di = (Dictionary<string, object>)Session["whee"];
                string humanMajorKindId = di["kid"].ToString();
                string humanMajorId = di["mid"].ToString();
                string primarKey = di["key"].ToString();
                DateTime startDate = Convert.ToDateTime(di["staDate"]);
                DateTime endDate = Convert.ToDateTime(di["endDate"]);


                where = e => e.human_major_kind_id == humanMajorKindId && e.human_major_id == humanMajorId && (e.human_name.Contains(primarKey) || e.human_telephone.Contains(primarKey) || e.human_idcard.Contains(primarKey) || e.human_history_records.Contains(primarKey)) && e.regist_time >= startDate && e.regist_time <= endDate && e.check_status == 0;
            }

            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }

        //复核页面
        [HttpGet]
        public ActionResult GetFH(int id)
        {

            engage_resume er = ierb.SelectWhere(e => e.res_id == id).FirstOrDefault();
            ViewBag.user = iub.Select();
            return View(er);
        }

        //修改推荐
        [HttpPost]
        public ActionResult GetFH(engage_resume er)
        {
            er.check_status = 1;
            er.interview_status = 0;
            if (ierb.Update(er) > 0)
            {
                Session["whee"] = null;
                return Content("<script>alert('复核成功');location.href='/Engage_resume/WhereList';</script>");
            }
            else
            {
                return Content("<script>alert('复核失败');location.href='/Engage_resume/GetFH/" + er.res_id + "';</script>");
            }



        }


        //有效页面
        public ActionResult SelectDic()
        {

            ViewBag.fl = imkb.Select();
            return View();
        }

        //查询查来的页面
        public ActionResult WhereList2()
        {
            return View();
        }

        //有效查看详细
        public ActionResult Selediccc(int id)
        {
            engage_resume er = ierb.SelectWhere(e => e.res_id == id).FirstOrDefault();
            return View(er);
        }

        //有效查询分页
        public ActionResult WList2(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
            int rows;
            if (Session["whee"] == null)
            {
                where = e => e.check_status == 1;
            }
            else
            {
                Dictionary<string, object> di = (Dictionary<string, object>)Session["whee"];
                string humanMajorKindId = di["kid"].ToString();
                string humanMajorId = di["mid"].ToString();
                string primarKey = di["key"].ToString();
                DateTime startDate = Convert.ToDateTime(di["staDate"]);
                DateTime endDate = Convert.ToDateTime(di["endDate"]);


                where = e => e.human_major_kind_id == humanMajorKindId && e.human_major_id == humanMajorId && (e.human_name.Contains(primarKey) || e.human_telephone.Contains(primarKey) || e.human_idcard.Contains(primarKey) || e.human_history_records.Contains(primarKey)) && e.regist_time >= startDate && e.regist_time <= endDate && e.check_status == 1;
            }

            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }


        //录用申请列表页面
        public ActionResult index3()
        {
            return View();
        }

        //录用申请分页
        public ActionResult LYGetlist(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
            int rows;

            where = e => e.interview_status == 2;

            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }



        //录用申请细节页面
        [HttpGet]
        public ActionResult Getshenqinluyong(int id)
        {

            engage_resume er = ierb.SelectWhere(e => e.res_id == id).FirstOrDefault();
            // ViewBag.er2 = er;
            engage_interview ei = ieib.SelectWhere(e => e.resume_id == id).FirstOrDefault();
            ViewBag.ei2 = ei;
            users u = (users)Session["getuser"];
            
            ViewBag.us = u.u_true_name;
            return View(er);

        }

        //录用申请细节页面提交
        [HttpPost]
        public ActionResult Getshenqinluyong(engage_resume eraa)
        {

            if (eraa.pass_checkComment == "通过")
            {
                //录用申请通过将修改简历表的面试状态为录用申请通过，及修改该简历的录用信息



                engage_resume era = ierb.SelectWhere(e => e.res_id == eraa.res_id).FirstOrDefault();
                era.pass_checkComment = eraa.pass_checkComment;
                era.pass_regist_time = eraa.pass_regist_time;
                era.pass_register = eraa.pass_register;
                era.interview_status = 3;
                era.pass_check_status = 0;
                if (ierb.Update(era) > 0)
                {

                    return Content("<script>alert('申请成功');location.href='/Engage_resume/index3'</script>");
                }
                else
                {
                    return Content("<script>alert('申请失败');location.href='/Engage_resume/Getshenqinluyong/" + era.res_id + "';</script>");
                }

            }
            else
            {
                //录用申请不通过则该简历状态该为未面试
                engage_interview ei = ieib.SelectWhere(e => e.resume_id == eraa.res_id).FirstOrDefault();
                ei.interview_status = 0;
                ieib.Update(ei);

                engage_resume era = ierb.SelectWhere(e => e.res_id == eraa.res_id).FirstOrDefault();
                era.pass_checkComment = eraa.pass_checkComment;
                era.pass_regist_time = eraa.pass_regist_time;
                era.pass_register = eraa.pass_register;
                era.interview_status = 0;


                if (ierb.Update(era) > 0)
                {
                    return Content("<script>alert('释放成功');location.href='/Engage_resume/index3'</script>");



                }
                else
                {
                    return Content("<script>alert('失败');location.href='/Engage_resume/Getshenqinluyong/" + era.res_id + "'</script>");

                }

            }



        }


        //录用审核列表页面
        public ActionResult index4()
        {
            return View();
        }
        //录用审核分页
        public ActionResult LYShenHeGetlist(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
            int rows;

            where = e => e.interview_status == 3 && e.pass_check_status == 0;

            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }


        //录用审核细节页面
        [HttpGet]
        public ActionResult GetShenhe(int id)
        {

            engage_resume eraaa = ierb.SelectWhere(e => e.res_id == id).FirstOrDefault();

            //ViewBag.er2 = eraaa;
            engage_interview eiaaa = ieib.SelectWhere(e => e.resume_id == id).FirstOrDefault();

            ViewBag.ei2 = eiaaa;

            return View(eraaa);

        }


        //录用审核细节页面提交
        [HttpPost]
        public ActionResult GetShenhe(engage_resume ersh)
        {
            if (ersh.pass_passComment == "通过")
            {
                engage_resume er = ierb.SelectWhere(e => e.res_id == ersh.res_id).FirstOrDefault();
                er.pass_check_status = 1;
                er.interview_status = 4;
                users u = (users)Session["getuser"];
                er.pass_checker = u.u_true_name;
                er.pass_passComment = ersh.pass_passComment;
                ierb.Update(er);
                int id = Convert.ToInt32(Session["zpid"]);
                if (Session["zpid"] != null)
                {
                   // int id =Convert.ToInt32(Session["zpid"]);
                    engage_major_release emr = imrb.SelectWhere(e => e.mre_id == id).FirstOrDefault();
                    emr.human_amount--;
                    imrb.Update(emr);
                }
              
                
                long i = 1;
                foreach (byte b in Guid.NewGuid().ToByteArray()){ i *= ((int)b + 1); };
                string s=  string.Format(@"{0:x}", i - DateTime.Now.Ticks);
                string sa=s.Substring(0,11);





                human_file hf = new human_file()
                {
                    human_id = "L" + sa,
                    human_name = er.human_name,
                    human_address = er.human_address,
                    human_postcode = er.human_postcode,
                    human_telephone = er.human_telephone,
                    human_mobilephone = er.human_mobilephone,
                    human_email = er.human_email,
                    human_hobby = er.human_hobby,
                    human_speciality = er.human_specility,
                    human_sex = er.human_sex,
                    human_religion = er.human_religion,
                    human_party = er.human_party,
                    human_nationality = er.human_nationality,
                    human_race = er.human_race,
                    human_birthday = er.human_birthday,
                    human_birthplace = er.human_birthplace,
                    human_age = er.human_age,
                    human_educated_degree = er.human_educated_degree,
                    human_educated_years = er.human_educated_years,
                    human_educated_major = er.human_educated_major,
                    human_id_card = er.human_idcard,
                    remark = er.remark,
                    human_histroy_records = er.human_history_records,
                    check_status=0
                    
                };

                if (ihdb.Insert(hf) > 0)
                {

                    return Content("<script>alert('成功');location.href='/Engage_resume/index4';</script>");
                }
                else {

                    return Content("<script>alert('失败');location.href='/Engage_resume/GetShenhe/"+er.res_id+"';</script>");

                }


            }
            else
            {
                //录用不通过则删除该简历的任何信息
                engage_interview ei = ieib.SelectWhere(e => e.resume_id == ersh.res_id).FirstOrDefault();

                ieib.Del(ei);
                ierb.Del(ersh);
                return Content("<script>alert('成功');location.href='/Engage_resume/index4';</script>");

            }



        }



        //录用查询列表页面
        public ActionResult index5() {
            return View();
        }

        //录用查询分页
        public ActionResult LYSelectGetlist(int currentpage)
        {
            Expression<Func<engage_resume, bool>> where = null;
            int rows;

            where = e => e.interview_status == 4&& e.pass_check_status == 1;

            var data = ierb.SelectFenye(e => e.res_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }



        //录用查询细节
        public ActionResult GetSelctly(int id) {

            engage_resume eraaa = ierb.SelectWhere(e => e.res_id == id).FirstOrDefault();

            //ViewBag.er2 = eraaa;
            engage_interview eiaaa = ieib.SelectWhere(e => e.resume_id == id).FirstOrDefault();

            ViewBag.ei2 = eiaaa;

            return View(eraaa);
        }
    }
}