using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_empty.Extentions;
using aspnet_empty.Services;
using aspnet_empty.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspnet_empty
{
    // 配置Web应用所需的服务和中间件
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // 可选的 注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            // 服务容器 IoC容器
            // 注册类型 请求实例
            
            // 默认已经注册了一些服务，服务容器
            
            // 添加对控制器和API相关功能的支持，但是不支持视图和页面
            services.AddControllers();
            
            // 添加对控制器/API/视图相关功能的支持
            // ASP.NET CORE 3.0 MVC默认模板使用 AddControllersWithViews
            services.AddControllersWithViews();
            // 添加对Razor Pages和最小控制器的支持
            services.AddRazorPages();
            
            // ASP.NET CORE 2.0 添加MVC模板
            // services.AddMvc();
            // 添加对跨阈的支持
            services.AddCors();
            // 配置方法定义在MessageServiceExtention 和 MessageServiceBuilder
            services.AddMessage(option => option.UseSms());
            
            // 还可以添加一些第三方的服务 如：EF Core, 日志框架， swagger
            // 注册自定义服务（必须要选择一个生存周期）
            // 服务生存期  类型生命周期
            //    1. 瞬时 每次从服务器容器里请求时实例时，都会创建一个新的实例
            //    2. 作用域 线程单例，在同一个线程里，只实例化一次
            //    3. 单例  全局单例，每次都是相同的实例
            // services.AddSingleton();
            // services.AddTransient();
            // services.AddScoped();
            
            // services.AddSingleton<IMessageService, EmailService>();
            // // 若同一个接口注册多个实例，只有最后一个实例会生效
            // services.AddSingleton<IMessageService, SmsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 配置中间件，中间件组成管道
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageService messageService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(messageService.Send());
                });
            });
        }
    }
}