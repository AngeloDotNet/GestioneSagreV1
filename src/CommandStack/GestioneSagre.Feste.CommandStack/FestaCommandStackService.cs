namespace GestioneSagre.Feste.CommandStack;

public class FestaCommandStackService : IFestaCommandStackService
{
    private readonly ILogger<FestaCommandStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public FestaCommandStackService(ILogger<FestaCommandStackService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<FestaViewModel> CreateFestaAsync(FestaCreateInputModel inputModel)
    {
        FestaEntity festa = new()
        {
            GuidFesta = inputModel.GuidFesta,
            DataInizio = inputModel.DataInizio,
            DataFine = inputModel.DataFine,
            Titolo = inputModel.Titolo,
            Edizione = inputModel.Edizione,
            Luogo = inputModel.Luogo,
            Logo = inputModel.Logo,
            GestioneCoperti = inputModel.GestioneCoperti,
            GestioneMenu = inputModel.GestioneMenu,
            StampaCarta = inputModel.StampaCarta,
            StampaLogo = inputModel.StampaLogo,
            StampaRicevuta = inputModel.StampaRicevuta,
            StatusFesta = inputModel.StatusFesta
        };

        dbContext.Add(festa);
        await dbContext.SaveChangesAsync();

        return festa.ToFestaViewModel();
    }
    public async Task<FestaViewModel> EditFestaAsync(FestaEditInputModel inputModel)
    {
        var festa = await dbContext.Feste.FindAsync(inputModel.Id);

        festa.GuidFesta = inputModel.GuidFesta;
        festa.DataInizio = inputModel.DataInizio;
        festa.DataFine = inputModel.DataFine;
        festa.Titolo = inputModel.Titolo;
        festa.Edizione = inputModel.Edizione;
        festa.Luogo = inputModel.Luogo;
        festa.Logo = inputModel.Logo;
        festa.GestioneCoperti = inputModel.GestioneCoperti;
        festa.GestioneMenu = inputModel.GestioneMenu;
        festa.StampaCarta = inputModel.StampaCarta;
        festa.StampaLogo = inputModel.StampaLogo;
        festa.StampaRicevuta = inputModel.StampaRicevuta;
        festa.StatusFesta = inputModel.StatusFesta;

        await dbContext.SaveChangesAsync();

        return festa.ToFestaViewModel();
    }
    public async Task DeleteFestaAsync(FestaDeleteInputModel inputModel)
    {
        var festa = await dbContext.Feste.FindAsync(inputModel.Id);

        // Cancellazione della festa mediante eliminazione logica "soft-delete"
        festa.StatusFesta = FestaStato.Eliminata;
        await dbContext.SaveChangesAsync();

        // Cancello la festa fisicamente dal database
        //dbContext.Remove(festa);
        //await dbContext.SaveChangesAsync();
    }
}