using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IBLL
{
    public interface Isecond_kindBLL
    {
        List<config_file_second_kind> Select();

        //List<config_file_first_kind> SelectXL();

        int Insert(config_file_second_kind t);//新增
        int Del(config_file_second_kind t);//删除
        List<config_file_second_kind> selectWhere(Expression<Func<config_file_second_kind, bool>> where);  //通用where条件查询
        int Update(config_file_second_kind t);//修改
    }
}
