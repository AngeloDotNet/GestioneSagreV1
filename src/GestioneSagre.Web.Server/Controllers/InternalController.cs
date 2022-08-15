using Microsoft.AspNetCore.Authorization;

namespace GestioneSagre.Web.Server.Controllers;

public class InternalController : BaseController
{
    private readonly IInternalService internalService;

    public InternalController(IInternalService internalService)
    {
        this.internalService = internalService;
    }

    [AllowAnonymous]
    [HttpGet("GeneraGuid")]
    public Task<string> GenerateGuid()
    {
        return internalService.GenerateGuid();
    }

    [AllowAnonymous]
    [HttpGet("GeneraImmagineDefault")]
    public Task<string> GenerateImageDefault()
    {
        return internalService.GenerateImageDefault();
    }
}