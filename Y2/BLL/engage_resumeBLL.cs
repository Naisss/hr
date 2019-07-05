using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using Entity;
using IBLL;
using IDao;
using System.Linq.Expressions;
namespace BLL
{
    public class engage_resumeBLL : Iengage_resumeBLL
    {
        Iengage_resumeDao<engage_resume> ierd = iocCreate.engage_resumeDao();
        public int Insert(engage_resume er) {
            return ierd.Insert(er);
        }

        public List<engage_resume> Select() {
            return ierd.SelectAll();
        }
        public List<engage_resume> SelectWhere(Expression<Func<engage_resume,bool>> where)
        {
            return ierd.selectWhere(where);
        }

        public List<engage_resume> SelectFenye(Expression<Func<engage_resume,int>> order, Expression<Func<engage_resume, bool>> where,out int rows,int currentPage, int pageSize) {
            return ierd.FenYe(order,where,out rows,currentPage,pageSize);
        }

        public int Update(engage_resume er) {
            return ierd.Update(er);
        }

        public int Del(engage_resume er) {
            return ierd.Del(er);
        }
    }
}
