using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class PricingStrategy:BasePoco
    {
        [Display(Name ="策略名")]
        public string StrategyName { get; set; }
        [Display(Name = "策略明细")]
        public List<PricingStrategyLin> PSLin { get; set; }
    }
}
