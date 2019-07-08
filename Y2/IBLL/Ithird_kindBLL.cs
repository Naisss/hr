using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IBLL
{
    public interface Ithird_kindBLL
    {
        List<config_file_third_kind> Select();
        int Insert(config_file_third_kind t);//新增
        int Del(config_file_third_kind t);//删除
        List<config_file_third_kind> selectWhere(Expression<Func<config_file_third_kind, bool>> where);  //通用where条件查询
        int Update(config_file_third_kind t);//修改
    }
}
