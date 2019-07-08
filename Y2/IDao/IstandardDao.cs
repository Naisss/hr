using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace IDao
{
  public  interface IstandardDao<T> : TSelectUpdateDelete<T> where T : class
    {
        string GUID();
        List<salary_standard> SelectBy(string sql, out int rows, int IndexPage, int PageSize);
    }
}
