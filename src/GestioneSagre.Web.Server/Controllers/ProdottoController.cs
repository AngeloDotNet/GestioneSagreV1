using GestioneSagre.Models.ViewModel;

namespace GestioneSagre.Web.Server.Controllers;

public class ProdottoController : BaseController
{
    private readonly IProdottoCommandStackService commandService;
    private readonly IProdottoQueryStackService queryService;
    private readonly IValidator<ProdottoCreateInputModel> prodottoCreateValidator;
    private readonly IValidator<ProdottoEditInputModel> prodottoEditValidator;
    private readonly IValidator<ProdottoDeleteInputModel> prodottoDeleteValidator;

    public ProdottoController(IProdottoCommandStackService commandService,
                              IProdottoQueryStackService queryService,
                              IValidator<ProdottoCreateInputModel> prodottoCreateValidator,
                              IValidator<ProdottoEditInputModel> prodottoEditValidator,
                              IValidator<ProdottoDeleteInputModel> prodottoDeleteValidator)
    {
        this.commandService = commandService;
        this.queryService = queryService;
        this.prodottoCreateValidator = prodottoCreateValidator;
        this.prodottoEditValidator = prodottoEditValidator;
        this.prodottoDeleteValidator = prodottoDeleteValidator;
    }

    /// <summary>
    /// Elenco dei prodotti
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProdottiAsync()
    {
        try
        {
            var prodotto = await queryService.GetProdottiAsync();

            return Ok(prodotto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Dettagli di uno specifico prodotto
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpGet("{guidFesta:guid}/{prodotto}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProdottoAsync(string guidFesta, string prodotto)
    {
        try
        {
            var product = await queryService.GetProdottoAsync(guidFesta, prodotto);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
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
    /// Nuovo prodotto
    /// </summary>
    /// <param name="inputModel">Inserisce le informazioni sul prodotto</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="409">Codice 409 - Conflict</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateProdottoAsync(ProdottoCreateInputModel inputModel)
    {
        var validation = await prodottoCreateValidator.ValidateAsync(inputModel);
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
            var bRes = await queryService.IsProdottoAvailableAsync(inputModel.GuidFesta, inputModel.Prodotto, 0);

            if (!bRes)
            {
                return Conflict("Prodotto già presente");
            }
            else
            {
                var prodotto = await commandService.CreateProdottoAsync(inputModel);
                return Ok(prodotto);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Modifica i dati di un prodotto
    /// </summary>
    /// <param name="inputModel">Modifica le informazioni del prodotto</param>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [AllowAnonymous]
    [HttpPut]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditProdottoAsync(ProdottoEditInputModel inputModel)
    {
        var validation = await prodottoEditValidator.ValidateAsync(inputModel);
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
            var categoria = await commandService.EditProdottoAsync(inputModel);
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Cancella un prodotto
    /// </summary>
    /// <param name="inputModel">Cancella le informazioni del prodotto</param>
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
    public async Task<IActionResult> DeleteProdottoAsync(ProdottoDeleteInputModel inputModel)
    {
        var validation = await prodottoDeleteValidator.ValidateAsync(inputModel);
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
            await commandService.DeleteProdottoAsync(inputModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}