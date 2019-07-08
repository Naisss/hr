using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using IDao;
using IBLL;
using Entity;
using System.Linq.Expressions;
namespace BLL
{
 public   class _fileBLL:I_fileBLL
    {
        I_fileDao<human_file> ioc = iocCreate._file();

        public int AUD(string sql)
        {
            return ioc.AUD(sql);
        }

        public string GUID1()
        {
        return ioc.GUID1();
        }

        public List<human_file> Select()
        {
            return ioc.SelectAll();
        }

        public List<human_file> selectWhere(Expression<Func<human_file, bool>> where)
        {
            return ioc.selectWhere(where);
        }
    }
}
