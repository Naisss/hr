using Entity;
using IBLL;
using IocContianer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class Human_fileController : Controller
    {

        Ipublic_charBLL ipcb = iocCreate.CreateTextBll<Ipublic_charBLL>("public_charBLL");
        ImajorBLL imb = iocCreate.CreateTextBll<ImajorBLL>("majorBLL");
        Imajor_kindBLL imkb = iocCreate.CreateTextBll<Imajor_kindBLL>("major_kindBLL");
        Ihuman_fileBll ihdb = iocCreate.CreateTextBll<Ihuman_fileBll>("human_fileBLL");
        Isecond_kindBLL iskb = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ithird_kindBLL itkb = iocCreate.CreateTextBll<Ithird_kindBLL>("third_kindBLL");
        Ifirst_kindBLL ifkb = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        Isalary_standardBLL issdb = iocCreate.CreateTextBll<Isalary_standardBLL>("salary_standardBLL");
        IusersBLL iub = iocCreate.CreateTextBll<IusersBLL>("usersBLL");
        // GET: Human_file




        //人力资源登记列表页面
        public ActionResult Selectdengji() {
            return View();
        }

        //登记查询分页
        public ActionResult GetDenji(int currentpage)
        {
            Expression<Func<human_file, bool>> where = null;
            int rows;

            where = e => e.check_status == 0 && e.first_kind_name == null;

            var data = ihdb.SelectFenYe(e => e.huf_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }


        //人力资源登记细节页面
        [HttpGet]
        public ActionResult Index(int id)
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
            ViewBag.chenzhi = ipcb.SelectWhere(e => e.attribute_kind == "职称");
            ViewBag.xinchou = issdb.Select();
            ViewBag.yiji = ifkb.SelectAll();
            ViewBag.fl = imkb.Select();
            users u = (users)Session["getuser"];
            ViewBag.user =u.u_true_name;
            human_file h = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            return View(h);
        }


        //按分类id查询
        public ActionResult GetbyKid(string id)
        {
            List<config_major> list = imb.SelectWhere(e => e.major_kind_id == id);
            return Content(JsonConvert.SerializeObject(list));
        }
        //二级阶段
        public ActionResult GetbyYid(string id)
        {

            List<config_file_second_kind> list1 = iskb.SelectWhere(e => e.first_kind_id == id);

            return Content(JsonConvert.SerializeObject(list1));
        }
        //三级阶段
        public ActionResult GetbyEid(string id, string yid)
        {

            List<config_file_third_kind> list2 = itkb.SelectWhere(e => e.first_kind_id == yid && e.second_kind_id == id);

            return Content(JsonConvert.SerializeObject(list2));
        }

        //人力资源登记提交
        [HttpPost]
        public ActionResult index(human_file hf) {
            config_file_first_kind s = ifkb.selectWhere(e => e.first_kind_id == hf.first_kind_id).FirstOrDefault();
            config_file_second_kind s1 = iskb.SelectWhere(e => e.second_kind_id == hf.second_kind_id).FirstOrDefault();
            config_file_third_kind s2 = itkb.SelectWhere(e => e.third_kind_id == hf.third_kind_id).FirstOrDefault();
            config_major s3 = imb.SelectWhere(e => e.major_id == hf.human_major_id).FirstOrDefault();
            config_major_kind s4 = imkb.SelectWhere(e => e.major_kind_id == hf.human_major_kind_id).FirstOrDefault();
            salary_standard ssd = issdb.SelectWhere(e => e.standard_id == hf.salary_standard_id).FirstOrDefault();
            hf.salary_standard_name = ssd.standard_name;
            hf.first_kind_name = s.first_kind_name;
            hf.second_kind_name = s1.second_kind_name;
            hf.third_kind_name = s2.third_kind_name;
            hf.hunma_major_name = s3.major_name;
            hf.human_major_kind_name = s4.major_kind_name;
            hf.check_status = 0;
            hf.salary_sum = ssd.salary_sum;
            hf.demand_salaray_sum = ssd.salary_sum;
            hf.paid_salary_sum = ssd.salary_sum;
            hf.file_chang_amount = 0;
            hf.lastly_change_time = DateTime.Now;
            if (ihdb.Update(hf) > 0)
            {
                return Content("<script>location.href='/Human_file/Top_file/" + hf.huf_id + "'</script>");
            }
            else {
                return Content("<script>alert('登记失败');location.href='/Human_file/index'</script>");
            }

        }

        //上传图片
        public ActionResult Top_file(int id) {
            human_file h = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            return View(h);
        }

        //上传图片提交
        public ActionResult TopImg(IEnumerable<HttpPostedFileBase> human_picture, int id)
        {
            string s = "";
            string type = "";
            getFile(human_picture, ref s, ref type, "img");

            if (type == ".jpg" || type == ".gif" || type == "")
            {

                human_file hff = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
                if (s == null || s == "")
                {
                    if (hff.human_picture == null)
                    {
                        hff.human_picture = s;
                    }

                }
                else {
                    hff.human_picture = s;
                }


                if (ihdb.Update(hff) > 0)
                {
                    return Content("<script>alert('上传成功');location.href='/Human_file/Top_file/" + id + "'</script>");
                }
                else
                {
                    return Content("<script>alert('上传失败');location.href='/Human_file/Top_file/" + id + "'</script>");
                }

            }
            else
            {
                return Content("<script>alert('文件类型错误');location.href='/Human_file/Top_file/" + id + "';</script>");
            }


        }

        //文件上传
        private void getFile(IEnumerable<HttpPostedFileBase> filename, ref string s, ref string type, string top_type)
        {

            foreach (HttpPostedFileBase item in filename)
            {
                if (item == null)
                {
                    s = null;
                }
                else
                {
                    s = item.FileName;
                    FileInfo fi = new FileInfo(s);
                    type = fi.Extension;//获取类型  
                    string path = "";
                    if (top_type == "img")
                    {
                        path = Server.MapPath("~/images/img/" + s);//获取全路径
                    }
                    else if (top_type == "Fufile")
                    {
                        path = Server.MapPath("~/file_file/" + s);
                    }
                    else
                    {

                    }

                    item.SaveAs(path);//将内容写入路劲内
                }
            }



        }


        //上传文件
        public ActionResult Top_file_file(int id) {
            human_file h = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();

            return View(h);
        }
        //上传附件提交
        public ActionResult TopFu_file(IEnumerable<HttpPostedFileBase> file_filename, int id)
        {
            string s = "";
            string type = "";
            getFile(file_filename, ref s, ref type, "Fufile");

            if (type == ".doc" || type == ".txt" || type == ".pdf" || type == ".jpg" || type == "")
            {

                human_file hff = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
                if (s == null || s == "")//判断fileName==null就在里面进行判断数据库的文件列是不是也为空，是就赋null
                {
                    if (hff.attachment_name == null)
                    {
                        hff.attachment_name = s;
                    }
                }
                else
                {
                    hff.attachment_name = s;
                }


                if (ihdb.Update(hff) > 0)
                {
                    return Content("<script>alert('上传附件成功');location.href='/Human_file/Top_file_file/" + id + "'</script>");
                }
                else
                {
                    return Content("<script>alert('上传附件失败');location.href='/Human_file/Top_file_file/" + id + "'</script>");
                }

            }
            else
            {
                return Content("<script>alert('文件类型错误');location.href='/Human_file/Top_file_file/" + id + "';</script>");
            }


        }


        //人力资源档案登记复核列表
        public ActionResult index2() {
            return View();
        }
        //登记复核查询分页
        public ActionResult GetDenjiFuHe(int currentpage)
        {
            Expression<Func<human_file, bool>> where = null;
            int rows;

            where = e => e.check_status == 0 && e.first_kind_name != null;

            var data = ihdb.SelectFenYe(e => e.huf_id, where, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));

        }

        //人力资源档案登记复核细节
        [HttpGet]
        public ActionResult FuHe(int id)
        {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            ViewBag.guoji = ipcb.SelectWhere(e => e.attribute_kind == "国籍");
            ViewBag.minzu = ipcb.SelectWhere(e => e.attribute_kind == "民族");
            ViewBag.xinyan = ipcb.SelectWhere(e => e.attribute_kind == "宗教信仰");
            ViewBag.mianmao = ipcb.SelectWhere(e => e.attribute_kind == "政治面貌");
            ViewBag.xueli = ipcb.SelectWhere(e => e.attribute_kind == "学历");
            ViewBag.nianxian = ipcb.SelectWhere(e => e.attribute_kind == "教育年限");
            ViewBag.zhuanye = ipcb.SelectWhere(e => e.attribute_kind == "专业");
            ViewBag.techang = ipcb.SelectWhere(e => e.attribute_kind == "特长");
            ViewBag.aihao = ipcb.SelectWhere(e => e.attribute_kind == "爱好");
            ViewBag.chenzhi = ipcb.SelectWhere(e => e.attribute_kind == "职称");
            ViewBag.xinchou = issdb.Select();
            ViewBag.user = iub.Select();
            return View(hf);
        }

        //人力资源档案登记复核细节提交
        [HttpPost]
        public ActionResult FuHe(human_file hfa)
        {
            salary_standard ssd = issdb.SelectWhere(e => e.standard_id == hfa.salary_standard_id).FirstOrDefault();
            hfa.salary_standard_name = ssd.standard_name;
            hfa.check_status = 1;
            hfa.salary_sum = ssd.salary_sum;
            hfa.demand_salaray_sum = ssd.salary_sum;
            hfa.paid_salary_sum = ssd.salary_sum;
            hfa.human_file_status = true;
            if (hfa.file_chang_amount == null)
            {
                hfa.file_chang_amount = 0;
            }
            else {
                hfa.file_chang_amount++;
            }
            
            hfa.lastly_change_time = DateTime.Now;
            if (ihdb.Update(hfa) > 0)
            {
                return Content("<script>location.href='/Human_file/Top_file/" + hfa.huf_id + "'</script>");
            }
            else
            {
                return Content("<script>alert('复核失败');location.href='/Human_file/index'</script>");
            }

        }


        //人力资源档案查询
        public ActionResult index3() {
            GetYjandZyname();
            return View();
        }

        //查询提交页面
        [HttpPost]
        public ActionResult Selectwhere_liebiao(human_file hfw,string startDate, string endDate) {

            GetWhere(hfw,startDate,endDate);
            return View();
        }
        //查询结果列表分页
        public ActionResult GetLieList(int currentpage) {
            int rows;
            Expression<Func<human_file, bool>> where2=null;
            if (Session["where"] == null)
            {

                where2 = e => e.check_status >= 1;
            }
            else {
                Dictionary<string, object> di = (Dictionary<string, object>) Session["where"];

                string yi=  di["yiji"].ToString();
                string er = di["erji"].ToString();
                string san = di["sanji"].ToString();
                string zy = di["zhiye"].ToString();
                string zyfl = di["zhiyefl"].ToString();
                DateTime jiezhi =DateTime.Parse(di["end"].ToString());
                DateTime qishi = DateTime.Parse(di["sta"].ToString()) ;

                where2 = e => e.first_kind_id == yi
                  && e.second_kind_id == er
                   && e.third_kind_id == san
                   && e.human_major_id ==zy
                   && e.human_major_kind_id == zyfl
                   && e.regist_time >= qishi && e.regist_time <= jiezhi
                   && e.check_status == 1; ;
            }
            var data = ihdb.SelectFenYe(e => e.huf_id, where2, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }

        //查询结果细节
        public ActionResult Select_human_xijie(int id) {
            human_file hf = ihdb.SelectWhere(e=>e.huf_id==id).FirstOrDefault();
            return View(hf);
        }

        //人力资源档案变更
        public ActionResult index4()
        {
            GetYjandZyname();

            return View();
        }
        //变更查询列表页面
        [HttpPost]
        public ActionResult BiangenSelect_liebiao(human_file hfwa, string startDate, string endDate)
        {

            GetWhere(hfwa,startDate,endDate);
            return View();
        }

        //变更细节页面
        [HttpGet]
        public ActionResult Baingeng_human_xijie(int id)
        {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
          
            ViewBag.guoji = ipcb.SelectWhere(e => e.attribute_kind == "国籍");
            ViewBag.minzu = ipcb.SelectWhere(e => e.attribute_kind == "民族");
            ViewBag.xinyan = ipcb.SelectWhere(e => e.attribute_kind == "宗教信仰");
            ViewBag.mianmao = ipcb.SelectWhere(e => e.attribute_kind == "政治面貌");
            ViewBag.xueli = ipcb.SelectWhere(e => e.attribute_kind == "学历");
            ViewBag.nianxian = ipcb.SelectWhere(e => e.attribute_kind == "教育年限");
            ViewBag.zhuanye = ipcb.SelectWhere(e => e.attribute_kind == "专业");
            ViewBag.techang = ipcb.SelectWhere(e => e.attribute_kind == "特长");
            ViewBag.aihao = ipcb.SelectWhere(e => e.attribute_kind == "爱好");
            ViewBag.chenzhi = ipcb.SelectWhere(e => e.attribute_kind == "职称");
            ViewBag.xinchou = issdb.Select();
            ViewBag.user = iub.Select();
            return View(hf);
        }

        //变更细节提交
        [HttpPost]
        public ActionResult Baingeng_human_xijie(human_file hfaa)
        {
            salary_standard ssd = issdb.SelectWhere(e => e.standard_id == hfaa.salary_standard_id).FirstOrDefault();
            hfaa.salary_standard_name = ssd.standard_name;
            hfaa.check_status = 0;
            hfaa.salary_sum = ssd.salary_sum;
            hfaa.demand_salaray_sum = ssd.salary_sum;
            hfaa.paid_salary_sum = ssd.salary_sum;
            hfaa.file_chang_amount++;
            hfaa.lastly_change_time = DateTime.Now;
            hfaa.human_file_status = false;
            if (ihdb.Update(hfaa) > 0)
            {
                return Content("<script>location.href='/Human_file/Top_file/" + hfaa.huf_id + "'</script>");
            }
            else
            {
                return Content("<script>alert('变更失败');location.href='/Human_file/index'</script>");
            }
           
        }


        //人力资源档案删除
        public ActionResult index5()
        {
            GetYjandZyname();

            return View();
        }


        //删除查询列表页面
        [HttpPost]
        public ActionResult DelSelect_liebiao(human_file hfwaa, string startDate, string endDate)
        {
            GetWhere(hfwaa, startDate, endDate);
            return View();
        }

        //存条件
        private void GetWhere(human_file hfwaa, string startDate, string endDate)
        {
            if (hfwaa.first_kind_id != null && hfwaa.second_kind_id != null && hfwaa.third_kind_id != null && hfwaa.human_major_id != null && hfwaa.human_major_kind_id != null && startDate != "" && endDate != "")
            {
                DateTime sta = DateTime.Parse(startDate);
                DateTime end = DateTime.Parse(endDate);
                //where = 
                Dictionary<string, object> di = new Dictionary<string, object>();
                di.Add("yiji", hfwaa.first_kind_id);
                di.Add("erji", hfwaa.second_kind_id);
                di.Add("sanji", hfwaa.third_kind_id);
                di.Add("zhiye", hfwaa.human_major_id);
                di.Add("zhiyefl", hfwaa.human_major_kind_id);
                di.Add("sta", sta);
                di.Add("end", end);

                Session["where"] = di;
            }
            else
            {

                Session["where"] = null;
            }
        }



        //人力资源档案删除分页
        public ActionResult GetDelList(int currentpage)
        {
            int rows;
            Expression<Func<human_file, bool>> where2 = null;
            if (Session["where"] == null)
            {

                where2 = e => e.human_file_status==true;
            }
            else
            {
                Dictionary<string, object> di = (Dictionary<string, object>)Session["where"];

                string yi = di["yiji"].ToString();
                string er = di["erji"].ToString();
                string san = di["sanji"].ToString();
                string zy = di["zhiye"].ToString();
                string zyfl = di["zhiyefl"].ToString();
                DateTime jiezhi = DateTime.Parse(di["end"].ToString());
                DateTime qishi = DateTime.Parse(di["sta"].ToString());

                where2 = e => e.first_kind_id == yi
                  && e.second_kind_id == er
                   && e.third_kind_id == san
                   && e.human_major_id == zy
                   && e.human_major_kind_id == zyfl
                   && e.regist_time >= qishi && e.regist_time <= jiezhi
                   && e.human_file_status == true;
            }
            var data = ihdb.SelectFenYe(e => e.huf_id, where2, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }

        
        //删除细节页面
        [HttpGet]
        public ActionResult Del_human_xijie(int id)
        {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            return View(hf);
        }

        //删除细节提交
        [HttpPost]
        public ActionResult Del_human_xijie(human_file hfaaw)
        {
            human_file hf = ihdb.SelectWhere(e=>e.huf_id==hfaaw.huf_id).FirstOrDefault();


            if (hf.check_status == 0)
            {

                return Content("<script>alert('该档案还未复核不能删除！');</script>");

            }
            else
            {



                hf.human_file_status = false;
                hf.lastly_change_time = DateTime.Now;
                hf.delete_time = DateTime.Now;
                if (ihdb.Update(hf) > 0)
                {
                    return Content("<script>alert('删除成功');location.href='/Human_file/index5'</script>");
                }
                else
                {
                    return Content("<script>alert('删除失败');location.href='/Human_file/index'</script>");
                }
            }
        }




        //人力资源档案恢复
        public ActionResult index6()
        {
            GetYjandZyname();

            return View();
        }



        //恢复查询列表页面
        [HttpPost]
        public ActionResult HuiFuSelect_liebiao(human_file hfwaa, string startDate, string endDate)
        {
            GetWhere(hfwaa, startDate, endDate);
            return View();
        }


        //人力资源档案恢复分页
        public ActionResult GetHuiFuList(int currentpage)
        {
            int rows;
            Expression<Func<human_file, bool>> where2 = null;
            if (Session["where"] == null)
            {

                where2 = e => e.human_file_status == false&&e.check_status==1;
            }
            else
            {
                Dictionary<string, object> di = (Dictionary<string, object>)Session["where"];

                string yi = di["yiji"].ToString();
                string er = di["erji"].ToString();
                string san = di["sanji"].ToString();
                string zy = di["zhiye"].ToString();
                string zyfl = di["zhiyefl"].ToString();
                DateTime jiezhi = DateTime.Parse(di["end"].ToString());
                DateTime qishi = DateTime.Parse(di["sta"].ToString());

                where2 = e => e.first_kind_id == yi
                  && e.second_kind_id == er
                   && e.third_kind_id == san
                   && e.human_major_id == zy
                   && e.human_major_kind_id == zyfl
                   && e.regist_time >= qishi && e.regist_time <= jiezhi
                   && e.human_file_status == false
                   && e.check_status == 1;
            }
            var data = ihdb.SelectFenYe(e => e.huf_id, where2, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }



        //恢复细节页面
        [HttpGet]
        public ActionResult HuiFu_human_xijie(int id)
        {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            return View(hf);
        }

        //恢复细节提交
        [HttpPost]
        public ActionResult HuiFu_human_xijie(human_file hfaawa)
        {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == hfaawa.huf_id).FirstOrDefault();
            hf.human_file_status = true;
            hf.lastly_change_time = DateTime.Now;
           hf.recovery_time = DateTime.Now;
            if (ihdb.Update(hf) > 0)
            {
                return Content("<script>alert('恢复成功');location.href='/Human_file/index6'</script>");
            }
            else
            {
                return Content("<script>alert('恢复失败');location.href='/Human_file/index6'</script>");
            }

        }




        //人力资源档案永久删除
        public ActionResult index7()
        {
          
            return View();
        }

        //人力资源档案永久删除分页
        public ActionResult GetTrueDelList(int currentpage)
        {
            int rows;
            Expression<Func<human_file, bool>> where2 = null;
            where2 = e => e.check_status >= 1;
            var data = ihdb.SelectFenYe(e => e.huf_id, where2, out rows, currentpage, 2);
            Dictionary<string, object> dtion = new Dictionary<string, object>();
            dtion.Add("data", data);
            dtion.Add("rows", rows);
            dtion.Add("page", rows % 2 > 0 ? (rows / 2) + 1 : (rows / 2));
            return Content(JsonConvert.SerializeObject(dtion));
        }
        //人力资源档案永久删除
        public ActionResult True_Del(int id) {
            human_file hf = ihdb.SelectWhere(e => e.huf_id == id).FirstOrDefault();
            if (ihdb.Del(hf) > 0)
            {
                return Content("<script>alert('永久删除成功！');location.href='/Human_file/index7'</script>");
            }
            else {
                return Content("<script>alert('永久删除失败！');location.href='/Human_file/index7'</script>");

            }
        }

        //查询一级结构和职业分类
        private void GetYjandZyname()
        {
            ViewBag.yiji = ifkb.SelectAll();
            ViewBag.fl = imkb.Select();
        }
    }
}