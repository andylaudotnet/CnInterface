using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.Text;
using etmc.sms.smpapi;
using System.Text.RegularExpressions;
using System.Collections;

namespace CnWeb.SmsOnline
{
    public partial class SmpApiSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            labResult.Text = SendSMS(txtPhone.Text,txtMessage.Text).ToString();
        }

        #region 处理分页并发送短信
        public bool SendSMS ( string PhoneNum, string SmsMsg)
		{
			SmsBuilder SmsBdr = new SmsBuilder ( PhoneNum );
			// 当手机号无效，取消发送
			if ( SmsBdr.IsValid () == false )
			{
				return false;
			}
			else
			{
				// 短信不用分页时，直接发送单条短信
				if ( SmsBdr.NeedPage ( SmsMsg ) == false )
				{
					// 生成单页短信
					string SingleMsg = SmsBdr.SingleMsg ( SmsMsg );
					// 发送单页短信
                    return this.SendPageSMS(PhoneNum, SingleMsg);
				}
				else// 短信需要分页时，依次发送多条已分页的短信
				{
					// 短信分页页数
					int SmsPageCount = SmsBdr.PageCount ( SmsMsg );
					bool RtnVal = true;
					for ( int Index = 0; Index < SmsPageCount; Index ++ )
					{
						// 生成当前页短信
						string SmsPageMsg = SmsBdr.PageMsg ( SmsMsg, Index );
						// 发送当前页短信
                        RtnVal &= this.SendPageSMS(PhoneNum, SmsPageMsg);
						// 当前页不是最后一页
						if ( Index < SmsPageCount )
						{
							// 发送两页短信之间，等待一个时间间隔
							System.Threading.Thread.Sleep ( SmsBdr.PageInterval );
						}
					}
					return RtnVal;
				}
			}
		}
		#endregion

        #region 短信处理类
        private bool SendPageSMS(string PhoneNum, string SmsMsg)
        {
            SmsBuilder SmsBdr = new SmsBuilder(PhoneNum);
            // 未处理分页时，转到处理分页，并发送短信的函数
            if (SmsBdr.NeedPage(SmsMsg) == true)
            {
                // return this.SendSMS(PhoneNum, SmsMsg, SmsSource);
            }
            string[] Params = "203.81.21.56|3000|10060|8|message1,message2,message3,message4,message5".Split('|');
            UdpClient uc = new UdpClient();
            IPAddress ipa = IPAddress.Parse(Params[0]);
            int port = Convert.ToInt16(Params[1]);
            IPEndPoint ipep = new IPEndPoint(ipa, port);

            // 生成短信来源
            string SmsSrc = "web";
            SmpApi sa = new SmpApi();
            sa.setSmp021(PhoneNum);
            sa.setSmp023(Params[2]);
            sa.setSmp032(SmsMsg);
            sa.setSmp040(Params[3]);
            sa.setSmp085(SmsSrc);
            sa.setSmp084("101");

            byte[] Buf = Encoding.Default.GetBytes(sa.packSmp());

            // 循环重试发送短信

            for (int i = 0; i < SmsBdr.TrySendCount; i++)
            {
                try
                {
                    // 调用发送短信接口，将短信发送出去
                    uc.Send(Buf, Buf.Length, ipep);
                    break;
                }
                catch (Exception ex)
                {
                    if (i < SmsBdr.TrySendCount - 1)
                    {
                        // 重试发送前，等待一个时间间隔
                        System.Threading.Thread.Sleep(SmsBdr.RetryInterval);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }

    #region 短信类
    /// <summary>
    /// 短信类
    /// </summary>
    public class SmsBuilder
    {
        public SmsBuilder(string PhoneNum)
        {
            this.PhoneNum = PhoneNum;
            this.UnicomHead = new ArrayList(new string[] { "130", "131", "132", "133", "153" });
            if (this.HasAutoSender() == true)
            {
                this.SenderInfoSize = 0;
            }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNum;
        /// <summary>
        /// 联通手机号头列表
        /// </summary>
        private ArrayList UnicomHead;
        /// <summary>
        /// 结束符长度
        /// </summary>
        private const int PadSize = 0;
        /// <summary>
        /// 原始最大长度
        /// </summary>
        private const int RawSize = 60;
        /// <summary>
        /// 短信最大长度
        /// </summary>
        public int MaxSize
        {
            get
            {
                return RawSize - SenderInfoSize - PadSize;
            }
        }
        /// <summary>
        ///  短信发送者信息
        /// </summary>
        private const string SenderInfo = "[abcd]";
        /// <summary>
        /// 短信发送者所占长度
        /// </summary>
        private int SenderInfoSize = 0;
        /// <summary>
        /// 短信页码格式
        /// </summary>
        private const string PageInfoFormat = "({0}/{1})";
        /// <summary>
        /// 短信页码长度
        /// 仅适用于页数是1位数的情况
        /// </summary>
        private int PageInfoSize = PageInfoFormat.Length - 4;
        /// <summary>
        /// 尝试发送次数
        /// </summary>
        public int TrySendCount = 3;
        /// <summary>
        /// 重试发送间隔【单位：毫秒】
        /// </summary>
        public int RetryInterval = 5000;
        /// <summary>
        /// 分页发送间隔【单位：毫秒】
        /// </summary>
        public int PageInterval = 1500;
        /// <summary>
        /// 分页长度
        /// </summary>
        public int PageSize
        {
            get
            {
                return MaxSize - PageInfoSize - SenderInfoSize;
            }
        }
        /// <summary>
        ///  分页短信的页数
        /// </summary>
        /// <param name="SmsMsg">短信内容</param>
        /// <returns>短信分页的页数</returns>
        public int PageCount(string SmsMsg)
        {
            if (this.NeedPage(SmsMsg) == false)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(SmsMsg.Length) / Convert.ToDouble(PageSize)));
            }
        }
        /// <summary>
        /// 短信超长时，切割短信，并插入短信页码信息，然后依次发送所有短信
        /// </summary>
        /// <param name="PhoneNum">电话号码</param>
        /// <param name="SmsMsg">短信内容</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <returns>当前索引页的分页短信</returns>
        public string PageMsg(string SmsMsg, int PageIndex)
        {
            if (this.NeedPage(SmsMsg) == false)
            {
                return SingleMsg(SmsMsg);
            }
            else
            {
                int SmsPageCount = PageCount(SmsMsg);
                // 右填充空白字符，以对齐最后1页长度
                SmsMsg = SmsMsg.PadRight(PageSize * SmsPageCount);
                StringBuilder Bdr = new StringBuilder();
                // 插入页码
                Bdr.AppendFormat(PageInfoFormat, PageIndex + 1, SmsPageCount);
                // 插入当页短信
                Bdr.Append(SmsMsg.Substring(PageIndex * PageSize, PageSize).Trim());
                return Bdr.ToString().Trim();
            }
        }

        /// <summary>
        /// 短信超长时，切割短信，并插入短信页码信息，然后依次发送所有短信
        /// </summary>
        /// <param name="PhoneNum">电话号码</param>
        /// <param name="SmsMsg">短信内容</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <returns>当前索引页的分页短信</returns>
        public string SingleMsg(string SmsMsg)
        {
            if (this.NeedPage(SmsMsg) == true)
            {
                return PageMsg(SmsMsg, 0);
            }
            else
            {
                StringBuilder Bdr = new StringBuilder();

                Bdr.Append(SmsMsg.Trim());
                return Bdr.ToString().Trim();
            }
        }

        /// <summary>
        /// 判断手机号在发送短信时，是否会自动包含短信发送者信息
        /// </summary>
        public bool HasAutoSender()
        {
            try
            {
                string PhoneHead = this.PhoneNum.Substring(0, 3);

                return !this.UnicomHead.Contains(PhoneHead);
            }
            catch (Exception ex)
            {
                StringBuilder Bdr = new StringBuilder();
                Bdr.AppendFormat("<{0}>联通{1}", PhoneNum, ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 判断短信内容，是否已包含用户自定义发送者信息
        /// </summary>
        public bool HasCustomSender(string SmsMsg)
        {
            return SmsMsg.Trim().EndsWith(SenderInfo);
        }
        /// <summary>
        /// 判断短信内容，是否包含发送着信息
        /// </summary>
        public bool HasSender(string SmsMsg)
        {
            return true;
        }
        /// <summary>
        /// 判断当前短信是否需要分页
        /// </summary>
        public bool NeedPage(string SmsMsg)
        {
            int SmsSize = SmsMsg.Trim().Length;

            if (this.HasSender(SmsMsg) == true)
            {
                return SmsSize > MaxSize;
            }
            else
            {
                return SmsSize > MaxSize - SenderInfoSize;
            }
        }
        /// <summary>
        /// 验证手机号码是否有效
        /// </summary>
        public bool IsValid()
        {
            if (this.PhoneNum.Length != 11
              && this.PhoneNum.Length != 13)
            {
                return false;
            }
            else
            {
                string Phone = this.PhoneNum.PadLeft(13).Substring(2);
                // 验证手机号是否以 "13" 开头
                Regex Reg13 = new Regex("^[13]{2}");
                // 验证手机号是否以 "15" 开头
                Regex Reg15 = new Regex("^[15]{2}");
                return Reg13.IsMatch(Phone)
                    || Reg15.IsMatch(Phone);
            }
        }
    }
    #endregion
}
