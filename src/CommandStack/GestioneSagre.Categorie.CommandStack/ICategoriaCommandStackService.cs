namespace GestioneSagre.Categorie.CommandStack;

public interface ICategoriaCommandStackService
{
    Task<CategoriaViewModel> CreateCategoriaAsync(CategoriaCreateInputModel inputModel);
    Task<CategoriaViewModel> EditCategoriaAsync(CategoriaEditInputModel inputModel);
    Task DeleteCategoriaAsync(CategoriaDeleteInputModel inputModel);
}