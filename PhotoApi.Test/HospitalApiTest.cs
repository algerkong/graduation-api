using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using PhotoApi.Controllers;
using PhotoApi.ViewModel.HospitalVMs;
using PhotoApi.Model;
using PhotoApi.DataAccess;

namespace PhotoApi.Test
{
    [TestClass]
    public class HospitalApiTest
    {
        private HospitalController _controller;
        private string _seed;

        public HospitalApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<HospitalController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new HospitalSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            HospitalVM vm = _controller.CreateVM<HospitalVM>();
            Hospital v = new Hospital();
            
            v.Name = "FyGFRip";
            v.LocationId = AddLocation();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().FirstOrDefault();
                
                Assert.AreEqual(data.Name, "FyGFRip");
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "FyGFRip";
                v.LocationId = AddLocation();
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }

            HospitalVM vm = _controller.CreateVM<HospitalVM>();
            var oldID = v.ID;
            v = new Hospital();
            v.ID = oldID;
       		
            v.Name = "5qEoqO";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.LocationId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "5qEoqO");
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "FyGFRip";
                v.LocationId = AddLocation();
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Hospital v1 = new Hospital();
            Hospital v2 = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "FyGFRip";
                v1.LocationId = AddLocation();
                v2.Name = "5qEoqO";
                v2.LocationId = v1.LocationId; 
                context.Set<Hospital>().Add(v1);
                context.Set<Hospital>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Hospital>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddLocation()
        {
            City v = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.Name = "fruZoM";
                context.Set<City>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
