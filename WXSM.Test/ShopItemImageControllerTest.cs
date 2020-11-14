using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.ShopItemImageVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class ShopItemImageControllerTest
    {
        private ShopItemImageController _controller;
        private string _seed;

        public ShopItemImageControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ShopItemImageController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ShopItemImageListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemImageVM));

            ShopItemImageVM vm = rv.Model as ShopItemImageVM;
            ShopItemImage v = new ShopItemImage();
			
            v.ShopItemID = AddShopItem();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemImage>().FirstOrDefault();
				
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ShopItemImage v = new ShopItemImage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemImage>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemImageVM));

            ShopItemImageVM vm = rv.Model as ShopItemImageVM;
            v = new ShopItemImage();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ShopItemID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ShopItemImage>().FirstOrDefault();
 				
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ShopItemImage v = new ShopItemImage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemImage>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemImageVM));

            ShopItemImageVM vm = rv.Model as ShopItemImageVM;
            v = new ShopItemImage();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemImage>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ShopItemImage v = new ShopItemImage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ShopItemID = AddShopItem();
                context.Set<ShopItemImage>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ShopItemImage v1 = new ShopItemImage();
            ShopItemImage v2 = new ShopItemImage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ShopItemID = AddShopItem();
                v2.ShopItemID = v1.ShopItemID; 
                context.Set<ShopItemImage>().Add(v1);
                context.Set<ShopItemImage>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ShopItemImageBatchVM));

            ShopItemImageBatchVM vm = rv.Model as ShopItemImageBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ShopItemImage>().Count(), 0);
            }
        }

        private Int32 AddShopItem()
        {
            ShopItem v = new ShopItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 42;
                v.item_id = 20;
                context.Set<ShopItem>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
