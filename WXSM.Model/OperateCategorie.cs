using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class OperateCategorie:TopBasePoco
    {
        [Display(Name = "分类编码")]
        public string oc_code { get; set; }
        [Display(Name = "分类名称")]
        public string oc_name { get; set; }
        [Display(Name = "父分类编码")]
        public string parent_code { get; set; }
        [Display(Name = "是否是父分类")]
        public bool parent { get; set; }
        public List<OperateCategorie> operate_categories { get; set; } = new List<OperateCategorie>();
    }
}
