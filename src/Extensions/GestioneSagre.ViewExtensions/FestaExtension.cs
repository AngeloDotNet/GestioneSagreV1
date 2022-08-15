namespace GestioneSagre.ViewExtensions;

public static class FestaExtension
{
    public static FestaViewModel ToFestaViewModel(this FestaEntity dataRow)
    {
        return new FestaViewModel
        {
            Id = dataRow.Id,
            GuidFesta = dataRow.GuidFesta,
            DataInizio = dataRow.DataInizio,
            DataFine = dataRow.DataFine,
            Titolo = dataRow.Titolo,
            Edizione = dataRow.Edizione,
            Luogo = dataRow.Luogo,
            Logo = dataRow.Logo,
            GestioneCoperti = dataRow.GestioneCoperti,
            GestioneMenu = dataRow.GestioneMenu,
            StampaCarta = dataRow.StampaCarta,
            StampaLogo = dataRow.StampaLogo,
            StampaRicevuta = dataRow.StampaRicevuta,
            StatusFesta = dataRow.StatusFesta,
        };
    }
}
