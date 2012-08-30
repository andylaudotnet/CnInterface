using System;
using System.Collections.Generic;
using System.Text;
using CnDataAcess.Entity;
using System.Data;

namespace CnDataAcess.IList
{
    public interface ICnInterfaceInfo
    {
        #region 插入接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 插入接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="cii">接口实体对象</param>
        int InsertCnInterfaceInfo(CnInterfaceInfo cii);
        #endregion

        #region 更新接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 更新接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="cii">接口实体对象</param>
        void UpdateCnInterfaceInfo(CnInterfaceInfo cii);
        #endregion

        #region 删除接口表(Cn_InterfaceInfo)数据
        /// <summary>
        /// 删除接口表(Cn_InterfaceInfo)数据
        /// </summary>
        /// <param name="id">接口ID</param>
        void DeleteCnInterfaceInfo(int id);
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据搜索参数对象查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据搜索参数对象查询)
        /// </summary>
        /// <param name="spara">搜索参数对象</param>
        /// <returns>接口实体对象集合</returns>
        IList<CnInterfaceInfo> GetCnInterfaceInfos(SearchParames spara);
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
        IList<CnInterfaceInfo> GetCnInterfaceInfoByName(int ttype, string searchwords, int pagesize, int pageindex, out int totalcount, out int totalpage);
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据ID查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据ID查询)
        /// </summary>
        /// <param name="id">接口ID</param>
        /// <returns>接口实体对象</returns>
        CnInterfaceInfo GetCnInterfaceInfoByID(int id);
        #endregion

        #region 查询接口表(Cn_InterfaceInfo)数据(根据接口名称查询)
        /// <summary>
        /// 查询接口表(Cn_InterfaceInfo)数据(根据接口名称查询)
        /// </summary>
        /// <param name="name">接口名称</param>
        /// <returns>DataSet数据对象</returns>
        DataSet GetCnInterfaceNames(string name);
        #endregion
    }
}
