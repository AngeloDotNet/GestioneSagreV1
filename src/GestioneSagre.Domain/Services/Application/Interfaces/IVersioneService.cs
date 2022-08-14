namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IVersioneService
{
    //COMMAND QUERY
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string codiceVersione);
    Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id);

    //COMMAND STACK
    Task<VersioneViewModel> CreateVersioneAsync(VersioneInputModel inputModel);
    Task DeleteVersioneAsync(int id);
}
