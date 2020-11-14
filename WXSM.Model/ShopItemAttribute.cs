using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace WXSM.Model
{
    public class ShopItemAttribute:TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int ID { get; set; }
        [Display(Name = "主编推荐")]
        public string editor_recommendation { get; set; }
        [Display(Name = "内容简介")]
        public string content_introduce { get; set; }
        [Display(Name = "目录")]
        public string catalog { get; set; }
        [Display(Name = "摘要")]
        public string digest { get; set; }
        [Display(Name = "作者简介")]
        public string author_introduce { get; set; }
        [Display(Name = "精彩内容")]
        public string preface { get; set; }
        [Display(Name = "媒体评论")]
        public string media_comment { get; set; }
        [Display(Name = "商品描述")]
        public string description { get; set; }
        [Display(Name = "作者")]
        public string author { get; set; }
        [Display(Name = "版次")]
        [StringLength(1000)]
        public string edition { get; set; }
        [Display(Name = "印次")]
        [StringLength(1000)]
        public string impression { get; set; }
        [Display(Name = "出版社")]
        [StringLength(1000)]
        public string publish_house { get; set; }
        [Display(Name = "出版日期")]
        public DateTime? publish_date { get; set; }
        [Display(Name = "印刷时间")]
        public DateTime? printing_date { get; set; }
        [Display(Name = "开本")]
        [StringLength(1000)]
        public string size { get; set; }
        [Display(Name = "装帧")]
        [StringLength(1000)]
        public string binding { get; set; }
        [Display(Name = "字数")]
        [StringLength(1000)]
        public string words_num { get; set; }
        [Display(Name = "页数")]
        [StringLength(1000)]
        public string page_num { get; set; }
        [Display(Name = "中图法")]
        [StringLength(1000)]
        public string clc { get; set; }        
    }
}
