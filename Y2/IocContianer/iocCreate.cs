using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Dao;
using Entity;
using IDao;
using IBLL;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace IocContianer
{
    public class iocCreate { 
    // {  
    public static Ifirst_kindDao text01Dao()
    {

        UnityContainer ioc = new UnityContainer();
        ioc.RegisterType<Ifirst_kindDao, first_kindDao>();
        return ioc.Resolve<Ifirst_kindDao>();

    }

    public static T CreateTextBll<T> (string bl) 
    {

        UnityContainer ioc = new UnityContainer();
        ExeConfigurationFileMap ef = new ExeConfigurationFileMap();

        ef.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "Unity.config";

        Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);

        UnityConfigurationSection uc = (UnityConfigurationSection)cf.GetSection("unity");

        ioc.LoadConfiguration(uc, "containerTow");

        return ioc.Resolve<T>(bl);
        //ioc.RegisterType<IBookBLL,>
    }
        // }
    }
}
