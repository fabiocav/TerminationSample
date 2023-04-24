using Microsoft.Extensions.Hosting;

internal class MyHostedService : IHostedService, IAsyncDisposable
{
    private CancellationTokenRegistration _registration;

    public MyHostedService(IHostApplicationLifetime applicationLifetime)
    {
        if (applicationLifetime is null)
        {
            throw new ArgumentNullException(nameof(applicationLifetime));
        }

        _registration = applicationLifetime.ApplicationStopping.Register(() => { });
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {        
        return Task.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        return ((IAsyncDisposable)_registration).DisposeAsync();
    }
}