namespace GestioneSagre.Models.InputModels.Prodotto;

public class ProdottoCreateInputModel
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

    //public static ProdottoInputModel FromEntity(ProdottoEntity entity)
    //{
    //    return new ProdottoInputModel
    //    {
    //        Id = entity.Id,
    //        GuidFesta = entity.GuidFesta,
    //        CategoriaId = entity.CategoriaId,
    //        Prodotto = entity.Prodotto,
    //        ProdottoAttivo = entity.ProdottoAttivo,
    //        Prezzo = entity.Prezzo,
    //        Quantita = entity.Quantita,
    //        QuantitaAttiva = entity.QuantitaAttiva,
    //        QuantitaScorta = entity.QuantitaScorta,
    //        AvvisoScorta = entity.AvvisoScorta,
    //        Prenotazione = entity.Prenotazione,
    //    };
    //}
}