using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class ConsumoServiceTests
{
    private readonly Mock<IConsumoRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ConsumoService _service;

    public ConsumoServiceTests()
    {
        _mockRepository = new Mock<IConsumoRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new ConsumoService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllConsumosAsync_ReturnsMappedConsumoDtos()
    {
        // Arrange
        var consumos = new List<Consumo>
        {
            new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 120, CustoEstimado = 45.5m, PrecoId = 1, AparelhoId = 1 },
            new Consumo { Id = 2, Data = DateTime.Now.AddDays(-1), ConsumoKwh = 100, CustoEstimado = 40.0m, PrecoId = 2, AparelhoId = 2 }
        };
        var consumosDto = consumos.Select(c => new ConsumoDto
        {
            Id = c.Id,
            Data = c.Data,
            ConsumoKwh = c.ConsumoKwh,
            CustoEstimado = c.CustoEstimado,
            PrecoId = c.PrecoId,
            AparelhoId = c.AparelhoId
        });

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(consumos);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ConsumoDto>>(consumos)).Returns(consumosDto);

        // Act
        var result = await _service.GetAllConsumosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(consumos.Count, result.Count());
        Assert.Equal(consumos[0].ConsumoKwh, result.First().ConsumoKwh);
        Assert.Equal(consumos[0].CustoEstimado, result.First().CustoEstimado);
    }

    [Fact]
    public async Task GetConsumoByIdAsync_ReturnsMappedConsumoDto_WhenExists()
    {
        // Arrange
        var consumo = new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 120, CustoEstimado = 45.5m, PrecoId = 1, AparelhoId = 1 };
        var consumoDto = new ConsumoDto
        {
            Id = consumo.Id,
            Data = consumo.Data,
            ConsumoKwh = consumo.ConsumoKwh,
            CustoEstimado = consumo.CustoEstimado,
            PrecoId = consumo.PrecoId,
            AparelhoId = consumo.AparelhoId
        };

        _mockRepository.Setup(repo => repo.GetByIdAsync(consumo.Id)).ReturnsAsync(consumo);
        _mockMapper.Setup(mapper => mapper.Map<ConsumoDto>(consumo)).Returns(consumoDto);

        // Act
        var result = await _service.GetConsumoByIdAsync(consumo.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(consumoDto.ConsumoKwh, result.ConsumoKwh);
        Assert.Equal(consumoDto.CustoEstimado, result.CustoEstimado);
        Assert.Equal(consumoDto.PrecoId, result.PrecoId);
        Assert.Equal(consumoDto.AparelhoId, result.AparelhoId);
    }

    [Fact]
    public async Task CreateConsumoAsync_ReturnsMappedConsumoDto()
    {
        // Arrange
        var consumoDto = new ConsumoDto
        {
            Data = DateTime.Now,
            ConsumoKwh = 120,
            CustoEstimado = 45.5m,
            PrecoId = 1,
            AparelhoId = 1
        };
        var consumo = new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 120, CustoEstimado = 45.5m, PrecoId = 1, AparelhoId = 1 };
        var createdConsumo = new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 120, CustoEstimado = 45.5m, PrecoId = 1, AparelhoId = 1 };
        var createdConsumoDto = new ConsumoDto
        {
            Id = 1,
            Data = DateTime.Now,
            ConsumoKwh = 120,
            CustoEstimado = 45.5m,
            PrecoId = 1,
            AparelhoId = 1
        };

        _mockMapper.Setup(mapper => mapper.Map<Consumo>(consumoDto)).Returns(consumo);
        _mockRepository.Setup(repo => repo.AddAsync(consumo)).ReturnsAsync(createdConsumo);
        _mockMapper.Setup(mapper => mapper.Map<ConsumoDto>(createdConsumo)).Returns(createdConsumoDto);

        // Act
        var result = await _service.CreateConsumoAsync(consumoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createdConsumoDto.ConsumoKwh, result.ConsumoKwh);
        Assert.Equal(createdConsumoDto.CustoEstimado, result.CustoEstimado);
    }

    [Fact]
    public async Task UpdateConsumoAsync_ReturnsMappedConsumoDto_WhenExists()
    {
        // Arrange
        var consumoDto = new ConsumoDto
        {
            Id = 1,
            Data = DateTime.Now,
            ConsumoKwh = 130,
            CustoEstimado = 50.0m,
            PrecoId = 1,
            AparelhoId = 1
        };
        var consumo = new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 130, CustoEstimado = 50.0m, PrecoId = 1, AparelhoId = 1 };
        var updatedConsumo = new Consumo { Id = 1, Data = DateTime.Now, ConsumoKwh = 130, CustoEstimado = 50.0m, PrecoId = 1, AparelhoId = 1 };
        var updatedConsumoDto = new ConsumoDto
        {
            Id = 1,
            Data = DateTime.Now,
            ConsumoKwh = 130,
            CustoEstimado = 50.0m,
            PrecoId = 1,
            AparelhoId = 1
        };

        _mockMapper.Setup(mapper => mapper.Map<Consumo>(consumoDto)).Returns(consumo);
        _mockRepository.Setup(repo => repo.UpdateAsync(consumo)).ReturnsAsync(updatedConsumo);
        _mockMapper.Setup(mapper => mapper.Map<ConsumoDto>(updatedConsumo)).Returns(updatedConsumoDto);

        // Act
        var result = await _service.UpdateConsumoAsync(consumoDto.Id, consumoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedConsumoDto.ConsumoKwh, result.ConsumoKwh);
        Assert.Equal(updatedConsumoDto.CustoEstimado, result.CustoEstimado);
    }

    [Fact]
    public async Task DeleteConsumoAsync_ReturnsTrue_WhenExists()
    {
        // Arrange
        var consumoId = 1;
        var consumo = new Consumo { Id = consumoId };

        _mockRepository.Setup(repo => repo.GetByIdAsync(consumoId)).ReturnsAsync(consumo);
        _mockRepository.Setup(repo => repo.DeleteAsync(consumoId)).Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteConsumoAsync(consumoId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteConsumoAsync_ReturnsFalse_WhenNotExists()
    {
        // Arrange
        var consumoId = 1;

        _mockRepository.Setup(repo => repo.GetByIdAsync(consumoId)).ReturnsAsync((Consumo)null);

        // Act
        var result = await _service.DeleteConsumoAsync(consumoId);

        // Assert
        Assert.False(result);
    }
}
