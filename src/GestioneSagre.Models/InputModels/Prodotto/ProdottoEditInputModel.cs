namespace GestioneSagre.Models.InputModels.Prodotto;
public class ProdottoEditInputModel
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
}
