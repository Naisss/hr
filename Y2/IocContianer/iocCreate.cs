using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Dao;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Entity;
using IDao;
using  IBLL;
namespace IocContianer
{
    public class iocCreate
    {
        public static ILoginDao CreateLoginDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<ILoginDao, LoginDao>();
            return ioc.Resolve<ILoginDao>();

        }

        public static T CreateLoginBll<T>(string namew) 
        {

            UnityContainer ioc = new UnityContainer();

            ExeConfigurationFileMap ef = new ExeConfigurationFileMap();

            ef.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "Unity.config";

            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);

            UnityConfigurationSection uc = (UnityConfigurationSection)cf.GetSection("unity");

            ioc.LoadConfiguration(uc, "containerTow");

            return ioc.Resolve<T>(namew);
        }
    }
}
