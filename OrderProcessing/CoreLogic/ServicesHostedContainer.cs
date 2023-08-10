using System.Timers;

namespace OrderProcessing
{
    public class ServicesHostedContainer : BackgroundService
    {
        public IServiceProvider Services { get; }
        private IEnumerable<IHandler> handlers;
        private static System.Timers.Timer _timer = new(5000)
        {
            AutoReset = true,
            Enabled = true,
        };

        public ServicesHostedContainer(IServiceProvider services)
        {
            Services = services;
            _timer.Elapsed += OnTimerEvent;
        }

        private void OnTimerEvent(object? sender, ElapsedEventArgs e)
        {
            CallProcessingContainer();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await CallProcessingContainer();
        }

        private async Task CallProcessingContainer()
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IMainProcessingContainer>();
                handlers = scope.ServiceProvider.GetServices<IHandler>();

                await scopedProcessingService.StartAsync(handlers);
            }
        }
    }
}
