namespace GestioneSagre.Versioni.CommandStack;

public class VersioneCommandStackService : IVersioneCommandStackService
{
    private readonly ILogger<VersioneCommandStackService> logger;
    private readonly GestioneSagreInternalDbContext dbContext;

    public VersioneCommandStackService(ILogger<VersioneCommandStackService> logger,
                                       GestioneSagreInternalDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

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

        return versione.ToVersioneViewModel();
    }

    public async Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel)
    {
        var versione = await dbContext.Versioni.FindAsync(inputModel.Id);

        versione.VersioneStato = VersioneStato.Deprecata;
        await dbContext.SaveChangesAsync();
    }
}