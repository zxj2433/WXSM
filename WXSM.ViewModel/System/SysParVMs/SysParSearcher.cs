using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.System.SysParVMs
{
    public partial class SysParSearcher : BaseSearcher
    {
        [Display(Name = "参数名")]
        public ParType? parTitle { get; set; }

        protected override void InitVM()
        {
        }

    }
}
