using GestioneSagre.Domain.Services.Application;
using GestioneSagre.Internal.QueryStack;

namespace GestioneSagre.Feste.CommandStack;

public class FestaCommandStackService : IFestaCommandStackService
{
    private readonly ILogger<FestaCommandStackService> logger;
    private readonly GestioneSagreDbContext dbContext;
    private readonly IImagePersister imagePersister;
    private readonly IInternalQueryStackService internalQueryStackService;

    public FestaCommandStackService(ILogger<FestaCommandStackService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<FestaViewModel> CreateFestaAsync(FestaCreateInputModel inputModel)
    {
        string imageName = await internalQueryStackService.GenerateGuid();

        FestaEntity festa = new();

        if (inputModel.Logo != null)
        {
            var imageFesta = await imagePersister.SaveImageAsync(imageName, "jpg", "images", inputModel.Logo);

            festa = new()
            {
                GuidFesta = inputModel.GuidFesta,
                DataInizio = inputModel.DataInizio,
                DataFine = inputModel.DataFine,
                Titolo = inputModel.Titolo,
                Edizione = inputModel.Edizione,
                Luogo = inputModel.Luogo,
                //Logo = inputModel.Logo,
                Logo = imageFesta,
                GestioneCoperti = inputModel.GestioneCoperti,
                GestioneMenu = inputModel.GestioneMenu,
                StampaCarta = inputModel.StampaCarta,
                StampaLogo = inputModel.StampaLogo,
                StampaRicevuta = inputModel.StampaRicevuta,
                StatusFesta = inputModel.StatusFesta
            };
        }
        else
        {
            festa = new()
            {
                GuidFesta = inputModel.GuidFesta,
                DataInizio = inputModel.DataInizio,
                DataFine = inputModel.DataFine,
                Titolo = inputModel.Titolo,
                Edizione = inputModel.Edizione,
                Luogo = inputModel.Luogo,
                //Logo = inputModel.Logo,
                //Logo = imageFesta,
                GestioneCoperti = inputModel.GestioneCoperti,
                GestioneMenu = inputModel.GestioneMenu,
                StampaCarta = inputModel.StampaCarta,
                StampaLogo = inputModel.StampaLogo,
                StampaRicevuta = inputModel.StampaRicevuta,
                StatusFesta = inputModel.StatusFesta
            };
        }

        dbContext.Add(festa);
        await dbContext.SaveChangesAsync();

        return festa.ToFestaViewModel();
    }
    public async Task<FestaViewModel> EditFestaAsync(FestaEditInputModel inputModel)
    {
        var festa = await dbContext.Feste.FindAsync(inputModel.Id);

        string imageName = await internalQueryStackService.GenerateGuid();

        if (inputModel.Logo != null)
        {
            var imageFesta = await imagePersister.SaveImageAsync(imageName, "jpg", "images", inputModel.Logo);

            festa.GuidFesta = inputModel.GuidFesta;
            festa.DataInizio = inputModel.DataInizio;
            festa.DataFine = inputModel.DataFine;
            festa.Titolo = inputModel.Titolo;
            festa.Edizione = inputModel.Edizione;
            festa.Luogo = inputModel.Luogo;
            //festa.Logo = inputModel.Logo;
            festa.Logo = imageFesta;
            festa.GestioneCoperti = inputModel.GestioneCoperti;
            festa.GestioneMenu = inputModel.GestioneMenu;
            festa.StampaCarta = inputModel.StampaCarta;
            festa.StampaLogo = inputModel.StampaLogo;
            festa.StampaRicevuta = inputModel.StampaRicevuta;
            festa.StatusFesta = inputModel.StatusFesta;
        }
        else
        {
            festa.GuidFesta = inputModel.GuidFesta;
            festa.DataInizio = inputModel.DataInizio;
            festa.DataFine = inputModel.DataFine;
            festa.Titolo = inputModel.Titolo;
            festa.Edizione = inputModel.Edizione;
            festa.Luogo = inputModel.Luogo;
            //festa.Logo = inputModel.Logo;
            //festa.Logo = imageFesta;
            festa.GestioneCoperti = inputModel.GestioneCoperti;
            festa.GestioneMenu = inputModel.GestioneMenu;
            festa.StampaCarta = inputModel.StampaCarta;
            festa.StampaLogo = inputModel.StampaLogo;
            festa.StampaRicevuta = inputModel.StampaRicevuta;
            festa.StatusFesta = inputModel.StatusFesta;
        }

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

    public async Task ConclusionFestaAsync(int id)
    {
        var festa = await dbContext.Feste.FindAsync(id);

        festa.StatusFesta = FestaStato.Conclusa;
        await dbContext.SaveChangesAsync();
    }
}