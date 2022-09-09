namespace GestioneSagre.Feste.CommandStack;

public interface IFestaCommandStackService
{
    Task<FestaViewModel> CreateFestaAsync(FestaCreateInputModel inputModel);
    Task<FestaViewModel> EditFestaAsync(FestaEditInputModel inputModel);
    Task DeleteFestaAsync(FestaDeleteInputModel inputModel);
    Task StatusFestaCreataAsync(int id);
    Task StatusFestaInCorsoAsync(int id);
    Task StatusFestaConclusaAsync(int id);
    Task StatusFestaEliminataAsync(int id);
}