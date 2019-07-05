using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;
namespace IBLL
{
    public interface Isalary_standard_detailsBLL
    {

        List<salary_standard_details> Select();
        List<salary_standard_details> SelectWhere(Expression<Func<salary_standard_details, bool>> where);
    }
}
