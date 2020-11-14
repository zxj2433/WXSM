using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ShopTradeItemVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ShopTradeItemControllerTest
    {
        private ShopTradeItemController _controller;
        private string _seed;

        public ShopTradeItemControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ShopTradeItemController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ShopTradeItemListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ShopTradeItemVM));

            ShopTradeItemVM vm = rv.Model as ShopTradeItemVM;
            ShopTradeItem v = new ShopTradeItem();
			
            v.itemId = Additem();
            v.salePrice = 70;
            v.listPrice = 12;
            v.purchaseQuantity = 39;
            v.OrderID = AddOrder();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopTradeItem>().FirstOrDefault();
				
                Assert.AreEqual(data.salePrice, 70);
                Assert.AreEqual(data.listPrice, 12);
                Assert.AreEqual(data.purchaseQuantity, 39);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ShopTradeItem v = new ShopTradeItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.itemId = Additem();
                v.salePrice = 70;
                v.listPrice = 12;
                v.purchaseQuantity = 39;
                v.OrderID = AddOrder();
                context.Set<ShopTradeItem>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopTradeItemVM));

            ShopTradeItemVM vm = rv.Model as ShopTradeItemVM;
            v = new ShopTradeItem();
            v.ID = vm.Entity.ID;
       		
            v.salePrice = 8;
            v.listPrice = 46;
            v.purchaseQuantity = 74;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.itemId", "");
            vm.FC.Add("Entity.salePrice", "");
            vm.FC.Add("Entity.listPrice", "");
            vm.FC.Add("Entity.purchaseQuantity", "");
            vm.FC.Add("Entity.OrderID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopTradeItem>().FirstOrDefault();
 				
                Assert.AreEqual(data.salePrice, 8);
                Assert.AreEqual(data.listPrice, 46);
                Assert.AreEqual(data.purchaseQuantity, 74);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ShopTradeItem v = new ShopTradeItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.itemId = Additem();
                v.salePrice = 70;
                v.listPrice = 12;
                v.purchaseQuantity = 39;
                v.OrderID = AddOrder();
                context.Set<ShopTradeItem>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopTradeItemVM));

            ShopTradeItemVM vm = rv.Model as ShopTradeItemVM;
            v = new ShopTradeItem();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopTradeItem>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ShopTradeItem v = new ShopTradeItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.itemId = Additem();
                v.salePrice = 70;
                v.listPrice = 12;
                v.purchaseQuantity = 39;
                v.OrderID = AddOrder();
                context.Set<ShopTradeItem>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ShopTradeItem v1 = new ShopTradeItem();
            ShopTradeItem v2 = new ShopTradeItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.itemId = Additem();
                v1.salePrice = 70;
                v1.listPrice = 12;
                v1.purchaseQuantity = 39;
                v1.OrderID = AddOrder();
                v2.itemId = v1.itemId; 
                v2.salePrice = 8;
                v2.listPrice = 46;
                v2.purchaseQuantity = 74;
                v2.OrderID = v1.OrderID; 
                context.Set<ShopTradeItem>().Add(v1);
                context.Set<ShopTradeItem>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ShopTradeItemBatchVM));

            ShopTradeItemBatchVM vm = rv.Model as ShopTradeItemBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopTradeItem>().Count(), 0);
            }
        }

        private Int32 Additem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 28;
                v.item_id = 23;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddtradeConsignee()
        {
            ShopTradeConsignee v = new ShopTradeConsignee();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.country = 15;
                v.province = 4;
                v.city = 13;
                v.district = 20;
                v.town = 35;
                context.Set<ShopTradeConsignee>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddtradeInvoice()
        {
            ShopTradeInvoice v = new ShopTradeInvoice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                context.Set<ShopTradeInvoice>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddOrder()
        {
            TradeOrder v = new TradeOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 74;
                v.listPrice = 58;
                v.salePrice = 85;
                v.deliveryFee = 19;
                v.tradeConsigneeID = AddtradeConsignee();
                v.tradeInvoiceID = AddtradeInvoice();
                context.Set<TradeOrder>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
