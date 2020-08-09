using aspnet_empty.Services;
using aspnet_empty.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_empty.Extentions
{
    public class MessageServiceBuilder
    {
        public IServiceCollection services { get; set; }

        public MessageServiceBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public void UseSms()
        {
            services.AddSingleton<IMessageService, SmsService>();
        }
        
        public void UseEmail()
        {
            services.AddSingleton<IMessageService, EmailService>();
        }
    }
}