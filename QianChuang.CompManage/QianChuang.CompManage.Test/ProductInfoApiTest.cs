using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using QianChuang.CompManage.Controllers;
using QianChuang.CompManage.ViewModel._Product.ProductInfoVMs;
using QianChuang.CompManage.Model.Product;
using QianChuang.CompManage.DataAccess;

namespace QianChuang.CompManage.Test
{
    [TestClass]
    public class ProductInfoApiTest
    {
        private ProductInfoController _controller;
        private string _seed;

        public ProductInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductInfoVM vm = _controller.Wtm.CreateVM<ProductInfoVM>();
            ProductInfo v = new ProductInfo();
            
            v.Name = "5pgby";
            v.Remark = "TDQt";
            v.FormCode = "vUps1";
            v.Price = 83;
            v.Title = "HODC";
            v.ImageId = AddImage();
            v.Content = "8EZlwC";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductInfo>().Find(v.ID);
                
                Assert.AreEqual(data.Name, "5pgby");
                Assert.AreEqual(data.Remark, "TDQt");
                Assert.AreEqual(data.FormCode, "vUps1");
                Assert.AreEqual(data.Price, 83);
                Assert.AreEqual(data.Title, "HODC");
                Assert.AreEqual(data.Content, "8EZlwC");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProductInfo v = new ProductInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "5pgby";
                v.Remark = "TDQt";
                v.FormCode = "vUps1";
                v.Price = 83;
                v.Title = "HODC";
                v.ImageId = AddImage();
                v.Content = "8EZlwC";
                context.Set<ProductInfo>().Add(v);
                context.SaveChanges();
            }

            ProductInfoVM vm = _controller.Wtm.CreateVM<ProductInfoVM>();
            var oldID = v.ID;
            v = new ProductInfo();
            v.ID = oldID;
       		
            v.Name = "cjJzd8SJw";
            v.Remark = "tuuUJg";
            v.FormCode = "iNQCbf";
            v.Price = 73;
            v.Title = "0jHvbz";
            v.Content = "OXJ";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Remark", "");
            vm.FC.Add("Entity.FormCode", "");
            vm.FC.Add("Entity.Price", "");
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.ImageId", "");
            vm.FC.Add("Entity.Content", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "cjJzd8SJw");
                Assert.AreEqual(data.Remark, "tuuUJg");
                Assert.AreEqual(data.FormCode, "iNQCbf");
                Assert.AreEqual(data.Price, 73);
                Assert.AreEqual(data.Title, "0jHvbz");
                Assert.AreEqual(data.Content, "OXJ");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProductInfo v = new ProductInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "5pgby";
                v.Remark = "TDQt";
                v.FormCode = "vUps1";
                v.Price = 83;
                v.Title = "HODC";
                v.ImageId = AddImage();
                v.Content = "8EZlwC";
                context.Set<ProductInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProductInfo v1 = new ProductInfo();
            ProductInfo v2 = new ProductInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "5pgby";
                v1.Remark = "TDQt";
                v1.FormCode = "vUps1";
                v1.Price = 83;
                v1.Title = "HODC";
                v1.ImageId = AddImage();
                v1.Content = "8EZlwC";
                v2.Name = "cjJzd8SJw";
                v2.Remark = "tuuUJg";
                v2.FormCode = "iNQCbf";
                v2.Price = 73;
                v2.Title = "0jHvbz";
                v2.ImageId = v1.ImageId; 
                v2.Content = "OXJ";
                context.Set<ProductInfo>().Add(v1);
                context.Set<ProductInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProductInfo>().Find(v1.ID);
                var data2 = context.Set<ProductInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddImage()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.FileName = "Nu0bXq3mW";
                v.FileExt = "K0daALmEY";
                v.Path = "d4Oy8YhRJ";
                v.Length = 65;
                v.SaveMode = "JHjF";
                v.ExtraInfo = "eOxlvMvT";
                v.HandlerInfo = "Fs9IW4";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
