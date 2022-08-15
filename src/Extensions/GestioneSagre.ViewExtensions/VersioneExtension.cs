using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.ViewExtensions;

public static class VersioneExtension
{
    public static VersioneViewModel ToVersioneViewModel(this VersioneEntity dataRow)
    {
        return new VersioneViewModel
        {
            Id = dataRow.Id,
            CodiceVersione = dataRow.CodiceVersione,
            TestoVersione = dataRow.TestoVersione,
            VersioneStato = dataRow.VersioneStato
        };
    }
}
