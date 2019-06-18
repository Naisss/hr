using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDao;
using IocContianer;
namespace BLL
{
    public class LoginBll:ILoginBll
    {
        ILoginDao id = iocCreate.CreateLoginDao();
        public object login(string name, string pwd)
        {
            return id.login(name,pwd);
        }
        public object u_roleidSelect(string name, string pwd)
        {
            return id.login(name, pwd);
        }
    }
}
