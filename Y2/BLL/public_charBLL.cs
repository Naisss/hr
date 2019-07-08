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
    public class public_charBLL : Ipublic_charBLL
    {
        Ipublic_charDao<config_public_char> ioc = iocCreate.public_charDao();
        //Ipublic_charDao<config_major_kind> imd = iocCreate.();
        public int Del(config_public_char t)
        {
            return ioc.Del(t);
        }

        public int Insert(config_public_char t)
        {
            return ioc.Insert(t);
        }

        public List<config_public_char> Select()
        {
            return ioc.SelectAll();
        }

        public List<config_public_char> selectWhere(Expression<Func<config_public_char, bool>> where)
        {
            return ioc.selectWhere(where);
        }
    }
}
