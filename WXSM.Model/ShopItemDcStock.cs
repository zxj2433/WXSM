using System;
using System.Collections.Generic;
using System.Text;

namespace WXSM.Model
{
    public class ShopItemDcStock
    {

        public int item_id { get; set; }
        public DcStpck dc_stocks { get; set; }
        public List<ShopItemDcStock> shop_items_dc_stocks { get; set; }
    }
    public class DcStpck
    {
        public string stock_type { get; set; }
        public int stock { get; set; }
    }
}
