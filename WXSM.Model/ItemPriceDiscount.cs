using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ItemPriceDiscount:TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int ID { get; set; }
        public int item_id { get; set; }
        [Display(Name ="图书")]
        public ShopItem ShopItem { get; set; }
        [Display(Name = "图书")]
        public int ShopItemID { get; set; }
        [Display(Name = "限价折扣")]
        public double discount { get; set; }
        [Display(Name = "更新时间")]
        public DateTime update_time { get; set; }
        [NotMapped]
        public List<ItemPriceDiscount> items { get; set; } = new List<ItemPriceDiscount>();
        [NotMapped]
        public int total_rows { get; set; }
        [NotMapped]
        public int total_pages { get; set; }
    }
}
