using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
 public   interface I_fileBLL
    {
        List<human_file> selectWhere(Expression<Func<human_file, bool>> where);  //通用where条件查询
        int AUD(string sql);
        string GUID1();//单号
        List<human_file> Select();
    }
}
