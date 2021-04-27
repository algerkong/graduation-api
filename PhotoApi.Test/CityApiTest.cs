using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using PhotoApi.Controllers;
using PhotoApi.ViewModel.CityVMs;
using PhotoApi.Model;
using PhotoApi.DataAccess;

namespace PhotoApi.Test
{
    [TestClass]
    public class CityApiTest
    {
        private CityController _controller;
        private string _seed;

        public CityApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<CityController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new CitySearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            CityVM vm = _controller.CreateVM<CityVM>();
            City v = new City();
            
            v.Name = "46zr";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<City>().FirstOrDefault();
                
                Assert.AreEqual(data.Name, "46zr");
            }
        }

        [TestMethod]
        public void EditTest()
        {
            City v = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "46zr";
                context.Set<City>().Add(v);
                context.SaveChanges();
            }

            CityVM vm = _controller.CreateVM<CityVM>();
            var oldID = v.ID;
            v = new City();
            v.ID = oldID;
       		
            v.Name = "PTwgpCh7";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<City>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "PTwgpCh7");
            }

        }

		[TestMethod]
        public void GetTest()
        {
            City v = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "46zr";
                context.Set<City>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            City v1 = new City();
            City v2 = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "46zr";
                v2.Name = "PTwgpCh7";
                context.Set<City>().Add(v1);
                context.Set<City>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<City>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
