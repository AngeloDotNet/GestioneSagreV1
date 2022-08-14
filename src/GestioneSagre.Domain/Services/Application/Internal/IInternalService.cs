using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Models.InputSender;

namespace GestioneSagre.Domain.Services.Application.Internal;

public interface IInternalService
{
    Task<string> GenerateGuid();
    Task<string> GenerateImageDefault();
    Task SendEmailSupportoAsync(MailSupportoInputSender model);
}