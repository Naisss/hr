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
 public   class grant_detailsBLL:Igrant_detailsBLL
    {
        Igrant_detailsDao<salary_grant_details> s = iocCreate.grant_details();

        public int Insert(salary_grant_details t)
        {
            return s.Insert(t);
        }

        public List<salary_grant_details> selectWhere(Expression<Func<salary_grant_details, bool>> where)
        {
            return s.selectWhere(where);
        }

        public int Update(salary_grant_details t)
        {
            return s.Update(t);
        }
    }
}
