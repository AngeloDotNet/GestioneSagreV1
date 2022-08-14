using System.ComponentModel.DataAnnotations;

namespace GestioneSagre.Core.Models.Enums;

public enum VersioneStato
{
    [Display(Name = "Attiva")]
    Attiva,

    [Display(Name = "Deprecata")]
    Deprecata
}