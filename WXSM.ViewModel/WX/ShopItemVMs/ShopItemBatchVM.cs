using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;
using Newtonsoft.Json;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace WXSM.ViewModel.WX.ShopItemVMs
{
    public partial class ShopItemBatchVM : BaseBatchVM<ShopItem, ShopItem_BatchEdit>
    {
        public ShopItemBatchVM()
        {
            ListVM = new ShopItemListVM();
            LinkedVM = new ShopItem_BatchEdit();
        }

        public void AutoUpdateIDs()
        {
            while(true)
            {
                var result = GetChangeIDs();
                if(result.Length>0)
                {
                    DoLog(result, ActionLogTypesEnum.Normal);
                }
                Thread.Sleep(1000);
               
            }
        }

        public string GetChangeIDs()
        {
            //获取变更的商品id
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            SysPar sp = DC.Set<SysPar>().Where(r => r.parTitle == ParType.LastUpdateStockTime).FirstOrDefault();
           
            DateTime LastUpdateTime = sp == null || sp.parValue.Length == 0 ? DateTime.Now : DateTime.Parse(sp.parValue);
            if((DateTime.Now-LastUpdateTime).TotalMinutes<=10)
            {
                return string.Empty;
            }
            DateTime CurTime = (DateTime.Now-LastUpdateTime).TotalDays>1? LastUpdateTime.AddHours(1):DateTime.Now;
            ChangeShopItem csi = new ChangeShopItem();

            //变更库存的商品ID            
            List<string> StockChangeIDs = new List<string>();
            int pageNo = 1;
            do
            {
                csi = client.Item.ListItemsStockChange(LastUpdateTime, CurTime, pageNo);
                StockChangeIDs.AddRange(csi.change_shop_items.Select(r => r.item_id.ToString()));
                pageNo += 1;
            }
            while (csi.change_shop_items.Count == 50);
            //变更价格的商品ID
            List<string> PriceChangeIDs = new List<string>();
            pageNo = 1;
            do
            {
                csi = client.Item.ListItemsPriceChange(LastUpdateTime, CurTime, pageNo);
                PriceChangeIDs.AddRange(csi.change_shop_items.Select(r => r.item_id.ToString()));
                pageNo += 1;
            }
            while (csi.change_shop_items.Count == 50);
            //变更信息的商品ID
            List<string> InfoChangeIDs = new List<string>();
            pageNo = 1;
            List<changeType> changeTypes = new List<changeType>();
            changeTypes.Add(changeType.BASEINFO_UPDATE);
            changeTypes.Add(changeType.CLASSIFY_UPDATE);
            changeTypes.Add(changeType.DESCRIPTION_UPDATE);
            changeTypes.Add(changeType.FREIGHT_UPDATE);
            changeTypes.Add(changeType.IMAGE_UPDATE);
            changeTypes.Add(changeType.ON_SHELF);
            changeTypes.Add(changeType.PRESELL_UPDATE);
            changeTypes.Add(changeType.SELLINGPOINTS_UPDATE);
            changeTypes.Add(changeType.TITLE_UPDATE);
            changeTypes.Add(changeType.UNDER_SHELF);
            do
            {
                csi = client.Item.ListItemChange(changeTypes.ToArray(), LastUpdateTime, CurTime, pageNo);
                InfoChangeIDs.AddRange(csi.change_shop_items.Select(r => r.item_id.ToString()));
                pageNo += 1;
            } while (csi.change_shop_items.Count == 50);
            //新上传商品编码
            List<string> UploadIDs = new List<string>();
            changeTypes.Clear();
            pageNo = 1;
            changeTypes.Add(changeType.NEW_UPLOAD);
            do
            {
                csi = client.Item.ListItemChange(changeTypes.ToArray(), LastUpdateTime, CurTime, pageNo);
                UploadIDs.AddRange(csi.change_shop_items.Select(r => r.item_id.ToString()));
                pageNo += 1;
            } while (csi.change_shop_items.Count == 50);
            
            //每次更新20个商品编码
            List<string> PostIDs = new List<string>();
            //上传新品
            foreach (var item in UploadIDs)
            {
                if (PostIDs.Count == 20)
                {
                    UploadItemsInfo(PostIDs.ToArray());
                    PostIDs.Clear();
                }
                else
                {
                    PostIDs.Add(item);
                }
            }
            if (PostIDs.Count > 0)
            {
                UploadItemsInfo(PostIDs.ToArray());
                PostIDs.Clear();
            }
            //更新信息
            foreach (var item in InfoChangeIDs.Distinct())
            {
                if (PostIDs.Count == 20)
                {
                    UpdateItemsInfo(PostIDs.ToArray());
                    PostIDs.Clear();
                }
                else
                {
                    PostIDs.Add(item);
                }
            }
            if (PostIDs.Count > 0)
            {
                UpdateItemsInfo(PostIDs.ToArray());
                PostIDs.Clear();
            }
            //更新价格
            PriceChangeIDs = PriceChangeIDs.Where(r => !InfoChangeIDs.Contains(r)).ToList();
            foreach (var item in PriceChangeIDs.Distinct())
            {
                if (PostIDs.Count == 20)
                {
                    UpdateItemsPrice(PostIDs.ToArray());
                    PostIDs.Clear();
                }
                else
                {
                    PostIDs.Add(item);
                }
            }
            if (PostIDs.Count > 0)
            {
                UpdateItemsPrice(PostIDs.ToArray());
                PostIDs.Clear();
            }
            //库存价格
            StockChangeIDs = StockChangeIDs.Where(r => !InfoChangeIDs.Contains(r)).ToList();
            foreach (var item in StockChangeIDs)
            {
                if (PostIDs.Count == 20)
                {
                    UpdateItemsStock(PostIDs.ToArray());
                    PostIDs.Clear();
                }
                else
                {
                    PostIDs.Add(item);
                }
            }
            if (PostIDs.Count > 0)
            {
                UpdateItemsStock(PostIDs.ToArray());
                PostIDs.Clear();
            }
           
            sp.parValue = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
            DC.UpdateEntity(sp);
            DC.SaveChanges();
            string tempStr="更新了{0}本书价格，{1}本书的库存,{2}本书信息,上传了{3}本新书";
            string msg = string.Format(tempStr, PriceChangeIDs.Count.ToString(), StockChangeIDs.Count.ToString(), InfoChangeIDs.Count.ToString(),UploadIDs.Count.ToString());
            DoLog(msg, ActionLogTypesEnum.Normal);
            return msg;
        }

        public void UpdateItemsPrice(string[] Items)
        {
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            ShopItemPrice sip = client.Item.GetItemsPrice(Items);
            foreach (var item in sip.shop_item_prices)
            {
                if(DC.Set<ShopItemPrice>().Where(r=>r.item_id==item.item_id).Any())
                {
                    DC.Set<ShopItemPrice>().Update(item);
                }
                else
                {
                    DC.Set<ShopItemPrice>().Add(item);
                }
            }
            DC.SaveChanges();
            DC = DC.ReCreate();
        }

        public void UpdateItemsStock(string[] Items)
        {
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            ShopItemStock sis = client.Item.GetItemsStock(Items);
            if (sis == null)
            {
                DoLog("无需要变更的库存", ActionLogTypesEnum.Exception);
                return;
            }
            DateTime CurTime = DateTime.Now;
            foreach (var item in sis.shop_item_stocks)
            {
                if(DC.Set<ShopItemStock>().Where(r=>r.item_id==item.item_id).Any())
                {
                    DC.Set<ShopItemStock>().Update(item);
                }
            }
            DC.SaveChanges();
            DC = DC.ReCreate();
        }

        public void UpdateItemsInfo(string[] items)
        {
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            List<ShopItem> shopitems = client.Item.GetItems(items).shop_items;
            if(shopitems==null)
            {
                DoLog("没有需要更新的数据", ActionLogTypesEnum.Exception);
                return;
            }
            foreach (var item in shopitems)
            {

                    item.ID = item.item_id;
                    item.UpdateBy = LoginUserInfo.ITCode;
                    item.UpdateTime = DateTime.Now;

                    item.shop_item_attribute.ID = item.item_id;
                    if (item.shop_item_images != null && item.shop_item_images.Count > 0)
                    {
                        foreach (var image in item.shop_item_images)
                        {
                            image.ShopItemID = item.item_id;
                        }
                        if (DC.Set<ShopItemImage>().Where(r => r.ShopItemID == item.ID).Any())
                        {
                            DC.Set<ShopItemImage>().RemoveRange(DC.Set<ShopItemImage>().Where(r => r.ShopItemID == item.ID));
                        }
                    }
                    item.shop_item_priceitem_id = item.item_id;
                    item.Stockitem_id = item.item_id;
                    item.Stock = new ShopItemStock
                    {
                        item_id = item.item_id,
                        stock = item.stock.Value,
                        UpdateTime = DateTime.Now
                    };

                if (DC.Set<ShopItem>().Where(r => r.ID == item.item_id).Any())
                {
                    if (item.shop_item_images!= null)
                    {
                        DC.Set<ShopItemImage>().AddRange(item.shop_item_images);
                        item.shop_item_images.Clear();
                    }
                    DC.Set<ShopItem>().Update(item);
                }
            }
            DC.SaveChanges();
            DC = DC.ReCreate();
        }
        //上传新品
        public void UploadItemsInfo(string[] items)
        {
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            var shopitems = client.Item.GetItems(items);
            if(shopitems.shop_items == null&&shopitems.subErrors!=null&&shopitems.subErrors.Count>0)
            {
                DoLog(shopitems.subErrors.FirstOrDefault().message, ActionLogTypesEnum.Exception);
                shopitems = client.Item.GetItems(items);
            }
            if (shopitems.shop_items == null)
            {
                DoLog(shopitems.subErrors.FirstOrDefault().message, ActionLogTypesEnum.Exception);
                return;
            }
            foreach (var item in shopitems.shop_items)
            {
                item.ID = item.item_id;
                item.UpdateBy = LoginUserInfo.ITCode;
                item.UpdateTime = DateTime.Now;      
                if (item.shop_item_attribute!=null)
                {
                    item.shop_item_attribute.ID = item.item_id;
                    item.shop_item_attributeID = item.item_id;
                    //DC.Set<ShopItemAttribute>().Add(item.shop_item_attribute);
                }
                if (item.shop_item_price!=null)
                {
                    item.shop_item_price.item_id = item.item_id;
                    item.shop_item_priceitem_id = item.item_id;
                    //DC.Set<ShopItemPrice>().Add(item.shop_item_price);
                }
                if(item.shop_item_images!=null)
                {
                    foreach (var image in item.shop_item_images)
                    {
                        image.ShopItemID = item.item_id;
                    }
                }
                item.Stock= new ShopItemStock
                {
                    item_id = item.ID,
                    stock = item.stock.Value
                };
                item.Stockitem_id = item.item_id;
                if (DC.Set<ShopItem>().Where(r => r.ID == item.item_id).Any())
                {

                    DC.Set<ShopItem>().Update(item);
                }
                else
                {
                    DC.Set<ShopItem>().Add(item);
                }
                
            }
            DC.SaveChanges(); 
        }

    }

    /// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ShopItem_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
