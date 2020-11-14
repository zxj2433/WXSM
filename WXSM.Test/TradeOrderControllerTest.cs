using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.TradeOrderVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class TradeOrderControllerTest
    {
        private TradeOrderController _controller;
        private string _seed;

        public TradeOrderControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<TradeOrderController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as TradeOrderListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(TradeOrderVM));

            TradeOrderVM vm = rv.Model as TradeOrderVM;
            TradeOrder v = new TradeOrder();
			
            v.ID = 65;
            v.listPrice = 89;
            v.salePrice = 52;
            v.deliveryFee = 14;
            v.tradeConsigneeID = AddtradeConsignee();
            v.tradeInvoiceID = AddtradeInvoice();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TradeOrder>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 65);
                Assert.AreEqual(data.listPrice, 89);
                Assert.AreEqual(data.salePrice, 52);
                Assert.AreEqual(data.deliveryFee, 14);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            TradeOrder v = new TradeOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 65;
                v.listPrice = 89;
                v.salePrice = 52;
                v.deliveryFee = 14;
                v.tradeConsigneeID = AddtradeConsignee();
                v.tradeInvoiceID = AddtradeInvoice();
                context.Set<TradeOrder>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TradeOrderVM));

            TradeOrderVM vm = rv.Model as TradeOrderVM;
            v = new TradeOrder();
            v.ID = vm.Entity.ID;
       		
            v.listPrice = 1;
            v.salePrice = 62;
            v.deliveryFee = 93;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.listPrice", "");
            vm.FC.Add("Entity.salePrice", "");
            vm.FC.Add("Entity.deliveryFee", "");
            vm.FC.Add("Entity.tradeConsigneeID", "");
            vm.FC.Add("Entity.tradeInvoiceID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TradeOrder>().FirstOrDefault();
 				
                Assert.AreEqual(data.listPrice, 1);
                Assert.AreEqual(data.salePrice, 62);
                Assert.AreEqual(data.deliveryFee, 93);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            TradeOrder v = new TradeOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 65;
                v.listPrice = 89;
                v.salePrice = 52;
                v.deliveryFee = 14;
                v.tradeConsigneeID = AddtradeConsignee();
                v.tradeInvoiceID = AddtradeInvoice();
                context.Set<TradeOrder>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TradeOrderVM));

            TradeOrderVM vm = rv.Model as TradeOrderVM;
            v = new TradeOrder();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<TradeOrder>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            TradeOrder v = new TradeOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 65;
                v.listPrice = 89;
                v.salePrice = 52;
                v.deliveryFee = 14;
                v.tradeConsigneeID = AddtradeConsignee();
                v.tradeInvoiceID = AddtradeInvoice();
                context.Set<TradeOrder>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TradeOrder v1 = new TradeOrder();
            TradeOrder v2 = new TradeOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 65;
                v1.listPrice = 89;
                v1.salePrice = 52;
                v1.deliveryFee = 14;
                v1.tradeConsigneeID = AddtradeConsignee();
                v1.tradeInvoiceID = AddtradeInvoice();
                v2.listPrice = 1;
                v2.salePrice = 62;
                v2.deliveryFee = 93;
                v2.tradeConsigneeID = v1.tradeConsigneeID; 
                v2.tradeInvoiceID = v1.tradeInvoiceID; 
                context.Set<TradeOrder>().Add(v1);
                context.Set<TradeOrder>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TradeOrderBatchVM));

            TradeOrderBatchVM vm = rv.Model as TradeOrderBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<TradeOrder>().Count(), 0);
            }
        }

        private Guid AddtradeConsignee()
        {
            ShopTradeConsignee v = new ShopTradeConsignee();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.country = 3;
                v.province = 15;
                v.city = 69;
                v.district = 4;
                v.town = 10;
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


    }
}
