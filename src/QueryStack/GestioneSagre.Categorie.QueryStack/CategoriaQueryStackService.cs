using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Domain.Services.Infrastructure;
using GestioneSagre.Models.InputModels.Categoria;
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

    public async Task<CategoriaViewModel> GetCategoriaAsync(CategoriaDetailViewModel model)
    {
        var queryLinq = dbContext.Categorie.AsNoTracking()
            .Where(categoria => categoria.CategoriaVideo == model.CategoriaVideo && categoria.GuidFesta == model.GuidFesta)
            .Select(categoria => categoria.ToCategoriaViewModel());

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<bool> IsCategoriaAvailableAsync(CategoriaDetailViewModel model)
    {
        var categoriaExists = await dbContext.Categorie.AnyAsync(x => EF.Functions.Like(x.CategoriaVideo, model.CategoriaVideo) && x.Id != model.Id);
        return !categoriaExists;
    }

    public Task<CategoriaEditInputModel> GetCategoriaForEditingAsync(CategoriaDetailViewModel viewModel) => throw new NotImplementedException();
    public Task<int> GetCountProdottiByCategoriaAsync(CategoriaDetailViewModel viewModel) => throw new NotImplementedException();
}