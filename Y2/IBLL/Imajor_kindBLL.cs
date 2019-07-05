using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Imajor_kindBLL
    {
        List<config_major_kind> Select();
        List<config_major_kind> SelectWhere(Expression<Func<config_major_kind, bool>> where);
    }
}
