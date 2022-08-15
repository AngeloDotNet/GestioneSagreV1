namespace GestioneSagre.Models.InputModels.Versione;

public class VersioneCreateInputModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }

    //public static VersioneCreateInputModel FromEntity(VersioneEntity entity)
    //{
    //    return new VersioneCreateInputModel
    //    {
    //        Id = entity.Id,
    //        CodiceVersione = entity.CodiceVersione,
    //        TestoVersione = entity.TestoVersione,
    //        VersioneStato = entity.VersioneStato,
    //    };
    //}
}
