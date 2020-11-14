using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.OperateCategorieVMs
{
    public partial class OperateCategorieBatchVM : BaseBatchVM<OperateCategorie, OperateCategorie_BatchEdit>
    {
        public OperateCategorieBatchVM()
        {
            ListVM = new OperateCategorieListVM();
            LinkedVM = new OperateCategorie_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class OperateCategorie_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
