using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ShopItem:BasePoco
    {
        [NotMapped]
        public List<ShopItem> shop_items { get; set; }
        [NotMapped]
        public List<SubErro> subErrors { get; set; } 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int ID { get; set; }
        [Display(Name = "商品编码")]
        public int item_id { get; set; }
        [Display(Name = "外部商品编码")]
        [StringLength(100)]
        public string out_item_id { get; set; }
        [Display(Name = "标题")]
        [StringLength(500)]
        public string title { get; set; }
        [Display(Name = "卖点")]
        [StringLength(1000)]
        public string selling_points { get; set; }
        [Display(Name = "免运费")]
        public bool? freight_free { get; set; }
        [Display(Name = "运费")]
        public int? freight { get; set; }
        [Display(Name = "预售")]
        public bool? presell { get; set; }
        [Display(Name = "预售结束时间")]
        public DateTime? presell_time { get; set; }
        [Display(Name = "上架")]
        public bool? on_shelf { get; set; }
        [Display(Name = "库存")]
        public int? stock { get; set; }
        [Display(Name = "码洋")]
        public double? list_price { get; set; }
        [Display(Name = "套装类型")]
        [StringLength(100)]
        public string complex_type { get; set; }
        [Display(Name = "ISBN")]
        [StringLength(100)]
        public string barcode { get; set; }
        [Display(Name = "营销分类")]
        [StringLength(100)]
        public string oc_code { get; set; }
        [Display(Name = "营销分类名")]
        [StringLength(100)]
        public string oc_name { get; set; }
        [Display(Name = "店铺分类")]
        [StringLength(100)]
        public string sc_code { get; set; }
        [Display(Name = "店铺分类名")]
        [StringLength(100)]
        public string sc_name { get; set; }
        public List<ShopItemImage> shop_item_images { get; set; }
        public  ShopItemAttribute shop_item_attribute { get; set; }
        public int? shop_item_attributeID { get; set; }
        public ShopItemPrice shop_item_price { get; set; }
        public int? shop_item_priceitem_id { get; set; }
        public ShopItemStock Stock { get; set; }
        public int? Stockitem_id { get; set; }
    }
}
