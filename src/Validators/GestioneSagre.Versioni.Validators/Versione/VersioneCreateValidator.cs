namespace GestioneSagre.Versioni.Validators.Versione;

public class VersioneCreateValidator : AbstractValidator<VersioneCreateInputModel>
{
    public VersioneCreateValidator()
    {
        RuleFor(x => x.CodiceVersione)
            .NotNull().NotEmpty().WithMessage("Il codice della versione è obbligatorio");

        RuleFor(x => x.TestoVersione)
            .NotNull().NotEmpty().WithMessage("Il testo della versione è obbligatorio");

        RuleFor(x => Convert.ToInt32(x.VersioneStato))
            .InclusiveBetween(0, 1).WithMessage("Lo stato della versione dev'essere 0 oppure 1");
    }
}