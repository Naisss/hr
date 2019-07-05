using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using IDao;
using IBLL;
using IocContianer;
using System.Linq.Expressions;
using Entity;

namespace BLL
{
   public  class engage_interviewBLL:Iengage_interviewBLL
    {
        Iengage_interviewDao iid = iocCreate.engage_interviewDao();
        public List<engage_interview> Select() {
            return iid.SelectAll();
        }
        public List<engage_interview> SelectWhere(Expression<Func<engage_interview,bool>> where)
        {
            return iid.selectWhere(where);
        }

        public int Insert(engage_interview en)
        {
            return iid.Insert(en);
        }

        public List<engage_interview> SelectFenYe(Expression<Func<engage_interview,int>> order,Expression<Func<engage_interview,bool>> where,out int rows,int currentPage,int pageSize) {

            return iid.FenYe(order,where,out rows,currentPage,pageSize);
        }

        public int Update(engage_interview en) {
            return iid.Update(en);
        }

        public int Del(engage_interview en) {
            return iid.Del(en);
        }

    }
}
