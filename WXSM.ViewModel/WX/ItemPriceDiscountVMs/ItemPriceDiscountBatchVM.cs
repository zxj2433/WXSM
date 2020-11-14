using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ItemPriceDiscountVMs
{
    public partial class ItemPriceDiscountBatchVM : BaseBatchVM<ItemPriceDiscount, ItemPriceDiscount_BatchEdit>
    {
        public ItemPriceDiscountBatchVM()
        {
            ListVM = new ItemPriceDiscountListVM();
            LinkedVM = new ItemPriceDiscount_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ItemPriceDiscount_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
