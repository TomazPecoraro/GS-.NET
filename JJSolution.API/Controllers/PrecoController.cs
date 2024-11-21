using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PrecoController : ControllerBase
{
    private readonly IPrecoService _precoService;

    public PrecoController(IPrecoService precoService)
    {
        _precoService = precoService;
    }

    /// <summary>
    /// Obtém todos os preços.
    /// </summary>
    /// <returns>Lista de preços.</returns>
    /// <response code="200">Retorna a lista de preços com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var precos = await _precoService.GetAllPrecosAsync();
        return Ok(precos);
    }

    /// <summary>
    /// Obtém um preço pelo ID.
    /// </summary>
    /// <param name="id">ID do preço.</param>
    /// <returns>Detalhes do preço.</returns>
    /// <response code="200">Retorna o preço com sucesso.</response>
    /// <response code="404">Preço não encontrado para o ID fornecido.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var preco = await _precoService.GetPrecoByIdAsync(id);
        if (preco == null)
        {
            return NotFound();
        }
        return Ok(preco);
    }

    /// <summary>
    /// Cria um novo preço.
    /// </summary>
    /// <param name="precoDto">Dados do preço a ser criado.</param>
    /// <returns>Preço criado com sucesso.</returns>
    /// <response code="201">Preço criado com sucesso.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PrecoDto precoDto)
    {
        var preco = await _precoService.CreatePrecoAsync(precoDto);
        return CreatedAtAction(nameof(GetById), new { id = preco.Id }, preco);
    }

    /// <summary>
    /// Atualiza um preço existente.
    /// </summary>
    /// <param name="id">ID do preço a ser atualizado.</param>
    /// <param name="precoDto">Dados atualizados do preço.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Preço atualizado com sucesso.</response>
    /// <response code="404">Preço não encontrado para o ID fornecido.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PrecoDto precoDto)
    {
        var preco = await _precoService.UpdatePrecoAsync(id, precoDto);
        if (preco == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deleta um preço pelo ID.
    /// </summary>
    /// <param name="id">ID do preço a ser deletado.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Preço deletado com sucesso.</response>
    /// <response code="404">Preço não encontrado para o ID fornecido.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _precoService.DeletePrecoAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
