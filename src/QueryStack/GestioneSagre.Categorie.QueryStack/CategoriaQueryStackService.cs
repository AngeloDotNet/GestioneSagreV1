using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Domain.Services.Infrastructure;
using GestioneSagre.ViewExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestioneSagre.Categorie.QueryStack;

public class CategoriaQueryStackService : ICategoriaQueryStackService
{
    private readonly ILogger<CategoriaQueryStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public CategoriaQueryStackService(ILogger<CategoriaQueryStackService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<List<CategoriaViewModel>> GetCategorieAsync()
    {
        IQueryable<CategoriaEntity> baseQuery = dbContext.Categorie.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery.AsNoTracking();
        var categorie = await queryLinq.Select(categoria => categoria.ToCategoriaViewModel()).ToListAsync();

        return categorie;
    }

    public async Task<CategoriaViewModel> GetCategoriaAsync(string guidFesta, string categoriaVideo)
    {
        var queryLinq = dbContext.Categorie.AsNoTracking()
            .Where(categoria => categoria.CategoriaVideo == categoriaVideo && categoria.GuidFesta == guidFesta)
            .Select(categoria => categoria.ToCategoriaViewModel());

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<bool> IsCategoriaAvailableAsync(string guidFesta, string categoriaVideo, int id)
    {
        var categoriaExists = await dbContext.Categorie.AnyAsync(x => EF.Functions.Like(x.CategoriaVideo, categoriaVideo)
                                                                   && EF.Functions.Like(x.GuidFesta, guidFesta) && x.Id != id);
        return !categoriaExists;
    }

    public async Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId)
    {
        var counter = await dbContext.Prodotti
                            .Where(categoria => categoria.GuidFesta == guidFesta && categoria.CategoriaId == categoriaId)
                            .CountAsync();
        return counter;
    }
}