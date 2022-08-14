using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Core.Models.Enums;
using GestioneSagre.Models.InputModels;

namespace GestioneSagre.Models.ViewModels;
public class VersioneViewModel
{
    public int Id { get; set; }
    public string CodiceVersione { get; set; }
    public string TestoVersione { get; set; }
    public VersioneStato VersioneStato { get; set; }

    public static VersioneViewModel FromEntity(VersioneEntity entity)
    {
        return new VersioneViewModel
        {
            Id = entity.Id,
            CodiceVersione = entity.CodiceVersione,
            TestoVersione = entity.TestoVersione,
            VersioneStato = entity.VersioneStato,
        };
    }
}