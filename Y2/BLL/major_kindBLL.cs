using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContianer;
using IDao;
using IBLL;
using Entity;
namespace BLL
{
    public class major_kindBLL:Imajor_kindBLL
    {
        Imajor_kindDao<config_major_kind> imd = iocCreate.major_kindDao();
        public List<config_major_kind> Select() {
            return imd.SelectAll();
        }
    }
}
