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

        public async Task<IEnumerable<PrecoDto>> GetAllPrecosAsync()
        {
            var precos = await _precoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PrecoDto>>(precos);
        }

        public async Task<PrecoDto> GetPrecoByIdAsync(int id)
        {
            var preco = await _precoRepository.GetByIdAsync(id);
            return _mapper.Map<PrecoDto>(preco);
        }

        public async Task<PrecoDto> CreatePrecoAsync(PrecoDto precoDto)
        {
            var preco = _mapper.Map<Preco>(precoDto);
            var newPreco = await _precoRepository.AddAsync(preco);
            return _mapper.Map<PrecoDto>(newPreco);
        }

        public async Task<PrecoDto> UpdatePrecoAsync(PrecoDto precoDto)
        {
            var preco = _mapper.Map<Preco>(precoDto);
            var updatedPreco = await _precoRepository.UpdateAsync(preco);
            return _mapper.Map<PrecoDto>(updatedPreco);
        }

        public async Task<bool> DeletePrecoAsync(int id)
        {
            var preco = await _precoRepository.GetByIdAsync(id);
            if (preco == null)
                return false;

            await _precoRepository.DeleteAsync(id);
            return true;
        }
    }

