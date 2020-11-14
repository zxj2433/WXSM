using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WXSM.Controllers;
using WXSM.ViewModel.System.SysParVMs;
using WXSM.Model;
using WXSM.DataAccess;

namespace WXSM.Test
{
    [TestClass]
    public class SysParControllerTest
    {
        private SysParController _controller;
        private string _seed;

        public SysParControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SysParController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as SysParListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SysParVM));

            SysParVM vm = rv.Model as SysParVM;
            SysPar v = new SysPar();
			
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SysPar>().FirstOrDefault();
				
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SysPar v = new SysPar();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                context.Set<SysPar>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SysParVM));

            SysParVM vm = rv.Model as SysParVM;
            v = new SysPar();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SysPar>().FirstOrDefault();
 				
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SysPar v = new SysPar();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                context.Set<SysPar>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SysParVM));

            SysParVM vm = rv.Model as SysParVM;
            v = new SysPar();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SysPar>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SysPar v = new SysPar();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<SysPar>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SysPar v1 = new SysPar();
            SysPar v2 = new SysPar();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<SysPar>().Add(v1);
                context.Set<SysPar>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SysParBatchVM));

            SysParBatchVM vm = rv.Model as SysParBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SysPar>().Count(), 0);
            }
        }


    }
}
