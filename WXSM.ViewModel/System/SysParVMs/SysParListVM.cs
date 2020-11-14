using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.System.SysParVMs
{
    public partial class SysParListVM : BasePagedListVM<SysPar_View, SysParSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.Create, Localizer["Create"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "System",dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.Details, Localizer["Details"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.Import, Localizer["Import"],"System", dialogWidth: 800),
                this.MakeStandardAction("SysPar", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"System"),
            };
        }

        protected override IEnumerable<IGridColumn<SysPar_View>> InitGridHeader()
        {
            return new List<GridColumn<SysPar_View>>{
                this.MakeGridHeader(x => x.parTitle),
                this.MakeGridHeader(x => x.parValue),
                this.MakeGridHeader(x => x.remark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SysPar_View> GetSearchQuery()
        {
            var query = DC.Set<SysPar>()
                .CheckEqual(Searcher.parTitle, x=>x.parTitle)
                .Select(x => new SysPar_View
                {
				    ID = x.ID,
                    parTitle = x.parTitle,
                    parValue = x.parValue,
                    remark = x.remark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SysPar_View : SysPar{

    }
}
