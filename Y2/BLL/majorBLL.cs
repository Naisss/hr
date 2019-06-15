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
    public  class majorBLL:ImajorBLL
    {
        ImajorDao<config_major> idm = iocCreate.majorDao();
        public List<config_major> Select() {

            return idm.SelectAll();
        }
    }
}
