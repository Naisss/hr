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
    //public class third_kindBLL:Ithird_kindBLL
    //{
    //    Ithird_kindDao<config_file_third_kind> i = iocCreate.third_kindDao();

        public List<config_file_third_kind> Select() {
            return i.SelectAll();
        }
      
        public List<config_file_third_kind> SelectWhere(Expression<Func<config_file_third_kind, bool>> where) {
            return i.selectWhere(where);
        }

    }
}
