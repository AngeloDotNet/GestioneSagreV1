namespace GestioneSagre.Prodotti.CommandStack;

public interface IProdottoCommandStackService
{
    Task<ProdottoViewModel> CreateProdottoAsync(ProdottoCreateInputModel inputModel);
    Task<ProdottoViewModel> EditProdottoAsync(ProdottoEditInputModel inputModel);
    Task DeleteProdottoAsync(ProdottoDeleteInputModel inputModel);
}