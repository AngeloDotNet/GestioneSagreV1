namespace GestioneSagre.InputExtensions;

public static class CategoriaExtension
{
    public static CategoriaEditInputModel ToCategoriaEditInputModel(this CategoriaEntity dataRow)
    {
        return new CategoriaEditInputModel
        {
            Id = dataRow.Id,
            GuidFesta = dataRow.GuidFesta,
            CategoriaVideo = dataRow.CategoriaVideo,
            CategoriaStampa = dataRow.CategoriaStampa,
        };
    }
}
