using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IDao
{
    public  interface IQuanxianDao
    {
        Dictionary<string, object> FYslect(string cp, string where);//查询用户视图
        int Insert(users   u);
        List<users> selectWhere(Expression<Func<users, bool>> where);//查询用户
    }
}
