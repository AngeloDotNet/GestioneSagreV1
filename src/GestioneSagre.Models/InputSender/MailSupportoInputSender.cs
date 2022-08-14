using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;

namespace GestioneSagre.Models.InputSender;
public partial class MailSupportoInputSender
{
    [Required]
    public string MittenteNominativo { get; set; }

    [Required]
    public string MittenteEmail { get; set; }

    [Required]
    public string Messaggio { get; set; }

    public InputMailOptionSender OptionSender { get; set; }
}

public partial class InputMailOptionSender
{
    public string DestinatarioNominativo { get; set; }
    public string DestinatarioEmail { get; set; }
    public string Oggetto { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public SecureSocketOptions Security { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}