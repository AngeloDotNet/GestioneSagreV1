using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Core.Models.Enums;
using GestioneSagre.Domain.Services.Infrastructure;
using GestioneSagre.Models.ViewModels;
using GestioneSagre.ViewExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestioneSagre.Feste.QueryStack;

public class FestaQueryStackService : IFestaQueryStackService
{
    private readonly ILogger<FestaQueryStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public FestaQueryStackService(ILogger<FestaQueryStackService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<List<FestaViewModel>> GetFesteAsync()
    {
        IQueryable<FestaEntity> baseQuery = dbContext.Feste.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery.AsNoTracking();
        var feste = await queryLinq.Select(festa => festa.ToFestaViewModel()).ToListAsync();

        return feste;
    }

    public async Task<FestaViewModel> GetFestaAsync(string guidFesta)
    {
        var queryLinq = dbContext.Feste.AsNoTracking()
            .Where(festa => festa.GuidFesta == guidFesta)
            .Select(festa => festa.ToFestaViewModel());

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<int> GetCountFesteAsync(FestaStato statusFesta)
    {
        var counter = await dbContext.Feste
                            .Where(festa => festa.StatusFesta != statusFesta)
                            .CountAsync();
        return counter;
    }
}