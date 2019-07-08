using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using Entity;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.Entity;
namespace Dao
{
    public   class DaoBase<T> where T : class
    {

        HREntities st = new HREntities();
        private static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=HR;Integrated Security=True");
            return cn;
        }
        public static HREntities CreateDBContent()
        {
            HREntities at = CallContext.GetData("s") as HREntities;
            if (at == null)
            {
                at = new HREntities();
                CallContext.SetData("s", at);
            }
            return at;
        }
        //通用查询全部
        public List<T> SelectAll()
        {
            return st.Set<T>().Select(e => e).AsNoTracking().ToList();
        }
        //通用where条件查询
        public List<T> selectWhere(Expression<Func<T, bool>> where)
        {
            return st.Set<T>().Where(where).Select(e => e).AsNoTracking().ToList();
        }
        //通用分页查询
        public List<T> FenYe<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, int currentPage, int pageSize)
        {
            var data = st.Set<T>().OrderBy(order).Where(where);
            rows = data.Count();
            return data.Skip((currentPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        //通用新增
        public int Insert(T t)
        {
            st.Entry<T>(t).State = System.Data.Entity.EntityState.Added;
            try
            {
                return st.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        //通用修改
        public int Update(T t)
        {
            st.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            try
            {
                return st.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        //通用删除
        public int Del(T t)
        {
            st.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            return st.SaveChanges();
        }
        //通用写sql
        public int AUD(string sql)
        {
            return st.Database.ExecuteSqlCommand(sql);
        }
        //班级下拉
        public List<T> SelectBanJi()
        {
            return st.Set<T>().Select(e => e).ToList();
        }
        public static DataTable danhao(SqlParameter[] ps, string fileName)
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
        public static DataTable danhao1(SqlParameter[] ps, string fileName)
        {
            SqlConnection cn = GetConnection();
            string sql = "Danhao1";
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
        public string GUID() {
            SqlParameter[] ps ={
                        new SqlParameter(){ParameterName="@n1",SqlDbType=System.Data.SqlDbType.Char,Direction=System.Data.ParameterDirection.Output,Size=14}
                        };
            DataTable DD = danhao(ps,"");
            String id = ps[0].Value.ToString();
            return id;


        }
        public string GUID1()
        {
            SqlParameter[] ps ={
                        new SqlParameter(){ParameterName="@n1",SqlDbType=System.Data.SqlDbType.Char,Direction=System.Data.ParameterDirection.Output,Size=14}
                        };
            DataTable DD = danhao1(ps, "");
            String id = ps[0].Value.ToString();
            return id;


        }
    }
}
