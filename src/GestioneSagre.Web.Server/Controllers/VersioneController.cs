using GestioneSagre.Models.InputModels.Versione;
using GestioneSagre.Models.ViewModels;
using GestioneSagre.Versioni.CommandStack;
using GestioneSagre.Versioni.QueryStack;
using Microsoft.AspNetCore.Authorization;

namespace GestioneSagre.Web.Server.Controllers;

public class VersioneController : BaseController
{
    private readonly IVersioneCommandStackService commandService;
    private readonly IVersioneQueryStackService queryService;

    public VersioneController(CommandStackVersioneService commandVersioneService, QueryStackVersioneService queryVersioneService)
    {
        this.commandService = commandVersioneService;
        this.queryService = queryVersioneService;
    }

    /// <summary>
    /// Mostra un elenco di versioni software
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVersioniAsync()
    {
        try
        {
            List<VersioneViewModel> versione = await queryService.GetVersioniAsync();

            return Ok(versione);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Mostra i dettagli di una specifica versione software
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpGet("{codiceVersione:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVersioneAsync(Guid codiceVersione)
    {
        try
        {
            var codice = codiceVersione.ToString();

            VersioneViewModel versione = await queryService.GetVersioneAsync(codice);

            if (versione == null)
            {
                return NotFound();
            }

            return Ok(versione);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Crea una nuova versione software
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 409 - Conflict</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(VersioneViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateVersioneAsync(VersioneCreateInputModel inputModel)
    {
        try
        {
            bool bRes = await queryService.IsVersioneAvailableAsync(inputModel.TestoVersione, 0);

            if (!bRes)
            {
                return Conflict("Versione già presente");
            }
            else
            {
                VersioneViewModel versione = await commandService.CreateVersioneAsync(inputModel);
                return Ok(versione);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //DeleteVersioneAsync (valutare se implementare questa funzione)
}
