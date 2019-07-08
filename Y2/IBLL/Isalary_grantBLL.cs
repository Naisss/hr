using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
  public  interface Isalary_grantBLL
    {
        List<salary_grant> SelectFenYe(Expression<Func<salary_grant, int>> order, Expression<Func<salary_grant, bool>> where, out int rows, int currentPage, int pageSize);
        List<salary_grant> selectWhere(Expression<Func<salary_grant, bool>> where);  //通用where条件查询
        int Insert(salary_grant t);//新增
        int Update(salary_grant t);//修改
        List<salary_grant> Select();
    }
}
