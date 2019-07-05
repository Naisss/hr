using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDao;
using IocContianer;
using Entity;
using System.Linq.Expressions;
namespace BLL
{
    public class major_changeBll : Imajor_changeBll
    {
        Imajor_changeDao<major_change> ic = iocCreate.CreateImajor_changeDao();
        public List<major_change> selectWhere(Expression<Func<major_change, bool>> where)
        {
            return ic.selectWhere(where);
        }
        public List<major_change> SelectAll()
        {
            return ic.SelectAll();
        }
        public List<major_change> FenYe<K>(Expression<Func<major_change,int>> order, Expression<Func<major_change, bool>> where, out int rows, int currentPage, int pageSize)
        {
            return ic.FenYe<int>(order, where, out rows, currentPage, pageSize);
        }
        public int Update(major_change mc)
        {
            return ic.Update(mc);
        }
        public   int Insert(major_change mc)
        {
            return ic.Insert(mc);
        }
    }
}
