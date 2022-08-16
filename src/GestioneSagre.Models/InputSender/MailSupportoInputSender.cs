namespace GestioneSagre.Models.InputSender;

public partial class MailSupportoInputSender
{
    public string MittenteNominativo { get; set; }
    public string MittenteEmail { get; set; }
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