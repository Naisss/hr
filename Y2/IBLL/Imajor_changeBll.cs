using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
     public interface Imajor_changeBll
    {
        List<major_change> selectWhere(Expression<Func<major_change, bool>> where);
        //List<major_change> SelectAll();
        List<major_change> FenYe<K>(Expression<Func<major_change,int>> order, Expression<Func<major_change, bool>> where, out int rows, int currentPage, int pageSize);

        int Update(major_change mc);//修改

        int Insert(major_change mc);//添加
    }
}
