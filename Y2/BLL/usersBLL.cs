using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using IBLL;
using IocContianer;
using Entity;
namespace BLL
{
   public  class usersBLL:IusersBLL
    {
        IusersDao ud = iocCreate.usersDao();

        public List<users> Select() {
            return ud.SelectAll();
        }
    }
}
