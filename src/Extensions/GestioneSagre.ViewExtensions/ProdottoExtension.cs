namespace GestioneSagre.ViewExtensions;

public static class ProdottoExtension
{
    public static ProdottoViewModel ToProdottoViewModel(this ProdottoEntity dataRow)
    {
        return new ProdottoViewModel
        {
            Id = dataRow.Id,
            GuidFesta = dataRow.GuidFesta,
            CategoriaId = dataRow.CategoriaId,
            Prodotto = dataRow.Prodotto,
            ProdottoAttivo = dataRow.ProdottoAttivo,
            Prezzo = dataRow.Prezzo,
            Quantita = dataRow.Quantita,
            QuantitaAttiva = dataRow.QuantitaAttiva,
            QuantitaScorta = dataRow.QuantitaScorta,
            AvvisoScorta = dataRow.AvvisoScorta,
            Prenotazione = dataRow.Prenotazione,
        };
    }
}
