namespace GestioneSagre.Categorie.Validators;

public class CategoriaEditValidator : AbstractValidator<CategoriaEditInputModel>
{
    public CategoriaEditValidator()
    {
        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della categoria è obbligatorio");

        RuleFor(x => x.CategoriaVideo)
            .NotEmpty().WithMessage("La categoria video è obbligatoria");

        RuleFor(x => x.CategoriaStampa)
            .NotEmpty().WithMessage("La categoria stampa è obbligatoria");
    }
}