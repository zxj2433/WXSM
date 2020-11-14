using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyLinVMs
{
    public partial class PricingStrategyLinVM : BaseCRUDVM<PricingStrategyLin>
    {
        public List<ComboSelectListItem> AllPSs { get; set; }

        public PricingStrategyLinVM()
        {
            SetInclude(x => x.PS);
        }

        protected override void InitVM()
        {
            AllPSs = DC.Set<PricingStrategy>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.StrategyName);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
