using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.upload.PricingStrategyLinVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class PricingStrategyLinControllerTest
    {
        private PricingStrategyLinController _controller;
        private string _seed;

        public PricingStrategyLinControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PricingStrategyLinController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PricingStrategyLinListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PricingStrategyLinVM));

            PricingStrategyLinVM vm = rv.Model as PricingStrategyLinVM;
            PricingStrategyLin v = new PricingStrategyLin();
			
            v.PSID = AddPS();
            v.MinCost = 50;
            v.MaxCost = 28;
            v.ShopCommission = 10;
            v.OwnCommission = 52;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PricingStrategyLin>().FirstOrDefault();
				
                Assert.AreEqual(data.MinCost, 50);
                Assert.AreEqual(data.MaxCost, 28);
                Assert.AreEqual(data.ShopCommission, 10);
                Assert.AreEqual(data.OwnCommission, 52);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PricingStrategyLin v = new PricingStrategyLin();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PSID = AddPS();
                v.MinCost = 50;
                v.MaxCost = 28;
                v.ShopCommission = 10;
                v.OwnCommission = 52;
                context.Set<PricingStrategyLin>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PricingStrategyLinVM));

            PricingStrategyLinVM vm = rv.Model as PricingStrategyLinVM;
            v = new PricingStrategyLin();
            v.ID = vm.Entity.ID;
       		
            v.MinCost = 46;
            v.MaxCost = 60;
            v.ShopCommission = 62;
            v.OwnCommission = 42;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PSID", "");
            vm.FC.Add("Entity.MinCost", "");
            vm.FC.Add("Entity.MaxCost", "");
            vm.FC.Add("Entity.ShopCommission", "");
            vm.FC.Add("Entity.OwnCommission", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PricingStrategyLin>().FirstOrDefault();
 				
                Assert.AreEqual(data.MinCost, 46);
                Assert.AreEqual(data.MaxCost, 60);
                Assert.AreEqual(data.ShopCommission, 62);
                Assert.AreEqual(data.OwnCommission, 42);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PricingStrategyLin v = new PricingStrategyLin();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PSID = AddPS();
                v.MinCost = 50;
                v.MaxCost = 28;
                v.ShopCommission = 10;
                v.OwnCommission = 52;
                context.Set<PricingStrategyLin>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PricingStrategyLinVM));

            PricingStrategyLinVM vm = rv.Model as PricingStrategyLinVM;
            v = new PricingStrategyLin();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PricingStrategyLin>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PricingStrategyLin v = new PricingStrategyLin();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.PSID = AddPS();
                v.MinCost = 50;
                v.MaxCost = 28;
                v.ShopCommission = 10;
                v.OwnCommission = 52;
                context.Set<PricingStrategyLin>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PricingStrategyLin v1 = new PricingStrategyLin();
            PricingStrategyLin v2 = new PricingStrategyLin();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PSID = AddPS();
                v1.MinCost = 50;
                v1.MaxCost = 28;
                v1.ShopCommission = 10;
                v1.OwnCommission = 52;
                v2.PSID = v1.PSID; 
                v2.MinCost = 46;
                v2.MaxCost = 60;
                v2.ShopCommission = 62;
                v2.OwnCommission = 42;
                context.Set<PricingStrategyLin>().Add(v1);
                context.Set<PricingStrategyLin>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PricingStrategyLinBatchVM));

            PricingStrategyLinBatchVM vm = rv.Model as PricingStrategyLinBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PricingStrategyLin>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PricingStrategyLinListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddPS()
        {
            PricingStrategy v = new PricingStrategy();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                context.Set<PricingStrategy>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
