namespace GestioneSagre.Categorie.Validators;

public class CategoriaCreateValidator : AbstractValidator<CategoriaCreateInputModel>
{
    public CategoriaCreateValidator()
    {
        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della festa è obbligatorio");

        RuleFor(x => x.CategoriaVideo)
            .NotEmpty().WithMessage("La categoria video è obbligatoria");

        RuleFor(x => x.CategoriaStampa)
            .NotEmpty().WithMessage("La categoria stampa è obbligatoria");
    }
}