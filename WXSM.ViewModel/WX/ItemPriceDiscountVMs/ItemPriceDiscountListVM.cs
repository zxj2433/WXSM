using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ItemPriceDiscountVMs
{
    public partial class ItemPriceDiscountListVM : BasePagedListVM<ItemPriceDiscount_View, ItemPriceDiscountSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX",dialogWidth: 800),
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.Details, Localizer["Details"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WX", dialogWidth: 800),
                //this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.Import, Localizer["Import"],"WX", dialogWidth: 800),
                this.MakeStandardAction("ItemPriceDiscount", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WX"),
            };
        }

        protected override IEnumerable<IGridColumn<ItemPriceDiscount_View>> InitGridHeader()
        {
            return new List<GridColumn<ItemPriceDiscount_View>>{
                this.MakeGridHeader(x => x.isbn),
                this.MakeGridHeader(x => x.title_view),
                this.MakeGridHeader(x => x.author),
                this.MakeGridHeader(x => x.publish),
                this.MakeGridHeader(x => x.publishdate),
                this.MakeGridHeader(x => x.Price),
                this.MakeGridHeader(x => x.discount),
                this.MakeGridHeader(x => x.stock),
                this.MakeGridHeader(x => x.update_time),
                //this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ItemPriceDiscount_View> GetSearchQuery()
        {
            var query = DC.Set<ItemPriceDiscount>()
                .Where(r=>r.ShopItem.barcode==Searcher.SearchTxt||r.ShopItem.title.Contains(Searcher.SearchTxt)||Searcher.SearchTxt.Length==0)
                .Select(x => new ItemPriceDiscount_View
                {
				    ID = x.ID,
                    item_id = x.item_id,
                    title_view = x.ShopItem.title,
                    isbn=x.ShopItem.barcode,
                    author=x.ShopItem.shop_item_attribute.author,
                    Price=x.ShopItem.shop_item_price.sell_price,
                    stock=x.ShopItem.stock.Value,
                    publish=x.ShopItem.shop_item_attribute.publish_house,
                    publishdate=x.ShopItem.shop_item_attribute.publish_date.Value.ToString("yyyy-MM-dd"),
                    discount = x.discount,
                    update_time = x.update_time,
                })
                .OrderBy(x => x.update_time);
            return query;
        }

    }

    public class ItemPriceDiscount_View : ItemPriceDiscount{
        [Display(Name = "标题")]
        public String title_view { get; set; }
        [Display(Name ="书号")]
        public string isbn { get; set; }
        [Display(Name = "作者")]
        public string author { get; set; }
        [Display(Name = "出版社")]
        public string publish { get; set; }
        [Display(Name = "出版日期")]
        public string publishdate { get; set; }
        [Display(Name = "定价")]
        public double Price { get; set; }
        [Display(Name = "库存")]
        public int stock { get; set; }
    }
}
