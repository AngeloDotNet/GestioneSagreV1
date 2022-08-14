namespace GestioneSagre.Models.InputModels;

public class VersioneInputModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }

    public static VersioneInputModel FromEntity(VersioneEntity entity)
    {
        return new VersioneInputModel
        {
            Id = entity.Id,
            CodiceVersione = entity.CodiceVersione,
            TestoVersione = entity.TestoVersione,
            VersioneStato = entity.VersioneStato,
        };
    }
}
