using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public enum CommissionType
    {
        /// <summary>
        /// 百分点
        /// </summary>
        [Display(Name ="百分点")]
        Point,
        /// <summary>
        /// 金额
        /// </summary>
        [Display(Name ="金额")]
        Cost
    }
    public class PricingStrategyLin:BasePoco
    {
        [Display(Name ="定价策略")]
        public PricingStrategy PS { get; set; }
        [Display(Name = "定价策略")]
        public Guid PSID { get; set; }
        [Display(Name = "最小金额(包含)")]
        public int MinCost { get; set; }
        [Display(Name = "最大金额(不包含)")]
        public int MaxCost { get; set; }
        [Display(Name = "商城手续费")]
        public double ShopCommission { get; set; }
        [Display(Name = "提成类型")]
        public CommissionType CT { get; set; }
        [Display(Name = "提成")]
        public double OwnCommission { get; set; }
    }
}
