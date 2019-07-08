using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
   public interface IstandardBLL
    {
        int Insert(salary_standard t);//新增
        string GUID();//单号
        List<salary_standard> SelectFenYe(Expression<Func<salary_standard, int>> order, Expression<Func<salary_standard, bool>> where, out int rows, int currentPage, int pageSize);
        List<salary_standard> selectWhere(Expression<Func<salary_standard, bool>> where);  //通用where条件查询
     int  AUD(string sql);//删除
        int Update(salary_standard t);//修改
        List<salary_standard> SelectBy(string sql, out int rows, int IndexPage, int PageSize);
    }
}
