using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class TradeWayBill:TopBasePoco
    {
        [Display(Name = "交易单采购单备注")]
        public string CUSTOMER_PURCHASE_ID { get; set; }
        [Display(Name = "是否打印价格信息")]
        public bool DIS_SALESPRICE_ALL { get; set; }=false;
    }
}
