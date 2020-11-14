using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopTradeItemVMs
{
    public partial class ShopTradeItemSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> Allitems { get; set; }
        public int? itemId { get; set; }
        public List<ComboSelectListItem> AllOrders { get; set; }
        public Guid? OrderID { get; set; }

        protected override void InitVM()
        {
            Allitems = DC.Set<ShopItem>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.barcode);
            AllOrders = DC.Set<TradeOrder>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.outerTrade);
        }

    }
}
