namespace GestioneSagre.Mapper;

public class ProdottoMapper : IEntityTypeConfiguration<ProdottoEntity>
{
    public void Configure(EntityTypeBuilder<ProdottoEntity> entity)
    {
        entity.ToTable("Prodotto");
        entity.HasKey(prodotto => prodotto.Id);
    }
}