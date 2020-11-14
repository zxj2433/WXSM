using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.TradeOrderVMs
{
    public partial class TradeOrderVM : BaseCRUDVM<TradeOrder>
    {
        public List<ComboSelectListItem> AlltradeConsignees { get; set; }

        public TradeOrderVM()
        {
            SetInclude(x => x.tradeConsignee);
        }

        protected override void InitVM()
        {
            AlltradeConsignees = DC.Set<ShopTradeConsignee>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ConsigneeInfo);
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
