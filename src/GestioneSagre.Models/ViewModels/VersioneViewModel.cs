namespace GestioneSagre.Models.ViewModels;

public class VersioneViewModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }

    //public static VersioneViewModel FromEntity(VersioneEntity entity)
    //{
    //    return new VersioneViewModel
    //    {
    //        Id = entity.Id,
    //        CodiceVersione = entity.CodiceVersione,
    //        TestoVersione = entity.TestoVersione,
    //        VersioneStato = entity.VersioneStato,
    //    };
    //}
}