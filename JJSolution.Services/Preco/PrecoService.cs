using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrecoService : IPrecoService
{
    private readonly IPrecoRepository _precoRepository;
    private readonly IMapper _mapper;

    public PrecoService(IPrecoRepository precoRepository, IMapper mapper)
    {
        _precoRepository = precoRepository;
        _mapper = mapper;
    }

    public async Task<PrecoDto> GetPrecoByIdAsync(int id)
    {
        var preco = await _precoRepository.GetPrecoByIdAsync(id);
        return _mapper.Map<PrecoDto>(preco);
    }

    public async Task<IEnumerable<PrecoDto>> GetAllPrecosAsync()
    {
        var precos = await _precoRepository.GetAllPrecosAsync();
        return _mapper.Map<IEnumerable<PrecoDto>>(precos);
    }

    public async Task CreatePrecoAsync(PrecoDto precoDto)
    {
        var preco = _mapper.Map<Preco>(precoDto);
        await _precoRepository.CreatePrecoAsync(preco);
    }

    public async Task UpdatePrecoAsync(PrecoDto precoDto)
    {
        var preco = _mapper.Map<Preco>(precoDto);
        await _precoRepository.UpdatePrecoAsync(preco);
    }

    public async Task DeletePrecoAsync(int id)
    {
        await _precoRepository.DeletePrecoAsync(id);
    }
}
