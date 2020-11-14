using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;
using System.Data.Common;

namespace WXSM.ViewModel.WX.ShopItemVMs
{
    public partial class ShopItemListVM : BasePagedListVM<ShopItem_View, ShopItemSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX",dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.Details, Localizer["Details"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.Import, Localizer["Import"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ShopItem", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WX"),
                this.MakeAction("ShopItem","InitData","初始化","",GridActionParameterTypesEnum.NoId,"WX").SetHideOnToolBar(false).SetShowInRow(false),
                this.MakeAction("ShopItem","StartUpdate","自动更新","",GridActionParameterTypesEnum.NoId,"WX").SetHideOnToolBar(false).SetShowInRow(false)
           };
        }


        protected override IEnumerable<IGridColumn<ShopItem_View>> InitGridHeader()
        {
            return new List<GridColumn<ShopItem_View>>{
                this.MakeGridHeader(x => x.item_id),
                //this.MakeGridHeader(x => x.out_item_id),
                this.MakeGridHeader(x => x.title),
                this.MakeGridHeader(x => x.publish_house_view),
                this.MakeGridHeader(x => x.selling_points),
                //this.MakeGridHeader(x => x.freight_free),
                //this.MakeGridHeader(x => x.freight),
                //this.MakeGridHeader(x => x.presell),
                //this.MakeGridHeader(x => x.presell_time),
                this.MakeGridHeader(x => x.on_shelf),
                this.MakeGridHeader(x => x.stock),
                this.MakeGridHeader(x => x.list_price),
                this.MakeGridHeader(x => x.complex_type),
                this.MakeGridHeader(x => x.barcode),
                this.MakeGridHeader(x => x.oc_code),
                this.MakeGridHeader(x => x.oc_name),
                this.MakeGridHeader(x => x.settle_price),
                //this.MakeGridHeader(x => x.sc_name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ShopItem_View> GetSearchQuery()
        {
            var query = DC.Set<ShopItem>()
                .Where(r=>Searcher.SearchTxt.Length>0)
                .Where(r=> r.barcode == Searcher.SearchTxt ||r.title.Contains(Searcher.SearchTxt))
                .CheckEqual(Searcher.on_shelf, x=>x.on_shelf)
                .Select(x => new ShopItem_View
                {
				    ID = x.ID,
                    item_id = x.item_id,
                    out_item_id = x.out_item_id,
                    title = x.title,
                    selling_points = x.selling_points,
                    freight_free = x.freight_free,
                    freight = x.freight,
                    presell = x.presell,
                    presell_time = x.presell_time,
                    on_shelf = x.on_shelf,
                    stock = x.Stock.stock,
                    list_price = x.list_price,
                    complex_type = x.complex_type,
                    barcode = x.barcode,
                    oc_code = x.oc_code,
                    oc_name = x.oc_name,
                    sc_code = x.sc_code,
                    sc_name = x.sc_name,
                    publish_house_view = x.shop_item_attribute.publish_house,
                    sale_price=x.shop_item_price.sell_price,
                    settle_price=x.shop_item_price.settle_price
                })
                .OrderBy(x => x.ID);
            return query;
        }
    }

    public class ShopItem_View : ShopItem{
        [Display(Name = "出版社")]
        public String publish_house_view { get; set; }
        [Display(Name ="售价")]
        public double sale_price { get; set; }
        [Display(Name ="结算价格")]
        public double settle_price { get; set; }
    }
}
