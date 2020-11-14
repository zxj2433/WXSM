using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ItemPriceDiscountVMs
{
    public partial class ItemPriceDiscountSearcher : BaseSearcher
    {
        [Display(Name ="查询内容")]
        public string SearchTxt { get; set; }
        protected override void InitVM()
        {
        }

    }
}
