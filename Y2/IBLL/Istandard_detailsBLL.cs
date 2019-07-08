using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
  public  interface Istandard_detailsBLL
    {
        int Insert(salary_standard_details t);
        List<salary_standard_details> selectWhere(Expression<Func<salary_standard_details, bool>> where);  //通用where条件查询
        int Update(salary_standard_details t);//修改
        List<salary_standard_details> Select();

    }
}
