using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using CnDataAcess.IList;
using CnDataAcess.Entity;

namespace CnDataAcess.SqlServer
{
    public class CnInterfaceVideoXpath:ICnInterfaceVideoXpath
    {
        public CnDataAcess.Entity.CnInterfaceVideoXpath GetVideoXpathByWebName(string webname)
        {
            string sql = @"SELECT * FROM [Cn_InterfaceVideoXpath] WHERE [CnWebName] = @CnWebName";
            CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath = null;
            string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@CnWebName", webname);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    cnXpath = new CnDataAcess.Entity.CnInterfaceVideoXpath();
                    cnXpath.CnWebName = sdr["CnWebName"] as string;
                    cnXpath.CnWebUrl = sdr["CnWebUrl"] as string;
                    cnXpath.CnWebEncode = sdr["CnWebEncode"] as string;
                    cnXpath.CnVideoTitle001 = sdr["CnVideoTitle001"] as string;
                    cnXpath.CnVideoHref001 = sdr["CnVideoHref001"] as string;
                    cnXpath.CnVideoSrc001 = sdr["CnVideoSrc001"] as string;
                    cnXpath.CnVideoTitle002 = sdr["CnVideoTitle002"] as string;
                    cnXpath.CnVideoHref002 = sdr["CnVideoHref002"] as string;
                    cnXpath.CnVideoSrc002 = sdr["CnVideoSrc002"] as string;
                    cnXpath.CnVideoTitle003 = sdr["CnVideoTitle003"] as string;
                    cnXpath.CnVideoHref003 = sdr["CnVideoHref003"] as string;
                    cnXpath.CnVideoSrc003 = sdr["CnVideoSrc003"] as string;
                    cnXpath.CnVideoTitle004 = sdr["CnVideoTitle004"] as string;
                    cnXpath.CnVideoHref004 = sdr["CnVideoHref004"] as string;
                    cnXpath.CnVideoSrc004 = sdr["CnVideoSrc004"] as string;
                    cnXpath.CnVideoTitle005 = sdr["CnVideoTitle005"] as string;
                    cnXpath.CnVideoHref005 = sdr["CnVideoHref005"] as string;
                    cnXpath.CnVideoSrc005 = sdr["CnVideoSrc005"] as string;
                    cnXpath.CnVideoTitle006 = sdr["CnVideoTitle006"] as string;
                    cnXpath.CnVideoHref006 = sdr["CnVideoHref006"] as string;
                    cnXpath.CnVideoSrc006 = sdr["CnVideoSrc006"] as string;
                }
            }
            return cnXpath;
        }

        public int UpdateCnInterfaceVideo(CnDataAcess.Entity.CnInterfaceVideoXpath cnxpath)
        {
            int resultcount = 0;
            string sql = @"IF NOT EXISTS(SELECT 1 FROM [Cn_InterfaceVideoXpath] WHERE [CnWebName] = @CnWebName)
BEGIN
INSERT INTO [Cn_InterfaceVideoXpath]
           ([CnWebName]
           ,[CnWebUrl]
           ,[CnWebEncode]
           ,[CnVideoTitle001]
           ,[CnVideoHref001]
           ,[CnVideoSrc001]
           ,[CnVideoTitle002]
           ,[CnVideoHref002]
           ,[CnVideoSrc002]
           ,[CnVideoTitle003]
           ,[CnVideoHref003]
           ,[CnVideoSrc003]
           ,[CnVideoTitle004]
           ,[CnVideoHref004]
           ,[CnVideoSrc004]
           ,[CnVideoTitle005]
           ,[CnVideoHref005]
           ,[CnVideoSrc005]
           ,[CnVideoTitle006]
           ,[CnVideoHref006]
           ,[CnVideoSrc006])
     VALUES
           (@CnWebName
           ,@CnWebUrl
           ,@CnWebEncode
           ,@CnVideoTitle001
           ,@CnVideoHref001
           ,@CnVideoSrc001
           ,@CnVideoTitle002
           ,@CnVideoHref002
           ,@CnVideoSrc002
           ,@CnVideoTitle003
           ,@CnVideoHref003
           ,@CnVideoSrc003
           ,@CnVideoTitle004
           ,@CnVideoHref004
           ,@CnVideoSrc004
           ,@CnVideoTitle005
           ,@CnVideoHref005
           ,@CnVideoSrc005
           ,@CnVideoTitle006
           ,@CnVideoHref006
           ,@CnVideoSrc006)
END
ELSE
BEGIN
UPDATE [Cn_InterfaceVideoXpath]
   SET [CnWebName] = @CnWebName
      ,[CnWebUrl] = @CnWebUrl
      ,[CnWebEncode]=@CnWebEncode
      ,[CnVideoTitle001] = @CnVideoTitle001
      ,[CnVideoHref001] = @CnVideoHref001
      ,[CnVideoSrc001] = @CnVideoSrc001
      ,[CnVideoTitle002] = @CnVideoTitle002
      ,[CnVideoHref002] = @CnVideoHref002
      ,[CnVideoSrc002] = @CnVideoSrc002
      ,[CnVideoTitle003] = @CnVideoTitle003
      ,[CnVideoHref003] = @CnVideoHref003
      ,[CnVideoSrc003] = @CnVideoSrc003
      ,[CnVideoTitle004] = @CnVideoTitle004
      ,[CnVideoHref004] = @CnVideoHref004
      ,[CnVideoSrc004] = @CnVideoSrc004
      ,[CnVideoTitle005] = @CnVideoTitle005
      ,[CnVideoHref005] = @CnVideoHref005
      ,[CnVideoSrc005] = @CnVideoSrc005
      ,[CnVideoTitle006] = @CnVideoTitle006
      ,[CnVideoHref006] = @CnVideoHref006
      ,[CnVideoSrc006] = @CnVideoSrc006
      ,[CnUpdateTime] = getdate()
 WHERE [CnWebName]=@CnWebName
END";
            string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@CnWebName", cnxpath.CnWebName);
                cmd.Parameters.AddWithValue("@CnWebUrl", cnxpath.CnWebUrl);
                cmd.Parameters.AddWithValue("@CnWebEncode", cnxpath.CnWebEncode);
                cmd.Parameters.AddWithValue("@CnVideoTitle001", cnxpath.CnVideoTitle001);
                cmd.Parameters.AddWithValue("@CnVideoHref001", cnxpath.CnVideoHref001);
                cmd.Parameters.AddWithValue("@CnVideoSrc001", cnxpath.CnVideoSrc001);
                cmd.Parameters.AddWithValue("@CnVideoTitle002", cnxpath.CnVideoTitle002);
                cmd.Parameters.AddWithValue("@CnVideoHref002", cnxpath.CnVideoHref002);
                cmd.Parameters.AddWithValue("@CnVideoSrc002", cnxpath.CnVideoSrc002);
                cmd.Parameters.AddWithValue("@CnVideoTitle003", cnxpath.CnVideoTitle003);
                cmd.Parameters.AddWithValue("@CnVideoHref003", cnxpath.CnVideoHref003);
                cmd.Parameters.AddWithValue("@CnVideoSrc003", cnxpath.CnVideoSrc003);
                cmd.Parameters.AddWithValue("@CnVideoTitle004", cnxpath.CnVideoTitle004);
                cmd.Parameters.AddWithValue("@CnVideoHref004", cnxpath.CnVideoHref004);
                cmd.Parameters.AddWithValue("@CnVideoSrc004", cnxpath.CnVideoSrc004);
                cmd.Parameters.AddWithValue("@CnVideoTitle005", cnxpath.CnVideoTitle005);
                cmd.Parameters.AddWithValue("@CnVideoHref005", cnxpath.CnVideoHref005);
                cmd.Parameters.AddWithValue("@CnVideoSrc005", cnxpath.CnVideoSrc005);
                cmd.Parameters.AddWithValue("@CnVideoTitle006", cnxpath.CnVideoTitle006);
                cmd.Parameters.AddWithValue("@CnVideoHref006", cnxpath.CnVideoHref006);
                cmd.Parameters.AddWithValue("@CnVideoSrc006", cnxpath.CnVideoSrc006);

                resultcount = cmd.ExecuteNonQuery();
            }
            return resultcount;
        }

    }
}
