namespace GestioneSagre.Versioni.CommandStack;

public interface IVersioneService
{
    Task<VersioneViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel);
    Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel);
}
