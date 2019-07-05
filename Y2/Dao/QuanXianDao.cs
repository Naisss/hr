using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using System.Data;
using System.Data.SqlClient;
using Entity;
using System.Linq.Expressions;

namespace Dao
{
    public class QuanXianDao : DaoBase<users>, IQuanxianDao
    {
        public Dictionary<string, object> FYslect(string cp, string where)
        {
            SqlParameter[] ps =
            {
            new SqlParameter(){ParameterName="@pageSize",Value=2},
            new  SqlParameter(){ParameterName="@keyName",Value="u_id"},
            new SqlParameter(){ParameterName="@tableName",Value="Yonghu"},
            new SqlParameter(){ParameterName="@where",Value=where},
            new SqlParameter(){ParameterName="@currentPage",Value=cp},
            new SqlParameter(){ ParameterName="@rows",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output},
            new SqlParameter(){ ParameterName="@pages",SqlDbType= System.Data.SqlDbType.Int,Direction= System.Data.ParameterDirection.Output}
            };
            DataTable dt = DBhelper.SelectProc(ps, "WebService1");
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = dt;
            di["rows"] = ps[5].Value;
            di["pages"] = ps[6].Value;
            return di;
        }
    }
}
