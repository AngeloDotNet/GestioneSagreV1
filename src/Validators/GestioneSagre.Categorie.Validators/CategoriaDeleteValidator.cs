namespace GestioneSagre.Categorie.Validators;
public class CategoriaDeleteValidator : AbstractValidator<CategoriaDeleteInputModel>
{
    public CategoriaDeleteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("L'ID è obbligatorio");

        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della categoria è obbligatorio");
    }
}