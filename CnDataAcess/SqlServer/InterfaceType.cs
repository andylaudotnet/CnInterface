using System;
using CnDataAcess.IList;
using System.Data;
using System.Data.SqlClient;

namespace CnDataAcess.SqlServer
{
    public  class InterfaceType:ICnInterfaceType
    {
        /// <summary>
        /// 获取接口类型列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetCnInterfaceType()
        {
            string sql = "select  * from  Cn_Interfacetype";
            DataTable dt = null;
             string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
             using (SqlConnection conn = new SqlConnection(conStr))
             {
                 conn.Open();
                 SqlCommand cmd = conn.CreateCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = sql;
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 sda.Fill(ds);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     dt = ds.Tables[0];
                 }
             }
             return dt;
        }
    }
}
