using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Entity;
using System.Linq.Expressions;
using System.Data.SqlClient;

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
        public users Getuser(string name, string pwd)
        {
            string sql = string.Format("select * from users where u_name='{0}' and u_password='{1}'", name, pwd);
            SqlDataReader reader = DBhelper.SelectReader(sql,"ss");
            users u=null;
            if (reader.Read()) {

                u = new users()
                {
                    u_id = short.Parse(reader["u_id"].ToString()),
                    u_password = reader["u_password"].ToString(),
                    u_name = reader["u_name"].ToString(),
                    u_roleid = Convert.ToInt32(reader["u_roleid"]),
                    u_true_name= reader["u_true_name"].ToString()
                };
                
            }
            return u;
        }
    }
}
