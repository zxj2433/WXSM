using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public enum TitleType
    {
        [Display(Name ="个人")]
        PERSONAL,
        [Display(Name = "公司")]
        COMPANY
    }
    public class ShopTradeInvoice:TopBasePoco
    {
        [StringLength(50)]
        public string titleType{get;set;}
        [Display(Name = "抬头类型")]
        public TitleType invoiceType {
            get
            {
                if (titleType != null && titleType.Length > 0)
                {
                    TitleType obj;
                    Enum.TryParse(titleType, out obj);
                    return obj;
                }
                else
                {
                    return TitleType.PERSONAL;
                }
            }
            set
            {
                titleType = value.GetEnumDisplayName();
            }
        }
        [Display(Name = "发票抬头")]
        [StringLength(50)]
        public string title{get;set;}
        [Display(Name = "税号")]
        [StringLength(50)]
        public string registerno{get;set;}
        [Display(Name = "开户行")]
        [StringLength(50)]
        public string bank{get;set;}
        [Display(Name = "开票电话")]
        [StringLength(20)]
        public string phone{get;set;}
        [Display(Name = "开票地址")]
        [StringLength(500)]
        public string address{get;set;}
        [Display(Name = "开户行账户")]
        [StringLength(50)]
        public string bankAccount{get;set;}
    }
}