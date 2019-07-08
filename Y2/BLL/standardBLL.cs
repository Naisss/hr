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
    public class standardBLL : IstandardBLL
    {
        IstandardDao<salary_standard> i = iocCreate.standardioc();

        public int AUD(string sql)
        {
            return i.AUD(sql);
        }

        public string GUID()
        {
            return i.GUID();
        }

        public int Insert(salary_standard t)
        {
            return i.Insert(t);
        }

        public List<salary_standard> SelectBy(string sql, out int rows, int IndexPage, int PageSize)
        {
            return i.SelectBy(sql, out rows, IndexPage, PageSize);
        }

        public List<salary_standard>  SelectFenYe(Expression<Func<salary_standard, int>> order, Expression<Func<salary_standard, bool>> where, out int rows, int currentPage, int pageSize)
        {
            return i.FenYe(order, where, out rows, currentPage, pageSize);

        }

        public List<salary_standard> selectWhere(Expression<Func<salary_standard, bool>> where)
        {
            return i.selectWhere(where);
        }

        public int Update(salary_standard t)
        {
            return i.Update(t);
        }

       
    }
}
