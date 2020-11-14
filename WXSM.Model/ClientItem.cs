using System;
using System.Collections.Generic;
using System.Text;
using HttpHelper;
using Newtonsoft.Json;

namespace WXSM.Model
{
    public enum changeType
    {
        /// <summary>
        /// 标题更新
        /// </summary>
        TITLE_UPDATE,
        /// <summary>
        /// 基础信息更新
        /// </summary>
        BASEINFO_UPDATE,
        /// <summary>
        /// 描述更新
        /// </summary>
        DESCRIPTION_UPDATE,
        /// <summary>
        /// 图片更新
        /// </summary>
        IMAGE_UPDATE,
        /// <summary>
        /// 分类更新
        /// </summary>
        CLASSIFY_UPDATE,
        /// <summary>
        /// 运费更新
        /// </summary>
        FREIGHT_UPDATE,
        /// <summary>
        /// 预售更新
        /// </summary>
        PRESELL_UPDATE,
        /// <summary>
        /// 卖点更新
        /// </summary>
        SELLINGPOINTS_UPDATE,
        /// <summary>
        /// 商品上架
        /// </summary>
        ON_SHELF,
        /// <summary>
        /// 商品下架
        /// </summary>
        UNDER_SHELF,
        /// <summary>
        /// 新品上传
        /// </summary>
        NEW_UPLOAD
    }
    public class ClientItem
    {
        private List<string> _pars { get; set; }
        private string _appSecret { get; set; }
        private Uri _RouteUrl { get; set; }
        public ClientItem(List<string> pars,string appSecret,Uri RouteRul)
        {
            _pars = pars;
            _appSecret = appSecret;
            _RouteUrl = RouteRul;
        }

        /// <summary>
        /// 获取商品ID
        /// </summary>
        /// <param name="pageNo">第几页</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <returns></returns>
        public Items ListItemsId(int? pageNo = 1)
        {
            string _method = "winxuan.shop.items.id.list";
            List<string> pars = new List<string>();
            //添加公共参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数
            pars.Add(Helper.ParUrlStr("pageNo", pageNo.ToString()));
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<Items>(result);
        }
        /// <summary>
        /// 批量查询店铺商品详细信息
        /// </summary>
        /// <param name="itemIds">商品id</param>
        /// <param name="fields">需返回的字段</param>
        /// <returns></returns>
        public ShopItem GetItems(string[] itemIds, string[] fields=null)
        {
            string _method = "winxuan.shop.items.get";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数  
            pars.Add(Helper.ParUrlStr("itemIds", itemIds));
            pars.Add(Helper.ParUrlStr("fields", fields));
            //清除无效的空值参数
            pars.Remove(string.Empty);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ShopItem>(Result);
        }
        /// <summary>
        /// 批量查看商品库存
        /// </summary>
        /// <param name="itemIds">文轩商品码</param>
        /// <returns></returns>
        public ShopItemStock GetItemsStock(string[] itemIds)
        {
            string _method = "winxuan.shop.items.stock.get";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数  
            pars.Add(Helper.ParUrlStr("itemIds", itemIds));
            //清除无效的空值参数
            pars.Remove(string.Empty);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ShopItemStock>(Result);
        }
        /// <summary>
        /// 批量查询店铺商品价格信息
        /// </summary>
        /// <param name="Ids">商品id</param>
        /// <returns></returns>
        public ShopItemPrice GetItemsPrice(string[] itemIds)
        {
            string _method = "winxuan.shop.items.price.get";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            //添加业务参数  
            pars.Add(Helper.ParUrlStr("itemIds", itemIds));
            //清除无效的空值参数
            pars.Remove(string.Empty);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ShopItemPrice>(Result);
        }
        /// <summary>
        /// 查询店铺商品信息变动列表
        /// </summary>
        /// <param name="Types">类型数组</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间，不填则默认当前时间</param>
        /// <param name="pageNo">分页页码</param>
        /// <param name="pageSize">分页数量</param>
        /// <returns></returns>
        public ChangeShopItem ListItemChange(changeType[] changeTypes, DateTime changeStartTime, DateTime? changeEndTime, int? pageNo = 1)
        {
            string _method = "winxuan.shop.items.change.list";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));
            List<string> TypeStr = new List<string>();
            foreach (var item in changeTypes)
            {
                TypeStr.Add(item.ToString());
            }
            //添加业务参数  
            pars.Add(Helper.ParUrlStr("changeTypes", TypeStr.ToArray()));
            pars.Add(Helper.ParUrlStr("changeStartTime", changeStartTime == null ? string.Empty : changeStartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("changeEndTime", changeEndTime == null ? string.Empty : changeEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("pageNo", pageNo?.ToString()));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ChangeShopItem>(Result);
        }
        /// <summary>
        /// 查询店铺商品价格变动列表
        /// </summary>
        /// <param name="changeStartTime">变更开始时间</param>
        /// <param name="changeEndTime">变更结束时间</param>
        /// <param name="pageSize">分页数量,默认为50,最大不能超过200</param>
        /// <param name="pageNo">分页页码,默认为1</param>
        /// <returns></returns>
        public ChangeShopItem ListItemsPriceChange(DateTime changeStartTime, DateTime? changeEndTime,int? pageNo = 1)
        {
            string _method = "winxuan.shop.items.price.change.list";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));

            //添加业务参数  
            pars.Add(Helper.ParUrlStr("changeStartTime", changeStartTime == null ? string.Empty : changeStartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("changeEndTime", changeEndTime == null ? string.Empty : changeEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("pageNo", pageNo?.ToString()));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result= Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ChangeShopItem>(Result);
        }
        /// <summary>
        /// 查询店铺商品库存变动列表
        /// </summary>
        /// <param name="changeStartTime">变更开始时间</param>
        /// <param name="changeEndTime">变更结束时间</param>
        /// <param name="pageSize">分页数量,默认为50,最大不能超过200</param>
        /// <param name="pageNo">分页页码,默认为1</param>
        /// <returns></returns>
        public ChangeShopItem ListItemsStockChange(DateTime changeStartTime, DateTime? changeEndTime, int? pageNo = 1)
        {
            string _method = "winxuan.shop.items.stock.change.list";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));

            //添加业务参数  
            pars.Add(Helper.ParUrlStr("changeStartTime", changeStartTime==null?string.Empty:changeStartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("changeEndTime", changeEndTime == null ? string.Empty : changeEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("pageNo", pageNo?.ToString()));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ChangeShopItem>(Result);
        }
        /// <summary>
        /// 查询店铺商品分仓库存
        /// </summary>
        /// <param name="items">商品id(文轩商品编码)，支持多个商品用，号分开</param>
        /// <returns></returns>
        public ShopItemDcStock listItemsDCStock(string[] items)
        {
            string _method = "winxuan.shop.items.dc.list";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));

            //添加业务参数  
            pars.Add(Helper.ParUrlStr("itemIds", items));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ShopItemDcStock>(Result);
        }

        /// <summary>
        /// 查询店铺商品营销分类
        /// </summary>
        /// <param name="items">商品id(文轩商品编码)，支持多个商品用，号分开</param>
        /// <returns></returns>
        public OperateCategorie GetCategorys(string ocCode="",string parentOcCode="")
        {
            string _method = "winxuan.shop.categorys.get";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));

            //添加业务参数  
            pars.Add(Helper.ParUrlStr("ocCode", ocCode));
            pars.Add(Helper.ParUrlStr("parentOcCode", parentOcCode));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<OperateCategorie>(Result);
        }
        /// <summary>
        /// 批量查询限价商品
        /// </summary>
        /// <param name="startTime">开始时间,不能为空,,时间格式为:yyyy-MM-dd HH:mm:ss</param>
        /// <param name="endTime">结束时间,为空,默认为当前时间,时间格式为:yyyy-MM-dd HH:mm:ss,开始时间与结束时间间隔不能超过365天</param>
        /// <param name="pageNo">分页页码,默认为1</param>
        /// <param name="pageSize">分页数量,默认为50,最大不能超过200</param>
        /// <returns></returns>
        public ItemPriceDiscount ListItemDiscount(DateTime startTime,DateTime? endTime,int? pageNo=1)
        {
            string _method = "winxuan.items.limit.discount.list";
            List<string> pars = new List<string>();
            //添加公用参数
            pars.AddRange(_pars);
            pars.Add(Helper.ParUrlStr("method", _method));
            pars.Add(Helper.ParUrlStr("timeStamp", Helper.GetTimestamp(DateTime.Now)));

            //添加业务参数  
            pars.Add(Helper.ParUrlStr("changeStartTime", startTime == null ? string.Empty : startTime.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("changeEndTime", endTime == null ? string.Empty : endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            pars.Add(Helper.ParUrlStr("pageNo", pageNo?.ToString()));
            //清除无效的空值参数
            pars = Helper.EmptyStringClear(pars);
            //生成签名
            string _appSign = Helper.GetSignKey(pars, _appSecret);
            pars.Add(Helper.ParUrlStr("appSign", _appSign));
            //拼接字符串
            string ResultPars = string.Join("&", pars);
            pars.Clear();
            string Result = Helper.Post("application/x-www-form-urlencoded", _RouteUrl, ResultPars);
            return JsonConvert.DeserializeObject<ItemPriceDiscount>(Result);
        }
    }
}
