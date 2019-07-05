using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ImajorBLL
    {
        List<config_major> Select();

        List<config_major> SelectWhere(Expression<Func<config_major, bool>> where);
    }
}
