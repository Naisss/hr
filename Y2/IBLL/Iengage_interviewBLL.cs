using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Iengage_interviewBLL
    {
        List<engage_interview> Select();

        List<engage_interview> SelectWhere(Expression<Func<engage_interview, bool>> where);
        int Insert(engage_interview en);
        int Update(engage_interview en);
        List<engage_interview> SelectFenYe(Expression<Func<engage_interview, int>> order, Expression<Func<engage_interview, bool>> where, out int rows, int currentPage, int pageSize);

        int Del(engage_interview en);
    }
}
