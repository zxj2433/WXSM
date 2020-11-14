using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;
using WXSM.ViewModel.WX.ShopItemVMs;
using NPOI.SS.Formula.Functions;
using System.Text.RegularExpressions;

namespace WXSM.ViewModel.WX.TradeOrderVMs
{
    public partial class TradeOrderTemplateVM : BaseTemplateVM
    {
        [Display(Name = "状态")]
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.Status);
        [Display(Name = "订单号")]
        public ExcelPropety outerTrade_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.outerTrade);
        [Display(Name = "销售类型")]
        public ExcelPropety SType_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.SType);
        [Display(Name = "下单时间")]
        public ExcelPropety purchaseTime_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.purchaseTime);
        [Display(Name = "总码洋")]
        public ExcelPropety listPrice_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.listPrice);
        [Display(Name = "配送类型")]
        public ExcelPropety DType_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.DType);
        [Display(Name = "面单信息")]
        public ExcelPropety wayBill_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.wayBill);
        [Display(Name = "缺货方式")]
        public ExcelPropety StockOutOption_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.StockOutOption);
        [Display(Name = "最迟发货时间")]
        public ExcelPropety maxDeliveryTime_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.maxDeliveryTime);
        [Display(Name = "总实洋")]
        public ExcelPropety salePrice_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.salePrice);
        [Display(Name = "运费")]
        public ExcelPropety deliveryFee_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.deliveryFee);
        public ExcelPropety tradeConsignee_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.tradeConsigneeID);
        [Display(Name = "发票类型")]
        public ExcelPropety VType_Excel = ExcelPropety.CreateProperty<TradeOrder>(x => x.VType);

	    protected override void InitVM()
        {
            tradeConsignee_Excel.DataType = ColumnDataType.ComboBox;
            tradeConsignee_Excel.ListItems = DC.Set<ShopTradeConsignee>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ConsigneeInfo);
        }

    }
    
    public class TradeOrderImportVM : BaseImportVM<TradeOrderTemplateVM, TradeOrder>
    {
        [Display(Name ="商城")]
        public ShopMall Mall { get; set; }
        [Display(Name ="缺货处理")]
        public StockOutOption OutOption { get; set; }
        public List<Area> Areas { get; set; }
        public List<ShopItem_View> Items { get; set; }
        public override bool BatchSaveData()
        {
            Areas = DC.Set<Area>().AsNoTracking().Select(r=>new Area { 
                ID=r.ID,
                name=r.name.Replace("省","").Replace("自治区","").Replace("市","").Replace("区","")
                .Replace("县","").Replace("镇","").Replace("壮族",""),
                parentID=r.parentID
            }).ToList();
            FileAttachment fa = DC.Set<FileAttachment>().Where(r => r.ID == this.UploadFileId).FirstOrDefault();
            DataTable dt = HttpHelper.FileHelper.GetTableGB(fa.Path, 0);
            if(Mall==ShopMall.JD)
            {
                DataTable IDs = dt.DefaultView.ToTable(true, "货号");
                List<string> ISBN = IDs.AsEnumerable().Select(r => r.Field<string>("货号")).ToList();
                string ISBNReg = DC.Set<SysPar>().Where(r => r.parTitle == ParType.RegISBN).FirstOrDefault().parValue;
                Regex reg = new Regex(ISBNReg);
                ISBN = ISBN.Select(r => reg.Match(r).Value).Distinct().ToList();
                Items = DC.Set<ShopItem>().AsNoTracking()
                    .Where(r => ISBN.Contains(r.barcode))
                    .Select(r => new ShopItem_View
                    {
                        item_id = r.item_id,
                        title=r.title,
                        barcode = r.barcode,
                        list_price = r.list_price,
                        sale_price = r.shop_item_price.settle_price,
                        stock = r.stock
                    }).ToList();

                DataTable OrderNOs = dt.DefaultView.ToTable(true, "订单号");
                string[] OrderHeaders= {"订单号","付款确认时间", "应付金额", "客户姓名", "客户地址", "联系电话" };
                DataTable OrderList = dt.DefaultView.ToTable(true, OrderHeaders);
                string[] OrderItemsHeaders = { "订单号", "订购数量", "货号", "商品名称", "京东价"};
                DataTable OrderItemLin = dt.DefaultView.ToTable(true, OrderItemsHeaders);
                var orders = (from o in OrderList.AsEnumerable()
                             select new TradeOrder
                             {
                                 ID=Guid.NewGuid(),
                                 Mall=ShopMall.JD,
                                 outerTrade = o.Field<string>("订单号").Trim(),
                                 SType=SellType.NORMAL_SELL,
                                 purchaseTime=DateTime.Parse(o.Field<string>("付款确认时间").Replace("\"","").Trim()),
                                 DType=DeliveryType.EXPRESS,
                                 StockOutOption=StockOutOption.STOCKOUT_CANCEL,
                                 maxDeliveryTime= DateTime.Parse(o.Field<string>("付款确认时间").Replace("\"", "").Trim()).AddHours(48),
                                 deliveryFee=6,
                                 VType=InvoiceType.NOT_NEED,
                                 PayPrice=double.Parse(o.Field<string>("应付金额")),
                                 tradeConsigneeID= GetConsignee(o.Field<string>("客户姓名").Trim(), o.Field<string>("客户地址").Trim(), o.Field<string>("联系电话").Replace("\"","").Trim())
                             }).ToList();
                var orderlin = (from ord in orders
                               join i in OrderItemLin.AsEnumerable() on ord.outerTrade equals i.Field<string>("订单号")
                               select GetItems(ord.ID, ord.outerTrade, reg.Match(i.Field<string>("货号")).Value, i.Field<string>("商品名称"),
                               int.Parse(i.Field<string>("订购数量").Replace("\"","")), double.Parse(i.Field<string>("京东价").Replace("\"","")))).ToList();
                DC.Set<TradeOrder>().AddRange(orders);
                DC.Set<ShopTradeItem>().AddRange(orderlin);
                EntityList = orders;
            }
            return DC.SaveChanges() > 0 ? true : false;
        }
        public Guid? GetConsignee(string ConsigneeName,string Address,string ConsigneePhone)
        {
            var consigne = DC.Set<ShopTradeConsignee>()
                .Where(r => r.consignee == ConsigneeName)
                .Where(r => r.mobile == ConsigneePhone)
                .Where(r => r.address == Address).FirstOrDefault();
            if(consigne!=null)
            {
                return consigne.ID;
            }
            int country, province, city, district, town;
            var provinceArea = Areas.Where(r => r.parentID == 23).Where(r => Address.Contains(r.name)).FirstOrDefault();
            if(provinceArea!=null)
            {
                country = 23;
                province = provinceArea.ID;
            }
            else
            {
                return null;
            }
            city = Areas.Where(r => r.parentID == province).Where(r => Address.Contains(r.name)).FirstOrDefault().ID;
            district= Areas.Where(r => r.parentID == city).Where(r => Address.Contains(r.name)).FirstOrDefault().ID;
            town = Areas.Where(r => r.parentID == district).Where(r => Address.Contains(r.name)).FirstOrDefault().ID;
            var stc=new ShopTradeConsignee()
            {
                ID=Guid.NewGuid(),
                consignee=ConsigneeName,
                mobile=ConsigneePhone,
                email="982834258@qq.com",
                zipCode="100000",
                country=country,
                province=province,
                city=city,
                district=district,
                town=town,
                address=Address
            };
            DC.Set<ShopTradeConsignee>().Add(stc);
            DC.SaveChanges();
            return stc.ID;
        }
        public ShopTradeItem GetItems(Guid OrderID,string OutOrderID,string SKU,string SDesc,int Qty,double skuPrice)
        {
            var item= Items
                .Where(r => SKU==r.barcode)
                .OrderBy(r=>r.sale_price).FirstOrDefault();
            if(item!=null)
            {
                int AlcQty = item.stock >= Qty ? Qty : item.stock.Value; 
                Items.Where(r => r.item_id == item.item_id).First().stock =item.stock-AlcQty ;
                return new ShopTradeItem
                {
                    outItemId = OutOrderID,
                    itemID = item.item_id,
                    SKU = SKU,
                    sDesc=SDesc,
                    purchaseQuantity = Qty,
                    alcQty = AlcQty,
                    OrderID = OrderID
                };
            }
            else
            {
                return new ShopTradeItem
                {
                    outItemId = OutOrderID,
                    SKU = SKU,
                    sDesc = SDesc,
                    purchaseQuantity = Qty,
                    alcQty = 0,
                    OrderID = OrderID
                };
            }
        }

    }

}
