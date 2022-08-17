namespace GestioneSagre.Categorie.CommandStack;

public class CategoriaCommandStackService : ICategoriaCommandStackService
{
    private readonly ILogger<CategoriaCommandStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public CategoriaCommandStackService(ILogger<CategoriaCommandStackService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<CategoriaViewModel> CreateCategoriaAsync(CategoriaCreateInputModel inputModel)
    {
        CategoriaEntity categoria = new()
        {
            GuidFesta = inputModel.GuidFesta,
            CategoriaVideo = inputModel.CategoriaVideo,
            CategoriaStampa = inputModel.CategoriaStampa
        };

        dbContext.Add(categoria);
        await dbContext.SaveChangesAsync();

        return categoria.ToCategoriaViewModel();
    }

    public async Task<CategoriaViewModel> EditCategoriaAsync(CategoriaEditInputModel inputModel)
    {
        var categoria = await dbContext.Categorie.FindAsync(inputModel.Id);

        categoria.GuidFesta = inputModel.GuidFesta;
        categoria.CategoriaVideo = inputModel.CategoriaVideo;
        categoria.CategoriaStampa = inputModel.CategoriaStampa;

        await dbContext.SaveChangesAsync();

        return categoria.ToCategoriaViewModel();
    }

    public async Task DeleteCategoriaAsync(CategoriaDeleteInputModel inputModel)
    {
        var categoria = await dbContext.Categorie.FindAsync(inputModel.Id);

        dbContext.Remove(categoria);
        await dbContext.SaveChangesAsync();
    }
}