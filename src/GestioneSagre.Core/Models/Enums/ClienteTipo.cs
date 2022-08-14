using System.ComponentModel.DataAnnotations;

namespace GestioneSagre.Core.Models.Enums;
public enum ClienteTipo
{
    [Display(Name = "Cliente")]
    Cliente,

    [Display(Name = "Staff")]
    Staff
}
