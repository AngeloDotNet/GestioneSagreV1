namespace GestioneSagre.Domain.Services.Infrastructure;

public partial class GestioneSagreInternalDbContext : DbContext
{
    public GestioneSagreInternalDbContext(DbContextOptions<GestioneSagreInternalDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<VersioneEntity> Versioni { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Tabella VERSIONE
        modelBuilder.ApplyConfiguration(new VersioneMapper());
    }
}
