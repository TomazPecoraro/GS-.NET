using System.Collections.Generic;
using System.Threading.Tasks;
public interface IAlertaService
{
    Task<IEnumerable<AlertaDto>> GetAllAlertasAsync();
    Task<AlertaDto> GetAlertaByIdAsync(int id);
    Task<AlertaDto> CreateAlertaAsync(AlertaDto alertaDTO);
    Task<AlertaDto> UpdateAlertaAsync(int id, AlertaDto alertaDTO);
    Task<bool> DeleteAlertaAsync(int id);
}
