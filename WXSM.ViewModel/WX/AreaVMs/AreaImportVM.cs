using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.Model;


namespace WXSM.ViewModel.WX.AreaVMs
{
    public partial class AreaTemplateVM : BaseTemplateVM
    {
	    protected override void InitVM()
        {
        }
    }

    public class AreaImportVM : BaseImportVM<AreaTemplateVM, Area>
    {
        public override bool BatchSaveData()
        {
            try
            {
                
                //清空记录
                while(DC.Set<Area>().Any())
                {
                    Area ars=DC.Set<Area>().OrderByDescending(r=>r.ID).First();
                    if(ars.parent==null&&!DC.Set<Area>().Where(r=>r.parentID==ars.ID).Any())
                    {
                        DC.Set<Area>().Remove(ars);
                        DC.SaveChanges();
                    }
                    else{
                        DeleteAreas(ars.parentID);
                    }
                }

                string appkey = ConfigInfo.AppSettings["appKey"];
                string appSecret = ConfigInfo.AppSettings["appSecret"];
                string token = ConfigInfo.AppSettings["token"];
                Client client = new Client(appkey, appSecret, token);
                //添加国家
                Area Areas = client.Record.getareas("");
                DC.Set<Area>().AddRange(Areas.areas);
                DC.SaveChanges();
                //只导入中国(23)的地址记录
                GetAreas(client,Areas.areas.Where(r=>r.name.Contains("中国")).FirstOrDefault().ID.ToString());
                return true;
            }
            catch (Exception ex)
            {
                DoLog(ex.ToString(), logtype: ActionLogTypesEnum.Exception);
                return false;
            }
        }

        public void GetAreas(Client CT, string AreaNo)
        {           
            Area Areas = CT.Record.getareas(AreaNo);
            if(Areas.areas.Count>0)
            {
                DC.Set<Area>().AddRange(Areas.areas);
                DC.SaveChanges();
                foreach (var item in Areas.areas)
                {
                    GetAreas(CT,item.ID.ToString());
                }
            }
        }
        public void DeleteAreas(int? ID)
        {
            if (ID > 0 && !DC.Set<Area>().Where(r => r.parentID == ID).Any())
            {
                DC.Set<Area>().RemoveRange(DC.Set<Area>().Where(r => r.ID == ID));
                DC.SaveChanges();
            }
            else{
                DeleteAreas(DC.Set<Area>().Where(r => r.parentID == ID).First().ID);
            }
        }
    }

}
