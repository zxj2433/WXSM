using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ShopItemImage:TopBasePoco
    {
        [Display(Name = "图片路径")]
        public string winxuan_image_url { get; set; }
        [Display(Name = "图片类型")]
        public string image_type { get; set; }
        [Display(Name = "图片顺序")]
        public int index { get; set; }
        [Display(Name = "商品")]
        public ShopItem ShopItem { get; set; }
        [Display(Name = "商品")]
        public int ShopItemID { get; set; }
    }
}
