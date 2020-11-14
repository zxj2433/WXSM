using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopTradeItemVMs
{
    public partial class ShopTradeItemVM : BaseCRUDVM<ShopTradeItem>
    {
        public List<ComboSelectListItem> Allitems { get; set; }
        public List<ComboSelectListItem> AllOrders { get; set; }

        public ShopTradeItemVM()
        {
            SetInclude(x => x.item);
            SetInclude(x => x.Order);
        }

        protected override void InitVM()
        {
            Allitems = DC.Set<ShopItem>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.barcode);
            AllOrders = DC.Set<TradeOrder>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.outerTrade);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
