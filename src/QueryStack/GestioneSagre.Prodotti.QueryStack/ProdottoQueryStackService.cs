namespace GestioneSagre.Prodotti.QueryStack;

public class ProdottoQueryStackService : IProdottoQueryStackService
{
    private readonly ILogger<ProdottoQueryStackService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public ProdottoQueryStackService(ILogger<ProdottoQueryStackService> logger,
                                     GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<List<ProdottoViewModel>> GetProdottiAsync()
    {
        IQueryable<ProdottoEntity> baseQuery = dbContext.Prodotti.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery.AsNoTracking();
        var prodotti = await queryLinq.Select(categoria => categoria.ToProdottoViewModel()).ToListAsync();

        return prodotti;
    }
    public async Task<ProdottoViewModel> GetProdottoAsync(string guidFesta, string prodotto)
    {
        var queryLinq = dbContext.Prodotti.AsNoTracking()
            .Where(prodotti => prodotti.Prodotto == prodotto && prodotti.GuidFesta == guidFesta)
            .Select(prodotti => prodotti.ToProdottoViewModel());

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }
    public async Task<bool> IsProdottoAvailableAsync(string guidFesta, string prodotto, int id)
    {
        var prodottoExists = await dbContext.Prodotti.AnyAsync(x => EF.Functions.Like(x.Prodotto, prodotto)
                                                                 && EF.Functions.Like(x.GuidFesta, guidFesta) && x.Id != id);
        return !prodottoExists;
    }
    public async Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId)
    {
        var counter = await dbContext.Prodotti
                            .Where(prodotto => prodotto.GuidFesta == guidFesta && prodotto.CategoriaId == categoriaId)
                            .CountAsync();
        return counter;
    }
}