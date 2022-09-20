namespace GestioneSagre.Domain.Services.Infrastructure;

public partial class GestioneSagreSecurityDbContext : DbContext
{
    public GestioneSagreSecurityDbContext(DbContextOptions<GestioneSagreSecurityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}