using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ShopItemVMs
{
    public partial class ShopItemTemplateVM : BaseTemplateVM
    {
        [Display(Name = "商品编码")]
        public ExcelPropety item_id_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.item_id);
        [Display(Name = "外部商品编码")]
        public ExcelPropety out_item_id_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.out_item_id);
        [Display(Name = "标题")]
        public ExcelPropety title_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.title);
        [Display(Name = "卖点")]
        public ExcelPropety selling_points_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.selling_points);
        [Display(Name = "免运费")]
        public ExcelPropety freight_free_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.freight_free);
        [Display(Name = "运费")]
        public ExcelPropety freight_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.freight);
        [Display(Name = "预售")]
        public ExcelPropety presell_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.presell);
        [Display(Name = "预售结束时间")]
        public ExcelPropety presell_time_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.presell_time);
        [Display(Name = "上架")]
        public ExcelPropety on_shelf_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.on_shelf);
        [Display(Name = "库存")]
        public ExcelPropety stock_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.stock);
        [Display(Name = "码洋")]
        public ExcelPropety list_price_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.list_price);
        [Display(Name = "套装类型")]
        public ExcelPropety complex_type_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.complex_type);
        [Display(Name = "ISBN")]
        public ExcelPropety barcode_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.barcode);
        [Display(Name = "营销分类")]
        public ExcelPropety oc_code_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.oc_code);
        [Display(Name = "营销分类名")]
        public ExcelPropety oc_name_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.oc_name);
        [Display(Name = "店铺分类")]
        public ExcelPropety sc_code_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.sc_code);
        [Display(Name = "店铺分类名")]
        public ExcelPropety sc_name_Excel = ExcelPropety.CreateProperty<ShopItem>(x => x.sc_name);

	    protected override void InitVM()
        {
        }

    }

    public class ShopItemImportVM : BaseImportVM<ShopItemTemplateVM, ShopItem>
    {
        public void Insert(CancellationTokenSource CTs)
        {
            List<int> IDs = new List<int>();
            //如果是第一次，则创建初始配置
            var page = DC.Set<SysPar>().Where(r => r.parTitle == ParType.itempageNo).FirstOrDefault();
            if(page==null)
            {
                page = new SysPar
                {
                    parTitle = ParType.itempageNo,
                    parValue = "1",
                };
                DC.Set<SysPar>().Add(page);
                DC.Set<SysPar>().Add(new SysPar
                {
                    parTitle = ParType.LastUpdateStockTime,
                    parValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
                DC.SaveChanges();
            }
            //从第一页开始获取ItemID
            int pageno = 1;
            if (int.TryParse(page.parValue, out pageno))
            {
                string appkey = ConfigInfo.AppSettings["appKey"];
                string appSecret = ConfigInfo.AppSettings["appSecret"];
                string token = ConfigInfo.AppSettings["token"];
                Client client = new Client(appkey, appSecret, token);
                List<ShopItem> shopitems = new List<ShopItem>();
                Items itemids = new Items();
                do
                {
                    itemids.Item_ids.Clear();
                    try
                    {
                        itemids = client.Item.ListItemsId(pageno);
                        pageno += 1;
                    }
                    catch (Exception ex)
                    {
                        DoLog(ex.ToString(), ActionLogTypesEnum.Exception);
                    }
                    finally
                    {
                        //保存ID到IDs缓存中
                        IDs.AddRange(itemids.Item_ids);
                        page.parValue = pageno.ToString();
                        DC.UpdateEntity(page);
                        DC.SaveChanges();
                    }
                }
                while (itemids.Item_ids.Count > 0&&!CTs.IsCancellationRequested);
                //IDs去重并导入
                IDs = IDs.Distinct().ToList() ;
                shopitems = IDs.Select(r => new ShopItem
                {
                    ID = r,
                    item_id = r,
                    CreateTime = DateTime.Now
                }).ToList();
                DC.Set<ShopItem>().AddRange(shopitems);
                DC.SaveChanges();
                IDs.Clear();
            }
        }
        public void InitItemInfo()
        {
            var vm = new ShopItemBatchVM();
            vm.CopyContext(this);
            vm.DoInit();
            var Ids = DC.Set<ShopItem>().Where(r => r.barcode== null|| r.barcode.Length == 0).Select(r=>r.item_id).ToList();
            List<string> Items = new List<string>();
            foreach (var item in Ids)
            {
                if(Items.Count>=20)
                {
                    vm.UploadItemsInfo(Items.ToArray());
                    Items.Clear();
                }
                else
                {
                    Items.Add(item.ToString());
                }                
            }
            if(Items.Count>0)
            {
                vm.UploadItemsInfo(Items.ToArray());
            }
        }
    }

}
