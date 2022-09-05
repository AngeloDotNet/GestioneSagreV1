namespace GestioneSagre.Web.Shared.Services.Versione;

public class VersioneService : IVersioneService
{
    private readonly IConfigurazioneService configurazioneService;
    private HttpClient httpClient;

    public VersioneViewModel testoVersione { get; set; }

    public VersioneService(HttpClient httpClient, IConfigurazioneService configurazioneService)
    {
        this.httpClient = httpClient;
        this.configurazioneService = configurazioneService;
    }

    public async Task<VersioneViewModel> GetVersione()
    {
        var pathWebInternalAPI = await configurazioneService.GetInternalApiFromSettings();
        var versione = await configurazioneService.GetVersioneFromSettings();

        testoVersione = await httpClient.GetFromJsonAsync<VersioneViewModel>($"https://{pathWebInternalAPI}/api/Versione/{versione}");

        return testoVersione;
    }
}