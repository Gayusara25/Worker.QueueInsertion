using Microsoft.EntityFrameworkCore;
using UpdateColumn;
using UpdateColumn.Services;

IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureServices((hostContext, services) => {
        IConfiguration configuration = hostContext.Configuration;
         services.AddSingleton<IService, Service>();
         services.AddHostedService<Worker>();
     }).Build();

await host.RunAsync();