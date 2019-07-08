using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDao;
namespace Dao
{
    public class first_kindDao : DaoBase<config_file_first_kind>, Ifirst_kindDao<config_file_first_kind>
    {
        public List<T> SqlBy<T>(string sql, out int rows, int IndexPage, int PageSize) where T : class
        {
            HREntities ef;
            ef = CreateDBContent();
            var a = ef.Database.SqlQuery<T>(sql);
            rows = a.Count();
            return a.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
