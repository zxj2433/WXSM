using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class Area:TopBasePoco
    {
        [Key]
        public new int ID { get; set; }
        [Display(Name ="地址")]
        [StringLength(1000)]
        public string name { get; set; }
        public Area parent { get; set; }
        [Display(Name = "父ID")]
        public int? parentID { get; set; }
        [Display(Name = "更新时间")]
        public DateTime updatetime { get; set; } = DateTime.Now;
        [NotMapped]
        public List<Area> areas { get; set; } = new List<Area>();
    }
}
