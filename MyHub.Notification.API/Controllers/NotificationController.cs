using Microsoft.AspNetCore.Mvc;
using MyHub.Notification.API.Models;
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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
            var types = new List<Domain.Enuns.ENotiticationType>();
            types.Add(Domain.Enuns.ENotiticationType.Email);
            var retorno = await _notificationService.SendNotification(new Domain.Entities.Message
            {
                Email = model.Email,
                Message = model.Message,
                NotificationProvider = model.NotificationProvider,
                NotificationType = types
            });
            return Ok(model);
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
