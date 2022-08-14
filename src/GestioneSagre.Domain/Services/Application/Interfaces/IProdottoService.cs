namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IProdottoService
{
    //COMMAND QUERY
    Task<List<ProdottoViewModel>> GetProdottiAsync();
    Task<ProdottoViewModel> GetProdottoAsync(string guidFesta, int id);
    Task<bool> IsProdottoAvailableAsync(string guidFesta, string prodotto, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId);

    //COMMAND STACK
    Task<ProdottoViewModel> CreateProdottoAsync(ProdottoInputModel inputModel);
    Task<ProdottoViewModel> EditProdottoAsync(ProdottoInputModel inputModel);
    Task DeleteProdottoAsync(string guidFesta, int Id);
}