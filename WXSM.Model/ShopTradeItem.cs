using System;
using WXSM.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public class ShopTradeItem:TopBasePoco
    {
        [Display(Name ="订单号")]
        [StringLength(50)]
        public string outItemId{get;set;}
        [Display(Name = "商品编码")]
        [StringLength(50)]
        public int? itemID{get;set;}
        public ShopItem item { get; set; }
        [Display(Name ="书号")]
        public string SKU { get; set; }
        [Display(Name ="书名")]
        public string sDesc { get; set; }
        [Display(Name = "实洋")]
        public double salePrice{get;set; }
        [Display(Name = "码洋")]
        public double listPrice{get;set;}
        [Display(Name = "下单数量")]
        public int purchaseQuantity{get;set;}
        [Display(Name ="分配数量")]
        public int alcQty { get; set; }
        public TradeOrder Order{get;set;}
        public Guid OrderID{get;set;}
    }
}