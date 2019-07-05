using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDao;
using IocContianer;
using System.Linq.Expressions;
using Entity;

namespace BLL
{
   public  class salary_standardBLL:Isalary_standardBLL
    {
        Isalary_standardDao issd = iocCreate.salary_standardDao();

        public List<salary_standard> Select() {
            return issd.SelectAll();
        }

        public List<salary_standard> SelectWhere(Expression<Func<salary_standard,bool>> where) {
            return issd.selectWhere(where);
        }
    }
}
