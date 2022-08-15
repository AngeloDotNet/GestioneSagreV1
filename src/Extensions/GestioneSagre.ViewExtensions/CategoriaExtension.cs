namespace GestioneSagre.ViewExtensions;

public static class CategoriaExtension
{
    public static CategoriaViewModel ToCategoriaViewModel(this CategoriaEntity dataRow)
    {
        return new CategoriaViewModel
        {
            Id = dataRow.Id,
            GuidFesta = dataRow.GuidFesta,
            CategoriaVideo = dataRow.CategoriaVideo,
            CategoriaStampa = dataRow.CategoriaStampa,
        };
    }
}
