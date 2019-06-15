using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    public interface Isecond_kindDao<T>:TSelectUpdateDelete<T>where T:class
    {
    }
}
