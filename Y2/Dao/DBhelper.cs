using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public  class DBhelper
    {
        public static DataTable Select(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            if (ps != null)
            {
                ad.SelectCommand.Parameters.AddRange(ps);
            }
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);
            }
            return dt;
        }

        private static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=HR;Integrated Security=True");
            return cn;
        }

        public static int InsertUpdateDelte(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            int result = 0;
            try
            {
                cn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        public static object SelectSinger(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            object obj = null;
            try
            {
                cn.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);

            }
            finally
            {
                cn.Close();
            }
            return obj;
        }

        public static SqlDataReader SelectReader(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);

            }
            return reader;
        }

        private static void WRZ(string fileName, Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("错误日志.txt", true))
            {
                sw.WriteLine("错误信息：" + ex.Message);
                sw.WriteLine("错误时间:" + DateTime.Now);
                sw.WriteLine("报错窗体名:" + fileName);
                sw.WriteLine("----------------------------");
            }
        }

        public static DataTable SelectProc(SqlParameter[] ps, string fileName)
        {
            SqlConnection cn = GetConnection();
            string sql = "YonghuFY";
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            //执行的是存储过程
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            //命令对象添加参数对象
            ad.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);
            }
            return dt;
        }

        public static DataTable danhao(SqlParameter[] ps,string fileName)
        {
            SqlConnection cn = GetConnection();
            string sql = "Danhao";
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                WRZ(fileName, ex);
            }
            return dt;
        }
    }
}
