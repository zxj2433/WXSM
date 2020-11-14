using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopTradeItemVMs
{
    public partial class ShopTradeItemTemplateVM : BaseTemplateVM
    {
        [Display(Name = "订单号")]
        public ExcelPropety outItemId_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.outItemId);
        public ExcelPropety item_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.itemID);
        [Display(Name = "实洋")]
        public ExcelPropety salePrice_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.salePrice);
        [Display(Name = "码洋")]
        public ExcelPropety listPrice_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.listPrice);
        [Display(Name = "下单数量")]
        public ExcelPropety purchaseQuantity_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.purchaseQuantity);
        public ExcelPropety Order_Excel = ExcelPropety.CreateProperty<ShopTradeItem>(x => x.OrderID);

	    protected override void InitVM()
        {
            item_Excel.DataType = ColumnDataType.ComboBox;
            item_Excel.ListItems = DC.Set<ShopItem>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.barcode);
            Order_Excel.DataType = ColumnDataType.ComboBox;
            Order_Excel.ListItems = DC.Set<TradeOrder>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.outerTrade);
        }

    }

    public class ShopTradeItemImportVM : BaseImportVM<ShopTradeItemTemplateVM, ShopTradeItem>
    {

    }

}
