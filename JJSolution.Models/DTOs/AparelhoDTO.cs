public class AparelhoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } // Nome do aparelho
    public int Potencia { get; set; } // Potência em watts
    public string Tipo { get; set; } // Tipo (climatização, iluminação, etc.)
    public int UsuarioId { get; set; } // ID do usuário relacionado
}
