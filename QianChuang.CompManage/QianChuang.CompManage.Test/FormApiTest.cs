using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using QianChuang.CompManage.Controllers;
using QianChuang.CompManage.ViewModel._Flow.FormVMs;
using QianChuang.CompManage.Model.Flow;
using QianChuang.CompManage.DataAccess;

namespace QianChuang.CompManage.Test
{
    [TestClass]
    public class FormApiTest
    {
        private FormController _controller;
        private string _seed;

        public FormApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FormController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FormSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FormVM vm = _controller.Wtm.CreateVM<FormVM>();
            Form v = new Form();
            
            v.ID = "yRUPBq5y";
            v.Name = "u2VmjdTb";
            v.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Default;
            v.WebId = "z5KAjAS";
            v.Fields = 20;
            v.ContentData = "dEATKet";
            v.ContentParse = "nHMcv";
            v.Content = "UKe3";
            v.SortCode = 9;
            v.DeleteMark = 7;
            v.DbName = "X8tY85R";
            v.Description = "6PkM7wnQ";
            v.OrgId = "7MzMIEv";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Form>().Find(v.ID);
                
                Assert.AreEqual(data.ID, "yRUPBq5y");
                Assert.AreEqual(data.Name, "u2VmjdTb");
                Assert.AreEqual(data.FrmType, QianChuang.CompManage.Model.Flow.FrmTypeEnum.Default);
                Assert.AreEqual(data.WebId, "z5KAjAS");
                Assert.AreEqual(data.Fields, 20);
                Assert.AreEqual(data.ContentData, "dEATKet");
                Assert.AreEqual(data.ContentParse, "nHMcv");
                Assert.AreEqual(data.Content, "UKe3");
                Assert.AreEqual(data.SortCode, 9);
                Assert.AreEqual(data.DeleteMark, 7);
                Assert.AreEqual(data.DbName, "X8tY85R");
                Assert.AreEqual(data.Description, "6PkM7wnQ");
                Assert.AreEqual(data.OrgId, "7MzMIEv");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Form v = new Form();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = "yRUPBq5y";
                v.Name = "u2VmjdTb";
                v.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Default;
                v.WebId = "z5KAjAS";
                v.Fields = 20;
                v.ContentData = "dEATKet";
                v.ContentParse = "nHMcv";
                v.Content = "UKe3";
                v.SortCode = 9;
                v.DeleteMark = 7;
                v.DbName = "X8tY85R";
                v.Description = "6PkM7wnQ";
                v.OrgId = "7MzMIEv";
                context.Set<Form>().Add(v);
                context.SaveChanges();
            }

            FormVM vm = _controller.Wtm.CreateVM<FormVM>();
            var oldID = v.ID;
            v = new Form();
            v.ID = oldID;
       		
            v.Name = "7BqOoLFr4";
            v.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Web;
            v.WebId = "rOJE9NNHE";
            v.Fields = 27;
            v.ContentData = "gibtpSZ";
            v.ContentParse = "XwZkFq";
            v.Content = "C3pUGq";
            v.SortCode = 97;
            v.DeleteMark = 78;
            v.DbName = "xUaNL";
            v.Description = "jXh6LKf";
            v.OrgId = "dbd1";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.FrmType", "");
            vm.FC.Add("Entity.WebId", "");
            vm.FC.Add("Entity.Fields", "");
            vm.FC.Add("Entity.ContentData", "");
            vm.FC.Add("Entity.ContentParse", "");
            vm.FC.Add("Entity.Content", "");
            vm.FC.Add("Entity.SortCode", "");
            vm.FC.Add("Entity.DeleteMark", "");
            vm.FC.Add("Entity.DbName", "");
            vm.FC.Add("Entity.Description", "");
            vm.FC.Add("Entity.OrgId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Form>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "7BqOoLFr4");
                Assert.AreEqual(data.FrmType, QianChuang.CompManage.Model.Flow.FrmTypeEnum.Web);
                Assert.AreEqual(data.WebId, "rOJE9NNHE");
                Assert.AreEqual(data.Fields, 27);
                Assert.AreEqual(data.ContentData, "gibtpSZ");
                Assert.AreEqual(data.ContentParse, "XwZkFq");
                Assert.AreEqual(data.Content, "C3pUGq");
                Assert.AreEqual(data.SortCode, 97);
                Assert.AreEqual(data.DeleteMark, 78);
                Assert.AreEqual(data.DbName, "xUaNL");
                Assert.AreEqual(data.Description, "jXh6LKf");
                Assert.AreEqual(data.OrgId, "dbd1");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Form v = new Form();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = "yRUPBq5y";
                v.Name = "u2VmjdTb";
                v.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Default;
                v.WebId = "z5KAjAS";
                v.Fields = 20;
                v.ContentData = "dEATKet";
                v.ContentParse = "nHMcv";
                v.Content = "UKe3";
                v.SortCode = 9;
                v.DeleteMark = 7;
                v.DbName = "X8tY85R";
                v.Description = "6PkM7wnQ";
                v.OrgId = "7MzMIEv";
                context.Set<Form>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Form v1 = new Form();
            Form v2 = new Form();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = "yRUPBq5y";
                v1.Name = "u2VmjdTb";
                v1.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Default;
                v1.WebId = "z5KAjAS";
                v1.Fields = 20;
                v1.ContentData = "dEATKet";
                v1.ContentParse = "nHMcv";
                v1.Content = "UKe3";
                v1.SortCode = 9;
                v1.DeleteMark = 7;
                v1.DbName = "X8tY85R";
                v1.Description = "6PkM7wnQ";
                v1.OrgId = "7MzMIEv";
                v2.ID = "bmDfnJWL";
                v2.Name = "7BqOoLFr4";
                v2.FrmType = QianChuang.CompManage.Model.Flow.FrmTypeEnum.Web;
                v2.WebId = "rOJE9NNHE";
                v2.Fields = 27;
                v2.ContentData = "gibtpSZ";
                v2.ContentParse = "XwZkFq";
                v2.Content = "C3pUGq";
                v2.SortCode = 97;
                v2.DeleteMark = 78;
                v2.DbName = "xUaNL";
                v2.Description = "jXh6LKf";
                v2.OrgId = "dbd1";
                context.Set<Form>().Add(v1);
                context.Set<Form>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Form>().Find(v1.ID);
                var data2 = context.Set<Form>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
