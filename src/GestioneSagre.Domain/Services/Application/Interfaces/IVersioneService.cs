namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IVersioneService
{
    //COMMAND QUERY
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string codiceVersione);
    Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id);

    //COMMAND STACK
    Task<VersioneViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel);
    Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel);
}
