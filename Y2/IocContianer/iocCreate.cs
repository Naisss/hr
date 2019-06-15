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
        //发布登记
        public static Imajor_releaseDao<engage_major_release> text01Dao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Imajor_releaseDao<engage_major_release>, major_releaseDao>();
            return ioc.Resolve<Imajor_releaseDao<engage_major_release>>();
        }
        //第二阶段
        public static Isecond_kindDao<config_file_second_kind> second_kindDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Isecond_kindDao<config_file_second_kind>, second_kindDao>();
            return ioc.Resolve<Isecond_kindDao<config_file_second_kind>>();
        }

        //第三阶段
        public static Ithird_kindDao<config_file_third_kind> third_kindDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ithird_kindDao<config_file_third_kind>, third_kindDao>();
            return ioc.Resolve<Ithird_kindDao<config_file_third_kind>>();
        }

        //职位分类
        public static Imajor_kindDao<config_major_kind> major_kindDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Imajor_kindDao<config_major_kind>, major_kindDao>();
            return ioc.Resolve<Imajor_kindDao<config_major_kind>>();
        }
        //职位名称    
        public static ImajorDao<config_major> majorDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<ImajorDao<config_major>, majorDao>();
            return ioc.Resolve<ImajorDao<config_major>>();
        }



        //登录
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

        public static Ifirst_kindDao text01Dao1()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ifirst_kindDao, first_kindDao>();
            return ioc.Resolve<Ifirst_kindDao>();

        }




    }
}


