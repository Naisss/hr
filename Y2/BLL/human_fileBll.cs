using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDao;
using IocContianer;
using System.Linq.Expressions;

namespace BLL
{
        public class human_fileBll:Ihuman_fileBll
        {
        Ihuman_fileDao<human_file> hf = iocCreate.CreateIhuman_fileDao();
        public  List<human_file> selectWhere(Expression<Func<human_file, bool>> where)
        {
            return hf.selectWhere(where);
        }
    }
}
