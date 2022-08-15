namespace GestioneSagre.Versioni.QueryStack;

public interface IVersioneQueryStackService
{
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string codiceVersione);
    Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id);
}