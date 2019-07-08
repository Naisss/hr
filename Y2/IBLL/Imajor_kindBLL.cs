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
    public interface Imajor_kindBLL
    {
        List<config_major_kind> Select();
        int Del(config_major_kind t);//删除
        int Insert(config_major_kind t);//新增

        List<config_major_kind> selectWhere(Expression<Func<config_major_kind, bool>> where);  //通用where条件查询
        List<config_major_kind> SelectWhere(Expression<Func<config_major_kind, bool>> where);
    }
}
