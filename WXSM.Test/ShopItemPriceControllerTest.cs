using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ShopItemPriceVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ShopItemPriceControllerTest
    {
        private ShopItemPriceController _controller;
        private string _seed;

        public ShopItemPriceControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ShopItemPriceController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ShopItemPriceListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemPriceVM));

            ShopItemPriceVM vm = rv.Model as ShopItemPriceVM;
            ShopItemPrice v = new ShopItemPrice();
			
            v.settle_price = 0;
            v.sell_price = 20;
            v.ShopItemID = AddShopItem();
            v.ShopItemAttributeID = AddShopItemAttribute();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemPrice>().FirstOrDefault();
				
                Assert.AreEqual(data.settle_price, 0);
                Assert.AreEqual(data.sell_price, 20);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ShopItemPrice v = new ShopItemPrice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.settle_price = 0;
                v.sell_price = 20;
                v.ShopItemID = AddShopItem();
                v.ShopItemAttributeID = AddShopItemAttribute();
                context.Set<ShopItemPrice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemPriceVM));

            ShopItemPriceVM vm = rv.Model as ShopItemPriceVM;
            v = new ShopItemPrice();
            v.ID = vm.Entity.ID;
       		
            v.settle_price = 16;
            v.sell_price = 50;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.settle_price", "");
            vm.FC.Add("Entity.sell_price", "");
            vm.FC.Add("Entity.ShopItemID", "");
            vm.FC.Add("Entity.ShopItemAttributeID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemPrice>().FirstOrDefault();
 				
                Assert.AreEqual(data.settle_price, 16);
                Assert.AreEqual(data.sell_price, 50);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ShopItemPrice v = new ShopItemPrice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.settle_price = 0;
                v.sell_price = 20;
                v.ShopItemID = AddShopItem();
                v.ShopItemAttributeID = AddShopItemAttribute();
                context.Set<ShopItemPrice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemPriceVM));

            ShopItemPriceVM vm = rv.Model as ShopItemPriceVM;
            v = new ShopItemPrice();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemPrice>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ShopItemPrice v = new ShopItemPrice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.settle_price = 0;
                v.sell_price = 20;
                v.ShopItemID = AddShopItem();
                v.ShopItemAttributeID = AddShopItemAttribute();
                context.Set<ShopItemPrice>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ShopItemPrice v1 = new ShopItemPrice();
            ShopItemPrice v2 = new ShopItemPrice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.settle_price = 0;
                v1.sell_price = 20;
                v1.ShopItemID = AddShopItem();
                v1.ShopItemAttributeID = AddShopItemAttribute();
                v2.settle_price = 16;
                v2.sell_price = 50;
                v2.ShopItemID = v1.ShopItemID; 
                v2.ShopItemAttributeID = v1.ShopItemAttributeID; 
                context.Set<ShopItemPrice>().Add(v1);
                context.Set<ShopItemPrice>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemPriceBatchVM));

            ShopItemPriceBatchVM vm = rv.Model as ShopItemPriceBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemPrice>().Count(), 0);
            }
        }

        private Int32 AddShopItem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 8;
                v.item_id = 12;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddShopItem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 22;
                v.item_id = 2;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddShopItemAttribute()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ShopItemID = AddShopItem();
                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
