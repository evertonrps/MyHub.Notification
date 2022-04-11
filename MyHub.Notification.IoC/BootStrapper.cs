using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.Interfaces.Services;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.Domain.services;
using MyHub.Notification.Domain.Services;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;
using MyHub.Notification.ExternalService.Providers.FirebaseProvider;
using MyHub.Notification.ExternalService.Providers.HubSpotProvider;
using MyHub.Notification.ExternalService.Providers.MandrilProvider;
using MyHub.Notification.ExternalService.Providers.MarketingCloudProvider;
using MyHub.Notification.ExternalService.Providers.OneSignalProvider;
using MyHub.Notification.ExternalService.Services;

namespace MyHub.Notification.IoC
{
    public static class BootStrapper
    {
        public delegate IMailStrategy ServiceResolver(ENotificationProvider provider);

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection appSettingsSection = configuration.GetRequiredSection("ApiConfiguration");
            services.Configure<AppSettings>(appSettingsSection);

            //Repositories

            //Services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMailNotificationService, MailNotificationService>();
            services.AddScoped<IMobileNotificationService, MobileNotificationService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();
            services.AddScoped<IWebNotificationService, WebNotificationService>();
            services.AddScoped<IWhatsAppNotificationService, WhatsAppNotificationService>();

            //Mail
            services.AddTransient<IMailStrategy, MailStrategy>();
            services.AddTransient<IMailHandler, HubSpotMailService>();
            services.AddTransient<IMailHandler, MandrilMailService>();
            services.AddTransient<IMailHandler, MarketingCloudMailService>();

            //Push
            services.AddTransient<IPushStrategy, PushStrategy>();
            services.AddTransient<IPushNotificationHandler, FirebasePushService>();
            services.AddTransient<IPushNotificationHandler, MarketingCloudPushService>();
            services.AddTransient<IPushNotificationHandler, OneSignalPushService>();

            //WhatsApp
            services.AddTransient<IWhatsAppStrategy, WhatsAppStrategy>();
            services.AddTransient<IWhatsAppHandler, HubSpotWhatsAppService>();
            services.AddTransient<IWhatsAppHandler, MarketingCloudWhatsAppService>();

            //SMS
            services.AddTransient<ISmsStrategy, SmsStrategy>();
            services.AddTransient<ISmsHandler, HubSpotSmsService>();

            //Web Notification
            services.AddTransient<IWebNotificationStrategy, WebNotificationStrategy>();
            services.AddTransient<IWebNotificationHandler, HubSpotWebNotificationService>();

            //services.AddScoped<ServiceResolver>(serviceProvider => key =>
            //{
            //    switch (key)
            //    {
            //        case ENotificationProvider.HubSpot:
            //            return serviceProvider.GetRequiredService<HubSpotExternalService>();
            //        case ENotificationProvider.Mandril:
            //            return serviceProvider.GetRequiredService<MandrilExternalService>();
            //        case ENotificationProvider.MarketingCloud:
            //            return serviceProvider.GetRequiredService<MarketingCloudExternalService>();
            //        default:
            //            throw new KeyNotFoundException();
            //    }
            //});

            //External Services
            services.AddScoped<INotificationExternalService, NotificationExternalService>();

            SerilogConfiguration.CreateLogger();
            SerilogConfiguration.AddSerilog(services);
        }
    }
}