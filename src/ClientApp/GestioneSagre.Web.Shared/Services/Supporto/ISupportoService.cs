namespace GestioneSagre.Web.Shared.Services.Supporto;

public interface ISupportoService
{
    Task InvioEmailSupportoAsync(MailSupportoInputSender input);
}