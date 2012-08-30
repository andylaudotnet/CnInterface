using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CnDataAcess.IList;

namespace CnDataAcess
{
    public class ObjectCreate
    {
        private static readonly string AssemblyName = "CnDataAcess";
        private static readonly string DBName = System.Configuration.ConfigurationSettings.AppSettings["DBName"].ToString();

        /// <summary>
        /// 接口信息接口反射
        /// </summary>
        /// <returns>接口信息子对象</returns>
        public static ICnInterfaceInfo CreateInterfaceInfo()
        {
            string className = AssemblyName + "." + DBName + "." + "InterfaceInfo";
            return (ICnInterfaceInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        /// <summary>
        /// 接口类型接口反射
        /// </summary>
        /// <returns>接口类型子对象</returns>
        public static ICnInterfaceType CreateInterfaceType()
        {
            string className = AssemblyName + "." + DBName + "." + "InterfaceType";
            return (ICnInterfaceType)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        /// <summary>
        /// 视频Xpath接口反射
        /// </summary>
        /// <returns>视频Xpath子对象</returns>
        public static ICnInterfaceVideoXpath CreateInterfaceVideoXpath()
        {
            string className = AssemblyName + "." + DBName + "." + "CnInterfaceVideoXpath";
            return (ICnInterfaceVideoXpath)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        /// <summary>
        /// 用户对象反射
        /// </summary>
        /// <returns>用户对象</returns>
        public static ICnInterfaceUser CreateInterfaceUser()
        {
            string className = AssemblyName + "." + DBName + "." + "CnInterfaceUser";
            return (ICnInterfaceUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
