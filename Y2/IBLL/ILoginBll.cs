using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface ILoginBll
    {
        object login(string name, string pwd);//登录
        object u_roleidSelect(string name, string pwd);
    }
}
