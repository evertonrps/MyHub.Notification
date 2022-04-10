using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.Interfaces.Services;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.Domain.services;
using MyHub.Notification.Domain.Services;
using MyHub.Notification.ExternalService.Interfaces;
using MyHub.Notification.ExternalService.Providers.HubSpotProvider;
using MyHub.Notification.ExternalService.Providers.MandrilProvider;
using MyHub.Notification.ExternalService.Providers.MarketingCloudProvider;
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

            services.AddTransient<IMailStrategy, MailStrategy>();
            services.AddTransient<IMailHandlerService, HubSpotExternalService>();
            services.AddTransient<IMailHandlerService, MandrilExternalService>();
            services.AddTransient<IMailHandlerService, MarketingCloudExternalService>();

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