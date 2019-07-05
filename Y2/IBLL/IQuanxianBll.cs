using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IQuanxianBll
    {
        Dictionary<string, object> FYslect(string cp, string where);
        int Insert(users u);
        List<users> selectWhere(Expression<Func<users, bool>> where);//查询用户
    }
}
