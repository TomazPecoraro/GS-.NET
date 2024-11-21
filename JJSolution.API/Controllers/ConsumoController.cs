using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ConsumoController : ControllerBase
{
    private readonly IConsumoService _consumoService;

    public ConsumoController(IConsumoService consumoService)
    {
        _consumoService = consumoService;
    }

    /// <summary>
    /// Obtém todos os consumos.
    /// </summary>
    /// <returns>Lista de consumos.</returns>
    /// <response code="200">Retorna a lista de consumos com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var consumos = await _consumoService.GetAllConsumosAsync();
        return Ok(consumos);
    }

    /// <summary>
    /// Obtém um consumo pelo ID.
    /// </summary>
    /// <param name="id">ID do consumo.</param>
    /// <returns>Detalhes do consumo.</returns>
    /// <response code="200">Retorna o consumo com sucesso.</response>
    /// <response code="404">Consumo não encontrado para o ID fornecido.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var consumo = await _consumoService.GetConsumoByIdAsync(id);
        if (consumo == null)
        {
            return NotFound();
        }
        return Ok(consumo);
    }

    /// <summary>
    /// Cria um novo consumo.
    /// </summary>
    /// <param name="consumoDto">Dados do consumo a ser criado.</param>
    /// <returns>Consumo criado com sucesso.</returns>
    /// <response code="201">Consumo criado com sucesso.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConsumoDto consumoDto)
    {
        var consumo = await _consumoService.CreateConsumoAsync(consumoDto);
        return CreatedAtAction(nameof(GetById), new { id = consumo.Id }, consumo);
    }

    /// <summary>
    /// Atualiza um consumo existente.
    /// </summary>
    /// <param name="id">ID do consumo a ser atualizado.</param>
    /// <param name="consumoDto">Dados atualizados do consumo.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Consumo atualizado com sucesso.</response>
    /// <response code="404">Consumo não encontrado para o ID fornecido.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ConsumoDto consumoDto)
    {
        var consumo = await _consumoService.UpdateConsumoAsync(id, consumoDto);
        if (consumo == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deleta um consumo pelo ID.
    /// </summary>
    /// <param name="id">ID do consumo a ser deletado.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Consumo deletado com sucesso.</response>
    /// <response code="404">Consumo não encontrado para o ID fornecido.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _consumoService.DeleteConsumoAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
