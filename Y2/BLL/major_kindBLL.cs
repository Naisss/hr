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
    public class major_kindBLL:Imajor_kindBLL
    {
        Imajor_kindDao<config_major_kind> imd = iocCreate.major_kindDao();

        public int Del(config_major_kind t)
        {
            return imd.Del(t);
        }

        public int Insert(config_major_kind t)
        {
            return imd.Insert(t);
        }

        public List<config_major_kind> Select() {
            return imd.SelectAll();
        }

        public List<config_major_kind> selectWhere(Expression<Func<config_major_kind, bool>> where)
        {
            return imd.selectWhere(where);
        }
    }
}
