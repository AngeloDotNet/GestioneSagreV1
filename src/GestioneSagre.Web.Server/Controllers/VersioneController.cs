﻿namespace GestioneSagre.Web.Server.Controllers;

public class VersioneController : BaseController
{
    private readonly IVersioneCommandStackService commandService;
    private readonly IVersioneQueryStackService queryService;
    private readonly IValidator<VersioneCreateInputModel> versioneCreateValidator;

    public VersioneController(CommandStackVersioneService commandVersioneService,
                              VersioneQueryStackService queryVersioneService,
                              IValidator<VersioneCreateInputModel> versioneCreateValidator)
    {
        this.commandService = commandVersioneService;
        this.queryService = queryVersioneService;
        this.versioneCreateValidator = versioneCreateValidator;
    }

    /// <summary>
    /// Elenco di versioni software
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
    /// Dettagli di una specifica versione software
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
    /// Nuova versione software
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
        var validation = await versioneCreateValidator.ValidateAsync(inputModel);
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