namespace GestioneSagre.Web.InternalApi.Controllers;

public class InternalController : BaseController
{
    private readonly IInternalQueryStackService queryService;
    private readonly ILogger<InternalController> logger;

    public InternalController(ILogger<InternalController> logger, IInternalQueryStackService queryService)
    {
        this.logger = logger;
        this.queryService = queryService;
    }

    /// <summary>
    /// Generazione guid
    /// </summary>
    /// <response code="200">Guid generato con successo</response>
    [AllowAnonymous]
    [HttpGet("GeneraGuid")]
    public Task<string> GenerateGuid()
    {
        return queryService.GenerateGuid();
    }

    /// <summary>
    /// Generazione immagine standard
    /// </summary>
    /// <response code="200">Immagine default generata con successo</response>
    [AllowAnonymous]
    [HttpGet("GeneraImmagine")]
    public Task<string> GenerateImageDefault()
    {
        return queryService.GenerateImageDefault();
    }
}