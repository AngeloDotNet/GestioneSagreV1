using GestioneSagre.Models.InputModel.Versione;

namespace GestioneSagre.Versioni.CommandStack;

public interface IVersioneCommandStackService
{
    Task<VersioneViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel);
    Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel);
}
