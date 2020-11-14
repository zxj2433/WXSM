using System;
using System.Collections.Generic;
using System.Text;

namespace API.PDD.Model
{
    public class PDDSku
    {
        /// <summary>
        /// 上架状态，0=已下架，1=上架中
        /// </summary>
        public int is_onsale { get; set; }
        /// <summary>
        /// sku购买限制，只入参999
        /// </summary>
        public long limit_quantity { get; set; }
        /// <summary>
        /// 商品团购价格
        /// </summary>
        public long multi_price { get; set; }
        /// <summary>
        /// 商品sku外部编码，同其他接口中的outer_id 、out_id、out_sku_sn、outer_sku_sn、out_sku_id、outer_sku_id 都为商家编码（sku维度）
        /// </summary>
        public string out_sku_sn { get; set; }
        /// <summary>
        /// 商品单买价格
        /// </summary>
        public long price { get; set; }
        /// <summary>
        /// 商品sku库存初始数量，后续库存update只使用stocks.update接口进行调用
        /// </summary>
        public long quantity { get; set; }
        /// <summary>
        /// 商品规格列表，根据pdd.goods.spec.id.get生成的规格属性id，例如：颜色规格下商家新增白色和黑色，大小规格下商家新增L和XL，则由4种spec组合，入参一种组合即可，在skulist中需要有4个spec组合的sku，示例：[20,5]
        /// </summary>
        public string spec_id_list { get; set; }
        /// <summary>
        /// sku 缩略图
        /// </summary>
        public string thumb_url { get; set; }
        /// <summary>
        /// 重量，单位为g
        /// </summary>
        public long weight { get; set; }

    }
}
