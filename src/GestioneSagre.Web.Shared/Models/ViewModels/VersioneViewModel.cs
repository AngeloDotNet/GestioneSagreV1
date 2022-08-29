using System.ComponentModel.DataAnnotations;

namespace GestioneSagre.Web.Shared.Models.ViewModels;

public class VersioneViewModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }
}

public enum VersioneStato
{
    [Display(Name = "Attiva")]
    Attiva,

    [Display(Name = "Deprecata")]
    Deprecata
}