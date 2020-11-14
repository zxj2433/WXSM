using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyVMs
{
    public partial class PricingStrategyListVM : BasePagedListVM<PricingStrategy_View, PricingStrategySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.Create, Localizer["Create"],"upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.Details, Localizer["Details"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.Import, Localizer["Import"], "upload", dialogWidth: 800),
                this.MakeStandardAction("PricingStrategy", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "upload"),
            };
        }


        protected override IEnumerable<IGridColumn<PricingStrategy_View>> InitGridHeader()
        {
            return new List<GridColumn<PricingStrategy_View>>{
                this.MakeGridHeader(x => x.StrategyName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PricingStrategy_View> GetSearchQuery()
        {
            var query = DC.Set<PricingStrategy>()
                .Select(x => new PricingStrategy_View
                {
				    ID = x.ID,
                    StrategyName = x.StrategyName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PricingStrategy_View : PricingStrategy{

    }
}
