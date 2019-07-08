﻿using System;
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


    public class iocCreate
    {

        public static Igrant_detailsDao<salary_grant_details> grant_details()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Igrant_detailsDao<salary_grant_details>, grant_detailsDao>();
            return ioc.Resolve<Igrant_detailsDao<salary_grant_details>>();
        }
        public static I_fileDao<human_file> _file()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<I_fileDao<human_file>, _fileDao>();
            return ioc.Resolve<I_fileDao<human_file>>();
        }

        // 薪酬发放登记表       
        public static Isalary_grantDao<salary_grant> _grant()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Isalary_grantDao<salary_grant>, salary_grantDao>();
            return ioc.Resolve<Isalary_grantDao<salary_grant>>();
        }
        //薪酬标准登记
        public static IstandardDao<salary_standard> standardioc()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<IstandardDao<salary_standard>, standardDao>();
            return ioc.Resolve<IstandardDao<salary_standard>>();
        }
        //: 薪酬标准单详细信息   
        public static Istandard_detailsDao<salary_standard_details> standard_detailsioc()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Istandard_detailsDao<salary_standard_details>, standard_detailsDao>();
            return ioc.Resolve<Istandard_detailsDao<salary_standard_details>>();
        }
        //公共属性设置
        public static Ipublic_charDao<config_public_char> public_charDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ipublic_charDao<config_public_char>, public_charDao>();
            return ioc.Resolve<Ipublic_charDao<config_public_char>>();
        }

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
        public static Ifile_third_kindDao<config_file_third_kind> third_kindDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ifile_third_kindDao<config_file_third_kind>, file_third_kindDao>();
            return ioc.Resolve<Ifile_third_kindDao<config_file_third_kind>>();
        }

        //第三阶段2
        public static Ithird_kindDao third_kindDao2()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ithird_kindDao, third_kindDao>();
            return ioc.Resolve<Ithird_kindDao>();
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
       
        //第一阶段
        public static Ifirst_kindDao text01Dao1()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ifirst_kindDao, first_kindDao>();
            return ioc.Resolve<Ifirst_kindDao>();

        }

        //公共属性
        public static Ipublic_charDao<config_public_char> public_charDao() {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ipublic_charDao<config_public_char>, public_charDao>();
            return ioc.Resolve<Ipublic_charDao<config_public_char>>();

        }


        //简历登记
        public static Iengage_resumeDao<engage_resume> engage_resumeDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Iengage_resumeDao<engage_resume>, engage_resumeDao>();
            return ioc.Resolve<Iengage_resumeDao<engage_resume>>();

        }


        //面试登记
        public static Iengage_interviewDao engage_interviewDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Iengage_interviewDao, engage_interviewDao>();
            return ioc.Resolve<Iengage_interviewDao>();

        }

        //人力资源档案
        public static Ihuman_fileDao human_fileDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ihuman_fileDao, human_fileDao>();
            return ioc.Resolve<Ihuman_fileDao>();

        }



        //薪酬标准详细
        public static Isalary_standard_detailsDao salary_standard_detailsDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Isalary_standard_detailsDao, salary_standard_detailsDao>();
            return ioc.Resolve<Isalary_standard_detailsDao>();

        }

        //用户标椎
        public static IusersDao usersDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<IusersDao, usersDao>();
            return ioc.Resolve<IusersDao>();

        }
        //薪酬标准基本
        public static Isalary_standardDao salary_standardDao()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Isalary_standardDao, salary_standardDao>();
            return ioc.Resolve<Isalary_standardDao>();

        }


        public static Imajor_changeDao<major_change> CreateImajor_changeDao()
        {
            IUnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Imajor_changeDao<major_change>, major_changeDao>();
            return ioc.Resolve<Imajor_changeDao<major_change>>();
        }
        public static IQuanxianDao CreateQuanXianDao()
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<IQuanxianDao, QuanXianDao>();
            return ioc.Resolve<IQuanxianDao>();
        }

        //bll通用
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

        public static Ifirst_kindDao<config_file_first_kind> text01Dao1()
        {

            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<Ifirst_kindDao<config_file_first_kind>, first_kindDao>();
            return ioc.Resolve<Ifirst_kindDao< config_file_first_kind >> ();

        }





    }
}


