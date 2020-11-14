using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public class ShopTradeConsignee:TopBasePoco
    {
        [Display(Name ="联系人")]
        [StringLength(30)]
        [RegularExpression("[^!~@$%^&* ]")]
        public string consignee { get; set; }
        [Display(Name = "联系电话")]
        [StringLength(11)]
        public string phone { get; set; }
        [Display(Name = "联系电话")]
        [StringLength(11)]
        public string mobile { get; set; }
        [Display(Name = "邮箱")]
        [StringLength(50)]
        public string email { get; set; }
        [Display(Name = "邮政编码")]
        [StringLength(10)]
        public string zipCode { get; set; }
        [Display(Name = "国家")]
        public int country { get; set; }
        [Display(Name = "省")]
        public int province { get; set; }
        [Display(Name = "市")]
        public int city { get; set; }
        [Display(Name = "区")]
        public int district { get; set; }
        [Display(Name = "街道/乡镇")]
        public int town { get; set; }
        [Display(Name = "详细地址")]
        [RegularExpression("[^!~@$%^&*]")]
        [StringLength(500)]
        public string address { get; set; }
        [Display(Name = "备注")]
        [StringLength(120)]
        [RegularExpression("[^!~@$%^&*]")]
        public string remark { get; set; }
        [NotMapped]
        [Display(Name ="联系人")]
        public string ConsigneeInfo
        {
            get
            {
                return consignee + ":" + mobile+" "+address;
            }
        }
    }
}