using System;
using System.Collections.Generic;
using API.PDD.Model;
using HttpHelper;
using Newtonsoft.Json;

namespace API.PDD
{
    public class GetToken
    {
        private readonly string _client_id;
        private readonly string _code;
        private readonly string _client_secret;
        private readonly string _grant_type;
        private readonly string _Uri;
        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="client_id">appkey</param>
        /// <param name="code">换取token的授权码</param>
        /// <param name="client_secret">app Secret</param>
        /// <param name="grant_type">默认为authorization_code</param>
        /// <param name="Uri">授权地址</param>
        public GetToken(string client_id,string code,string client_secret, string grant_type = "authorization_code", string Uri= "https://open-api.pinduoduo.com/oauth/token")
        {
            _client_id = client_id;
            _code = code;
            _client_secret = client_secret;
            _grant_type = grant_type;
            _Uri = Uri;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AccessToken GetAccessToken()
        {
            List<string> pars = new List<string>();
            pars.Add(Helper.ParJson("client_id", _client_id));
            pars.Add(Helper.ParJson("code", _code));
            pars.Add(Helper.ParJson("client_secret", _client_secret));
            pars.Add(Helper.ParJson("grant_type", _grant_type));
            string Result=Helper.Post("application/json", new Uri(_Uri), Helper.GetParsJson(pars));
            AccessToken pat = JsonConvert.DeserializeObject<AccessToken>(Result);
            return pat;
        }
    }
}
