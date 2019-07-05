using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Isecond_kindBLL
    {
        List<config_file_second_kind> Select();

        List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where);
    }
}
