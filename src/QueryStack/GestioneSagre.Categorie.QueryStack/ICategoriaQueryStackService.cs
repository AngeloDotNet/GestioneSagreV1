namespace GestioneSagre.Categorie.QueryStack;

public interface ICategoriaQueryStackService
{
    Task<List<CategoriaViewModel>> GetCategorieAsync();
    Task<CategoriaViewModel> GetCategoriaAsync(string guidFesta, string categoriaVideo);
    Task<bool> IsCategoriaAvailableAsync(string guidFesta, string categoriaVideo, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId);
}