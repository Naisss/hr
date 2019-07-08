using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace IBLL
{
    public interface Ipublic_charBLL
    {
        List<config_public_char> Select();
        int Insert(config_public_char t);//新增
        int Del(config_public_char t);//删除

        List<config_public_char> selectWhere(Expression<Func<config_public_char, bool>> where);  //通用where条件查询

        List<config_public_char> SelectWhere(Expression<Func<config_public_char, bool>> where);
    }
}
