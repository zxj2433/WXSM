using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.System.SysParVMs
{
    public partial class SysParTemplateVM : BaseTemplateVM
    {
        [Display(Name = "参数名")]
        public ExcelPropety parTitle_Excel = ExcelPropety.CreateProperty<SysPar>(x => x.parTitle);
        [Display(Name = "参数值")]
        public ExcelPropety parValue_Excel = ExcelPropety.CreateProperty<SysPar>(x => x.parValue);
        [Display(Name = "备注")]
        public ExcelPropety remark_Excel = ExcelPropety.CreateProperty<SysPar>(x => x.remark);

	    protected override void InitVM()
        {
        }

    }

    public class SysParImportVM : BaseImportVM<SysParTemplateVM, SysPar>
    {

    }

}
