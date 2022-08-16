namespace GestioneSagre.Web.Server.Options;

public class SmtpOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public SecureSocketOptions Security { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Sender { get; set; }
    public SmtpExtendOptions SmtpExtendOptions { get; set; }
}

public partial class SmtpExtendOptions
{
    public string Support { get; set; }
}