using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.upload.PricingStrategyLinVMs
{
    public partial class PricingStrategyLinTemplateVM : BaseTemplateVM
    {
        [Display(Name = "定价策略")]
        public ExcelPropety PS_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.PSID);
        [Display(Name = "最小金额(包含)")]
        public ExcelPropety MinCost_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.MinCost);
        [Display(Name = "最大金额(不包含)")]
        public ExcelPropety MaxCost_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.MaxCost);
        [Display(Name = "商城手续费")]
        public ExcelPropety ShopCommission_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.ShopCommission);
        [Display(Name = "提成类型")]
        public ExcelPropety CT_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.CT);
        [Display(Name = "提成")]
        public ExcelPropety OwnCommission_Excel = ExcelPropety.CreateProperty<PricingStrategyLin>(x => x.OwnCommission);

	    protected override void InitVM()
        {
            PS_Excel.DataType = ColumnDataType.ComboBox;
            PS_Excel.ListItems = DC.Set<PricingStrategy>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.StrategyName);
        }

    }

    public class PricingStrategyLinImportVM : BaseImportVM<PricingStrategyLinTemplateVM, PricingStrategyLin>
    {

    }

}
