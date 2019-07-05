using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Ithird_kindBLL
    {
        List<config_file_third_kind> Select();
        List<config_file_third_kind> SelectWhere(Expression<Func<config_file_third_kind, bool>> where);
    }
}
