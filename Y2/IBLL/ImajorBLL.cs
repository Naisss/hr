using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IBLL
{
    public interface ImajorBLL
    {
        List<config_major> Select();
        int Del(config_major t);//删除
        int Insert(config_major t);//新增
        List<config_major> selectWhere(Expression<Func<config_major, bool>> where);  //通用where条件查询

        List<config_major> SelectWhere(Expression<Func<config_major, bool>> where);
    }
}
