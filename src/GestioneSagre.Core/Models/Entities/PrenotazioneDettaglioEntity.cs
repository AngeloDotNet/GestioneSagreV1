namespace GestioneSagre.Core.Models.Entities;

public class PrenotazioneDettaglioEntity
{
    public int Id { get; set; }
    public int PrenotazioneId { get; set; }
    public string Prodotto { get; set; }
    public int Quantita { get; set; }
    public Money Prezzo { get; set; }
    public Money Totale { get; set; }
}