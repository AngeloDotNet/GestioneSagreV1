namespace GestioneSagre.Internal.QueryStack;

public class InternalQueryStackService : IInternalQueryStackService
{
    private readonly ILogger<InternalQueryStackService> logger;
    private readonly IOptionsMonitor<SmtpOptions> smtpOptionsMonitor;

    public InternalQueryStackService(ILogger<InternalQueryStackService> logger, IOptionsMonitor<SmtpOptions> smtpOptionsMonitor)
    {
        this.logger = logger;
        this.smtpOptionsMonitor = smtpOptionsMonitor;
    }

    public Task<string> GenerateGuid()
    {
        var newGuid = SequentialGuidGenerator.Instance.NewGuid().ToString();

        return Task.FromResult(newGuid);
    }

    public Task<string> GenerateImageDefault()
    {
        var imageDefault = "/images/default.png";

        return Task.FromResult(imageDefault);
    }

    public async Task SendEmailSupportoAsync(MailSupportoInputSender model)
    {
        try
        {
            var options = model.OptionSender;

            using SmtpClient client = new();

            await client.ConnectAsync(options.Host, options.Port, options.Security);

            if (!string.IsNullOrEmpty(options.Username))
            {
                await client.AuthenticateAsync(options.Username, options.Password);
            }

            MimeMessage message = new();

            message.From.Add(MailboxAddress.Parse($"{model.MittenteNominativo} <{model.MittenteEmail}>"));
            message.To.Add(MailboxAddress.Parse($"{options.DestinatarioNominativo} <{options.DestinatarioEmail}>"));
            message.Subject = options.Oggetto;

            var builder = new BodyBuilder
            {
                HtmlBody = model.Messaggio
            };

            message.Body = builder.ToMessageBody();

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
