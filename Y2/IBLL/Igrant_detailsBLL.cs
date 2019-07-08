using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
   public interface Igrant_detailsBLL
    {
        List<salary_grant_details> selectWhere(Expression<Func<salary_grant_details, bool>> where);  //通用where条件查询
        int Insert(salary_grant_details t);//新增
        int Update(salary_grant_details t);//修改
    }
}
