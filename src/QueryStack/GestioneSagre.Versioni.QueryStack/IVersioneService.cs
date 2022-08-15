namespace GestioneSagre.Versioni.QueryStack;

public interface IVersioneService
{
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string codiceVersione);
    Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id);
}