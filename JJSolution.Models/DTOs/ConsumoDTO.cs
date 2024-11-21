public class ConsumoDto
{
    public int Id { get; set; } // ID do consumo
    public DateTime Data { get; set; } // Data do consumo
    public double ConsumoKwh { get; set; } // Energia consumida em kWh
    public decimal CustoEstimado { get; set; } // Custo estimado do consumo
    public int? PrecoId { get; set; } // ID do preço relacionado (opcional)
    public int AparelhoId { get; set; } // ID do aparelho relacionado
}
