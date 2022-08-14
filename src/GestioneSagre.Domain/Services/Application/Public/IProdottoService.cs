using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Models.InputModels;
using GestioneSagre.Models.ViewModels;

namespace GestioneSagre.Domain.Services.Application.Public;
public interface IProdottoService
{
    //COMMAND QUERY
    Task<List<ProdottoViewModel>> GetProdottiAsync();
    Task<ProdottoViewModel> GetProdottoAsync(string guidFesta, int id);
    Task<bool> IsProdottoAvailableAsync(string guidFesta, string prodotto, int id);
    Task<int> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId);

    //COMMAND STACK
    Task<ProdottoViewModel> CreateProdottoAsync(ProdottoInputModel inputModel);
    Task<ProdottoViewModel> EditProdottoAsync(ProdottoInputModel inputModel);
    Task DeleteProdottoAsync(string guidFesta, int Id);
}