using System;

namespace CnDataAcess.Entity
{
    public class CnInterfaceInfo
    {
        #region 接口实体类属性
        private int _cnInterfaceTypeID;
        private string _cnInterfaceName;
        private string _cnInterfaceUrl;
        private string _cnInterfacebody;
        private string _cnInterfaceSource;
        private string _cnInterfaceSourceUrl;
        private DateTime _cnInterfaceAppearTime;
        private DateTime _createDateTime;
        #endregion

        #region 接口实体类属性get,set方法
        /// <summary>
        /// 接口类型
        /// </summary>
        public int CnInterfaceTypeID
        {
            get { return this._cnInterfaceTypeID; }
            set { this._cnInterfaceTypeID = value; }
        }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string CnInterfaceName
        {
            get { return this._cnInterfaceName; }
            set { this._cnInterfaceName = value; }
        }
        /// <summary>
        /// 接口地址
        /// </summary>
        public string CnInterfaceUrl
        {
            get { return this._cnInterfaceUrl; }
            set { this._cnInterfaceUrl = value; }
        }
        /// <summary>
        /// 接口描述内容
        /// </summary>
        public string CnInterfacebody
        {
            get { return this._cnInterfacebody; }
            set { this._cnInterfacebody = value; }
        }
        /// <summary>
        /// 接口来源
        /// </summary>
        public string CnInterfaceSource
        {
            get { return this._cnInterfaceSource; }
            set { this._cnInterfaceSource = value; }
        }
        /// <summary>
        /// 接口来源地址
        /// </summary>
        public string CnInterfaceSourceUrl
        {
            get { return this._cnInterfaceSourceUrl; }
            set { this._cnInterfaceSourceUrl = value; }
        }
        /// <summary>
        /// 接口发表时间
        /// </summary>
        public DateTime CnInterfaceAppearTime
        {
            get { return this._cnInterfaceAppearTime; }
            set { this._cnInterfaceAppearTime = value; }
        }
        /// <summary>
        /// 接口入库时间时间
        /// </summary>
        public DateTime CreateDateTime
        {
            get { return this._createDateTime; }
            set { this._createDateTime = value; }
        }
        #endregion
    }
}
