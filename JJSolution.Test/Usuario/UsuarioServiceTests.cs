using AutoMapper;
using Moq;
using Xunit;

public class UsuarioServiceTests
{
    private readonly Mock<IUsuarioRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UsuarioService _service;

    public UsuarioServiceTests()
    {
        _mockRepository = new Mock<IUsuarioRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new UsuarioService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllUsuariosAsync_ReturnsUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "João", Email = "joao@email.com", Senha = "123456" },
            new Usuario { Id = 2, Nome = "Maria", Email = "maria@email.com", Senha = "654321" }
        };

        var usuarioDtos = new List<UsuarioDto>
        {
            new UsuarioDto { Id = 1, Nome = "João", Email = "joao@email.com" },
            new UsuarioDto { Id = 2, Nome = "Maria", Email = "maria@email.com" }
        };

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usuarios);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UsuarioDto>>(usuarios)).Returns(usuarioDtos);

        // Act
        var result = await _service.GetAllUsuariosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("João", result.First().Nome);
    }

    [Fact]
    public async Task GetUsuarioByIdAsync_ReturnsUsuario_WhenExists()
    {
        // Arrange
        var usuario = new Usuario { Id = 1, Nome = "João", Email = "joao@email.com", Senha = "123456" };
        var usuarioDto = new UsuarioDto { Id = 1, Nome = "João", Email = "joao@email.com" };

        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(usuario);
        _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(usuario)).Returns(usuarioDto);

        // Act
        var result = await _service.GetUsuarioByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("João", result.Nome);
    }

    [Fact]
    public async Task CreateUsuarioAsync_ReturnsCreatedUsuario()
    {
        // Arrange
        var usuarioDto = new UsuarioDto { Nome = "João", Email = "joao@email.com", Senha = "123456" };
        var usuario = new Usuario { Id = 1, Nome = "João", Email = "joao@email.com", Senha = "123456" };

        _mockMapper.Setup(mapper => mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        _mockRepository.Setup(repo => repo.AddAsync(usuario)).ReturnsAsync(usuario);
        _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(usuario)).Returns(usuarioDto);

        // Act
        var result = await _service.CreateUsuarioAsync(usuarioDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("João", result.Nome);
    }

    [Fact]
    public async Task UpdateUsuarioAsync_ReturnsUpdatedUsuario_WhenExists()
    {
        // Arrange
        var usuarioDto = new UsuarioDto { Id = 1, Nome = "João Atualizado", Email = "joao@atualizado.com" };
        var usuario = new Usuario { Id = 1, Nome = "João Atualizado", Email = "joao@atualizado.com", Senha = "654321" };

        _mockMapper.Setup(mapper => mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        _mockRepository.Setup(repo => repo.UpdateAsync(usuario)).ReturnsAsync(usuario);
        _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(usuario)).Returns(usuarioDto);

        // Act
        var result = await _service.UpdateUsuarioAsync(1, usuarioDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("João Atualizado", result.Nome);
    }

    [Fact]
    public async Task DeleteUsuarioAsync_ReturnsTrue_WhenExists()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Usuario { Id = 1 });
        _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.FromResult(true));


        // Act
        var result = await _service.DeleteUsuarioAsync(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteUsuarioAsync_ReturnsFalse_WhenNotExists()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByIdAsync(999)).ReturnsAsync((Usuario)null);

        // Act
        var result = await _service.DeleteUsuarioAsync(999);

        // Assert
        Assert.False(result);
    }
}
