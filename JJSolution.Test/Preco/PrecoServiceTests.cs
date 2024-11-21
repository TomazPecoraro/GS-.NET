using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class PrecoServiceTests
{
    private readonly Mock<IPrecoRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PrecoService _service;

    public PrecoServiceTests()
    {
        _mockRepository = new Mock<IPrecoRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new PrecoService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllPrecosAsync_ReturnsMappedPrecoDtos()
    {
        // Arrange
        var precos = new List<Preco>
        {
            new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m },
            new Preco { Id = 2, Data = DateTime.Now.AddDays(-1), PrecoKwh = 0.6m }
        };

        var precosDto = new List<PrecoDto>
        {
            new PrecoDto { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m },
            new PrecoDto { Id = 2, Data = DateTime.Now.AddDays(-1), PrecoKwh = 0.6m }
        };

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(precos);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PrecoDto>>(precos)).Returns(precosDto);

        // Act
        var result = await _service.GetAllPrecosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(precos.Count, result.Count());
        Assert.Equal(precos[0].PrecoKwh, result.First().PrecoKwh);
    }

    [Fact]
    public async Task GetPrecoByIdAsync_ReturnsMappedPrecoDto_WhenExists()
    {
        // Arrange
        var preco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };
        var precoDto = new PrecoDto { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };

        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(preco);
        _mockMapper.Setup(mapper => mapper.Map<PrecoDto>(preco)).Returns(precoDto);

        // Act
        var result = await _service.GetPrecoByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(preco.Id, result.Id);
        Assert.Equal(preco.PrecoKwh, result.PrecoKwh);
    }

    [Fact]
    public async Task CreatePrecoAsync_ReturnsMappedPrecoDto()
    {
        // Arrange
        var precoDto = new PrecoDto { Id = 0, Data = DateTime.Now, PrecoKwh = 0.5m };
        var preco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };
        var newPreco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };

        _mockMapper.Setup(mapper => mapper.Map<Preco>(precoDto)).Returns(preco);
        _mockRepository.Setup(repo => repo.AddAsync(preco)).ReturnsAsync(newPreco);
        _mockMapper.Setup(mapper => mapper.Map<PrecoDto>(newPreco)).Returns(precoDto);

        // Act
        var result = await _service.CreatePrecoAsync(precoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(preco.Id, result.Id);
        Assert.Equal(preco.PrecoKwh, result.PrecoKwh);
    }

    [Fact]
    public async Task UpdatePrecoAsync_ReturnsMappedPrecoDto_WhenExists()
    {
        // Arrange
        var precoDto = new PrecoDto { Id = 1, Data = DateTime.Now, PrecoKwh = 0.6m };
        var preco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };
        var updatedPreco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.6m };

        _mockMapper.Setup(mapper => mapper.Map<Preco>(precoDto)).Returns(preco);
        _mockRepository.Setup(repo => repo.UpdateAsync(preco)).ReturnsAsync(updatedPreco);
        _mockMapper.Setup(mapper => mapper.Map<PrecoDto>(updatedPreco)).Returns(precoDto);

        // Act
        var result = await _service.UpdatePrecoAsync(1, precoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(precoDto.Id, result.Id);
        Assert.Equal(precoDto.PrecoKwh, result.PrecoKwh);
    }

    [Fact]
    public async Task DeletePrecoAsync_ReturnsTrue_WhenExists()
    {
        // Arrange
        var preco = new Preco { Id = 1, Data = DateTime.Now, PrecoKwh = 0.5m };

        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(preco);
        _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeletePrecoAsync(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeletePrecoAsync_ReturnsFalse_WhenNotFound()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Preco)null);

        // Act
        var result = await _service.DeletePrecoAsync(1);

        // Assert
        Assert.False(result);
    }
}
