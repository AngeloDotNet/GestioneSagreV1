using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Core.Models.Options;
using GestioneSagre.Models.InputSender;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SequentialGuid;

namespace GestioneSagre.Domain.Services.Application.Internal;
public class EfCoreInternalService : IInternalService
{
    private readonly IOptionsMonitor<SmtpOptions> smtpOptionsMonitor;
    private readonly ILogger<EfCoreInternalService> logger;

    public EfCoreInternalService(IOptionsMonitor<SmtpOptions> smtpOptionsMonitor, ILogger<EfCoreInternalService> logger)
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

            var builder = new BodyBuilder();

            builder.HtmlBody = model.Messaggio;
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