using Microsoft.AspNetCore.Http;

namespace GestioneSagre.Models.InputModels.Festa;

public class FestaCreateInputModel
{
    public int Id { get; set; }
    public string GuidFesta { get; set; }
    public string DataInizio { get; set; }
    public string DataFine { get; set; }
    public string Titolo { get; set; }
    public string Edizione { get; set; }
    public string Luogo { get; set; }
    //public string Logo { get; set; }
    public IFormFile Logo { get; set; }
    public bool GestioneCoperti { get; set; }
    public bool GestioneMenu { get; set; }
    public bool StampaCarta { get; set; }
    public bool StampaLogo { get; set; }
    public bool StampaRicevuta { get; set; }
    public FestaStato StatusFesta { get; set; }
}