using System;
using System.Collections.Generic;
using System.Text;
using HttpHelper;

namespace WXSM.Model
{
    public class Client
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public System.Uri RouteUrl { get; set; }
        private string _appSecret { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        private string _v { get; set; }

        public List<string> _pars { get; set; }
        /// <summary>
        /// 文轩客户端
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="format">返回格式</param>
        /// <param name="v">版本好</param>
        /// <param name="url">服务器地址</param>
        public Client(string appKey,string appSecret, string accessToken,string format = "json", string v="1.0",string url= "http://gw.api.winxuan.com/router/rest")
        {            
            _appSecret = appSecret;
            _pars = new List<string>();
            _pars.Add(Helper.ParUrlStr("format", format));
            _pars.Add(Helper.ParUrlStr("accessToken", accessToken));
            _pars.Add(Helper.ParUrlStr("appKey", appKey));
            _pars.Add(Helper.ParUrlStr("v", v));
            RouteUrl = new Uri(url);
            Item = new ClientItem(_pars, _appSecret, RouteUrl);
            Record = new ClientRecord(_pars, _appSecret, RouteUrl);
        }
        public ClientItem Item { get; set; }
        public ClientRecord Record { get; set; }

    }
}
