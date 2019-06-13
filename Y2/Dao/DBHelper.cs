using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
   public  class DBHelper
    {
        private static SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Test;Persist Security Info=True;User ID=sa;Password=root");
            return con;
        }
        public static DataTable Select(string sql,string dname,params DbParameter[] ps)
        {
            SqlConnection con = GetCon();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            if (ps!=null) {
                da.SelectCommand.Parameters.AddRange(ps);

            }
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt,dname);
            }
            catch (Exception ex)
            {
                xError( ex);
                // throw;
            }
            return dt.Tables[0];
        


        }

        public static int InsertUpdateDel(string sql,params DbParameter[] ps) {
            SqlConnection con = GetCon();
            SqlCommand com = new SqlCommand(sql,con);
            if (ps!=null) {

                com.Parameters.AddRange(ps);
            }
            int i = 0;
            try
            {
                con.Open();
                i = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                xError( ex);
                //throw;
            }
            finally {


                con.Close();
            }
            return i;

        }


        public static object SelectSinger(string sql, params DbParameter[] ps) {
            SqlConnection con = GetCon();
            SqlCommand com = new SqlCommand(sql, con);
            if (ps != null)
            {

                com.Parameters.AddRange(ps);
            }
            object obj = null;
            try
            {
              con.Open();
                obj = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                xError( ex);
                //throw;
            }
            finally
            {

          con.Close();
            }
            return obj;


        }


        public static SqlDataReader SelectReader(string sql, params DbParameter[] ps) {
            SqlConnection con = GetCon();
            SqlCommand com = new SqlCommand(sql,con);
            if(ps!=null){
                com.Parameters.AddRange(ps);
            }
            SqlDataReader reader = null;
            try
            {
                con.Open();
                reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                xError( ex);
                //throw;
            }
            return reader;
        }

        public static DataTable SelectCunCu(string sql,params DbParameter[] ps) {
            SqlConnection con = GetCon();
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            if (ps!=null) {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(ps);
            }
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                xError(ex);
                //throw;
            }
            return dt;
        }


        public static void xError(Exception ex) {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+ "/Error.txt",true)) {

                sw.WriteLine("错误信息：" + ex.Message);
                sw.WriteLine("错误时间:" + DateTime.Now); 
                sw.WriteLine("----------------------------");

            }

        }
    }
}
