using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDao;
namespace Dao
{
  public  class salary_grantDao: DaoBase<salary_grant>, Isalary_grantDao<salary_grant>
    {
    }
}
