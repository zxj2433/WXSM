using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.ItemPriceDiscountVMs
{
    public partial class ItemPriceDiscountTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }
    }

    public class ItemPriceDiscountImportVM : BaseImportVM<ItemPriceDiscountTemplateVM, ItemPriceDiscount>
    {
        public override bool BatchSaveData()
        {
            string appkey = ConfigInfo.AppSettings["appKey"];
            string appSecret = ConfigInfo.AppSettings["appSecret"];
            string token = ConfigInfo.AppSettings["token"];
            Client client = new Client(appkey, appSecret, token);
            SysPar par= DC.Set<SysPar>().Where(r => r.parTitle == ParType.LastGetItemDiscountPriceTime).FirstOrDefault();
            DateTime CurTime = DateTime.Now;
            List<ItemPriceDiscount> Ipds = new List<ItemPriceDiscount>();
            ItemPriceDiscount ipd = new ItemPriceDiscount();
            int pageNo = 1;
            do
            {
                ipd = client.Item.ListItemDiscount(DateTime.Parse(par.parValue), CurTime, pageNo);
                if (ipd.items.Count > 0)
                {
                    Ipds.AddRange(ipd.items);
                }
                pageNo += 1;
            } while (ipd.items.Count == 50);
            if(Ipds.Count>0)
            {
                Ipds = Ipds.Select(r => new ItemPriceDiscount
                {
                    item_id = r.item_id,
                    ID = r.item_id,
                    ShopItemID = r.item_id,
                    discount = r.discount,
                    update_time = r.update_time
                }).ToList();
                DC.Set<ItemPriceDiscount>().AddRange(Ipds);
                return DC.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
    }

}
