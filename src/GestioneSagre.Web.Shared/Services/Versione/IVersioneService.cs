using GestioneSagre.Web.Shared.Models.ViewModels;

namespace GestioneSagre.Web.Shared.Services.Versione;

public interface IVersioneService
{
    Task<VersioneViewModel> GetVersione();
}