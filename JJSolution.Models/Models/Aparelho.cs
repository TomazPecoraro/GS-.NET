using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Aparelho
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    public int Potencia { get; set; } // em watts

    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; } // Ex.: climatização, iluminação

    // Relacionamento com Usuario (FK)
    [Required]
    public int UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }

    // Relacionamento 1:N com Consumo
    public ICollection<Consumo> Consumos { get; set; }
}
