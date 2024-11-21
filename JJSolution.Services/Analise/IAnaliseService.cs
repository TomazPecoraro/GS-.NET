using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAnaliseService
{
    Task<decimal> CalcularConsumoTotalAsync(int usuarioId);
    Task<IEnumerable<RelatorioConsumoDto>> GerarRelatorioConsumoAsync(int usuarioId, DateTime periodoInicio, DateTime periodoFim);
    Task<decimal> CalcularCustoEstimadoTotalAsync(int usuarioId);
}
