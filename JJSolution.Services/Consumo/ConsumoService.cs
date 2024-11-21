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

        public async Task<IEnumerable<ConsumoDto>> GetAllConsumosAsync()
        {
            var consumos = await _consumoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConsumoDto>>(consumos);
        }

        public async Task<ConsumoDto> GetConsumoByIdAsync(int id)
        {
            var consumo = await _consumoRepository.GetByIdAsync(id);
            return _mapper.Map<ConsumoDto>(consumo);
        }

        public async Task<ConsumoDto> CreateConsumoAsync(ConsumoDto consumoDto)
        {
            var consumo = _mapper.Map<Consumo>(consumoDto);
            var newConsumo = await _consumoRepository.AddAsync(consumo);
            return _mapper.Map<ConsumoDto>(newConsumo);
        }

        public async Task<ConsumoDto> UpdateConsumoAsync(int id, ConsumoDto consumoDto)
        {
            var consumo = _mapper.Map<Consumo>(consumoDto);
            var updatedConsumo = await _consumoRepository.UpdateAsync(consumo);
            return _mapper.Map<ConsumoDto>(updatedConsumo);
        }

        public async Task<bool> DeleteConsumoAsync(int id)
        {
            var consumo = await _consumoRepository.GetByIdAsync(id);
            if (consumo == null)
                return false;

            await _consumoRepository.DeleteAsync(id);
            return true;
        }
    }

