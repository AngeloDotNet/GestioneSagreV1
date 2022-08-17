namespace GestioneSagre.Internal.Validators.EmailSender;

public class MailSupportoSenderValidator : AbstractValidator<MailSupportoInputSender>
{
    public MailSupportoSenderValidator()
    {
        RuleFor(x => x.MittenteNominativo)
            .NotEmpty().WithMessage("Il nominativo del mittente è obbligatorio");

        RuleFor(x => x.MittenteEmail)
            .NotEmpty().EmailAddress().WithMessage("L'indirizzo email del mittente è obbligatorio");

        RuleFor(x => x.Messaggio)
            .NotEmpty().WithMessage("Il messaggio è obbligatorio");

    }
}