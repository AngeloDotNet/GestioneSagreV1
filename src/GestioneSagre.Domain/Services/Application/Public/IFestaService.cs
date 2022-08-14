using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Models.InputModels;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.Domain.Services.Application.Public;
public interface IFestaService
{
    //COMMAND QUERY
    Task<List<FestaViewModel>> GetFesteAsync();
    Task<FestaViewModel> GetFestaAsync(string guidFesta);
    Task<int> GetCountFesteAsync();

    //COMMAND STACK
    Task<FestaViewModel> CreateFestaAsync(FestaInputModel inputModel);
    Task<FestaViewModel> EditFestaAsync(FestaInputModel inputModel);
    Task DeleteFestaAsync(string guidFesta, int Id);
}