using System;
using System.Collections.Generic;
using System.Text;
using API.PDD.Model;
using HttpHelper;

namespace API.PDD
{
    public class PDDClient
    {
        /// <summary>
        /// 正式环境调用拼多多API地址
        /// </summary>
        private System.Uri RouteUrl { get; set; }

        private string _client_secret { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        private string _type { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        private string _sign { get; set; }
        /// <summary>
        /// 公共变量参数
        /// </summary>
        private List<string> PubPars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client_id">client_id</param>
        /// <param name="access_token">access_token</param>
        /// <param name="data_type">返回类型,默认大写JSON</param>
        /// <param name="version">版本，默认V1</param>
        /// <param name="Url">调用拼多多API地址</param>
        public PDDClient(string client_id,string client_secret,string access_token,string data_type="JSON",string version="V1",string Url= "https://gw-api.pinduoduo.com/api/router")
        {
            PubPars = new List<string>();
            _client_secret = client_secret;
            RouteUrl =new Uri(Url);
            string timestamp = Helper.GetTimestamp(DateTime.Now);
            PubPars.Add(Helper.ParUrlStr("timestamp", timestamp));
            PubPars.Add(Helper.ParUrlStr("client_id", client_id));
            PubPars.Add(Helper.ParUrlStr("access_token", access_token));
            PubPars.Add(Helper.ParUrlStr("data_type", data_type));
            PubPars.Add(Helper.ParUrlStr("version", version));
        }
        public string GetResultStr(List<string> pars)
        {
            //清空空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            _sign = Helper.GetSignKeyMD5(pars, _client_secret);
            pars.Add(Helper.ParUrlStr("sign", _sign));
            string ResultPars =string.Join("&", pars);
            return Helper.Post("application/x-www-form-urlencoded", RouteUrl, ResultPars);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent_cat_id"></param>
        /// <returns></returns>
        public string GetGoodCats(long parent_cat_id=0)
        {
            List<string> pars = PubPars;
            _type = "pdd.goods.authorization.cats";
            pars.Add(Helper.ParUrlStr("type", _type));
            //业务参数传参
            pars.Add(Helper.ParUrlStr("parent_cat_id", parent_cat_id.ToString()));

            //获取结果
            return GetResultStr(pars);
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="outer_id"></param>
        /// <param name="is_onsale"></param>
        /// <param name="goods_name"></param>
        /// <param name="page_size"></param>
        /// <param name="page"></param>
        /// <param name="outer_goods_id"></param>
        /// <param name="cost_template_id"></param>
        /// <returns></returns>
        public string GetGoodsList(string outer_id,int? is_onsale,string goods_name,int? page_size,int? page,string outer_goods_id,long? cost_template_id)
        {
            List<string> pars = PubPars;
            _type = "pdd.goods.list.get";
            pars.Add(Helper.ParUrlStr("type", _type));
            //业务参数传参
            pars.Add(Helper.ParUrlStr("outer_id", outer_id));
            pars.Add(Helper.ParUrlStr("is_onsale", is_onsale.ToString()));
            pars.Add(Helper.ParUrlStr("goods_name", goods_name));
            pars.Add(Helper.ParUrlStr("page_size", page_size.ToString()));
            pars.Add(Helper.ParUrlStr("page", page.ToString()));
            pars.Add(Helper.ParUrlStr("outer_goods_id", outer_goods_id));
            pars.Add(Helper.ParUrlStr("cost_template_id", cost_template_id.ToString()));
            pars.Add(Helper.ParUrlStr("type", _type.ToString()));
            //获取结果
            return GetResultStr(pars);
        }

        public string GoodCatTemplate(long cat_id)
        {
            List<string> pars = PubPars;
            _type = "pdd.goods.cat.template.get";
            pars.Add(Helper.ParUrlStr("type", _type));
            //业务参数传参
            pars.Add(Helper.ParUrlStr("cat_id", cat_id.ToString()));
            //获取结果
            return GetResultStr(pars);
        }
        /// <summary>
        /// 商品新增接口
        /// </summary>
        /// <param name="carousel_gallery">商品轮播图，按次序上传，图片格式支持JPEG/JPG/PNG， 图片尺寸长宽比1：1且尺寸不低于480px，图片大小最高1MB</param>
        /// <param name="cat_id">叶子类目ID</param>
        /// <param name="cost_template_id">物流运费模板ID，可使用pdd.logistics.template.get获取</param>
        /// <param name="country_id">国家ID，country_id可以通过pdd.goods.country.get获取，仅在goods_type为2、3时（海淘商品）入参生效，其余goods_type传0</param>
        /// <param name="detail_gallery">商品详情图： a. 尺寸要求宽度处于480~1200px之间，高度0-1500px之间 b. 大小1M以内 c. 数量限制在20张之间 d. 图片格式仅支持JPG,PNG格式 e. 点击上传时，支持批量上传详情图</param>
        /// <param name="goods_desc">商品描述， 字数限制：20-500</param>
        /// <param name="goods_name">商品标题</param>
        /// <param name="goods_type">1-国内普通商品，2-进口，3-直供（保税），4-直邮 ,5-流量 ,6-话费 ,7-优惠券 ,8-QQ充值 ,9-加油卡，15-商家卡券，19-平台卡券</param>
        /// <param name="is_folt">是否支持假一赔十，false-不支持，true-支持</param>
        /// <param name="is_pre_sale">是否预售,true-预售商品，false-非预售商品</param>
        /// <param name="is_refundable">是否7天无理由退换货，true-支持，false-不支持</param>
        /// <param name="market_price">市场价格，单位为分</param>
        /// <param name="second_hand">是否二手商品，true -二手商品 ，false-全新商品</param>
        /// <param name="shipment_limit_second">承诺发货时间（ 秒），普通、进口商品可选48小时或24小时；直邮、直供商品只能入参120小时；is_pre_sale为true时不必传</param>
        /// <param name="sku_list">sku对象列表</param>
        /// <returns></returns>
        public string GoodAdd(string[] carousel_gallery, long cat_id,long cost_template_id,int country_id,string[] detail_gallery,string goods_desc,string goods_name,int goods_type,bool is_folt,bool is_pre_sale,bool is_refundable,long market_price,bool second_hand,long shipment_limit_second,PDDSku[] sku_list)
        {
            List<string> pars = PubPars;
            _type = "pdd.goods.add";
            pars.Add(Helper.ParUrlStr("type", _type));
            //业务参数传参
            pars.Add(Helper.ParUrlStr("carousel_gallery", carousel_gallery));
            pars.Add(Helper.ParUrlStr("cat_id", cat_id.ToString()));
            pars.Add(Helper.ParUrlStr("cost_template_id", cost_template_id.ToString()));
            pars.Add(Helper.ParUrlStr("country_id", country_id.ToString()));
            pars.Add(Helper.ParUrlStr("detail_gallery", detail_gallery));
            pars.Add(Helper.ParUrlStr("goods_desc", goods_desc));
            pars.Add(Helper.ParUrlStr("goods_name", goods_name));
            pars.Add(Helper.ParUrlStr("goods_type", goods_type.ToString()));
            pars.Add(Helper.ParUrlStr("is_folt", is_folt.ToString()));
            pars.Add(Helper.ParUrlStr("is_pre_sale", goods_type.ToString()));
            pars.Add(Helper.ParUrlStr("is_refundable", is_folt.ToString()));
            pars.Add(Helper.ParUrlStr("market_price", market_price.ToString()));
            pars.Add(Helper.ParUrlStr("second_hand", second_hand.ToString()));
            pars.Add(Helper.ParUrlStr("market_price", market_price.ToString()));
            pars.Add(Helper.ParUrlStr("shipment_limit_second", shipment_limit_second.ToString()));
            string SkuListStr = string.Empty;
            foreach (var item in sku_list)
            {
                string SkuStr = string.Empty;
                SkuStr += "{is_onsale=" + item.is_onsale.ToString();
                SkuStr += ",limit_quantity=" + item.limit_quantity.ToString();
                SkuStr += ",multi_price" + item.multi_price.ToString();
                SkuStr += ",out_sku_sn" + item.out_sku_sn+"}";
                SkuListStr += SkuListStr.Length > 0 ? "," + SkuStr : SkuStr;
            }
            pars.Add(Helper.ParUrlStr("sku_list", "["+SkuListStr+"]"));
            //获取结果
            return GetResultStr(pars);
        }

        public string GetGoodList(int page=1,int page_size=100,int is_onsale=1,string outer_id,string goods_name,string outer_goods_id,)
        {

        }
    }
}
