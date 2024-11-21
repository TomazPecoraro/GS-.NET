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

    // GET: api/Aparelho
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var aparelhos = await _aparelhoService.GetAllAparelhosAsync();
        return Ok(aparelhos);
    }

    // GET: api/Aparelho/{id}
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

    // POST: api/Aparelho
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AparelhoDto aparelhoDto)
    {
        var aparelho = await _aparelhoService.CreateAparelhoAsync(aparelhoDto);
        return CreatedAtAction(nameof(GetById), new { id = aparelho.Id }, aparelho);
    }

    // PUT: api/Aparelho/{id}
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

    // DELETE: api/Aparelho/{id}
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
