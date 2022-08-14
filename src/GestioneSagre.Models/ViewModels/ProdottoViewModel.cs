using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Core.Models.Entities;
using GestioneSagre.Core.Models.ValueObjects;
using GestioneSagre.Models.InputModels;

namespace GestioneSagre.Models.ViewModels;
public class ProdottoViewModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public int CategoriaId { get; set; }
    public string Prodotto { get; set; }
    public bool ProdottoAttivo { get; set; }
    public Money Prezzo { get; set; }
    public int Quantita { get; set; }
    public bool QuantitaAttiva { get; set; }
    public int QuantitaScorta { get; set; }
    public bool AvvisoScorta { get; set; }
    public bool Prenotazione { get; set; }

    public static ProdottoViewModel FromEntity(ProdottoEntity entity)
    {
        return new ProdottoViewModel
        {
            Id = entity.Id,
            GuidFesta = entity.GuidFesta,
            CategoriaId = entity.CategoriaId,
            Prodotto = entity.Prodotto,
            ProdottoAttivo = entity.ProdottoAttivo,
            Prezzo = entity.Prezzo,
            Quantita = entity.Quantita,
            QuantitaAttiva = entity.QuantitaAttiva,
            QuantitaScorta = entity.QuantitaScorta,
            AvvisoScorta = entity.AvvisoScorta,
            Prenotazione = entity.Prenotazione,
        };
    }
}