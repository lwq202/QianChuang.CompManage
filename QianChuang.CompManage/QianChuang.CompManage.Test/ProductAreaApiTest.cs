using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using QianChuang.CompManage.Controllers;
using QianChuang.CompManage.ViewModel._Product.ProductAreaVMs;
using QianChuang.CompManage.Model.Product;
using QianChuang.CompManage.DataAccess;

namespace QianChuang.CompManage.Test
{
    [TestClass]
    public class ProductAreaApiTest
    {
        private ProductAreaController _controller;
        private string _seed;

        public ProductAreaApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductAreaController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductAreaSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductAreaVM vm = _controller.Wtm.CreateVM<ProductAreaVM>();
            ProductArea v = new ProductArea();
            
            v.Province = "5Yo60Pr";
            v.City = "AiLLQfhQ";
            v.AreaName = "ew9";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductArea>().Find(v.ID);
                
                Assert.AreEqual(data.Province, "5Yo60Pr");
                Assert.AreEqual(data.City, "AiLLQfhQ");
                Assert.AreEqual(data.AreaName, "ew9");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProductArea v = new ProductArea();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Province = "5Yo60Pr";
                v.City = "AiLLQfhQ";
                v.AreaName = "ew9";
                context.Set<ProductArea>().Add(v);
                context.SaveChanges();
            }

            ProductAreaVM vm = _controller.Wtm.CreateVM<ProductAreaVM>();
            var oldID = v.ID;
            v = new ProductArea();
            v.ID = oldID;
       		
            v.Province = "6YNh2K";
            v.City = "FOO92g2V";
            v.AreaName = "BgCZA2";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Province", "");
            vm.FC.Add("Entity.City", "");
            vm.FC.Add("Entity.AreaName", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductArea>().Find(v.ID);
 				
                Assert.AreEqual(data.Province, "6YNh2K");
                Assert.AreEqual(data.City, "FOO92g2V");
                Assert.AreEqual(data.AreaName, "BgCZA2");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProductArea v = new ProductArea();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Province = "5Yo60Pr";
                v.City = "AiLLQfhQ";
                v.AreaName = "ew9";
                context.Set<ProductArea>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProductArea v1 = new ProductArea();
            ProductArea v2 = new ProductArea();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Province = "5Yo60Pr";
                v1.City = "AiLLQfhQ";
                v1.AreaName = "ew9";
                v2.Province = "6YNh2K";
                v2.City = "FOO92g2V";
                v2.AreaName = "BgCZA2";
                context.Set<ProductArea>().Add(v1);
                context.Set<ProductArea>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProductArea>().Find(v1.ID);
                var data2 = context.Set<ProductArea>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
