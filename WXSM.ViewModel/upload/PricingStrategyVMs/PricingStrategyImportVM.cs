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
    public partial class PricingStrategyTemplateVM : BaseTemplateVM
    {
        [Display(Name = "策略名")]
        public ExcelPropety StrategyName_Excel = ExcelPropety.CreateProperty<PricingStrategy>(x => x.StrategyName);

	    protected override void InitVM()
        {
        }

    }

    public class PricingStrategyImportVM : BaseImportVM<PricingStrategyTemplateVM, PricingStrategy>
    {

    }

}
