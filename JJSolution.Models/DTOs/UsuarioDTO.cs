public class UsuarioDto
{
    public int Id { get; set; } // ID do usuário
    public string Nome { get; set; } // Nome do usuário
    public string Email { get; set; } // Email do usuário
    public ICollection<int> AparelhosIds { get; set; } // IDs dos aparelhos relacionados
    public ICollection<int> AlertasIds { get; set; } // IDs dos alertas relacionados
}

