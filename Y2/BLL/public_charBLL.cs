using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using IDao;
using IBLL;
using Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class public_charBLL:Ipublic_charBLL
    {

        Ipublic_charDao<config_public_char> ipd = iocCreate.public_charDao();

        public List<config_public_char> SelectWhere(Expression<Func<config_public_char, bool>> where) {
            return ipd.selectWhere(where) ;
        }
    }
}
