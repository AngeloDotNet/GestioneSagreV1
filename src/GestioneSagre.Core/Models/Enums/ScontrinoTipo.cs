using System.ComponentModel.DataAnnotations;

namespace GestioneSagre.Core.Models.Enums;
public enum ScontrinoTipo
{
    [Display(Name = "Pagamento")]
    Pagamento,

    [Display(Name = "Omaggio")]
    Omaggio
}
