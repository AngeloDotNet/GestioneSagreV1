using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Models.InputModels;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IVersioneService
{
    //COMMAND QUERY
    Task<List<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string codiceVersione);
    Task<bool> IsVersioneAvailableAsync(string codiceVersione, int id);

    //COMMAND STACK
    Task<VersioneViewModel> CreateVersioneAsync(VersioneInputModel inputModel);
    Task DeleteVersioneAsync(int id);
}
