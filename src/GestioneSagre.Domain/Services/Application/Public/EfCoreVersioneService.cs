namespace GestioneSagre.Domain.Services.Application.Public;

public class EfCoreVersioneService : IVersioneService
{
    private readonly ILogger<EfCoreVersioneService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public EfCoreVersioneService(ILogger<EfCoreVersioneService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    //COMMAND QUERY
    public async Task<List<VersioneViewModel>> GetVersioniAsync()
    {
        IQueryable<VersioneEntity> baseQuery = dbContext.Versioni;

        IQueryable<VersioneEntity> queryLinq = baseQuery
            .AsNoTracking();

        List<VersioneViewModel> versioni = await queryLinq
            .Select(versione => VersioneViewModel.FromEntity(versione))
            .ToListAsync();

        return versioni;
    }

    public async Task<VersioneViewModel> GetVersioneAsync(string codiceVersione)
    {
        IQueryable<VersioneViewModel> queryLinq = dbContext.Versioni
            .AsNoTracking()
            .Where(versione => versione.CodiceVersione == codiceVersione)
            .Select(versione => VersioneViewModel.FromEntity(versione));

        VersioneViewModel viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id)
    {
        bool versioneExists = await dbContext.Versioni.AnyAsync(versione => EF.Functions.Like(versione.CodiceVersione, codiceVersione) && versione.Id != id);
        return !versioneExists;
    }

    //COMMAND STACK
    public async Task<VersioneViewModel> CreateVersioneAsync(VersioneInputModel inputModel)
    {
        VersioneEntity versione = new()
        {
            CodiceVersione = inputModel.CodiceVersione,
            TestoVersione = inputModel.TestoVersione,
            VersioneStato = inputModel.VersioneStato
        };

        dbContext.Add(versione);
        await dbContext.SaveChangesAsync();

        return VersioneViewModel.FromEntity(versione);
    }
    public async Task DeleteVersioneAsync(int id)
    {
        VersioneEntity versione = await dbContext.Versioni.FindAsync(id);

        versione.VersioneStato = VersioneStato.Deprecata;
        await dbContext.SaveChangesAsync();
    }
}
