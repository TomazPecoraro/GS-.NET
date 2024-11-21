public class Alerta
{
    public int Id { get; set; } // Chave primária
    public int UsuarioId { get; set; } // Chave estrangeira para Usuario
    public string Descricao { get; set; } // Texto do alerta
    public DateTime DataCriacao { get; set; } = DateTime.Now; // Data de criação padrão
    public bool Lido { get; set; } = false; // Status de leitura (false por padrão)

    // Relacionamento com Usuario
    public Usuario Usuario { get; set; }
}
