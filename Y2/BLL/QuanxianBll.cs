using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using IBLL;
using IDao;
using Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class QuanxianBll : IQuanxianBll
    {
        IQuanxianDao id = iocCreate.CreateQuanXianDao();
        public Dictionary<string, object> FYslect(string cp, string where)
        {
            return id.FYslect(cp, where);
        }
        public int Insert(users u)
        {
            return id.Insert(u);
        }
        public List<users> selectWhere(Expression<Func<users, bool>> where)
        {
            return id.selectWhere(where);
        }
    }
}
