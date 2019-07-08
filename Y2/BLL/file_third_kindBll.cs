using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IocContianer;
using IDao;
using Entity;
namespace BLL
{
    public class file_third_kindBll:Ifile_third_Bll
    {
        Ifile_third_kindDao<config_file_third_kind> ifd = iocCreate.third_kindDao();
        public List<config_file_third_kind> SelectAll()
        {
            return ifd.SelectAll();
        }
    }
}
