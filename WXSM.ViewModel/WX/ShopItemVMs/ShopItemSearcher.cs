using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopItemVMs
{
    public partial class ShopItemSearcher : BaseSearcher
    {
        [Display(Name = "卖点")]
        public String selling_points { get; set; }
        [Display(Name = "上架")]
        public Boolean? on_shelf { get; set; }
        [Display(Name = "ISBN")]
        public String barcode { get; set; }
        [Display(Name = "营销分类名")]
        public String oc_name { get; set; }
        [Display(Name ="搜索条件")]
        public string SearchTxt { get; set; }

        protected override void InitVM()
        {
        }

    }
}
