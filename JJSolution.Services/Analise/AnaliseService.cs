using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AnaliseService : IAnaliseService
{
    private readonly IConsumoRepository _consumoRepository;
    private readonly IPrecoRepository _precoRepository;
    private readonly IMapper _mapper;

    public AnaliseService(IConsumoRepository consumoRepository, IPrecoRepository precoRepository, IMapper mapper)
    {
        _consumoRepository = consumoRepository;
        _precoRepository = precoRepository;
        _mapper = mapper;
    }

    // Calcular o consumo total de energia para um usuário em um determinado período
    public async Task<decimal> CalcularConsumoTotalAsync(int usuarioId)
    {
        var consumos = await _consumoRepository.GetConsumosByUsuarioIdAsync(usuarioId);

        // Somando o consumo total
        var totalConsumo = consumos.Sum(c => c.ConsumoKwh);
        return totalConsumo;
    }

    // Gerar relatório de consumo de energia para um usuário em um intervalo de datas
    public async Task<IEnumerable<RelatorioConsumoDto>> GerarRelatorioConsumoAsync(int usuarioId, DateTime periodoInicio, DateTime periodoFim)
    {
        var consumos = await _consumoRepository.GetConsumosByUsuarioIdAsync(usuarioId);

        // Filtrando consumos dentro do período fornecido
        var consumosNoPeriodo = consumos.Where(c => c.Data >= periodoInicio && c.Data <= periodoFim);

        // Mapeando para o DTO
        var relatorio = _mapper.Map<IEnumerable<RelatorioConsumoDto>>(consumosNoPeriodo);
        return relatorio;
    }

    // Calcular o custo total estimado para um usuário em um período
    public async Task<decimal> CalcularCustoEstimadoTotalAsync(int usuarioId)
    {
        var consumos = await _consumoRepository.GetConsumosByUsuarioIdAsync(usuarioId);
        var precoAtual = await _precoRepository.GetPrecoByIdAsync(1); // Exemplo de pegar o primeiro preço disponível

        // Calculando o custo com base no consumo de energia e o preço por kWh
        var custoTotal = consumos.Sum(c => c.ConsumoKwh * precoAtual.PrecoKwh);
        return custoTotal;
    }
}
