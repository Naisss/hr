using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Isalary_standardBLL
    {
        List<salary_standard> Select();
        List<salary_standard> SelectWhere(Expression<Func<salary_standard, bool>> where);
    }
}
