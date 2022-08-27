namespace GestioneSagre.Versioni.QueryStack;

public class VersioneQueryStackService : IVersioneQueryStackService
{
    private readonly ILogger<VersioneQueryStackService> logger;
    private readonly GestioneSagreInternalDbContext dbContext;

    public VersioneQueryStackService(ILogger<VersioneQueryStackService> logger,
                                     GestioneSagreInternalDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<List<VersioneViewModel>> GetVersioniAsync()
    {
        IQueryable<VersioneEntity> baseQuery = dbContext.Versioni;

        var queryLinq = baseQuery.AsNoTracking();
        var versioni = await queryLinq.Select(versione => versione.ToVersioneViewModel()).ToListAsync();

        return versioni;
    }

    public async Task<VersioneViewModel> GetVersioneAsync(string codiceVersione)
    {
        var queryLinq = dbContext.Versioni.AsNoTracking()
            .Where(versione => versione.CodiceVersione == codiceVersione)
            .Select(versione => versione.ToVersioneViewModel());

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id)
    {
        var versioneExists = await dbContext.Versioni.AnyAsync(versione => EF.Functions.Like(versione.CodiceVersione, codiceVersione) && versione.Id != id);
        return !versioneExists;
    }
}