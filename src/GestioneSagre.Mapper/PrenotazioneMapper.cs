namespace GestioneSagre.Mapper;

public class PrenotazioneMapper : IEntityTypeConfiguration<PrenotazioneEntity>
{
    public void Configure(EntityTypeBuilder<PrenotazioneEntity> entity)
    {
        entity.ToTable("Prenotazione");
        entity.HasKey(prenotazione => prenotazione.Id);
        entity.Property(prenotazione => prenotazione.StatoPrenotazione).HasConversion<string>();
    }
}