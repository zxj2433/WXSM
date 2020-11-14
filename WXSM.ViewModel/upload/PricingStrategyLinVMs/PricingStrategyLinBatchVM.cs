using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyLinVMs
{
    public partial class PricingStrategyLinBatchVM : BaseBatchVM<PricingStrategyLin, PricingStrategyLin_BatchEdit>
    {
        public PricingStrategyLinBatchVM()
        {
            ListVM = new PricingStrategyLinListVM();
            LinkedVM = new PricingStrategyLin_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PricingStrategyLin_BatchEdit : BaseVM
    {
        [Display(Name = "商城手续费")]
        public Double? ShopCommission { get; set; }

        protected override void InitVM()
        {
        }

    }

}
