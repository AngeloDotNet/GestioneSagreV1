namespace GestioneSagre.Prodotti.CommandStack;

public class ProdottoCommandStackService : IProdottoCommandStackService
{
    private readonly ILogger<ProdottoCommandStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public ProdottoCommandStackService(ILogger<ProdottoCommandStackService> logger,
                                       GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<ProdottoViewModel> CreateProdottoAsync(ProdottoCreateInputModel inputModel)
    {
        ProdottoEntity prodotto = new()
        {
            GuidFesta = inputModel.GuidFesta,
            CategoriaId = inputModel.CategoriaId,
            Prodotto = inputModel.Prodotto,
            ProdottoAttivo = inputModel.ProdottoAttivo,
            Prezzo = inputModel.Prezzo,
            Quantita = inputModel.Quantita,
            QuantitaAttiva = inputModel.QuantitaAttiva,
            QuantitaScorta = inputModel.QuantitaScorta,
            AvvisoScorta = inputModel.AvvisoScorta,
            Prenotazione = inputModel.Prenotazione
        };

        dbContext.Add(prodotto);
        await dbContext.SaveChangesAsync();

        return prodotto.ToProdottoViewModel();
    }

    public async Task<ProdottoViewModel> EditProdottoAsync(ProdottoEditInputModel inputModel)
    {
        var prodotto = await dbContext.Prodotti.FindAsync(inputModel.Id);

        prodotto.GuidFesta = inputModel.GuidFesta;
        prodotto.CategoriaId = inputModel.CategoriaId;
        prodotto.Prodotto = inputModel.Prodotto;
        prodotto.ProdottoAttivo = inputModel.ProdottoAttivo;
        prodotto.Prezzo = inputModel.Prezzo;
        prodotto.Quantita = inputModel.Quantita;
        prodotto.QuantitaAttiva = inputModel.QuantitaAttiva;
        prodotto.QuantitaScorta = inputModel.QuantitaScorta;
        prodotto.AvvisoScorta = inputModel.AvvisoScorta;
        prodotto.Prenotazione = inputModel.Prenotazione;

        await dbContext.SaveChangesAsync();

        return prodotto.ToProdottoViewModel();
    }

    public async Task DeleteProdottoAsync(ProdottoDeleteInputModel inputModel)
    {
        var prodotto = await dbContext.Prodotti.FindAsync(inputModel.Id);

        dbContext.Remove(prodotto);
        await dbContext.SaveChangesAsync();
    }
}
