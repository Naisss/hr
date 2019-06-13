using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;
using Dao;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace IocCreate
{
   public  class iocCreate
    {

        //public static Itext01Dao<text01>  text01Dao()    {

        //    UnityContainer ioc = new UnityContainer();
        //    ioc.RegisterType<Itext01Dao<text01>, text01Dao>();
        //    return ioc.Resolve<Itext01Dao<text01>>();

        //}
       
       // public static Itext01BLL CreateTextBll()
        //{
            
        //    UnityContainer ioc = new UnityContainer();
        //    ExeConfigurationFileMap ef = new ExeConfigurationFileMap();

        //    ef.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory+"Unity.config";

        //    Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);

        //    UnityConfigurationSection uc = (UnityConfigurationSection)cf.GetSection("unity");

        //    ioc.LoadConfiguration(uc, "containerTow");

        //    return ioc.Resolve<Itext01BLL>("text01BLL");
        //    //ioc.RegisterType<IBookBLL,>
        //}
    }
}
