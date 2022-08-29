namespace GestioneSagre.Prodotti.QueryStack;

public interface IProdottoQueryStackService
{
    Task<List<ProdottoViewModel>> GetProdottiAsync();
    Task<ProdottoViewModel> GetProdottoAsync(string guidFesta, string prodotto);
    Task<bool> IsProdottoAvailableAsync(string guidFesta, string prodotto, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId);
}