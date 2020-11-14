using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    public class User:FrameworkUserBase
    {
        [Display(Name ="级别")]
        public int Level { get; set; }
    }
}
