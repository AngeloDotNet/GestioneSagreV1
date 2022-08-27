namespace GestioneSagre.WorkerServices;

public class FestaHostedService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory serviceScopeFactory;
    private readonly ILogger logger;

    private Timer timer;

    public FestaHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<FestaHostedService> logger)
    {
        this.serviceScopeFactory = serviceScopeFactory;
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        timer = new Timer(
            async state =>
            {
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var dataOdierna = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);

                    using var serviceScope = serviceScopeFactory.CreateScope();
                    var festeQueryStackService = serviceScope.ServiceProvider.GetRequiredService<IFestaQueryStackService>();
                    var festeCommandStackService = serviceScope.ServiceProvider.GetRequiredService<IFestaCommandStackService>();

                    List<FestaViewModel> listaEventi = await festeQueryStackService.GetFesteAsync();

                    if (listaEventi.Count != 0)
                    {
                        foreach (var item in listaEventi)
                        {
                            DateTime dataFineFesta = Convert.ToDateTime(item.DataFine);

                            if (dataOdierna > dataFineFesta)
                            {
                                // Imposto la stato della festa a CONCLUSA
                                await festeCommandStackService.ConclusionFestaAsync(item.Id);
                            }
                            else
                            {
                                // Non eseguo nessuna operazione
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Esecuzione fallita");
                }
            },

            state: null,
            dueTime: TimeSpan.Zero,         // delay per la prima esecuzione
            period: TimeSpan.FromHours(1)); // ripetizione ogni 1 ora/e

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        timer.Change(Timeout.Infinite, Timeout.Infinite);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        timer.Dispose();
    }
}