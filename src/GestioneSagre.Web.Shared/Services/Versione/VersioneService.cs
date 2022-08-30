namespace GestioneSagre.Web.Shared.Services.Versione;

public class VersioneService : IVersioneService
{
    private readonly IConfigurazioneService configurazioneService;
    private HttpClient httpClient;

    private string Versione = "08da4afe-6f26-d449-753a-8e553407828b";

    public VersioneViewModel testoVersione { get; set; }

    public VersioneService(HttpClient httpClient, IConfigurazioneService configurazioneService)
    {
        this.httpClient = httpClient;
        this.configurazioneService = configurazioneService;
    }

    public async Task<VersioneViewModel> GetVersione()
    {
        var pathWebInternalAPI = await configurazioneService.GetPathInternalAPI();

        testoVersione = await httpClient.GetFromJsonAsync<VersioneViewModel>($"https://{pathWebInternalAPI}/api/Versione/{Versione}");

        return testoVersione;
    }
}