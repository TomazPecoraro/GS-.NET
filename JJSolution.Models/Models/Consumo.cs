using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Consumo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public double ConsumoKwh { get; set; } // Energia consumida em kWh

    [Required]
    public decimal CustoEstimado { get; set; } // Custo do consumo

    [Required]
    public int? PrecoId { get; set; }

    // Relacionamento com Aparelho (FK)
    [Required]
    public int AparelhoId { get; set; }

    [ForeignKey("AparelhoId")]
    public Aparelho Aparelho { get; set; }

    [ForeignKey("PrecoId")]
    public Preco Preco { get; set; }

}
