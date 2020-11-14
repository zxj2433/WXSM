using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.WX.OperateCategorieVMs
{
    public partial class OperateCategorieListVM : BasePagedListVM<OperateCategorie_View, OperateCategorieSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.Details, Localizer["Details"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.Import, Localizer["Import"], "WX", dialogWidth: 800),
                this.MakeStandardAction("OperateCategorie", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "WX"),
            };
        }


        protected override IEnumerable<IGridColumn<OperateCategorie_View>> InitGridHeader()
        {
            return new List<GridColumn<OperateCategorie_View>>{
                this.MakeGridHeader(x => x.oc_code),
                this.MakeGridHeader(x => x.oc_name),
                this.MakeGridHeader(x => x.parent_code),
                this.MakeGridHeader(x => x.parent),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<OperateCategorie_View> GetSearchQuery()
        {
            var query = DC.Set<OperateCategorie>()
                .CheckContain(Searcher.parent_code, x=>x.parent_code)
                .Select(x => new OperateCategorie_View
                {
				    ID = x.ID,
                    oc_code = x.oc_code,
                    oc_name = x.oc_name,
                    parent_code = x.parent_code,
                    parent = x.parent,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class OperateCategorie_View : OperateCategorie{

    }
}
