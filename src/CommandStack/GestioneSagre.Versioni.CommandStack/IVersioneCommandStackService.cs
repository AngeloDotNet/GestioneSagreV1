namespace GestioneSagre.Versioni.CommandStack;

public interface IVersioneCommandStackService
{
    Task<VersioneViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel);
    Task AttivaVersioneAsync(VersioneDeleteInputModel inputModel);
    Task DeprecaVersioneAsync(VersioneDeleteInputModel inputModel);
}
