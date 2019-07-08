using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using IocContianer;
using IBLL;
using Entity;
using System.Linq.Expressions;
namespace BLL
{
   public class salary_grantBLL:Isalary_grantBLL
    {
        Isalary_grantDao<salary_grant> s = iocCreate._grant();

        public int Insert(salary_grant t)
        {
            return s.Insert(t);
        }

        public List<salary_grant> Select()
        {
            return s.SelectAll();
        }

        public List<salary_grant> SelectFenYe(Expression<Func<salary_grant, int>> order, Expression<Func<salary_grant, bool>> where, out int rows, int currentPage, int pageSize)
        {
            return s.FenYe(order, where, out rows, currentPage, pageSize);
        }

        public List<salary_grant> selectWhere(Expression<Func<salary_grant, bool>> where)
        {
           return s.selectWhere(where);
        }

        public int Update(salary_grant t)
        {
            return s.Update(t);
        }
    }
}
