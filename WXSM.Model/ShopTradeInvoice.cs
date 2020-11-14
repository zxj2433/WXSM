using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public enum TitleType
    {
        [Display(Name ="����")]
        PERSONAL,
        [Display(Name = "��˾")]
        COMPANY
    }
    public class ShopTradeInvoice:TopBasePoco
    {
        [StringLength(50)]
        public string titleType{get;set;}
        [Display(Name = "̧ͷ����")]
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
        [Display(Name = "��Ʊ̧ͷ")]
        [StringLength(50)]
        public string title{get;set;}
        [Display(Name = "˰��")]
        [StringLength(50)]
        public string registerno{get;set;}
        [Display(Name = "������")]
        [StringLength(50)]
        public string bank{get;set;}
        [Display(Name = "��Ʊ�绰")]
        [StringLength(20)]
        public string phone{get;set;}
        [Display(Name = "��Ʊ��ַ")]
        [StringLength(500)]
        public string address{get;set;}
        [Display(Name = "�������˻�")]
        [StringLength(50)]
        public string bankAccount{get;set;}
    }
}