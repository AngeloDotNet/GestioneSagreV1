namespace GestioneSagre.Internal.QueryStack;

public interface IInternalQueryStackService
{
    Task<string> GenerateGuid();
    Task<string> GenerateImageDefault();
    Task SendEmailSupportoAsync(MailSupportoInputSender model);
}
