namespace GestioneSagre.Models.ViewModels;

public class CategoriaViewModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string CategoriaVideo { get; set; }
    public string CategoriaStampa { get; set; }

    //public static CategoriaViewModel FromEntity(CategoriaEntity entity)
    //{
    //    return new CategoriaViewModel
    //    {
    //        Id = entity.Id,
    //        GuidFesta = entity.GuidFesta,
    //        CategoriaVideo = entity.CategoriaVideo,
    //        CategoriaStampa = entity.CategoriaStampa,
    //    };
    //}
}
