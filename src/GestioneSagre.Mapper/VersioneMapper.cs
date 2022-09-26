namespace GestioneSagre.Mapper;

public class VersioneMapper : IEntityTypeConfiguration<VersioneEntity>
{
    public void Configure(EntityTypeBuilder<VersioneEntity> entity)
    {
        entity.ToTable("Versione");
        entity.HasKey(versione => versione.Id);
        entity.Property(versione => versione.VersioneStato).HasConversion<string>();
    }
}