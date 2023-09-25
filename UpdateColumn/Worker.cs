using Microsoft.Extensions.Options;
using System.Threading;
using UpdateColumn.Services;

namespace UpdateColumn
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IService _service;
        private readonly TimeSpan _timer = TimeSpan.FromSeconds(10);
        public Worker(ILogger<Worker> logger, IService service)
        {
            _logger = logger;
            _service = service;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_timer);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                Random random = new Random();
                ModelClass model = new ModelClass()
                {
                    Id = random.Next(0, 1000000),
                    CreatedDate = DateTime.Now
                };
                bool k = _service.InsertColumn(model);
                if (k)
                {
                    _logger.LogInformation("Data Inserted");
                }
                else
                {
                    _logger.LogInformation("Data Not Inserted");

                }
            }
        }
    }
}