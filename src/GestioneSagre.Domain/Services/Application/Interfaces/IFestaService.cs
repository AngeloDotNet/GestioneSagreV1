namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IFestaService
{
    //COMMAND QUERY
    Task<List<FestaViewModel>> GetFesteAsync();
    Task<FestaViewModel> GetFestaAsync(string guidFesta);
    Task<int> GetCountFesteAsync();

    //COMMAND STACK
    Task<FestaViewModel> CreateFestaAsync(FestaInputModel inputModel);
    Task<FestaViewModel> EditFestaAsync(FestaInputModel inputModel);
    Task DeleteFestaAsync(string guidFesta, int Id);
}