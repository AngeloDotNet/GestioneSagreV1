using System.Net.Http.Json;
using GestioneSagre.Web.Shared.Models.InputSender;
using GestioneSagre.Web.Shared.Services.Configurazione;

namespace GestioneSagre.Web.Shared.Services.Supporto;

public class SupportoService : ISupportoService
{
    private readonly IConfigurazioneService configurazioneService;
    private HttpClient httpClient;

    public SupportoService(HttpClient httpClient, IConfigurazioneService configurazioneService)
    {
        this.httpClient = httpClient;
        this.configurazioneService = configurazioneService;
    }

    public async Task InvioEmailSupportoAsync(MailSupportoInputSender inputModel)
    {
        var pathWebInternalAPI = await configurazioneService.GetPathInternalAPI();

        var response = await httpClient.PostAsJsonAsync($"https://{pathWebInternalAPI}/api/Email/InvioEmailSupporto", inputModel);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Richiesta di supporto non inviata a causa di un problema tecnico.");
        }
    }
}