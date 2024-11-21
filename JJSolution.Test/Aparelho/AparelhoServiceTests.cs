using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class AparelhoServiceTests
{
    private readonly Mock<IAparelhoRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AparelhoService _service;

    public AparelhoServiceTests()
    {
        _mockRepository = new Mock<IAparelhoRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new AparelhoService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllAparelhosAsync_ReturnsMappedAparelhoDtos()
    {
        // Arrange
        var aparelhos = new List<Aparelho>
        {
            new Aparelho { Id = 1, Nome = "Aparelho 1" },
            new Aparelho { Id = 2, Nome = "Aparelho 2" }
        };
        var aparelhosDto = aparelhos.Select(a => new AparelhoDto { Id = a.Id, Nome = a.Nome });

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(aparelhos);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<AparelhoDto>>(aparelhos)).Returns(aparelhosDto);

        // Act
        var result = await _service.GetAllAparelhosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(aparelhos.Count, result.Count());
        Assert.Equal(aparelhos[0].Nome, result.First().Nome);
    }

    [Fact]
    public async Task GetAparelhoByIdAsync_ReturnsMappedAparelhoDto_WhenExists()
    {
        // Arrange
        var aparelho = new Aparelho { Id = 1, Nome = "Aparelho Teste" };
        var aparelhoDto = new AparelhoDto { Id = aparelho.Id, Nome = aparelho.Nome };

        _mockRepository.Setup(repo => repo.GetByIdAsync(aparelho.Id)).ReturnsAsync(aparelho);
        _mockMapper.Setup(mapper => mapper.Map<AparelhoDto>(aparelho)).Returns(aparelhoDto);

        // Act
        var result = await _service.GetAparelhoByIdAsync(aparelho.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(aparelhoDto.Nome, result.Nome);
    }

    [Fact]
    public async Task CreateAparelhoAsync_ReturnsMappedAparelhoDto()
    {
        // Arrange
        var aparelhoDto = new AparelhoDto { Nome = "Novo Aparelho" };
        var aparelho = new Aparelho { Id = 1, Nome = "Novo Aparelho" };
        var createdAparelho = new Aparelho { Id = 1, Nome = "Novo Aparelho" };
        var createdAparelhoDto = new AparelhoDto { Id = 1, Nome = "Novo Aparelho" };

        _mockMapper.Setup(mapper => mapper.Map<Aparelho>(aparelhoDto)).Returns(aparelho);
        _mockRepository.Setup(repo => repo.AddAsync(aparelho)).ReturnsAsync(createdAparelho);
        _mockMapper.Setup(mapper => mapper.Map<AparelhoDto>(createdAparelho)).Returns(createdAparelhoDto);

        // Act
        var result = await _service.CreateAparelhoAsync(aparelhoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createdAparelhoDto.Nome, result.Nome);
    }

    [Fact]
    public async Task UpdateAparelhoAsync_ReturnsMappedAparelhoDto_WhenExists()
    {
        // Arrange
        var aparelhoDto = new AparelhoDto { Id = 1, Nome = "Aparelho Atualizado" };
        var aparelho = new Aparelho { Id = 1, Nome = "Aparelho Atualizado" };
        var updatedAparelho = new Aparelho { Id = 1, Nome = "Aparelho Atualizado" };
        var updatedAparelhoDto = new AparelhoDto { Id = 1, Nome = "Aparelho Atualizado" };

        _mockMapper.Setup(mapper => mapper.Map<Aparelho>(aparelhoDto)).Returns(aparelho);
        _mockRepository.Setup(repo => repo.UpdateAsync(aparelho)).ReturnsAsync(updatedAparelho);
        _mockMapper.Setup(mapper => mapper.Map<AparelhoDto>(updatedAparelho)).Returns(updatedAparelhoDto);

        // Act
        var result = await _service.UpdateAparelhoAsync(aparelhoDto.Id, aparelhoDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedAparelhoDto.Nome, result.Nome);
    }

    [Fact]
    public async Task DeleteAparelhoAsync_ReturnsTrue_WhenExists()
    {
        // Arrange
        var aparelhoId = 1;
        var aparelho = new Aparelho { Id = aparelhoId };

        _mockRepository.Setup(repo => repo.GetByIdAsync(aparelhoId)).ReturnsAsync(aparelho);
        _mockRepository.Setup(repo => repo.DeleteAsync(aparelhoId)).Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteAparelhoAsync(aparelhoId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAparelhoAsync_ReturnsFalse_WhenNotExists()
    {
        // Arrange
        var aparelhoId = 1;

        _mockRepository.Setup(repo => repo.GetByIdAsync(aparelhoId)).ReturnsAsync((Aparelho)null);

        // Act
        var result = await _service.DeleteAparelhoAsync(aparelhoId);

        // Assert
        Assert.False(result);
    }
}
