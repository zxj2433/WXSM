using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.WX.AreaVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class AreaControllerTest
    {
        private AreaController _controller;
        private string _seed;

        public AreaControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<AreaController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as AreaListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            Area v = new Area();
			
            v.ID = 62;
            v.parent_id = 49;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Area>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 62);
                Assert.AreEqual(data.parent_id, 49);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 62;
                v.parent_id = 49;
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            v = new Area();
            v.ID = vm.Entity.ID;
       		
            v.parent_id = 13;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.parent_id", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Area>().FirstOrDefault();
 				
                Assert.AreEqual(data.parent_id, 13);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 62;
                v.parent_id = 49;
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            v = new Area();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Area>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 62;
                v.parent_id = 49;
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Area v1 = new Area();
            Area v2 = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 62;
                v1.parent_id = 49;
                v2.parent_id = 13;
                context.Set<Area>().Add(v1);
                context.Set<Area>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AreaBatchVM));

            AreaBatchVM vm = rv.Model as AreaBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Area>().Count(), 0);
            }
        }


    }
}
