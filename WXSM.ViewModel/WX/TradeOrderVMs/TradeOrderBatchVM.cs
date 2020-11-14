using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.TradeOrderVMs
{
    public partial class TradeOrderBatchVM : BaseBatchVM<TradeOrder, TradeOrder_BatchEdit>
    {
        public TradeOrderBatchVM()
        {
            ListVM = new TradeOrderListVM();
            LinkedVM = new TradeOrder_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TradeOrder_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
