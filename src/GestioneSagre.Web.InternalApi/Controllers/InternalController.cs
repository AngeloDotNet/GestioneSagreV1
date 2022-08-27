namespace GestioneSagre.Web.InternalApi.Controllers;

public class InternalController : BaseController
{
    private readonly IInternalQueryStackService queryService;
    private readonly IOptionsMonitor<SmtpOptions> smtpOptionsMonitor;
    private readonly ILogger<InternalController> logger;
    private readonly IValidator<MailSupportoInputSender> mailSupportoValidator;

    public InternalController(IOptionsMonitor<SmtpOptions> smtpOptionsMonitor,
                              ILogger<InternalController> logger,
                              IValidator<MailSupportoInputSender> mailSupportoValidator,
                              IInternalQueryStackService queryService)
    {
        this.smtpOptionsMonitor = smtpOptionsMonitor;
        this.logger = logger;
        this.mailSupportoValidator = mailSupportoValidator;
        this.queryService = queryService;
    }

    ///// <summary>
    ///// Generazione guid
    ///// </summary>
    ///// <response code="200">Guid generato con successo</response>
    //[AllowAnonymous]
    //[HttpGet("GeneraGuid")]
    //public Task<string> GenerateGuid()
    //{
    //    return queryService.GenerateGuid();
    //}

    ///// <summary>
    ///// Generazione immagine standard
    ///// </summary>
    ///// <response code="200">Immagine default generata con successo</response>
    //[AllowAnonymous]
    //[HttpGet("GeneraImmagine")]
    //public Task<string> GenerateImageDefault()
    //{
    //    return queryService.GenerateImageDefault();
    //}

    /// <summary>
    /// Invio email al supporto
    /// </summary>
    /// <response code="200">Email inviata con successo</response>
    /// <response code="400">Email non inviata causa errori</response>
    [AllowAnonymous]
    [HttpPost("InvioEmailSupporto")]
    [ProducesResponseType(typeof(MailSupportoInputSender), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InvioEmailSupportoAsync(MailSupportoInputSender inputModel)
    {
        var validation = await mailSupportoValidator.ValidateAsync(inputModel);
        List<string> listaErrori = new();

        if (!validation.IsValid)
        {
            foreach (var item in validation.Errors)
            {
                listaErrori.Add(item.ErrorMessage);
            }

            return StatusCode(StatusCodes.Status400BadRequest, listaErrori);
        }

        try
        {
            var options = smtpOptionsMonitor.CurrentValue;
            var customOptions = new InputMailOptionSender
            {
                DestinatarioNominativo = "Supporto Gestione Sagre",
                DestinatarioEmail = "supporto.gestionesagre@aepserver.it",
                Oggetto = "Richiesta di supporto",
                Host = options.Host,
                Port = options.Port,
                Security = options.Security,
                Username = options.Username,
                Password = options.Password
            };

            await queryService.SendEmailSupportoAsync(inputModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}