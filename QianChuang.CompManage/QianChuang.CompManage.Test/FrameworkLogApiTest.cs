using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using QianChuang.CompManage.Controllers;
using QianChuang.CompManage.ViewModel._Admin.FrameworkLogVMs;
using QianChuang.CompManage.Model.Framework;
using QianChuang.CompManage.DataAccess;

namespace QianChuang.CompManage.Test
{
    [TestClass]
    public class FrameworkLogApiTest
    {
        private FrameworkLogController _controller;
        private string _seed;

        public FrameworkLogApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkLogController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkLogSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkLogVM vm = _controller.Wtm.CreateVM<FrameworkLogVM>();
            FrameworkLog v = new FrameworkLog();
            
            v.ID = 97;
            v.Message = "x8W3";
            v.MessageTemplate = "9BHH6MxB";
            v.Level = "ERbT6w9Zc";
            v.Exception = "q6nt3Si6";
            v.Properties = "DdPv5G";
            v.LogEvent = "a0WeM1qHQ";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkLog>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 97);
                Assert.AreEqual(data.Message, "x8W3");
                Assert.AreEqual(data.MessageTemplate, "9BHH6MxB");
                Assert.AreEqual(data.Level, "ERbT6w9Zc");
                Assert.AreEqual(data.Exception, "q6nt3Si6");
                Assert.AreEqual(data.Properties, "DdPv5G");
                Assert.AreEqual(data.LogEvent, "a0WeM1qHQ");
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkLog v = new FrameworkLog();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 97;
                v.Message = "x8W3";
                v.MessageTemplate = "9BHH6MxB";
                v.Level = "ERbT6w9Zc";
                v.Exception = "q6nt3Si6";
                v.Properties = "DdPv5G";
                v.LogEvent = "a0WeM1qHQ";
                context.Set<FrameworkLog>().Add(v);
                context.SaveChanges();
            }

            FrameworkLogVM vm = _controller.Wtm.CreateVM<FrameworkLogVM>();
            var oldID = v.ID;
            v = new FrameworkLog();
            v.ID = oldID;
       		
            v.Message = "cNS";
            v.MessageTemplate = "ILQiwO";
            v.Level = "oYdtI3dcw";
            v.Exception = "xuGuMw";
            v.Properties = "qfZ9";
            v.LogEvent = "cUu5b";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Message", "");
            vm.FC.Add("Entity.MessageTemplate", "");
            vm.FC.Add("Entity.Level", "");
            vm.FC.Add("Entity.Exception", "");
            vm.FC.Add("Entity.Properties", "");
            vm.FC.Add("Entity.LogEvent", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkLog>().Find(v.ID);
 				
                Assert.AreEqual(data.Message, "cNS");
                Assert.AreEqual(data.MessageTemplate, "ILQiwO");
                Assert.AreEqual(data.Level, "oYdtI3dcw");
                Assert.AreEqual(data.Exception, "xuGuMw");
                Assert.AreEqual(data.Properties, "qfZ9");
                Assert.AreEqual(data.LogEvent, "cUu5b");
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkLog v = new FrameworkLog();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 97;
                v.Message = "x8W3";
                v.MessageTemplate = "9BHH6MxB";
                v.Level = "ERbT6w9Zc";
                v.Exception = "q6nt3Si6";
                v.Properties = "DdPv5G";
                v.LogEvent = "a0WeM1qHQ";
                context.Set<FrameworkLog>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkLog v1 = new FrameworkLog();
            FrameworkLog v2 = new FrameworkLog();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 97;
                v1.Message = "x8W3";
                v1.MessageTemplate = "9BHH6MxB";
                v1.Level = "ERbT6w9Zc";
                v1.Exception = "q6nt3Si6";
                v1.Properties = "DdPv5G";
                v1.LogEvent = "a0WeM1qHQ";
                v2.ID = 14;
                v2.Message = "cNS";
                v2.MessageTemplate = "ILQiwO";
                v2.Level = "oYdtI3dcw";
                v2.Exception = "xuGuMw";
                v2.Properties = "qfZ9";
                v2.LogEvent = "cUu5b";
                context.Set<FrameworkLog>().Add(v1);
                context.Set<FrameworkLog>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkLog>().Find(v1.ID);
                var data2 = context.Set<FrameworkLog>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
