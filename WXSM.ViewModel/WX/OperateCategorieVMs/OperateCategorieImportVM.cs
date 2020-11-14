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
    public partial class OperateCategorieTemplateVM : BaseTemplateVM
    {
        [Display(Name = "分类编码")]
        public ExcelPropety oc_code_Excel = ExcelPropety.CreateProperty<OperateCategorie>(x => x.oc_code);
        [Display(Name = "分类名称")]
        public ExcelPropety oc_name_Excel = ExcelPropety.CreateProperty<OperateCategorie>(x => x.oc_name);
        [Display(Name = "父分类编码")]
        public ExcelPropety parent_code_Excel = ExcelPropety.CreateProperty<OperateCategorie>(x => x.parent_code);
        [Display(Name = "是否是父分类")]
        public ExcelPropety parent_Excel = ExcelPropety.CreateProperty<OperateCategorie>(x => x.parent);

	    protected override void InitVM()
        {
        }

    }

    public class OperateCategorieImportVM : BaseImportVM<OperateCategorieTemplateVM, OperateCategorie>
    {
        public override bool BatchSaveData()
        {
            try
            {
                string appkey = ConfigInfo.AppSettings["appKey"];
                string appSecret = ConfigInfo.AppSettings["appSecret"];
                string token = ConfigInfo.AppSettings["token"];
                Client client = new Client(appkey, appSecret, token);
                OperateCategorie oc = client.Item.GetCategorys();
                DC.Set<OperateCategorie>().AddRange(oc.operate_categories);
                DC.SaveChanges();
                foreach (var item in oc.operate_categories)
                {
                    GetCategorys(client, item.oc_code);
                }
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public void GetCategorys(Client CT,string ocCode)
        {
            OperateCategorie oc = CT.Item.GetCategorys(parentOcCode:ocCode);
            if (oc.operate_categories.Count > 0)
            {
                DC.Set<OperateCategorie>().AddRange(oc.operate_categories);
                DC.SaveChanges();
                foreach (var item in oc.operate_categories)
                {
                    GetCategorys(CT, item.oc_code.ToString());
                }
            }
        }
    }

}
