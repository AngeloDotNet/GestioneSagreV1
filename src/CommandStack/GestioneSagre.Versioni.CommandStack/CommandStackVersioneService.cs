namespace GestioneSagre.Versioni.CommandStack;

public class CommandStackVersioneService : IVersioneService
{
    private readonly ILogger<CommandStackVersioneService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public CommandStackVersioneService(ILogger<CommandStackVersioneService> logger, GestioneSagreDbContext dbContext)
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
