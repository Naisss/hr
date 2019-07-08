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
        Ifirst_kindDao<config_file_first_kind> dao = iocCreate.text01Dao1();

        public int Del(config_file_first_kind t)
        {
            return dao.Del(t);
        }

        public int Insert(config_file_first_kind t)
        {
            return dao.Insert(t);
        }

        public List<config_file_first_kind> SelectAll()
        {
            return dao.SelectAll();
        }

        public List<config_file_first_kind> SelectFenYe(Expression<Func<config_file_first_kind, int>> order, Expression<Func<config_file_first_kind, bool>> where, out int rows, int currentPage, int pageSize)
        {
           return dao.FenYe(order, where, out rows, currentPage, pageSize);
        }

        public List<config_file_first_kind> selectWhere(Expression<Func<config_file_first_kind, bool>> where)
        {
            return dao.selectWhere(where);
        }

        public int Update(config_file_first_kind t)
        {
            return dao.Update(t);
        }
    }
}
