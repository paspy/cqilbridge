using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

using Newtonsoft.Json.Linq;
using CQILBridge.Framework.Data;
using CQILBridge.Framework.Utility;

namespace CQILBridge.Framework {
    /// <summary>
    /// CoolQ API Extensions - Unofficial
    /// </summary>
    public static class CQE {

        /// <inheritdoc />
        public static List<GroupInfo> GetGroupList() {
            lock (__syncRoot) {
                List<GroupInfo> lst = new List<GroupInfo>();
                try {
                    CQ.Log(CQLogLevel.Info, "开始获取群列表");
                    string url = "http://qun.qq.com/cgi-bin/qun_mgr/get_group_list";
                    var postData = new Dictionary<string, string>() {
                    { "bkn", CQ.CsrfToken.ToString() }
                };
                    string sourceString =
                        HttpHelper.Post(
                            url, postData, "http://qun.qq.com/member.html", GetCookieCollection("qun.qq.com"));
                    var strReg = "{\"gc\":([1-9][0-9]{4,10}),\"gn\":\"(.*?)\",\"owner\":([1-9][0-9]{4,10})}";
                    Regex reg = new Regex(strReg);
                    MatchCollection matches = reg.Matches(sourceString);
                    foreach (Match match in matches) {
                        dynamic g = JToken.Parse(match.Value);
                        var gInfo = new GroupInfo() { Name = HttpUtility.HtmlDecode((string)g.gn), Number = g.gc, Owner = g.owner };
                        lst.Add(gInfo);
                        CQ.Log(CQLogLevel.Debug,
                            string.Format("Name: {0}, Number: {1}, Owner: {2}", gInfo.Name, gInfo.Number, gInfo.Owner));
                    }
                } catch (Exception e) {
                    CQ.Log(CQLogLevel.Error, "GetGroupList " + e.Message);
                    lst = null;
                }
                return lst;
            }
        }

        /// <inheritdoc />
        public static CookieCollection GetCookieCollection(string domain) {
            CookieCollection cookieCollection = new CookieCollection();
            char[] chArray1 = new char[1] { ';' };
            foreach (string str in CQ.Cookies.Split(chArray1)) {
                char[] chArray2 = new char[1] { '=' };
                string[] strArray = str.Split(chArray2);
                if (strArray.Length == 2) {
                    Cookie cookie = new Cookie(strArray[0].Trim(), HttpHelper.UrlDecode(strArray[1].Trim()), "/", domain);
                    cookieCollection.Add(cookie);
                }
            }
            return cookieCollection;
        }

        [NonSerialized]
        private static object __syncRoot = new object();
    }
}
