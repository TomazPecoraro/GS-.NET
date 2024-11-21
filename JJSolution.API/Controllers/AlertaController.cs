using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AlertaController : ControllerBase
{
    private readonly IAlertaService _alertaService;

    public AlertaController(IAlertaService alertaService)
    {
        _alertaService = alertaService;
    }

    /// <summary>
    /// Obtém todos os alertas.
    /// </summary>
    /// <returns>Lista de alertas</returns>
    /// <response code="200">Retorna a lista de alertas</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alertas = await _alertaService.GetAllAlertasAsync();
        return Ok(alertas);
    }

    /// <summary>
    /// Obtém um alerta pelo ID.
    /// </summary>
    /// <param name="id">ID do alerta</param>
    /// <returns>Detalhes do alerta</returns>
    /// <response code="200">Retorna os detalhes do alerta</response>
    /// <response code="404">Alerta não encontrado</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var alerta = await _alertaService.GetAlertaByIdAsync(id);
        if (alerta == null)
        {
            return NotFound();
        }
        return Ok(alerta);
    }

    /// <summary>
    /// Cria um novo alerta.
    /// </summary>
    /// <param name="alertaDto">Dados do alerta a ser criado</param>
    /// <returns>Alerta criado</returns>
    /// <response code="201">Alerta criado com sucesso</response>
    /// <response code="400">Dados inválidos fornecidos</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlertaDto alertaDto)
    {
        var alerta = await _alertaService.CreateAlertaAsync(alertaDto);
        return CreatedAtAction(nameof(GetById), new { id = alerta.Id }, alerta);
    }

    /// <summary>
    /// Atualiza um alerta existente.
    /// </summary>
    /// <param name="id">ID do alerta a ser atualizado</param>
    /// <param name="alertaDto">Dados atualizados do alerta</param>
    /// <returns>Resposta HTTP 204 (No Content)</returns>
    /// <response code="204">Alerta atualizado com sucesso</response>
    /// <response code="404">Alerta não encontrado</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AlertaDto alertaDto)
    {
        var alerta = await _alertaService.UpdateAlertaAsync(id, alertaDto);
        if (alerta == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deleta um alerta pelo ID.
    /// </summary>
    /// <param name="id">ID do alerta a ser deletado</param>
    /// <returns>Resposta HTTP 204 (No Content)</returns>
    /// <response code="204">Alerta deletado com sucesso</response>
    /// <response code="404">Alerta não encontrado</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _alertaService.DeleteAlertaAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
