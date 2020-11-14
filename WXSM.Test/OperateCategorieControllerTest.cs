using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.OperateCategorieVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class OperateCategorieControllerTest
    {
        private OperateCategorieController _controller;
        private string _seed;

        public OperateCategorieControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<OperateCategorieController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as OperateCategorieListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(OperateCategorieVM));

            OperateCategorieVM vm = rv.Model as OperateCategorieVM;
            OperateCategorie v = new OperateCategorie();
			
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OperateCategorie>().FirstOrDefault();
				
            }

        }

        [TestMethod]
        public void EditTest()
        {
            OperateCategorie v = new OperateCategorie();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                context.Set<OperateCategorie>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(OperateCategorieVM));

            OperateCategorieVM vm = rv.Model as OperateCategorieVM;
            v = new OperateCategorie();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OperateCategorie>().FirstOrDefault();
 				
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            OperateCategorie v = new OperateCategorie();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                context.Set<OperateCategorie>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(OperateCategorieVM));

            OperateCategorieVM vm = rv.Model as OperateCategorieVM;
            v = new OperateCategorie();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<OperateCategorie>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            OperateCategorie v = new OperateCategorie();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<OperateCategorie>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            OperateCategorie v1 = new OperateCategorie();
            OperateCategorie v2 = new OperateCategorie();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<OperateCategorie>().Add(v1);
                context.Set<OperateCategorie>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(OperateCategorieBatchVM));

            OperateCategorieBatchVM vm = rv.Model as OperateCategorieBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<OperateCategorie>().Count(), 0);
            }
        }


    }
}
