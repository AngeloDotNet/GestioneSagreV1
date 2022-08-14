using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Models.InputModels;

namespace GestioneSagre.Models.ViewModels;
public class CategoriaViewModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string CategoriaVideo { get; set; }
    public string CategoriaStampa { get; set; }

    public static CategoriaViewModel FromEntity(CategoriaEntity entity)
    {
        return new CategoriaViewModel
        {
            Id = entity.Id,
            GuidFesta = entity.GuidFesta,
            CategoriaVideo = entity.CategoriaVideo,
            CategoriaStampa = entity.CategoriaStampa,
        };
    }
}
