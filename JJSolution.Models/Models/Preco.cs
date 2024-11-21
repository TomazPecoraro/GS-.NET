using System;
using System.ComponentModel.DataAnnotations;

public class Preco
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public decimal PrecoKwh { get; set; } 
}
