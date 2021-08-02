using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{
    //https://stackoverflow.com/questions/56360983/signalr-hub-resolves-to-null-inside-rabbitmq-subscription-handler-in-asp-net-cor
    //  services.AddHostedService<MyHostedService>(); 
    public class MyHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MyHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceScopeFactory.CreateScope();
            //var bus = scope.ServiceProvider.GetRequiredService<IBus>();

            //bus.SubscribeAsync<MyMessage>("MySubscription", async message =>
            //{
            //    var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<MyHub>>();

            //    await hubContext.Clients
            //        .All
            //        .SendAsync("MyNotification", cancellationToken: stoppingToken);
            //});

            return Task.CompletedTask;
        }
    }

}