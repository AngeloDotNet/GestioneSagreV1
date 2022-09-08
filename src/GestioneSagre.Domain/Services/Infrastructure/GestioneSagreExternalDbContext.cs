namespace GestioneSagre.Domain.Services.Infrastructure;

public partial class GestioneSagreExternalDbContext : DbContext
{
    public GestioneSagreExternalDbContext(DbContextOptions<GestioneSagreExternalDbContext> options)
        : base(options)
    {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Pre-convention model configuration goes here
        configurationBuilder.Properties<Currency>().HaveConversion<string>();
        configurationBuilder.Properties<decimal>().HaveConversion<float>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Mapping per gli owned types
        modelBuilder.Owned<Money>();

        //Tabella PRENOTAZIONE
        modelBuilder.Entity<PrenotazioneEntity>(entity =>
        {
            entity.ToTable("Prenotazione");
            entity.HasKey(prenotazione => prenotazione.Id);
            entity.Property(prenotazione => prenotazione.StatoPrenotazione).HasConversion<string>();
        });

        //Tabella DETTAGLIO PRENOTAZIONE
        modelBuilder.Entity<PrenotazioneDettaglioEntity>(entity =>
        {
            entity.ToTable("PrenotazioneDettaglio");
            entity.HasKey(prenotazione => prenotazione.Id);
        });
    }
}