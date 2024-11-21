using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AparelhoService : IAparelhoService
{
    private readonly IAparelhoRepository _aparelhoRepository;
    private readonly IMapper _mapper;

    public AparelhoService(IAparelhoRepository aparelhoRepository, IMapper mapper)
    {
        _aparelhoRepository = aparelhoRepository;
        _mapper = mapper;
    }

    public async Task<AparelhoDto> GetAparelhoByIdAsync(int id)
    {
        var aparelho = await _aparelhoRepository.GetAparelhoByIdAsync(id);
        return _mapper.Map<AparelhoDto>(aparelho);
    }

    public async Task<IEnumerable<AparelhoDto>> GetAparelhosByUsuarioIdAsync(int usuarioId)
    {
        var aparelhos = await _aparelhoRepository.GetAparelhosByUsuarioIdAsync(usuarioId);
        return _mapper.Map<IEnumerable<AparelhoDto>>(aparelhos);
    }

    public async Task CreateAparelhoAsync(AparelhoDto aparelhoDto)
    {
        var aparelho = _mapper.Map<Aparelho>(aparelhoDto);
        await _aparelhoRepository.CreateAparelhoAsync(aparelho);
    }

    public async Task UpdateAparelhoAsync(AparelhoDto aparelhoDto)
    {
        var aparelho = _mapper.Map<Aparelho>(aparelhoDto);
        await _aparelhoRepository.UpdateAparelhoAsync(aparelho);
    }

    public async Task DeleteAparelhoAsync(int id)
    {
        await _aparelhoRepository.DeleteAparelhoAsync(id);
    }
}
