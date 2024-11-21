using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAlertaService
{
    Task<AlertaDTO> GetAlertaByIdAsync(int id);
    Task<IEnumerable<AlertaDTO>> GetAlertasByUsuarioIdAsync(int usuarioId);
    Task CreateAlertaAsync(AlertaDTO alertaDTO);
    Task UpdateAlertaAsync(AlertaDTO alertaDTO);
    Task DeleteAlertaAsync(int id);
}
