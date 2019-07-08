using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using IBLL;
using IocContianer;
using Newtonsoft.Json;
using Dao;
using System.Data;
namespace UI.Controllers
{
    public class salary_grantController : Controller
    {
        Ifirst_kindBLL fbll = iocCreate.CreateTextBll<Ifirst_kindBLL>("first_kindBLL");
        Isalary_grantBLL ioc = iocCreate.CreateTextBll<Isalary_grantBLL>("salary_grantBLL");
        Isecond_kindBLL se = iocCreate.CreateTextBll<Isecond_kindBLL>("second_kindBLL");
        Ithird_kindBLL th = iocCreate.CreateTextBll<Ithird_kindBLL>("third_kindBLL");
        I_fileBLL f = iocCreate.CreateTextBll<I_fileBLL>("_fileBLL");
        Igrant_detailsBLL ii = iocCreate.CreateTextBll<Igrant_detailsBLL>("grant_detailsBLL");
        Istandard_detailsBLL io = iocCreate.CreateTextBll<Istandard_detailsBLL>("standard_detailsBLL");
        // GET: salary_grant
        #region 登记

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _grant1()    //根据一级机构名称查询
        {


            ViewBag.first = fbll.SelectAll();
            ViewBag.human_file = f.Select();
            return View();
        }

        public ActionResult _grant2()
        {//根据二级机构名称查询
            ViewBag.first = se.Select();
            ViewBag.human_file = f.Select();
            return View();


        }
        public ActionResult _grant3()
        {//三级查询

            ViewBag.first = th.Select();
            ViewBag.human_file = f.Select();
            return View();

        }
        // GET: salary_grant/Details/5
        public ActionResult _GUN(string id, string Name)
        {
            ViewBag.guid = f.GUID1();
            Session["RegisName"] = Name;
            //按照薪酬标准项目和员工的薪酬标准设定列出员工的工资构成及金额       
            Session["Type"] = 1;
            string str = id;   //一级机构名称编号
            List<human_file> lists = f.selectWhere(e => e.first_kind_id == id);
            ViewBag.fir = lists;
            string[] listId = new string[lists.Count];//获取出长度
            List<salary_standard_details> list = new List<salary_standard_details>();//薪水查询
            for (int i = 0; i < listId.Length; i++)
            {
                listId[i] = lists[i].salary_standard_id;
            }

            List<List<salary_standard_details>> xs = new List<List<salary_standard_details>>();
            foreach (string item in listId)
            {
                xs.Add(io.selectWhere(e => e.standard_id == item));
            }
            ViewBag.fird = xs;
            return View();

        }
        public ActionResult xq(string id) {
            ViewBag.jj = io.selectWhere(e=>e.standard_id==id);

            return View();
        }




        public ActionResult _GUN2(string id, string Name)
        {
            ViewBag.guid = f.GUID1();
            Session["RegisName"] = Name;
            //按照薪酬标准项目和员工的薪酬标准设定列出员工的工资构成及金额       
            Session["Type"] = 2;
            string str = id;   //一级机构名称编号
            List<human_file> lists = f.selectWhere(e => e.second_kind_id == id);
            ViewBag.fir = lists;
            string[] listId = new string[lists.Count];//获取出长度
            List<salary_standard_details> list = new List<salary_standard_details>();//薪水查询
            for (int i = 0; i < listId.Length; i++)
            {
                listId[i] = lists[i].salary_standard_id;
            }

            List<List<salary_standard_details>> xs = new List<List<salary_standard_details>>();
            foreach (string item in listId)
            {
                xs.Add(io.selectWhere(e => e.standard_id == item));
            }
            ViewBag.fird = xs;
            return View();

        }
        public ActionResult _GUN3(string id, string Name)
        {

            ViewBag.guid = f.GUID1();
            Session["RegisName"] = Name;
            //按照薪酬标准项目和员工的薪酬标准设定列出员工的工资构成及金额       
            Session["Type"] = 3;
            string str = id;   //一级机构名称编号
            List<human_file> lists = f.selectWhere(e => e.third_kind_id == id);
            ViewBag.fir = lists;
            string[] listId = new string[lists.Count];//获取出长度
            List<salary_standard_details> list = new List<salary_standard_details>();//薪水查询
            for (int i = 0; i < listId.Length; i++)
            {
                listId[i] = lists[i].salary_standard_id;
            }

            List<List<salary_standard_details>> xs = new List<List<salary_standard_details>>();
            foreach (string item in listId)
            {
                xs.Add(io.selectWhere(e => e.standard_id == item));
            }
            ViewBag.fird = xs;
            return View();

        }
        [HttpPost]
        public ActionResult Addregister_commit(FormCollection c)
        { //人力资源--薪酬标准管理--薪酬发放登记提交
            salary_grant sa = new salary_grant();
            String type = Session["Type"].ToString(); //Type刚选的机构i
            if (type == "1")
            {
                sa.first_kind_name = Session["RegisName"].ToString();

            }
            else if (type == "2")
            {
                sa.second_kind_name = Session["RegisName"].ToString();
            }
            else
            {
                sa.third_kind_name = Session["RegisName"].ToString();
            }
            sa.salary_grant_id = c["salary_grant_id"];
            sa.human_amount = short.Parse(c["human_amount"]);
            sa.salary_standard_sum = decimal.Parse(c["salary_standard_sum"]);
            sa.salary_paid_sum = decimal.Parse(c["salary_paid_sum"]);
            sa.register = c["register"];
            sa.regist_time = DateTime.Parse(c["regist_time"]);
            sa.check_status = 0;
       
            int mun1 = 0;
            for (int i = 0; i < sa.human_amount; i++)
            {
                salary_grant_details sala = new salary_grant_details();
                sa.salary_standard_id = c["salary_standard_id" + i];
                sala.salary_grant_id = c["salary_grant_id"];
                sala.human_id = c["grantDetails" + i + ".human_id"];
                sala.human_name = c["grantDetails" + i + ".humanName"];
                sala.bouns_sum = decimal.Parse(c["grantDetails" + i + ".bounsSum"]);
                sala.sale_sum = decimal.Parse(c["grantDetails" + i + ".saleSum"]);
                sala.deduct_sum = decimal.Parse(c["grantDetails" + i + ".deductSum"]);
                sala.salary_standard_sum = decimal.Parse(c["grantDetails"+i+".salary_standard_sum"]);
                sala.salary_paid_sum = decimal.Parse(c["grantDetails" + i + ".salaryPaidSum"]);
                mun1 = ii.Insert(sala);
            }
            int mun = ioc.Insert(sa);
            if (mun > 0 && mun1 > 0)
            {
                return Content("<script>alert('新增成功');location.href='/salary_grant/Index'</script>");

            }

            return View();
        }
        #endregion

        #region 复核Vue分页
        public ActionResult check_list()
        {

            return View();

        }
        [HttpPost]
        public ActionResult check_list(int currentPage, int pageSize)
        {
            int rows = 0;
            List<salary_grant> list = ioc.SelectFenYe(e => e.sgr_id, e => e.check_status == 0, out rows, currentPage, pageSize);
            Dictionary<String, object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["row"] = rows;
            return Content(JsonConvert.SerializeObject(di));
        }

        public ActionResult check(String id, String sid)
        {

            Dictionary<String, object> di = new Dictionary<string, object>();
            List<salary_grant> sg = ioc.Select();
            List<salary_grant_details> list = ii.selectWhere(e => e.salary_grant_id == id).ToList();
            List<string> Xq = new List<string>();
            decimal Sum = 0;
            decimal Sums = 0;//基本薪酬总数
            for (int i = 0; i < list.Count(); i++)
            {
                String c = list[i].human_name;
                string xid = list[i].human_id;
                List<salary_standard_details> list1 = io.selectWhere(e => e.standard_name == c).ToList();
                human_file XQ = f.selectWhere(e => e.human_id == xid).FirstOrDefault();
                Xq.Add(XQ.salary_standard_id);
                di["list" + i] = list1;
                Sum = Sum + Convert.ToDecimal(list[i].salary_paid_sum);
                Sums = Sums + Convert.ToDecimal(list[i].salary_standard_sum);
            }
            ViewBag.Sum = Sum;
            ViewBag.Sums = Sums;

            di["salary_grant_details"] = list;
            di["sg"] = sg;
            ViewBag.s = di;
            ViewBag.ss = Xq;
            return View();
        }

        public ActionResult UpdateZ(FormCollection c) {

            salary_grant sa = new salary_grant();
            //String type = Session["Type"].ToString(); //Type刚选的机构i
            //if (type == "1")
            //{
            //    sa.first_kind_name = Session["RegisName"].ToString();

            //}
            //else if (type == "2")
            //{
            //    sa.second_kind_name = Session["RegisName"].ToString();
            //}
            //else
            //{
            //    sa.third_kind_name = Session["RegisName"].ToString();
            //}
            //sa.sgr_id = Convert.ToInt16(c["sgr_id"]);
            string gid = c["salary_grant_id1"];
          
            salary_grant k = ioc.selectWhere(e => e.salary_grant_id == gid).FirstOrDefault();


            sa.sgr_id = k.sgr_id;
            sa.register = k.register;
            sa.regist_time = k.regist_time;
            sa.first_kind_name = k.first_kind_name;
            sa.second_kind_name = k.second_kind_name;
            sa.third_kind_name = k.third_kind_name;
            sa.salary_grant_id = c["salary_grant_id1"];
            sa.human_amount = short.Parse(c["human_amount"]);
            sa.salary_standard_sum = decimal.Parse(c["salary_standard_sum"]);
            sa.salary_paid_sum = decimal.Parse(c["salary_paid_sum"]);
            sa.checker = c["checker"];
            sa.check_time = DateTime.Parse(c["check_time"]);
            sa.check_status = 1;
            int mun = 0;
            int mun1 = 0;
    
            for (int i = 0; i < sa.human_amount; i++)
            {
                salary_grant_details sala = new salary_grant_details();
                //sala.grd_id = Convert.ToInt16(c["grd_id"]);
                string[] a = (c["grd_id"]).ToString().Split(',');
                sa.salary_standard_id = c["salary_standard_id" + i];
                sala.salary_grant_id = c["salary_grant_id1"];
                sala.human_id = c["grantDetails" + i + ".humanId"];
                sala.human_name = c["grantDetails" + i + ".humanName"];
                sala.bouns_sum = decimal.Parse(c["grantDetails" + i + ".bounsSum"]);
                sala.sale_sum = decimal.Parse(c["grantDetails" + i + ".saleSum"]);
                sala.deduct_sum = decimal.Parse(c["grantDetails" + i + ".deductSum"]);
                sala.salary_standard_sum = decimal.Parse(c["grantDetails" + i + ".salary_standard_sum"]);
                sala.salary_paid_sum = decimal.Parse(c["grantDetails" + i + ".salaryPaidSum"]);
                sala.grd_id = Convert.ToInt16(a[i]);
             mun1 = ii.Update(sala);
                
            }
            mun = ioc.Update(sa);

            if (mun > 0 && mun1 > 0)
            {
                return Content("<script>alert('修改成功');location.href='/salary_grant/Index'</script>");

            }            
            return View();
        }
        #endregion


        #region 查询

        public ActionResult query_locate()
        {


            return View();
        }

        public ActionResult query_list()
        {
            Dictionary<String, object> di = new Dictionary<string, object>();
            di["Id"] = Request["salaryGrantId"];
            di["Nmae"] = Request["primarKey"];
            di["startDate"] = Request["utilbean.startDate"];
            di["endDate"] = Request["utilbean.endDate"];
            Session["query_lis"] = di;//薪酬发放管理--薪酬发放查值
            return View();
        }
        public ActionResult query_list1(int currentPage, int pageSize)
        {
            int rows = 0;
            Dictionary<String, object> di = Session["query_lis"] as Dictionary<String, object>;
            String id = di["Id"].ToString();
            String Name = di["Nmae"].ToString();
            DateTime startDate ;
            DateTime endDate;
            if (di["startDate"].ToString() == "")
            {
                di["startDate"]= "1001-5-5";
                 startDate = DateTime.Parse(di["startDate"].ToString());
            }
            else {
                 startDate = DateTime.Parse(di["startDate"].ToString());
            }
            if (di["endDate"].ToString() == "")
            {
                di["endDate"] = "2501-5-5";
                 endDate = DateTime.Parse(di["endDate"].ToString());
            }
            else
            {
                 endDate = DateTime.Parse(di["endDate"].ToString());
            }
            List<salary_grant> list = ioc.SelectFenYe(e => e.sgr_id, e => e.salary_grant_id.Contains(id) && (e.register.Contains(Name) || e.second_kind_name.Contains(Name)) && (e.regist_time > startDate && e.regist_time < endDate), out rows, currentPage, pageSize);
            Dictionary<String, object> dtt = new Dictionary<string, object>();
            dtt["dt"] = list;
            dtt["row"] = rows;
            return Content(JsonConvert.SerializeObject(dtt));
        }
        public ActionResult query(String id)
        {
            Dictionary<String, object> di = new Dictionary<string, object>();
            List<salary_grant_details> list = ii.selectWhere(e => e.salary_grant_id == id).ToList();
            List<string> Xq = new List<string>();
            decimal Sum = 0;
            decimal Sum1 = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                String c = list[i].human_name;
                string xid = list[i].human_id;
                List<salary_standard_details> list1 =io.selectWhere(e => e.standard_name == c).ToList();         
                human_file XQ = f.selectWhere(e => e.human_id == xid).FirstOrDefault();
                Xq.Add(XQ.salary_standard_id);
                di["list" + i] = list1;
                Sum = Sum + Convert.ToDecimal(list[i].salary_paid_sum);
                Sum1 = Sum1 + Convert.ToDecimal(list[i].salary_standard_sum);
            }
            ViewBag.Sum = Sum;
            ViewBag.Sum1 = Sum1;
            di["salary_grant_details"] = list;
            ViewBag.s = di;
            ViewBag.ss = Xq;
            return View();
        }



        #endregion
    }
}
