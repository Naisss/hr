using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Imajor_releaseBLL
    {
        int Add(engage_major_release ms);
        List<engage_major_release> SelectFenYe(Expression<Func<engage_major_release, int>> order, Expression<Func<engage_major_release, bool>> where, out int rows, int currentPage, int pageSize);

        List<engage_major_release> SelectWhere(Expression<Func<engage_major_release, bool>> where);

        int Update(engage_major_release emr);

        int Del(engage_major_release mr);

    }
 }
