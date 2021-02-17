﻿using Autofac.Extensions.DependencyInjection;
using Infrastructure.Cache;
using Infrastructure.Extensions.AutofacManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OpenAuth.App.SSO;
using OpenAuth.Repository;

namespace OpenAuth.App.Test
{
    public class TestBase
    {
        protected AutofacServiceProvider _autofacServiceProvider;

        [SetUp]
        public void Init()
        {
            var serviceCollection = GetService();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddOptions();
            
            var optionMock = new Mock<IOptions<AppSetting>>();
            optionMock.Setup(x => x.Value).Returns(new AppSetting { DbType = Define.DBTYPE_MYSQL});
            serviceCollection.AddScoped(x => optionMock.Object);

           // 测试my sql
           serviceCollection.AddDbContext<OpenAuthDBContext>(options =>
               options.UseMySql("server=127.0.0.1;user id=root;database=openauthdb;password=000000"));

//            serviceCollection.AddDbContext<OpenAuthDBContext>(options =>
//                options.UseSqlServer("Data Source=.;Initial Catalog=OpenAuthDB;User=sa;Password=000000;Integrated Security=True"));

            var container = AutofacExt.InitForTest(serviceCollection);
            _autofacServiceProvider = new AutofacServiceProvider(container);
            AutofacContainerModule.ConfigServiceProvider(_autofacServiceProvider);
        }

        /// <summary>
        /// 测试框架默认只注入了缓存Cache，配置Option；
        /// 如果在测试的过程中需要模拟登录用户，cookie等信息，需要重写该方法，可以参考TestFlow的写法
        /// </summary>
        public virtual ServiceCollection GetService()
        {
            return  new ServiceCollection();
        }
    }
}
