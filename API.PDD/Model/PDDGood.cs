using System;
using System.Collections.Generic;
using System.Text;

namespace API.PDD.Model
{
    class PDDGood
    {
        /// <summary>
        /// 商品轮播图，按次序上传，图片格式支持JPEG/JPG/PNG， 图片尺寸长宽比1：1且尺寸不低于480px，图片大小最高1MB
        /// </summary>
        public string[] carousel_gallery { get; set; }
        /// <summary>
        /// 叶子类目ID
        /// </summary>
        public long cat_id { get; set; }
        /// <summary>
        /// 物流运费模板ID，可使用pdd.logistics.template.get获取
        /// </summary>
        public long cost_template_id { get; set; }
        /// <summary>
        /// 国家ID，country_id可以通过pdd.goods.country.get获取，仅在goods_type为2、3时（海淘商品）入参生效，其余goods_type传0
        /// </summary>
        public int country_id { get; set; }
        /// <summary>
        /// 商品详情图： a. 尺寸要求宽度处于480~1200px之间，高度0-1500px之间 b. 大小1M以内 c. 数量限制在20张之间 d. 图片格式仅支持JPG,PNG格式 e. 点击上传时，支持批量上传详情图
        /// </summary>
        public string[] detail_gallery { get; set; }
        /// <summary>
        /// 商品描述， 字数限制：20-500，例如，新包装，保证产品的口感和新鲜度。单颗独立小包装，双重营养，1斤家庭分享装，更实惠新疆一级骏枣夹核桃仁。
        /// </summary>
        public string goods_desc { get; set; }
        /// <summary>
        /// 商品标题，例如，新疆特产 红满疆枣夹核桃500g
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 1-国内普通商品，2-进口，3-直供（保税），4-直邮 ,5-流量 ,6-话费 ,7-优惠券 ,8-QQ充值 ,9-加油卡，15-商家卡券，19-平台卡券
        /// </summary>
        public int goods_type { get; set; } = 1;
        /// <summary>
        /// 是否支持假一赔十，false-不支持，true-支持
        /// </summary>
        public bool is_folt { get; set; }
        /// <summary>
        /// 是否预售,true-预售商品，false-非预售商品
        /// </summary>
        public bool is_pre_sale { get; set; }
        /// <summary>
        /// 是否7天无理由退换货，true-支持，false-不支持
        /// </summary>
        public bool is_refundable { get; set; }
        /// <summary>
        /// 市场价格，单位为分
        /// </summary>
        public long market_price { get; set; }
        /// <summary>
        /// 是否二手商品，true -二手商品 ，false-全新商品
        /// </summary>
        public bool second_hand { get; set; }
        /// <summary>
        /// 承诺发货时间（ 秒），普通、进口商品可选48小时或24小时；直邮、直供商品只能入参120小时；is_pre_sale为true时不必传
        /// </summary>
        public int shipment_limit_second { get; set; } = 48;
        /// <summary>
        /// sku对象列表,实例
        /// </summary>
        public List<PDDSku> sku_list { get; set; }
        public 



    }
}
