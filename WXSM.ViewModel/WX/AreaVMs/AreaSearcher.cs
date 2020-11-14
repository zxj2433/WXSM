using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.AreaVMs
{
    public partial class AreaSearcher : BaseSearcher
    {
        [Display(Name = "地址")]
        public String name { get; set; }
        [Display(Name = "父ID")]
        public Int32? parent_id { get; set; }

        protected override void InitVM()
        {
        }

    }
}
