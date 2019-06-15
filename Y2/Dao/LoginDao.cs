using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Entity;
namespace Dao
{
      public  class LoginDao: DaoBase<users>,ILoginDao<users>
    {
       public object login(string name, string pwd)
        {
            string sql = string.Format("select count(*) from users where u_name='{0}' and u_password='{1}'", name, pwd);
            object num = DBhelper.SelectSinger(sql,"");
            return num;
        }
    }
}
