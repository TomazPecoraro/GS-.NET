public class AlertaDto
{
    public int Id { get; set; } // Chave primária
    public int UsuarioId { get; set; } // Chave estrangeira para Usuario
    public string Descricao { get; set; } // Texto do alerta
    public DateTime DataCriacao { get; set; } // Data de criação
    public bool Lido { get; set; } // Status de leitura
}
