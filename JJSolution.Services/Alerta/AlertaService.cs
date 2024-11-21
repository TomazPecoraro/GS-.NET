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

    public async Task<AlertaDTO> GetAlertaByIdAsync(int id)
    {
        var alerta = await _alertaRepository.GetAlertaByIdAsync(id);
        return _mapper.Map<AlertaDTO>(alerta);
    }

    public async Task<IEnumerable<AlertaDTO>> GetAlertasByUsuarioIdAsync(int usuarioId)
    {
        var alertas = await _alertaRepository.GetAlertasByUsuarioIdAsync(usuarioId);
        return _mapper.Map<IEnumerable<AlertaDTO>>(alertas);
    }

    public async Task CreateAlertaAsync(AlertaDTO alertaDTO)
    {
        var alerta = _mapper.Map<Alerta>(alertaDTO);
        await _alertaRepository.CreateAlertaAsync(alerta);
    }

    public async Task UpdateAlertaAsync(AlertaDTO alertaDTO)
    {
        var alerta = _mapper.Map<Alerta>(alertaDTO);
        await _alertaRepository.UpdateAlertaAsync(alerta);
    }

    public async Task DeleteAlertaAsync(int id)
    {
        await _alertaRepository.DeleteAlertaAsync(id);
    }
}
