//using MyHub.Notification.Domain.Enuns;
//using MyHub.Notification.ExternalService.Interfaces;
//using MyHub.Notification.ExternalService.Providers.HubSpotProvider;
//using MyHub.Notification.ExternalService.Providers.MandrilProvider;
//using MyHub.Notification.ExternalService.Providers.MarketingCloudProvider;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyHub.Notification.IoC
//{
//    public static class MailStrategyFactory
//    {
//        public static IMailStrategy GetStrategy(ENotificationProvider provider)
//        {
//            switch (provider)
//            {
//                case ENotificationProvider.Invalid:
//                case ENotificationProvider.OneSignal:
//                case ENotificationProvider.Firebase:
//                    {
//                        throw new InvalidOperationException("Service not avaliable");
//                    }
//                case ENotificationProvider.Mandril:
//                    return new MandrilExternalService();
//                case ENotificationProvider.HubSpot:
//                    return new HubSpotExternalService();
//                case ENotificationProvider.MarketingCloud:
//                    return new MarketingCloudExternalService();
//                default:
//                    throw new ArgumentException();
//            }
//        }
//    }
//}