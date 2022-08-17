using GestioneSagre.Models.InputModels.Categoria;

namespace GestioneSagre.Web.Server.Controllers;

public class CategoriaController : BaseController
{
    private readonly ICategoriaCommandStackService commandService;
    private readonly ICategoriaQueryStackService queryService;
    private readonly IValidator<CategoriaCreateInputModel> categoriaCreateValidator;
    private readonly IValidator<CategoriaCreateInputModel> categoriaEditValidator;

    public CategoriaController(ICategoriaCommandStackService commandService,
                               ICategoriaQueryStackService queryService,
                               IValidator<CategoriaCreateInputModel> categoriaCreateValidator,
                               IValidator<CategoriaCreateInputModel> categoriaEditValidator)
    {
        this.commandService = commandService;
        this.queryService = queryService;
        this.categoriaCreateValidator = categoriaCreateValidator;
        this.categoriaEditValidator = categoriaEditValidator;
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
}