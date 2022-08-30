using System.ComponentModel.DataAnnotations;
using MailKit.Security;

namespace GestioneSagre.Models.InputSender;

public partial class MailSupportoInputSender
{
    [Required(ErrorMessage = "Il nominativo di contatto è obbligatorio")]
    public string MittenteNominativo { get; set; }
    [Required(ErrorMessage = "L'email di contatto è obbligatoria")]
    public string MittenteEmail { get; set; }
    [Required(ErrorMessage = "Il messaggio è obbligatorio")]
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