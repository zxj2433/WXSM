using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public enum ParType
    {
        /// <summary>
        /// 商品编码当前页
        /// </summary>
        [Display(Name ="商品编码最大页数")]
        itempageNo,
        /// <summary>
        /// 最后更新价格时间
        /// </summary>
        [Display(Name ="最后更新价格时间")]
        LastUpdatePriceTime,
        /// <summary>
        /// 最后更新库存时间
        /// </summary>
        [Display(Name = "最后更新库存时间")]
        LastUpdateStockTime,
        /// <summary>
        /// 最后更新限价时间
        /// </summary>
        [Display(Name ="最后更新限价时间")]
        LastGetItemDiscountPriceTime,
        /// <summary>
        /// 书号筛选正则
        /// </summary>
        [Display(Name ="书号筛选正则")]
        RegISBN

    }
    public class SysPar:TopBasePoco
    {
        [Display(Name ="参数名")]
        public ParType parTitle { get; set; }
        [Display(Name ="参数值")]
        public string parValue { get; set; }
        [Display(Name = "备注")]
        public string remark { get; set; }
    }
}
