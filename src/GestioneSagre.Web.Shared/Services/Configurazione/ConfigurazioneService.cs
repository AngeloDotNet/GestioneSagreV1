namespace GestioneSagre.Web.Shared.Services.Configurazione;

public class ConfigurazioneService : IConfigurazioneService
{
    private ClientSharedOptions[] options;
    private HttpClient httpClient;

    public ConfigurazioneService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ClientSharedOptions[]> ReadOptionsFromJSON()
    {
        options = await httpClient.GetFromJsonAsync<ClientSharedOptions[]>("settings.json");

        return options;
    }

    public async Task<string> GetApplicationApiFromSettings()
    {
        options = await ReadOptionsFromJSON();

        return options.ElementAt(0).PathPublic;
    }

    public async Task<string> GetInternalApiFromSettings()
    {
        options = await ReadOptionsFromJSON();

        return options.ElementAt(0).PathPrivate;
    }

    public async Task<string> GetVersioneFromSettings()
    {
        options = await ReadOptionsFromJSON();

        return options.ElementAt(0).Versione;
    }
}