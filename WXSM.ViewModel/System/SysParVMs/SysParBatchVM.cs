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
    public partial class SysParBatchVM : BaseBatchVM<SysPar, SysPar_BatchEdit>
    {
        public SysParBatchVM()
        {
            ListVM = new SysParListVM();
            LinkedVM = new SysPar_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SysPar_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
