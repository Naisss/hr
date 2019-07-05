using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    public interface  Iengage_resumeDao<T>:TSelectUpdateDelete<T> where T:class
    {
    }
}
