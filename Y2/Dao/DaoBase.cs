using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using Entity;
namespace Dao
{
    public   class DaoBase<T> where T : class
    {

        HREntities st = new HREntities();
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
            return st.Set<T>().Select(e => e).ToList();
        }
        //通用where条件查询
        public List<T> selectWhere(Expression<Func<T, bool>> where)
        {
            return st.Set<T>().Where(where).Select(e => e).ToList();
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
            return st.SaveChanges();
        }
        //通用修改
        public int Update(T t)
        {
            st.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            return st.SaveChanges();
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
    }
}
