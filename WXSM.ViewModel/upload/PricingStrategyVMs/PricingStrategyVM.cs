using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyVMs
{
    public partial class PricingStrategyVM : BaseCRUDVM<PricingStrategy>
    {

        public PricingStrategyVM()
        {
        }

        protected override void InitVM()
        {
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
        public double FinialCost(double Price,double SettlePrice)
        {
            PricingStrategyLin psl = DC.Set<PricingStrategyLin>()
                .Where(r => r.PSID == Entity.ID)
                .Where(r => r.MaxCost > Price && r.MinCost <= Price).FirstOrDefault();
            switch(psl?.CT)
            {
                case CommissionType.Cost:
                    return (SettlePrice + psl.OwnCommission) * (1 + psl.ShopCommission);
                case CommissionType.Point:
                    return (SettlePrice / Price + psl.OwnCommission) * Price * (1 + psl.ShopCommission);
                default:
                    throw new Exception("参数不正确,无法计算最终售价");
            }
        }
    }
}
