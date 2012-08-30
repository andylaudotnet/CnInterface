using System;
using System.Collections.Generic;
using System.Text;
using CnDataAcess.IList;
using CnDataAcess.Entity;
using System .Data;
using System .Data.SqlClient;

namespace CnDataAcess.SqlServer
{
    public class InterfaceInfo : ICnInterfaceInfo
    {
        #region 插入接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 插入接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="cii">接口实体对象</param>
        int ICnInterfaceInfo.InsertCnInterfaceInfo(CnInterfaceInfo cnf)
        {
            int excutecount = 0;
            string sql = @"DECLARE @cnf_id INT
SELECT  @cnf_id = ID
FROM    Cn_InterfaceInfo
WHERE   CnInterfaceUrl = @CnInterfaceUrl
        AND CnInterfaceName = @CnInterfaceName

IF @cnf_id IS NULL 
    BEGIN
INSERT INTO [Cn_InterfaceInfo]
           ([CnInterfaceTypeID]
           ,[CnInterfaceName]
           ,[CnInterfaceUrl]
           ,[CnInterfaceInfo]
           ,[CnInterfaceSource]
           ,[CnInterfaceSourceUrl]
           ,[CnInterfaceAppearTime])
     VALUES
           (@CnInterfaceTypeID
           ,@CnInterfaceName
           ,@CnInterfaceUrl
           ,@CnInterfaceInfo
           ,@CnInterfaceSource
           ,@CnInterfaceSourceUrl
           ,@CnInterfaceAppearTime) 
      END";
             string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
             using (SqlConnection conn = new SqlConnection(conStr))
             {
                 conn.Open();
                 SqlCommand cmd = conn.CreateCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = sql;
                 cmd.Parameters.AddWithValue("@CnInterfaceTypeID", cnf.CnInterfaceTypeID);
                 cmd.Parameters.AddWithValue("@CnInterfaceName", cnf.CnInterfaceName);
                 cmd.Parameters.AddWithValue("@CnInterfaceUrl", cnf.CnInterfaceUrl);
                 cmd.Parameters.AddWithValue("@CnInterfaceInfo", cnf.CnInterfacebody);
                 cmd.Parameters.AddWithValue("@CnInterfaceSource", cnf.CnInterfaceSource);
                 cmd.Parameters.AddWithValue("@CnInterfaceSourceUrl", cnf.CnInterfaceSourceUrl);
                 cmd.Parameters.AddWithValue("@CnInterfaceAppearTime", cnf.CnInterfaceAppearTime);

                 excutecount = cmd.ExecuteNonQuery();
             }
             return excutecount;
        }
        #endregion

        #region 更新接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 更新接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="cii">接口实体对象</param>
        void ICnInterfaceInfo.UpdateCnInterfaceInfo(CnInterfaceInfo cii)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 删除接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 删除接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="id">接口ID</param>
        void ICnInterfaceInfo.DeleteCnInterfaceInfo(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据搜索参数对象查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据搜索参数对象查询)
        /// </summary>
        /// <param name="spara">搜索参数对象</param>
        /// <returns>接口实体对象集合</returns>
        IList<CnInterfaceInfo> ICnInterfaceInfo.GetCnInterfaceInfos(SearchParames spara)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据关键字等条件查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据关键字等条件查询)
        /// </summary>
        /// <param name="searchwords">查询关键字</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="totalcount">数据总条数</param>
        /// <param name="totalpage">分页总页数</param>
        /// <returns>接口实体对象集合</returns>
        IList<CnInterfaceInfo> ICnInterfaceInfo.GetCnInterfaceInfoByName(int ttype,string searchwords, int pagesize, int pageindex, out int totalcount, out int totalpage)
        {
            string sql = @"SELECT  a.*
                                INTO    #temp_search_article
                                FROM    ( SELECT    id ,
                                                    0 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE  CnInterfaceTypeID=@ttype  AND   CnInterfaceName LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceInfo LIKE '%' + @searchwords + '%'
                                          UNION ALL
                                          SELECT    id ,
                                                    1 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE  CnInterfaceTypeID=@ttype  AND   CnInterfaceName LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceInfo NOT LIKE '%' + @searchwords + '%'
                                          UNION ALL
                                          SELECT    id ,
                                                    2 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE  CnInterfaceTypeID=@ttype  AND   CnInterfaceInfo LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceName NOT LIKE '%' + @searchwords + '%'
                                        ) a


                                SELECT  b.MATCH ,
                                        c.*
                                FROM    ( SELECT TOP ( @pagesize )
                                                    *
                                          FROM      #temp_search_article b
                                          WHERE     id NOT IN ( SELECT TOP ( @pagesize * ( @pageindex - 1 ) )
                                                                        id
                                                                FROM    #temp_search_article )
                                        ) b
                                        INNER JOIN Cn_InterfaceInfo c ON b.id = c.id
                                ORDER BY b.MATCH ASC ,c.CnInterfaceAppearTime DESC

                                -- 总的记录数
                                DECLARE @totalcount INT ;
                                -- 总的页数
                                DECLARE @totalpage INT ;

                                SELECT  @totalcount = COUNT(0)
                                FROM    #temp_search_article

                                SET @totalpage = @totalcount / @pagesize
                                IF @totalcount % @pagesize <> 0 
                                    SET @totalpage = @totalpage + 1 
                                SELECT  @totalcount AS totalcount ,
                                        @totalpage AS totalpage 

                                DROP TABLE #temp_search_article
                                ";
            if (ttype == 0)
            {
                sql = @"SELECT  a.*
                                INTO    #temp_search_article
                                FROM    ( SELECT    id ,
                                                    0 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE     CnInterfaceName LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceInfo LIKE '%' + @searchwords + '%'
                                          UNION ALL
                                          SELECT    id ,
                                                    1 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE     CnInterfaceName LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceInfo NOT LIKE '%' + @searchwords + '%'
                                          UNION ALL
                                          SELECT    id ,
                                                    2 AS MATCH
                                          FROM      Cn_InterfaceInfo
                                          WHERE     CnInterfaceInfo LIKE '%' + @searchwords + '%'
                                                    AND CnInterfaceName NOT LIKE '%' + @searchwords + '%'
                                        ) a


                                SELECT  b.MATCH ,
                                        c.*
                                FROM    ( SELECT TOP ( @pagesize )
                                                    *
                                          FROM      #temp_search_article b
                                          WHERE     id NOT IN ( SELECT TOP ( @pagesize * ( @pageindex - 1 ) )
                                                                        id
                                                                FROM    #temp_search_article )
                                        ) b
                                        INNER JOIN Cn_InterfaceInfo c ON b.id = c.id
                                ORDER BY b.MATCH ASC ,c.CnInterfaceAppearTime DESC

                                -- 总的记录数
                                DECLARE @totalcount INT ;
                                -- 总的页数
                                DECLARE @totalpage INT ;

                                SELECT  @totalcount = COUNT(0)
                                FROM    #temp_search_article

                                SET @totalpage = @totalcount / @pagesize
                                IF @totalcount % @pagesize <> 0 
                                    SET @totalpage = @totalpage + 1 
                                SELECT  @totalcount AS totalcount ,
                                        @totalpage AS totalpage 

                                DROP TABLE #temp_search_article
                                ";
            }
            string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@searchwords", searchwords);
                if (ttype > 0)
                {
                    cmd.Parameters.AddWithValue("@ttype", ttype);
                }
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@pageindex", pageindex);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IList<CnInterfaceInfo> ICII =new List<CnInterfaceInfo>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CnInterfaceInfo cii = new CnInterfaceInfo();
                        cii.CnInterfaceTypeID =Convert.ToInt32(ds.Tables[0].Rows[i]["CnInterfaceTypeID"]);
                        cii.CnInterfaceName = ds.Tables[0].Rows[i]["CnInterfaceName"] as string;
                        cii.CnInterfaceUrl = ds.Tables[0].Rows[i]["CnInterfaceUrl"] as string;
                        cii.CnInterfacebody = ds.Tables[0].Rows[i]["CnInterfaceInfo"] as string;
                        cii.CnInterfaceSource = ds.Tables[0].Rows[i]["CnInterfaceSource"] as string;
                        cii.CnInterfaceSourceUrl = ds.Tables[0].Rows[i]["CnInterfaceSourceUrl"] as string;
                        cii.CreateDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreateDateTime"]);
                        cii.CnInterfaceAppearTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CnInterfaceAppearTime"]);
                        ICII.Add(cii);
                    }
                    totalcount = Convert.ToInt32(ds.Tables[1].Rows[0]["totalcount"]);
                    totalpage = Convert.ToInt32(ds.Tables[1].Rows[0]["totalpage"]);
                    return ICII;
                }
                else
                {
                    totalcount = 0;
                    totalpage = 0;
                    return null;
                }
            }
        }
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据ID查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据ID查询)
        /// </summary>
        /// <param name="id">接口ID</param>
        /// <returns>接口实体对象</returns>
        CnInterfaceInfo ICnInterfaceInfo.GetCnInterfaceInfoByID(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据接口名称查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据接口名称查询)
        /// </summary>
        /// <param name="name">接口名称</param>
        /// <returns>DataSet数据对象</returns>
        public DataSet GetCnInterfaceNames(string name)
        {
            DataSet ds = null;
            string sql = "select top 10 CnInterfaceName from Cn_InterfaceInfo where CnInterfaceName like '%" + name + "%' ";
            string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"].ToString();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                //cmd.Parameters.AddWithValue("@name", name);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
            }
            return ds;
        }
        #endregion
    }
}
