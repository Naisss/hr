using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public    interface Ihuman_fileBll
    {
        List<human_file> selectWhere(Expression<Func<human_file, bool>> where);
    }
}
