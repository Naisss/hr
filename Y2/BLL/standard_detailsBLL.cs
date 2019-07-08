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
 public   class standard_detailsBLL: Istandard_detailsBLL
    {
        Istandard_detailsDao<salary_standard_details> s = iocCreate.standard_detailsioc();

        public int Insert(salary_standard_details t)
        {
            return s.Insert(t);
        }

        public List<salary_standard_details> Select()
        {
            return s.SelectAll();
        }

        public List<salary_standard_details> selectWhere(Expression<Func<salary_standard_details, bool>> where)
        {
            return s.selectWhere(where);
        }

        public int Update(salary_standard_details t)
        {
            return s.Update(t);
        }
    }
}
