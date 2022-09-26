namespace GestioneSagre.Mapper;

public class PrenotazioneDettaglioMapper : IEntityTypeConfiguration<PrenotazioneDettaglioEntity>
{
    public void Configure(EntityTypeBuilder<PrenotazioneDettaglioEntity> entity)
    {
        entity.ToTable("PrenotazioneDettaglio");
        entity.HasKey(prenotazione => prenotazione.Id);
    }
}