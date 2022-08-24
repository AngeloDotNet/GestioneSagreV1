namespace GestioneSagre.Feste.CommandStack;

public interface IFestaCommandStackService
{
    Task<FestaViewModel> CreateFestaAsync(FestaCreateInputModel inputModel);
    Task<FestaViewModel> EditFestaAsync(FestaEditInputModel inputModel);
    Task DeleteFestaAsync(FestaDeleteInputModel inputModel);
    Task ConclusionFestaAsync(int id);
}