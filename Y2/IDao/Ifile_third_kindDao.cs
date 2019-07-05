using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IDao
{
    public  interface Ifile_third_kindDao<T>  where T:class
    {
        List<T> SelectAll();
    }
}
