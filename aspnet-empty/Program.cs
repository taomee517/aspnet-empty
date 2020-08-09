using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace aspnet_empty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //主要任务：
            // 1. 加载默认配置
            // 2. 加载环境变量（DOTNET开头）
            // 3. 加载命令行参数
            // 4. 加载应用配置
            // 5. 配置默认的日志组件
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //主机配置项
                    webBuilder.UseStartup<Startup>();
                    //自定义配置-优先级：
                    //命令行 > 应用配置 > 硬编码 > 环境变量
                    webBuilder.UseUrls("http://localhost:8000");
                })
                .ConfigureLogging((context,loggingBuilder)=>
                {
                    //该方法需要引入Microsoft.Extensions.Logging名称空间

                    //过滤掉系统默认的一些日志
                    loggingBuilder.AddFilter("System", LogLevel.Warning); 
                    //过滤掉系统默认的一些日志
                    loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                    //最好带上这句话
                    loggingBuilder.SetMinimumLevel(LogLevel.Information);
                    loggingBuilder.AddLog4Net("Logging/log4net.config");
                });
    }
}