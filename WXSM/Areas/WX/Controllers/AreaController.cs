using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using WXSM.ViewModel.WX.AreaVMs;
using WXSM.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WXSM.Controllers
{
    [Area("WX")]
    [ActionDescription("地址")]
    public partial class AreaController : BaseController
    {
        #region Search
        [ActionDescription("Search")]
        public ActionResult Index()
        {
            var vm = CreateVM<AreaListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Search")]
        [HttpPost]
        public string Search(AreaListVM vm)
        {
            if (ModelState.IsValid)
            {
                return vm.GetJson(false);
            }
            else
            {
                return vm.GetError();
            }
        }

        #endregion

        #region Create
        [ActionDescription("Create")]
        public ActionResult Create()
        {
            var vm = CreateVM<AreaVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Create")]
        public ActionResult Create(AreaVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region Import
		[ActionDescription("Import")]
        public ActionResult Import()
        {
            var vm = CreateVM<AreaImportVM>();
            Task.Run(() => vm.BatchSaveData());
            return FFResult().RefreshGrid().Alert("正在开始更新地址库");
        }
        #endregion

        [ActionDescription("Export")]
        [HttpPost]
        public IActionResult ExportExcel(AreaListVM vm)
        {
            return vm.GetExportData();
        }

        public IActionResult GetAreas(string id)
        {
            var query = DC.Set<Area>().Where(r => r.parentID == int.Parse(id)).Select(r => new ComboSelectListItem
            {
                Selected = false,
                Text = r.name,
                Value = r.ID
            });
            return Json(query.ToList());
        }

    }
}
