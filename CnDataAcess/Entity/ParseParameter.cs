using System;

namespace CnDataAcess.Entity
{
    public class ParseParameter
    {
        #region 解析实体类属性
        /// <summary>
        /// 解析名称
        /// </summary>
        public string ParseName { get; set; }
        /// <summary>
        /// 解析状态
        /// </summary>
        public int ParseStatus { get; set; }
        /// <summary>
        /// 解析网络名称
        /// </summary>
        public string SiteSoureName { get; set; }
        /// <summary>
        /// 解析网络编码编号
        /// </summary>
        public int SiteSoureEncodeNo { get; set; }
        /// <summary>
        /// 解析网络地址
        /// </summary>
        public string SiteSoureUrl { get; set; }
        /// <summary>
        /// 接口类型
        /// </summary>
        public int CnTypeID { get; set; }
        /// <summary>
        /// 接口列表网络地址
        /// </summary>
        public string CnListUrl { get; set; }
        /// <summary>
        /// 接口列表XPath
        /// </summary>
        public string CnListXPath { get; set; }
        /// <summary>
        /// 接口列表正则表达式
        /// </summary>
        public string CnListRegex { get; set; }
       /// <summary>
       /// 接口名称XPath
       /// </summary>
        public string CnInterfaceNameXPath { get; set; }
        /// <summary>
        /// 接口名称正则表达式
        /// </summary>
        public string CnInterfaceNameRegex { get; set; }
        /// <summary>
        /// 接口详细内容XPath
        /// </summary>
        public string CnInterfaceXPath { get; set; }
        /// <summary>
        /// 接口详细内容正则表达式
        /// </summary>
        public string CnInterfaceRegex { get; set; }
        /// <summary>
        /// 接口时间XPath
        /// </summary>
        public string CnInterfaceTimeXPath { get; set; }
        /// <summary>
        /// 接口时间正则表达式
        /// </summary>
        public string CnInterfaceTimeRegex { get; set; }
        /// <summary>
        /// 接口时间格式化
        /// </summary>
        public string CnInterfaceTimeFormat { get; set; }
        #endregion
    }
}
