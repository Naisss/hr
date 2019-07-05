using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IDao
{
     public interface Ihuman_fileDao<T> where T:class
    {
        List<T> selectWhere(Expression<Func<T, bool>> where);
    }
}
