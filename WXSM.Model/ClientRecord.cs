using HttpHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class ClientRecord
    {
        private List<string> _pars { get; set; }
        private string _appSecret { get; set; }
        private Uri _RouteUrl { get; set; }
        public ClientRecord(List<string> pars, string appSecret, Uri RouteRul)
        {
            _pars = pars;
            _appSecret = appSecret;
            _RouteUrl = RouteRul;
        }

        public Area getareas(string id="")
        {
            string _method = "winxuan.areas.get";
            List<string> pars = new List<string>();
            //添加公共参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数
            pars.Add(Helper.ParUrlStr("id", id));
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            result = result.Replace("_id", "ID").Replace("id","ID");
            return JsonConvert.DeserializeObject<Area>(result);
        }

        public TradeOrder createtrade(TradeOrder Order)
        {
            string _method = "winxuan.shop.trade.create";
            List<string> pars = new List<string>();
            //添加公共参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数
            pars.Add(Helper.ParUrlStr("outerTrade", Order.outerTrade));
            pars.Add(Helper.ParUrlStr("sellType", Order.sellType));
            pars.Add(Helper.ParUrlStr("purchaseTime", Order.purchaseTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("listPrice", Order.listPrice));
            pars.Add(Helper.ParUrlStr("deliveryType", Order.deliveryType));
            pars.Add(Helper.ParUrlStr("wayBill", Order.wayBill));
            pars.Add(Helper.ParUrlStr("stockOutOption", Order.stockOutOption));
            pars.Add(Helper.ParUrlStr("maxDeliveryTime", Order.maxDeliveryTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("dc", Order.dc));
            pars.Add(Helper.ParUrlStr("salePrice", Order.salePrice));
            pars.Add(Helper.ParUrlStr("deliveryFee", Order.deliveryFee));
            pars.Add(Helper.ParUrlStr("invoiceType", Order.invoiceType));
            //添加收件人信息
            pars.Add(Helper.ParUrlStr("tradeConsignee.consignee", Order.tradeConsignee.consignee));
            pars.Add(Helper.ParUrlStr("tradeConsignee.phone", Order.tradeConsignee.phone));
            pars.Add(Helper.ParUrlStr("tradeConsignee.mobile", Order.tradeConsignee.mobile));
            pars.Add(Helper.ParUrlStr("tradeConsignee.email", Order.tradeConsignee.email));
            pars.Add(Helper.ParUrlStr("tradeConsignee.zipCode", Order.tradeConsignee.zipCode));
            pars.Add(Helper.ParUrlStr("tradeConsignee.country", Order.tradeConsignee.country));
            pars.Add(Helper.ParUrlStr("tradeConsignee.province", Order.tradeConsignee.province));
            pars.Add(Helper.ParUrlStr("tradeConsignee.city", Order.tradeConsignee.city));
            pars.Add(Helper.ParUrlStr("tradeConsignee.district", Order.tradeConsignee.district));
            pars.Add(Helper.ParUrlStr("tradeConsignee.town", Order.tradeConsignee.town));
            pars.Add(Helper.ParUrlStr("tradeConsignee.address", Order.tradeConsignee.address));
            pars.Add(Helper.ParUrlStr("tradeConsignee.remark", Order.tradeConsignee.remark));

            for (int i = 0; i < Order.items.Count; i++)
            {
                pars.Add(Helper.ParUrlStr("item["+i.ToString()+ "].outItemId", Order.items[i].outItemId));
                pars.Add(Helper.ParUrlStr("item[" + i.ToString() + "].itemId", Order.items[i].itemID.ToString()));
                pars.Add(Helper.ParUrlStr("item[" + i.ToString() + "].salePrice", Order.items[i].salePrice));
                pars.Add(Helper.ParUrlStr("item[" + i.ToString() + "].listPrice", Order.items[i].listPrice));
                pars.Add(Helper.ParUrlStr("item[" + i.ToString() + "].purchaseQuantity", Order.items[i].purchaseQuantity));
            }
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            result = result.Replace("_id", "ID").Replace("id", "ID");
            TradeOrder OrderResult = JsonConvert.DeserializeObject<TradeOrder>(result);
            Order.wx_trade_id = OrderResult.wx_trade_id;
            Order.trade_status = OrderResult.trade_status;
            return Order;
        }
    }
}
