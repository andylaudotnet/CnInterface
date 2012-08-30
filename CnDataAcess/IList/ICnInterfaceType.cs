using System;
using System.Data;

namespace CnDataAcess.IList
{
     public  interface ICnInterfaceType
    {
         /// <summary>
         /// 获取接口类型列表
         /// </summary>
         /// <returns></returns>
         DataTable GetCnInterfaceType();
    }
}
