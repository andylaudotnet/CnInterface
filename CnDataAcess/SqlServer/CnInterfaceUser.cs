using System;
using System.Data;
using System.Text;
using CnDataAcess.IList;
using System.Data.SqlClient;

namespace CnDataAcess.SqlServer
{
    public class CnInterfaceUser:ICnInterfaceUser
    {
        public int GetUserLevel(string username)
        {
            int UserLevel = 2;
            string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
            string sql = "select  UserLevel from Cn_InterfaceUser where username='" + username + "'";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                    UserLevel = Convert.ToInt32(sdr["UserLevel"]);
            }
            return UserLevel;
        }

    }
}
