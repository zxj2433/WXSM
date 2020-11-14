using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyLinVMs
{
    public partial class PricingStrategyLinListVM : BasePagedListVM<PricingStrategyLin_View, PricingStrategyLinSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.Create, Localizer["Create"],"upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.Details, Localizer["Details"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.Import, Localizer["Import"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategyLin", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "upload"),
            };
        }


        protected override IEnumerable<IGridColumn<PricingStrategyLin_View>> InitGridHeader()
        {
            return new List<GridColumn<PricingStrategyLin_View>>{
                this.MakeGridHeader(x => x.StrategyName_view),
                this.MakeGridHeader(x => x.MinCost),
                this.MakeGridHeader(x => x.MaxCost),
                this.MakeGridHeader(x => x.ShopCommission),
                this.MakeGridHeader(x => x.CT),
                this.MakeGridHeader(x => x.OwnCommission),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PricingStrategyLin_View> GetSearchQuery()
        {
            var query = DC.Set<PricingStrategyLin>()
                .CheckEqual(Searcher.PSID, x=>x.PSID)
                .Select(x => new PricingStrategyLin_View
                {
				    ID = x.ID,
                    StrategyName_view = x.PS.StrategyName,
                    MinCost = x.MinCost,
                    MaxCost = x.MaxCost,
                    ShopCommission = x.ShopCommission,
                    CT = x.CT,
                    OwnCommission = x.OwnCommission,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PricingStrategyLin_View : PricingStrategyLin{
        [Display(Name = "策略名")]
        public String StrategyName_view { get; set; }

    }
}
