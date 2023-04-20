using Microsoft.Extensions.Hosting;

internal class MyHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;
    private CancellationTokenRegistration _registration;

    public MyHostedService(IHostApplicationLifetime applicationLifetime)
    {
        _applicationLifetime = applicationLifetime;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _registration =  _applicationLifetime.ApplicationStopping.Register(() => { });
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _registration.Dispose();

        return Task.CompletedTask;
    }
}