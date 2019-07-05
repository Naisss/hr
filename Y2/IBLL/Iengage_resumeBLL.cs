using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Iengage_resumeBLL
    {
        int Insert(engage_resume er);

        List<engage_resume> Select();

        List<engage_resume> SelectWhere(Expression<Func<engage_resume, bool>> where);
        List<engage_resume> SelectFenye(Expression<Func<engage_resume, int>> order, Expression<Func<engage_resume, bool>> where, out int rows, int currentPage, int pageSize);


        int Update(engage_resume er);
        int Del(engage_resume er);
    }
}
