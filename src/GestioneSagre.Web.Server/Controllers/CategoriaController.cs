namespace GestioneSagre.Web.Server.Controllers;

public class CategoriaController : BaseController
{
    private readonly ICategoriaCommandStackService commandService;
    private readonly ICategoriaQueryStackService queryService;
    private readonly IValidator<CategoriaCreateInputModel> categoriaCreateValidator;
    private readonly IValidator<CategoriaEditInputModel> categoriaEditValidator;
    private readonly IValidator<CategoriaDeleteInputModel> categoriaDeleteValidator;

    public CategoriaController(ICategoriaCommandStackService commandService,
                               ICategoriaQueryStackService queryService,
                               IValidator<CategoriaCreateInputModel> categoriaCreateValidator,
                               IValidator<CategoriaEditInputModel> categoriaEditValidator,
                               IValidator<CategoriaDeleteInputModel> categoriaDeleteValidator)
    {
        this.commandService = commandService;
        this.queryService = queryService;
        this.categoriaCreateValidator = categoriaCreateValidator;
        this.categoriaEditValidator = categoriaEditValidator;
        this.categoriaDeleteValidator = categoriaDeleteValidator;
    }

    /// <summary>
    /// Elenco delle categorie
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCategorieAsync()
    {
        try
        {
            var categoria = await queryService.GetCategorieAsync();

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Dettagli di una specifica categoria
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpGet("{guidFesta:guid}/{categoriaVideo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategoriaAsync(string guidFesta, string categoriaVideo)
    {
        try
        {
            var categoria = await queryService.GetCategoriaAsync(guidFesta, categoriaVideo);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Conteggio prodotti di una specifica categoria
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="204">Codice 204 - No Content</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpGet("{guidFesta:guid}/{categoriaId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCountProdottiByCategoriaAsync(string guidFesta, int categoriaId)
    {
        try
        {
            var counter = await queryService.GetCountProdottiByCategoriaAsync(guidFesta, categoriaId);

            if (counter == 0)
            {
                return NoContent();
            }

            return Ok(counter);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Nuova categoria
    /// </summary>
    /// <param name="inputModel">Inserisce le informazioni sulla categoria</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="409">Codice 409 - Conflict</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateCategoriaAsync(CategoriaCreateInputModel inputModel)
    {
        var validation = await categoriaCreateValidator.ValidateAsync(inputModel);
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
            var bRes = await queryService.IsCategoriaAvailableAsync(inputModel.GuidFesta, inputModel.CategoriaVideo, 0);

            if (!bRes)
            {
                return Conflict("Categoria già presente");
            }
            else
            {
                var categoria = await commandService.CreateCategoriaAsync(inputModel);
                return Ok(categoria);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Modifica i dati di una categoria
    /// </summary>
    /// <param name="inputModel">Modifica le informazioni della categoria</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpPut]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditCategoriaAsync(CategoriaEditInputModel inputModel)
    {
        var validation = await categoriaEditValidator.ValidateAsync(inputModel);
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
            var categoria = await commandService.EditCategoriaAsync(inputModel);
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Cancella una categoria
    /// </summary>
    /// <param name="inputModel">Cancella le informazioni della categoria</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    /// <response code="409">Codice 409 - Conflict</response>
    [AllowAnonymous]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteCategoriaAsync(CategoriaDeleteInputModel inputModel)
    {
        var validation = await categoriaDeleteValidator.ValidateAsync(inputModel);
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
            var count = await queryService.GetCountProdottiByCategoriaAsync(inputModel.GuidFesta, inputModel.Id);

            if (count != 0)
            {
                return Conflict("Non è possibile cancellare la categoria in quanto vi sono prodotti associati");
            }
            else
            {
                await commandService.DeleteCategoriaAsync(inputModel);
                return Ok();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}