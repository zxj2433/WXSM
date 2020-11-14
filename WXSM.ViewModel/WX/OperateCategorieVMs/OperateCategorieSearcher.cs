using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.OperateCategorieVMs
{
    public partial class OperateCategorieSearcher : BaseSearcher
    {
        [Display(Name = "父分类编码")]
        public String parent_code { get; set; }

        protected override void InitVM()
        {
        }

    }
}
