using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Entity;
namespace IDao
{
     public  interface Imajor_changeDao<T> where T:class
    {
        List<T> selectWhere(Expression<Func<T, bool>> where);
        List<T> SelectAll();//查询
        List<T> FenYe<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, int currentPage, int pageSize);//分页查询
        int Update(T t);//修改
        int Insert(T t);//添加
    }
}
