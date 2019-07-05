using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IocContianer;
using IBLL;
using IDao;
using System.Linq.Expressions;

namespace BLL
{
    public class major_releaseBLL : Imajor_releaseBLL
    {
        Imajor_releaseDao<engage_major_release> s = iocCreate.text01Dao();
        public int Add(engage_major_release ms)
        {
            return s.Insert(ms);
        }

        public List<engage_major_release> SelectFenYe(Expression<Func<engage_major_release, int>> order, Expression<Func<engage_major_release, bool>> where, out int rows, int currentPage, int pageSize)
        {

            return s.FenYe(order, where, out rows, currentPage, pageSize);
        }


        public List<engage_major_release> SelectWhere(Expression<Func<engage_major_release, bool>> where)
        {

            return s.selectWhere(where);
        }

        public int Update(engage_major_release emr) {
            return s.Update(emr);
        }

        public int Del(engage_major_release mr) {
            return s.Del(mr);
        }
    }
}
