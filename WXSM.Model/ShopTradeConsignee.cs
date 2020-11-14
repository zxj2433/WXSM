using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
namespace WXSM.Model
{
    public class ShopTradeConsignee:TopBasePoco
    {
        [Display(Name ="��ϵ��")]
        [StringLength(30)]
        [RegularExpression("[^!~@$%^&* ]")]
        public string consignee { get; set; }
        [Display(Name = "��ϵ�绰")]
        [StringLength(11)]
        public string phone { get; set; }
        [Display(Name = "��ϵ�绰")]
        [StringLength(11)]
        public string mobile { get; set; }
        [Display(Name = "����")]
        [StringLength(50)]
        public string email { get; set; }
        [Display(Name = "��������")]
        [StringLength(10)]
        public string zipCode { get; set; }
        [Display(Name = "����")]
        public int country { get; set; }
        [Display(Name = "ʡ")]
        public int province { get; set; }
        [Display(Name = "��")]
        public int city { get; set; }
        [Display(Name = "��")]
        public int district { get; set; }
        [Display(Name = "�ֵ�/����")]
        public int town { get; set; }
        [Display(Name = "��ϸ��ַ")]
        [RegularExpression("[^!~@$%^&*]")]
        [StringLength(500)]
        public string address { get; set; }
        [Display(Name = "��ע")]
        [StringLength(120)]
        [RegularExpression("[^!~@$%^&*]")]
        public string remark { get; set; }
        [NotMapped]
        [Display(Name ="��ϵ��")]
        public string ConsigneeInfo
        {
            get
            {
                return consignee + ":" + mobile+" "+address;
            }
        }
    }
}