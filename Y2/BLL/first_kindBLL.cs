using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Dao;
using IDao;
using IBLL;
using Entity;
using IocContianer;
namespace BLL
{
    public class first_kindBLL : Ifirst_kindBLL
    {
        Ifirst_kindDao dao = iocCreate.text01Dao();
        public List<config_file_first_kind> SelectAll()
        {
            return dao.SelectAll();
        }
    }
}
