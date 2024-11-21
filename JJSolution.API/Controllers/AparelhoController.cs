using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AparelhoController : ControllerBase
{
    private readonly IAparelhoService _aparelhoService;

    public AparelhoController(IAparelhoService aparelhoService)
    {
        _aparelhoService = aparelhoService;
    }

    /// <summary>
    /// Obtém todos os aparelhos.
    /// </summary>
    /// <returns>Lista de aparelhos.</returns>
    /// <response code="200">Retorna a lista de aparelhos com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var aparelhos = await _aparelhoService.GetAllAparelhosAsync();
        return Ok(aparelhos);
    }

    /// <summary>
    /// Obtém um aparelho pelo ID.
    /// </summary>
    /// <param name="id">ID do aparelho.</param>
    /// <returns>Detalhes do aparelho.</returns>
    /// <response code="200">Retorna o aparelho com sucesso.</response>
    /// <response code="404">Aparelho não encontrado para o ID fornecido.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var aparelho = await _aparelhoService.GetAparelhoByIdAsync(id);
        if (aparelho == null)
        {
            return NotFound();
        }
        return Ok(aparelho);
    }

    /// <summary>
    /// Cria um novo aparelho.
    /// </summary>
    /// <param name="aparelhoDto">Dados do aparelho a ser criado.</param>
    /// <returns>Alerta criado com sucesso.</returns>
    /// <response code="201">Aparelho criado com sucesso.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AparelhoDto aparelhoDto)
    {
        var aparelho = await _aparelhoService.CreateAparelhoAsync(aparelhoDto);
        return CreatedAtAction(nameof(GetById), new { id = aparelho.Id }, aparelho);
    }

    /// <summary>
    /// Atualiza um aparelho existente.
    /// </summary>
    /// <param name="id">ID do aparelho a ser atualizado.</param>
    /// <param name="aparelhoDto">Dados atualizados do aparelho.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Aparelho atualizado com sucesso.</response>
    /// <response code="404">Aparelho não encontrado para o ID fornecido.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AparelhoDto aparelhoDto)
    {
        var aparelho = await _aparelhoService.UpdateAparelhoAsync(id, aparelhoDto);
        if (aparelho == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deleta um aparelho pelo ID.
    /// </summary>
    /// <param name="id">ID do aparelho a ser deletado.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Aparelho deletado com sucesso.</response>
    /// <response code="404">Aparelho não encontrado para o ID fornecido.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _aparelhoService.DeleteAparelhoAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
