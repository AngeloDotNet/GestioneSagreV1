namespace GestioneSagre.Models.ViewModels;

public class VersioneViewModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }
}