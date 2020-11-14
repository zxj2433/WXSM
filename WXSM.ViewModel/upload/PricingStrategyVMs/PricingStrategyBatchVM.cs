using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyVMs
{
    public partial class PricingStrategyBatchVM : BaseBatchVM<PricingStrategy, PricingStrategy_BatchEdit>
    {
        public PricingStrategyBatchVM()
        {
            ListVM = new PricingStrategyListVM();
            LinkedVM = new PricingStrategy_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PricingStrategy_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
