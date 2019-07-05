using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using Entity;
using IDao;
using IBLL;
using System.Linq.Expressions;
namespace BLL
{
    public class salary_standard_detailsBLL:Isalary_standard_detailsBLL
    {
        Isalary_standard_detailsDao issdd = iocCreate.salary_standard_detailsDao();
        public List<salary_standard_details> Select() {
            return issdd.SelectAll();
        }
        public List<salary_standard_details> SelectWhere(Expression<Func<salary_standard_details,bool>> where)
        {
            return issdd.selectWhere(where);
        }



    }
}
