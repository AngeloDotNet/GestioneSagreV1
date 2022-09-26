namespace GestioneSagre.Mapper;

public class CategoriaMapper : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> entity)
    {
        entity.ToTable("Categoria");
        entity.HasKey(categoria => categoria.Id);
    }
}