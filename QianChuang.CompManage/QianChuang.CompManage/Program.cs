using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return
                Host.CreateDefaultBuilder(args)
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                     logging.AddWTMLogger();
                 })
                .UseSerilog((hostContext, loggerConfiguration) =>
                {

                    var configs = hostContext.Configuration.Get<Configs>();

                    // 这一部分是配置Sql Server的Sink
                    string connectionString = configs.Connections.SingleOrDefault(a => a.Key == "default")?.Value;// 数据库连接字符串

                    var sinkOption = new SinkOptions()
                    {
                        AutoCreateSqlTable = true,
                        TableName = "FrameworkLogs",
                    };
                    var columnOptions = new ColumnOptions();
                    // 输出模板，Sql Server不能用这个
                    const string outputTemplate = "[{Timestamp:HH:mm:ss.FFF} {Level}] {Message} ({SourceContext:l}){NewLine}{Exception}";
                    columnOptions.Store.Add(StandardColumn.LogEvent);
                    loggerConfiguration.MinimumLevel.Information() // 所有Sink的最小记录级别
                        .Enrich.WithProperty("SourceContext", null) //加入属性SourceContext，也就运行时是调用Logger的具体类
                        .Enrich.FromLogContext() //动态加入属性，主要是针对上面的自定义字段User和Class，当然也可以随时加入别的属性。
                        .WriteTo.Console(outputTemplate: outputTemplate)
                        .WriteTo.Debug(
                            outputTemplate: outputTemplate) // 写到VS Output 窗口
                        .WriteTo.File("logs\\log-.log", shared: true,
                            rollingInterval: RollingInterval.Hour,
                            restrictedToMinimumLevel: LogEventLevel.Debug,
                            fileSizeLimitBytes: 10485760,
                            outputTemplate: outputTemplate) // 写到文件，每天一个，最小记录级别是Debug，文件格式是 yyyyMMdd.log

                        // 记录到Sql Server，最小级别是Information
                        .WriteTo.MSSqlServer(connectionString, columnOptions: columnOptions
                            , sinkOptions: sinkOption,
                            restrictedToMinimumLevel: LogEventLevel.Error);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
        }
    }
}
