using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ShopItemPrice
    {
        [Display(Name = "结算价格")]
        public double settle_price { get; set; }
        [Display(Name = "建议售价")]
        public double sell_price { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        [NotMapped]
        public List<ShopItemPrice> shop_item_prices { get; set; }
        //public ShopItem ShopItem { get; set; }
        //[ForeignKey("ShopItem")]
        //public int ShopItemID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }
    }
}
