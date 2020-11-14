using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WalkingTec.Mvvm.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WXSM.Model
{
    public enum TradeStatus {
        /// <summary>
        /// 新建
        /// </summary>
        [Display(Name ="新建")]
        NEW,
        /// <summary>
        /// 已创建
        /// </summary>
        [Display(Name = "已创建")]
        CREATED,
        /// <summary>
        /// 确认成功
        /// </summary>
        [Display(Name = "确认成功")]
        CONFIRM_SUCCESS,
        /// <summary>
        /// 等待卖家确认
        /// </summary>
        [Display(Name = "等待卖家确认")]
        WAIT_SELLER_CONFIRM,
        /// <summary>
        /// 等待出库
        /// </summary>
        [Display(Name = "等待出库")]
        WAIT_DELIVERY,
        /// <summary>
        /// 交易取消
        /// </summary>
        [Display(Name = "交易取消")]
        TRADE_CANCEL,
        /// <summary>
        /// 交易完成
        /// </summary>
        [Display(Name = "交易完成")]
        TRADE_COMPLETED,
        /// <summary>
        /// 已作废
        /// </summary>
        [Display(Name = "已作废")]
        INVALID,
        /// <summary>
        /// 等待取消
        /// </summary>
        [Display(Name = "等待取消")]
        WAIT_CANCEL,
        /// <summary>
        /// 正在出库
        /// </summary>
        [Display(Name = "正在出库")]
        DELIVERING,
        /// <summary>
        /// 出库完成
        /// </summary>
        [Display(Name = "出库完成")]
        COMPLETE_DELIVERY
    }
    public enum DeliveryType
    {
        /// <summary>
        /// 快递
        /// </summary>
        [Display(Name = "快递")]
        EXPRESS,
        /// <summary>
        /// 货运
        /// </summary>
        [Display(Name = "货运")]
        SUPPLY
    }
    public enum SellType
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        NORMAL_SELL,
        /// <summary>
        /// 预定
        /// </summary>
        [Display(Name = "预定")]
        RESERVATION
    }
    public enum StockOutOption
    {
        /// <summary>
        /// 缺货取消
        /// </summary>
        [Display(Name = "缺货整单取消")]
        STOCKOUT_CANCEL,
        /// <summary>
        /// 发送有的商品
        /// </summary>
        [Display(Name = "只发有的商品")]
        UTMOST_DELIVERY,
        /// <summary>
        /// 单品缺货取消
        /// </summary>
        [Display(Name = "只取消缺货品")]
        SKU_STOCKOUT_CANCEL
    }
    public enum InvoiceType
    {
        /// <summary>
        /// 不需要
        /// </summary>
        [Display(Name ="不需要")]
        NOT_NEED,
        /// <summary>
        /// 电子发票
        /// </summary>
        [Display(Name = "电子发票")]
        ELECTRONIC_INVOICE
    }
    public enum ShopMall
    {
        /// <summary>
        /// 天猫
        /// </summary>
        [Display(Name = "天猫")]
        TMALL,
        /// <summary>
        /// 京东
        /// </summary>
        [Display(Name = "京东")]
        JD,
        /// <summary>
        /// 拼多多
        /// </summary>
        [Display(Name = "拼多多")]
        PDD,
    }

    public class TradeOrder:TopBasePoco
    {
        [Display(Name ="商城")]
        public ShopMall? Mall { get; set; }
        [StringLength(50)]
        public string wx_trade_id{get;set;}
        [StringLength(50)]
        public string trade_status{get;set;}
        [Display(Name = "状态")]
        public TradeStatus Status{
            get
            {
                if(trade_status!=null&&trade_status.Length>0)
                {
                    TradeStatus obj;
                    Enum.TryParse(trade_status, out obj);
                    return obj;
                }
                else
                {
                    return TradeStatus.NEW;
                }
            }
            set{
                trade_status=value.GetEnumDisplayName();
            }
        }
        [Display(Name = "订单号")]
        [StringLength(50)]
        public string outerTrade { get; set; }
        [StringLength(50)]
        public string sellType{get;set;}

        [Display(Name = "销售类型")]
        public SellType? SType
        {
            get
            {
                if(sellType != null && sellType.Length>0)
                {
                    SellType obj;
                    Enum.TryParse(trade_status, out obj);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                sellType = value.GetEnumDisplayName();
            }
        }
        [Display(Name = "下单时间")]
        public DateTime purchaseTime{get;set;}
        [Display(Name = "总码洋")]
        public double listPrice{get;set;}
        [StringLength(20)]
        public string deliveryType{get;set;}
        [Display(Name = "配送类型")]
        public DeliveryType? DType
        {
            get
            {
                if(deliveryType != null && deliveryType.Length>0)
                {
                    DeliveryType obj;
                    Enum.TryParse(deliveryType, out obj);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                deliveryType = value.GetEnumDisplayName();
            }
        }
        [Display(Name ="面单信息")]
        [StringLength(500)]
        public string wayBill { get; set; }
        [StringLength(50)]
        public string stockOutOption { get; set; }
        [Display(Name = "缺货方式")]
        [NotMapped]
        public StockOutOption StockOutOption {
            get
            {
                if(stockOutOption != null && stockOutOption.Length>0)
                {
                    StockOutOption obj;
                    Enum.TryParse(trade_status, out obj);
                    return obj;
                }
                else
                {
                    return StockOutOption.STOCKOUT_CANCEL;
                }                
            }
            set
            {
                stockOutOption = value.GetEnumDisplayName();
            }
        }
        [Display(Name = "最迟发货时间")]
        public DateTime maxDeliveryTime { get; set; }
        [Display(Name = "发货仓库")]
        [StringLength(50)]
        public string dc { get; set; }
        [Display(Name = "总实洋")]
        public double salePrice{get;set;}
        [Display(Name ="运费")]
        public double deliveryFee{get;set;}

        public List<ShopTradeItem> items{get;set;}
        public ShopTradeConsignee tradeConsignee{get;set;}
        [Display(Name ="收货人信息")]
        public Guid? tradeConsigneeID{get;set;}
        [StringLength(50)]
        public string invoiceType { get; set; }
        [Display(Name = "发票类型")]
        [NotMapped]
        public InvoiceType? VType
        {
            get
            {
                if(invoiceType != null && invoiceType.Length>0)
                {
                    InvoiceType obj;
                    Enum.TryParse(trade_status, out obj);
                    return obj;
                }
               else
                {
                    return InvoiceType.NOT_NEED;
                }
            }
            set
            {
                invoiceType = value.GetEnumDisplayName();
            }
        }
        public double PayPrice { get; set; }

    }
}