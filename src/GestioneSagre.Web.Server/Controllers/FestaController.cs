using GestioneSagre.Models.ViewModel;

namespace GestioneSagre.Web.Server.Controllers;

public class FestaController : BaseController
{
    private readonly IFestaCommandStackService commandService;
    private readonly IFestaQueryStackService queryService;
    private readonly IValidator<FestaCreateInputModel> festaCreateValidator;
    private readonly IValidator<FestaEditInputModel> festaEditValidator;
    private readonly IValidator<FestaDeleteInputModel> festaDeleteValidator;

    public FestaController(IFestaCommandStackService commandService, IFestaQueryStackService queryService, IValidator<FestaCreateInputModel> festaCreateValidator, IValidator<FestaEditInputModel> festaEditValidator, IValidator<FestaDeleteInputModel> festaDeleteValidator)
    {
        this.commandService = commandService;
        this.queryService = queryService;
        this.festaCreateValidator = festaCreateValidator;
        this.festaEditValidator = festaEditValidator;
        this.festaDeleteValidator = festaDeleteValidator;
    }

    /// <summary>
    /// Elenco delle feste
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFesteAsync()
    {
        try
        {
            var festa = await queryService.GetFesteAsync();

            return Ok(festa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Dettagli di una specifica festa
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpGet("{guidFesta:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFestaAsync(string guidFesta)
    {
        try
        {
            var festa = await queryService.GetFestaAsync(guidFesta);

            if (festa == null)
            {
                return NotFound();
            }

            return Ok(festa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Nuova festa
    /// </summary>
    /// <param name="inputModel">Inserisce le informazioni sulla festa</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(FestaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateFestaAsync(FestaCreateInputModel inputModel)
    {
        var validation = await festaCreateValidator.ValidateAsync(inputModel);
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
            var categoria = await commandService.CreateFestaAsync(inputModel);
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Modifica i dati di una festa
    /// </summary>
    /// <param name="inputModel">Modifica le informazioni della festa</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpPut]
    [ProducesResponseType(typeof(FestaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditFestaAsync(FestaEditInputModel inputModel)
    {
        var validation = await festaEditValidator.ValidateAsync(inputModel);
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
            var festa = await commandService.EditFestaAsync(inputModel);
            return Ok(festa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Cancella una festa
    /// </summary>
    /// <param name="inputModel">Cancella le informazioni della festa</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFestaAsync(FestaDeleteInputModel inputModel)
    {
        var validation = await festaDeleteValidator.ValidateAsync(inputModel);
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
            await commandService.DeleteFestaAsync(inputModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}