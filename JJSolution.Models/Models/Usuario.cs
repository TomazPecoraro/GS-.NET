using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Senha { get; set; }

    // Relacionamento 1:N com Aparelhos
    public ICollection<Aparelho> Aparelhos { get; set; }

    // Relacionamento com Alertas
    public ICollection<Alerta> Alertas { get; set; }
}
