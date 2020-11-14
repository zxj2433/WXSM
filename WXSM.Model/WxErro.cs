using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WXSM.Model
{
    /// <summary>
    /// 错误信息
    /// </summary>
    public class WxErro: BasePoco
    {
        public string code { get; set; }
        public string errotoken { get; set; }
        public string solution { get; set; }
        public List<SubErro> subErros { get; set; }
    }
    public class SubErro : TopBasePoco
    {
        public string code { get; set; }
        public string message { get; set; }
        public WxErro WxErro { get; set; }
        public Guid WxErroID { get; set; }
    }
}
