using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Entity;
using System.Linq.Expressions;
namespace Dao
{
    public class LoginDao:ILoginDao
    {
        public object login(string name, string pwd)
        {
            string sql = string.Format("select count(*) from users where u_name='{0}' and u_password='{1}'", name, pwd);
            object num = DBhelper.SelectSinger(sql, "");
            return num;
        }
        public object u_roleidSelect(string name, string pwd)
        {
            string sql = string.Format("select u_roleid from users where u_name='{0}' and u_password='{1}'", name, pwd);
            object u_roleid = DBhelper.SelectSinger(sql, "");
            return u_roleid;
        }
    }
}
