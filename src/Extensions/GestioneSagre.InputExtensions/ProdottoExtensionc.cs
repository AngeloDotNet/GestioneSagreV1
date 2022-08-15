namespace GestioneSagre.InputExtensions;

public static class ProdottoExtensionc
{
    public static ProdottoEditInputModel ToProdottoEditInputModel(this ProdottoEntity dataRow)
    {
        return new ProdottoEditInputModel
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
