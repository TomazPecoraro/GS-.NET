using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class AlertaServiceTests
{
    private readonly Mock<IAlertaRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AlertaService _service;

    public AlertaServiceTests()
    {
        _mockRepository = new Mock<IAlertaRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new AlertaService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllAlertasAsync_ReturnsMappedAlertaDtos()
    {
        // Arrange
        var alertas = new List<Alerta>
        {
            new Alerta { Id = 1, Descricao = "Alerta 1", UsuarioId = 1 },
            new Alerta { Id = 2, Descricao = "Alerta 2", UsuarioId = 2 }
        };
        var alertasDto = alertas.Select(a => new AlertaDto { Id = a.Id, Descricao = a.Descricao });

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(alertas);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<AlertaDto>>(alertas)).Returns(alertasDto);

        // Act
        var result = await _service.GetAllAlertasAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(alertas.Count, result.Count());
        Assert.Equal(alertas[0].Descricao, result.First().Descricao);
    }

    [Fact]
    public async Task GetAlertaByIdAsync_ReturnsMappedAlertaDto_WhenExists()
    {
        // Arrange
        var alerta = new Alerta { Id = 1, Descricao = "Alerta Teste", UsuarioId = 1 };
        var alertaDto = new AlertaDto { Id = alerta.Id, Descricao = alerta.Descricao };

        _mockRepository.Setup(repo => repo.GetByIdAsync(alerta.Id)).ReturnsAsync(alerta);
        _mockMapper.Setup(mapper => mapper.Map<AlertaDto>(alerta)).Returns(alertaDto);

        // Act
        var result = await _service.GetAlertaByIdAsync(alerta.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(alertaDto.Descricao, result.Descricao);
    }

    [Fact]
    public async Task CreateAlertaAsync_ReturnsMappedAlertaDto()
    {
        // Arrange
        var alertaDto = new AlertaDto { Descricao = "Novo Alerta" };
        var alerta = new Alerta { Id = 1, Descricao = "Novo Alerta" };
        var createdAlerta = new Alerta { Id = 1, Descricao = "Novo Alerta" };
        var createdAlertaDto = new AlertaDto { Id = 1, Descricao = "Novo Alerta" };

        _mockMapper.Setup(mapper => mapper.Map<Alerta>(alertaDto)).Returns(alerta);
        _mockRepository.Setup(repo => repo.AddAsync(alerta)).ReturnsAsync(createdAlerta);
        _mockMapper.Setup(mapper => mapper.Map<AlertaDto>(createdAlerta)).Returns(createdAlertaDto);

        // Act
        var result = await _service.CreateAlertaAsync(alertaDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createdAlertaDto.Descricao, result.Descricao);
    }

    [Fact]
    public async Task UpdateAlertaAsync_ReturnsMappedAlertaDto_WhenExists()
    {
        // Arrange
        var alertaDto = new AlertaDto { Id = 1, Descricao = "Alerta Atualizado" };
        var alerta = new Alerta { Id = 1, Descricao = "Alerta Atualizado" };
        var updatedAlerta = new Alerta { Id = 1, Descricao = "Alerta Atualizado" };
        var updatedAlertaDto = new AlertaDto { Id = 1, Descricao = "Alerta Atualizado" };

        _mockMapper.Setup(mapper => mapper.Map<Alerta>(alertaDto)).Returns(alerta);
        _mockRepository.Setup(repo => repo.UpdateAsync(alerta)).ReturnsAsync(updatedAlerta);
        _mockMapper.Setup(mapper => mapper.Map<AlertaDto>(updatedAlerta)).Returns(updatedAlertaDto);

        // Act
        var result = await _service.UpdateAlertaAsync(alertaDto.Id, alertaDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedAlertaDto.Descricao, result.Descricao);
    }

    [Fact]
    public async Task DeleteAlertaAsync_ReturnsTrue_WhenExists()
    {
        // Arrange
        var alertaId = 1;
        var alerta = new Alerta { Id = alertaId };

        _mockRepository.Setup(repo => repo.GetByIdAsync(alertaId)).ReturnsAsync(alerta);
        _mockRepository.Setup(repo => repo.DeleteAsync(alertaId)).Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteAlertaAsync(alertaId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAlertaAsync_ReturnsFalse_WhenNotExists()
    {
        // Arrange
        var alertaId = 1;

        _mockRepository.Setup(repo => repo.GetByIdAsync(alertaId)).ReturnsAsync((Alerta)null);

        // Act
        var result = await _service.DeleteAlertaAsync(alertaId);

        // Assert
        Assert.False(result);
    }
}
