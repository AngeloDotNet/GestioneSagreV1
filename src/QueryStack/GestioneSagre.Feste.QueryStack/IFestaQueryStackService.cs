using GestioneSagre.Core.Models.Enums;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.Feste.QueryStack;

public interface IFestaQueryStackService
{
    Task<List<FestaViewModel>> GetFesteAsync();
    Task<FestaViewModel> GetFestaAsync(string guidFesta);
    Task<int> GetCountFesteAsync(FestaStato statusFesta);
}