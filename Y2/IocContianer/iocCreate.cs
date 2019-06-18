using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using IDao;
using Entity;
using IBLL;
using Dao;

namespace IocContianer
{
    
       
    public class iocCreate 
    {
        public static Imajor_releaseDao<engage_major_release> text01Dao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Imajor_releaseDao<engage_major_release>,major_releaseDao>();
            return ioc.Resolve<Imajor_releaseDao<engage_major_release>>();
           

        }

        public static ILoginDao CreateLoginDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<ILoginDao, LoginDao>();
            return ioc.Resolve<ILoginDao>();
        }
      

        public static T CreateTextBll<T>(string bl)
    {

        UnityContainer ioc = new UnityContainer();
        ExeConfigurationFileMap ef = new ExeConfigurationFileMap();
      

        ef.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "Unity.config";

        Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);

        UnityConfigurationSection uc = (UnityConfigurationSection)cf.GetSection("unity");

        ioc.LoadConfiguration(uc, "containerTow");
                return ioc.Resolve<T>(bl);

            }
    }
    }


