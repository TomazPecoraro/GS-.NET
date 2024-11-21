using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET: api/Usuario
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    // GET: api/Usuario/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    // POST: api/Usuario
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
    {
        var usuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    // PUT: api/Usuario/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto usuarioDto)
    {
        var usuario = await _usuarioService.UpdateUsuarioAsync(id, usuarioDto);
        if (usuario == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Usuario/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _usuarioService.DeleteUsuarioAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
