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

    // GET: api/Consumo
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var consumos = await _consumoService.GetAllConsumosAsync();
        return Ok(consumos);
    }

    // GET: api/Consumo/{id}
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

    // POST: api/Consumo
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConsumoDto consumoDto)
    {
        var consumo = await _consumoService.CreateConsumoAsync(consumoDto);
        return CreatedAtAction(nameof(GetById), new { id = consumo.Id }, consumo);
    }

    // PUT: api/Consumo/{id}
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

    // DELETE: api/Consumo/{id}
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
