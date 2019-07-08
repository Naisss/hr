using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IDao
{
  public  interface I_fileDao<T> : TSelectUpdateDelete<T> where T : class
    {
        string GUID1();
    }
}
