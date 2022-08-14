namespace GestioneSagre.Domain.Services.Infrastructure;

public partial class GestioneSagreDbContext : DbContext
{
    public GestioneSagreDbContext(DbContextOptions<GestioneSagreDbContext> options) : base(options)
    {
    }

    public virtual DbSet<FestaEntity> Feste { get; set; }
    public virtual DbSet<VersioneEntity> Versioni { get; set; }
    public virtual DbSet<CategoriaEntity> Categorie { get; set; }
    public virtual DbSet<ProdottoEntity> Prodotti { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Currency>().HaveConversion<string>();
        configurationBuilder.Properties<decimal>().HaveConversion<float>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Mapping per gli owned types
        modelBuilder.Owned<Money>();

        //Tabella FESTA, INTESTAZIONE ed IMPOSTAZIONI
        modelBuilder.Entity<FestaEntity>(entity =>
        {
            entity.ToTable("Festa");
            entity.HasKey(course => course.Id);
        });

        //Tabella VERSIONE
        modelBuilder.Entity<VersioneEntity>(entity =>
        {
            entity.ToTable("Versione");
            entity.HasKey(versione => versione.Id);
        });

        //Tabella CATEGORIE
        modelBuilder.Entity<CategoriaEntity>(entity =>
        {
            entity.ToTable("Categoria");
            entity.HasKey(categoria => categoria.Id);
        });

        //Tabella PRODOTTO
        modelBuilder.Entity<ProdottoEntity>(entity =>
        {
            entity.ToTable("Prodotto");
            entity.HasKey(prodotto => prodotto.Id);
        });
    }
}