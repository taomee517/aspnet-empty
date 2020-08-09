using aspnet_empty.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnet_empty.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ILogger _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }


        public string GetMsg(IMessageService messageService)
        {
            _logger.LogInformation("测试Kafka日志！");
            messageService = _messageService;
            return messageService.Send();
        }
    }
}