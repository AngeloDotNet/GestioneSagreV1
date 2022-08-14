using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Models.InputModels;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.Domain.Services.Application.Public;

public interface IVersioneService
{
    //COMMAND QUERY
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string CodiceVersione);
    Task<bool> IsVersioneAvailableAsync(string title, int excludeId);

    //COMMAND STACK
    Task<VersioneViewModel> CreateVersioneAsync(VersioneInputModel inputModel);
    Task DeleteVersioneAsync(string CodiceVersione);
}
