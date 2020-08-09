using System;
using aspnet_empty.Services;
using aspnet_empty.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_empty.Extentions
{
    public static class MessageServiceExtention
    {
        public static void AddMessage(this IServiceCollection services)
        {
            services.AddSingleton<IMessageService, SmsService>();
        }
        
        public static void AddMessage(this IServiceCollection services, Action<MessageServiceBuilder> configure)
        {
            var builder = new MessageServiceBuilder(services);
            configure(builder);
        }
    }
}