using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopTradeItemVMs
{
    public partial class ShopTradeItemListVM : BasePagedListVM<ShopTradeItem_View, ShopTradeItemSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX",dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.Details, Localizer["Details"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.Import, Localizer["Import"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopTradeItem", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WX"),
            };
        }

        protected override IEnumerable<IGridColumn<ShopTradeItem_View>> InitGridHeader()
        {
            return new List<GridColumn<ShopTradeItem_View>>{
                this.MakeGridHeader(x => x.outItemId),
                this.MakeGridHeader(x => x.barcode_view),
                this.MakeGridHeader(x => x.salePrice),
                this.MakeGridHeader(x => x.listPrice),
                this.MakeGridHeader(x => x.purchaseQuantity),
                this.MakeGridHeader(x => x.outerTrade_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ShopTradeItem_View> GetSearchQuery()
        {
            var query = DC.Set<ShopTradeItem>()
                .CheckEqual(Searcher.itemId, x=>x.itemID)
                .CheckEqual(Searcher.OrderID, x=>x.OrderID)
                .Select(x => new ShopTradeItem_View
                {
				    ID = x.ID,
                    outItemId = x.outItemId,
                    barcode_view = x.item.barcode,
                    salePrice = x.salePrice,
                    listPrice = x.listPrice,
                    purchaseQuantity = x.purchaseQuantity,
                    outerTrade_view = x.Order.outerTrade,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ShopTradeItem_View : ShopTradeItem{
        [Display(Name = "ISBN")]
        public String barcode_view { get; set; }
        [Display(Name = "订单号")]
        public String outerTrade_view { get; set; }

    }
}
