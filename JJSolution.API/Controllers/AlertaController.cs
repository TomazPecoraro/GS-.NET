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

    // GET: api/Alerta
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alertas = await _alertaService.GetAllAlertasAsync();
        return Ok(alertas);
    }

    // GET: api/Alerta/{id}
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

    // POST: api/Alerta
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlertaDto alertaDto)
    {
        var alerta = await _alertaService.CreateAlertaAsync(alertaDto);
        return CreatedAtAction(nameof(GetById), new { id = alerta.Id }, alerta);
    }

    // PUT: api/Alerta/{id}
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

    // DELETE: api/Alerta/{id}
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
