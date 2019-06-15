using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IDao
{
   public interface Ifirst_kindDao
    {
        List<config_file_first_kind> SelectAll();//查询全部

        int Insert(config_file_first_kind t);//新增

        int Del(config_file_first_kind t);//删除

        List<config_file_first_kind> selectWhere(Expression<Func<config_file_first_kind, bool>> where);  //通用where条件查询

        int Update(config_file_first_kind t);//修改

    }
}
