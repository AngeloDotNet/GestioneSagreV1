namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface ICategoriaService
{
    //COMMAND QUERY
    Task<List<CategoriaViewModel>> GetCategorieAsync();
    Task<CategoriaViewModel> GetCategoriaAsync(string guidFesta, int id);
    Task<bool> IsCategoriaAvailableAsync(string guidFesta, string categoriaVideo, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int id);

    //COMMAND STACK
    Task<CategoriaViewModel> CreateCategoriaAsync(CategoriaInputModel inputModel);
    Task<CategoriaViewModel> EditCategoriaAsync(CategoriaInputModel inputModel);
    Task DeleteCategoriaAsync(string guidFesta, int id);
}