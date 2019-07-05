using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using IocContianer;
using IBLL;
using Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class second_kindBLL:Isecond_kindBLL
    {
        Isecond_kindDao<config_file_second_kind> s = iocCreate.second_kindDao();

        //二级阶段
        public List<config_file_second_kind> Select() {
            return s.SelectAll();
        }

        public List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where) {
            return s.selectWhere(where);
        }
    }
}
