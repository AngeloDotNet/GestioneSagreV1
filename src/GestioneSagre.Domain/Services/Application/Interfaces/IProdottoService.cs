namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IProdottoService
{
    //COMMAND QUERY
    Task<List<ProdottoViewModel>> GetProdottiAsync();
    Task<ProdottoViewModel> GetProdottoAsync(string guidFesta, int id);
    Task<ProdottoEditInputModel> GetProdottoForEditingAsync(string guidFesta, int id);
    Task<bool> IsProdottoAvailableAsync(string guidFesta, string prodotto, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId);

    //COMMAND STACK
    Task<ProdottoViewModel> CreateProdottoAsync(ProdottoCreateInputModel inputModel);
    Task<ProdottoViewModel> EditProdottoAsync(ProdottoEditInputModel inputModel);
    Task DeleteProdottoAsync(ProdottoDeleteInputModel inputModel);
}