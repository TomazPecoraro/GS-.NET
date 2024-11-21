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

    // GET: api/Preco
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var precos = await _precoService.GetAllPrecosAsync();
        return Ok(precos);
    }

    // GET: api/Preco/{id}
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

    // POST: api/Preco
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PrecoDto precoDto)
    {
        var preco = await _precoService.CreatePrecoAsync(precoDto);
        return CreatedAtAction(nameof(GetById), new { id = preco.Id }, preco);
    }

    // PUT: api/Preco/{id}
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

    // DELETE: api/Preco/{id}
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
