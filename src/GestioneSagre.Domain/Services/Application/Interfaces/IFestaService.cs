namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IFestaService
{
    //COMMAND QUERY
    Task<List<FestaViewModel>> GetFesteAsync();
    Task<FestaViewModel> GetFestaAsync(string guidFesta);
    Task<FestaEditInputModel> GetFestaForEditingAsync(string guidFesta);
    Task<int> GetCountFesteAsync();

    //COMMAND STACK
    Task<FestaViewModel> CreateFestaAsync(FestaCreateInputModel inputModel);
    Task<FestaViewModel> EditFestaAsync(FestaEditInputModel inputModel);
    Task DeleteFestaAsync(FestaDeleteInputModel inputModel);
}