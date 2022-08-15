namespace GestioneSagre.Domain.Services.Application.Interfaces;

public interface IInternalService
{
    Task<string> GenerateGuid();
    Task<string> GenerateImageDefault();
    Task SendEmailSupportoAsync(MailSupportoInputSender model);
}