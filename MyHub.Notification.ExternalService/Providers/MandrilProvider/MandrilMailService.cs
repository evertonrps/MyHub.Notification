using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.Interfaces.Repositories;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Providers.MandrilProvider.ProviderObjects;

namespace MyHub.Notification.ExternalService.Providers.MandrilProvider
{
    public class MandrilMailService : IMailHandler
    {
        private readonly ILogger<MandrilMailService> _logger;
        private readonly IMailTemplateRepository _mailTemplateRepository;

        public ENotificationProvider NotificationProvider => ENotificationProvider.Mandril;

        public MandrilMailService(ILogger<MandrilMailService> logger, IMailTemplateRepository mailTemplateRepository)
        {
            _logger = logger;
            _mailTemplateRepository = mailTemplateRepository;
        }

        public async Task<ResponseEntity> SendMail(Message message)
        {
            var mandrilMessage = await MandrilMessageBuilder(message);
            _logger.LogInformation("Sended Mail by Mandril");
            return new ResponseEntity { Type = ENotiticationType.Email, Provider = NotificationProvider, Success = true, Message = "Sended Mail by Mandril" };
        }

        private async Task<MandrilMail> MandrilMessageBuilder(Message message)
        {    
            MailTemplate mailTemplate = new MailTemplate();
            if (message?.Template != null)
            {
                mailTemplate = await _mailTemplateRepository.GetMailTemplateByName(message.Template);
                mailTemplate.Html.Replace("[Name]", "Client Name");
                return new MandrilMail(message.Email, mailTemplate.Subject, mailTemplate.Html);
            }
                       
           return new MandrilMail(message.Email, message.Subject, message.BodyMessage);
        }
    }
}