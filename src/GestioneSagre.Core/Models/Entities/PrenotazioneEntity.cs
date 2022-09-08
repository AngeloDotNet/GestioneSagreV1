namespace GestioneSagre.Core.Models.Entities;

public class PrenotazioneEntity
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string Riferimento { get; set; }
    public string Nominativo { get; set; }
    public string DataPrenotazione { get; set; }
    public string OraPrenotazione { get; set; }
    public PrenotazioneStato StatoPrenotazione { get; set; }
}