namespace GestioneSagre.Versioni.QueryStack;

public class QueryStackVersioneService : IVersioneQueryStackService
{
    private readonly ILogger<QueryStackVersioneService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public QueryStackVersioneService(ILogger<QueryStackVersioneService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<List<VersioneViewModel>> GetVersioniAsync()
    {
        IQueryable<VersioneEntity> baseQuery = dbContext.Versioni;

        IQueryable<VersioneEntity> queryLinq = baseQuery
            .AsNoTracking();

        //List<VersioneViewModel> versioni = await queryLinq
        //    .Select(versione => VersioneViewModel.FromEntity(versione))
        //    .ToListAsync();

        List<VersioneViewModel> versioni = await queryLinq
            .Select(versione => versione.ToVersioneViewModel())
            .ToListAsync();

        return versioni;
    }

    public async Task<VersioneViewModel> GetVersioneAsync(string codiceVersione)
    {
        //IQueryable<VersioneViewModel> queryLinq = dbContext.Versioni
        //    .AsNoTracking()
        //    .Where(versione => versione.CodiceVersione == codiceVersione)
        //    .Select(versione => VersioneViewModel.FromEntity(versione));

        IQueryable<VersioneViewModel> queryLinq = dbContext.Versioni
            .AsNoTracking()
            .Where(versione => versione.CodiceVersione == codiceVersione)
            .Select(versione => versione.ToVersioneViewModel());

        VersioneViewModel viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id)
    {
        bool versioneExists = await dbContext.Versioni.AnyAsync(versione => EF.Functions.Like(versione.CodiceVersione, codiceVersione) && versione.Id != id);
        return !versioneExists;
    }
}
