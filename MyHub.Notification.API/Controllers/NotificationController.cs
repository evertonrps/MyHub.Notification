using Microsoft.AspNetCore.Mvc;
using MyHub.Notification.API.Models;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHub.Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/<NotificationController>
        [HttpGet("providers")]
        public IActionResult GetProviders()
        {
            Dictionary<int, string?> providers = Enum.GetValues(typeof(ENotificationProvider))
                                        .Cast<ENotificationProvider>()
                                        .ToDictionary(x => (int)x, v => v.GetDescription());
            return Ok(providers);
        }

        [HttpGet("services")]
        public IActionResult GetServices()
        {
            Dictionary<int, string?> types = Enum.GetValues(typeof(ENotiticationType))
                                        .Cast<ENotiticationType>()
                                        .ToDictionary(x => (int)x, v => v.GetDescription());
            return Ok(types);
        }

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotificationController>
        [HttpPost]
        public async Task<IActionResult> Post(MessageModel model)
        {
            var message = Message.Factory(
                model.Email,
                model.ClientID,
                model.Message,
                model.Subject,
                model.Template,
                model?.NotificationProvider,
                model?.NotificationType);
            

            if (!message.IsValid())
                return BadRequest(message.Errors.Select(x=> x.ErrorMessage));
           
            var retorno = await _notificationService.SendNotification(message);
            return Ok(retorno);
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}