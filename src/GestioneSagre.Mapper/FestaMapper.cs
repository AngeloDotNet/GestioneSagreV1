namespace GestioneSagre.Mapper;

public class FestaMapper : IEntityTypeConfiguration<FestaEntity>
{
    public void Configure(EntityTypeBuilder<FestaEntity> entity)
    {
        entity.ToTable("Festa");
        entity.HasKey(festa => festa.Id);
        entity.Property(festa => festa.StatusFesta).HasConversion<string>();
    }
}