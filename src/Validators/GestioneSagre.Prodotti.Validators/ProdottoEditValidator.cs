namespace GestioneSagre.Prodotti.Validators;

public class ProdottoEditValidator : AbstractValidator<ProdottoEditInputModel>
{
    public ProdottoEditValidator()
    {
        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della categoria è obbligatorio");

        //RuleFor(x => x.CategoriaId)
        //    .NotEmpty().WithMessage("L'Id della categoria è obbligatorio");

        RuleFor(x => x.Prodotto)
            .NotEmpty().WithMessage("Il prodotto è obbligatorio");

        RuleFor(x => x.Prezzo)
            .NotEmpty().WithMessage("Il prezzo è obbligatorio");

        RuleFor(x => x.Quantita)
            .NotEmpty().WithMessage("La quantità è obbligatoria");
    }
}