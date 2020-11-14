using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ShopItemVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ShopItemControllerTest
    {
        private ShopItemController _controller;
        private string _seed;

        public ShopItemControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ShopItemController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ShopItemListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemVM));

            ShopItemVM vm = rv.Model as ShopItemVM;
            ShopItem v = new ShopItem();
			
            v.item_id = 48;
            v.shop_item_attributeID = Addshop_item_attribute();
            v.shop_item_priceID = Addshop_item_price();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItem>().FirstOrDefault();
				
                Assert.AreEqual(data.item_id, 48);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.item_id = 48;
                v.shop_item_attributeID = Addshop_item_attribute();
                v.shop_item_priceID = Addshop_item_price();
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemVM));

            ShopItemVM vm = rv.Model as ShopItemVM;
            v = new ShopItem();
            v.ID = vm.Entity.ID;
       		
            v.item_id = 93;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.item_id", "");
            vm.FC.Add("Entity.shop_item_attributeID", "");
            vm.FC.Add("Entity.shop_item_priceID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItem>().FirstOrDefault();
 				
                Assert.AreEqual(data.item_id, 93);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.item_id = 48;
                v.shop_item_attributeID = Addshop_item_attribute();
                v.shop_item_priceID = Addshop_item_price();
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemVM));

            ShopItemVM vm = rv.Model as ShopItemVM;
            v = new ShopItem();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItem>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.item_id = 48;
                v.shop_item_attributeID = Addshop_item_attribute();
                v.shop_item_priceID = Addshop_item_price();
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ShopItem v1 = new ShopItem();
            ShopItem v2 = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.item_id = 48;
                v1.shop_item_attributeID = Addshop_item_attribute();
                v1.shop_item_priceID = Addshop_item_price();
                v2.item_id = 93;
                v2.shop_item_attributeID = v1.shop_item_attributeID; 
                v2.shop_item_priceID = v1.shop_item_priceID; 
                context.Set<ShopItem>().Add(v1);
                context.Set<ShopItem>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemBatchVM));

            ShopItemBatchVM vm = rv.Model as ShopItemBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItem>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ShopItemListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid Addshop_item_attribute()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddShopItemAttribute()
        {
            ShopItemAttribute v = new ShopItemAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                context.Set<ShopItemAttribute>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid Addshop_item_price()
        {
            ShopItemPrice v = new ShopItemPrice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.settle_price = 81;
                v.sell_price = 25;
                v.ShopItemAttributeID = AddShopItemAttribute();
                context.Set<ShopItemPrice>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
