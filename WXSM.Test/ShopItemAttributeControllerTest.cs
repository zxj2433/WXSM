using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ShopItemAttributeVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ShopItemAttributeControllerTest
    {
        private ShopItemAttributeController _controller;
        private string _seed;

        public ShopItemAttributeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ShopItemAttributeController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ShopItemAttributeListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemAttributeVM));

            ShopItemAttributeVM vm = rv.Model as ShopItemAttributeVM;
            ShopItemAttribute v = new ShopItemAttribute();
			
            v.ShopItemID = AddShopItem();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemAttribute>().FirstOrDefault();
				
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemAttributeVM));

            ShopItemAttributeVM vm = rv.Model as ShopItemAttributeVM;
            v = new ShopItemAttribute();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ShopItemID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemAttribute>().FirstOrDefault();
 				
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemAttributeVM));

            ShopItemAttributeVM vm = rv.Model as ShopItemAttributeVM;
            v = new ShopItemAttribute();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemAttribute>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ShopItemAttribute v1 = new ShopItemAttribute();
            ShopItemAttribute v2 = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ShopItemID = AddShopItem();
                v2.ShopItemID = v1.ShopItemID; 
                context.Set<ShopItemAttribute>().Add(v1);
                context.Set<ShopItemAttribute>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemAttributeBatchVM));

            ShopItemAttributeBatchVM vm = rv.Model as ShopItemAttributeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemAttribute>().Count(), 0);
            }
        }

        private Int32 AddShopItem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 27;
                v.item_id = 86;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
