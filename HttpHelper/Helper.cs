using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace HttpHelper
{
    public class Helper
    {
        public static string Post(string ContentType, System.Uri Url, string pars)
        {
            int n = 0;
            bool PostStatus = false;
            string Result = string.Empty;
            while(n<3&&PostStatus==false)
            {
                try
                {
                    Result=BasePost(ContentType, Url, pars);
                    PostStatus = true;
                    n += 1;
                }
                catch
                {
                    n += 1;
                    Thread.Sleep(1000);
                }
            }
            if(PostStatus==false)
            {
                throw new Exception("3次发送失败:" + pars);
            }
            else
            {
                return Result;
            }
        }
        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="ContentType"></param>
        /// <param name="Url"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static string BasePost(string ContentType, System.Uri Url, string pars)
        {

            string ResultStr = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = ContentType;
            request.Method = "POST";
            if (pars != null && pars.Length > 0)
            {
                byte[] ParsBytes = Encoding.UTF8.GetBytes(pars);
                Stream s = request.GetRequestStream();
                s.Write(ParsBytes, 0, ParsBytes.Length);
                s.Close();
            }
            using (HttpWebResponse respone = (HttpWebResponse)request.GetResponse())
            {
                System.IO.Stream stm = respone.GetResponseStream();
                ResultStr = new StreamReader(stm, System.Text.Encoding.UTF8).ReadToEnd();
                stm.Close();
            }
            return ResultStr;
        }
        /// <summary>
        /// 将日期转换为时间戳
        /// </summary>
        /// <param name="Time">需要转换的日期</param>
        /// <returns></returns>
        public static string GetTimestamp(DateTime Time)
        {
            DateTime ZeroTime = new DateTime(1970, 1, 1, 8, 0, 0);
            Time = new DateTime(Time.Year, Time.Month, Time.Day, Time.Hour, Time.Minute, Time.Second, Time.Millisecond);
            return (Time - ZeroTime).TotalMilliseconds.ToString();
        }
        /// <summary>
        /// 将提交的参数排序后使用SHA1加密计算出SignKey
        /// </summary>
        /// <param name="pars"></param>
        /// <param name="Secret"></param>
        /// <returns></returns>
        public static string GetSignKey(List<string> pars,string Secret)
        {
            pars=EmptyStringClear(pars);
            pars.Sort();
            StringBuilder sb = new StringBuilder();
            sb.Append(Secret);
            foreach (var item in pars)
            {
                sb.Append(HttpUtility.UrlDecode(item.Replace("=","").Replace(":","")));
            }
            sb.Append(Secret);
            return GetSHA1(sb.ToString());
        }
        /// <summary>
        /// 将提交的参数排序后使用MD5加密计算出SignKey
        /// </summary>
        /// <param name="pars"></param>
        /// <param name="Secret"></param>
        /// <returns></returns>
        public static string GetSignKeyMD5(List<string> pars, string Secret)
        {
            pars = EmptyStringClear(pars);
            pars.Sort();
            StringBuilder sb = new StringBuilder();
            sb.Append(Secret);
            foreach (var item in pars)
            {
                sb.Append(HttpUtility.UrlDecode(item.Replace(":", "").Replace("=","")));
            }
            sb.Append(Secret);
            return GetMD5(sb.ToString());
        }
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="Str">加密的内容</param>
        /// <returns></returns>
        public static string GetSHA1(string Str)
        {
            var sa = new SHA1CryptoServiceProvider();
            byte[] byts = Encoding.UTF8.GetBytes(Str);
            byte[] saByts = sa.ComputeHash(byts);
            var SaString = BitConverter.ToString(saByts).Replace("-", "");
            return SaString.ToUpper();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="Str">加密的内容</param>
        /// <returns></returns>
        public static string GetMD5(string Str)
        {
            var md = new MD5CryptoServiceProvider();
            byte[] byts = Encoding.UTF8.GetBytes(Str);
            byte[] mdByts = md.ComputeHash(byts);
            var mdString = BitConverter.ToString(mdByts).Replace("-", "");
            return mdString.ToUpper();
        }
        public static string ParJson(string parname,string parvalue)
        {
            if (parvalue != null && parvalue.Length > 0)
            {

                return parname + ":" +parvalue;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 返回Url参数
        /// </summary>
        /// <param name="parname"></param>
        /// <param name="parvalue"></param>
        /// <returns></returns>
        public static string ParUrlStr(string parname, string parvalue)
        {
            if(parvalue!=null&&parvalue.Length>0)
            {

                return HttpUtility.UrlEncode(parname, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(parvalue, Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }
        public static string ParUrlStr(string parname, int parvalue)
        {
            if (parvalue> 0)
            {

                return HttpUtility.UrlEncode(parname, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(parvalue.ToString(), Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }
        public static string ParUrlStr(string parname, double parvalue)
        {
            if (parvalue > 0)
            {

                return HttpUtility.UrlEncode(parname, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(parvalue.ToString(), Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 返回Url数组参数
        /// </summary>
        /// <param name="parname">参数名</param>
        /// <param name="parvalues"></param>
        /// <returns></returns>
        public static string ParUrlStr(string parname, string[] parvalues)
        {
            string parStr = string.Empty;
            if(parvalues != null && parvalues.Length > 0)
            {
                parStr= HttpUtility.UrlEncode(parname, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(string.Join(",", parvalues), Encoding.UTF8);
            }
            return parStr;
        }
        /// <summary>
        /// 清除空参数
        /// </summary>
        /// <param name="ListStr"></param>
        /// <returns></returns>
        public static List<string> EmptyStringClear(List<string> ListStr)
        {
            bool UnClear = true;
            while (UnClear)
            {
                UnClear = ListStr.Remove(string.Empty);
            }
            return ListStr;
        }
        /// <summary>
        /// 返回Url字符串
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static string GetParsUrlStr(List<string> pars)
        {
            return string.Join("&", pars);
        }
        /// <summary>
        /// 返回json字符串
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static string GetParsJson(List<string> pars)
        {
            return string.Join(",", pars);
        }
    }
}
