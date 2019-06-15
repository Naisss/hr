using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    public interface TSelectUpdateDelete<T> where T : class
    {

        List<T> SelectAll();
        List<T> selectWhere(Expression<Func<T, bool>> where);
        List<T> FenYe<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, int currentPage, int pageSize);
        int Insert(T t);
        int Update(T t);
        int Del(T t);
        int AUD(string sql);
        List<T> SelectBanJi();
    }
}
