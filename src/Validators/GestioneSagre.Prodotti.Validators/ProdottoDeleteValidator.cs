namespace GestioneSagre.Prodotti.Validators;

public class ProdottoDeleteValidator : AbstractValidator<ProdottoDeleteInputModel>
{
    public ProdottoDeleteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("L'ID è obbligatorio");

        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della categoria è obbligatorio");
    }
}