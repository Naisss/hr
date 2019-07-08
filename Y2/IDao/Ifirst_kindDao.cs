using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IDao
{
   public interface Ifirst_kindDao<T> : TSelectUpdateDelete<T> where T : class
    {
     
    }
}
