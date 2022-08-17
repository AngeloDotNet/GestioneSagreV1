using GestioneSagre.Models.InputModels.Categoria;

namespace GestioneSagre.Categorie.QueryStack;

public interface ICategoriaQueryStackService
{
    Task<List<CategoriaViewModel>> GetCategorieAsync();
    Task<CategoriaViewModel> GetCategoriaAsync(CategoriaDetailViewModel viewModel);
    Task<CategoriaEditInputModel> GetCategoriaForEditingAsync(CategoriaDetailViewModel viewModel);
    Task<bool> IsCategoriaAvailableAsync(CategoriaDetailViewModel viewModel);
    Task<int> GetCountProdottiByCategoriaAsync(CategoriaDetailViewModel viewModel);
}