using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyLinVMs
{
    public partial class PricingStrategyLinSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllPSs { get; set; }
        [Display(Name = "定价策略")]
        public Guid? PSID { get; set; }

        protected override void InitVM()
        {
            AllPSs = DC.Set<PricingStrategy>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.StrategyName);
        }

    }
}
