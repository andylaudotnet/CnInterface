using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System .Net;
using System.Text;
using System.IO;

namespace CnWeb
{
    public partial class GoogleResult : System.Web.UI.Page
    {
        protected string searchword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["searchword"] != null)
            {
                searchword = Request["searchword"].ToString();
            }
            else
            {
                //GetContextByUrl(GetUrl());
            }
        }

        private void GetContextByUrl(string url)
        {
            WebClient wc = new WebClient
                       {
                           Encoding = Encoding.GetEncoding(65001)
                       };
            string html = wc.DownloadString(url);
            if (!System.IO.File.Exists(Server.MapPath("searchresult.html")))
            {
                System.IO.File.Create(Server.MapPath("searchresult.html"));
            }
            StreamWriter sw = new StreamWriter(Server.MapPath("searchresult.html"));
            lock (sw)
            {
                sw.Write(html);
                sw.Close();
            }
        }

        public static string GetUrl()
        {
            string strTemp = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTPS"] == "off")
            {
                strTemp = "http://";
            }
            else
            {
                strTemp = "https://";
            }

            strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

            if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "80")
            {
                strTemp = strTemp + ":" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            }

            strTemp = strTemp + System.Web.HttpContext.Current.Request.RawUrl;

            return strTemp;
        }


    }
}
