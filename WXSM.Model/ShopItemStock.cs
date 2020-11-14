using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ShopItemStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }
        public int stock { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        [NotMapped]
        public List<ShopItemStock> shop_item_stocks { get; set; }
    }
}
