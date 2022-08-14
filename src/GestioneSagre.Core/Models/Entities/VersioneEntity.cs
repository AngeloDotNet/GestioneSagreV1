namespace GestioneSagre.Core.Models.Entities;

public class VersioneEntity
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }
}