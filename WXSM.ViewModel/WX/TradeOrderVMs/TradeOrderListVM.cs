using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WXSM.Model;


namespace WXSM.ViewModel.WX.TradeOrderVMs
{
    public partial class TradeOrderListVM : BasePagedListVM<TradeOrder_View, TradeOrderSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.Create, Localizer["Create"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WX",dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.Details, Localizer["Details"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.Import, Localizer["Import"],"WX", dialogWidth: 800),
                this.MakeStandardAction("TradeOrder", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WX"),
            };
        }

        protected override IEnumerable<IGridColumn<TradeOrder_View>> InitGridHeader()
        {
            return new List<GridColumn<TradeOrder_View>>{
                this.MakeGridHeader(x => x.Mall),
                this.MakeGridHeader(x => x.Status),
                this.MakeGridHeader(x => x.outerTrade),
                this.MakeGridHeader(x => x.SType),
                this.MakeGridHeader(x => x.purchaseTime),
                this.MakeGridHeader(x => x.listPrice),
                this.MakeGridHeader(x => x.DType),
                this.MakeGridHeader(x => x.wayBill),
                this.MakeGridHeader(x => x.StockOutOption),
                this.MakeGridHeader(x => x.maxDeliveryTime),
                this.MakeGridHeader(x => x.salePrice),
                this.MakeGridHeader(x=>x.OrderQtyFullment),
                this.MakeGridHeader(x => x.deliveryFee),
                this.MakeGridHeader(x => x.ConsigneeInfo_view),
                this.MakeGridHeader(x => x.VType),
                this.MakeGridHeader(x => x.title_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TradeOrder_View> GetSearchQuery()
        {
            var query = DC.Set<TradeOrder>()
                .Select(x => new TradeOrder_View
                {
				    ID = x.ID,
                    Mall=x.Mall,
                    Status = x.Status,
                    outerTrade = x.outerTrade,
                    SType = x.SType,
                    purchaseTime = x.purchaseTime,
                    listPrice = x.listPrice,
                    DType = x.DType,
                    wayBill = x.wayBill,
                    StockOutOption = x.StockOutOption,
                    maxDeliveryTime = x.maxDeliveryTime,
                    salePrice = x.salePrice,
                    deliveryFee = x.deliveryFee,
                    OrderQtyFullment=x.items.Sum(r=>r.alcQty).ToString()+"/"+x.items.Sum(r=>r.purchaseQuantity).ToString(),
                    ConsigneeInfo_view = x.tradeConsignee.ConsigneeInfo,
                    VType = x.VType,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TradeOrder_View : TradeOrder{
        public String ConsigneeInfo_view { get; set; }
        [Display(Name = "发票抬头")]
        public String title_view { get; set; }
        public string OrderQtyFullment { get; set; }

    }
}
