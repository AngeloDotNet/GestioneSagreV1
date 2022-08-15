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

    //COMMAND STACK
    public async Task<VersioneViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel)
    {
        VersioneEntity versione = new()
        {
            CodiceVersione = inputModel.CodiceVersione,
            TestoVersione = inputModel.TestoVersione,
            VersioneStato = inputModel.VersioneStato
        };

        dbContext.Add(versione);
        await dbContext.SaveChangesAsync();

        //return VersioneViewModel.FromEntity(versione);
        return versione.ToVersioneViewModel();
    }
    public async Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel)
    {
        VersioneEntity versione = await dbContext.Versioni.FindAsync(inputModel.Id);

        versione.VersioneStato = VersioneStato.Deprecata;
        await dbContext.SaveChangesAsync();
    }
}
