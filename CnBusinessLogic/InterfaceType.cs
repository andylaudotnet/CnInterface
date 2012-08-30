using System;
using System.Data;
using CnDataAcess;

namespace CnBusinessLogic
{
    public class InterfaceType
    {
        /// <summary>
        /// 获取接口类型列表
        /// </summary>
        /// <returns>DataTable数据格式</returns>
        public static DataTable GetInterfaceType()
        {
            return ObjectCreate.CreateInterfaceType().GetCnInterfaceType();
        }
    }
}
