using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ItemPriceDiscountVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ItemPriceDiscountControllerTest
    {
        private ItemPriceDiscountController _controller;
        private string _seed;

        public ItemPriceDiscountControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ItemPriceDiscountController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ItemPriceDiscountListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ItemPriceDiscountVM));

            ItemPriceDiscountVM vm = rv.Model as ItemPriceDiscountVM;
            ItemPriceDiscount v = new ItemPriceDiscount();
			
            v.ID = 23;
            v.item_id = 70;
            v.ShopItemID = AddShopItem();
            v.discount = 88;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ItemPriceDiscount>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 23);
                Assert.AreEqual(data.item_id, 70);
                Assert.AreEqual(data.discount, 88);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ItemPriceDiscount v = new ItemPriceDiscount();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 23;
                v.item_id = 70;
                v.ShopItemID = AddShopItem();
                v.discount = 88;
                context.Set<ItemPriceDiscount>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ItemPriceDiscountVM));

            ItemPriceDiscountVM vm = rv.Model as ItemPriceDiscountVM;
            v = new ItemPriceDiscount();
            v.ID = vm.Entity.ID;
       		
            v.item_id = 42;
            v.discount = 78;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.item_id", "");
            vm.FC.Add("Entity.ShopItemID", "");
            vm.FC.Add("Entity.discount", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ItemPriceDiscount>().FirstOrDefault();
 				
                Assert.AreEqual(data.item_id, 42);
                Assert.AreEqual(data.discount, 78);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ItemPriceDiscount v = new ItemPriceDiscount();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 23;
                v.item_id = 70;
                v.ShopItemID = AddShopItem();
                v.discount = 88;
                context.Set<ItemPriceDiscount>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ItemPriceDiscountVM));

            ItemPriceDiscountVM vm = rv.Model as ItemPriceDiscountVM;
            v = new ItemPriceDiscount();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ItemPriceDiscount>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ItemPriceDiscount v = new ItemPriceDiscount();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 23;
                v.item_id = 70;
                v.ShopItemID = AddShopItem();
                v.discount = 88;
                context.Set<ItemPriceDiscount>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ItemPriceDiscount v1 = new ItemPriceDiscount();
            ItemPriceDiscount v2 = new ItemPriceDiscount();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 23;
                v1.item_id = 70;
                v1.ShopItemID = AddShopItem();
                v1.discount = 88;
                v2.item_id = 42;
                v2.ShopItemID = v1.ShopItemID; 
                v2.discount = 78;
                context.Set<ItemPriceDiscount>().Add(v1);
                context.Set<ItemPriceDiscount>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ItemPriceDiscountBatchVM));

            ItemPriceDiscountBatchVM vm = rv.Model as ItemPriceDiscountBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ItemPriceDiscount>().Count(), 0);
            }
        }

        private Int32 AddShopItem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 6;
                v.item_id = 75;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
