using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Ipublic_charBLL
    {

        List<config_public_char> SelectWhere(Expression<Func<config_public_char, bool>> where);
    }
}
