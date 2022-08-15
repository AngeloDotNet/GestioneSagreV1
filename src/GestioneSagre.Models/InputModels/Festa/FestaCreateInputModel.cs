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
    public string Logo { get; set; }
    public bool GestioneCoperti { get; set; }
    public bool GestioneMenu { get; set; }
    public bool StampaCarta { get; set; }
    public bool StampaLogo { get; set; }
    public bool StampaRicevuta { get; set; }
    public FestaStato StatusFesta { get; set; }

    //public static FestaCreateInputModel FromEntity(FestaEntity entity)
    //{
    //    return new FestaCreateInputModel
    //    {
    //        Id = entity.Id,
    //        GuidFesta = entity.GuidFesta,
    //        DataInizio = entity.DataInizio,
    //        DataFine = entity.DataFine,
    //        Titolo = entity.Titolo,
    //        Edizione = entity.Edizione,
    //        Luogo = entity.Luogo,
    //        Logo = entity.Logo,
    //        GestioneCoperti = entity.GestioneCoperti,
    //        GestioneMenu = entity.GestioneMenu,
    //        StampaCarta = entity.StampaCarta,
    //        StampaLogo = entity.StampaLogo,
    //        StampaRicevuta = entity.StampaRicevuta,
    //        StatusFesta = entity.StatusFesta,
    //    };
    //}
}
