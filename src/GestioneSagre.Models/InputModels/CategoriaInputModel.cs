namespace GestioneSagre.Models.InputModels;

public class CategoriaInputModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string CategoriaVideo { get; set; }
    public string CategoriaStampa { get; set; }

    public static CategoriaInputModel FromEntity(CategoriaEntity entity)
    {
        return new CategoriaInputModel
        {
            Id = entity.Id,
            GuidFesta = entity.GuidFesta,
            CategoriaVideo = entity.CategoriaVideo,
            CategoriaStampa = entity.CategoriaStampa,
        };
    }
}
