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

    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Lista de usuários.</returns>
    /// <response code="200">Retorna a lista de usuários com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    /// <summary>
    /// Obtém um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Detalhes do usuário.</returns>
    /// <response code="200">Retorna o usuário com sucesso.</response>
    /// <response code="404">Usuário não encontrado para o ID fornecido.</response>
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

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuarioDto">Dados do usuário a ser criado.</param>
    /// <returns>Usuário criado com sucesso.</returns>
    /// <response code="201">Usuário criado com sucesso.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
    {
        var usuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    /// <summary>
    /// Atualiza um usuário existente.
    /// </summary>
    /// <param name="id">ID do usuário a ser atualizado.</param>
    /// <param name="usuarioDto">Dados atualizados do usuário.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Usuário atualizado com sucesso.</response>
    /// <response code="404">Usuário não encontrado para o ID fornecido.</response>
    /// <response code="400">Dados inválidos fornecidos.</response>
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

    /// <summary>
    /// Deleta um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser deletado.</param>
    /// <returns>Resposta HTTP 204 (No Content) em caso de sucesso.</returns>
    /// <response code="204">Usuário deletado com sucesso.</response>
    /// <response code="404">Usuário não encontrado para o ID fornecido.</response>
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
