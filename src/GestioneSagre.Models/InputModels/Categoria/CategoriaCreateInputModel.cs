namespace GestioneSagre.Models.InputModels.Categoria;

public class CategoriaCreateInputModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string CategoriaVideo { get; set; }
    public string CategoriaStampa { get; set; }

    //public static CategoriaCreateInputModel FromEntity(CategoriaEntity entity)
    //{
    //    return new CategoriaCreateInputModel
    //    {
    //        Id = entity.Id,
    //        GuidFesta = entity.GuidFesta,
    //        CategoriaVideo = entity.CategoriaVideo,
    //        CategoriaStampa = entity.CategoriaStampa,
    //    };
    //}
}
