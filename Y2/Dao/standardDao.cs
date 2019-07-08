using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDao;
namespace Dao
{
  public  class standardDao:DaoBase<salary_standard>,IstandardDao<salary_standard>
    {

        public List<salary_standard> SelectBy(string sql, out int rows, int IndexPage, int PageSize)
        {
            HREntities aet = CreateDBContent();
            var ii = aet.salary_standard.SqlQuery(sql).ToList();
            rows = ii.Count();
            return ii.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();

        }
    }
}
