using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AlertaService : IAlertaService
    {
        private readonly IAlertaRepository _alertaRepository;
        private readonly IMapper _mapper;

        public AlertaService(IAlertaRepository alertaRepository, IMapper mapper)
        {
            _alertaRepository = alertaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlertaDto>> GetAllAlertasAsync()
        {
            var alertas = await _alertaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlertaDto>>(alertas);
        }

        public async Task<AlertaDto> GetAlertaByIdAsync(int id)
        {
            var alerta = await _alertaRepository.GetByIdAsync(id);
            return _mapper.Map<AlertaDto>(alerta);
        }

        public async Task<AlertaDto> CreateAlertaAsync(AlertaDto alertaDto)
        {
            var alerta = _mapper.Map<Alerta>(alertaDto);
            var newAlerta = await _alertaRepository.AddAsync(alerta);
            return _mapper.Map<AlertaDto>(newAlerta);
        }

        public async Task<AlertaDto> UpdateAlertaAsync(int id, AlertaDto alertaDto)
        {
            var alerta = _mapper.Map<Alerta>(alertaDto);
            var updatedAlerta = await _alertaRepository.UpdateAsync(alerta);
            return _mapper.Map<AlertaDto>(updatedAlerta);
        }

        public async Task<bool> DeleteAlertaAsync(int id)
        {
            var alerta = await _alertaRepository.GetByIdAsync(id);
            if (alerta == null)
                return false;

            await _alertaRepository.DeleteAsync(id);
            return true;
        }
    }

