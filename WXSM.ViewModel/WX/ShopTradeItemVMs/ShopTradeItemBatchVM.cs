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
    public partial class ShopTradeItemBatchVM : BaseBatchVM<ShopTradeItem, ShopTradeItem_BatchEdit>
    {
        public ShopTradeItemBatchVM()
        {
            ListVM = new ShopTradeItemListVM();
            LinkedVM = new ShopTradeItem_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ShopTradeItem_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
