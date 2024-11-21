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

        public async Task<IEnumerable<AparelhoDto>> GetAllAparelhosAsync()
        {
            var aparelhos = await _aparelhoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AparelhoDto>>(aparelhos);
        }

        public async Task<AparelhoDto> GetAparelhoByIdAsync(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            return _mapper.Map<AparelhoDto>(aparelho);
        }


    public async Task<AparelhoDto> CreateAparelhoAsync(AparelhoDto aparelhoDto)
        {
            var aparelho = _mapper.Map<Aparelho>(aparelhoDto);
            var newAparelho = await _aparelhoRepository.AddAsync(aparelho);
            return _mapper.Map<AparelhoDto>(newAparelho);
        }

        public async Task<AparelhoDto> UpdateAparelhoAsync(AparelhoDto aparelhoDto)
        {
            var aparelho = _mapper.Map<Aparelho>(aparelhoDto);
            var updatedAparelho = await _aparelhoRepository.UpdateAsync(aparelho);
            return _mapper.Map<AparelhoDto>(updatedAparelho);
        }

        public async Task<bool> DeleteAparelhoAsync(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            if (aparelho == null)
                return false;

            await _aparelhoRepository.DeleteAsync(id);
            return true;
        }
    }
