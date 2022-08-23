namespace GestioneSagre.Feste.Validators;

public class FestaDeleteValidator : AbstractValidator<FestaDeleteInputModel>
{
    public FestaDeleteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("L'ID è obbligatorio");

        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della caegoria è obbligatorio");
    }
}