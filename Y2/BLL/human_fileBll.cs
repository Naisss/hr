using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using IBLL;
using IocContianer;
using Entity;
using System.Linq.Expressions;
namespace BLL
{
    public class human_fileBLL: Ihuman_fileBll
    {
        Ihuman_fileDao ihf = iocCreate.human_fileDao();

        public List<human_file> Select() {
            return ihf.SelectAll();
        }

        public List<human_file> SelectWhere(Expression<Func<human_file,bool>> where)
        {
            return ihf.selectWhere(where);
        }
        public int Insert(human_file h) {
            return ihf.Insert(h);
        }

        public List<human_file> SelectFenYe(Expression<Func<human_file,int>> order,Expression<Func<human_file,bool>> where,out int rows,int currentPage,int pageSize) {
            return ihf.FenYe(order,where,out rows,currentPage,pageSize);
        }


        public int Update(human_file hf) {
            return ihf.Update(hf);
        }

        public int Del(human_file hf)
        {
            return ihf.Del(hf);
        }
    }
}
