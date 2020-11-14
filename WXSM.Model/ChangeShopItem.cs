using System;
using System.Collections.Generic;
using System.Text;

namespace WXSM.Model
{
    public class ChangeShopItem
    {
        public int item_id { get; set; }
        public string change_type { get; set; }
        public DateTime change_time { get; set; }
        public List<ChangeShopItem> change_shop_items { get; set; } = new List<ChangeShopItem>();
    }
}
