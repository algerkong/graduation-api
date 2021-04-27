using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using PhotoApi.Controllers;
using PhotoApi.ViewModel.VirusVMs;
using PhotoApi.Model;
using PhotoApi.DataAccess;

namespace PhotoApi.Test
{
    [TestClass]
    public class VirusApiTest
    {
        private VirusController _controller;
        private string _seed;

        public VirusApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<VirusController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new VirusSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            VirusVM vm = _controller.CreateVM<VirusVM>();
            Virus v = new Virus();
            
            v.VirusName = "4ezq";
            v.VirusCode = "tSCbuMs";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Virus>().FirstOrDefault();
                
                Assert.AreEqual(data.VirusName, "4ezq");
                Assert.AreEqual(data.VirusCode, "tSCbuMs");
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Virus v = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.VirusName = "4ezq";
                v.VirusCode = "tSCbuMs";
                context.Set<Virus>().Add(v);
                context.SaveChanges();
            }

            VirusVM vm = _controller.CreateVM<VirusVM>();
            var oldID = v.ID;
            v = new Virus();
            v.ID = oldID;
       		
            v.VirusName = "HYU";
            v.VirusCode = "Pcq";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.VirusName", "");
            vm.FC.Add("Entity.VirusCode", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Virus>().FirstOrDefault();
 				
                Assert.AreEqual(data.VirusName, "HYU");
                Assert.AreEqual(data.VirusCode, "Pcq");
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Virus v = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.VirusName = "4ezq";
                v.VirusCode = "tSCbuMs";
                context.Set<Virus>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Virus v1 = new Virus();
            Virus v2 = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.VirusName = "4ezq";
                v1.VirusCode = "tSCbuMs";
                v2.VirusName = "HYU";
                v2.VirusCode = "Pcq";
                context.Set<Virus>().Add(v1);
                context.Set<Virus>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Virus>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
