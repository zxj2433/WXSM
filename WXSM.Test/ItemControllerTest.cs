using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ItemVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ItemControllerTest
    {
        private ItemController _controller;
        private string _seed;

        public ItemControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ItemController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ItemListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ItemVM));

            ItemVM vm = rv.Model as ItemVM;
            Item v = new Item();
			
            v.Item_id = 42;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Item>().FirstOrDefault();
				
                Assert.AreEqual(data.Item_id, 42);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Item v = new Item();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Item_id = 42;
                context.Set<Item>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ItemVM));

            ItemVM vm = rv.Model as ItemVM;
            v = new Item();
            v.ID = vm.Entity.ID;
       		
            v.Item_id = 0;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Item_id", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Item>().FirstOrDefault();
 				
                Assert.AreEqual(data.Item_id, 0);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Item v = new Item();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Item_id = 42;
                context.Set<Item>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ItemVM));

            ItemVM vm = rv.Model as ItemVM;
            v = new Item();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Item>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Item v = new Item();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Item_id = 42;
                context.Set<Item>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Item v1 = new Item();
            Item v2 = new Item();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Item_id = 42;
                v2.Item_id = 0;
                context.Set<Item>().Add(v1);
                context.Set<Item>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ItemBatchVM));

            ItemBatchVM vm = rv.Model as ItemBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Item>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ItemListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
