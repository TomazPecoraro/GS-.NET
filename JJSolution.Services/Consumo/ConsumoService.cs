using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ConsumoService : IConsumoService
{
    private readonly IConsumoRepository _consumoRepository;
    private readonly IMapper _mapper;

    public ConsumoService(IConsumoRepository consumoRepository, IMapper mapper)
    {
        _consumoRepository = consumoRepository;
        _mapper = mapper;
    }

    public async Task<ConsumoDto> GetConsumoByIdAsync(int id)
    {
        var consumo = await _consumoRepository.GetConsumoByIdAsync(id);
        return _mapper.Map<ConsumoDto>(consumo);
    }

    public async Task<IEnumerable<ConsumoDto>> GetConsumosByAparelhoIdAsync(int aparelhoId)
    {
        var consumos = await _consumoRepository.GetConsumosByAparelhoIdAsync(aparelhoId);
        return _mapper.Map<IEnumerable<ConsumoDto>>(consumos);
    }

    public async Task<IEnumerable<ConsumoDto>> GetConsumosByPrecoIdAsync(int precoId)
    {
        var consumos = await _consumoRepository.GetConsumosByPrecoIdAsync(precoId);
        return _mapper.Map<IEnumerable<ConsumoDto>>(consumos);
    }

    public async Task CreateConsumoAsync(ConsumoDto consumoDto)
    {
        var consumo = _mapper.Map<Consumo>(consumoDto);
        await _consumoRepository.CreateConsumoAsync(consumo);
    }

    public async Task UpdateConsumoAsync(ConsumoDto consumoDto)
    {
        var consumo = _mapper.Map<Consumo>(consumoDto);
        await _consumoRepository.UpdateConsumoAsync(consumo);
    }

    public async Task DeleteConsumoAsync(int id)
    {
        await _consumoRepository.DeleteConsumoAsync(id);
    }
}
