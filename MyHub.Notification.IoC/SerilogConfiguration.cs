using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MyHub.Notification.IoC
{
    public static class SerilogConfiguration
    {
        public static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("System.Net.Http.HttpClient", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}{NewLine}")
                        .CreateLogger();
        }

        public static void AddSerilog(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddLogging(
                    logginBuilder =>
                    {
                        logginBuilder.AddSerilog();
                    });
        }
    }
}