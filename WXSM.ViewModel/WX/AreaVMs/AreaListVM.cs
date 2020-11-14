using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.WX.AreaVMs
{
    public partial class AreaListVM : BasePagedListVM<Area_View, AreaSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX",dialogWidth: 800),
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.Details, Localizer["Details"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("Area", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WX", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Import, Localizer["Import"],"WX", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WX"),
            };
        }

        protected override IEnumerable<IGridColumn<Area_View>> InitGridHeader()
        {
            return new List<GridColumn<Area_View>>{

                this.MakeGridHeader(x => x.parentArea),
                this.MakeGridHeader(x => x.name),
                this.MakeGridHeader(x => x.updatetime),
                //this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Area_View> GetSearchQuery()
        {
            var query = DC.Set<Area>()
                .Where(r=>r.parent.name.Contains(Searcher.name)||r.name.Contains(Searcher.name)||Searcher.name.Length==0)
                .Select(x => new Area_View
                {
				    ID = x.ID,
                    name = x.name,
                    parentArea = x.parent==null?"国家":x.parent.name,
                    updatetime=x.updatetime
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Area_View : Area{
        [Display(Name ="区域")]
        public string parentArea { get; set; }
    }
}
