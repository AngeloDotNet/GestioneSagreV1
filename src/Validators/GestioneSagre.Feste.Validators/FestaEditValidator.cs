namespace GestioneSagre.Feste.Validators;

public class FestaEditValidator : AbstractValidator<FestaEditInputModel>
{
    public FestaEditValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("L'ID è obbligatorio");

        RuleFor(x => x.GuidFesta)
            .NotEmpty().WithMessage("Il guid della festa è obbligatorio");

        RuleFor(x => x.DataInizio)
            .NotEmpty().WithMessage("La data di inizio della festa è obbligatoria");

        RuleFor(x => x.DataFine)
            .NotEmpty().WithMessage("La data di fine della festa è obbligatoria");

        RuleFor(x => x.Titolo)
            .NotEmpty().WithMessage("Il titolo della festa è obbligatorio");

        RuleFor(x => x.Edizione)
            .NotEmpty().WithMessage("L'edizione della festa è obbligatorio");

        RuleFor(x => x.Luogo)
            .NotEmpty().WithMessage("Il luogo della festa è obbligatorio");

        //RuleFor(x => x.Logo)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.GestioneCoperti)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.GestioneMenu)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.StampaCarta)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.StampaLogo)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.StampaRicevuta)
        //    .NotEmpty().WithMessage("");

        //RuleFor(x => x.StatusFesta)
        //    .NotEmpty().WithMessage("");
    }
}