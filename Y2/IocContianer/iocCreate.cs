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

        public static ILoginDao<users> CreateLoginDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<ILoginDao<users>, LoginDao>();
            return ioc.Resolve<ILoginDao<users>>();
        }
          
        public static T CreateTextBll<T>(string bl)
    {
    public class iocCreate { 
    // {  
    public static Ifirst_kindDao text01Dao()
    {

        UnityContainer ioc = new UnityContainer();
        ioc.RegisterType<Ifirst_kindDao, first_kindDao>();
        return ioc.Resolve<Ifirst_kindDao>();

    }

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


