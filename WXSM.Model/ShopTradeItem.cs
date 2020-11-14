using System;
using WXSM.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public class ShopTradeItem:TopBasePoco
    {
        [Display(Name ="������")]
        [StringLength(50)]
        public string outItemId{get;set;}
        [Display(Name = "��Ʒ����")]
        [StringLength(50)]
        public int? itemID{get;set;}
        public ShopItem item { get; set; }
        [Display(Name ="���")]
        public string SKU { get; set; }
        [Display(Name ="����")]
        public string sDesc { get; set; }
        [Display(Name = "ʵ��")]
        public double salePrice{get;set; }
        [Display(Name = "����")]
        public double listPrice{get;set;}
        [Display(Name = "�µ�����")]
        public int purchaseQuantity{get;set;}
        [Display(Name ="��������")]
        public int alcQty { get; set; }
        public TradeOrder Order{get;set;}
        public Guid OrderID{get;set;}
    }
}